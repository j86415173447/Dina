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
using System.Globalization;

namespace SnappFood_Employee_Evaluation.QC
{
    public partial class RPT_QC_DASHBOARD : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public DataTable dt22 = new DataTable();
        public string DT_Day;
        public string DT_Mth;
        public string DT_Yr;
        public string DT_TM;

        public RPT_QC_DASHBOARD()
        {
            InitializeComponent();
        }

        private void QC_GENERAL_REPORT_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            //dt_from.Culture = new System.Globalization.CultureInfo("fa-IR");
            //dt_from.NullableValue = null;
            //dt_from.SetToNullValue();

            //dt_to.Culture = new System.Globalization.CultureInfo("fa-IR");
            //dt_to.NullableValue = null;
            //dt_to.SetToNullValue();
            update_grid();
            update_gauge();

            
            //////////////////////////////////////// Get Date Persian
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT day(GETDATE()), month(GETDATE()), year(GETDATE()), CONVERT(time(0), CURRENT_TIMESTAMP) ";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            DateTime datetime = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
            ///////////////////////////////////////// Convert Persian
            PersianCalendar psdate = new PersianCalendar();
            DT_Day = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            DT_Mth = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            DT_Yr = psdate.GetYear(datetime).ToString();
            DT_TM = dt1.Rows[0][3].ToString().Substring(0, 5);

            Header.Text = Header.Text + "     " + DT_Yr + "/" + DT_Mth + "/" + DT_Day;

