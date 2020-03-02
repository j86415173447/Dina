namespace SnappFood_Employee_Evaluation.QC
{
    partial class RPT_COOR_DETAIL
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
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.Print = new Telerik.WinControls.UI.RadMenuItem();
            this.Exit = new Telerik.WinControls.UI.RadMenuItem();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.Log_Status = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dt_to = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dt_from = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.Taboo = new System.Windows.Forms.CheckBox();
            this.no_fwl = new System.Windows.Forms.CheckBox();
            this.bad_fwl = new System.Windows.Forms.CheckBox();
            this.QC_Agent = new System.Windows.Forms.ComboBox();
            this.Call_Type = new System.Windows.Forms.ComboBox();
            this.Per_Dep = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_to)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.radMenu1.Size = new System.Drawing.Size(1218, 59);
            this.radMenu1.TabIndex = 67;
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
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.bad_fwl);
            this.radGroupBox1.Controls.Add(this.no_fwl);
            this.radGroupBox1.Controls.Add(this.Log_Status);
            this.radGroupBox1.Controls.Add(this.label5);
            this.radGroupBox1.Controls.Add(this.Taboo);
            this.radGroupBox1.Controls.Add(this.Per_Dep);
            this.radGroupBox1.Controls.Add(this.QC_Agent);
            this.radGroupBox1.Controls.Add(this.dt_to);
            this.radGroupBox1.Controls.Add(this.dt_from);
            this.radGroupBox1.Controls.Add(this.Call_Type);
            this.radGroupBox1.Controls.Add(this.label4);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radGroupBox1.HeaderText = "     پنل جستجو     ";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 65);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1194, 67);
            this.radGroupBox1.TabIndex = 68;
            this.radGroupBox1.Text = "     پنل جستجو     ";
            this.radGroupBox1.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Standard;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.LavenderBlush;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            // 
            // Log_Status
            // 
            this.Log_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Log_Status.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Log_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Log_Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Log_Status.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Log_Status.FormattingEnabled = true;
            this.Log_Status.Location = new System.Drawing.Point(572, 28);
            this.Log_Status.Name = "Log_Status";
            this.Log_Status.Size = new System.Drawing.Size(169, 21);
            this.Log_Status.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(747, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "وضعیت لاگ:";
            // 
            // dt_to
            // 
            this.dt_to.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_to.AutoSize = false;
            this.dt_to.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dt_to.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.dt_to.CustomFormat = "yyyy/MM/dd";
            this.dt_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_to.Location = new System.Drawing.Point(818, 27);
            this.dt_to.Name = "dt_to";
            this.dt_to.Size = new System.Drawing.Size(115, 21);
            this.dt_to.TabIndex = 28;
            this.dt_to.TabStop = false;
            this.dt_to.ThemeName = "Office2010Silver";
            this.dt_to.Value = new System.DateTime(((long)(0)));
            // 
            // dt_from
            // 
            this.dt_from.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_from.AutoSize = false;
            this.dt_from.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dt_from.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.dt_from.CustomFormat = "yyyy/MM/dd";
            this.dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_from.Location = new System.Drawing.Point(962, 27);
            this.dt_from.Name = "dt_from";
            this.dt_from.Size = new System.Drawing.Size(115, 21);
            this.dt_from.TabIndex = 27;
            this.dt_from.TabStop = false;
            this.dt_from.ThemeName = "Office2010Silver";
            this.dt_from.Value = new System.DateTime(((long)(0)));
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(939, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "تا:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(1083, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "تاریخ بررسی لاگ از:";
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radGridView1.Location = new System.Drawing.Point(12, 138);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.ShowFilteringRow = false;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.ShowGroupPanelScrollbars = false;
            this.radGridView1.ShowNoDataText = false;
            this.radGridView1.Size = new System.Drawing.Size(1194, 542);
            this.radGridView1.TabIndex = 69;
            this.radGridView1.ThemeName = "Office2010Silver";
            this.radGridView1.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellDoubleClick);
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // Taboo
            // 
            this.Taboo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Taboo.AutoSize = true;
            this.Taboo.BackColor = System.Drawing.Color.MistyRose;
            this.Taboo.Location = new System.Drawing.Point(461, 31);
            this.Taboo.Name = "Taboo";
            this.Taboo.Size = new System.Drawing.Size(90, 17);
            this.Taboo.TabIndex = 24;
            this.Taboo.Text = "مکالمات تابو";
            this.Taboo.UseVisualStyleBackColor = false;
            this.Taboo.Visible = false;
            // 
            // no_fwl
            // 
            this.no_fwl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.no_fwl.AutoSize = true;
            this.no_fwl.BackColor = System.Drawing.Color.MistyRose;
            this.no_fwl.Location = new System.Drawing.Point(354, 31);
            this.no_fwl.Name = "no_fwl";
            this.no_fwl.Size = new System.Drawing.Size(85, 17);
            this.no_fwl.TabIndex = 33;
            this.no_fwl.Text = "عدم پیگیری";
            this.no_fwl.UseVisualStyleBackColor = false;
            this.no_fwl.Visible = false;
            // 
            // bad_fwl
            // 
            this.bad_fwl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bad_fwl.AutoSize = true;
            this.bad_fwl.BackColor = System.Drawing.Color.MistyRose;
            this.bad_fwl.Location = new System.Drawing.Point(237, 31);
            this.bad_fwl.Name = "bad_fwl";
            this.bad_fwl.Size = new System.Drawing.Size(95, 17);
            this.bad_fwl.TabIndex = 34;
            this.bad_fwl.Text = "پیگیری ناقص";
            this.bad_fwl.UseVisualStyleBackColor = false;
            this.bad_fwl.Visible = false;
            // 
            // QC_Agent
            // 
            this.QC_Agent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QC_Agent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.QC_Agent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QC_Agent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QC_Agent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.QC_Agent.FormattingEnabled = true;
            this.QC_Agent.Location = new System.Drawing.Point(8, 28);
            this.QC_Agent.Name = "QC_Agent";
            this.QC_Agent.Size = new System.Drawing.Size(61, 21);
            this.QC_Agent.TabIndex = 29;
            this.QC_Agent.Visible = false;
            // 
            // Call_Type
            // 
            this.Call_Type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Call_Type.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Call_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Call_Type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Call_Type.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Call_Type.FormattingEnabled = true;
            this.Call_Type.Location = new System.Drawing.Point(75, 28);
            this.Call_Type.Name = "Call_Type";
            this.Call_Type.Size = new System.Drawing.Size(67, 21);
            this.Call_Type.TabIndex = 26;
            this.Call_Type.Visible = false;
            // 
            // Per_Dep
            // 
            this.Per_Dep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Per_Dep.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Per_Dep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Per_Dep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Per_Dep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Per_Dep.FormattingEnabled = true;
            this.Per_Dep.Location = new System.Drawing.Point(148, 29);
            this.Per_Dep.Name = "Per_Dep";
            this.Per_Dep.Size = new System.Drawing.Size(61, 21);
            this.Per_Dep.TabIndex = 30;
            this.Per_Dep.Visible = false;
            // 
            // RPT_COOR_DETAIL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 692);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.KeyPreview = true;
            this.Name = "RPT_COOR_DETAIL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جزئیات عملکرد سرگروه";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.QC_GENERAL_REPORT_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QC_GENERAL_REPORT_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_to)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem Save;
        private Telerik.WinControls.UI.RadMenuItem Print;
        private Telerik.WinControls.UI.RadMenuItem Exit;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDateTimePicker dt_to;
        private Telerik.WinControls.UI.RadDateTimePicker dt_from;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Windows.Forms.ComboBox Log_Status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox bad_fwl;
        private System.Windows.Forms.CheckBox no_fwl;
        private System.Windows.Forms.CheckBox Taboo;
        private System.Windows.Forms.ComboBox Per_Dep;
        private System.Windows.Forms.ComboBox QC_Agent;
        private System.Windows.Forms.ComboBox Call_Type;
    }
}
