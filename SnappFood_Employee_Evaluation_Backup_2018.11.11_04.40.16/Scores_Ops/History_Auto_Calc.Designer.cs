namespace SnappFood_Employee_Evaluation.Scores_Ops
{
    partial class History_Auto_Calc
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
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.Exit = new Telerik.WinControls.UI.RadMenuItem();
            this.Today_Btn = new Telerik.WinControls.UI.RadButton();
            this.radLabel18 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel17 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel16 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel15 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.DT_Day = new Telerik.WinControls.UI.RadTextBox();
            this.DT_Mth = new Telerik.WinControls.UI.RadTextBox();
            this.DT_Yr = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.Calculation_Prog = new Telerik.WinControls.UI.RadProgressBar();
            this.Updation_Prog = new Telerik.WinControls.UI.RadProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Today_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DT_Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DT_Mth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DT_Yr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Calculation_Prog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Updation_Prog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // radMenu1
            // 
            this.radMenu1.BackColor = System.Drawing.Color.Pink;
            this.radMenu1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.Save,
            this.Exit});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(366, 53);
            this.radMenu1.TabIndex = 1;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "Office2010Silver";
            // 
            // Save
            // 
            this.Save.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.Refresh_icon;
            this.Save.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Save.Name = "Save";
            this.Save.Text = "بروزرسانی";
            this.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Save.UseCompatibleTextRendering = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Exit
            // 
            this.Exit.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.power;
            this.Exit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Exit.Name = "Exit";
            this.Exit.Text = "   خروج   ";
            this.Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Exit.UseCompatibleTextRendering = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Today_Btn
            // 
            this.Today_Btn.BackColor = System.Drawing.Color.LavenderBlush;
            this.Today_Btn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Today_Btn.Location = new System.Drawing.Point(23, 89);
            this.Today_Btn.Name = "Today_Btn";
            this.Today_Btn.Size = new System.Drawing.Size(57, 21);
            this.Today_Btn.TabIndex = 100;
            this.Today_Btn.Text = "امروز";
            this.Today_Btn.ThemeName = "Office2010Silver";
            this.Today_Btn.Click += new System.EventHandler(this.Today_Btn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.Today_Btn.GetChildAt(0))).Text = "امروز";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.Today_Btn.GetChildAt(0).GetChildAt(2))).BorderDrawMode = Telerik.WinControls.BorderDrawModes.BottomOver;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.Today_Btn.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.Today_Btn.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.Today_Btn.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.Today_Btn.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.Pink;
            // 
            // radLabel18
            // 
            this.radLabel18.AutoSize = false;
            this.radLabel18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel18.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.radLabel18.Location = new System.Drawing.Point(86, 70);
            this.radLabel18.Name = "radLabel18";
            this.radLabel18.Size = new System.Drawing.Size(35, 18);
            this.radLabel18.TabIndex = 99;
            this.radLabel18.Text = "سال";
            this.radLabel18.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel18.ThemeName = "Office2010Silver";
            // 
            // radLabel17
            // 
            this.radLabel17.AutoSize = false;
            this.radLabel17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel17.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.radLabel17.Location = new System.Drawing.Point(138, 70);
            this.radLabel17.Name = "radLabel17";
            this.radLabel17.Size = new System.Drawing.Size(35, 18);
            this.radLabel17.TabIndex = 98;
            this.radLabel17.Text = "ماه";
            this.radLabel17.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel17.ThemeName = "Office2010Silver";
            // 
            // radLabel16
            // 
            this.radLabel16.AutoSize = false;
            this.radLabel16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel16.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.radLabel16.Location = new System.Drawing.Point(190, 70);
            this.radLabel16.Name = "radLabel16";
            this.radLabel16.Size = new System.Drawing.Size(35, 18);
            this.radLabel16.TabIndex = 97;
            this.radLabel16.Text = "روز";
            this.radLabel16.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel16.ThemeName = "Office2010Silver";
            // 
            // radLabel15
            // 
            this.radLabel15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel15.Location = new System.Drawing.Point(124, 91);
            this.radLabel15.Name = "radLabel15";
            this.radLabel15.Size = new System.Drawing.Size(11, 18);
            this.radLabel15.TabIndex = 96;
            this.radLabel15.Text = "/";
            this.radLabel15.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel14
            // 
            this.radLabel14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel14.Location = new System.Drawing.Point(176, 91);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(11, 18);
            this.radLabel14.TabIndex = 95;
            this.radLabel14.Text = "/";
            this.radLabel14.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // DT_Day
            // 
            this.DT_Day.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_Day.Location = new System.Drawing.Point(190, 90);
            this.DT_Day.Name = "DT_Day";
            this.DT_Day.Size = new System.Drawing.Size(35, 20);
            this.DT_Day.TabIndex = 91;
            this.DT_Day.ThemeName = "Office2010Silver";
            this.DT_Day.TextChanged += new System.EventHandler(this.DT_Day_TextChanged);
            this.DT_Day.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DT_Day_KeyPress);
            // 
            // DT_Mth
            // 
            this.DT_Mth.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_Mth.Location = new System.Drawing.Point(138, 90);
            this.DT_Mth.Name = "DT_Mth";
            this.DT_Mth.Size = new System.Drawing.Size(35, 20);
            this.DT_Mth.TabIndex = 92;
            this.DT_Mth.ThemeName = "Office2010Silver";
            this.DT_Mth.TextChanged += new System.EventHandler(this.DT_Day_TextChanged);
            // 
            // DT_Yr
            // 
            this.DT_Yr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_Yr.Location = new System.Drawing.Point(86, 90);
            this.DT_Yr.Name = "DT_Yr";
            this.DT_Yr.Size = new System.Drawing.Size(35, 20);
            this.DT_Yr.TabIndex = 93;
            this.DT_Yr.ThemeName = "Office2010Silver";
            this.DT_Yr.TextChanged += new System.EventHandler(this.Br_Yr_TextChanged);
            // 
            // radLabel11
            // 
            this.radLabel11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel11.Location = new System.Drawing.Point(234, 90);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(104, 18);
            this.radLabel11.TabIndex = 94;
            this.radLabel11.Text = "بروزرسانی تا تاریخ:";
            this.radLabel11.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel11.ThemeName = "Office2010Silver";
            // 
            // Calculation_Prog
            // 
            this.Calculation_Prog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Calculation_Prog.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Calculation_Prog.Location = new System.Drawing.Point(0, 172);
            this.Calculation_Prog.Name = "Calculation_Prog";
            this.Calculation_Prog.Size = new System.Drawing.Size(366, 31);
            this.Calculation_Prog.Step = 1;
            this.Calculation_Prog.TabIndex = 102;
            this.Calculation_Prog.Text = "محاسبه امتیازات";
            this.Calculation_Prog.ThemeName = "Office2010Silver";
            // 
            // Updation_Prog
            // 
            this.Updation_Prog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Updation_Prog.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Updation_Prog.Location = new System.Drawing.Point(0, 141);
            this.Updation_Prog.Name = "Updation_Prog";
            this.Updation_Prog.Size = new System.Drawing.Size(366, 31);
            this.Updation_Prog.TabIndex = 103;
            this.Updation_Prog.Text = "بروزرسانی پرونده ها";
            this.Updation_Prog.ThemeName = "Office2010Silver";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // History_Auto_Calc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 203);
            this.Controls.Add(this.Updation_Prog);
            this.Controls.Add(this.Calculation_Prog);
            this.Controls.Add(this.Today_Btn);
            this.Controls.Add(this.radLabel18);
            this.Controls.Add(this.radLabel17);
            this.Controls.Add(this.radLabel16);
            this.Controls.Add(this.radLabel15);
            this.Controls.Add(this.radLabel14);
            this.Controls.Add(this.DT_Day);
            this.Controls.Add(this.DT_Mth);
            this.Controls.Add(this.DT_Yr);
            this.Controls.Add(this.radLabel11);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "History_Auto_Calc";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بروزرسانی اتوماتیک امتیاز سابقه کار در شرکت ";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.History_Auto_Calc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Today_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DT_Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DT_Mth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DT_Yr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Calculation_Prog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Updation_Prog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadMenuItem Save;
        private Telerik.WinControls.UI.RadMenuItem Exit;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadButton Today_Btn;
        private Telerik.WinControls.UI.RadLabel radLabel18;
        private Telerik.WinControls.UI.RadLabel radLabel17;
        private Telerik.WinControls.UI.RadLabel radLabel16;
        private Telerik.WinControls.UI.RadLabel radLabel15;
        private Telerik.WinControls.UI.RadLabel radLabel14;
        private Telerik.WinControls.UI.RadTextBox DT_Day;
        private Telerik.WinControls.UI.RadTextBox DT_Mth;
        private Telerik.WinControls.UI.RadTextBox DT_Yr;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadProgressBar Calculation_Prog;
        private Telerik.WinControls.UI.RadProgressBar Updation_Prog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