            timer1.Interval = 3000;
            timer1.Start();


        }

        public void update_grid()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            //string lcommand = "SELECT BSEL1.*,BSEL2.[AMW] from ((SELECT [QC_Agent] 'نام کارشناس',COUNT([QC_ID]) 'لاگ مانیتور شده',SUM(CASE WHEN [QC_Score]<=17 then 1 else 0 end) 'لاگ ناموفق',SUM(CASE WHEN [QC_Score]>17 then 1 else 0 end) 'لاگ موفق' " +
            //                  ",SUM(CASE WHEN[taboo] = 1 then 1 else 0 end) 'تابو',SUM(CASE WHEN[QC_M_Approval] != [Final_Approval] and[Final_Approval] is not null then 1 else 0 end) 'تغییر تائید',AVG([Handling_tm]) 'AHT' " +
            //                  ",SUM(CASE WHEN[CC_M_Aprv_Usr] = N'عدم تائید کیفی' then 1 else 0 end) 'عدم تائید کیفی',SUM([Handling_tm]) 'SHT' FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_ID] != 1 AND [insrt_dt] = convert(date, getdate(), 111) group by[QC_Agent]) BSEL1 " +
            //                  "left join(select Sel10.[QC_Agent], AVG(ABS(Sel10.[Handling_tm] - Sel20.[Len])) 'AMW' from((SELECT[QC_ID],[Handling_tm],[QC_Agent] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_ID] != 1 AND [insrt_dt] = convert(date, getdate(), 111) ) Sel10 " +
            //                  "left join(SELECT[QC_ID], sum((SUBSTRING([Voice_len], 1, 2) * 60) + SUBSTRING([Voice_len], 4, 2)) AS 'Len' FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_VOICES] group by[QC_ID]) Sel20 " +
            //                  "on Sel10.[QC_ID] = Sel20.[QC_ID]) group by Sel10.[QC_Agent]) BSEL2 on BSEL1.[نام کارشناس] = BSEL2.[QC_Agent]) order by BSEL1.[لاگ مانیتور شده] desc";

            string lcommand = "SELECT BSEL1.*,BSEL2.[AMW] from ((SELECT [QC_Agent] 'نام کارشناس',COUNT([QC_ID]) 'لاگ مانیتور شده',SUM(CASE WHEN [QC_Score]<=17 then 1 else 0 end) 'لاگ ناموفق',SUM(CASE WHEN [QC_Score]>17 then 1 else 0 end) 'لاگ موفق' " +
                              ",SUM(CASE WHEN[taboo] = 1 then 1 else 0 end) 'تابو' " +
                              ",SUM(CASE WHEN[CC_M_Aprv_Usr] = N'عدم تائید کیفی' then 1 else 0 end) 'عدم تائید کیفی',AVG([Handling_tm]) 'AHT' FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_ID] != 1 AND [insrt_dt] = convert(date, getdate(), 111) group by[QC_Agent]) BSEL1 " +
                              "left join(select Sel10.[QC_Agent], AVG(ABS(Sel10.[Handling_tm] - Sel20.[Len])) 'AMW' from((SELECT[QC_ID],[Handling_tm],[QC_Agent] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_ID] != 1 AND [insrt_dt] = convert(date, getdate(), 111) ) Sel10 " +
                              "left join(SELECT[QC_ID], sum((SUBSTRING([Voice_len], 1, 2) * 60) + SUBSTRING([Voice_len], 4, 2)) AS 'Len' FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_VOICES] group by[QC_ID]) Sel20 " +
                              "on Sel10.[QC_ID] = Sel20.[QC_ID]) group by Sel10.[QC_Agent]) BSEL2 on BSEL1.[نام کارشناس] = BSEL2.[QC_Agent]) order by BSEL1.[لاگ مانیتور شده] desc";

            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);
            if (dt22.Rows.Count != 0)
            {
                radGridView1.DataSource = dt22;
                //radGridView1.BestFitColumns();

                radGridView1.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[7].TextAlignment = ContentAlignment.MiddleCenter;


                radGridView1.TableElement.RowHeight = 60;
                radGridView1.TableElement.TableHeaderHeight = 70;
                //for (int i = 0; i < radGridView1.Rows.Count; i++)
                //{
                //    radGridView1.Rows[i].Cells[1].Value = (int.Parse(radGridView1.Rows[i].Cells[2].Value.ToString()) + int.Parse(radGridView1.Rows[i].Cells[3].Value.ToString()) + int.Parse(radGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                //}
            }
            else
            {
                //RadMessageBox.Show(this, "مطابق با شرایط جستجو، موردی یافت نشد." + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        public void update_gauge()
        {
            /////////////////////////////////// Parameter Calculations
            float tot_monitored = 0;
            float tot_aht = 0;
            float tot_amw = 0;

            for (int i = 0; i < dt22.Rows.Count; i++)
            {
                tot_monitored = tot_monitored + int.Parse(dt22.Rows[i][1].ToString());
                tot_aht = tot_aht + int.Parse(dt22.Rows[i][6].ToString());
                tot_amw = tot_amw + int.Parse(dt22.Rows[i][7].ToString());
            }

            tot_aht = tot_aht / dt22.Rows.Count;
            tot_amw = tot_amw / dt22.Rows.Count;

            lbl_tot_monitored.Text = tot_monitored.ToString();
            lbl_tot_aht.Text = tot_aht.ToString();
            lbl_tot_amw.Text = tot_amw.ToString();

            ////////////////////////////////////// config gauges
            total_gauge.Value = (tot_monitored/350)*100;
            amw_gauge.Value = (tot_amw/60)*100;
            aht_gauge.Value = (tot_aht/250)*100;

            //total_gauge.RangeStart = 0;
            //total_gauge.RangeEnd = 350;


            //amw_gauge.RangeStart = 5;
            //amw_gauge.RangeEnd = 60;

            //aht_gauge.RangeStart = 100;
            //aht_gauge.RangeEnd = 250;
            //////////////////////////////////////////////////// Total Monitoring
            if (total_gauge.Value <= 30)
            {
                radialGaugeArc5.BackColor = Color.Red;
                radialGaugeArc5.BackColor2 = Color.Red;
            }
            else if (total_gauge.Value <= 60)
            {
                radialGaugeArc5.BackColor = Color.Yellow;
                radialGaugeArc5.BackColor2 = Color.Yellow;
            }
            else
            {
                radialGaugeArc5.BackColor = Color.Green;
                radialGaugeArc5.BackColor2 = Color.Green;
            }
            /////////////////////////////////////////////////// AMW Coloring
            if (amw_gauge.Value <= 30)
            {
                radialGaugeArc1.BackColor = Color.Green;
                radialGaugeArc1.BackColor2 = Color.Green;
            }
            else if (amw_gauge.Value <= 50)
            {
                radialGaugeArc1.BackColor = Color.Yellow;
                radialGaugeArc1.BackColor2 = Color.Yellow;
            }
            else
            {
                radialGaugeArc1.BackColor = Color.Red;
                radialGaugeArc1.BackColor2 = Color.Red;
            }
            //////////////////////////////////////////////////// AHT Coloring
            if (aht_gauge.Value <= 40)
            {
                radialGaugeArc3.BackColor = Color.Green;
                radialGaugeArc3.BackColor2 = Color.Green;
            }
            else if (aht_gauge.Value <= 60)
            {
                radialGaugeArc3.BackColor = Color.Yellow;
                radialGaugeArc3.BackColor2 = Color.Yellow;
            }
            else
            {
                radialGaugeArc3.BackColor = Color.Red;
                radialGaugeArc3.BackColor2 = Color.Red;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            update_grid();
            update_gauge();
        }
    }
}
