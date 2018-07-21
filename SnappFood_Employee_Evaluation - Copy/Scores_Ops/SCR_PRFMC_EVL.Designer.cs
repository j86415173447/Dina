namespace SnappFood_Employee_Evaluation.Scores_Ops
{
    partial class SCR_PRFMC_EVL
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.lbl_cur_scr = new Telerik.WinControls.UI.RadLabel();
            this.radLabel15 = new Telerik.WinControls.UI.RadLabel();
            this.grid = new Telerik.WinControls.UI.RadGridView();
            this.radLabel21 = new Telerik.WinControls.UI.RadLabel();
            this.Per_Dep = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.lbl_pic = new Telerik.WinControls.UI.RadLabel();
            this.Per_Nk_Name = new Telerik.WinControls.UI.RadLabel();
            this.Per_Fa_Name = new Telerik.WinControls.UI.RadLabel();
            this.Per_Name = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.Result = new System.Windows.Forms.ComboBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.Period = new Telerik.WinControls.UI.RadLabel();
            this.Per_Pic = new System.Windows.Forms.PictureBox();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.Print = new Telerik.WinControls.UI.RadMenuItem();
            this.Exit = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_cur_scr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Dep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Nk_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Fa_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Period)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // lbl_cur_scr
            // 
            this.lbl_cur_scr.AutoSize = false;
            this.lbl_cur_scr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cur_scr.ForeColor = System.Drawing.Color.Red;
            this.lbl_cur_scr.Location = new System.Drawing.Point(359, 220);
            this.lbl_cur_scr.Name = "lbl_cur_scr";
            this.lbl_cur_scr.Size = new System.Drawing.Size(170, 18);
            this.lbl_cur_scr.TabIndex = 100;
            this.lbl_cur_scr.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lbl_cur_scr.ThemeName = "Office2010Silver";
            // 
            // radLabel15
            // 
            this.radLabel15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel15.Location = new System.Drawing.Point(535, 219);
            this.radLabel15.Name = "radLabel15";
            this.radLabel15.Size = new System.Drawing.Size(121, 18);
            this.radLabel15.TabIndex = 97;
            this.radLabel15.Text = "مجموع امتیازات فعلی:";
            this.radLabel15.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel15.ThemeName = "Office2010Silver";
            // 
            // grid
            // 
            this.grid.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grid.Location = new System.Drawing.Point(12, 250);
            // 
            // 
            // 
            this.grid.MasterTemplate.AllowAddNewRow = false;
            this.grid.MasterTemplate.AllowColumnReorder = false;
            this.grid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grid.MasterTemplate.EnableSorting = false;
            this.grid.MasterTemplate.ShowFilteringRow = false;
            this.grid.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.ShowGroupPanel = false;
            this.grid.ShowNoDataText = false;
            this.grid.Size = new System.Drawing.Size(644, 306);
            this.grid.TabIndex = 112;
            this.grid.Text = "radGridView1";
            this.grid.ThemeName = "Office2010Silver";
            // 
            // radLabel21
            // 
            this.radLabel21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel21.Location = new System.Drawing.Point(585, 172);
            this.radLabel21.Name = "radLabel21";
            this.radLabel21.Size = new System.Drawing.Size(71, 18);
            this.radLabel21.TabIndex = 110;
            this.radLabel21.Text = "دوره ارزیابی:";
            this.radLabel21.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel21.ThemeName = "Office2010Silver";
            // 
            // Per_Dep
            // 
            this.Per_Dep.AutoSize = false;
            this.Per_Dep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Dep.Location = new System.Drawing.Point(391, 125);
            this.Per_Dep.Name = "Per_Dep";
            this.Per_Dep.Size = new System.Drawing.Size(175, 18);
            this.Per_Dep.TabIndex = 99;
            this.Per_Dep.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Per_Dep.ThemeName = "Office2010Silver";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(572, 125);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(84, 18);
            this.radLabel4.TabIndex = 95;
            this.radLabel4.Text = "واحد سازمانی:";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel4.ThemeName = "Office2010Silver";
            // 
            // lbl_pic
            // 
            this.lbl_pic.AutoSize = false;
            this.lbl_pic.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pic.Location = new System.Drawing.Point(12, 226);
            this.lbl_pic.Name = "lbl_pic";
            this.lbl_pic.Size = new System.Drawing.Size(120, 18);
            this.lbl_pic.TabIndex = 107;
            this.lbl_pic.Text = "عکس پرسنلی";
            this.lbl_pic.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lbl_pic.ThemeName = "Office2010Silver";
            // 
            // Per_Nk_Name
            // 
            this.Per_Nk_Name.AutoSize = false;
            this.Per_Nk_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Nk_Name.Location = new System.Drawing.Point(154, 125);
            this.Per_Nk_Name.Name = "Per_Nk_Name";
            this.Per_Nk_Name.Size = new System.Drawing.Size(140, 18);
            this.Per_Nk_Name.TabIndex = 94;
            this.Per_Nk_Name.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Per_Nk_Name.ThemeName = "Office2010Silver";
            // 
            // Per_Fa_Name
            // 
            this.Per_Fa_Name.AutoSize = false;
            this.Per_Fa_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Fa_Name.Location = new System.Drawing.Point(154, 78);
            this.Per_Fa_Name.Name = "Per_Fa_Name";
            this.Per_Fa_Name.Size = new System.Drawing.Size(163, 18);
            this.Per_Fa_Name.TabIndex = 92;
            this.Per_Fa_Name.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Per_Fa_Name.ThemeName = "Office2010Silver";
            // 
            // Per_Name
            // 
            this.Per_Name.AutoSize = false;
            this.Per_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Name.Location = new System.Drawing.Point(391, 78);
            this.Per_Name.Name = "Per_Name";
            this.Per_Name.Size = new System.Drawing.Size(154, 18);
            this.Per_Name.TabIndex = 90;
            this.Per_Name.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Per_Name.ThemeName = "Office2010Silver";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(300, 125);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(67, 18);
            this.radLabel6.TabIndex = 91;
            this.radLabel6.Text = "نام مستعار:";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel6.ThemeName = "Office2010Silver";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(323, 78);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(44, 18);
            this.radLabel5.TabIndex = 89;
            this.radLabel5.Text = "نام پدر:";
            this.radLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel5.ThemeName = "Office2010Silver";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(552, 78);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(104, 18);
            this.radLabel8.TabIndex = 88;
            this.radLabel8.Text = "نام و نام خانوادگی:";
            this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel8.ThemeName = "Office2010Silver";
            // 
            // Result
            // 
            this.Result.BackColor = System.Drawing.Color.LavenderBlush;
            this.Result.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Result.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.FormattingEnabled = true;
            this.Result.Location = new System.Drawing.Point(154, 169);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(140, 22);
            this.Result.TabIndex = 111;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(300, 172);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(77, 18);
            this.radLabel1.TabIndex = 112;
            this.radLabel1.Text = "نتیجه ارزیابی:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel1.ThemeName = "Office2010Silver";
            // 
            // Period
            // 
            this.Period.AutoSize = false;
            this.Period.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Period.ForeColor = System.Drawing.Color.Green;
            this.Period.Location = new System.Drawing.Point(391, 172);
            this.Period.Name = "Period";
            this.Period.Size = new System.Drawing.Size(188, 18);
            this.Period.TabIndex = 100;
            this.Period.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Period.ThemeName = "Office2010Silver";
            // 
            // Per_Pic
            // 
            this.Per_Pic.BackColor = System.Drawing.Color.LavenderBlush;
            this.Per_Pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Per_Pic.Location = new System.Drawing.Point(12, 74);
            this.Per_Pic.Name = "Per_Pic";
            this.Per_Pic.Size = new System.Drawing.Size(120, 160);
            this.Per_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Per_Pic.TabIndex = 108;
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
            this.radMenu1.TabIndex = 87;
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
            // SCR_PRFMC_EVL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 568);
            this.Controls.Add(this.Period);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.lbl_cur_scr);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel15);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.radLabel21);
            this.Controls.Add(this.Per_Dep);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.lbl_pic);
            this.Controls.Add(this.Per_Pic);
            this.Controls.Add(this.Per_Nk_Name);
            this.Controls.Add(this.Per_Fa_Name);
            this.Controls.Add(this.Per_Name);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "SCR_PRFMC_EVL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowItemToolTips = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "امتیاز عملکرد بلند مدت";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.SCR_PRFMC_EVL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lbl_cur_scr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Dep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Nk_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Fa_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Period)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadLabel lbl_cur_scr;
        private Telerik.WinControls.UI.RadLabel radLabel15;
        private Telerik.WinControls.UI.RadGridView grid;
        private Telerik.WinControls.UI.RadLabel radLabel21;
        private Telerik.WinControls.UI.RadLabel Per_Dep;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel lbl_pic;
        private System.Windows.Forms.PictureBox Per_Pic;
        private Telerik.WinControls.UI.RadLabel Per_Nk_Name;
        private Telerik.WinControls.UI.RadLabel Per_Fa_Name;
        private Telerik.WinControls.UI.RadLabel Per_Name;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadMenuItem Exit;
        private Telerik.WinControls.UI.RadMenuItem Print;
        private Telerik.WinControls.UI.RadMenuItem Save;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private System.Windows.Forms.ComboBox Result;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel Period;
    }
}
