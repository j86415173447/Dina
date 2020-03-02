namespace SnappFood_Employee_Evaluation.After_Sales
{
    partial class AS_USER_MANAGMENT
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
            this.combo_roles = new System.Windows.Forms.ComboBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.usr_per_name = new Telerik.WinControls.UI.RadTextBox();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.must_chng = new Telerik.WinControls.UI.RadCheckBox();
            this.usr_id = new Telerik.WinControls.UI.RadTextBox();
            this.donutShape1 = new Telerik.WinControls.Tests.DonutShape();
            this.actv = new Telerik.WinControls.UI.RadCheckBox();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.Print = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.Exit = new Telerik.WinControls.UI.RadMenuItem();
            this.org_role = new System.Windows.Forms.ComboBox();
            this.AS_Center = new System.Windows.Forms.ComboBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usr_per_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.must_chng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usr_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // combo_roles
            // 
            this.combo_roles.BackColor = System.Drawing.Color.LavenderBlush;
            this.combo_roles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_roles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_roles.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_roles.FormattingEnabled = true;
            this.combo_roles.Items.AddRange(new object[] {
            "",
            "کارشناس",
            "سرگروه",
            "رهبر",
            "سوپروایزر",
            "مدیر"});
            this.combo_roles.Location = new System.Drawing.Point(16, 112);
            this.combo_roles.Name = "combo_roles";
            this.combo_roles.Size = new System.Drawing.Size(168, 22);
            this.combo_roles.TabIndex = 95;
            this.combo_roles.SelectedIndexChanged += new System.EventHandler(this.new_position_SelectedIndexChanged);
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(223, 70);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(63, 18);
            this.radLabel4.TabIndex = 90;
            this.radLabel4.Text = "نام کاربری:";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel4.ThemeName = "Office2010Silver";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(190, 114);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(96, 18);
            this.radLabel6.TabIndex = 89;
            this.radLabel6.Text = "سطح دسترسی:";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel6.ThemeName = "Office2010Silver";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(509, 115);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(63, 18);
            this.radLabel8.TabIndex = 85;
            this.radLabel8.Text = "نقش کاربر:";
            this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel8.ThemeName = "Office2010Silver";
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(468, 70);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(104, 18);
            this.radLabel9.TabIndex = 93;
            this.radLabel9.Text = "نام و نام خانوادگی:";
            this.radLabel9.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel9.ThemeName = "Office2010Silver";
            // 
            // usr_per_name
            // 
            this.usr_per_name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usr_per_name.Location = new System.Drawing.Point(292, 69);
            this.usr_per_name.Name = "usr_per_name";
            this.usr_per_name.Size = new System.Drawing.Size(170, 20);
            this.usr_per_name.TabIndex = 98;
            this.usr_per_name.ThemeName = "Office2010Silver";
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // must_chng
            // 
            this.must_chng.CheckState = System.Windows.Forms.CheckState.Checked;
            this.must_chng.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.must_chng.Location = new System.Drawing.Point(127, 160);
            this.must_chng.Name = "must_chng";
            this.must_chng.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.must_chng.Size = new System.Drawing.Size(162, 19);
            this.must_chng.TabIndex = 100;
            this.must_chng.Text = "  :اجبار تغییر رمز در اولین ورود";
            this.must_chng.ThemeName = "Office2010Silver";
            this.must_chng.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.must_chng.Visible = false;
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.must_chng.GetChildAt(0))).ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.must_chng.GetChildAt(0))).Text = "  :اجبار تغییر رمز در اولین ورود";
            ((Telerik.WinControls.UI.RadCheckmark)(this.must_chng.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ScaleTransform = new System.Drawing.SizeF(1F, 1F);
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.must_chng.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).CheckPrimitiveStyle = Telerik.WinControls.Enumerations.CheckPrimitiveStyleEnum.Win8;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.must_chng.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).DrawFill = false;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.must_chng.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).CheckThickness = 50;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.must_chng.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).ForeColor = System.Drawing.Color.DeepPink;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.must_chng.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.must_chng.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.must_chng.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).Shape = null;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.must_chng.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).ScaleTransform = new System.Drawing.SizeF(1.3F, 1.3F);
            // 
            // usr_id
            // 
            this.usr_id.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usr_id.Location = new System.Drawing.Point(16, 69);
            this.usr_id.Name = "usr_id";
            this.usr_id.Size = new System.Drawing.Size(170, 20);
            this.usr_id.TabIndex = 99;
            this.usr_id.ThemeName = "Office2010Silver";
            // 
            // actv
            // 
            this.actv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.actv.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.actv.Location = new System.Drawing.Point(16, 160);
            this.actv.Name = "actv";
            this.actv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.actv.Size = new System.Drawing.Size(80, 19);
            this.actv.TabIndex = 101;
            this.actv.Text = "  :کاربر فعال";
            this.actv.ThemeName = "Office2010Silver";
            this.actv.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.actv.Visible = false;
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.actv.GetChildAt(0))).ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.actv.GetChildAt(0))).Text = "  :کاربر فعال";
            ((Telerik.WinControls.UI.RadCheckmark)(this.actv.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ScaleTransform = new System.Drawing.SizeF(1F, 1F);
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.actv.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).CheckPrimitiveStyle = Telerik.WinControls.Enumerations.CheckPrimitiveStyleEnum.Win8;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.actv.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).DrawFill = false;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.actv.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).CheckThickness = 50;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.actv.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).ForeColor = System.Drawing.Color.DeepPink;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.actv.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.actv.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).Shape = null;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.actv.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).ScaleTransform = new System.Drawing.SizeF(1.3F, 1.3F);
            // 
            // radMenu1
            // 
            this.radMenu1.BackColor = System.Drawing.Color.Pink;
            this.radMenu1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.Save,
            this.Print,
            this.radMenuItem1,
            this.radMenuItem2,
            this.Exit});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(582, 55);
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
            // radMenuItem1
            // 
            this.radMenuItem1.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.secrecy_icon;
            this.radMenuItem1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "تغییر پسورد";
            this.radMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radMenuItem1.Click += new System.EventHandler(this.radMenuItem1_Click);
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.plusplus;
            this.radMenuItem2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "ورودی جدید";
            this.radMenuItem2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radMenuItem2.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            this.radMenuItem2.Click += new System.EventHandler(this.radMenuItem2_Click);
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
            // org_role
            // 
            this.org_role.BackColor = System.Drawing.Color.LavenderBlush;
            this.org_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.org_role.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.org_role.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.org_role.FormattingEnabled = true;
            this.org_role.Items.AddRange(new object[] {
            "",
            "کارشناس",
            "سرگروه",
            "رهبر",
            "سوپروایزر",
            "مدیر"});
            this.org_role.Location = new System.Drawing.Point(292, 112);
            this.org_role.Name = "org_role";
            this.org_role.Size = new System.Drawing.Size(170, 22);
            this.org_role.TabIndex = 102;
            // 
            // AS_Center
            // 
            this.AS_Center.BackColor = System.Drawing.Color.LavenderBlush;
            this.AS_Center.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AS_Center.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AS_Center.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AS_Center.FormattingEnabled = true;
            this.AS_Center.Items.AddRange(new object[] {
            "",
            "DHQ",
            "ETD"});
            this.AS_Center.Location = new System.Drawing.Point(290, 157);
            this.AS_Center.Name = "AS_Center";
            this.AS_Center.Size = new System.Drawing.Size(172, 22);
            this.AS_Center.TabIndex = 104;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(494, 160);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(78, 18);
            this.radLabel1.TabIndex = 103;
            this.radLabel1.Text = "واحد خدماتی:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel1.ThemeName = "Office2010Silver";
            // 
            // AS_USER_MANAGMENT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 192);
            this.Controls.Add(this.AS_Center);
            this.Controls.Add(this.org_role);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.actv);
            this.Controls.Add(this.usr_id);
            this.Controls.Add(this.must_chng);
            this.Controls.Add(this.usr_per_name);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.combo_roles);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "AS_USER_MANAGMENT";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت کاربران";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.GEN_POSITIONING_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usr_per_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.must_chng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usr_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem Save;
        private Telerik.WinControls.UI.RadMenuItem Print;
        private Telerik.WinControls.UI.RadMenuItem Exit;
        private System.Windows.Forms.ComboBox combo_roles;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadTextBox usr_per_name;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadCheckBox must_chng;
        public Telerik.WinControls.UI.RadTextBox usr_id;
        private Telerik.WinControls.Tests.DonutShape donutShape1;
        private Telerik.WinControls.UI.RadCheckBox actv;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private System.Windows.Forms.ComboBox org_role;
        private System.Windows.Forms.ComboBox AS_Center;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
