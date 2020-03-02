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
using Telerik.WinControls.UI;
using System.Linq;
using Telerik.Charting;

namespace SnappFood_Employee_Evaluation.After_Sales
{
    public partial class RPT_INBOUND_DASHBOARD : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public DataTable dt22 = new DataTable();
        public string DT_Day;
        public string DT_Mth;
        public string DT_Yr;
        public string DT_TM;

        public RPT_INBOUND_DASHBOARD()
        {
            InitializeComponent();

        }

        private void QC_GENERAL_REPORT_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;

            try
            {
                update_grid();
                update_gauge();
            }
            catch
            {
                Header.Text = "Error Detected!";
            }
            timer1.Interval = 1000;
            timer1.Start();
        }

        public void update_grid()
        {
            if (DateTime.Now >= Convert.ToDateTime("00:01:00") && DateTime.Now <= Convert.ToDateTime("08:01:00"))
            {

                Shifting_Page.Visible = true;
                if (Shifting_Page.Text.Length == 0)
                {
                    Shifting_Page.Text = "Waiting For New Shift Start...";
                }
                else
                {
                    Shifting_Page.Text = "";
                }

                Productivity.Text = "--";
                Ass_Back.Text = "--";
                Proc_Back.Text = "--";
                total_gauge.Value = 0;
                lbl_tot_inbound.Text = "--";
                radChartView2.Series.Clear();
                radChartView1.Series.Clear();
                timer1.Interval = 500;
            }
            else
            {

                timer1.Interval = 20000;
                Shifting_Page.Visible = false;

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

                Header.Text = "Date:" + "     " + DT_Yr + "/" + DT_Mth + "/" + DT_Day;


                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand();
                adp.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand = " SELECT ROW_NUMBER()over (order by convert(float,replace(t.productivity,'%','')) desc) 'Rank', t.* from (SELECT [Insrt_Usr] 'Agent', count(batch_no) 'QTY', " +
                                  "IIF(DATEDIFF(SECOND, min([In_TM]), Max([In_TM])) != 0 and count(batch_no) > 100, (CAST(round((convert(float, (count(batch_no) * 3600)) / convert(float, (IIF(min([In_TM]) > '05:00:00' AND min([In_TM]) < '11:00:00', '80', '174') * DATEDIFF(SECOND, min([In_TM]), Max([In_TM]))))) *100,2) AS nvarchar) +'%') , '0') 'Productivity' " +
                                  " FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where[in_dt_per] = '" + DT_Yr + "/" + DT_Mth + "/" + DT_Day + "' and[In_TM] >= '00:00:00' Group by[Insrt_Usr]) t ";
                adp.SelectCommand.CommandText = lcommand;
                dt22.Clear();
                adp.Fill(dt22);
                if (dt22.Rows.Count != 0)
                {
                    radGridView1.DataSource = dt22;

                    radGridView1.Columns[0].TextAlignment = ContentAlignment.TopCenter;
                    radGridView1.Columns[1].TextAlignment = ContentAlignment.TopCenter;
                    radGridView1.Columns[2].TextAlignment = ContentAlignment.TopCenter;
                    radGridView1.Columns[3].TextAlignment = ContentAlignment.TopCenter;

                    radGridView1.TableElement.RowHeight = 70;
                    radGridView1.TableElement.TableHeaderHeight = 60;
                    //radGridView1.Height = ((radGridView1.Rows.Count) * 70) + 60;
                    //radGridView1.Columns[0].BestFit();

                    /////////////////////////////////////////////////////////// UPDATE GAUGE
                    DataTable dt2 = new DataTable();
                    OleDbDataAdapter adp2 = new OleDbDataAdapter();
                    adp2.SelectCommand = new OleDbCommand();
                    adp2.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommand2 = " SELECT  IIF([Nature]= N'کوچک','Small','Large') 'Nature', count([Batch_no]) 'QTY' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [in_dt_per] = '" + DT_Yr + "/" + DT_Mth + "/" + DT_Day + "' Group By [Nature] order by QTY desc ";
                    adp2.SelectCommand.CommandText = lcommand2;
                    dt2.Clear();
                    adp2.Fill(dt2);
                    if (dt2.Rows.Count != 0)
                    {
                        /////////////////////////////////// Gauge Parameter Calculations
                        float tot_inbound = 0;
                        float tot_prodct = 0;

                        for (int i = 0; i < dt22.Rows.Count; i++)
                        {
                            tot_inbound = tot_inbound + int.Parse(dt22.Rows[i][2].ToString());
                            if (dt22.Rows[i][3].ToString() != "0%")
                            {
                                tot_prodct = tot_prodct + float.Parse(dt22.Rows[i][3].ToString().Replace("%", ""));
                            }
                        }
                        lbl_tot_inbound.Text = Math.Truncate(tot_inbound).ToString();

                        ////////////////////////////////////// config gauges
                        total_gauge.Value = (tot_inbound / ((dt22.Rows.Count) * 650)) * 100;
                        Productivity.Text = (Math.Round(tot_prodct / dt22.Rows.Count, 2)).ToString() + "%";

                        //////////////////////////////////////////////////// Total Monitoring
                        if (total_gauge.Value <= 50)
                        {
                            radialGaugeArc5.BackColor = Color.OrangeRed;
                            radialGaugeArc5.BackColor2 = Color.OrangeRed;
                            lbl_tot_inbound.ForeColor = Color.Red;
                            Productivity.ForeColor = Color.Red;
                        }
                        else if (total_gauge.Value <= 85)
                        {
                            radialGaugeArc5.BackColor = Color.Yellow;
                            radialGaugeArc5.BackColor2 = Color.Yellow;
                            lbl_tot_inbound.ForeColor = Color.Orange;
                            Productivity.ForeColor = Color.Orange;
                        }
                        else
                        {
                            radialGaugeArc5.BackColor = Color.LightGreen;
                            radialGaugeArc5.BackColor2 = Color.LightGreen;
                            lbl_tot_inbound.ForeColor = Color.Green;
                            Productivity.ForeColor = Color.Green;
                        }
                        ////////////////////////////////////////////////////////// Color code productivity
                        if (tot_prodct / dt22.Rows.Count <= 50)
                        {
                            radialGaugeArc5.BackColor = Color.OrangeRed;
                            radialGaugeArc5.BackColor2 = Color.OrangeRed;
                            lbl_tot_inbound.ForeColor = Color.Red;
                            Productivity.ForeColor = Color.Red;
                        }
                        else if (tot_prodct / dt22.Rows.Count <= 85)
                        {
                            radialGaugeArc5.BackColor = Color.Yellow;
                            radialGaugeArc5.BackColor2 = Color.Yellow;
                            lbl_tot_inbound.ForeColor = Color.Gold;
                            Productivity.ForeColor = Color.Gold;
                        }
                        else
                        {
                            radialGaugeArc5.BackColor = Color.LightGreen;
                            radialGaugeArc5.BackColor2 = Color.LightGreen;
                            lbl_tot_inbound.ForeColor = Color.Green;
                            Productivity.ForeColor = Color.Green;
                        }

                        //////////////////////////////////////////// NATURE
                        this.radChartView1.AreaType = ChartAreaType.Pie;
                        PieSeries series = new PieSeries();
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            series.DataPoints.Add(new PieDataPoint(int.Parse(dt2.Rows[i][1].ToString()), dt2.Rows[i][0].ToString()));
                        }
                        series.ShowLabels = true;
                        radChartView1.Series.Clear();
                        radChartView1.Series.Add(series);
                        radChartView1.Area.View.Palette = KnownPalette.Sun;

                        ////////////////////////////////////////////// ORIGIN
                        DataTable dt3 = new DataTable();
                        OleDbDataAdapter adp3 = new OleDbDataAdapter();
                        adp3.SelectCommand = new OleDbCommand();
                        adp3.SelectCommand.Connection = oleDbConnection1;
                        oleDbCommand1.Parameters.Clear();
                        string lcommand3 = " SELECT IIF([Origin]= N'ماهکس','Province',IIF([Origin]= N'پست','Post','Tehran')) 'Origin', count([Batch_no]) 'QTY' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [in_dt_per] = '" + DT_Yr + "/" + DT_Mth + "/" + DT_Day + "' Group By [Origin] order by QTY desc ";
                        adp3.SelectCommand.CommandText = lcommand3;
                        dt3.Clear();
                        adp3.Fill(dt3);

                        this.radChartView2.AreaType = ChartAreaType.Pie;
                        PieSeries series2 = new PieSeries();
                        for (int i = 0; i < dt3.Rows.Count; i++)
                        {
                            series2.DataPoints.Add(new PieDataPoint(int.Parse(dt3.Rows[i][1].ToString()), dt3.Rows[i][0].ToString()));
                        }
                        series2.ShowLabels = true;
                        radChartView2.Series.Clear();
                        radChartView2.Series.Add(series2);
                        radChartView2.Area.View.Palette = KnownPalette.Fluent;


                        ///////////////////////////////////////////// BACKLOG
                        DataTable dt4 = new DataTable();
                        OleDbDataAdapter adp4 = new OleDbDataAdapter();
                        adp4.SelectCommand = new OleDbCommand();
                        adp4.SelectCommand.Connection = oleDbConnection1;
                        oleDbCommand1.Parameters.Clear();
                        string lcommand4 = " SELECT SUM(CASE WHEN [REC] = 0 then 1 else 0 end) , SUM(CASE WHEN [Assigned_Rec] is null and [rec] = 0 and [nature] = N'کوچک' then 1 else 0 end) FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] ";
                        adp4.SelectCommand.CommandText = lcommand4;
                        dt4.Clear();
                        adp4.Fill(dt4);
                        Ass_Back.Text = dt4.Rows[0][1].ToString();
                        Proc_Back.Text = dt4.Rows[0][0].ToString();

                        int process = int.Parse(dt4.Rows[0][0].ToString());
                        int assign = int.Parse(dt4.Rows[0][1].ToString());

                        if (process <= 500)
                        {
                            Proc_Back.ForeColor = Color.Green;
                        }
                        else if (process > 500 && process <= 1000)
                        {
                            Proc_Back.ForeColor = Color.Orange;
                        }
                        else
                        {
                            Proc_Back.ForeColor = Color.Red;
                        }

                        if (assign <= 500)
                        {
                            Ass_Back.ForeColor = Color.Green;
                        }
                        else if (assign > 500 && assign <= 1000)
                        {
                            Ass_Back.ForeColor = Color.Orange;
                        }
                        else
                        {
                            Ass_Back.ForeColor = Color.Red;
                        }
                    }
                }

            }
        }

        public void update_gauge()
        {
            ////////////////////////////////////////// Get Date Persian
            //DataTable dt1 = new DataTable();
            //OleDbDataAdapter adp1 = new OleDbDataAdapter();
            //adp1.SelectCommand = new OleDbCommand();
            //adp1.SelectCommand.Connection = oleDbConnection1;
            //oleDbCommand1.Parameters.Clear();
            //string lcommand1 = "SELECT day(GETDATE()), month(GETDATE()), year(GETDATE()), CONVERT(time(0), CURRENT_TIMESTAMP) ";
            //adp1.SelectCommand.CommandText = lcommand1;
            //adp1.Fill(dt1);
            //DateTime datetime = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
            /////////////////////////////////////////// Convert Persian
            //PersianCalendar psdate = new PersianCalendar();
            //DT_Day = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            //DT_Mth = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            //DT_Yr = psdate.GetYear(datetime).ToString();
            //DT_TM = dt1.Rows[0][3].ToString().Substring(0, 5);

           
        }

        //private void Save_Click(object sender, EventArgs e)
        //{
        //    update_grid();
        //}


        private void QC_GENERAL_REPORT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                update_grid();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                update_grid();
                update_gauge();
            }
            catch
            {
                Header.Text = "Error Detected!";
            }
        }

        private System.Drawing.Font font1 = new System.Drawing.Font("Tahoma", 14, FontStyle.Bold);
        private void radChartView1_LabelFormatting(object sender, ChartViewLabelFormattingEventArgs e)
        {
            e.LabelElement.Font = font1;
            e.LabelElement.TextAlignment = ContentAlignment.MiddleCenter;
            PiePointElement element = (PiePointElement)e.LabelElement.Parent;
            PieDataPoint dataPoint = (PieDataPoint)element.DataPoint;
            e.LabelElement.Text = string.Format("{0}:{1}%", dataPoint.LegendTitle, Math.Round(dataPoint.Percent,0).ToString());
        }

        private System.Drawing.Font font2 = new System.Drawing.Font("Tahoma", 14, FontStyle.Bold);
        private void radChartView2_LabelFormatting(object sender, ChartViewLabelFormattingEventArgs e)
        {
            e.LabelElement.Font = font2;
            e.LabelElement.TextAlignment = ContentAlignment.MiddleCenter;
            PiePointElement element = (PiePointElement)e.LabelElement.Parent;
            PieDataPoint dataPoint = (PieDataPoint)element.DataPoint;
            e.LabelElement.Text = string.Format("{0}:{1}%", dataPoint.LegendTitle, Math.Round(dataPoint.Percent, 0).ToString());
        }
    }
}
