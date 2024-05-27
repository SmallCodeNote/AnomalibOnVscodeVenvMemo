using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WinFormStringCnvClass;

using OnnxRuntime_ImageClassification;


namespace OnnxRuntime_AnomalibInference
{
    public partial class Form1 : Form
    {
        string thisExeDirPath;
        public Form1()
        {
            InitializeComponent();
            thisExeDirPath = Path.GetDirectoryName(Application.ExecutablePath);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TEXT|*.txt";
            if (false && ofd.ShowDialog() == DialogResult.OK)
            {
                WinFormStringCnv.setControlFromString(this, File.ReadAllText(ofd.FileName));
            }
            else
            {
                string paramFilename = Path.Combine(thisExeDirPath, "_param.txt");
                if (File.Exists(paramFilename))
                {
                    WinFormStringCnv.setControlFromString(this, File.ReadAllText(paramFilename));
                }
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string FormContents = WinFormStringCnv.ToString(this);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "TEXT|*.txt";

            if (false && sfd.ShowDialog() == DialogResult.OK)
            {

                File.WriteAllText(sfd.FileName, FormContents);
            }
            else
            {
                string paramFilename = Path.Combine(thisExeDirPath, "_param.txt");
                File.WriteAllText(paramFilename, FormContents);
            }

        }

        private void button_LoadOnnxFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ONNX|*.onnx";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            textBox_OnnxFilePath.Text = ofd.FileName;
        }

        private void button_LoadImageFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK) return;

