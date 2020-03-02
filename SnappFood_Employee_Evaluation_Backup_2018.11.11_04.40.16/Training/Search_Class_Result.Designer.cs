namespace SnappFood_Employee_Evaluation.Training
{
    partial class Search_Class_Result
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
            this.grid = new Telerik.WinControls.UI.RadGridView();
            this.CRS_NM = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.Search_Btn = new Telerik.WinControls.UI.RadButton();
            this.Trainer = new System.Windows.Forms.ComboBox();
            this.radLabel32 = new Telerik.WinControls.UI.RadLabel();
            this.CLS_CD = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLS_CD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
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
            this.grid.Location = new System.Drawing.Point(12, 69);
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
            this.grid.Size = new System.Drawing.Size(479, 272);
            this.grid.TabIndex = 2;
            this.grid.Text = "radGridView1";
            this.grid.ThemeName = "Office2010Silver";
            this.grid.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // CRS_NM
            // 
            this.CRS_NM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CRS_NM.Location = new System.Drawing.Point(257, 11);
            this.CRS_NM.Name = "CRS_NM";
            this.CRS_NM.Size = new System.Drawing.Size(178, 20);
            this.CRS_NM.TabIndex = 65;
            this.CRS_NM.ThemeName = "Office2010Silver";
            // 
            // radLabel10
            // 
            this.radLabel10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel10.Location = new System.Drawing.Point(441, 12);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(50, 18);
            this.radLabel10.TabIndex = 66;
            this.radLabel10.Text = "نام دوره:";
            this.radLabel10.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel10.ThemeName = "Office2010Silver";
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radCheckBox1.Location = new System.Drawing.Point(124, 13);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radCheckBox1.Size = new System.Drawing.Size(96, 17);
            this.radCheckBox1.TabIndex = 67;
            this.radCheckBox1.Text = "کلاس های فعال";
            // 
            // Search_Btn
            // 
            this.Search_Btn.BackColor = System.Drawing.Color.LavenderBlush;
            this.Search_Btn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_Btn.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.search_icon;
            this.Search_Btn.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Search_Btn.Location = new System.Drawing.Point(12, 12);
            this.Search_Btn.Name = "Search_Btn";
            this.Search_Btn.Size = new System.Drawing.Size(51, 51);
            this.Search_Btn.TabIndex = 77;
            this.Search_Btn.ThemeName = "Office2010Silver";
            this.Search_Btn.Click += new System.EventHandler(this.Search_Btn_Click);
            // 
            // Trainer
            // 
            this.Trainer.BackColor = System.Drawing.Color.LavenderBlush;
            this.Trainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Trainer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Trainer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Trainer.FormattingEnabled = true;
            this.Trainer.Items.AddRange(new object[] {
            "",
            "روز",
            "شب"});
            this.Trainer.Location = new System.Drawing.Point(257, 41);
            this.Trainer.Name = "Trainer";
            this.Trainer.Size = new System.Drawing.Size(166, 22);
            this.Trainer.TabIndex = 95;
            // 
            // radLabel32
            // 
            this.radLabel32.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel32.Location = new System.Drawing.Point(429, 44);
            this.radLabel32.Name = "radLabel32";
            this.radLabel32.Size = new System.Drawing.Size(62, 18);
            this.radLabel32.TabIndex = 96;
            this.radLabel32.Text = "نام مدرس:";
            this.radLabel32.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel32.ThemeName = "Office2010Silver";
            // 
            // CLS_CD
            // 
            this.CLS_CD.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLS_CD.Location = new System.Drawing.Point(69, 42);
            this.CLS_CD.Name = "CLS_CD";
            this.CLS_CD.Size = new System.Drawing.Size(119, 20);
            this.CLS_CD.TabIndex = 67;
            this.CLS_CD.ThemeName = "Office2010Silver";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(194, 44);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(57, 18);
            this.radLabel1.TabIndex = 68;
            this.radLabel1.Text = "کد کلاس:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel1.ThemeName = "Office2010Silver";
            // 
            // Search_Class_Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 353);
            this.Controls.Add(this.CLS_CD);
            this.Controls.Add(this.Trainer);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel32);
            this.Controls.Add(this.Search_Btn);
            this.Controls.Add(this.radCheckBox1);
            this.Controls.Add(this.CRS_NM);
            this.Controls.Add(this.radLabel10);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "Search_Class_Result";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست کلاس های فعال";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.Search_Staff_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_Class_Result_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLS_CD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadGridView grid;
        private Telerik.WinControls.UI.RadTextBox CRS_NM;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
        private Telerik.WinControls.UI.RadButton Search_Btn;
        private System.Windows.Forms.ComboBox Trainer;
        private Telerik.WinControls.UI.RadLabel radLabel32;
        private Telerik.WinControls.UI.RadTextBox CLS_CD;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
