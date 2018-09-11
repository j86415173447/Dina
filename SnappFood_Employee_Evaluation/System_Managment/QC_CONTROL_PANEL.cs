using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using System.IO;
using System.Globalization;
using Telerik.WinControls.UI;

namespace SnappFood_Employee_Evaluation.System_Managment
{
    public partial class QC_CONTROL_PANEL : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public string DT_Day;
        public string DT_Mth;
        public string DT_Yr;
        private ErrorProvider errorProvider;

        public QC_CONTROL_PANEL()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
        }

        private void GEN_POSITIONING_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            RadMessageBox.SetThemeName("Office2010Silver");
            ////////////////////////////////////////////////////////// Initilizing CAP
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT [cap_0_30],[cap_30_60],[cap_60_90],[cap_ov_90],[min_suc_log] FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_QC_SETTING]";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            if (dtsc4.Rows.Count != 0)
            {
                T0_30.Text = dtsc4.Rows[0][0].ToString();
                T30_60.Text = dtsc4.Rows[0][1].ToString();
                T60_90.Text = dtsc4.Rows[0][2].ToString();
                T_Over_90.Text = dtsc4.Rows[0][3].ToString();
                Min_Suc_Score.Text = dtsc4.Rows[0][4].ToString();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (AreRequiredFieldsValid()) 
            {
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "Truncate Table [SNAPP_CC_EVALUATION].[dbo].[SYS_QC_SETTING]";
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();

                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[SYS_QC_SETTING] ([cap_0_30],[cap_30_60],[cap_60_90],[cap_ov_90],[min_suc_log]) VALUES (?,?,?,?,?)";
                oleDbCommand1.Parameters.AddWithValue("@cap_0_30", T0_30.Text);
                oleDbCommand1.Parameters.AddWithValue("@cap_30_60", T30_60.Text);
                oleDbCommand1.Parameters.AddWithValue("@cap_60_90", T60_90.Text);
                oleDbCommand1.Parameters.AddWithValue("@cap_ov_90", T_Over_90.Text);
                oleDbCommand1.Parameters.AddWithValue("@min_suc_log", Min_Suc_Score.Text);
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
                RadMessageBox.Show(this, " تغییرات با موفقیت ثبت شد. " + "\n", "بروز خطا", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void Only_Digit(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '-');
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)))
                e.Handled = true;
        }

        private bool AreRequiredFieldsValid()
        {
            bool data_error = false;
            errorProvider.Clear();

            if (T0_30.Text == "")
            {
                this.errorProvider.SetError(this.T0_30, "مقدار وارد نشده است.");
                data_error = true;
            }
            if (T30_60.Text == "")
            {
                this.errorProvider.SetError(this.T30_60, "مقدار وارد نشده است.");
                data_error = true;
            }
            if (T60_90.Text == "")
            {
                this.errorProvider.SetError(this.T60_90, "مقدار وارد نشده است.");
                data_error = true;
            }
            if (T_Over_90.Text == "")
            {
                this.errorProvider.SetError(this.T_Over_90, "مقدار وارد نشده است.");
                data_error = true;
            }
            if (T0_30.Text == "0")
            {
                this.errorProvider.SetError(this.T0_30, "مقدار صفر مجاز نیست.");
                data_error = true;
            }
            if (T30_60.Text == "0")
            {
                this.errorProvider.SetError(this.T30_60, "مقدار صفر مجاز نیست.");
                data_error = true;
            }
            if (T60_90.Text == "0")
            {
                this.errorProvider.SetError(this.T60_90, "مقدار صفر مجاز نیست.");
                data_error = true;
            }
            if (T_Over_90.Text == "0")
            {
                this.errorProvider.SetError(this.T_Over_90, "مقدار صفر مجاز نیست.");
                data_error = true;
            }
            int n1 = int.Parse(T0_30.Text);
            int n2 = int.Parse(T30_60.Text);
            int n3 = int.Parse(T60_90.Text);
            int n4 = int.Parse(T_Over_90.Text);
            if (n1 + n2 + n3 + n4 != 100)
            {
                data_error = true;
                RadMessageBox.Show(this, " مجموع درصدهای وارد شده می بایست 100% باشد. " + "\n", "بروز خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            if (Min_Suc_Score.Text == "" || int.Parse(Min_Suc_Score.Text) < 1 || int.Parse(Min_Suc_Score.Text) > 24)
            {
                this.errorProvider.SetError(this.Min_Suc_Score, "مقدار وارد شده صحیح نیست.");
                data_error = true;
            }
            if (data_error == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
