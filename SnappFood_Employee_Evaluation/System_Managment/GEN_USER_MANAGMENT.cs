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
using SmsIrRestful;

namespace SnappFood_Employee_Evaluation.System_Managment
{
    public partial class GEN_USER_MANAGMENT : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public string DT_Day;
        public string DT_Mth;
        public string DT_Yr;
        public SmsIrRestful.Token token_instance = new SmsIrRestful.Token();
        public string token = null;
        public string token_key;
        public string token_security;
        private ErrorProvider errorProvider;
        public bool data_error = false;

        public GEN_USER_MANAGMENT()
        {
            InitializeComponent();
            RadMessageBox.SetThemeName("Office2010Silver");
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
        }

        private void GEN_POSITIONING_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT day(GETDATE()), month(GETDATE()), year(GETDATE())";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            DateTime datetime = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
            ///////////////////////////////////////// Convert Persian
            PersianCalendar psdate = new PersianCalendar();
            DT_Day = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            DT_Mth = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            DT_Yr = psdate.GetYear(datetime).ToString();

            ///////////////////////////////////////// Initialize Positions
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT '' 'Role_CD', '' 'Role_Desc' union SELECT Distinct [Role_CD],[Role_Desc] FROM [SNAPP_CC_EVALUATION].[dbo].[USR_ROLE_MASTER] ";
            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            combo_roles.DataSource = dt2;
            combo_roles.DisplayMember = "Role_Desc";
            combo_roles.ValueMember = "Role_CD";
        }

        public void searching()
        {
            //Clear_Frm();
            /////////////////////////////// Update first tab
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[users] where [usr_name] = '" + usr_id.Text + "'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            usr_per_name.Text = dt1.Rows[0][2].ToString();
            org_role.Text = dt1.Rows[0][3].ToString();
            combo_roles.Text = dt1.Rows[0][5].ToString();
            actv.Checked = (dt1.Rows[0][6].ToString() == "True" ? true : false);
            must_chng.Checked = (dt1.Rows[0][7].ToString() == "True" ? true : false);
            usr_id.Enabled = false;
        }

        private void Print_Click(object sender, EventArgs e)
        {
            System_Managment.SRCH_USER_MANAGMENT ob = new System_Managment.SRCH_USER_MANAGMENT(this);
            ob.constr = constr;
            ob.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void new_position_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (check_entry())
            {
                if (usr_id.Enabled) //////////////////////// insert mode
                {
                    
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[Users] ([usr_name],[Usr_Pass],[usr_per_name], [usr_role], [usr_role_cd], [usr_role_nm], [usr_actv], [usr_first_login]) VALUES (?,?,?,?,?,?,?,?)";
                    oleDbCommand1.Parameters.AddWithValue("@usr_name", usr_id.Text);
                    oleDbCommand1.Parameters.AddWithValue("@usr_Pass", "1");
                    oleDbCommand1.Parameters.AddWithValue("@usr_per_name", usr_per_name.Text);
                    oleDbCommand1.Parameters.AddWithValue("@usr_role", org_role.Text);
                    oleDbCommand1.Parameters.AddWithValue("@usr_role_cd", combo_roles.SelectedValue.ToString());
                    oleDbCommand1.Parameters.AddWithValue("@usr_role_nm", combo_roles.Text);
                    oleDbCommand1.Parameters.AddWithValue("@usr_actv", (actv.Checked == true ? true : false));
                    oleDbCommand1.Parameters.AddWithValue("@usr_first_login", (must_chng.Checked == true ? true : false));
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    
                    radMenuItem1_Click(null, null);
                    RadMessageBox.Show(this, " کاربر جدید با موفقیت ساخته شد. " + "\n", "اعلان سیستم", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);

                }
                else ///////////////////////////////////////////// amend mode
                {
                    ////////////////////////////////////////////// 3- User Table Update
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[Users] SET [usr_per_name]=? , [usr_role]=? , [usr_role_cd]=? , [usr_role_nm]=? , [usr_actv]=? , [usr_first_login]=?  WHERE [usr_name] = '" + usr_id.Text + "'";
                    oleDbCommand1.Parameters.AddWithValue("@usr_per_name", usr_per_name.Text);
                    oleDbCommand1.Parameters.AddWithValue("@usr_role", org_role.Text);
                    oleDbCommand1.Parameters.AddWithValue("@usr_role_cd", combo_roles.SelectedValue.ToString());
                    oleDbCommand1.Parameters.AddWithValue("@usr_role_nm", combo_roles.Text);
                    oleDbCommand1.Parameters.AddWithValue("@usr_actv", (actv.Checked == true ? true : false));
                    oleDbCommand1.Parameters.AddWithValue("@usr_first_login", (must_chng.Checked == true ? true : false));
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();

                    RadMessageBox.Show(this, "تغییرات با موفقیت ثبت شد." + "\n", "اعلان سیستم", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
            }
        }

        public bool check_entry()
        {
            data_error = false;
            if (usr_id.Text == "")
            {
                this.errorProvider.SetError(this.usr_id, "نام کاربری وارد نشده است");
                data_error = true;
            }
            if (usr_per_name.Text == "")
            {
                this.errorProvider.SetError(this.usr_per_name, "نام و نام خانوادگی وارد نشده است");
                data_error = true; 
            }
            if (org_role.Text == "")
            {
                this.errorProvider.SetError(this.org_role, "سمت وارد نشده است");
                data_error = true;
            }
            if (combo_roles.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.combo_roles, "سطح دسترسی انتخاب نشده است");
                data_error = true;
            }
            DataTable dt = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT [usr_name] FROM [SNAPP_CC_EVALUATION].[dbo].[Users] where [usr_name] = N'" + usr_id.Text + "'";
            adp2.SelectCommand.CommandText = lcommand2;
            dt.Clear();
            adp2.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                this.errorProvider.SetError(this.usr_id, "نام کاربری تکراری است.");
                data_error = true;
            }
            if (data_error)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            var new_staff = new System_Managment.GEN_USER_MANAGMENT();
            new_staff.constr = constr;
            new_staff.MdiParent = this.MdiParent;
            new_staff.Show();
            this.Close();
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            if (usr_id.Text != "")
            {
                Random rndm = new Random();
                int otp = rndm.Next(13681, 99843);
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "Update [SNAPP_CC_EVALUATION].[dbo].[Users] Set [USR_Pass] = HashBytes('MD5', convert(nvarchar(max),'" + otp.ToString() + "')), [usr_first_login] = 1  where [usr_name] = N'" + usr_id.Text + "'";

                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
                RadMessageBox.Show(this, " کلمه عبور تخصیص یافته:  " + otp.ToString() + "\n", "اعلان پسورد", MessageBoxButtons.OK, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                RadMessageBox.Show(this, "ابتدا یک کاربر را انتخاب نمائید." + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }
    }
}
