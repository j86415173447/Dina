namespace SnappFood_Employee_Evaluation.Training
{
    partial class TRN_COURSE_MASTER
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
            this.grid = new Telerik.WinControls.UI.RadGridView();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.Exit = new Telerik.WinControls.UI.RadMenuItem();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.CRS_CD = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.CRS_NM = new Telerik.WinControls.UI.RadTextBox();
            this.Period = new Telerik.WinControls.UI.RadTextBox();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.CRS_Type = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_CD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Period)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // grid
            // 
            this.grid.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grid.Location = new System.Drawing.Point(12, 124);
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
            this.grid.Size = new System.Drawing.Size(584, 386);
            this.grid.TabIndex = 2;
            this.grid.Text = "radGridView1";
            this.grid.ThemeName = "Office2010Silver";
            this.grid.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // Save
            // 
            this.Save.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.save1;
            this.Save.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Save.Name = "Save";
            this.Save.Text = "افزودن/اصلاح";
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
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel1.Location = new System.Drawing.Point(552, 69);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(45, 17);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "کد دوره:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // CRS_CD
            // 
            this.CRS_CD.AutoSize = false;
            this.CRS_CD.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.CRS_CD.ForeColor = System.Drawing.Color.Maroon;
            this.CRS_CD.Location = new System.Drawing.Point(481, 62);
            this.CRS_CD.Name = "CRS_CD";
            this.CRS_CD.Size = new System.Drawing.Size(71, 27);
            this.CRS_CD.TabIndex = 5;
            this.CRS_CD.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel3.Location = new System.Drawing.Point(506, 101);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(90, 17);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "نام دوره آموزشی:";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel4.Location = new System.Drawing.Point(106, 69);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(54, 17);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "مدت دوره:";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel5.Location = new System.Drawing.Point(12, 69);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(38, 17);
            this.radLabel5.TabIndex = 7;
            this.radLabel5.Text = "ساعت";
            this.radLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // CRS_NM
            // 
            this.CRS_NM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CRS_NM.Location = new System.Drawing.Point(12, 98);
            this.CRS_NM.Name = "CRS_NM";
            this.CRS_NM.Size = new System.Drawing.Size(488, 20);
            this.CRS_NM.TabIndex = 8;
            this.CRS_NM.ThemeName = "Office2010Silver";
            // 
            // Period
            // 
            this.Period.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Period.Location = new System.Drawing.Point(56, 66);
            this.Period.Name = "Period";
            this.Period.Size = new System.Drawing.Size(44, 20);
            this.Period.TabIndex = 2;
            this.Period.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Period.ThemeName = "Office2010Silver";
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
            this.radMenu1.Size = new System.Drawing.Size(608, 53);
            this.radMenu1.TabIndex = 3;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "Office2010Silver";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel2.Location = new System.Drawing.Point(383, 69);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(92, 17);
            this.radLabel2.TabIndex = 9;
            this.radLabel2.Text = "نوع دوره آموزشی:";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // CRS_Type
            // 
            this.CRS_Type.BackColor = System.Drawing.Color.LavenderBlush;
            this.CRS_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CRS_Type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CRS_Type.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CRS_Type.FormattingEnabled = true;
            this.CRS_Type.Items.AddRange(new object[] {
            "",
            "روز",
            "شب"});
            this.CRS_Type.Location = new System.Drawing.Point(166, 66);
            this.CRS_Type.Name = "CRS_Type";
            this.CRS_Type.Size = new System.Drawing.Size(211, 22);
            this.CRS_Type.TabIndex = 94;
            // 
            // TRN_COURSE_MASTER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 522);
            this.Controls.Add(this.CRS_Type);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.Period);
            this.Controls.Add(this.CRS_NM);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.CRS_CD);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radMenu1);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "TRN_COURSE_MASTER";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ایجاد دوره آموزشی ضمن خدمت";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.TRN_COURSE_MASTER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_CD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Period)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadGridView grid;
        private Telerik.WinControls.UI.RadMenuItem Save;
        private Telerik.WinControls.UI.RadMenuItem Exit;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel CRS_CD;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox CRS_NM;
        private Telerik.WinControls.UI.RadTextBox Period;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.ComboBox CRS_Type;
    }
}
