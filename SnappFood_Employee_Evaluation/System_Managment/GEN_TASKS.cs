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
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void GEN_POSITIONING_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
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
            string lcommand = "SELECT [TASK_DEP] 'واحد سازمانی',[TASK_NM] 'نام تسک' ,iif([MAIN_TASK] = '1' and [SCND_TASK] = '1', N'اصلی/فرعی',(iif([MAIN_TASK] = '1' and [SCND_TASK] = '0', N'اصلی',N'فرعی'))) 'نوع تسک',[TASK_ACTV] 'فعال؟',[Insrt_usr] 'ثبت کننده' FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TASKS_MASTER]";
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
            if (AreRequiredFieldsValid()) 
            {
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[CONF_TASKS_MASTER] ([TASK_DEP],[TASK_NM],[MAIN_TASK],[SCND_TASK],[TASK_ACTV],[Insrt_usr],[Insrt_DT],[Insrt_TM]) " +
                                            "values (?,?,?,?,?,?,getdate(),getdate())";
                oleDbCommand1.Parameters.AddWithValue("@TASK_DEP", dep.Text);
                oleDbCommand1.Parameters.AddWithValue("@TASK_NM", TSK_Nm.Text);
                oleDbCommand1.Parameters.AddWithValue("@MAIN_TASK", (TSK_Type.SelectedIndex == 1 || TSK_Type.SelectedIndex == 3) ? "1" : "0");
                oleDbCommand1.Parameters.AddWithValue("@SCND_TASK", (TSK_Type.SelectedIndex == 2 || TSK_Type.SelectedIndex == 3) ? "1" : "0");
                oleDbCommand1.Parameters.AddWithValue("@TASK_ACTV", (TSK_ACTV.Checked == true ? "1" : "0"));
                oleDbCommand1.Parameters.AddWithValue("@Insrt_usr", user);
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
                RadMessageBox.Show(this, " تسک " + TSK_Nm.Text + " با موفقیت ثبت شد. " + "\n", "اعلان سیستم", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                update_grid();
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
            string lcommand = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TASKS_MASTER] where [TASK_NM] = N'" + TSK_Nm.Text + "'";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                RadMessageBox.Show(this, " تسک " + TSK_Nm.Text + " قبلا ثبت شده است. " + "\n", "اخطار سیستم", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
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
    }
}
