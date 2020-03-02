using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using OpenXmlPackaging;

namespace SnappFood_Employee_Evaluation.QC
{
    public partial class RPT_QCA_REJECT : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt22 = new DataTable();
        public string user;

        public RPT_QCA_REJECT()
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
        }

        public string search_query()
        {
            List<string> conditions = new List<string>();
            string query = "";
            if (Call_Type.SelectedIndex != 0)
            {
                conditions.Add("SEL2.[Call_Type_nm] = N'" + Call_Type.Text + "'");
            }
            if (dt_from.Text != "")
            {
                conditions.Add("SEL1.[Insrt_dt_per] >= '" + dt_from.Text + "'");
            }
            if (dt_to.Text != "")
            {
                conditions.Add("SEL1.[Insrt_dt_per] <= '" + dt_to.Text + "'");
            }
            if (conditions.Count != 0)
            {
                query = query + " AND " + string.Join(" AND ", conditions.ToArray());
            }

            return query;
        }

        public void update_grid()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY [QC_ID] ASC) AS 'ردیف', Sel1.[QC_ID] 'شناسه کیفی', Sel1.[QC_Score] 'امتیاز کیفی',Sel1.[Agent_Ext] 'داخلی ایجنت', Sel3.[Plan_nm] 'پلن کیفی',Sel2.[Call_Type_nm] 'نوع تماس',Sel1.[taboo] 'تابو',Sel1.[insrt_dt_per] 'تاریخ بررسی',Sel1.[QC_Agent] 'کارشناس کیفی' FROM ( " +
                              "(SELECT[QC_ID],[QC_Score],[Agent_Ext],[Call_Type_Cd],[Log_Type_Cd],[taboo],[insrt_dt_per],[QC_Agent],[CC_M_Aprv_Usr] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS]) Sel1 " +
                              "left join(SELECT[Call_Type_id],[Call_Type_nm] FROM[SNAPP_CC_EVALUATION].[dbo].[QC_CALL_TYPE]) Sel2 on Sel1.[Call_Type_Cd] = Sel2.[Call_Type_id] " +
                              "left join (SELECT[Plan_id],[Plan_nm] FROM[SNAPP_CC_EVALUATION].[dbo].[QC_PLAN]) Sel3 on Sel1.[Log_Type_Cd] = Sel3.[Plan_id]) WHERE Sel1.[CC_M_Aprv_Usr] = N'عدم تائید کیفی' and Sel1.[QC_Agent] = N'" + user + "'";
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
