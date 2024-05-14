namespace OnnxRuntime_AnomalibInference
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Run = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.textBox_ImageFilesPath = new System.Windows.Forms.TextBox();
            this.button_LoadImageFiles = new System.Windows.Forms.Button();
            this.textBox_OnnxFilePath = new System.Windows.Forms.TextBox();
            this.button_LoadOnnxFilePath = new System.Windows.Forms.Button();
            this.panel_Images = new System.Windows.Forms.Panel();
            this.panel_ImagesFrame = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_alpha = new System.Windows.Forms.TextBox();
            this.textBox_beta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_viewWidth = new System.Windows.Forms.TextBox();
            this.textBox_MapSaveDirectory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_ClearImageFiles = new System.Windows.Forms.Button();
            this.button_SavePanel = new System.Windows.Forms.Button();
            this.panel_ImagesFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Run
            // 
            this.button_Run.Location = new System.Drawing.Point(91, 68);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(75, 23);
            this.button_Run.TabIndex = 11;
            this.button_Run.Text = "Run";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "ImageFiles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Onnx File";
            // 
            // textBox_Result
            // 
            this.textBox_Result.Location = new System.Drawing.Point(512, 95);
            this.textBox_Result.Multiline = true;
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Result.Size = new System.Drawing.Size(389, 286);
            this.textBox_Result.TabIndex = 6;
            this.textBox_Result.WordWrap = false;
            // 
            // textBox_ImageFilesPath
            // 
            this.textBox_ImageFilesPath.Location = new System.Drawing.Point(33, 94);
            this.textBox_ImageFilesPath.Multiline = true;
            this.textBox_ImageFilesPath.Name = "textBox_ImageFilesPath";
            this.textBox_ImageFilesPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_ImageFilesPath.Size = new System.Drawing.Size(456, 287);
            this.textBox_ImageFilesPath.TabIndex = 7;
            this.textBox_ImageFilesPath.WordWrap = false;
            // 
            // button_LoadImageFiles
            // 
            this.button_LoadImageFiles.Location = new System.Drawing.Point(8, 94);
            this.button_LoadImageFiles.Name = "button_LoadImageFiles";
            this.button_LoadImageFiles.Size = new System.Drawing.Size(23, 21);
            this.button_LoadImageFiles.TabIndex = 4;
            this.button_LoadImageFiles.Text = "...";
            this.button_LoadImageFiles.UseVisualStyleBackColor = true;
            this.button_LoadImageFiles.Click += new System.EventHandler(this.button_LoadImageFiles_Click);
            // 
            // textBox_OnnxFilePath
            // 
            this.textBox_OnnxFilePath.Location = new System.Drawing.Point(33, 27);
            this.textBox_OnnxFilePath.Name = "textBox_OnnxFilePath";
            this.textBox_OnnxFilePath.Size = new System.Drawing.Size(456, 19);
            this.textBox_OnnxFilePath.TabIndex = 8;
            // 
            // button_LoadOnnxFilePath
            // 
            this.button_LoadOnnxFilePath.Location = new System.Drawing.Point(8, 27);
            this.button_LoadOnnxFilePath.Name = "button_LoadOnnxFilePath";
            this.button_LoadOnnxFilePath.Size = new System.Drawing.Size(23, 21);
            this.button_LoadOnnxFilePath.TabIndex = 5;
            this.button_LoadOnnxFilePath.Text = "...";
            this.button_LoadOnnxFilePath.UseVisualStyleBackColor = true;
            this.button_LoadOnnxFilePath.Click += new System.EventHandler(this.button_LoadOnnxFilePath_Click);
            // 
            // panel_Images
            // 
            this.panel_Images.AutoScroll = true;
            this.panel_Images.Location = new System.Drawing.Point(0, 0);
            this.panel_Images.Name = "panel_Images";
            this.panel_Images.Size = new System.Drawing.Size(364, 108);
            this.panel_Images.TabIndex = 12;
            // 
            // panel_ImagesFrame
            // 
            this.panel_ImagesFrame.AutoScroll = true;
            this.panel_ImagesFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_ImagesFrame.Controls.Add(this.panel_Images);
            this.panel_ImagesFrame.Location = new System.Drawing.Point(33, 387);
            this.panel_ImagesFrame.Name = "panel_ImagesFrame";
            this.panel_ImagesFrame.Size = new System.Drawing.Size(868, 160);
            this.panel_ImagesFrame.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "alpha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(614, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "beta";
            // 
            // textBox_alpha
            // 
            this.textBox_alpha.Location = new System.Drawing.Point(548, 54);
            this.textBox_alpha.Name = "textBox_alpha";
            this.textBox_alpha.Size = new System.Drawing.Size(46, 19);
            this.textBox_alpha.TabIndex = 15;
            this.textBox_alpha.Text = "0";
            // 
            // textBox_beta
            // 
            this.textBox_beta.Location = new System.Drawing.Point(647, 54);
            this.textBox_beta.Name = "textBox_beta";
            this.textBox_beta.Size = new System.Drawing.Size(52, 19);
            this.textBox_beta.TabIndex = 15;
            this.textBox_beta.Text = "Nan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(718, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "view width";
            // 
            // textBox_viewWidth
            // 
            this.textBox_viewWidth.Location = new System.Drawing.Point(783, 55);
            this.textBox_viewWidth.Name = "textBox_viewWidth";
            this.textBox_viewWidth.Size = new System.Drawing.Size(52, 19);
            this.textBox_viewWidth.TabIndex = 15;
            this.textBox_viewWidth.Text = "Nan";
            // 
            // textBox_MapSaveDirectory
            // 
            this.textBox_MapSaveDirectory.Location = new System.Drawing.Point(512, 27);
            this.textBox_MapSaveDirectory.Name = "textBox_MapSaveDirectory";
            this.textBox_MapSaveDirectory.Size = new System.Drawing.Size(389, 19);
            this.textBox_MapSaveDirectory.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "MapSaveDirectory";
            // 
            // button_ClearImageFiles
            // 
            this.button_ClearImageFiles.Location = new System.Drawing.Point(8, 121);
            this.button_ClearImageFiles.Name = "button_ClearImageFiles";
            this.button_ClearImageFiles.Size = new System.Drawing.Size(23, 21);
            this.button_ClearImageFiles.TabIndex = 4;
            this.button_ClearImageFiles.Text = "x";
            this.button_ClearImageFiles.UseVisualStyleBackColor = true;
            this.button_ClearImageFiles.Click += new System.EventHandler(this.button_ClearImageFiles_Click);
            // 
            // button_SavePanel
            // 
            this.button_SavePanel.Location = new System.Drawing.Point(8, 388);
            this.button_SavePanel.Name = "button_SavePanel";
            this.button_SavePanel.Size = new System.Drawing.Size(23, 21);
            this.button_SavePanel.TabIndex = 16;
            this.button_SavePanel.Text = "s";
            this.button_SavePanel.UseVisualStyleBackColor = true;
            this.button_SavePanel.Click += new System.EventHandler(this.button_SavePanel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 561);
            this.Controls.Add(this.button_SavePanel);
            this.Controls.Add(this.textBox_viewWidth);
            this.Controls.Add(this.textBox_beta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_alpha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel_ImagesFrame);
            this.Controls.Add(this.button_Run);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.textBox_ImageFilesPath);
            this.Controls.Add(this.button_ClearImageFiles);
            this.Controls.Add(this.button_LoadImageFiles);
            this.Controls.Add(this.textBox_MapSaveDirectory);
            this.Controls.Add(this.textBox_OnnxFilePath);
            this.Controls.Add(this.button_LoadOnnxFilePath);
            this.Name = "Form1";
            this.Text = "OnnxRuntime_AnomalibPatchCoreInference";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panel_ImagesFrame.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.TextBox textBox_ImageFilesPath;
        private System.Windows.Forms.Button button_LoadImageFiles;
        private System.Windows.Forms.TextBox textBox_OnnxFilePath;
        private System.Windows.Forms.Button button_LoadOnnxFilePath;
        private System.Windows.Forms.Panel panel_Images;
        private System.Windows.Forms.Panel panel_ImagesFrame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_alpha;
        private System.Windows.Forms.TextBox textBox_beta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_viewWidth;
        private System.Windows.Forms.TextBox textBox_MapSaveDirectory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_ClearImageFiles;
        private System.Windows.Forms.Button button_SavePanel;
    }
}

