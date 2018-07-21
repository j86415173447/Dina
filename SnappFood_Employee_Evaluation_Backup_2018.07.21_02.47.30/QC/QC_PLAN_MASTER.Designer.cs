namespace SnappFood_Employee_Evaluation.QC
{
    partial class QC_PLAN_MASTER
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
            this.CRS_NM = new Telerik.WinControls.UI.RadTextBox();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.ACTV = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.AMW = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_CD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ACTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AMW)).BeginInit();
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
            this.grid.Location = new System.Drawing.Point(12, 95);
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
            this.grid.Size = new System.Drawing.Size(546, 347);
            this.grid.TabIndex = 2;
            this.grid.ThemeName = "Office2010Silver";
            this.grid.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // Save
            // 
            this.Save.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.save1;
            this.Save.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Save.Name = "Save";
            this.Save.Text = "ثبت/اصلاح";
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
            this.radLabel1.Location = new System.Drawing.Point(517, 69);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(41, 17);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "کد پلن:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // CRS_CD
            // 
            this.CRS_CD.AutoSize = false;
            this.CRS_CD.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.CRS_CD.ForeColor = System.Drawing.Color.Maroon;
            this.CRS_CD.Location = new System.Drawing.Point(436, 64);
            this.CRS_CD.Name = "CRS_CD";
            this.CRS_CD.Size = new System.Drawing.Size(71, 27);
            this.CRS_CD.TabIndex = 5;
            this.CRS_CD.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel3.Location = new System.Drawing.Point(357, 69);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(73, 17);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "نام پلن کیفی:";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // CRS_NM
            // 
            this.CRS_NM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CRS_NM.Location = new System.Drawing.Point(154, 66);
            this.CRS_NM.Name = "CRS_NM";
            this.CRS_NM.Size = new System.Drawing.Size(197, 20);
            this.CRS_NM.TabIndex = 8;
            this.CRS_NM.ThemeName = "Office2010Silver";
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
            this.radMenu1.Size = new System.Drawing.Size(570, 53);
            this.radMenu1.TabIndex = 3;
            this.radMenu1.ThemeName = "Office2010Silver";
            // 
            // ACTV
            // 
            this.ACTV.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ACTV.Location = new System.Drawing.Point(12, 69);
            this.ACTV.Name = "ACTV";
            this.ACTV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ACTV.Size = new System.Drawing.Size(46, 17);
            this.ACTV.TabIndex = 9;
            this.ACTV.Text = "فعال؟";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radLabel2.Location = new System.Drawing.Point(112, 69);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(36, 17);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "AMW:";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // AMW
            // 
            this.AMW.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AMW.Location = new System.Drawing.Point(64, 66);
            this.AMW.Name = "AMW";
            this.AMW.Size = new System.Drawing.Size(42, 20);
            this.AMW.TabIndex = 9;
            this.AMW.ThemeName = "Office2010Silver";
            // 
            // QC_PLAN_MASTER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 453);
            this.Controls.Add(this.AMW);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.ACTV);
            this.Controls.Add(this.CRS_NM);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.CRS_CD);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radMenu1);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "QC_PLAN_MASTER";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت پلن های کیفی";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.TRN_COURSE_MASTER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_CD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRS_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ACTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AMW)).EndInit();
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
        private Telerik.WinControls.UI.RadTextBox CRS_NM;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadCheckBox ACTV;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox AMW;
    }
}
