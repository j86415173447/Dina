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
    public partial class RPT_QCA_PERFORMANCE : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public DataTable dt22 = new DataTable();
        public int min_score;

        public RPT_QCA_PERFORMANCE()
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
                min_score = int.Parse(dtsc4.Rows[0][4].ToString());
            }


        }

        public void update_grid()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT BSEL1.*,BSEL2.[AMW] from ((SELECT [QC_Agent] 'نام کارشناس',COUNT([QC_ID]) 'لاگ مانیتور شده',SUM(CASE WHEN [QC_Score]< " + min_score.ToString() + " then 1 else 0 end) 'لاگ ناموفق',SUM(CASE WHEN [QC_Score] >=" + min_score.ToString() + " then 1 else 0 end) 'لاگ موفق' " +
                              ",SUM(CASE WHEN[taboo] = 1 then 1 else 0 end) 'تابو',SUM(CASE WHEN [QC_M_Approval] != [Final_Approval] and[Final_Approval] is not null then 1 else 0 end) 'تغییر تائید',AVG([Handling_tm]) 'AHT' " +
                              " FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_ID] != 1  " + (dt_from.Text == "" ? "" : (" AND [insrt_dt_per] >= N'" + dt_from.Text + "'")) + (dt_to.Text == "" ? "" : (" AND [insrt_dt_per] <= N'" + dt_to.Text + "'")) + "  group by[QC_Agent]) BSEL1 " +
                              "left join(select Sel10.[QC_Agent], AVG(ABS(Sel10.[Handling_tm] - Sel20.[Len])) 'AMW' from((SELECT[QC_ID],[Handling_tm],[QC_Agent] FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_ID] != 1  " + (dt_from.Text == "" ? "" : (" AND [insrt_dt_per] >= N'" + dt_from.Text + "'")) + (dt_to.Text == "" ? "" : (" AND [insrt_dt_per] <= N'" + dt_to.Text + "'")) + " ) Sel10 " +
                              "left join(SELECT[QC_ID], sum((SUBSTRING([Voice_len], 1, 2) * 60) + SUBSTRING([Voice_len], 4, 2)) AS 'Len' FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_VOICES] group by[QC_ID]) Sel20 " +
                              "on Sel10.[QC_ID] = Sel20.[QC_ID]) group by Sel10.[QC_Agent]) BSEL2 on BSEL1.[نام کارشناس] = BSEL2.[QC_Agent]) where BSEL2.[QC_AGENT] = N'" + user + "'";

            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);
            if (dt22.Rows.Count != 0)
            {
                radGridView1.DataSource = dt22;
                radGridView1.BestFitColumns();
                radGridView1.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[7].TextAlignment = ContentAlignment.MiddleCenter;

                //for (int i = 0; i < radGridView1.Rows.Count; i++)
                //{
                //    radGridView1.Rows[i].Cells[1].Value = (int.Parse(radGridView1.Rows[i].Cells[2].Value.ToString()) + int.Parse(radGridView1.Rows[i].Cells[3].Value.ToString()) + int.Parse(radGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                //}
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
    }
}
