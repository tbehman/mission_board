using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace mission_board
{
    public partial class splash_screen : Form
    {
        public string pdf_letter_directory = Directory.GetCurrentDirectory() + "\\Missionary_Letters";
        public string jpg_letter_directory = Directory.GetCurrentDirectory() + "\\Missionary_Letters\\jpg\\";
        public float letter_dpi = 800;

        public splash_screen()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged +=
                new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);


            InitializeComponent();
            bw.RunWorkerAsync();
            
            
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            convert_pdf(pdf_letter_directory, jpg_letter_directory, letter_dpi);
            worker.ReportProgress(10);
            System.Threading.Thread.Sleep(3000);
            
            // for (int i = 1; (i <= 10); i++)
            // {
            //     if ((worker.CancellationPending == true))
            //     {
            //         e.Cancel = true;
            //         break;
            //     }
            //     else
            //     {
            //         // Perform a time consuming operation and report progress.
            //         System.Threading.Thread.Sleep(500);
            //         worker.ReportProgress((i * 10));
            //     }
            // }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            splash_screen.ActiveForm.Dispose();
           // Form1.ActiveForm.Show();
            //  if ((e.Cancelled == true))
            //  {
            //      this.tbProgress.Text = "Canceled!";
            //  }
            //
            //  else if (!(e.Error == null))
            //  {
            //      this.tbProgress.Text = ("Error: " + e.Error.Message);
            //  }
            //
            //  else
            //  {
            //      this.tbProgress.Text = "Done!";
            //  }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            for (int index = 0; index <= 100; index++)
            {
                this.progressBar1.Value = index;
                System.Threading.Thread.Sleep(20);
            }
           // this.progressBar1.Value += 100; //tbProgress.Text = (e.ProgressPercentage.ToString() + "%");
        }

        // This can be used to optimize the load time for the missionary letters
        public bool convert_pdf(string source_directory, string target_directory, float dpi)
        {
            if (!Directory.Exists(source_directory))
                return false;

            if (!Directory.Exists(target_directory))
            {
                try
                {
                    Directory.CreateDirectory(target_directory);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            string[] fileEntries = Directory.GetFiles(source_directory);
            string jpg_file_name = "";

            foreach (string fileName in fileEntries)
            {
                try
                {
                    using (var document = PdfiumViewer.PdfDocument.Load(fileName))
                    {
                        for (int index = 0; index < document.PageCount; index++)
                        {
                            jpg_file_name = target_directory + fileName.Substring(fileName.LastIndexOf("\\") + 1) + index.ToString() + ".jpg";

                            if (!File.Exists(jpg_file_name))
                            {
                                var image = document.Render(index, dpi, dpi, PdfiumViewer.PdfRenderFlags.LcdText);
                                image.Save(jpg_file_name, ImageFormat.Jpeg);
                            }
                            else
                            {
                                // do nothing but save time
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    // handle exception here;
                }
            }
            return true;
        }
    }
}
