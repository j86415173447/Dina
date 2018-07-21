namespace SnappFood_Employee_Evaluation.Personel
{
    partial class PER_TERMINATION_REPORT
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.emp_to_dt = new System.Windows.Forms.MaskedTextBox();
            this.emp_from_dt = new System.Windows.Forms.MaskedTextBox();
            this.job_level = new System.Windows.Forms.ComboBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel24 = new Telerik.WinControls.UI.RadLabel();
            this.Main_Shift = new System.Windows.Forms.ComboBox();
            this.Per_Dep = new System.Windows.Forms.ComboBox();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.grid = new Telerik.WinControls.UI.RadGridView();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.Print = new Telerik.WinControls.UI.RadMenuItem();
            this.Exit = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.radGroupBox1.Controls.Add(this.emp_to_dt);
            this.radGroupBox1.Controls.Add(this.emp_from_dt);
            this.radGroupBox1.Controls.Add(this.job_level);
            this.radGroupBox1.Controls.Add(this.radLabel5);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.radLabel24);
            this.radGroupBox1.Controls.Add(this.Main_Shift);
            this.radGroupBox1.Controls.Add(this.Per_Dep);
            this.radGroupBox1.Controls.Add(this.radLabel9);
            this.radGroupBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radGroupBox1.HeaderText = "محدوده گزارش";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 65);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1056, 68);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.Text = "محدوده گزارش";
            this.radGroupBox1.ThemeName = "Office2010Silver";
            // 
            // emp_to_dt
            // 
            this.emp_to_dt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.emp_to_dt.BackColor = System.Drawing.Color.LavenderBlush;
            this.emp_to_dt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emp_to_dt.Location = new System.Drawing.Point(17, 27);
            this.emp_to_dt.Mask = "0000/00/00";
            this.emp_to_dt.Name = "emp_to_dt";
            this.emp_to_dt.Size = new System.Drawing.Size(81, 20);
            this.emp_to_dt.TabIndex = 103;
            // 
            // emp_from_dt
            // 
            this.emp_from_dt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.emp_from_dt.BackColor = System.Drawing.Color.LavenderBlush;
            this.emp_from_dt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emp_from_dt.Location = new System.Drawing.Point(132, 27);
            this.emp_from_dt.Mask = "0000/00/00";
            this.emp_from_dt.Name = "emp_from_dt";
            this.emp_from_dt.Size = new System.Drawing.Size(81, 20);
            this.emp_from_dt.TabIndex = 102;
            // 
            // job_level
            // 
            this.job_level.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.job_level.BackColor = System.Drawing.Color.LavenderBlush;
            this.job_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.job_level.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.job_level.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.job_level.FormattingEnabled = true;
            this.job_level.Items.AddRange(new object[] {
            "",
            "روز",
            "شب"});
            this.job_level.Location = new System.Drawing.Point(330, 27);
            this.job_level.Name = "job_level";
            this.job_level.Size = new System.Drawing.Size(147, 22);
            this.job_level.TabIndex = 69;
            // 
            // radLabel5
            // 
            this.radLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(483, 30);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(75, 18);
            this.radLabel5.TabIndex = 60;
            this.radLabel5.Text = "طبقه شغلی:";
            this.radLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel5.ThemeName = "Office2010Silver";
            // 
            // radLabel4
            // 
            this.radLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(104, 30);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(19, 18);
            this.radLabel4.TabIndex = 60;
            this.radLabel4.Text = " - ";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel4.ThemeName = "Office2010Silver";
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(219, 30);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(105, 18);
            this.radLabel3.TabIndex = 59;
            this.radLabel3.Text = "تاریخ قطع همکاری:";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel3.ThemeName = "Office2010Silver";
            // 
            // radLabel24
            // 
            this.radLabel24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel24.Location = new System.Drawing.Point(717, 30);
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
            this.Main_Shift.Location = new System.Drawing.Point(564, 27);
            this.Main_Shift.Name = "Main_Shift";
            this.Main_Shift.Size = new System.Drawing.Size(147, 22);
            this.Main_Shift.TabIndex = 61;
            this.Main_Shift.SelectedIndexChanged += new System.EventHandler(this.Per_Dep_SelectedIndexChanged);
            // 
            // Per_Dep
            // 
            this.Per_Dep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Per_Dep.BackColor = System.Drawing.Color.LavenderBlush;
            this.Per_Dep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Per_Dep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Per_Dep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Dep.FormattingEnabled = true;
            this.Per_Dep.Location = new System.Drawing.Point(801, 27);
            this.Per_Dep.Name = "Per_Dep";
            this.Per_Dep.Size = new System.Drawing.Size(147, 22);
            this.Per_Dep.TabIndex = 56;
            this.Per_Dep.SelectedIndexChanged += new System.EventHandler(this.Per_Dep_SelectedIndexChanged);
            // 
            // radLabel9
            // 
            this.radLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(954, 30);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(84, 18);
            this.radLabel9.TabIndex = 58;
            this.radLabel9.Text = "واحد سازمانی:";
            this.radLabel9.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel9.ThemeName = "Office2010Silver";
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grid.Location = new System.Drawing.Point(12, 139);
            // 
            // 
            // 
            this.grid.MasterTemplate.AllowAddNewRow = false;
            this.grid.MasterTemplate.AllowColumnReorder = false;
            this.grid.MasterTemplate.ShowFilteringRow = false;
            this.grid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.ShowGroupPanel = false;
            this.grid.ShowGroupPanelScrollbars = false;
            this.grid.ShowNoDataText = false;
            this.grid.Size = new System.Drawing.Size(1056, 475);
            this.grid.TabIndex = 65;
            this.grid.Text = "radGridView1";
            this.grid.ThemeName = "Office2010Silver";
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
            this.radMenu1.Size = new System.Drawing.Size(1080, 59);
            this.radMenu1.TabIndex = 66;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "Office2010Silver";
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
            this.Print.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.Excel_icon1;
            this.Print.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Print.Name = "Print";
            this.Print.Text = "خروجی اکسل";
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
            // PER_TERMINATION_REPORT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 626);
            this.Controls.Add(this.radMenu1);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "PER_TERMINATION_REPORT";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش عمومی پرسنل";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.PER_GENERAL_REPORT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel24;
        private System.Windows.Forms.ComboBox Main_Shift;
        private System.Windows.Forms.ComboBox Per_Dep;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadGridView grid;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem Save;
        private Telerik.WinControls.UI.RadMenuItem Print;
        private Telerik.WinControls.UI.RadMenuItem Exit;
        private System.Windows.Forms.ComboBox job_level;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.MaskedTextBox emp_to_dt;
        private System.Windows.Forms.MaskedTextBox emp_from_dt;
    }
}
