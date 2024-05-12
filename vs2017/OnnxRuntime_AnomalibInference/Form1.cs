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

            textBox_ImageFilesPath.Text = string.Join("\r\n", ofd.FileNames);
        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            string onnxFilePath = textBox_OnnxFilePath.Text;
            string[] imageFilePaths = textBox_ImageFilesPath.Text.Replace("\r\n", "\n").Trim('\n').Split('\n');

            textBox_Result.Text = "";
            panelImagesReset();
            foreach (var imageFilePath in imageFilePaths)
            {
                string Score = "";
                Bitmap bitmap;

                (Score, bitmap) = OnnxImageClassification.RunSessionAndDrawMap(onnxFilePath, imageFilePath, ImShow: false);
                string name = Path.Combine(Path.GetFileName(Path.GetDirectoryName(imageFilePath)), Path.GetFileNameWithoutExtension(imageFilePath));

                textBox_Result.Text += name
                    + "\t" + Score + "\r\n";
                panelImageAdd(bitmap,name + " : " + Score);
            }
        }
        private void panelImagesReset()
        {

            foreach (var control in panel_Images.Controls)
            {
                if (control is PictureBox)
                {
                    ((PictureBox)control).Image.Dispose();
                }
                
            }
            panel_Images.Controls.Clear();
            panel_Images.Height = 0;

        }
        private void panelImageAdd(Bitmap bitmap,string name)
        {
            Label label = new Label();
            label.Top = panel_Images.Height;
            label.Text = name;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Width = panel_Images.Width;
            pictureBox.Height = (int)((bitmap.Height * panel_Images.Width) / bitmap.Width );
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = bitmap;
            pictureBox.Top = panel_Images.Height+10;
            
            panel_Images.Height += pictureBox.Height+10;

            panel_Images.Controls.Add(pictureBox);
            panel_Images.Controls.Add(label);

        }

    }
}
