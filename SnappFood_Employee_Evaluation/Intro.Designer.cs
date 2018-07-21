namespace SnappFood_Employee_Evaluation
{
    partial class Intro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Intro));
            this.label1 = new System.Windows.Forms.Label();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(204, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ورژن: 1.1.4 - متصل به پنل پیامک";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.Sms_icon;
            this.pictureBox1.Location = new System.Drawing.Point(557, 275);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.Gmail_icon2;
            this.pictureBox2.Location = new System.Drawing.Point(517, 275);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.Dash = true;
            this.radProgressBar1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radProgressBar1.Location = new System.Drawing.Point(4, 238);
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radProgressBar1.SeparatorColor1 = System.Drawing.Color.Pink;
            this.radProgressBar1.SeparatorColor2 = System.Drawing.Color.HotPink;
            this.radProgressBar1.SeparatorColor3 = System.Drawing.Color.DeepPink;
            this.radProgressBar1.SeparatorColor4 = System.Drawing.Color.DeepPink;
            this.radProgressBar1.SeparatorNumberOfColors = 4;
            this.radProgressBar1.SeparatorWidth = 8;
            this.radProgressBar1.Size = new System.Drawing.Size(588, 37);
            this.radProgressBar1.StepWidth = 1;
            this.radProgressBar1.SweepAngle = 210;
            this.radProgressBar1.TabIndex = 4;
            this.radProgressBar1.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.RadProgressBarElement)(this.radProgressBar1.GetChildAt(0))).Dash = true;
            ((Telerik.WinControls.UI.RadProgressBarElement)(this.radProgressBar1.GetChildAt(0))).Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Intro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(639, 341);
            this.Controls.Add(this.radProgressBar1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Intro";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intro";
            this.Load += new System.EventHandler(this.Intro_Load);
            this.Shown += new System.EventHandler(this.Intro_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}