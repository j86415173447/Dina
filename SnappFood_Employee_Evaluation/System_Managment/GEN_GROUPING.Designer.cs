namespace SnappFood_Employee_Evaluation.System_Managment
{
    partial class GEN_GROUPING
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
            this.supervisor = new System.Windows.Forms.ComboBox();
            this.radLabel21 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.Grp_Id = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.Print = new Telerik.WinControls.UI.RadMenuItem();
            this.New = new Telerik.WinControls.UI.RadMenuItem();
            this.Exit = new Telerik.WinControls.UI.RadMenuItem();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.manager = new System.Windows.Forms.ComboBox();
            this.dep = new System.Windows.Forms.ComboBox();
            this.coordinator = new System.Windows.Forms.ComboBox();
            this.leader = new System.Windows.Forms.ComboBox();
            this.shift = new System.Windows.Forms.ComboBox();
            this.Grp_Nm = new Telerik.WinControls.UI.RadTextBox();
            this.Grp_ACTV = new Telerik.WinControls.UI.RadCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grp_Id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grp_Nm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grp_ACTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // supervisor
            // 
            this.supervisor.BackColor = System.Drawing.Color.LavenderBlush;
            this.supervisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supervisor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.supervisor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supervisor.FormattingEnabled = true;
            this.supervisor.Location = new System.Drawing.Point(156, 232);
            this.supervisor.Name = "supervisor";
            this.supervisor.Size = new System.Drawing.Size(175, 22);
            this.supervisor.TabIndex = 95;
            this.supervisor.Visible = false;
            this.supervisor.Click += new System.EventHandler(this.coordinator_Click);
            // 
            // radLabel21
            // 
            this.radLabel21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel21.Location = new System.Drawing.Point(363, 235);
            this.radLabel21.Name = "radLabel21";
            this.radLabel21.Size = new System.Drawing.Size(58, 18);
            this.radLabel21.TabIndex = 96;
            this.radLabel21.Text = "سوپروایزر:";
            this.radLabel21.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel21.ThemeName = "Office2010Silver";
            this.radLabel21.Visible = false;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(189, 68);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(51, 18);
            this.radLabel4.TabIndex = 90;
            this.radLabel4.Text = "نام گروه:";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel4.ThemeName = "Office2010Silver";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(461, 152);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(50, 18);
            this.radLabel6.TabIndex = 89;
            this.radLabel6.Text = "سرگروه:";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel6.ThemeName = "Office2010Silver";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(427, 110);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(84, 18);
            this.radLabel8.TabIndex = 85;
            this.radLabel8.Text = "واحد سازمانی:";
            this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel8.ThemeName = "Office2010Silver";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(180, 152);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(60, 18);
            this.radLabel2.TabIndex = 93;
            this.radLabel2.Text = "سرپرست:";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel2.ThemeName = "Office2010Silver";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(195, 110);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(45, 18);
            this.radLabel5.TabIndex = 95;
            this.radLabel5.Text = "شیفت:";
            this.radLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel5.ThemeName = "Office2010Silver";
            // 
            // Grp_Id
            // 
            this.Grp_Id.AutoSize = false;
            this.Grp_Id.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Id.Location = new System.Drawing.Point(246, 68);
            this.Grp_Id.Name = "Grp_Id";
            this.Grp_Id.Size = new System.Drawing.Size(175, 18);
            this.Grp_Id.TabIndex = 94;
            this.Grp_Id.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Grp_Id.ThemeName = "Office2010Silver";
            this.Grp_Id.TextChanged += new System.EventHandler(this.Doc_No_TextChanged);
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(462, 68);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(49, 18);
            this.radLabel9.TabIndex = 93;
            this.radLabel9.Text = "کد گروه:";
            this.radLabel9.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel9.ThemeName = "Office2010Silver";
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
            this.Print,
            this.New,
            this.Exit});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(521, 55);
            this.radMenu1.TabIndex = 2;
            this.radMenu1.ThemeName = "Office2010Silver";
            // 
            // Save
            // 
            this.Save.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.save1;
            this.Save.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Save.Name = "Save";
            this.Save.Text = "     ثبت     ";
            this.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Save.UseCompatibleTextRendering = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Print
            // 
            this.Print.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.search_icon;
            this.Print.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Print.Name = "Print";
            this.Print.Text = "جستجوی گروه ها";
            this.Print.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Print.UseCompatibleTextRendering = false;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // New
            // 
            this.New.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.plusplus;
            this.New.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.New.Name = "New";
            this.New.Text = "ورودی جدید";
            this.New.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.New.Click += new System.EventHandler(this.New_Click);
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
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(476, 193);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(33, 18);
            this.radLabel1.TabIndex = 97;
            this.radLabel1.Text = "مدیر:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel1.ThemeName = "Office2010Silver";
            // 
            // manager
            // 
            this.manager.BackColor = System.Drawing.Color.LavenderBlush;
            this.manager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manager.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manager.FormattingEnabled = true;
            this.manager.Location = new System.Drawing.Point(246, 190);
            this.manager.Name = "manager";
            this.manager.Size = new System.Drawing.Size(175, 22);
            this.manager.TabIndex = 98;
            this.manager.Click += new System.EventHandler(this.coordinator_Click);
            // 
            // dep
            // 
            this.dep.BackColor = System.Drawing.Color.LavenderBlush;
            this.dep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dep.FormattingEnabled = true;
            this.dep.Location = new System.Drawing.Point(246, 107);
            this.dep.Name = "dep";
            this.dep.Size = new System.Drawing.Size(175, 22);
            this.dep.TabIndex = 99;
            this.dep.SelectedIndexChanged += new System.EventHandler(this.dep_SelectedIndexChanged);
            // 
            // coordinator
            // 
            this.coordinator.BackColor = System.Drawing.Color.LavenderBlush;
            this.coordinator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coordinator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coordinator.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coordinator.FormattingEnabled = true;
            this.coordinator.Location = new System.Drawing.Point(246, 149);
            this.coordinator.Name = "coordinator";
            this.coordinator.Size = new System.Drawing.Size(175, 22);
            this.coordinator.TabIndex = 100;
            this.coordinator.Click += new System.EventHandler(this.coordinator_Click);
            // 
            // leader
            // 
            this.leader.BackColor = System.Drawing.Color.LavenderBlush;
            this.leader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leader.FormattingEnabled = true;
            this.leader.Location = new System.Drawing.Point(12, 149);
            this.leader.Name = "leader";
            this.leader.Size = new System.Drawing.Size(162, 22);
            this.leader.TabIndex = 101;
            this.leader.Click += new System.EventHandler(this.coordinator_Click);
            // 
            // shift
            // 
            this.shift.BackColor = System.Drawing.Color.LavenderBlush;
            this.shift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shift.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shift.FormattingEnabled = true;
            this.shift.Items.AddRange(new object[] {
            "",
            "صبح",
            "عصر",
            "شب"});
            this.shift.Location = new System.Drawing.Point(12, 107);
            this.shift.Name = "shift";
            this.shift.Size = new System.Drawing.Size(162, 22);
            this.shift.TabIndex = 102;
            this.shift.SelectedIndexChanged += new System.EventHandler(this.dep_SelectedIndexChanged);
            // 
            // Grp_Nm
            // 
            this.Grp_Nm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Grp_Nm.Location = new System.Drawing.Point(12, 68);
            this.Grp_Nm.Name = "Grp_Nm";
            this.Grp_Nm.Size = new System.Drawing.Size(171, 19);
            this.Grp_Nm.TabIndex = 103;
            this.Grp_Nm.ThemeName = "Office2010Silver";
            // 
            // Grp_ACTV
            // 
            this.Grp_ACTV.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Grp_ACTV.Location = new System.Drawing.Point(442, 236);
            this.Grp_ACTV.Name = "Grp_ACTV";
            this.Grp_ACTV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Grp_ACTV.Size = new System.Drawing.Size(69, 17);
            this.Grp_ACTV.TabIndex = 104;
            this.Grp_ACTV.Text = ":گروه فعال";
            // 
            // GEN_GROUPING
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 268);
            this.Controls.Add(this.Grp_ACTV);
            this.Controls.Add(this.Grp_Nm);
            this.Controls.Add(this.shift);
            this.Controls.Add(this.leader);
            this.Controls.Add(this.coordinator);
            this.Controls.Add(this.dep);
            this.Controls.Add(this.manager);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.Grp_Id);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.supervisor);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel21);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "GEN_GROUPING";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت گروه های شغلی";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.GEN_POSITIONING_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grp_Id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grp_Nm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grp_ACTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem Save;
        private Telerik.WinControls.UI.RadMenuItem Print;
        private Telerik.WinControls.UI.RadMenuItem Exit;
        private System.Windows.Forms.ComboBox supervisor;
        private Telerik.WinControls.UI.RadLabel radLabel21;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        public Telerik.WinControls.UI.RadLabel Grp_Id;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.ComboBox manager;
        private System.Windows.Forms.ComboBox dep;
        private System.Windows.Forms.ComboBox coordinator;
        private System.Windows.Forms.ComboBox leader;
        private System.Windows.Forms.ComboBox shift;
        private Telerik.WinControls.UI.RadTextBox Grp_Nm;
        private Telerik.WinControls.UI.RadCheckBox Grp_ACTV;
        private Telerik.WinControls.UI.RadMenuItem New;
    }
}
