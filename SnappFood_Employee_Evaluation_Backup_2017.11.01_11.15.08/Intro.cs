using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SnappFood_Employee_Evaluation
{
    public partial class Intro : Telerik.WinControls.UI.RadForm
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void Intro_Shown(object sender, EventArgs e)
        {
            this.Update();
            int i = 0;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Maximum = 100;
            for (i = 1; i <= 100; i++)
            {
                progressBar1.Value = i;
                progressBar1.Value = i - 1;
                this.Update();
                Thread.Sleep(4);
            }
            Thread.Sleep(1000);
            this.Update();
            this.Hide();
            var intro = new Login();
            intro.Show();
        }
    }
}
