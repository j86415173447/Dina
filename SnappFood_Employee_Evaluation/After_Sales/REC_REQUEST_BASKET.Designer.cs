namespace SnappFood_Employee_Evaluation.After_Sales
{
    partial class REC_REQUEST_BASKET
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
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.lbl = new Telerik.WinControls.UI.RadLabel();
            this.basket_no = new Telerik.WinControls.UI.RadLabel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basket_no)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // lbl
            // 
            this.lbl.AutoSize = false;
            this.lbl.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lbl.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl.Location = new System.Drawing.Point(12, 30);
            this.lbl.Name = "lbl";
            this.lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl.Size = new System.Drawing.Size(576, 36);
            this.lbl.TabIndex = 0;
            this.lbl.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl.ThemeName = "Office2010Silver";
            this.lbl.Visible = false;
            // 
            // basket_no
            // 
            this.basket_no.AutoSize = false;
            this.basket_no.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.basket_no.ForeColor = System.Drawing.Color.Red;
            this.basket_no.Location = new System.Drawing.Point(12, 72);
            this.basket_no.Name = "basket_no";
            this.basket_no.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.basket_no.Size = new System.Drawing.Size(576, 36);
            this.basket_no.TabIndex = 1;
            this.basket_no.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.basket_no.ThemeName = "Office2010Silver";
            this.basket_no.Visible = false;
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.radButton1.Location = new System.Drawing.Point(245, 154);
            this.radButton1.Name = "radButton1";
            this.radButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "متوجه شدم!";
            this.radButton1.ThemeName = "ControlDefault";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // REC_REQUEST_BASKET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 186);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.basket_no);
            this.Controls.Add(this.lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "REC_REQUEST_BASKET";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REC_REQUEST_BASKET";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.REC_REQUEST_BASKET_Load);
            this.Shown += new System.EventHandler(this.REC_REQUEST_BASKET_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.lbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basket_no)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private Telerik.WinControls.UI.RadLabel lbl;
        private Telerik.WinControls.UI.RadLabel basket_no;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}
