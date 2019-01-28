using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Maps.MapControl.WPF;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using System.Drawing.Imaging;

namespace mission_board
{
    public partial class Form1 : Form
    {
        public const string missionary_data_file_name = "missionary_data.csv";
        public const string error_log_file_name = "error.log";
        public List<FileInfo> missionary_letters;
        public string selected_letter;
        public string selected_missionary;
        public int max_list_letters = 15;

        public int move_tracker = 0;
        public string selected_pushpin_name = "";

        public string pdf_letter_directory = Directory.GetCurrentDirectory() + "\\Missionary_Letters";
        public string jpg_letter_directory = Directory.GetCurrentDirectory() + "\\Missionary_Letters\\jpg\\";
        public float letter_dpi = 500;

        public SortedList<string, missionary> missionary_list = new SortedList<string, missionary>();

        public bool close_form = false;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //Set Credentials for map
            mapUserControl1.Map.CredentialsProvider = new ApplicationIdCredentialsProvider("AonE3CQFKLAwXl7gB7sO4OJBc_ENtyOHzuE4JfycY_EPzNlqlGEnuL1vUeo8Tl8d");
            mapUserControl1.Map.AnimationLevel = AnimationLevel.None;
            mapUserControl1.Map.SupportedManipulations = System.Windows.Input.Manipulations.Manipulations2D.Scale | System.Windows.Input.Manipulations.Manipulations2D.Translate;
            mapUserControl1.Map.ZoomLevel = 3;
            mapUserControl1.Map.TargetViewChanged += Map_TargetViewChanged;
            mapUserControl1.Map.ViewChangeOnFrame += Map_ViewChangeOnFrame;
            show_map(true);

            keyboard1.Location = new Point(500, 700);

            if (!load_missionary_data(missionary_data_file_name))
            {
                close_form = true;
            }
            load_map_markers();
            load_missionary_letters();
            populate_recent_missionary_letters_list();
            load_missionary_list();

        }

