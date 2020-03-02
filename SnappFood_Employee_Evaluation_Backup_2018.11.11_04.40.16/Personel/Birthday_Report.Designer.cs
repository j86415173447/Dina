namespace SnappFood_Employee_Evaluation.Personel
{
    partial class Birthday_Report
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.Print = new Telerik.WinControls.UI.RadMenuItem();
            this.Exit = new Telerik.WinControls.UI.RadMenuItem();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.date_in = new System.Windows.Forms.MaskedTextBox();
            this.radLabel24 = new Telerik.WinControls.UI.RadLabel();
            this.Main_Shift = new System.Windows.Forms.ComboBox();
            this.month = new System.Windows.Forms.ComboBox();
            this.Per_Dep = new System.Windows.Forms.ComboBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.grid = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.search_icon;
            this.Save.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Save.Name = "Save";
            this.Save.Text = "  جستجو  ";
            this.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Save.UseCompatibleTextRendering = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Print
            // 
            this.Print.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.print_icon;
            this.Print.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Print.Name = "Print";
            this.Print.Text = "چاپ لیست";
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
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.date_in);
            this.radGroupBox1.Controls.Add(this.radLabel24);
            this.radGroupBox1.Controls.Add(this.Main_Shift);
            this.radGroupBox1.Controls.Add(this.month);
            this.radGroupBox1.Controls.Add(this.Per_Dep);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.radLabel9);
            this.radGroupBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radGroupBox1.HeaderText = "محدوده گزارش";
            this.radGroupBox1.Location = new System.Drawing.Point(13, 59);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(776, 78);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "محدوده گزارش";
            this.radGroupBox1.ThemeName = "Office2010Silver";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(266, 34);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(104, 18);
            this.radLabel2.TabIndex = 59;
            this.radLabel2.Text = "تا تاریخ (استخدام):";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel2.ThemeName = "Office2010Silver";
            // 
            // date_in
            // 
            this.date_in.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.date_in.Location = new System.Drawing.Point(179, 31);
            this.date_in.Mask = "0000/00/00";
            this.date_in.Name = "date_in";
            this.date_in.Size = new System.Drawing.Size(81, 20);
            this.date_in.TabIndex = 102;
            // 
            // radLabel24
            // 
            this.radLabel24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel24.Location = new System.Drawing.Point(92, 34);
            this.radLabel24.Name = "radLabel24";
            this.radLabel24.Size = new System.Drawing.Size(78, 18);
            this.radLabel24.TabIndex = 62;
            this.radLabel24.Text = "شیفت اصلی:";
            this.radLabel24.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel24.ThemeName = "Office2010Silver";
            // 
            // Main_Shift
            // 
            this.Main_Shift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_Shift.BackColor = System.Drawing.Color.LavenderBlush;
            this.Main_Shift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Main_Shift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Main_Shift.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Main_Shift.FormattingEnabled = true;
            this.Main_Shift.Items.AddRange(new object[] {
            "",
            "روز",
            "شب"});
            this.Main_Shift.Location = new System.Drawing.Point(16, 31);
            this.Main_Shift.Name = "Main_Shift";
            this.Main_Shift.Size = new System.Drawing.Size(70, 22);
            this.Main_Shift.TabIndex = 61;
            this.Main_Shift.SelectedIndexChanged += new System.EventHandler(this.month_SelectedIndexChanged);
            // 
            // month
            // 
            this.month.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.month.BackColor = System.Drawing.Color.LavenderBlush;
            this.month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.month.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.month.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.month.FormattingEnabled = true;
            this.month.Items.AddRange(new object[] {
            "",
            "فروردین",
            "اردیبهشت",
            "خرداد",
            "تیر",
            "مرداد",
            "شهریور",
            "مهر",
            "آبان",
            "آذر",
            "دی",
            "بهمن",
            "اسفند"});
            this.month.Location = new System.Drawing.Point(592, 31);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(119, 22);
            this.month.TabIndex = 59;
            this.month.SelectedIndexChanged += new System.EventHandler(this.month_SelectedIndexChanged);
            // 
            // Per_Dep
            // 
            this.Per_Dep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Per_Dep.BackColor = System.Drawing.Color.LavenderBlush;
            this.Per_Dep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Per_Dep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Per_Dep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Dep.FormattingEnabled = true;
            this.Per_Dep.Location = new System.Drawing.Point(379, 31);
            this.Per_Dep.Name = "Per_Dep";
            this.Per_Dep.Size = new System.Drawing.Size(117, 22);
            this.Per_Dep.TabIndex = 56;
            this.Per_Dep.SelectedIndexChanged += new System.EventHandler(this.month_SelectedIndexChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(714, 34);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(50, 18);
            this.radLabel1.TabIndex = 60;
            this.radLabel1.Text = "ماه تولد:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel1.ThemeName = "Office2010Silver";
            // 
            // radLabel9
            // 
            this.radLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(502, 34);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(84, 18);
            this.radLabel9.TabIndex = 58;
            this.radLabel9.Text = "واحد سازمانی:";
            this.radLabel9.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel9.ThemeName = "Office2010Silver";
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
            this.radMenu1.Size = new System.Drawing.Size(800, 53);
            this.radMenu1.TabIndex = 1;
            this.radMenu1.ThemeName = "Office2010Silver";
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grid.Location = new System.Drawing.Point(13, 143);
            // 
            // 
            // 
            this.grid.MasterTemplate.AllowAddNewRow = false;
            this.grid.MasterTemplate.AllowColumnReorder = false;
            this.grid.MasterTemplate.ShowFilteringRow = false;
            this.grid.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.ShowGroupPanel = false;
            this.grid.ShowGroupPanelScrollbars = false;
            this.grid.ShowNoDataText = false;
            this.grid.Size = new System.Drawing.Size(775, 399);
            this.grid.TabIndex = 64;
            this.grid.ThemeName = "Office2010Silver";
            // 
            // Birthday_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 554);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "Birthday_Report";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش تولد پرسنل (ماهانه)";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.Birthday_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.UI.RadMenuItem Save;
        private Telerik.WinControls.UI.RadMenuItem Print;
        private Telerik.WinControls.UI.RadMenuItem Exit;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.ComboBox month;
        private System.Windows.Forms.ComboBox Per_Dep;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadLabel radLabel24;
        private System.Windows.Forms.ComboBox Main_Shift;
        private Telerik.WinControls.UI.RadGridView grid;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.MaskedTextBox date_in;
    }
}
