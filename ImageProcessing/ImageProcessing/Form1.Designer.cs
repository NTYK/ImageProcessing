namespace ImageProcessing {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GBt = new System.Windows.Forms.Button();
            this.HPBt = new System.Windows.Forms.Button();
            this.BIPBt = new System.Windows.Forms.Button();
            this.FBt = new System.Windows.Forms.Button();
            this.CCBt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openBt = new System.Windows.Forms.Button();
            this.SaveBt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ExeBt = new System.Windows.Forms.Button();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GBt);
            this.groupBox1.Controls.Add(this.HPBt);
            this.groupBox1.Controls.Add(this.BIPBt);
            this.groupBox1.Controls.Add(this.FBt);
            this.groupBox1.Controls.Add(this.CCBt);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Command";
            // 
            // GBt
            // 
            this.GBt.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GBt.Location = new System.Drawing.Point(19, 134);
            this.GBt.Name = "GBt";
            this.GBt.Size = new System.Drawing.Size(166, 23);
            this.GBt.TabIndex = 5;
            this.GBt.Text = "Geometric Transformation";
            this.GBt.UseVisualStyleBackColor = true;
            this.GBt.Click += new System.EventHandler(this.GBt_Click);
            // 
            // HPBt
            // 
            this.HPBt.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HPBt.Location = new System.Drawing.Point(19, 105);
            this.HPBt.Name = "HPBt";
            this.HPBt.Size = new System.Drawing.Size(166, 23);
            this.HPBt.TabIndex = 4;
            this.HPBt.Text = "Histogram Processing";
            this.HPBt.UseVisualStyleBackColor = true;
            this.HPBt.Click += new System.EventHandler(this.HPBt_Click);
            // 
            // BIPBt
            // 
            this.BIPBt.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BIPBt.Location = new System.Drawing.Point(19, 76);
            this.BIPBt.Name = "BIPBt";
            this.BIPBt.Size = new System.Drawing.Size(166, 23);
            this.BIPBt.TabIndex = 3;
            this.BIPBt.Text = "Binary Image Processing";
            this.BIPBt.UseVisualStyleBackColor = true;
            this.BIPBt.Click += new System.EventHandler(this.BIPBt_Click);
            // 
            // FBt
            // 
            this.FBt.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FBt.Location = new System.Drawing.Point(19, 47);
            this.FBt.Name = "FBt";
            this.FBt.Size = new System.Drawing.Size(166, 23);
            this.FBt.TabIndex = 2;
            this.FBt.Text = "Filtering";
            this.FBt.UseVisualStyleBackColor = true;
            this.FBt.Click += new System.EventHandler(this.FBt_Click);
            // 
            // CCBt
            // 
            this.CCBt.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CCBt.Location = new System.Drawing.Point(19, 18);
            this.CCBt.Name = "CCBt";
            this.CCBt.Size = new System.Drawing.Size(166, 23);
            this.CCBt.TabIndex = 0;
            this.CCBt.Text = "Color Conversion";
            this.CCBt.UseVisualStyleBackColor = true;
            this.CCBt.Click += new System.EventHandler(this.CCBt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(12, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 267);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Setting";
            // 
            // openBt
            // 
            this.openBt.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.openBt.Location = new System.Drawing.Point(31, 12);
            this.openBt.Name = "openBt";
            this.openBt.Size = new System.Drawing.Size(75, 23);
            this.openBt.TabIndex = 2;
            this.openBt.Text = "Open";
            this.openBt.UseVisualStyleBackColor = true;
            this.openBt.Click += new System.EventHandler(this.OpenBt_Click);
            // 
            // SaveBt
            // 
            this.SaveBt.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SaveBt.Location = new System.Drawing.Point(122, 12);
            this.SaveBt.Name = "SaveBt";
            this.SaveBt.Size = new System.Drawing.Size(75, 23);
            this.SaveBt.TabIndex = 3;
            this.SaveBt.Text = "Save";
            this.SaveBt.UseVisualStyleBackColor = true;
            this.SaveBt.Click += new System.EventHandler(this.SaveBt_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.picBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel1.Location = new System.Drawing.Point(218, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 408);
            this.panel1.TabIndex = 4;
            // 
            // picBox1
            // 
            this.picBox1.Location = new System.Drawing.Point(0, 0);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(614, 408);
            this.picBox1.TabIndex = 1;
            this.picBox1.TabStop = false;
            this.picBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(180, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 70);
            this.label2.TabIndex = 0;
            this.label2.Text = "Image Draw Area\n        (Before)";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.picBox2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel2.Location = new System.Drawing.Point(838, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 408);
            this.panel2.TabIndex = 5;
            // 
            // picBox2
            // 
            this.picBox2.Location = new System.Drawing.Point(0, 0);
            this.picBox2.Name = "picBox2";
            this.picBox2.Size = new System.Drawing.Size(614, 408);
            this.picBox2.TabIndex = 1;
            this.picBox2.TabStop = false;
            this.picBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(180, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 70);
            this.label3.TabIndex = 0;
            this.label3.Text = "Image Draw Area\n        (After)";
            // 
            // openFD
            // 
            this.openFD.Filter = "Image File(*.bmp,*.jpg,*.png,*.tif)|*.bmp;*.jpg;*.png;*.tif|Bitmap(*.bmp)|*.bmp|J" +
    "peg(*.jpg)|*.jpg|PNG(*.png)|*.png";
            this.openFD.ShowReadOnly = true;
            this.openFD.Title = "イメージファイルを開く";
            this.openFD.FileOk += new System.ComponentModel.CancelEventHandler(this.openFD_FileOk);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(782, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Before";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(1413, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "After";
            // 
            // ExeBt
            // 
            this.ExeBt.Cursor = System.Windows.Forms.Cursors.Default;
            this.ExeBt.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExeBt.Location = new System.Drawing.Point(1374, 457);
            this.ExeBt.Name = "ExeBt";
            this.ExeBt.Size = new System.Drawing.Size(75, 23);
            this.ExeBt.TabIndex = 7;
            this.ExeBt.Text = "Execute";
            this.ExeBt.UseVisualStyleBackColor = true;
            this.ExeBt.Click += new System.EventHandler(this.ExeBt_Click);
            // 
            // saveFD
            // 
            this.saveFD.Filter = "Bitmap(*.bmp)|*.bmp|Jpeg(*.jpg)|*.jpg|PNG(*.png)|*.png";
            this.saveFD.Title = "名前を付けて保存";
            this.saveFD.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFD_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 489);
            this.Controls.Add(this.ExeBt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SaveBt);
            this.Controls.Add(this.openBt);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Image Processing";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GBt;
        private System.Windows.Forms.Button HPBt;
        private System.Windows.Forms.Button BIPBt;
        private System.Windows.Forms.Button FBt;
        private System.Windows.Forms.Button CCBt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button openBt;
        private System.Windows.Forms.Button SaveBt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFD;
        private System.Windows.Forms.PictureBox picBox1;
        private System.Windows.Forms.PictureBox picBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ExeBt;
        private System.Windows.Forms.SaveFileDialog saveFD;
    }
}

