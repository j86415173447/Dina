namespace SnappFood_Employee_Evaluation.System_Managment
{
    partial class GEN_TRANSFER
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
            this.new_dep = new System.Windows.Forms.ComboBox();
            this.radLabel21 = new Telerik.WinControls.UI.RadLabel();
            this.cur_dep = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.cur_shift = new Telerik.WinControls.UI.RadLabel();
            this.Per_Name = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.current_ext_cd = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.Doc_No = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.Per_Pic = new System.Windows.Forms.PictureBox();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.Print = new Telerik.WinControls.UI.RadMenuItem();
            this.Exit = new Telerik.WinControls.UI.RadMenuItem();
            this.new_shift = new System.Windows.Forms.ComboBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.sys_id = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cur_dep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cur_shift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.current_ext_cd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Doc_No)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sys_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // new_dep
            // 
            this.new_dep.BackColor = System.Drawing.Color.LavenderBlush;
            this.new_dep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.new_dep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_dep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_dep.FormattingEnabled = true;
            this.new_dep.Items.AddRange(new object[] {
            "",
            "کارشناس",
            "سرگروه",
            "رهبر",
            "سوپروایزر",
            "مدیر"});
            this.new_dep.Location = new System.Drawing.Point(377, 226);
            this.new_dep.Name = "new_dep";
            this.new_dep.Size = new System.Drawing.Size(210, 22);
            this.new_dep.TabIndex = 95;
            this.new_dep.SelectedIndexChanged += new System.EventHandler(this.new_position_SelectedIndexChanged);
            // 
            // radLabel21
            // 
            this.radLabel21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel21.Location = new System.Drawing.Point(593, 227);
            this.radLabel21.Name = "radLabel21";
            this.radLabel21.Size = new System.Drawing.Size(63, 18);
            this.radLabel21.TabIndex = 96;
            this.radLabel21.Text = "واحد جدید:";
            this.radLabel21.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel21.ThemeName = "Office2010Silver";
            // 
            // cur_dep
            // 
            this.cur_dep.AutoSize = false;
            this.cur_dep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cur_dep.Location = new System.Drawing.Point(153, 123);
            this.cur_dep.Name = "cur_dep";
            this.cur_dep.Size = new System.Drawing.Size(126, 18);
            this.cur_dep.TabIndex = 92;
            this.cur_dep.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.cur_dep.ThemeName = "Office2010Silver";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(286, 123);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(84, 18);
            this.radLabel4.TabIndex = 90;
            this.radLabel4.Text = "واحد سازمانی:";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel4.ThemeName = "Office2010Silver";
            // 
            // cur_shift
            // 
            this.cur_shift.AutoSize = false;
            this.cur_shift.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cur_shift.Location = new System.Drawing.Point(158, 175);
            this.cur_shift.Name = "cur_shift";
            this.cur_shift.Size = new System.Drawing.Size(128, 18);
            this.cur_shift.TabIndex = 91;
            this.cur_shift.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.cur_shift.ThemeName = "Office2010Silver";
            // 
            // Per_Name
            // 
            this.Per_Name.AutoSize = false;
            this.Per_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Name.Location = new System.Drawing.Point(377, 123);
            this.Per_Name.Name = "Per_Name";
            this.Per_Name.Size = new System.Drawing.Size(169, 18);
            this.Per_Name.TabIndex = 86;
            this.Per_Name.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Per_Name.ThemeName = "Office2010Silver";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(293, 175);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(77, 18);
            this.radLabel6.TabIndex = 89;
            this.radLabel6.Text = "شیفت فعلی:";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel6.ThemeName = "Office2010Silver";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(552, 123);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(104, 18);
            this.radLabel8.TabIndex = 85;
            this.radLabel8.Text = "نام و نام خانوادگی:";
            this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel8.ThemeName = "Office2010Silver";
            // 
            // current_ext_cd
            // 
            this.current_ext_cd.AutoSize = false;
            this.current_ext_cd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current_ext_cd.Location = new System.Drawing.Point(451, 175);
            this.current_ext_cd.Name = "current_ext_cd";
            this.current_ext_cd.Size = new System.Drawing.Size(95, 18);
            this.current_ext_cd.TabIndex = 96;
            this.current_ext_cd.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.current_ext_cd.ThemeName = "Office2010Silver";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(556, 175);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(100, 18);
            this.radLabel5.TabIndex = 95;
            this.radLabel5.Text = "کد واحد سازمانی:";
            this.radLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel5.ThemeName = "Office2010Silver";
            // 
            // Doc_No
            // 
            this.Doc_No.AutoSize = false;
            this.Doc_No.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Doc_No.Location = new System.Drawing.Point(446, 71);
            this.Doc_No.Name = "Doc_No";
            this.Doc_No.Size = new System.Drawing.Size(126, 18);
            this.Doc_No.TabIndex = 94;
            this.Doc_No.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Doc_No.ThemeName = "Office2010Silver";
            this.Doc_No.TextChanged += new System.EventHandler(this.Doc_No_TextChanged);
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(578, 71);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(78, 18);
            this.radLabel9.TabIndex = 93;
            this.radLabel9.Text = "شماره پرونده:";
            this.radLabel9.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel9.ThemeName = "Office2010Silver";
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // Per_Pic
            // 
            this.Per_Pic.BackColor = System.Drawing.Color.LavenderBlush;
            this.Per_Pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Per_Pic.Location = new System.Drawing.Point(12, 67);
            this.Per_Pic.Name = "Per_Pic";
            this.Per_Pic.Size = new System.Drawing.Size(135, 180);
            this.Per_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Per_Pic.TabIndex = 94;
            this.Per_Pic.TabStop = false;
            // 
            // radMenu1
            // 
            this.radMenu1.BackColor = System.Drawing.Color.Pink;
            this.radMenu1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.Save,
            this.Print,
            this.Exit});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(668, 53);
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
            this.Print.Text = "جستجوی پرسنل";
            this.Print.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Print.UseCompatibleTextRendering = false;
            this.Print.Click += new System.EventHandler(this.Print_Click);
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
            // new_shift
            // 
            this.new_shift.BackColor = System.Drawing.Color.LavenderBlush;
            this.new_shift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.new_shift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_shift.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_shift.FormattingEnabled = true;
            this.new_shift.Items.AddRange(new object[] {
            "",
            "روز",
            "شب"});
            this.new_shift.Location = new System.Drawing.Point(158, 226);
            this.new_shift.Name = "new_shift";
            this.new_shift.Size = new System.Drawing.Size(132, 22);
            this.new_shift.TabIndex = 97;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(296, 229);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(74, 18);
            this.radLabel1.TabIndex = 98;
            this.radLabel1.Text = "شیفت جدید:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel1.ThemeName = "Office2010Silver";
            // 
            // sys_id
            // 
            this.sys_id.AutoSize = false;
            this.sys_id.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sys_id.Location = new System.Drawing.Point(175, 71);
            this.sys_id.Name = "sys_id";
            this.sys_id.Size = new System.Drawing.Size(107, 18);
            this.sys_id.TabIndex = 88;
            this.sys_id.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.sys_id.ThemeName = "Office2010Silver";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(288, 71);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(82, 18);
            this.radLabel3.TabIndex = 87;
            this.radLabel3.Text = "شماره داخلی:";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel3.ThemeName = "Office2010Silver";
            // 
            // GEN_TRANSFER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 262);
            this.Controls.Add(this.sys_id);
            this.Controls.Add(this.new_shift);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.Doc_No);
            this.Controls.Add(this.current_ext_cd);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.new_dep);
            this.Controls.Add(this.radLabel21);
            this.Controls.Add(this.cur_dep);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.Per_Pic);
            this.Controls.Add(this.cur_shift);
            this.Controls.Add(this.Per_Name);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "GEN_TRANSFER";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تغییر واحد سازمانی پرسنل";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.GEN_POSITIONING_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cur_dep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cur_shift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.current_ext_cd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Doc_No)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sys_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem Save;
        private Telerik.WinControls.UI.RadMenuItem Print;
        private Telerik.WinControls.UI.RadMenuItem Exit;
        private System.Windows.Forms.ComboBox new_dep;
        private Telerik.WinControls.UI.RadLabel radLabel21;
        private Telerik.WinControls.UI.RadLabel cur_dep;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private System.Windows.Forms.PictureBox Per_Pic;
        private Telerik.WinControls.UI.RadLabel cur_shift;
        private Telerik.WinControls.UI.RadLabel Per_Name;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel current_ext_cd;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        public Telerik.WinControls.UI.RadLabel Doc_No;
        private System.Windows.Forms.ComboBox new_shift;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel sys_id;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}
