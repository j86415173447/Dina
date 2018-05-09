using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;

namespace SnappFood_Employee_Evaluation.Personel
{
    public partial class PER_TEL_INFO : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string ext_no;
        public PER_TEL_INFO()
        {
            InitializeComponent();
            platform.TextAlignment = ContentAlignment.MiddleRight;
            username.TextAlignment = ContentAlignment.MiddleRight;
            password.TextAlignment = ContentAlignment.MiddleRight;
            this.FormElement.TitleBar.CloseButton.Enabled = false;
            this.FormElement.TitleBar.CloseButton.Visibility = ElementVisibility.Collapsed;
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            this.FormElement.TitleBar.TitlePrimitive.ForeColor = Color.Green;
        }

        private void PER_TEL_INFO_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            oleDbConnection1.ConnectionString = constr;
            ///////////////////////////////////////////////////// INFORMATION
            DataTable dtsc1 = new DataTable();
            OleDbDataAdapter adpsc1 = new OleDbDataAdapter();
            adpsc1.SelectCommand = new OleDbCommand();
            adpsc1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc1 = "SELECT [PLATFORM],[EXT_NO],[EXT_PASS] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TEL_EXT_MASTER] where [EXT_NO] = '" + ext_no + "'";
            adpsc1.SelectCommand.CommandText = lcommandsc1;
            adpsc1.Fill(dtsc1);
            if (dtsc1.Rows.Count != 0)
            {
                platform.Text = dtsc1.Rows[0][0].ToString();
                username.Text = dtsc1.Rows[0][1].ToString();
                password.Text = dtsc1.Rows[0][2].ToString();
            }
            else
            {
                error_msg.Visible = true;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
