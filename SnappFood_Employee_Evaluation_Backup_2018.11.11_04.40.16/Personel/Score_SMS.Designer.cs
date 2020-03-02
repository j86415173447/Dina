namespace SnappFood_Employee_Evaluation.Personel
{
    partial class Score_SMS
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.Updation_Prog = new Telerik.WinControls.UI.RadProgressBar();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.Updation_Prog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // Updation_Prog
            // 
            this.Updation_Prog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Updation_Prog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Updation_Prog.Location = new System.Drawing.Point(0, 165);
            this.Updation_Prog.Name = "Updation_Prog";
            this.Updation_Prog.Size = new System.Drawing.Size(473, 43);
            this.Updation_Prog.TabIndex = 104;
            this.Updation_Prog.Text = "ارسال پیامک";
            this.Updation_Prog.ThemeName = "Office2010Silver";
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel1.ForeColor = System.Drawing.Color.Green;
            this.radLabel1.Location = new System.Drawing.Point(12, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(449, 59);
            this.radLabel1.TabIndex = 105;
            this.radLabel1.Text = "radLabel1";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radButton1.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.email_send_icon;
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(188, 77);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 82);
            this.radButton1.TabIndex = 106;
            this.radButton1.Text = "ارسال پیامک";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radButton1.ThemeName = "Office2010Silver";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // Score_SMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 208);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.Updation_Prog);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "Score_SMS";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ارسال پیامک اعلامیه امتیاز شغلی";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.Score_SMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Updation_Prog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadProgressBar Updation_Prog;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}
