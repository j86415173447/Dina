using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;

namespace SnappFood_Employee_Evaluation
{
    public partial class Pass_Change : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string username;
        private ErrorProvider errorProvider;
        public bool data_error = false;
        public bool frm_login = false;

        public Pass_Change()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pass_Change_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            data_error = false;
            if (NEW_PASS.Text.Length < 6)
            {
                this.errorProvider.SetError(this.NEW_PASS, "رمز عبور جدید باید بیش از 6 کاراکتر داشته باشد");
                data_error = true;
                //RadMessageBox.Show(this, "رمز عبور جدید باید بیش از 3 کاراکتر داشته باشد", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            if (NEW_PASS.Text != NEW_PASS_2.Text)
            {
                this.errorProvider.SetError(this.NEW_PASS_2, "رمز عبور جدید و تکرار آن با هم مطابقت ندارد");
                data_error = true;
                //RadMessageBox.Show(this, "رمز عبور جدید و تکرار آن با هم مطابقت ندارد", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            if (data_error != true)
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter adp2 = new OleDbDataAdapter();
                adp2.SelectCommand = new OleDbCommand();
                adp2.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand2 = "SELECT [usr_name],[usr_pass] FROM [SNAPP_CC_EVALUATION].[dbo].[Users] where [usr_name] = N'" + username + "'";
                adp2.SelectCommand.CommandText = lcommand2;
                dt.Clear();
                adp2.Fill(dt);
                if (CUR_PASS.Text != dt.Rows[0][1].ToString())
                {
                    this.errorProvider.SetError(this.CUR_PASS, "رمز عبور فعلی وارد شده صحیح نیست");
                    data_error = true;
                    //RadMessageBox.Show(this, "رمز عبور فعلی وارد شده صحیح نیست", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                else
                {
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "Update [SNAPP_CC_EVALUATION].[dbo].[Users] Set [USR_Pass] = ? , [USR_first_login] = ? where [usr_name] = N'" + username + "'";
                    oleDbCommand1.Parameters.AddWithValue("@newpass", NEW_PASS_2.Text);
                    oleDbCommand1.Parameters.AddWithValue("@newpass", "0");
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    
                    if (frm_login)
                    {
                        RadMessageBox.Show(this, "تغییر رمز با موفقیت انجام شد" + "\n\n" + "لطفاً سامانه را مجدداً راه اندازی نمائید.", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                        Application.Exit();
                    }
                    else
                    {
                        RadMessageBox.Show(this, "تغییر رمز با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                        this.Close();
                    }
                }
            }

        }
    }
}
