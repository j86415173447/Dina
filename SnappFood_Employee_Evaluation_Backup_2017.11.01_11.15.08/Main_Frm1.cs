using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SnappFood_Employee_Evaluation
{
    public partial class Main_Frm1 : Telerik.WinControls.UI.RadRibbonForm
    {
        public string constr;
        public string username;
        public Main_Frm1()
        {
            InitializeComponent();
        }

        private void Main_Frm1_Load(object sender, EventArgs e)
        {

        }

        private void Main_Frm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void radButtonElement2_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Setting_Initializing.New_Staff))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Setting_Initializing.New_Staff();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }
    }
}
