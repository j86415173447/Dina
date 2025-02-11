﻿using System;
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
    public partial class RPT_QC_DISPATCH : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public DataTable dt22 = new DataTable();

        public RPT_QC_DISPATCH()
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
            //string lcommand = "SELECT BSEL1.*,BSEL2.[AMW] from ((SELECT [QC_Agent] 'نام کارشناس',COUNT([QC_ID]) 'لاگ مانیتور شده',SUM(CASE WHEN [QC_Score]<=17 then 1 else 0 end) 'لاگ ناموفق',SUM(CASE WHEN [QC_Score]>17 then 1 else 0 end) 'لاگ موفق' " +
            //                  ",SUM(CASE WHEN[taboo] = 1 then 1 else 0 end) 'تابو',SUM(CASE WHEN [QC_M_Approval] != [Final_Approval] and[Final_Approval] is not null then 1 else 0 end) 'تغییر تائید',AVG([Handling_tm]) 'AHT' " +
            //                  ",SUM(CASE WHEN[CC_M_Aprv_Usr] = N'عدم تائید کیفی' then 1 else 0 end) 'عدم تائید کیفی',SUM([Handling_tm]) 'SHT' FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_ID] != 1  " + (dt_from.Text == "" ? "" : (" AND [insrt_dt_per] >= N'" + dt_from.Text + "'")) + (dt_to.Text == "" ? "" : (" AND [insrt_dt_per] <= N'" + dt_to.Text + "'")) + "  group by[QC_Agent]) BSEL1 " +
            //                  "left join(select Sel10.[QC_Agent], AVG(ABS(Sel10.[Handling_tm] - Sel20.[Len])) 'AMW' from((SELECT[QC_ID],[Handling_tm],[QC_Agent] FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_ID] != 1  " + (dt_from.Text == "" ? "" : (" AND [insrt_dt_per] >= N'" + dt_from.Text + "'")) + (dt_to.Text == "" ? "" : (" AND [insrt_dt_per] <= N'" + dt_to.Text + "'")) + " ) Sel10 " +
            //                  "left join(SELECT[QC_ID], sum((SUBSTRING([Voice_len], 1, 2) * 60) + SUBSTRING([Voice_len], 4, 2)) AS 'Len' FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_VOICES] group by[QC_ID]) Sel20 " +
            //                  "on Sel10.[QC_ID] = Sel20.[QC_ID]) group by Sel10.[QC_Agent]) BSEL2 on BSEL1.[نام کارشناس] = BSEL2.[QC_Agent])";
            string lcommand = "select Sel1.QC_Agent 'نام کارشناس', avg((SUBSTRING(sel2.[Voice_len],1,2)*60) + SUBSTRING(sel2.[Voice_len],4,2)) 'میانگین مدت مکالمه',max((SUBSTRING(sel2.[Voice_len],1,2)*60) + SUBSTRING(sel2.[Voice_len],4,2)) 'ماکزیمم مدت',min((SUBSTRING(sel2.[Voice_len],1,2)*60) + SUBSTRING(sel2.[Voice_len],4,2)) 'مینیمم مدت' " +
                              "  , count (sel1.[Qc_Agent]) 'تعداد مکالمات', SUM(CASE WHEN(SUBSTRING(sel2.[Voice_len], 1, 2) * 60) + SUBSTRING(sel2.[Voice_len], 4, 2) <= 30   then 1 else 0 end) '<30' " +
                              "  , SUM(CASE WHEN(SUBSTRING(sel2.[Voice_len], 1, 2) * 60) + SUBSTRING(sel2.[Voice_len], 4, 2) <= 60 and(SUBSTRING(sel2.[Voice_len], 1, 2) * 60) + SUBSTRING(sel2.[Voice_len], 4, 2) > 30   then 1 else 0 end) '>30 / <60' " +
                              "  , SUM(CASE WHEN(SUBSTRING(sel2.[Voice_len], 1, 2) * 60) + SUBSTRING(sel2.[Voice_len], 4, 2) <= 90 and(SUBSTRING(sel2.[Voice_len], 1, 2) * 60) + SUBSTRING(sel2.[Voice_len], 4, 2) > 60   then 1 else 0 end) '>60 / <90' " +
                              "  , SUM(CASE WHEN(SUBSTRING(sel2.[Voice_len], 1, 2) * 60) + SUBSTRING(sel2.[Voice_len], 4, 2) > 90   then 1 else 0 end) '>90' from ((SELECT[QC_ID],[QC_Agent] FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_ID] != 1  " + (dt_from.Text == "" ? "" : (" AND [insrt_dt_per] >= N'" + dt_from.Text + "'")) + (dt_to.Text == "" ? "" : (" AND [insrt_dt_per] <= N'" + dt_to.Text + "'")) + ") Sel1 " +
                              "  left join(select * from[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_VOICES]) Sel2 on Sel1.[QC_ID] = Sel2.QC_ID)  group by Sel1.[QC_Agent]";

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
