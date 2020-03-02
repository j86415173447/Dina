namespace SnappFood_Employee_Evaluation.Personel
{
    partial class PER_SCORE_DTL_MAIL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PER_SCORE_DTL_MAIL));
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.Updation_Prog = new Telerik.WinControls.UI.RadProgressBar();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Updation_Prog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel1.ForeColor = System.Drawing.Color.Green;
            this.radLabel1.Location = new System.Drawing.Point(12, 6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(449, 59);
            this.radLabel1.TabIndex = 108;
            this.radLabel1.Text = "radLabel1";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // Updation_Prog
            // 
            this.Updation_Prog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Updation_Prog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Updation_Prog.Location = new System.Drawing.Point(0, 165);
            this.Updation_Prog.Name = "Updation_Prog";
            this.Updation_Prog.Size = new System.Drawing.Size(473, 43);
            this.Updation_Prog.TabIndex = 107;
            this.Updation_Prog.ThemeName = "Office2010Silver";
            // 
            // radButton2
            // 
            this.radButton2.Enabled = false;
            this.radButton2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radButton2.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.email_send_icon;
            this.radButton2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton2.Location = new System.Drawing.Point(235, 77);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 82);
            this.radButton2.TabIndex = 110;
            this.radButton2.Text = "پیامک اطلاع رسانی";
            this.radButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radButton2.ThemeName = "Office2010Silver";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 110;
            this.pictureBox1.TabStop = false;
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radButton1.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.Gmail_icon1;
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(351, 77);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 82);
            this.radButton1.TabIndex = 109;
            this.radButton1.Text = "ایمیل اطلاع رسانی";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radButton1.ThemeName = "Office2010Silver";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // PER_SCORE_DTL_MAIL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 208);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.Updation_Prog);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "PER_SCORE_DTL_MAIL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ایمیل اطلاع رسانی جزئیات امتیازات شغلی همکاران";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.TRN_CLS_ANNOUNCEMENT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Updation_Prog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadProgressBar Updation_Prog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
