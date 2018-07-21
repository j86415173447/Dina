namespace SnappFood_Employee_Evaluation.Scores_Ops
{
    partial class SCR_MNG
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.Print = new Telerik.WinControls.UI.RadMenuItem();
            this.Exit = new Telerik.WinControls.UI.RadMenuItem();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.Per_Name = new Telerik.WinControls.UI.RadLabel();
            this.Per_Fa_Name = new Telerik.WinControls.UI.RadLabel();
            this.Per_Nk_Name = new Telerik.WinControls.UI.RadLabel();
            this.lbl_pic = new Telerik.WinControls.UI.RadLabel();
            this.Per_Pic = new System.Windows.Forms.PictureBox();
            this.lbl_rec_tot = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.Per_Dep = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.SCR_Type = new System.Windows.Forms.ComboBox();
            this.radLabel21 = new Telerik.WinControls.UI.RadLabel();
            this.lbl_tot_cap = new Telerik.WinControls.UI.RadLabel();
            this.lbl_sel_cap = new Telerik.WinControls.UI.RadLabel();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.given_scr = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.grid = new Telerik.WinControls.UI.RadGridView();
            this.lbl_rec_sel = new Telerik.WinControls.UI.RadLabel();
            this.lbl_cur_scr = new Telerik.WinControls.UI.RadLabel();
            this.radLabel15 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Fa_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Nk_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_rec_tot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Dep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_tot_cap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_sel_cap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.given_scr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_rec_sel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_cur_scr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).BeginInit();
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
            this.Print,
            this.Exit});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(668, 53);
            this.radMenu1.TabIndex = 1;
            this.radMenu1.Text = "radMenu1";
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
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(264, 105);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(67, 18);
            this.radLabel6.TabIndex = 67;
            this.radLabel6.Text = "نام مستعار:";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel6.ThemeName = "Office2010Silver";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(287, 70);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(44, 18);
            this.radLabel5.TabIndex = 66;
            this.radLabel5.Text = "نام پدر:";
            this.radLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel5.ThemeName = "Office2010Silver";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(552, 70);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(104, 18);
            this.radLabel8.TabIndex = 65;
            this.radLabel8.Text = "نام و نام خانوادگی:";
            this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel8.ThemeName = "Office2010Silver";
            // 
            // Per_Name
            // 
            this.Per_Name.AutoSize = false;
            this.Per_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Name.Location = new System.Drawing.Point(359, 70);
            this.Per_Name.Name = "Per_Name";
            this.Per_Name.Size = new System.Drawing.Size(186, 18);
            this.Per_Name.TabIndex = 66;
            this.Per_Name.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Per_Name.ThemeName = "Office2010Silver";
            // 
            // Per_Fa_Name
            // 
            this.Per_Fa_Name.AutoSize = false;
            this.Per_Fa_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Fa_Name.Location = new System.Drawing.Point(153, 70);
            this.Per_Fa_Name.Name = "Per_Fa_Name";
            this.Per_Fa_Name.Size = new System.Drawing.Size(128, 18);
            this.Per_Fa_Name.TabIndex = 67;
            this.Per_Fa_Name.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Per_Fa_Name.ThemeName = "Office2010Silver";
            // 
            // Per_Nk_Name
            // 
            this.Per_Nk_Name.AutoSize = false;
            this.Per_Nk_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Nk_Name.Location = new System.Drawing.Point(153, 105);
            this.Per_Nk_Name.Name = "Per_Nk_Name";
            this.Per_Nk_Name.Size = new System.Drawing.Size(105, 18);
            this.Per_Nk_Name.TabIndex = 68;
            this.Per_Nk_Name.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Per_Nk_Name.ThemeName = "Office2010Silver";
            // 
            // lbl_pic
            // 
            this.lbl_pic.AutoSize = false;
            this.lbl_pic.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pic.Location = new System.Drawing.Point(12, 247);
            this.lbl_pic.Name = "lbl_pic";
            this.lbl_pic.Size = new System.Drawing.Size(135, 18);
            this.lbl_pic.TabIndex = 81;
            this.lbl_pic.Text = "عکس پرسنلی";
            this.lbl_pic.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lbl_pic.ThemeName = "Office2010Silver";
            // 
            // Per_Pic
            // 
            this.Per_Pic.BackColor = System.Drawing.Color.LavenderBlush;
            this.Per_Pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Per_Pic.Location = new System.Drawing.Point(12, 66);
            this.Per_Pic.Name = "Per_Pic";
            this.Per_Pic.Size = new System.Drawing.Size(135, 180);
            this.Per_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Per_Pic.TabIndex = 82;
            this.Per_Pic.TabStop = false;
            // 
            // lbl_rec_tot
            // 
            this.lbl_rec_tot.AutoSize = false;
            this.lbl_rec_tot.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rec_tot.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_rec_tot.Location = new System.Drawing.Point(302, 219);
            this.lbl_rec_tot.Name = "lbl_rec_tot";
            this.lbl_rec_tot.Size = new System.Drawing.Size(108, 18);
            this.lbl_rec_tot.TabIndex = 69;
            this.lbl_rec_tot.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lbl_rec_tot.ThemeName = "Office2010Silver";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(416, 219);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(240, 18);
            this.radLabel2.TabIndex = 68;
            this.radLabel2.Text = "مجموع امتیاز تشویقی دریافتی در سال جاری:";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel2.ThemeName = "Office2010Silver";
            // 
            // Per_Dep
            // 
            this.Per_Dep.AutoSize = false;
            this.Per_Dep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Dep.Location = new System.Drawing.Point(359, 105);
            this.Per_Dep.Name = "Per_Dep";
            this.Per_Dep.Size = new System.Drawing.Size(206, 18);
            this.Per_Dep.TabIndex = 69;
            this.Per_Dep.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Per_Dep.ThemeName = "Office2010Silver";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(572, 105);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(84, 18);
            this.radLabel4.TabIndex = 68;
            this.radLabel4.Text = "واحد سازمانی:";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel4.ThemeName = "Office2010Silver";
            // 
            // SCR_Type
            // 
            this.SCR_Type.BackColor = System.Drawing.Color.LavenderBlush;
            this.SCR_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SCR_Type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SCR_Type.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SCR_Type.FormattingEnabled = true;
            this.SCR_Type.Location = new System.Drawing.Point(337, 140);
            this.SCR_Type.Name = "SCR_Type";
            this.SCR_Type.Size = new System.Drawing.Size(207, 22);
            this.SCR_Type.TabIndex = 83;
            this.SCR_Type.SelectedIndexChanged += new System.EventHandler(this.SCR_Type_SelectedValueChanged);
            // 
            // radLabel21
            // 
            this.radLabel21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel21.Location = new System.Drawing.Point(551, 143);
            this.radLabel21.Name = "radLabel21";
            this.radLabel21.Size = new System.Drawing.Size(105, 18);
            this.radLabel21.TabIndex = 84;
            this.radLabel21.Text = "نوع امتیاز تشویقی:";
            this.radLabel21.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel21.ThemeName = "Office2010Silver";
            // 
            // lbl_tot_cap
            // 
            this.lbl_tot_cap.AutoSize = false;
            this.lbl_tot_cap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tot_cap.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_tot_cap.Location = new System.Drawing.Point(320, 185);
            this.lbl_tot_cap.Name = "lbl_tot_cap";
            this.lbl_tot_cap.Size = new System.Drawing.Size(108, 18);
            this.lbl_tot_cap.TabIndex = 71;
            this.lbl_tot_cap.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lbl_tot_cap.ThemeName = "Office2010Silver";
            // 
            // lbl_sel_cap
            // 
            this.lbl_sel_cap.AutoSize = false;
            this.lbl_sel_cap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sel_cap.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_sel_cap.Location = new System.Drawing.Point(289, 252);
            this.lbl_sel_cap.Name = "lbl_sel_cap";
            this.lbl_sel_cap.Size = new System.Drawing.Size(108, 18);
            this.lbl_sel_cap.TabIndex = 73;
            this.lbl_sel_cap.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lbl_sel_cap.ThemeName = "Office2010Silver";
            // 
            // radLabel11
            // 
            this.radLabel11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel11.Location = new System.Drawing.Point(355, 286);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(301, 18);
            this.radLabel11.TabIndex = 72;
            this.radLabel11.Text = "جمع امتیاز تشویقی دریافتی از نوع انتخابی در سال جاری:";
            this.radLabel11.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel11.ThemeName = "Office2010Silver";
            // 
            // radLabel12
            // 
            this.radLabel12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel12.Location = new System.Drawing.Point(221, 143);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(110, 18);
            this.radLabel12.TabIndex = 73;
            this.radLabel12.Text = "میزان امتیاز اعطائی:";
            this.radLabel12.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel12.ThemeName = "Office2010Silver";
            // 
            // given_scr
            // 
            this.given_scr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.given_scr.Location = new System.Drawing.Point(153, 141);
            this.given_scr.Name = "given_scr";
            this.given_scr.Size = new System.Drawing.Size(62, 20);
            this.given_scr.TabIndex = 85;
            this.given_scr.ThemeName = "Office2010Silver";
            // 
            // radLabel13
            // 
            this.radLabel13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel13.Location = new System.Drawing.Point(403, 252);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(253, 18);
            this.radLabel13.TabIndex = 68;
            this.radLabel13.Text = "سقف امتیاز تشویقی سالانه از نوع انتخاب شده:";
            this.radLabel13.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel13.ThemeName = "Office2010Silver";
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(434, 185);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(222, 18);
            this.radLabel9.TabIndex = 70;
            this.radLabel9.Text = "سقف مجاز مجموع امتیاز تشویقی سالانه:";
            this.radLabel9.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel9.ThemeName = "Office2010Silver";
            // 
            // grid
            // 
            this.grid.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grid.Location = new System.Drawing.Point(12, 310);
            // 
            // 
            // 
            this.grid.MasterTemplate.AllowAddNewRow = false;
            this.grid.MasterTemplate.AllowColumnReorder = false;
            this.grid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grid.MasterTemplate.EnableSorting = false;
            this.grid.MasterTemplate.ShowFilteringRow = false;
            this.grid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.ShowGroupPanel = false;
            this.grid.ShowNoDataText = false;
            this.grid.Size = new System.Drawing.Size(644, 277);
            this.grid.TabIndex = 86;
            this.grid.Text = "radGridView1";
            this.grid.ThemeName = "Office2010Silver";
            // 
            // lbl_rec_sel
            // 
            this.lbl_rec_sel.AutoSize = false;
            this.lbl_rec_sel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rec_sel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_rec_sel.Location = new System.Drawing.Point(241, 286);
            this.lbl_rec_sel.Name = "lbl_rec_sel";
            this.lbl_rec_sel.Size = new System.Drawing.Size(108, 18);
            this.lbl_rec_sel.TabIndex = 72;
            this.lbl_rec_sel.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lbl_rec_sel.ThemeName = "Office2010Silver";
            // 
            // lbl_cur_scr
            // 
            this.lbl_cur_scr.AutoSize = false;
            this.lbl_cur_scr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cur_scr.ForeColor = System.Drawing.Color.Red;
            this.lbl_cur_scr.Location = new System.Drawing.Point(12, 286);
            this.lbl_cur_scr.Name = "lbl_cur_scr";
            this.lbl_cur_scr.Size = new System.Drawing.Size(90, 18);
            this.lbl_cur_scr.TabIndex = 70;
            this.lbl_cur_scr.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lbl_cur_scr.ThemeName = "Office2010Silver";
            // 
            // radLabel15
            // 
            this.radLabel15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel15.Location = new System.Drawing.Point(108, 286);
            this.radLabel15.Name = "radLabel15";
            this.radLabel15.Size = new System.Drawing.Size(121, 18);
            this.radLabel15.TabIndex = 69;
            this.radLabel15.Text = "مجموع امتیازات فعلی:";
            this.radLabel15.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel15.ThemeName = "Office2010Silver";
            // 
            // SCR_MNG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 599);
            this.Controls.Add(this.lbl_cur_scr);
            this.Controls.Add(this.lbl_rec_sel);
            this.Controls.Add(this.radLabel15);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.radLabel13);
            this.Controls.Add(this.given_scr);
            this.Controls.Add(this.radLabel12);
            this.Controls.Add(this.lbl_sel_cap);
            this.Controls.Add(this.lbl_tot_cap);
            this.Controls.Add(this.radLabel11);
            this.Controls.Add(this.SCR_Type);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.radLabel21);
            this.Controls.Add(this.Per_Dep);
            this.Controls.Add(this.lbl_rec_tot);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.lbl_pic);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.Per_Pic);
            this.Controls.Add(this.Per_Nk_Name);
            this.Controls.Add(this.Per_Fa_Name);
            this.Controls.Add(this.Per_Name);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "SCR_MNG";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowItemToolTips = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت امتیاز تشویقی مقام مافوق";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.SCR_MNG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Fa_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Nk_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_rec_tot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Dep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_tot_cap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_sel_cap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.given_scr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_rec_sel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_cur_scr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem Save;
        private Telerik.WinControls.UI.RadMenuItem Print;
        private Telerik.WinControls.UI.RadMenuItem Exit;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel Per_Name;
        private Telerik.WinControls.UI.RadLabel Per_Fa_Name;
        private Telerik.WinControls.UI.RadLabel Per_Nk_Name;
        private Telerik.WinControls.UI.RadLabel lbl_rec_tot;
        private Telerik.WinControls.UI.RadLabel lbl_pic;
        private System.Windows.Forms.PictureBox Per_Pic;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel Per_Dep;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private System.Windows.Forms.ComboBox SCR_Type;
        private Telerik.WinControls.UI.RadLabel radLabel21;
        private Telerik.WinControls.UI.RadLabel lbl_tot_cap;
        private Telerik.WinControls.UI.RadLabel lbl_sel_cap;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        private Telerik.WinControls.UI.RadTextBox given_scr;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadGridView grid;
        private Telerik.WinControls.UI.RadLabel lbl_rec_sel;
        private Telerik.WinControls.UI.RadLabel lbl_cur_scr;
        private Telerik.WinControls.UI.RadLabel radLabel15;
    }
}
