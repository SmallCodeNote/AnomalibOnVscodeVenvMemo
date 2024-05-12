namespace subtool
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
            this.panel_Frame = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_CreateE = new System.Windows.Forms.Button();
            this.textBox_CreateDirPath = new System.Windows.Forms.TextBox();
            this.button_CreateD = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_CreateC = new System.Windows.Forms.Button();
            this.textBox_Width = new System.Windows.Forms.TextBox();
            this.button_CreateB = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_Height = new System.Windows.Forms.TextBox();
            this.button_CreateA = new System.Windows.Forms.Button();
            this.textBox_ImageCount = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_LoadMaskTarget = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_MaskFromDiffTh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_MaskFromDiff_BaseDataDirPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_MaskFromDiff_EditDataDirPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_MaskFromDiff_MaskDataDirPath = new System.Windows.Forms.TextBox();
            this.button_MaskFromDiff_CreateMask = new System.Windows.Forms.Button();
            this.panel_Frame.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Frame
            // 
            this.panel_Frame.AutoScroll = true;
            this.panel_Frame.Controls.Add(this.tabControl1);
            this.panel_Frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Frame.Location = new System.Drawing.Point(0, 0);
            this.panel_Frame.Name = "panel_Frame";
            this.panel_Frame.Size = new System.Drawing.Size(591, 484);
            this.panel_Frame.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 451);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.button_CreateE);
            this.tabPage1.Controls.Add(this.textBox_CreateDirPath);
            this.tabPage1.Controls.Add(this.button_CreateD);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button_CreateC);
            this.tabPage1.Controls.Add(this.textBox_Width);
            this.tabPage1.Controls.Add(this.button_CreateB);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.textBox_Height);
            this.tabPage1.Controls.Add(this.button_CreateA);
            this.tabPage1.Controls.Add(this.textBox_ImageCount);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(559, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CreateImage";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "CreateDirPath";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 21);
            this.button1.TabIndex = 5;
            this.button1.Text = "CreateE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_CreateE_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Width";
            // 
            // button_CreateE
            // 
            this.button_CreateE.Location = new System.Drawing.Point(300, 169);
            this.button_CreateE.Name = "button_CreateE";
            this.button_CreateE.Size = new System.Drawing.Size(77, 21);
            this.button_CreateE.TabIndex = 5;
            this.button_CreateE.Text = "CreateE";
            this.button_CreateE.UseVisualStyleBackColor = true;
            this.button_CreateE.Click += new System.EventHandler(this.button_CreateE_Click);
            // 
            // textBox_CreateDirPath
            // 
            this.textBox_CreateDirPath.Location = new System.Drawing.Point(22, 41);
            this.textBox_CreateDirPath.Name = "textBox_CreateDirPath";
            this.textBox_CreateDirPath.Size = new System.Drawing.Size(456, 19);
            this.textBox_CreateDirPath.TabIndex = 2;
            // 
            // button_CreateD
            // 
            this.button_CreateD.Location = new System.Drawing.Point(300, 140);
            this.button_CreateD.Name = "button_CreateD";
            this.button_CreateD.Size = new System.Drawing.Size(77, 21);
            this.button_CreateD.TabIndex = 5;
            this.button_CreateD.Text = "CreateD";
            this.button_CreateD.UseVisualStyleBackColor = true;
            this.button_CreateD.Click += new System.EventHandler(this.button_CreateD_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Height";
            // 
            // button_CreateC
            // 
            this.button_CreateC.Location = new System.Drawing.Point(204, 140);
            this.button_CreateC.Name = "button_CreateC";
            this.button_CreateC.Size = new System.Drawing.Size(77, 21);
            this.button_CreateC.TabIndex = 5;
            this.button_CreateC.Text = "CreateC";
            this.button_CreateC.UseVisualStyleBackColor = true;
            this.button_CreateC.Click += new System.EventHandler(this.button_CreateC_Click);
            // 
            // textBox_Width
            // 
            this.textBox_Width.Location = new System.Drawing.Point(22, 84);
            this.textBox_Width.Name = "textBox_Width";
            this.textBox_Width.Size = new System.Drawing.Size(76, 19);
            this.textBox_Width.TabIndex = 2;
            this.textBox_Width.Text = "224";
            // 
            // button_CreateB
            // 
            this.button_CreateB.Location = new System.Drawing.Point(117, 140);
            this.button_CreateB.Name = "button_CreateB";
            this.button_CreateB.Size = new System.Drawing.Size(71, 22);
            this.button_CreateB.TabIndex = 4;
            this.button_CreateB.Text = "CreateB";
            this.button_CreateB.UseVisualStyleBackColor = true;
            this.button_CreateB.Click += new System.EventHandler(this.button_CreateB_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "ImageCount";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 169);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 224);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(104, 84);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.Size = new System.Drawing.Size(76, 19);
            this.textBox_Height.TabIndex = 2;
            this.textBox_Height.Text = "224";
            // 
            // button_CreateA
            // 
            this.button_CreateA.Location = new System.Drawing.Point(22, 140);
            this.button_CreateA.Name = "button_CreateA";
            this.button_CreateA.Size = new System.Drawing.Size(75, 23);
            this.button_CreateA.TabIndex = 0;
            this.button_CreateA.Text = "CreateA";
            this.button_CreateA.UseVisualStyleBackColor = true;
            this.button_CreateA.Click += new System.EventHandler(this.button_CreateA_Click);
            // 
            // textBox_ImageCount
            // 
            this.textBox_ImageCount.Location = new System.Drawing.Point(206, 84);
            this.textBox_ImageCount.Name = "textBox_ImageCount";
            this.textBox_ImageCount.Size = new System.Drawing.Size(76, 19);
            this.textBox_ImageCount.TabIndex = 2;
            this.textBox_ImageCount.Text = "100";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.button_LoadMaskTarget);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(559, 425);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CreateMask";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_LoadMaskTarget
            // 
            this.button_LoadMaskTarget.Location = new System.Drawing.Point(24, 47);
            this.button_LoadMaskTarget.Name = "button_LoadMaskTarget";
            this.button_LoadMaskTarget.Size = new System.Drawing.Size(130, 23);
            this.button_LoadMaskTarget.TabIndex = 0;
            this.button_LoadMaskTarget.Text = "LoadMaskTarget";
            this.button_LoadMaskTarget.UseVisualStyleBackColor = true;
            this.button_LoadMaskTarget.Click += new System.EventHandler(this.button_LoadMaskTarget_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "TargetColor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(365, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Threshold";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_MaskFromDiff_CreateMask);
            this.groupBox1.Controls.Add(this.textBox_MaskFromDiff_MaskDataDirPath);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox_MaskFromDiff_EditDataDirPath);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_MaskFromDiff_BaseDataDirPath);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_MaskFromDiffTh);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(16, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 184);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mask from image diff.";
            // 
            // textBox_MaskFromDiffTh
            // 
            this.textBox_MaskFromDiffTh.Location = new System.Drawing.Point(426, 34);
            this.textBox_MaskFromDiffTh.Name = "textBox_MaskFromDiffTh";
            this.textBox_MaskFromDiffTh.Size = new System.Drawing.Size(100, 19);
            this.textBox_MaskFromDiffTh.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "BaseDataDirPath";
            // 
            // textBox_MaskFromDiff_BaseDataDirPath
            // 
            this.textBox_MaskFromDiff_BaseDataDirPath.Location = new System.Drawing.Point(8, 74);
            this.textBox_MaskFromDiff_BaseDataDirPath.Name = "textBox_MaskFromDiff_BaseDataDirPath";
            this.textBox_MaskFromDiff_BaseDataDirPath.Size = new System.Drawing.Size(518, 19);
            this.textBox_MaskFromDiff_BaseDataDirPath.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "EditDataDirPath";
            // 
            // textBox_MaskFromDiff_EditDataDirPath
            // 
            this.textBox_MaskFromDiff_EditDataDirPath.Location = new System.Drawing.Point(8, 111);
            this.textBox_MaskFromDiff_EditDataDirPath.Name = "textBox_MaskFromDiff_EditDataDirPath";
            this.textBox_MaskFromDiff_EditDataDirPath.Size = new System.Drawing.Size(518, 19);
            this.textBox_MaskFromDiff_EditDataDirPath.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "MaskDataDirPath";
            // 
            // textBox_MaskFromDiff_MaskDataDirPath
            // 
            this.textBox_MaskFromDiff_MaskDataDirPath.Location = new System.Drawing.Point(8, 159);
            this.textBox_MaskFromDiff_MaskDataDirPath.Name = "textBox_MaskFromDiff_MaskDataDirPath";
            this.textBox_MaskFromDiff_MaskDataDirPath.Size = new System.Drawing.Size(518, 19);
            this.textBox_MaskFromDiff_MaskDataDirPath.TabIndex = 2;
            // 
            // button_MaskFromDiff_CreateMask
            // 
            this.button_MaskFromDiff_CreateMask.Location = new System.Drawing.Point(8, 18);
            this.button_MaskFromDiff_CreateMask.Name = "button_MaskFromDiff_CreateMask";
            this.button_MaskFromDiff_CreateMask.Size = new System.Drawing.Size(75, 23);
            this.button_MaskFromDiff_CreateMask.TabIndex = 3;
            this.button_MaskFromDiff_CreateMask.Text = "CreateMask";
            this.button_MaskFromDiff_CreateMask.UseVisualStyleBackColor = true;
            this.button_MaskFromDiff_CreateMask.Click += new System.EventHandler(this.button_MaskFromDiff_CreateMask_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 484);
            this.Controls.Add(this.panel_Frame);
            this.Name = "Form1";
            this.Text = "subTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_Frame.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Frame;
        private System.Windows.Forms.TextBox textBox_CreateDirPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_CreateA;
        private System.Windows.Forms.TextBox textBox_Height;
        private System.Windows.Forms.TextBox textBox_Width;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_ImageCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_CreateB;
        private System.Windows.Forms.Button button_CreateC;
        private System.Windows.Forms.Button button_CreateD;
        private System.Windows.Forms.Button button_CreateE;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_LoadMaskTarget;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_MaskFromDiffTh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_MaskFromDiff_CreateMask;
        private System.Windows.Forms.TextBox textBox_MaskFromDiff_MaskDataDirPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_MaskFromDiff_EditDataDirPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_MaskFromDiff_BaseDataDirPath;
        private System.Windows.Forms.Label label7;
    }
}

