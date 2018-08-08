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
    public partial class GEN_TASKS : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public string DT_Day;
        public string DT_Mth;
        public string DT_Yr;
        private ErrorProvider errorProvider;

        public GEN_TASKS()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;

        }

        private void GEN_POSITIONING_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            RadMessageBox.SetThemeName("Office2010Silver");
            update_grid();
            TSK_ACTV.Checked = true;
            ///////////////////////////////////////////////////////// initializing department combo
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT '' 'Department_Nm','' 'Department_Cd' union SELECT [Department_Nm],[Department_Cd] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_DEPARTMENT] where [Department_Actv] = 1 order by Department_Cd asc";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            dep.DataSource = dt;
            dep.ValueMember = "Department_Cd";
            dep.DisplayMember = "Department_Nm";
        }

        private void update_grid()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT [TASK_ID] 'کد تسک', [TASK_DEP] 'واحد سازمانی',[TASK_NM] 'نام تسک' ,iif([MAIN_TASK] = '1' and [SCND_TASK] = '1', N'اصلی/فرعی',(iif([MAIN_TASK] = '1' and [SCND_TASK] = '0', N'اصلی',N'فرعی'))) 'نوع تسک',[TASK_ACTV] 'فعال؟',[Insrt_usr] 'ثبت کننده' FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TASKS_MASTER]";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            grid.DataSource = dt;
            grid.BestFitColumns();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (TSK_ID.Text == "") //////////////////////////////////////////// Insrt Mode
            {
                if (AreRequiredFieldsValid())
                {
                    //////////////////////////////////////////// Get Doc_No
                    int doc_no;
                    string doc_no_str;
                    DataTable dt22 = new DataTable();
                    OleDbDataAdapter adp22 = new OleDbDataAdapter();
                    adp22.SelectCommand = new OleDbCommand();
                    adp22.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommand22 = "SELECT max([TASK_ID]) FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_GROUPS_MASTER]";
                    adp22.SelectCommand.CommandText = lcommand22;
                    adp22.Fill(dt22);
                    if (dt22.Rows[0][0].ToString() == "")
                    {
                        doc_no = 1;
                    }
                    else
                    {
                        doc_no = int.Parse(dt22.Rows[0][0].ToString()) + 1;
                    }
                    doc_no_str = doc_no.ToString();

                    TSK_ID.Text = doc_no_str;
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[CONF_TASKS_MASTER] ([TASK_ID],[TASK_DEP],[TASK_NM],[MAIN_TASK],[SCND_TASK],[TASK_ACTV],[Insrt_usr],[Insrt_DT],[Insrt_TM]) " +
                                                "values (?,?,?,?,?,?,?,getdate(),getdate())";
                    oleDbCommand1.Parameters.AddWithValue("@TASK_ID", TSK_ID.Text);
                    oleDbCommand1.Parameters.AddWithValue("@TASK_DEP", dep.Text);
                    oleDbCommand1.Parameters.AddWithValue("@TASK_NM", TSK_Nm.Text);
                    oleDbCommand1.Parameters.AddWithValue("@MAIN_TASK", (TSK_Type.SelectedIndex == 1 || TSK_Type.SelectedIndex == 3) ? "1" : "0");
                    oleDbCommand1.Parameters.AddWithValue("@SCND_TASK", (TSK_Type.SelectedIndex == 2 || TSK_Type.SelectedIndex == 3) ? "1" : "0");
                    oleDbCommand1.Parameters.AddWithValue("@TASK_ACTV", (TSK_ACTV.Checked == true ? "1" : "0"));
                    oleDbCommand1.Parameters.AddWithValue("@Insrt_usr", user);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    RadMessageBox.Show(this, "   تسک " + TSK_Nm.Text + " با موفقیت ثبت شد. " + "\n", "اعلان سیستم", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    update_grid();
                }
            }
            else /////////////////////////////////////////////////// Update mode
            {
                if (AreRequiredFieldsValid())
                {
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[CONF_TASKS_MASTER] SET [TASK_NM] = ?, [TASK_DEP] = ?, [MAIN_TASK] = ?, [SCND_TASK] = ?, [TASK_ACTV] = ?  WHERE [TASK_ID] = N'" + TSK_ID.Text + "'";
                    oleDbCommand1.Parameters.AddWithValue("@TASK_NM", TSK_Nm.Text);
                    oleDbCommand1.Parameters.AddWithValue("@TASK_DEP", dep.Text);
                    oleDbCommand1.Parameters.AddWithValue("@MAIN_TASK", (TSK_Type.SelectedIndex == 1 || TSK_Type.SelectedIndex == 3) ? "1" : "0");
                    oleDbCommand1.Parameters.AddWithValue("@SCND_TASK", (TSK_Type.SelectedIndex == 2 || TSK_Type.SelectedIndex == 3) ? "1" : "0");
                    oleDbCommand1.Parameters.AddWithValue("@TASK_ACTV", (TSK_ACTV.Checked == true ? "1" : "0"));
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    RadMessageBox.Show(this, "   تسک " + TSK_Nm.Text + " با موفقیت ویرایش شد. " + "\n", "اعلان سیستم", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    update_grid();
                }
            }
        }

        private bool AreRequiredFieldsValid()
        {
            bool data_error = false;

            if (TSK_Nm.Text == "")
            {
                this.errorProvider.SetError(this.TSK_Nm, "نام تسک وارد نشده است");
                data_error = true;
            }
            if (dep.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.dep, "واحد سازمانی انتخاب نشده است");
                data_error = true;
            }
            if (TSK_Type.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.TSK_Type, "نوع تسک انتخاب نشده است");
                data_error = true;
            }
            ////////////////////////////////////////////////////////////// check duplicate
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TASKS_MASTER] where [TASK_NM] = N'" + TSK_Nm.Text + "' and [TASK_DEP] = N'" + dep.Text + "'";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                RadMessageBox.Show(this, "   تسک " + TSK_Nm.Text + " برای واحد " + dep.Text + " قبلا ثبت شده است. " + "\n", "اخطار سیستم", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
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

        private void New_Click(object sender, EventArgs e)
        {
            var new_staff = new System_Managment.GEN_TASKS();
            new_staff.constr = constr;
            new_staff.user = user;
            new_staff.MdiParent = this.ParentForm;
            this.Close();
            new_staff.Show();
        }

        private void grid_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            TSK_ID.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
            searching();
        }

        private void searching()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT *,iif([MAIN_TASK] = '1' and [SCND_TASK] = '1', N'اصلی/فرعی',(iif([MAIN_TASK] = '1' and [SCND_TASK] = '0', N'اصلی',N'فرعی'))) 'نوع تسک' FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TASKS_MASTER] where [TASK_ID] = N'" + TSK_ID.Text + "'";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            TSK_Nm.Text = dt.Rows[0][1].ToString();
            dep.Text = dt.Rows[0][2].ToString();
            TSK_Type.Text = dt.Rows[0][9].ToString();
            TSK_ACTV.Checked = bool.Parse(dt.Rows[0][5].ToString());
        }
    }
}
