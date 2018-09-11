using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace SnappFood_Employee_Evaluation
{
    public partial class Intro : Telerik.WinControls.UI.RadForm
    {
        int ticks = 0;
        int stop;
        public Intro()
        {
            InitializeComponent();
            radProgressBar1.Minimum = 1;
            radProgressBar1.Maximum = 100;
        }

        private void Intro_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Intro_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            stop = rnd.Next(19, 81);

            timer1.Interval = 30;
            label1.Text = "ورژن:5.8.3 - متصل به پنل پیامک و ایمیل";
            label1.TextAlign = ContentAlignment.MiddleRight;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (ticks == 100)
            {
                timer1.Enabled = false;
                Thread.Sleep(1000);
                this.Hide();
                var intro = new Login();
                intro.Show();
            }
            else if (ticks == stop)
            {

                Thread.Sleep(1000);
                ticks++;

            }
            else
            {
                ticks++;
                radProgressBar1.Value1 = ticks;
                radProgressBar1.Text = ticks + "%";
            }
        }
    }
}
