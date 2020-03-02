namespace SnappFood_Employee_Evaluation
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.forget = new Telerik.WinControls.UI.RadLabel();
            this.pass = new Telerik.WinControls.UI.RadTextBox();
            this.user = new Telerik.WinControls.UI.RadTextBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.btn_cancel = new Telerik.WinControls.UI.RadButton();
            this.btn_enter = new Telerik.WinControls.UI.RadButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.roundRectShape1 = new Telerik.WinControls.RoundRectShape(this.components);
            this.pathElementShape1 = new Telerik.WinControls.Shapes.PathElementShape();
            ((System.ComponentModel.ISupportInitialize)(this.forget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_enter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // forget
            // 
            this.forget.BackColor = System.Drawing.Color.White;
            this.forget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forget.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.forget.ForeColor = System.Drawing.Color.Blue;
            this.forget.Location = new System.Drawing.Point(191, 229);
            this.forget.Name = "forget";
            this.forget.Size = new System.Drawing.Size(235, 20);
            this.forget.TabIndex = 4;
            this.forget.Text = "کلمه عبور خود را فراموش کرده اید؟";
            this.forget.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.forget.ThemeName = "Office2010Silver";
            this.forget.Visible = false;
            this.forget.Click += new System.EventHandler(this.radLabel1_Click);
            // 
            // pass
            // 
            this.pass.AutoSize = false;
            this.pass.BackColor = System.Drawing.Color.Transparent;
            this.pass.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.pass.Location = new System.Drawing.Point(157, 106);
            this.pass.Name = "pass";
            this.pass.PasswordChar = '●';
            this.pass.Size = new System.Drawing.Size(196, 22);
            this.pass.TabIndex = 7;
            this.pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pass.UseSystemPasswordChar = true;
            this.pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pass_KeyPress);
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.pass.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.pass.GetChildAt(0).GetChildAt(0))).NullText = "";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.pass.GetChildAt(0).GetChildAt(0))).BorderHighlightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.pass.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.pass.GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.pass.GetChildAt(0).GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.pass.GetChildAt(0).GetChildAt(0))).Shape = null;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.pass.GetChildAt(0).GetChildAt(1))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.pass.GetChildAt(0).GetChildAt(1))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.pass.GetChildAt(0).GetChildAt(1))).BackColor4 = System.Drawing.Color.Transparent;
            // 
            // user
            // 
            this.user.AutoSize = false;
            this.user.BackColor = System.Drawing.Color.Transparent;
            this.user.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.user.Location = new System.Drawing.Point(157, 63);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(196, 22);
            this.user.TabIndex = 6;
            this.user.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.user_KeyPress);
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.user.GetChildAt(0).GetChildAt(0))).NullText = "";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.user.GetChildAt(0).GetChildAt(0))).BorderHighlightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.user.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.user.GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.user.GetChildAt(0).GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.user.GetChildAt(0).GetChildAt(0))).Shape = null;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.user.GetChildAt(0).GetChildAt(1))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.user.GetChildAt(0).GetChildAt(1))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.user.GetChildAt(0).GetChildAt(1))).BackColor4 = System.Drawing.Color.Transparent;
            // 
            // radButton1
            // 
            this.radButton1.BackColor = System.Drawing.Color.LemonChiffon;
            this.radButton1.Enabled = false;
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radButton1.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.question;
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(157, 134);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(115, 24);
            this.radButton1.TabIndex = 10;
            this.radButton1.Text = "بازیابی کلمه عبور";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_cancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btn_cancel.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.cross_blue_16;
            this.btn_cancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.Location = new System.Drawing.Point(283, 134);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(70, 24);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "انصراف";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_enter
            // 
            this.btn_enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_enter.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btn_enter.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.tick_blue_16;
            this.btn_enter.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_enter.Location = new System.Drawing.Point(364, 134);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(70, 24);
            this.btn_enter.TabIndex = 8;
            this.btn_enter.Text = "ورود";
            this.btn_enter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_enter.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // radTextBox1
            // 
            this.radTextBox1.AutoSize = false;
            this.radTextBox1.BackColor = System.Drawing.Color.Azure;
            this.radTextBox1.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.radTextBox1.Location = new System.Drawing.Point(157, 164);
            this.radTextBox1.Multiline = true;
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(277, 32);
            this.radTextBox1.TabIndex = 8;
            this.radTextBox1.Text = "بهره بردار: آرا جهان نوین گستر اطلس (اسنپ تریپ)\r\nماژول: QAS | کد لایسنس: 11854030" +
    "09 | Beta Test";
            this.radTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.radTextBox1.GetChildAt(0))).Text = "بهره بردار: آرا جهان نوین گستر اطلس (اسنپ تریپ)\r\nماژول: QAS | کد لایسنس: 11854030" +
    "09 | Beta Test";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.radTextBox1.GetChildAt(0).GetChildAt(0))).NullText = "";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.radTextBox1.GetChildAt(0).GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.radTextBox1.GetChildAt(0).GetChildAt(0))).BorderHighlightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.radTextBox1.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 7.5F);
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.radTextBox1.GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.radTextBox1.GetChildAt(0).GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.radTextBox1.GetChildAt(0).GetChildAt(0))).Shape = null;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTextBox1.GetChildAt(0).GetChildAt(1))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTextBox1.GetChildAt(0).GetChildAt(1))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTextBox1.GetChildAt(0).GetChildAt(1))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radTextBox1.GetChildAt(0).GetChildAt(2))).Shape = this.roundRectShape1;
            // 
            // roundRectShape1
            // 
            this.roundRectShape1.IsRightToLeft = false;
            // 
            // pathElementShape1
            // 
            this.pathElementShape1.Bounds = ((System.Drawing.RectangleF)(resources.GetObject("pathElementShape1.Bounds")));
            this.pathElementShape1.IsRightToLeft = false;
            this.pathElementShape1.Owner = null;
            this.pathElementShape1.Path = null;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(445, 250);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_enter);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.user);
            this.Controls.Add(this.forget);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.forget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_enter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadLabel forget;
        private Telerik.WinControls.UI.RadTextBox pass;
        private Telerik.WinControls.UI.RadTextBox user;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton btn_cancel;
        private Telerik.WinControls.UI.RadButton btn_enter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.RoundRectShape roundRectShape1;
        private Telerik.WinControls.Shapes.PathElementShape pathElementShape1;
    }
}
