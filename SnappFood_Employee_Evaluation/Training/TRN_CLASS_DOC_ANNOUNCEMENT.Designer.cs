﻿namespace SnappFood_Employee_Evaluation.Training
{
    partial class TRN_CLASS_DOC_ANNOUNCEMENT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN_CLASS_DOC_ANNOUNCEMENT));
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.Updation_Prog = new Telerik.WinControls.UI.RadProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.Trainer = new System.Windows.Forms.ComboBox();
            this.File_Name = new Telerik.WinControls.UI.RadTextBox();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Updation_Prog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.File_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
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
            this.radLabel1.Location = new System.Drawing.Point(12, 80);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(449, 59);
            this.radLabel1.TabIndex = 108;
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // Updation_Prog
            // 
            this.Updation_Prog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Updation_Prog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Updation_Prog.Location = new System.Drawing.Point(0, 239);
            this.Updation_Prog.Name = "Updation_Prog";
            this.Updation_Prog.Size = new System.Drawing.Size(473, 43);
            this.Updation_Prog.TabIndex = 107;
            this.Updation_Prog.ThemeName = "Office2010Silver";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(392, 12);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(69, 18);
            this.radLabel8.TabIndex = 111;
            this.radLabel8.Text = "انتخاب دوره:";
            this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel8.ThemeName = "Office2010Silver";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(392, 45);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(69, 18);
            this.radLabel2.TabIndex = 112;
            this.radLabel2.Text = "انتخاب فایل:";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel2.ThemeName = "Office2010Silver";
            // 
            // Trainer
            // 
            this.Trainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Trainer.BackColor = System.Drawing.Color.LavenderBlush;
            this.Trainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Trainer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Trainer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Trainer.FormattingEnabled = true;
            this.Trainer.Location = new System.Drawing.Point(12, 9);
            this.Trainer.Name = "Trainer";
            this.Trainer.Size = new System.Drawing.Size(374, 22);
            this.Trainer.TabIndex = 113;
            this.Trainer.SelectedIndexChanged += new System.EventHandler(this.Trainer_SelectedIndexChanged);
            // 
            // File_Name
            // 
            this.File_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.File_Name.Location = new System.Drawing.Point(12, 43);
            this.File_Name.Name = "File_Name";
            this.File_Name.Size = new System.Drawing.Size(342, 20);
            this.File_Name.TabIndex = 114;
            this.File_Name.ThemeName = "Office2010Silver";
            // 
            // radButton3
            // 
            this.radButton3.AutoSize = true;
            this.radButton3.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.radButton3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radButton3.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.Folder_Open_icon1;
            this.radButton3.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton3.Location = new System.Drawing.Point(360, 41);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(26, 26);
            this.radButton3.TabIndex = 111;
            this.radButton3.Text = "پیامک اطلاع رسانی";
            this.radButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radButton3.ThemeName = "Office2010Silver";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // radButton2
            // 
            this.radButton2.Enabled = false;
            this.radButton2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radButton2.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.email_send_icon;
            this.radButton2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton2.Location = new System.Drawing.Point(235, 151);
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
            this.pictureBox1.Location = new System.Drawing.Point(12, 151);
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
            this.radButton1.Location = new System.Drawing.Point(351, 151);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 82);
            this.radButton1.TabIndex = 109;
            this.radButton1.Text = "ایمیل اطلاع رسانی";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radButton1.ThemeName = "Office2010Silver";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // TRN_CLASS_DOC_ANNOUNCEMENT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 282);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.File_Name);
            this.Controls.Add(this.Trainer);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.Updation_Prog);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "TRN_CLASS_DOC_ANNOUNCEMENT";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اطلاع رسانی کلاس";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.TRN_CLS_ANNOUNCEMENT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Updation_Prog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.File_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.ComboBox Trainer;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadTextBox File_Name;
    }
}