            textBox_ImageFilesPath.Text += string.Join("\r\n", ofd.FileNames) + "\r\n";
        }

        private void panelImagesResetHorizontal()
        {
            if (this.InvokeRequired) { this.Invoke((Action)(() => panelImagesResetHorizontal())); }
            else
            {
                panel_Images.Controls.Clear();
                panel_Images.Width = 0;

                if (!int.TryParse(textBox_panelWidth.Text, out panelImageAddHorizontalMaxWidth))
                {
                    panelImageAddHorizontalMaxWidth = panel_ImagesFrame.Width;
                }
            }
        }

        int panelImageAddHorizontalMaxWidth = 512;


        private void panelImageAddHorizontal(Bitmap bitmap, string name, float viewHeightFloat, string imageFilePath, string[] imageFilePaths)
        {
            if (this.InvokeRequired) { this.Invoke((Action)(() => panelImageAddHorizontal(bitmap, name, viewHeightFloat, imageFilePath, imageFilePaths))); }
            else
            {
                int viewHeight = 0;
                if (float.IsNaN(viewHeightFloat))
                {
                    viewHeight = panel_Images.Height;
                }
                else
                {
                    viewHeight = (int)viewHeightFloat;
                }

                int indexMaxX = panelImageAddHorizontalMaxWidth / (int)((bitmap.Width * viewHeight) / bitmap.Height);
                int index = Array.IndexOf(imageFilePaths, imageFilePath);
                int iY = (int)(Math.Floor(((double)index / (double)indexMaxX)));
                int iX = index - indexMaxX * iY;

                Label label = new Label();
                label.Text = name;
                label.Height = 12;

                PictureBox pictureBox = new PictureBox();
                pictureBox.Height = viewHeight;
                pictureBox.Width = (int)((bitmap.Width * viewHeight) / bitmap.Height);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = bitmap;

                label.Width = pictureBox.Width;

                int panelImageAddHorizontalTop = iY * (pictureBox.Height + label.Height * 2);
                int panelImageAddHorizontalLeft = iX * (pictureBox.Width + label.Height);

                label.Left = panelImageAddHorizontalLeft;
                label.Top = panelImageAddHorizontalTop;
                pictureBox.Left = panelImageAddHorizontalLeft;
                pictureBox.Top = panelImageAddHorizontalTop + label.Height;

                if (panel_Images.Width < panelImageAddHorizontalLeft + pictureBox.Width) { panel_Images.Width = panelImageAddHorizontalLeft + pictureBox.Width; };
                if (panel_Images.Height < panelImageAddHorizontalTop + pictureBox.Height + label.Height) { panel_Images.Height = panelImageAddHorizontalTop + pictureBox.Height + label.Height; };

                panel_Images.Controls.Add(label);
                panel_Images.Controls.Add(pictureBox);
            }
        }

        private void button_ClearImageFiles_Click(object sender, EventArgs e)
        {
            textBox_ImageFilesPath.Text = "";
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            panel_ImagesFrame.Height = 160 + (this.Height - 600);
            panel_ImagesFrame.Width = (this.Width - (929-868));

        }

        private void button_Run_Click(object sender, EventArgs e)
        {

            if (button_Run.Text == "Run")
            {
                button_Run.Text = "Stop";
                textBox_Result.Text = "";
                backgroundWorker_Run.RunWorkerAsync();
            }
            else
            {
                backgroundWorker_Run.CancelAsync();
            }
        }

        ConcurrentDictionary<string, string> ResultDictionary;
        private void backgroundWorker_Run_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            string onnxFilePath = textBox_OnnxFilePath.Text;
            string[] imageFilePaths = textBox_ImageFilesPath.Text.Replace("\r\n", "\n").Trim('\n').Split('\n');

            panelImagesResetHorizontal();
            ResultDictionary = new ConcurrentDictionary<string, string>();


            //foreach (var imageFilePath in imageFilePaths)
            Parallel.ForEach(imageFilePaths, (imageFilePath) =>
            {
                string Score = "";
                Bitmap bitmap;

                float alpha = 0;
                if (!float.TryParse(textBox_alpha.Text, out alpha))
                {
                    alpha = 0;
                };

                float beta = 0;
                if (!float.TryParse(textBox_beta.Text, out beta))
                {
                    beta = float.NaN;
                };

                float viewWidth = panel_Images.Width;
                if (!float.TryParse(textBox_viewWidth.Text, out viewWidth))
                {
                    viewWidth = float.NaN;
                }

                (Score, bitmap) = OnnxImageClassification.RunSessionAndDrawMap(onnxFilePath, imageFilePath, alpha, beta, ImShow: false);

                string name = Path.Combine(Path.GetFileName(Path.GetDirectoryName(imageFilePath)), Path.GetFileNameWithoutExtension(imageFilePath));
                ResultText += name + "\t" + Score + "\r\n";
                ResultDictionary.TryAdd(name, name + "\t" + Score);
                //ResultDictionary.AddOrUpdate(name, name + "\t" + Score, null);

                panelImageAddHorizontal(bitmap, name + " : " + Score, viewWidth, imageFilePath, imageFilePaths);

                if (Directory.Exists(textBox_MapSaveDirectory.Text))
                {
                    string mapFilePath = Path.Combine(textBox_MapSaveDirectory.Text, name + "_" + Score.Split('\t')[0] + ".png");
                    if (!Directory.Exists(Path.GetDirectoryName(mapFilePath))) { Directory.CreateDirectory(Path.GetDirectoryName(mapFilePath)); }

                    bitmap.Save(mapFilePath);
                }

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                ProgressText = ResultDictionary.Count.ToString() + " / " + imageFilePaths.Length.ToString();
            });


            List<string> ResultList = new List<string>();

            foreach (string imageFilePath in imageFilePaths)
            {
                string name = Path.Combine(Path.GetFileName(Path.GetDirectoryName(imageFilePath)), Path.GetFileNameWithoutExtension(imageFilePath));

                if (ResultDictionary.ContainsKey(name))
                {
                    ResultList.Add(ResultDictionary[name]);
                }
            }

            ResultText = string.Join("\r\n", ResultList);
        }

        public string ResultText
        {
            get { return textBox_Result.Text; }
            set
            {
                if (this.InvokeRequired) { this.Invoke((Action)(() => ResultText = value)); }
                else
                {
                    textBox_Result.Text = value;
                }
            }
        }
        public string ProgressText
        {
            get { return  label_Progress.Text; }
            set
            {
                if (this.InvokeRequired) { this.Invoke((Action)(() => ProgressText = value)); }
                else
                {
                    label_Progress.Text = value;
                }
            }
        }
        private void backgroundWorker_Run_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void backgroundWorker_Run_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            button_Run.Text = "Run";
        }

        private void button_SavePanel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG|*.png";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            Control c = panel_Images;
            int w = c.Size.Width;
            int h = c.Size.Height;

            using (Bitmap bmp = new Bitmap(w, h))
            {
                c.DrawToBitmap(bmp, new Rectangle(0, 0, w, h));
                bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void button_SendClip_Click(object sender, EventArgs e)
        {
            Control c = panel_Images;
            int w = c.Size.Width;
            int h = c.Size.Height;

            using (Bitmap bmp = new Bitmap(w, h))
            {
                c.DrawToBitmap(bmp, new Rectangle(0, 0, w, h));
                Clipboard.SetImage(bmp);
            }
        }
    }
}
