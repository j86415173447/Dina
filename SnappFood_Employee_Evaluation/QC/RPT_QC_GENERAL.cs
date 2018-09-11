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
    public partial class RPT_QC_GENERAL : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt22 = new DataTable();

        public RPT_QC_GENERAL()
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

            ///////////////////////////// initilize QC_Agent combo
            DataTable dt5 = new DataTable();
            OleDbDataAdapter adp5 = new OleDbDataAdapter();
            adp5.SelectCommand = new OleDbCommand();
            adp5.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand5 = "SELECT '' 'QC_Agent' union SELECT distinct [QC_Agent] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] order by [qc_agent] asc";
            adp5.SelectCommand.CommandText = lcommand5;
            adp5.Fill(dt5);
            QC_Agent.DataSource = dt5;
            QC_Agent.DisplayMember = "QC_Agent";

            ///////////////////////////// initilize call type combo
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '' 'Call_Type_id', '' 'Call_Type_nm' union SELECT [Call_Type_id],[Call_Type_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_CALL_TYPE] where [Call_Type_Actv] != 0 order by  [Call_Type_id] asc";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            Call_Type.DataSource = dt4;
            Call_Type.DisplayMember = "Call_Type_nm";
            Call_Type.ValueMember = "Call_Type_id";

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

            ///////////////////////////////////////////////////////// initializing Log State combo
            DataTable dt6 = new DataTable();
            OleDbDataAdapter adp6 = new OleDbDataAdapter();
            adp6.SelectCommand = new OleDbCommand();
            adp6.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand6 = "SELECT '' 'Status' union SELECT distinct iif([QC_M_Approval] is null,N'منتظر تائید کیفی',iif([QC_M_Approval] = 1 and [CC_M_Approval] is null, N'منتظر تائید سرگروه',iif([QC_M_Approval] = 1 and [CC_M_Approval] = 0 and [LD_M_Approval] is null, N'منتظر تائید رهبر',iif([QC_M_Approval] = 1 and [CC_M_Approval] = 0 and [LD_M_Approval] = 0 and [MG_M_Approval] is null, N'منتظر تائید مدیر',iif([QC_M_Approval] = 1 and [CC_M_Approval] = 0 and [LD_M_Approval] = 0 and [MG_M_Approval] = 0 and [Final_Approval] is null, N'منتظر تائید برگشتی', iif([QC_M_Approval] = 0, [CC_M_Aprv_Usr],iif([Final_Approval] = 1, N'تائید نهایی', N'عدم تائید نهائی'))))))) as 'Status' FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] order by [Status] asc";
            adp6.SelectCommand.CommandText = lcommand6;
            adp6.Fill(dt6);
            Log_Status.DataSource = dt6;
            Log_Status.DisplayMember = "Status";
        }

        public string search_query()
        {
            List<string> conditions = new List<string>();
            string query = "";
            if (Call_Type.SelectedIndex != 0)
            {
                conditions.Add("SEL3.[Call_Type_nm] = N'" + Call_Type.Text + "'");
            }
            if (Log_Status.SelectedIndex != 0)
            {
                conditions.Add("Sel1.[Status] = N'" + Log_Status.Text + "'");
            }
            if (QC_Agent.SelectedIndex != 0)
            {
                conditions.Add("SEL1.[QC_Agent] = N'" + QC_Agent.Text + "'");
            }
            if (Per_Dep.SelectedIndex != 0)
            {
                conditions.Add("SEL2.[Department] = N'" + Per_Dep.Text + "'");
            }
            if (dt_from.Text != "")
            {
                conditions.Add("SEL1.[Insrt_dt_per] >= '" + dt_from.Text + "'");
            }
            if (dt_to.Text != "")
            {
                conditions.Add("SEL1.[Insrt_dt_per] <= '" + dt_to.Text + "'");
            }
            if (Taboo.Checked)
            {
                conditions.Add("SEL1.[taboo] = 1");
            }
            if (no_fwl.Checked)
            {
                conditions.Add("SEL1.[No_Followup] = 1");
            }
            if (bad_fwl.Checked)
            {
                conditions.Add("SEL1.[Bad_Followup] = 1");
            }
            if (conditions.Count != 0)
            {
                query = query + " WHERE " + string.Join(" AND ", conditions.ToArray());
            }

            return query;
        }

        public void update_grid()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY SEL1.[QC_ID] ASC) AS 'ردیف', SEL1.[QC_ID] 'شناسه کیفی', SEL1.[QC_Score] 'امتیاز کیفی', SEL1.[Agent_Ext] 'شماره داخلی', SEL2.[Per_Name] 'نام ایجنت', SEL2.[Department] 'واحد شغلی', " +
                              "SEL3.[Call_Type_nm] 'نوع تماس', SEL4.[Plan_nm] 'پلن کیفی', SEL1.[taboo] 'تابو',SEL1.[No_Followup] 'عدم پیگیری',SEL1.[Bad_Followup] 'پیگیری ناقص', SEL1.[insrt_dt_per] 'تاریخ بررسی', Sel1.[call_dt] 'تاریخ مکالمه', Sel1.[call_tm] 'ساعت مکالمه', Sel1.[bad_Switch] 'سوئیچ بد', Sel1.[No_Switch] 'عدم سوئیچ', Sel1.[QC_Agent] 'نام کارشناس کیفی', Sel1.[Status] 'وضعیت لاگ' " +
                              "FROM ( " +
                              "(SELECT [QC_ID],[QC_Score],[Agent_Ext],[Call_Type_Cd],[Log_Type_Cd],[taboo],[insrt_dt_per],[QC_Agent],[call_dt],[call_tm],[bad_switch],[No_switch], " +
                              "iif([QC_M_Approval] is null,N'منتظر تائید کیفی',iif([QC_M_Approval] = 1 and [CC_M_Approval] is null, N'منتظر تائید سرگروه',iif([QC_M_Approval] = 1 and [CC_M_Approval] = 0 and [LD_M_Approval] is null, N'منتظر تائید رهبر',iif([QC_M_Approval] = 1 and [CC_M_Approval] = 0 and [LD_M_Approval] = 0 and [MG_M_Approval] is null, N'منتظر تائید مدیر',iif([QC_M_Approval] = 1 and [CC_M_Approval] = 0 and [LD_M_Approval] = 0 and [MG_M_Approval] = 0 and [Final_Approval] is null, N'منتظر تائید برگشتی', iif([QC_M_Approval] = 0, [CC_M_Aprv_Usr],iif([Final_Approval] = 1, N'تائید نهایی', N'عدم تائید نهائی'))))))) as [Status] " +
                              " ,[No_Followup],[Bad_Followup] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS]) SEL1 " +
                              "LEFT JOIN (SELECT [System_Id],[Department],[Per_Name] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) SEL2 ON SEL1.[Agent_Ext] = SEL2.[System_Id] " +
                              "LEFT JOIN (SELECT [Call_Type_id],[Call_Type_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_CALL_TYPE]) SEL3 ON SEL1.[Call_Type_Cd] = SEL3.[Call_Type_id] " +
                              "LEFT JOIN (SELECT [Plan_id],[Plan_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_PLAN]) SEL4 ON SEL1.[Log_Type_Cd] = SEL4.[Plan_id]) ";
            adp.SelectCommand.CommandText = lcommand + search_query();
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
