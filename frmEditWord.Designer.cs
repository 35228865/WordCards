namespace WordCards
{
    partial class frmEditWord
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
            this.grpWord = new System.Windows.Forms.GroupBox();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.grpPhonogram = new System.Windows.Forms.GroupBox();
            this.txtPhonogram = new System.Windows.Forms.TextBox();
            this.grpSoundPath = new System.Windows.Forms.GroupBox();
            this.txtSoundPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtExplain = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpWord.SuspendLayout();
            this.grpPhonogram.SuspendLayout();
            this.grpSoundPath.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpWord
            // 
            this.grpWord.Controls.Add(this.txtWord);
            this.grpWord.Location = new System.Drawing.Point(31, 24);
            this.grpWord.Name = "grpWord";
            this.grpWord.Size = new System.Drawing.Size(335, 57);
            this.grpWord.TabIndex = 0;
            this.grpWord.TabStop = false;
            this.grpWord.Text = "單字";
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(6, 21);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(323, 25);
            this.txtWord.TabIndex = 0;
            // 
            // grpPhonogram
            // 
            this.grpPhonogram.Controls.Add(this.txtPhonogram);
            this.grpPhonogram.Location = new System.Drawing.Point(31, 87);
            this.grpPhonogram.Name = "grpPhonogram";
            this.grpPhonogram.Size = new System.Drawing.Size(335, 57);
            this.grpPhonogram.TabIndex = 1;
            this.grpPhonogram.TabStop = false;
            this.grpPhonogram.Text = "音標";
            // 
            // txtPhonogram
            // 
            this.txtPhonogram.Location = new System.Drawing.Point(6, 21);
            this.txtPhonogram.Name = "txtPhonogram";
            this.txtPhonogram.Size = new System.Drawing.Size(323, 25);
            this.txtPhonogram.TabIndex = 0;
            // 
            // grpSoundPath
            // 
            this.grpSoundPath.Controls.Add(this.txtSoundPath);
            this.grpSoundPath.Location = new System.Drawing.Point(31, 150);
            this.grpSoundPath.Name = "grpSoundPath";
            this.grpSoundPath.Size = new System.Drawing.Size(335, 57);
            this.grpSoundPath.TabIndex = 2;
            this.grpSoundPath.TabStop = false;
            this.grpSoundPath.Text = "音檔路徑";
            // 
            // txtSoundPath
            // 
            this.txtSoundPath.Location = new System.Drawing.Point(6, 21);
            this.txtSoundPath.Name = "txtSoundPath";
            this.txtSoundPath.Size = new System.Drawing.Size(323, 25);
            this.txtSoundPath.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtExplain);
            this.groupBox1.Location = new System.Drawing.Point(31, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 218);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "音檔路徑";
            // 
            // txtExplain
            // 
            this.txtExplain.Location = new System.Drawing.Point(6, 21);
            this.txtExplain.Multiline = true;
            this.txtExplain.Name = "txtExplain";
            this.txtExplain.Size = new System.Drawing.Size(323, 191);
            this.txtExplain.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(291, 442);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmEditWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 477);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSoundPath);
            this.Controls.Add(this.grpPhonogram);
            this.Controls.Add(this.grpWord);
            this.Name = "frmEditWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEditWord";
            this.grpWord.ResumeLayout(false);
            this.grpWord.PerformLayout();
            this.grpPhonogram.ResumeLayout(false);
            this.grpPhonogram.PerformLayout();
            this.grpSoundPath.ResumeLayout(false);
            this.grpSoundPath.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpWord;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.GroupBox grpPhonogram;
        private System.Windows.Forms.TextBox txtPhonogram;
        private System.Windows.Forms.GroupBox grpSoundPath;
        private System.Windows.Forms.TextBox txtSoundPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtExplain;
        private System.Windows.Forms.Button btnSave;
    }
}