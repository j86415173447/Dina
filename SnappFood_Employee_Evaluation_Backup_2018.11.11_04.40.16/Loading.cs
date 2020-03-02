using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace SnappFood_Employee_Evaluation
{
    public partial class Loading : Telerik.WinControls.UI.RadForm
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            label1.TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}
