namespace mission_board
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.missionary_listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.recent_letter_listBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.back_to_map_button = new System.Windows.Forms.Button();
            this.keyboard1 = new mission_board_keyboard.keyboard();
            this.send_mail = new System.Windows.Forms.Button();
            this.missionary_letter_list_label = new System.Windows.Forms.Label();
            this.mission_field_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.profile_pictureBox = new System.Windows.Forms.PictureBox();
            this.missionary_letter_listBox = new System.Windows.Forms.ListBox();
            this.infobox_panel = new System.Windows.Forms.Panel();
            this.field_label = new System.Windows.Forms.Label();
            this.view_profile_button = new System.Windows.Forms.Button();
            this.inforbox_name_label = new System.Windows.Forms.Label();
            this.close_button = new System.Windows.Forms.Button();
            this.home_button = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.mapUserControl1 = new mission_board.MapUserControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile_pictureBox)).BeginInit();
            this.infobox_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // missionary_listBox
            // 
            this.missionary_listBox.BackColor = System.Drawing.Color.White;
            this.missionary_listBox.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missionary_listBox.FormattingEnabled = true;
            this.missionary_listBox.ItemHeight = 18;
            this.missionary_listBox.Location = new System.Drawing.Point(38, 203);
            this.missionary_listBox.Name = "missionary_listBox";
            this.missionary_listBox.Size = new System.Drawing.Size(163, 310);
            this.missionary_listBox.TabIndex = 1;
            this.missionary_listBox.SelectedIndexChanged += new System.EventHandler(this.missionary_listBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 27);
            this.label1.TabIndex = 10;
            this.label1.Text = "Missionaries";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(35, 556);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "Recent Letters";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // recent_letter_listBox
            // 
            this.recent_letter_listBox.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recent_letter_listBox.FormattingEnabled = true;
            this.recent_letter_listBox.ItemHeight = 18;
            this.recent_letter_listBox.Location = new System.Drawing.Point(40, 587);
            this.recent_letter_listBox.Name = "recent_letter_listBox";
            this.recent_letter_listBox.Size = new System.Drawing.Size(161, 238);
            this.recent_letter_listBox.TabIndex = 12;
            this.recent_letter_listBox.SelectedIndexChanged += new System.EventHandler(this.recent_letter_listBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::mission_board.Properties.Resources.profile_background_small;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.back_to_map_button);
            this.panel1.Controls.Add(this.keyboard1);
            this.panel1.Controls.Add(this.send_mail);
            this.panel1.Controls.Add(this.missionary_letter_list_label);
            this.panel1.Controls.Add(this.mission_field_label);
            this.panel1.Controls.Add(this.name_label);
            this.panel1.Controls.Add(this.profile_pictureBox);
            this.panel1.Controls.Add(this.missionary_letter_listBox);
            this.panel1.Location = new System.Drawing.Point(223, -9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1709, 1110);
            this.panel1.TabIndex = 3;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(818, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(616, 888);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(347, 510);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Send This Letter To Me";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 510);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Go To Map Location";
            // 
            // back_to_map_button
            // 
            this.back_to_map_button.BackgroundImage = global::mission_board.Properties.Resources.telescope1;
            this.back_to_map_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.back_to_map_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.back_to_map_button.Location = new System.Drawing.Point(113, 545);
            this.back_to_map_button.Name = "back_to_map_button";
            this.back_to_map_button.Size = new System.Drawing.Size(145, 99);
            this.back_to_map_button.TabIndex = 13;
            this.back_to_map_button.UseVisualStyleBackColor = true;
            this.back_to_map_button.Click += new System.EventHandler(this.back_to_map_button_Click);
            // 
            // keyboard1
            // 
            this.keyboard1.BackColor = System.Drawing.Color.Black;
            this.keyboard1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("keyboard1.BackgroundImage")));
            this.keyboard1.Location = new System.Drawing.Point(-248, 704);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(920, 366);
            this.keyboard1.TabIndex = 12;
            this.keyboard1.Visible = false;
            this.keyboard1.SendButtonClick += new System.EventHandler(this.keyboard1_SendButtonClick);
            this.keyboard1.Leave += new System.EventHandler(this.keyboard1_Leave);
            // 
            // send_mail
            // 
            this.send_mail.BackgroundImage = global::mission_board.Properties.Resources.email3;
            this.send_mail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.send_mail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.send_mail.Location = new System.Drawing.Point(386, 545);
            this.send_mail.Name = "send_mail";
            this.send_mail.Size = new System.Drawing.Size(145, 99);
            this.send_mail.TabIndex = 6;
            this.send_mail.UseVisualStyleBackColor = true;
            this.send_mail.Click += new System.EventHandler(this.send_mail_Click);
            // 
            // missionary_letter_list_label
            // 
            this.missionary_letter_list_label.AutoSize = true;
            this.missionary_letter_list_label.BackColor = System.Drawing.Color.Transparent;
            this.missionary_letter_list_label.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missionary_letter_list_label.Location = new System.Drawing.Point(635, 126);
            this.missionary_letter_list_label.Name = "missionary_letter_list_label";
            this.missionary_letter_list_label.Size = new System.Drawing.Size(88, 25);
            this.missionary_letter_list_label.TabIndex = 5;
            this.missionary_letter_list_label.Text = "Letters";
            // 
            // mission_field_label
            // 
            this.mission_field_label.AutoSize = true;
            this.mission_field_label.BackColor = System.Drawing.Color.Transparent;
            this.mission_field_label.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mission_field_label.Location = new System.Drawing.Point(30, 64);
            this.mission_field_label.Name = "mission_field_label";
            this.mission_field_label.Size = new System.Drawing.Size(178, 31);
            this.mission_field_label.TabIndex = 4;
            this.mission_field_label.Text = "Mission Field";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.BackColor = System.Drawing.Color.Transparent;
            this.name_label.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.ForeColor = System.Drawing.Color.Black;
            this.name_label.Location = new System.Drawing.Point(29, 19);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(305, 38);
            this.name_label.TabIndex = 3;
            this.name_label.Text = "Missionary Name";
            // 
            // profile_pictureBox
            // 
            this.profile_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profile_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.profile_pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.profile_pictureBox.Location = new System.Drawing.Point(35, 108);
            this.profile_pictureBox.Name = "profile_pictureBox";
            this.profile_pictureBox.Size = new System.Drawing.Size(550, 381);
            this.profile_pictureBox.TabIndex = 2;
            this.profile_pictureBox.TabStop = false;
            // 
            // missionary_letter_listBox
            // 
            this.missionary_letter_listBox.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missionary_letter_listBox.FormattingEnabled = true;
            this.missionary_letter_listBox.ItemHeight = 16;
            this.missionary_letter_listBox.Location = new System.Drawing.Point(640, 154);
            this.missionary_letter_listBox.Name = "missionary_letter_listBox";
            this.missionary_letter_listBox.Size = new System.Drawing.Size(156, 196);
            this.missionary_letter_listBox.TabIndex = 0;
            this.missionary_letter_listBox.SelectedIndexChanged += new System.EventHandler(this.missionary_letter_listBox_SelectedIndexChanged);
            // 
            // infobox_panel
            // 
            this.infobox_panel.BackColor = System.Drawing.Color.LightGray;
            this.infobox_panel.BackgroundImage = global::mission_board.Properties.Resources.old_brown_paper_texture;
            this.infobox_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infobox_panel.Controls.Add(this.field_label);
            this.infobox_panel.Controls.Add(this.view_profile_button);
            this.infobox_panel.Controls.Add(this.inforbox_name_label);
            this.infobox_panel.Location = new System.Drawing.Point(12, 850);
            this.infobox_panel.Name = "infobox_panel";
            this.infobox_panel.Size = new System.Drawing.Size(205, 100);
            this.infobox_panel.TabIndex = 6;
            // 
            // field_label
            // 
            this.field_label.AutoSize = true;
            this.field_label.BackColor = System.Drawing.Color.Transparent;
            this.field_label.Font = new System.Drawing.Font("Segoe Script", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.field_label.Location = new System.Drawing.Point(20, 31);
            this.field_label.MinimumSize = new System.Drawing.Size(50, 0);
            this.field_label.Name = "field_label";
            this.field_label.Size = new System.Drawing.Size(50, 20);
            this.field_label.TabIndex = 3;
            this.field_label.Text = "Field";
            this.field_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // view_profile_button
            // 
            this.view_profile_button.BackColor = System.Drawing.SystemColors.Menu;
            this.view_profile_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.view_profile_button.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view_profile_button.Location = new System.Drawing.Point(45, 56);
            this.view_profile_button.Name = "view_profile_button";
            this.view_profile_button.Size = new System.Drawing.Size(106, 30);
            this.view_profile_button.TabIndex = 2;
            this.view_profile_button.Text = "View Profile";
            this.view_profile_button.UseVisualStyleBackColor = false;
            this.view_profile_button.Click += new System.EventHandler(this.view_profile_button_Click);
            // 
            // inforbox_name_label
            // 
            this.inforbox_name_label.AutoSize = true;
            this.inforbox_name_label.BackColor = System.Drawing.Color.Transparent;
            this.inforbox_name_label.Font = new System.Drawing.Font("Segoe Script", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inforbox_name_label.Location = new System.Drawing.Point(20, 4);
            this.inforbox_name_label.MinimumSize = new System.Drawing.Size(50, 0);
            this.inforbox_name_label.Name = "inforbox_name_label";
            this.inforbox_name_label.Size = new System.Drawing.Size(158, 27);
            this.inforbox_name_label.TabIndex = 1;
            this.inforbox_name_label.Text = "Missionary Name";
            this.inforbox_name_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // close_button
            // 
            this.close_button.BackgroundImage = global::mission_board.Properties.Resources.pbc;
            this.close_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Location = new System.Drawing.Point(50, 904);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(148, 110);
            this.close_button.TabIndex = 7;
            this.close_button.UseMnemonic = false;
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            this.close_button.MouseClick += new System.Windows.Forms.MouseEventHandler(this.close_button_MouseClick);
            // 
            // home_button
            // 
            this.home_button.BackgroundImage = global::mission_board.Properties.Resources.globe;
            this.home_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.home_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home_button.Location = new System.Drawing.Point(50, 4);
            this.home_button.Name = "home_button";
            this.home_button.Size = new System.Drawing.Size(141, 142);
            this.home_button.TabIndex = 6;
            this.home_button.UseVisualStyleBackColor = true;
            this.home_button.Click += new System.EventHandler(this.home_button_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(223, -9);
            this.elementHost1.Margin = new System.Windows.Forms.Padding(2);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1698, 1110);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.mapUserControl1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1604, 904);
            this.ControlBox = false;
            this.Controls.Add(this.recent_letter_listBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.infobox_panel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.home_button);
            this.Controls.Add(this.missionary_listBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1376, 856);
            this.Name = "Form1";
            this.Text = "Mission Board";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile_pictureBox)).EndInit();
            this.infobox_panel.ResumeLayout(false);
            this.infobox_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private MapUserControl mapUserControl1;
        private System.Windows.Forms.ListBox missionary_listBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox missionary_letter_listBox;
        private System.Windows.Forms.Button home_button;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.PictureBox profile_pictureBox;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label mission_field_label;
        private System.Windows.Forms.Label missionary_letter_list_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel infobox_panel;
        private System.Windows.Forms.Label inforbox_name_label;
        private System.Windows.Forms.Button view_profile_button;
        private System.Windows.Forms.Label field_label;
        private mission_board_keyboard.keyboard keyboard1;
        private System.Windows.Forms.Button send_mail;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button back_to_map_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox recent_letter_listBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

