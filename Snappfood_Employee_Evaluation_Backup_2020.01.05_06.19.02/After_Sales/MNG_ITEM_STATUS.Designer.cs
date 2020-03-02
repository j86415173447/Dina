namespace SnappFood_Employee_Evaluation.After_Sales
{
    partial class MNG_ITEM_STATUS
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
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.item_sn = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.latest_status_DT = new Telerik.WinControls.UI.RadLabel();
            this.latest_status = new Telerik.WinControls.UI.RadLabel();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.item_nature = new Telerik.WinControls.UI.RadLabel();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.position = new Telerik.WinControls.UI.RadLabel();
            this.org_desc = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.origin = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.item_grid = new Telerik.WinControls.UI.RadGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.item_sn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.latest_status_DT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.latest_status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_nature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.position)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.org_desc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.origin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_grid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // item_sn
            // 
            this.item_sn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.item_sn.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.item_sn.Location = new System.Drawing.Point(376, 19);
            this.item_sn.Name = "item_sn";
            this.item_sn.Size = new System.Drawing.Size(155, 19);
            this.item_sn.TabIndex = 3;
            this.item_sn.ThemeName = "Office2010Silver";
            this.item_sn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.item_sn_KeyPress);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel1.Location = new System.Drawing.Point(548, 21);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(59, 17);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "سریال کالا:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Controls.Add(this.latest_status_DT);
            this.radGroupBox4.Controls.Add(this.latest_status);
            this.radGroupBox4.Controls.Add(this.radLabel13);
            this.radGroupBox4.Controls.Add(this.item_nature);
            this.radGroupBox4.Controls.Add(this.radLabel11);
            this.radGroupBox4.Controls.Add(this.radLabel9);
            this.radGroupBox4.Controls.Add(this.position);
            this.radGroupBox4.Controls.Add(this.org_desc);
            this.radGroupBox4.Controls.Add(this.radLabel7);
            this.radGroupBox4.Controls.Add(this.origin);
            this.radGroupBox4.Controls.Add(this.radLabel4);
            this.radGroupBox4.Controls.Add(this.radLabel6);
            this.radGroupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radGroupBox4.HeaderText = "   خلاصه وضعیت   ";
            this.radGroupBox4.Location = new System.Drawing.Point(12, 55);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGroupBox4.Size = new System.Drawing.Size(595, 123);
            this.radGroupBox4.TabIndex = 18;
            this.radGroupBox4.Text = "   خلاصه وضعیت   ";
            this.radGroupBox4.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox4.GetChildAt(0).GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox4.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Standard;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox4.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox4.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.LavenderBlush;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox4.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox4.GetChildAt(0).GetChildAt(1).GetChildAt(1))).BackColor = System.Drawing.Color.Pink;
            // 
            // latest_status_DT
            // 
            this.latest_status_DT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.latest_status_DT.AutoSize = false;
            this.latest_status_DT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.latest_status_DT.ForeColor = System.Drawing.Color.MediumBlue;
            this.latest_status_DT.Location = new System.Drawing.Point(14, 88);
            this.latest_status_DT.Name = "latest_status_DT";
            this.latest_status_DT.Size = new System.Drawing.Size(209, 17);
            this.latest_status_DT.TabIndex = 24;
            this.latest_status_DT.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // latest_status
            // 
            this.latest_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.latest_status.AutoSize = false;
            this.latest_status.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.latest_status.ForeColor = System.Drawing.Color.MediumBlue;
            this.latest_status.Location = new System.Drawing.Point(14, 61);
            this.latest_status.Name = "latest_status";
            this.latest_status.Size = new System.Drawing.Size(234, 17);
            this.latest_status.TabIndex = 22;
            this.latest_status.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel13
            // 
            this.radLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel13.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel13.Location = new System.Drawing.Point(229, 88);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(99, 17);
            this.radLabel13.TabIndex = 23;
            this.radLabel13.Text = "تاریخ آخرین وضعیت:";
            this.radLabel13.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // item_nature
            // 
            this.item_nature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.item_nature.AutoSize = false;
            this.item_nature.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.item_nature.ForeColor = System.Drawing.Color.MediumBlue;
            this.item_nature.Location = new System.Drawing.Point(14, 34);
            this.item_nature.Name = "item_nature";
            this.item_nature.Size = new System.Drawing.Size(247, 17);
            this.item_nature.TabIndex = 20;
            this.item_nature.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel11
            // 
            this.radLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel11.Location = new System.Drawing.Point(254, 61);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(74, 17);
            this.radLabel11.TabIndex = 21;
            this.radLabel11.Text = "آخرین وضعیت:";
            this.radLabel11.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel9
            // 
            this.radLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel9.Location = new System.Drawing.Point(267, 34);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(61, 17);
            this.radLabel9.TabIndex = 19;
            this.radLabel9.Text = "ماهیت کالا:";
            this.radLabel9.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // position
            // 
            this.position.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.position.AutoSize = false;
            this.position.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.position.ForeColor = System.Drawing.Color.MediumBlue;
            this.position.Location = new System.Drawing.Point(334, 88);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(167, 17);
            this.position.TabIndex = 18;
            this.position.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // org_desc
            // 
            this.org_desc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.org_desc.AutoSize = false;
            this.org_desc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.org_desc.ForeColor = System.Drawing.Color.MediumBlue;
            this.org_desc.Location = new System.Drawing.Point(334, 61);
            this.org_desc.Name = "org_desc";
            this.org_desc.Size = new System.Drawing.Size(185, 17);
            this.org_desc.TabIndex = 16;
            this.org_desc.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel7
            // 
            this.radLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel7.Location = new System.Drawing.Point(507, 88);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(74, 17);
            this.radLabel7.TabIndex = 17;
            this.radLabel7.Text = "جایگاه دریافت:";
            this.radLabel7.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // origin
            // 
            this.origin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.origin.AutoSize = false;
            this.origin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.origin.ForeColor = System.Drawing.Color.MediumBlue;
            this.origin.Location = new System.Drawing.Point(334, 34);
            this.origin.Name = "origin";
            this.origin.Size = new System.Drawing.Size(130, 17);
            this.origin.TabIndex = 14;
            this.origin.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel4
            // 
            this.radLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel4.Location = new System.Drawing.Point(526, 61);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(55, 17);
            this.radLabel4.TabIndex = 15;
            this.radLabel4.Text = "شرح مبدا:";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel6
            // 
            this.radLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel6.Location = new System.Drawing.Point(470, 34);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(111, 17);
            this.radLabel6.TabIndex = 13;
            this.radLabel6.Text = "شناسه دریافت / مبدا:";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // item_grid
            // 
            this.item_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.item_grid.AutoSizeRows = true;
            this.item_grid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_grid.Location = new System.Drawing.Point(12, 184);
            // 
            // 
            // 
            this.item_grid.MasterTemplate.AllowAddNewRow = false;
            this.item_grid.MasterTemplate.AllowCellContextMenu = false;
            this.item_grid.MasterTemplate.AllowColumnChooser = false;
            this.item_grid.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.item_grid.MasterTemplate.AllowColumnReorder = false;
            this.item_grid.MasterTemplate.AllowColumnResize = false;
            this.item_grid.MasterTemplate.AllowDeleteRow = false;
            this.item_grid.MasterTemplate.AllowDragToGroup = false;
            this.item_grid.MasterTemplate.AllowEditRow = false;
            this.item_grid.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.item_grid.MasterTemplate.AllowRowResize = false;
            this.item_grid.MasterTemplate.ShowFilteringRow = false;
            this.item_grid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.item_grid.Name = "item_grid";
            this.item_grid.ReadOnly = true;
            this.item_grid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.item_grid.ShowGroupPanel = false;
            this.item_grid.ShowGroupPanelScrollbars = false;
            this.item_grid.ShowNoDataText = false;
            this.item_grid.Size = new System.Drawing.Size(595, 234);
            this.item_grid.TabIndex = 19;
            this.item_grid.ThemeName = "Office2010Silver";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.DKES_LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // MNG_ITEM_STATUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 430);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.item_grid);
            this.Controls.Add(this.radGroupBox4);
            this.Controls.Add(this.item_sn);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "MNG_ITEM_STATUS";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "وضعیت کالا";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.MNG_ITEM_STATUS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.item_sn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            this.radGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.latest_status_DT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.latest_status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_nature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.position)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.org_desc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.origin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_grid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadLabel latest_status;
        private Telerik.WinControls.UI.RadLabel item_nature;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadLabel position;
        private Telerik.WinControls.UI.RadLabel org_desc;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel origin;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel latest_status_DT;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadGridView item_grid;
        public Telerik.WinControls.UI.RadTextBox item_sn;
        private System.Windows.Forms.PictureBox pictureBox1;
        public Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
