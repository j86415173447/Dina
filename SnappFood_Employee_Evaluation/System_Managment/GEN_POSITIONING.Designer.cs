namespace SnappFood_Employee_Evaluation.System_Managment
{
    partial class GEN_POSITIONING
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GEN_POSITIONING));
            this.new_position = new System.Windows.Forms.ComboBox();
            this.radLabel21 = new Telerik.WinControls.UI.RadLabel();
            this.Per_Dep = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.lbl_pic = new Telerik.WinControls.UI.RadLabel();
            this.Per_Nk_Name = new Telerik.WinControls.UI.RadLabel();
            this.Per_Name = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.Cur_Position = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.Cur_Score = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.Doc_No = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.given_scr = new Telerik.WinControls.UI.RadTextBox();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.Per_Pic = new System.Windows.Forms.PictureBox();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.Print = new Telerik.WinControls.UI.RadMenuItem();
            this.Exit = new Telerik.WinControls.UI.RadMenuItem();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Dep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Nk_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cur_Position)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cur_Score)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Doc_No)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.given_scr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // new_position
            // 
            this.new_position.BackColor = System.Drawing.Color.LavenderBlush;
            this.new_position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.new_position.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_position.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_position.FormattingEnabled = true;
            this.new_position.Items.AddRange(new object[] {
            "",
            "کارشناس",
            "سرگروه",
            "رهبر",
            "سوپروایزر",
            "مدیر"});
            this.new_position.Location = new System.Drawing.Point(374, 200);
            this.new_position.Name = "new_position";
            this.new_position.Size = new System.Drawing.Size(168, 22);
            this.new_position.TabIndex = 95;
            this.new_position.SelectedIndexChanged += new System.EventHandler(this.new_position_SelectedIndexChanged);
            // 
            // radLabel21
            // 
            this.radLabel21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel21.Location = new System.Drawing.Point(548, 203);
            this.radLabel21.Name = "radLabel21";
            this.radLabel21.Size = new System.Drawing.Size(104, 18);
            this.radLabel21.TabIndex = 96;
            this.radLabel21.Text = "طبقه شغلی جدید:";
            this.radLabel21.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel21.ThemeName = "Office2010Silver";
            // 
            // Per_Dep
            // 
            this.Per_Dep.AutoSize = false;
            this.Per_Dep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Dep.Location = new System.Drawing.Point(153, 71);
            this.Per_Dep.Name = "Per_Dep";
            this.Per_Dep.Size = new System.Drawing.Size(126, 18);
            this.Per_Dep.TabIndex = 92;
            this.Per_Dep.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Per_Dep.ThemeName = "Office2010Silver";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(286, 71);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(84, 18);
            this.radLabel4.TabIndex = 90;
            this.radLabel4.Text = "واحد سازمانی:";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel4.ThemeName = "Office2010Silver";
            // 
            // lbl_pic
            // 
            this.lbl_pic.AutoSize = false;
            this.lbl_pic.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pic.Location = new System.Drawing.Point(12, 248);
            this.lbl_pic.Name = "lbl_pic";
            this.lbl_pic.Size = new System.Drawing.Size(135, 18);
            this.lbl_pic.TabIndex = 93;
            this.lbl_pic.Text = "عکس پرسنلی";
            this.lbl_pic.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lbl_pic.ThemeName = "Office2010Silver";
            // 
            // Per_Nk_Name
            // 
            this.Per_Nk_Name.AutoSize = false;
            this.Per_Nk_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Nk_Name.Location = new System.Drawing.Point(158, 115);
            this.Per_Nk_Name.Name = "Per_Nk_Name";
            this.Per_Nk_Name.Size = new System.Drawing.Size(139, 18);
            this.Per_Nk_Name.TabIndex = 91;
            this.Per_Nk_Name.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Per_Nk_Name.ThemeName = "Office2010Silver";
            // 
            // Per_Name
            // 
            this.Per_Name.AutoSize = false;
            this.Per_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Name.Location = new System.Drawing.Point(376, 115);
            this.Per_Name.Name = "Per_Name";
            this.Per_Name.Size = new System.Drawing.Size(169, 18);
            this.Per_Name.TabIndex = 86;
            this.Per_Name.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Per_Name.ThemeName = "Office2010Silver";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(303, 115);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(67, 18);
            this.radLabel6.TabIndex = 89;
            this.radLabel6.Text = "نام مستعار:";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel6.ThemeName = "Office2010Silver";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(552, 115);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(104, 18);
            this.radLabel8.TabIndex = 85;
            this.radLabel8.Text = "نام و نام خانوادگی:";
            this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel8.ThemeName = "Office2010Silver";
            // 
            // Cur_Position
            // 
            this.Cur_Position.AutoSize = false;
            this.Cur_Position.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cur_Position.Location = new System.Drawing.Point(158, 159);
            this.Cur_Position.Name = "Cur_Position";
            this.Cur_Position.Size = new System.Drawing.Size(95, 18);
            this.Cur_Position.TabIndex = 94;
            this.Cur_Position.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Cur_Position.ThemeName = "Office2010Silver";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(259, 159);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(107, 18);
            this.radLabel2.TabIndex = 93;
            this.radLabel2.Text = "طبقه شغلی فعلی:";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel2.ThemeName = "Office2010Silver";
            // 
            // Cur_Score
            // 
            this.Cur_Score.AutoSize = false;
            this.Cur_Score.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cur_Score.Location = new System.Drawing.Point(448, 159);
            this.Cur_Score.Name = "Cur_Score";
            this.Cur_Score.Size = new System.Drawing.Size(95, 18);
            this.Cur_Score.TabIndex = 96;
            this.Cur_Score.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Cur_Score.ThemeName = "Office2010Silver";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(549, 159);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(107, 18);
            this.radLabel5.TabIndex = 95;
            this.radLabel5.Text = "امتیاز شغلی فعلی:";
            this.radLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel5.ThemeName = "Office2010Silver";
            // 
            // Doc_No
            // 
            this.Doc_No.AutoSize = false;
            this.Doc_No.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Doc_No.Location = new System.Drawing.Point(439, 71);
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
            // radLabel10
            // 
            this.radLabel10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel10.Location = new System.Drawing.Point(507, 248);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(149, 18);
            this.radLabel10.TabIndex = 97;
            this.radLabel10.Text = "امتیاز اصلاح سطح پرداختی:";
            this.radLabel10.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel10.ThemeName = "Office2010Silver";
            // 
            // given_scr
            // 
            this.given_scr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.given_scr.Location = new System.Drawing.Point(439, 246);
            this.given_scr.Name = "given_scr";
            this.given_scr.Size = new System.Drawing.Size(62, 20);
            this.given_scr.TabIndex = 98;
            this.given_scr.ThemeName = "Office2010Silver";
            this.given_scr.TextChanged += new System.EventHandler(this.given_scr_TextChanged);
            this.given_scr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Only_Digit);
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
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.Green;
            this.radLabel1.Location = new System.Drawing.Point(12, 274);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(644, 55);
            this.radLabel1.TabIndex = 98;
            this.radLabel1.Text = resources.GetString("radLabel1.Text");
            this.radLabel1.ThemeName = "Office2010Silver";
            // 
            // GEN_POSITIONING
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 341);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.given_scr);
            this.Controls.Add(this.radLabel10);
            this.Controls.Add(this.Doc_No);
            this.Controls.Add(this.Cur_Score);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.Cur_Position);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.new_position);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel21);
            this.Controls.Add(this.Per_Dep);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.lbl_pic);
            this.Controls.Add(this.Per_Pic);
            this.Controls.Add(this.Per_Nk_Name);
            this.Controls.Add(this.Per_Name);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "GEN_POSITIONING";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انتصاب سطوح شغلی پرسنل";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.GEN_POSITIONING_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Dep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Nk_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cur_Position)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cur_Score)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Doc_No)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.given_scr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Pic)).EndInit();
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
        private System.Windows.Forms.ComboBox new_position;
        private Telerik.WinControls.UI.RadLabel radLabel21;
        private Telerik.WinControls.UI.RadLabel Per_Dep;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel lbl_pic;
        private System.Windows.Forms.PictureBox Per_Pic;
        private Telerik.WinControls.UI.RadLabel Per_Nk_Name;
        private Telerik.WinControls.UI.RadLabel Per_Name;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel Cur_Position;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel Cur_Score;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadTextBox given_scr;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        public Telerik.WinControls.UI.RadLabel Doc_No;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
