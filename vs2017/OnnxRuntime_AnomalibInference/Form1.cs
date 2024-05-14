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

            textBox_ImageFilesPath.Text += string.Join("\r\n", ofd.FileNames)+"\r\n";
        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            string onnxFilePath = textBox_OnnxFilePath.Text;
            string[] imageFilePaths = textBox_ImageFilesPath.Text.Replace("\r\n", "\n").Trim('\n').Split('\n');

            textBox_Result.Text = "";
            panelImagesResetHorizontal();

            foreach (var imageFilePath in imageFilePaths)
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
                if(!float.TryParse(textBox_viewWidth.Text,out viewWidth))
                {
                    viewWidth = float.NaN;
                }

                (Score, bitmap) = OnnxImageClassification.RunSessionAndDrawMap(onnxFilePath, imageFilePath, alpha, beta, ImShow: false);

                string name = Path.Combine(Path.GetFileName(Path.GetDirectoryName(imageFilePath)), Path.GetFileNameWithoutExtension(imageFilePath));
                textBox_Result.Text += name + "\t" + Score + "\r\n";
                
                panelImageAddHorizontal(bitmap, name + " : " + Score, viewWidth);

                if (Directory.Exists(textBox_MapSaveDirectory.Text))
                {
                    string mapFilePath = Path.Combine(textBox_MapSaveDirectory.Text, name+"_"+ Score.Split('\t')[0] + ".png");
                    if (!Directory.Exists(Path.GetDirectoryName(mapFilePath))) { Directory.CreateDirectory(Path.GetDirectoryName(mapFilePath)); }

                    bitmap.Save(mapFilePath);
                }
            }
        }

        private void panelImagesResetHorizontal()
        {
            panel_Images.Controls.Clear();
            panel_Images.Width = 0;
        }

        private void panelImageAddHorizontal(Bitmap bitmap, string name, float viewHeightFloat)
        {
            int viewHeight = (int)viewHeightFloat;
            if (float.IsNaN(viewHeightFloat))
            {
                viewHeight = panel_Images.Height;
            }

            Label label = new Label();
            label.Left = panel_Images.Width;
            label.Text = name;
            label.Height = 12;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Height = viewHeight;
            pictureBox.Width = (int)((bitmap.Width * viewHeight) / bitmap.Height);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = bitmap;
            pictureBox.Left = panel_Images.Width;
            pictureBox.Top = label.Height;

            panel_Images.Width += pictureBox.Width + label.Height;

            if (panel_Images.Height < pictureBox.Height+ label.Height) { panel_Images.Height = pictureBox.Height+ label.Height; }

            panel_Images.Controls.Add(label);
            panel_Images.Controls.Add(pictureBox);
        }

        private void button_ClearImageFiles_Click(object sender, EventArgs e)
        {
            textBox_ImageFilesPath.Text = "";
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            panel_ImagesFrame.Height = 160 + (this.Height - 600);
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
    }
}
