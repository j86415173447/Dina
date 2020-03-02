using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;

namespace SnappFood_Employee_Evaluation.System_Managment
{
    public partial class GEN_HC_DASHBOARD : Telerik.WinControls.UI.RadForm
    {
        public string constr;

        public GEN_HC_DASHBOARD()
        {
            InitializeComponent();
        }

        private void GEN_HC_DASHBOARD_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            ///////////////////////////////////////////////////////// initializing department combo
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT '' 'Department_Nm','' 'Department_Cd' union SELECT [Department_Nm],[Department_Cd] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_DEPARTMENT] where [Department_Actv] = 1 order by Department_Cd asc";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            Per_Dep.DataSource = dt;
            Per_Dep.ValueMember = "Department_Cd";
            Per_Dep.DisplayMember = "Department_Nm";

            update_grid();
        }

        public void update_grid()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT [Main_Shift] 'شیفت',[Position] 'سطح شغلی', count([Doc_No]) 'تعداد نیرو' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] WHERE [Termination] = 0 " + (Per_Dep.SelectedIndex == 0 ? "" : ("and [Department] = N'" + Per_Dep.Text + "'")) + " group by [Main_Shift],[Position] order by [Main_Shift] asc";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            radGridView1.DataSource = dt;
            radGridView1.BestFitColumns();
            radGridView1.TableElement.RowHeight = 35;
            radGridView1.TableElement.TableHeaderHeight = 40;
            radGridView1.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;

            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT [Main_Shift] 'شیفت',iif([Main_Task] is null,N'نامشخص',[Main_Task]) 'تسک اصلی', count([Doc_No]) 'تعداد نیرو' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] WHERE [Termination] = 0 and [Position] = N'کارشناس' " + (Per_Dep.SelectedIndex == 0 ? "" : ("and [Department] = N'" + Per_Dep.Text + "'")) + " group by [Main_Shift],[Main_Task] order by [Main_Shift] asc";
            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            radGridView2.DataSource = dt2;
            radGridView2.BestFitColumns();
            radGridView2.TableElement.RowHeight = 20;
            radGridView2.TableElement.TableHeaderHeight = 30;
            radGridView2.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView2.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView2.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
        }

        private void Per_Dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_grid();
        }
    }
}
