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
    public partial class RPT_QC_PARAM_DETAILS : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public DataTable dt22 = new DataTable();

        public RPT_QC_PARAM_DETAILS()
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

            
        }

        public void update_grid()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();

            string lcommand = "SELECT Sel1.[Agent_Ext] 'داخلی', Sel2.[Department] 'واحد شغلی',Sel2.[Main_Shift] 'شیفت',Sel2.[Per_Name] 'اپراتور', Sel1.[Qty] 'تعداد لاگ', Sel1.[AVG Score] 'میانگین امتیاز کیفی', Sel1.[P1] 'Greeting', Sel1.[P2] 'Intro' " +
                              ", Sel1.[P3] 'Listening', Sel1.[P4] 'Holding', Sel1.[P5] 'Interuption', Sel1.[P6] 'Summarizing', Sel1.[P7] 'SPK Type', Sel1.[P8] 'SPK Tone', Sel1.[P9] 'FLW Process', Sel1.[P10] 'System' " +
                              ", Sel1.[P11] 'Query', Sel1.[P12] 'Closing' FROM ((SELECT [Agent_Ext], count([QC_ID]) 'Qty', round(AVG(convert(float,[QC_Score])),2,2) 'AVG Score', SUM(CASE WHEN [QC_Param_1] = 0 then 1 else 0 end) 'P1', SUM(CASE WHEN [QC_Param_2] = 0 then 1 else 0 end) 'P2' " +
                              ", SUM(CASE WHEN [QC_Param_3] = 0 then 1 else 0 end) 'P3' ,SUM(CASE WHEN [QC_Param_4] = 0 then 1 else 0 end)  'P4' ,SUM(CASE WHEN [QC_Param_1] = 0 then 1 else 0 end)  'P5' " +
                              ",SUM(CASE WHEN [QC_Param_1] = 0 then 1 else 0 end)  'P6' ,SUM(CASE WHEN [QC_Param_7] = 0 then 1 else 0 end)  'P7' ,SUM(CASE WHEN [QC_Param_8] = 0 then 1 else 0 end)  'P8' " +
                              ",SUM(CASE WHEN [QC_Param_9] = 0 then 1 else 0 end)  'P9' ,SUM(CASE WHEN [QC_Param_10] = 0 then 1 else 0 end) 'P10',SUM(CASE WHEN [QC_Param_11] = 0 then 1 else 0 end) 'P11' " +
                              ",SUM(CASE WHEN [QC_Param_12] = 0 then 1 else 0 end) 'P12' FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where [final_approval] = 1 " + (dt_from.Text == "" ? "" : (" AND [insrt_dt_per] >= N'" + dt_from.Text + "'")) + (dt_to.Text == "" ? "" : (" AND [insrt_dt_per] <= N'" + dt_to.Text + "'")) + " group by [Agent_Ext]) Sel1 " +
                              "left join (SELECT [System_Id],[Department],[Main_Shift],[Per_Name] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel2 on Sel1.[Agent_Ext] = Sel2.[System_Id])";

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
                radGridView1.Columns[8].TextAlignment = ContentAlignment.MiddleCenter;

                
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
