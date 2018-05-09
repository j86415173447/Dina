namespace SnappFood_Employee_Evaluation.Training
{
    partial class Search_Course
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
            this.CRS_ID = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.CRS_NM = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.Search_Btn = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Btn)).BeginInit();
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
            this.grid.Location = new System.Drawing.Point(12, 76);
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
            this.grid.Size = new System.Drawing.Size(479, 265);
            this.grid.TabIndex = 2;
            this.grid.Text = "radGridView1";
            this.grid.ThemeName = "Office2010Silver";
            this.grid.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // CRS_ID
            // 
            this.CRS_ID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CRS_ID.Location = new System.Drawing.Point(309, 28);
            this.CRS_ID.Name = "CRS_ID";
            this.CRS_ID.Size = new System.Drawing.Size(123, 20);
            this.CRS_ID.TabIndex = 59;
            this.CRS_ID.ThemeName = "Office2010Silver";
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(442, 29);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(49, 18);
            this.radLabel7.TabIndex = 60;
            this.radLabel7.Text = "کد دوره:";
            this.radLabel7.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel7.ThemeName = "Office2010Silver";
            // 
            // CRS_NM
            // 
            this.CRS_NM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CRS_NM.Location = new System.Drawing.Point(69, 27);
            this.CRS_NM.Name = "CRS_NM";
            this.CRS_NM.Size = new System.Drawing.Size(178, 20);
            this.CRS_NM.TabIndex = 61;
            this.CRS_NM.ThemeName = "Office2010Silver";
            // 
            // radLabel10
            // 
            this.radLabel10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel10.Location = new System.Drawing.Point(253, 29);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(50, 18);
            this.radLabel10.TabIndex = 62;
            this.radLabel10.Text = "نام دوره:";
            this.radLabel10.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel10.ThemeName = "Office2010Silver";
            // 
            // Search_Btn
            // 
            this.Search_Btn.BackColor = System.Drawing.Color.LavenderBlush;
            this.Search_Btn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_Btn.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.search_icon;
            this.Search_Btn.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Search_Btn.Location = new System.Drawing.Point(12, 13);
            this.Search_Btn.Name = "Search_Btn";
            this.Search_Btn.Size = new System.Drawing.Size(51, 51);
            this.Search_Btn.TabIndex = 76;
            this.Search_Btn.ThemeName = "Office2010Silver";
            this.Search_Btn.Click += new System.EventHandler(this.Search_Btn_Click);
            // 
            // Search_Course
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 353);
            this.Controls.Add(this.Search_Btn);
            this.Controls.Add(this.CRS_NM);
            this.Controls.Add(this.radLabel10);
            this.Controls.Add(this.CRS_ID);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "Search_Course";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جستجوی دوره";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.Search_Staff_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_Staff_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadGridView grid;
        private Telerik.WinControls.UI.RadTextBox CRS_ID;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadTextBox CRS_NM;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadButton Search_Btn;
    }
}
