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
            this.SuspendLayout();
            // 
            // button_Run
            // 
            this.button_Run.Location = new System.Drawing.Point(8, 241);
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
            this.textBox_Result.Location = new System.Drawing.Point(33, 270);
            this.textBox_Result.Multiline = true;
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Result.Size = new System.Drawing.Size(456, 286);
            this.textBox_Result.TabIndex = 6;
            this.textBox_Result.WordWrap = false;
            // 
            // textBox_ImageFilesPath
            // 
            this.textBox_ImageFilesPath.Location = new System.Drawing.Point(33, 94);
            this.textBox_ImageFilesPath.Multiline = true;
            this.textBox_ImageFilesPath.Name = "textBox_ImageFilesPath";
            this.textBox_ImageFilesPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_ImageFilesPath.Size = new System.Drawing.Size(456, 126);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 588);
            this.Controls.Add(this.button_Run);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.textBox_ImageFilesPath);
            this.Controls.Add(this.button_LoadImageFiles);
            this.Controls.Add(this.textBox_OnnxFilePath);
            this.Controls.Add(this.button_LoadOnnxFilePath);
            this.Name = "Form1";
            this.Text = "OnnxRuntime_AnomalibInference";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

