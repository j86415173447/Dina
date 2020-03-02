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
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.Dash = true;
            this.radProgressBar1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radProgressBar1.Location = new System.Drawing.Point(129, 135);
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radProgressBar1.SeparatorColor1 = System.Drawing.Color.LightBlue;
            this.radProgressBar1.SeparatorColor2 = System.Drawing.Color.LightSkyBlue;
            this.radProgressBar1.SeparatorColor3 = System.Drawing.Color.DodgerBlue;
            this.radProgressBar1.SeparatorColor4 = System.Drawing.Color.RoyalBlue;
            this.radProgressBar1.SeparatorNumberOfColors = 4;
            this.radProgressBar1.SeparatorWidth = 8;
            this.radProgressBar1.Size = new System.Drawing.Size(199, 23);
            this.radProgressBar1.StepWidth = 1;
            this.radProgressBar1.SweepAngle = 210;
            this.radProgressBar1.TabIndex = 4;
            this.radProgressBar1.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.RadProgressBarElement)(this.radProgressBar1.GetChildAt(0))).Dash = true;
            ((Telerik.WinControls.UI.RadProgressBarElement)(this.radProgressBar1.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).SeparatorWidth = 8;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).StepWidth = 1;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).SeparatorColor1 = System.Drawing.Color.LightBlue;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).SeparatorColor2 = System.Drawing.Color.LightSkyBlue;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).SeparatorColor3 = System.Drawing.Color.DodgerBlue;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).SeparatorColor4 = System.Drawing.Color.RoyalBlue;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).NumberOfColors = 4;
            ((Telerik.WinControls.UI.SeparatorsElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(2))).SweepAngle = 210;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(355, 176);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // Intro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radProgressBar1);
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
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}