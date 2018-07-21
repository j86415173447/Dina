using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using OpenXmlPackaging;

namespace SnappFood_Employee_Evaluation.QC
{
    public partial class RPT_QC_DETAILS_MG : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt22 = new DataTable();

        public RPT_QC_DETAILS_MG()
        {
            InitializeComponent();
        }

        private void QC_GENERAL_REPORT_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            dt_from.Culture = new System.Globalization.CultureInfo("fa-IR");
            dt_from.NullableValue = null;
            dt_from.SetToNullValue();

            dt_to.Culture = new System.Globalization.CultureInfo("fa-IR");
            dt_to.NullableValue = null;
            dt_to.SetToNullValue();
            
            ///////////////////////////////////////////////////////// initializing department combo
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT '' 'Department_Nm' union SELECT [Department_Nm] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_DEPARTMENT] where [Department_Actv] = 1 order by Department_Nm asc";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            Per_Dep.DataSource = dt;
            Per_Dep.DisplayMember = "Department_Nm";
           
        }

        public void update_grid()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT Sel2.[Per_Name] 'Agent Name', Sel2.[Department] 'Department',Sel2.[Main_Shift] 'Shift', Sel1.* from ( " +
                              " (SELECT[Agent_Ext] 'Extension', count([QC_ID]) 'Total Logs' , SUM(CASE WHEN[QC_Score] <= 17 then 1 else 0 end) 'Failed Logs' , SUM(CASE WHEN[taboo] = 1 then 1 else 0 end) 'Taboo Count' , SUM(CASE WHEN[QC_Param_1] = 0 then 1 else 0 end) 'Greeting' " +
                              " ,SUM(CASE WHEN[QC_Param_2] = 0 then 1 else 0 end) 'Opening Sen/Que' , SUM(CASE WHEN[QC_Param_3] = 0 then 1 else 0 end) 'Active Listening' , SUM(CASE WHEN[QC_Param_4] = 0 then 1 else 0 end) 'Call Holding' " +
                              " ,SUM(CASE WHEN[QC_Param_5] = 0 then 1 else 0 end) 'Interruption' , SUM(CASE WHEN[QC_Param_6] = 0 then 1 else 0 end) 'Summarizing' , SUM(CASE WHEN[QC_Param_7] = 0 then 1 else 0 end) 'Speaking Type' " +
                              " ,SUM(CASE WHEN[QC_Param_8] = 0 then 1 else 0 end) 'Speaking Tone' , SUM(CASE WHEN[QC_Param_9] = 0 then 1 else 0 end) 'Guide/Result' , SUM(CASE WHEN[QC_Param_10] = 0 then 1 else 0 end) 'Query' " +
                              " ,SUM(CASE WHEN[QC_Param_11] = 0 then 1 else 0 end) 'Appreciation' , SUM(CASE WHEN[QC_Param_12] = 0 then 1 else 0 end) 'Bye' FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where [Final_Approval] is not null " + (dt_from.Text == "" ? "" : (" AND [insrt_dt_per] >= N'" + dt_from.Text + "'")) + (dt_to.Text == "" ? "" : (" AND [insrt_dt_per] <= N'" + dt_to.Text + "'")) + " group by [Agent_Ext]) Sel1 " +
                              " left join(SELECT[System_Id],[Department],[Main_Shift],[Per_Name] FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel2 on Sel1.[Extension] = Sel2.[System_Id]) " + (Per_Dep.SelectedIndex == 0 ? "" : (" WHERE Sel2.[Department] = N'" + Per_Dep.Text + "'")) ;
            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);
            if (dt22.Rows.Count != 0)
            {
                radGridView1.DataSource = dt22;
                radGridView1.BestFitColumns();
            }
            else
            {
                RadMessageBox.Show(this, "مطابق با شرایط جستجو، موردی یافت نشد." + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            update_grid();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (radGridView1.Rows.Count != 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string add = saveFileDialog1.FileName;
                    add = add + ".xlsx";
                    using (var doc = new SpreadsheetDocument(@add))
                    {
                        Worksheet sheet1 = doc.Worksheets.Add("Report");
                        sheet1.ImportDataTable(dt22, "A1", true);
                    }
                    System.Diagnostics.Process.Start(@add);
                }
                else
                {

                }
            }
            else
            {
                RadMessageBox.Show(this, "اطلاعاتی جهت ارسال به اکسل وجود ندارد", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void QC_GENERAL_REPORT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                update_grid();
            }
        }

        private void radGridView1_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var log_detail = new QC.LOG_FULL_DETAILS();
            log_detail.constr = constr;
            log_detail.QC_ID.Text = radGridView1.SelectedRows[0].Cells[1].Value.ToString();
            log_detail.start();
            log_detail.search();
            log_detail.ShowDialog();
        }
    }
}
