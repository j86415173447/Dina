namespace SnappFood_Employee_Evaluation.Personel
{
    partial class Search_Staff_Termination
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
            this.Per_Name = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.Per_Ntl_ID = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.Per_Cd = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.Search_Btn = new Telerik.WinControls.UI.RadButton();
            this.Doc_No = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Ntl_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Cd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Doc_No)).BeginInit();
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
            // Per_Name
            // 
            this.Per_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Name.Location = new System.Drawing.Point(69, 12);
            this.Per_Name.Name = "Per_Name";
            this.Per_Name.Size = new System.Drawing.Size(123, 20);
            this.Per_Name.TabIndex = 56;
            this.Per_Name.ThemeName = "Office2010Silver";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(198, 13);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(104, 18);
            this.radLabel8.TabIndex = 57;
            this.radLabel8.Text = "نام و نام خانوادگی:";
            this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel8.ThemeName = "Office2010Silver";
            // 
            // Per_Ntl_ID
            // 
            this.Per_Ntl_ID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Ntl_ID.Location = new System.Drawing.Point(308, 12);
            this.Per_Ntl_ID.Name = "Per_Ntl_ID";
            this.Per_Ntl_ID.Size = new System.Drawing.Size(123, 20);
            this.Per_Ntl_ID.TabIndex = 59;
            this.Per_Ntl_ID.ThemeName = "Office2010Silver";
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(441, 13);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(50, 18);
            this.radLabel7.TabIndex = 60;
            this.radLabel7.Text = "کد ملی:";
            this.radLabel7.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel7.ThemeName = "Office2010Silver";
            // 
            // Per_Cd
            // 
            this.Per_Cd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Per_Cd.Location = new System.Drawing.Point(308, 44);
            this.Per_Cd.Name = "Per_Cd";
            this.Per_Cd.Size = new System.Drawing.Size(68, 20);
            this.Per_Cd.TabIndex = 61;
            this.Per_Cd.ThemeName = "Office2010Silver";
            // 
            // radLabel10
            // 
            this.radLabel10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel10.Location = new System.Drawing.Point(382, 45);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(109, 18);
            this.radLabel10.TabIndex = 62;
            this.radLabel10.Text = "کد پرسنلی شرکت:";
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
            // Doc_No
            // 
            this.Doc_No.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Doc_No.Location = new System.Drawing.Point(69, 44);
            this.Doc_No.Name = "Doc_No";
            this.Doc_No.Size = new System.Drawing.Size(149, 20);
            this.Doc_No.TabIndex = 77;
            this.Doc_No.ThemeName = "Office2010Silver";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(224, 45);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(78, 18);
            this.radLabel1.TabIndex = 78;
            this.radLabel1.Text = "شماره پرونده:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel1.ThemeName = "Office2010Silver";
            // 
            // Search_Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 353);
            this.Controls.Add(this.Doc_No);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.Search_Btn);
            this.Controls.Add(this.Per_Cd);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.Per_Name);
            this.Controls.Add(this.radLabel10);
            this.Controls.Add(this.Per_Ntl_ID);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "Search_Staff";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جستجوی پرسنل";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.Search_Staff_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_Staff_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Ntl_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Per_Cd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Doc_No)).EndInit();
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
        private Telerik.WinControls.UI.RadTextBox Per_Name;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadTextBox Per_Ntl_ID;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadTextBox Per_Cd;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadButton Search_Btn;
        private Telerik.WinControls.UI.RadTextBox Doc_No;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