        public List<string> get_letter_pages(string pdf)
        {
            string pdf_file_loc;
            List<string> letter_pages = new List<string>();
            try
            {
                using (var document = PdfiumViewer.PdfDocument.Load(pdf))
                {
                    for (int index = 0; index < document.PageCount; index++)
                    {
                        pdf_file_loc = jpg_letter_directory + pdf.Substring(pdf.LastIndexOf("\\") + 1) + index.ToString() + ".jpg";
                        if (File.Exists(pdf_file_loc))
                            letter_pages.Add(pdf_file_loc);
                        else
                        {
                            // Coverts pdf to jpeg. I thank the Lord for this render method. It's fast and blessed
                            var image = document.Render(index, letter_dpi, letter_dpi, PdfiumViewer.PdfRenderFlags.LcdText);
                            image.Save(pdf_file_loc, ImageFormat.Jpeg);
                            letter_pages.Add(pdf_file_loc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                // handle exception here;
            }
            return letter_pages;

        }

        private void show_map(bool show_map)
        {
            if (show_map)
            {
                panel1.Visible = false;
                infobox_panel.Visible = false;
                elementHost1.Visible = true;
                //Controls.SetChildIndex(elementHost1, 1);
                //Controls.SetChildIndex(infobox_panel, 0);
            }
            else
            {
                panel1.Visible = true;
                infobox_panel.Visible = false;
                elementHost1.Visible = false;
            }
        }

        // This method makes it so the pop up on the missionary marker stay open if it senses a little movement (most likely unintential movement)
        private void Map_ViewChangeOnFrame(object sender, MapEventArgs e)
        {
            if (infobox_panel.Visible)
            {
                move_tracker += 1;
                if (move_tracker > 3)
                {
                    infobox_panel.Visible = false;
                    move_tracker = 0;
                }
            }
        }

        private void Map_TargetViewChanged(object sender, MapEventArgs e)
        {
            if (mapUserControl1.Map.ZoomLevel > 15)
                mapUserControl1.Map.ZoomLevel = 15;
            if (mapUserControl1.Map.ZoomLevel < 3)
                mapUserControl1.Map.ZoomLevel = 3;

        }

        private void load_map_markers()
        {
            foreach (missionary miss in missionary_list.Values)
            {
                Pushpin pushpin = new Pushpin();
                pushpin.Location = new Location(miss.Latitude, miss.Longitude);
                pushpin.Name = miss.DisplayName.Replace(" ", "_");
                pushpin.MouseDown += Pushpin_MouseDown;
                mapUserControl1.Map.Children.Add(pushpin);
            }
        }

        private void Pushpin_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Pushpin pin = (Pushpin)sender;
            string missionary_name = pin.Name.Replace("_", " ");
            //Controls.SetChildIndex(infobox_panel, 0);

            // The most simple solution that took me a long time to get to
            Point coordinates = Cursor.Position;

            infobox_panel.Visible = false;
            infobox_panel.Location = new Point(coordinates.X, coordinates.Y);//((int)(calculate_infobox_positionX(pin) - elementHost1.Location.X), (int)(calculate_infobox_positionY(pin) + elementHost1.Location.Y));
            infobox_panel.Visible = true;
            infobox_panel.BringToFront();
            move_tracker = 0;
            inforbox_name_label.Text = missionary_name;
            field_label.Text = missionary_list[missionary_name].MissionField;
            selected_pushpin_name = pin.Name;
        }

        private bool load_missionary_data(string csv_file)
        {
            int valid_column_count = 9;

            if (!File.Exists(csv_file))
            {
                write_error_log("FATAL ERROR: " + csv_file + " is either missing or corrupted." + Environment.NewLine);
                return false;
            }
            try
            {
                string[] missionary_data_rows = File.ReadAllLines(csv_file);
                string[] split_line;
                missionary missionary_obj;
                foreach (string line in missionary_data_rows)
                {
                    if (!line.Contains("Display_Name")) // skip first line, I don't like doing it this way, shameful
                    {
                        // [0]          [1]             [2]         [3]         [4]         [5]         [6]     [7]
                        // Display_Name	Mission_Field	First_Name	Last_Name	Latitude	Longitude	Email	Profile_Picture

                        split_line = line.Split(",".ToCharArray());
                        missionary_obj = new missionary();

                        if (split_line.Length == valid_column_count) // so we don't go out of bounds on the array
                        {
                            missionary_obj.DisplayName = split_line[0].Trim();
                            missionary_obj.MissionField = split_line[1].Trim();
                            missionary_obj.FirstName = split_line[2].Trim();
                            missionary_obj.LastName = split_line[3].Trim();
                            missionary_obj.Email = split_line[6].Trim();
                            missionary_obj.ProfilePicture = split_line[7].Trim();
                            missionary_obj.LetterAlias = split_line[8].Trim();
                            try
                            {
                                missionary_obj.Latitude = Convert.ToDouble(split_line[4]);
                            }
                            catch (OverflowException)
                            {
                                write_error_log(split_line[4] + " is outside the range of the Int64 type for " + missionary_obj.DisplayName + Environment.NewLine);
                            }
                            catch (FormatException)
                            {
                                write_error_log(split_line[4] + "  is not in a recognizable latitude format for " + missionary_obj.DisplayName + Environment.NewLine);
                            }
                            try
                            {
                                missionary_obj.Longitude = Convert.ToDouble(split_line[5]);
                            }
                            catch (OverflowException)
                            {
                                write_error_log(split_line[5] + " is outside the range of the Int64 type for " + missionary_obj.DisplayName + Environment.NewLine);
                            }
                            catch (FormatException)
                            {
                                write_error_log(split_line[5] + "  is not in a recognizable longitude format for " + missionary_obj.DisplayName + Environment.NewLine);
                            }

                            missionary_list.Add(split_line[0], missionary_obj);
                        }
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please make sure that " + csv_file + " is closed and not in use.");
                write_error_log(csv_file + "  is open or in use."+ Environment.NewLine);
                return false;
                
            }
            return true;
        }

        private void write_error_log(string error_string)
        {
            String timeStamp = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ":";
            File.AppendAllText(error_log_file_name, timeStamp + " " + error_string);
        }

        private void load_missionary_letters()
        {
            string missionary_name = "";

            missionary_letters = new DirectoryInfo(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Missionary_Letters").GetFiles()
                                                  .OrderByDescending(f => f.LastAccessTime)
                                                  .ToList();

            clear_missionary_letters();
            foreach (FileInfo letter in missionary_letters)
            {
                missionary_name = lookup_letter_ownership(letter.Name);

                if (missionary_name != null)
                {
                    if (!missionary_list[missionary_name].Letters.Contains(letter))
                        missionary_list[missionary_name].Letters.Add(letter);
                }
                else
                {
                    // write error that the letter name doesn't match a missionary
                }
            }
        }

        private void populate_recent_missionary_letters_list()
        {
            string[] files = System.IO.Directory.GetFiles(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Missionary_Letters");

            var sortedFiles = new DirectoryInfo(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Missionary_Letters").GetFiles()
                                                  .OrderByDescending(f => f.LastAccessTime)
                                                  .ToList();
            string missionary_name = "";
            int month = 0;
            string month_str = "",day_str = "";
            int day = 0;
            //recent_letter_listView1.Items.Clear();
            recent_letter_listBox.Items.Clear();

            if (sortedFiles.Count < max_list_letters)
                max_list_letters = sortedFiles.Count;
            List<string> miss = new List<string>();

            foreach (FileInfo letter in sortedFiles)
            {
                missionary_name = lookup_letter_ownership(letter.Name);

                if (missionary_name != null)
                {
                    if (!miss.Contains(missionary_name))
                    {
                        if (miss.Count < max_list_letters)
                        {
                            month = letter.LastAccessTime.Month;
                            day = letter.LastAccessTime.Day;
                            if (month < 10)
                                month_str = "0" + month.ToString();
                            else
                                month_str = month.ToString();
                            if (day < 10)
                                day_str = "0" + day.ToString();
                            else
                                day_str = day.ToString();
                            recent_letter_listBox.Items.Add((month_str + "/" + day_str + " - ").PadRight(8) + missionary_name);
                            miss.Add(missionary_name);
                        }
                        else
                            break;
                    }
                }
                else
                {
                    // don't know who the letter belongs too
                }
            }
        }

        private void populate_individual_missionary_letter_list(string name)
        {
            missionary_letter_listBox.Items.Clear();
            foreach (FileInfo letter in missionary_list[name].Letters)
            {
                missionary_letter_listBox.Items.Add(name + " - " + letter.LastAccessTime.Month + "/" + letter.LastAccessTime.Day);
            }
        }

        // Critical method for associating a letter with the missionary
        private string lookup_letter_ownership(string letter_name)
        {
            string missionary_name = null;
            letter_name = letter_name.ToLower();

            foreach (missionary miss in missionary_list.Values)
            {
                // This alias has to be in the letter name!!! Make sure it's unique!!
                if (letter_name.Contains(miss.LetterAlias.ToLower()))
                { 
                    missionary_name = miss.DisplayName;
                    break;
                }

            }
            return missionary_name;
        }

        private void load_missionary_list()
        {
            SortedList<string, string> missionary_list2 = new SortedList<string, string>();

            // Sort alphabetically
            foreach (missionary miss in missionary_list.Values)
            {
                missionary_list2.Add(miss.LastName + "-" + miss.FirstName, miss.LastName + ", " + miss.FirstName);
            }

            foreach (string miss in missionary_list2.Values)
            {
                missionary_listBox.Items.Add(miss);
            }
        }

        private void clear_missionary_letters()
        {
            foreach (missionary miss in missionary_list.Values)
                miss.Letters.Clear();
        }

        private void missionary_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (missionary_listBox.SelectedIndex >= 0)
            {
                show_map(true);
                infobox_panel.Visible = false;
                string name = missionary_listBox.Items[missionary_listBox.SelectedIndex].ToString();
                string missionary_name = lookup_missionary_listbox(name);
                // mapUserControl1.Map.Center.Latitude = missionary_list[missionary_name].Latitude;
                // mapUserControl1.Map.Center.Longitude = missionary_list[missionary_name].Longitude;
                Location center_map = new Location(missionary_list[missionary_name].Latitude,
                                                   missionary_list[missionary_name].Longitude);
                mapUserControl1.Map.SetView(center_map, 5);

                int element_center_x = elementHost1.Width / 2;
                int element_center_y = elementHost1.Height / 2;
                infobox_panel.Location = new Point(element_center_x + elementHost1.Left, element_center_y + elementHost1.Top);//((int)(calculate_infobox_positionX(pin) - elementHost1.Location.X), (int)(calculate_infobox_positionY(pin) + elementHost1.Location.Y));
                infobox_panel.Visible = true;
                infobox_panel.BringToFront();
                move_tracker = 0;
                inforbox_name_label.Text = missionary_name;
                field_label.Text = missionary_list[missionary_name].MissionField;
                selected_pushpin_name = name;
                //update_profile(name, null);

            }
        }

        // Critical method for associating a letter with the missionary
        private string lookup_missionary_listbox(string name)
        {
            string missionary_name = null;
            name = name.ToLower();

            foreach (missionary miss in missionary_list.Values)
            {
                
                if (name.Contains(miss.LetterAlias.ToLower()) ||
                    (name.Contains(miss.FirstName.ToLower()) && name.Contains(miss.LastName.ToLower())))
                {
                    missionary_name = miss.DisplayName;
                    break;
                }

            }
            return missionary_name;
        }

        private void update_profile(string name)
        {
            show_map(false);
            keyboard1.Visible = false;
            string missionary_name = lookup_missionary_listbox(name);
            selected_missionary = missionary_name;

            if (File.Exists("Profile_Pictures\\" + missionary_list[missionary_name].ProfilePicture))
            {
                profile_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                profile_pictureBox.Image = System.Drawing.Image.FromFile("Profile_Pictures\\" + missionary_list[missionary_name].ProfilePicture);
            }
            else
                profile_pictureBox.Image = null;
            name_label.Text = missionary_name;
            mission_field_label.Text = missionary_list[missionary_name].MissionField;

            if (missionary_list[missionary_name].Letters.Count > 0)
            {
                selected_letter = missionary_list[missionary_name].Letters[0].FullName;
                //pdfDocumentViewer1.LoadFromFile(missionary_list[missionary_name].Letters[0].FullName); // not good, you should pass a index or lookup the selected letter. don't asume!!!!!!
                pictureBox1.Image = Image.FromFile(get_letter_pages(missionary_list[missionary_name].Letters[0].FullName)[0]);

            }
            else
            {
                pictureBox1.Image = null;
                // pdfDocumentViewer1.LoadFromFile("No Letter Present.pdf");
                // Nothing to load
            }
            populate_individual_missionary_letter_list(missionary_name);

        }

        private void missionary_letter_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (missionary_letter_listBox.SelectedIndex >= 0)
            {
                string missionary_name = missionary_letter_listBox.Items[missionary_letter_listBox.SelectedIndex].ToString();

                missionary_name = lookup_missionary_listbox(missionary_name);

                if (!missionary_list.ContainsKey(missionary_name))
                    missionary_name = null;

                if (missionary_name != null)
                {
                    selected_letter = missionary_list[missionary_name].Letters[missionary_letter_listBox.SelectedIndex].FullName;
                    //  pdfDocumentViewer1.LoadFromFile(missionary_list[missionary_name].Letters[missionary_letter_listBox.SelectedIndex].FullName);
                    pictureBox1.Image = Image.FromFile(get_letter_pages(selected_letter)[0]);

                }
                else
                {
                    // can't load profile letter
                }
            }
        }

        //private void load_picture_box
        private void home_button_Click(object sender, EventArgs e)
        {
            show_map(true);
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void down_button_Click(object sender, EventArgs e)
        {

            missionary_listBox.TopIndex += 1;
        }

        private void scroll_up_button_Click(object sender, EventArgs e)
        {
            missionary_listBox.TopIndex -= 1;
        }

        private void recent_letter_listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void view_profile_button_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(selected_pushpin_name);
            show_map(false);
            //infobox_panel.Visible = false;
            update_profile(selected_pushpin_name);
        }

        private void send_mail_Click(object sender, EventArgs e)
        {
            keyboard1.Text = "";
            keyboard1.Visible = true;
            keyboard1.BringToFront();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            send_email(keyboard1.Text, "parkviewmissions@gmail.com", "smtp.gmail.com", "Mission Board Letter", "", selected_letter);
        }

        public void send_email(string recipient, string sender, string smtp_server, string subject, string message, string attachment)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                //foreach (String str_email in recipient)
                mailMsg.To.Add(new MailAddress(recipient));
                mailMsg.From = new MailAddress(sender);
                mailMsg.Subject = subject;
                mailMsg.IsBodyHtml = true;
                mailMsg.Body = message;
                mailMsg.Attachments.Add(new Attachment(attachment));
                mailMsg.Priority = MailPriority.Normal;

                SmtpClient smtpClient = new SmtpClient(smtp_server);
                smtpClient.Port = 587; // for gmail

                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("parkviewmissions@gmail.com", "stark9355");
                smtpClient.Send(mailMsg);
                // MessageBox.Show("Here");
            }
            catch (Exception e)
            {
                //Console.WriteLine(Environment.NewLine + "Email Failed");
                File.AppendAllText("error.log", DateTime.Now.ToShortDateString() + " "
                                            + DateTime.Now.ToShortTimeString() + " "
                                            + e.Message + Environment.NewLine);
            }

        }

        private void keyboard1_SendButtonClick(object sender, EventArgs e)
        {
            if (keyboard1.Text == "stark9355")
                Form1.ActiveForm.Dispose();
            keyboard1.Visible = false;

            if (backgroundWorker1.IsBusy != true)
                backgroundWorker1.RunWorkerAsync();
        }

        private void back_to_map_button_Click(object sender, EventArgs e)
        {
            show_map(true);
            infobox_panel.Visible = false;
            string missionary_name = selected_missionary;
            // mapUserControl1.Map.Center.Latitude = missionary_list[missionary_name].Latitude;
            // mapUserControl1.Map.Center.Longitude = missionary_list[missionary_name].Longitude;
            Location center_map = new Location(missionary_list[missionary_name].Latitude,
                                               missionary_list[missionary_name].Longitude);
            mapUserControl1.Map.SetView(center_map, 5);

            int element_center_x = elementHost1.Width / 2;
            int element_center_y = elementHost1.Height / 2;
            infobox_panel.Location = new Point(element_center_x + elementHost1.Left, element_center_y + elementHost1.Top);//((int)(calculate_infobox_positionX(pin) - elementHost1.Location.X), (int)(calculate_infobox_positionY(pin) + elementHost1.Location.Y));
            infobox_panel.Visible = true;
            infobox_panel.BringToFront();
            move_tracker = 0;
            inforbox_name_label.Text = missionary_name;
            field_label.Text = missionary_list[missionary_name].MissionField;
            selected_pushpin_name = missionary_name;
            //update_profile(name, null);


        }

        private void keyboard1_Leave(object sender, EventArgs e)
        {
            //MessageBox.Show("please");
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            keyboard1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // pdfDocumentViewer1.SetZoom(Spire.PdfViewer.Forms.ZoomMode.FitWidth);
        }

        private void recent_letter_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (recent_letter_listBox.SelectedItems.Count > 0)
            {
                string missionary_letter = recent_letter_listBox.Items[recent_letter_listBox.SelectedIndex].ToString();
                missionary_letter = missionary_letter.Substring(8).Trim();

                if (missionary_list.ContainsKey(missionary_letter))
                    missionary_letter = missionary_list[missionary_letter].LetterAlias;
                else
                    missionary_letter = null;

                if (missionary_letter != null)
                {
                    update_profile(missionary_letter); // pass the proper parameter!!!! not null!!
                }
                else
                {
                    // can't load profile
                }
            }
        }

        private void close_button_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (close_form)
                Form1.ActiveForm.Dispose();
        }
    }
}
