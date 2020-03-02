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
using System.Threading;

namespace SnappFood_Employee_Evaluation.After_Sales
{
    public partial class RPT_REC_DASHBOARD : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public DataTable dt22 = new DataTable();
        public string DT_Day;
        public string DT_Mth;
        public string DT_Yr;
        public string DT_TM;
        public string center;

        public RPT_REC_DASHBOARD()
        {
            InitializeComponent();
            TAT2.TextAlign = ContentAlignment.MiddleCenter;
            TAT3.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void QC_GENERAL_REPORT_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            Header.TextAlign = ContentAlignment.MiddleRight;

            try
            {
                update_grid();
                update_gauge();
            }
            catch
            {
                Header.Text = "Error Detected!";
            }
            timer1.Interval = 10000;
            timer1.Start();
            timer2.Interval = 10000;
            timer2.Start();
        }

        public void update_grid()
        {
            if (DateTime.Now >= Convert.ToDateTime("23:55:00") && DateTime.Now <= Convert.ToDateTime("00:10:00"))
            {
                Shifting_Page.Visible = true;
                if (Shifting_Page.Text.Length == 0)
                {
                    Shifting_Page.Text = " همکاران عزیز، خسته نباشید " + "\n\n" + " در حال انجام محاسبات پایان روز... ";

                }
                else
                {
                    Shifting_Page.Text = "";
                }
                timer2.Stop();
                timer1.Interval = 700;
            }
            if (DateTime.Now >= Convert.ToDateTime("00:10:00") && DateTime.Now <= Convert.ToDateTime("08:02:00"))
            {
                Shifting_Page.Visible = true;
                if (Shifting_Page.Text.Length == 0)
                {
                    Shifting_Page.Text = " ...در حال انجام محاسبات روزانه ";

                }
                else
                {
                    Shifting_Page.Text = "";
                }
                timer2.Stop();
                timer1.Interval = 700;
            }
            else if (DateTime.Now >= Convert.ToDateTime("15:58:00") && DateTime.Now <= Convert.ToDateTime("16:03:00"))
            {
                Shifting_Page.Visible = true;
                if (Shifting_Page.Text.Length == 0)
                {
                    Shifting_Page.Text = " همکاران شیفت 1، خسته نباشید " + "\n\n" + " همکاران شیفت 2، خوش آمدید ";
                }
                else
                {
                    Shifting_Page.Text = "";
                }
                timer2.Stop();
                timer1.Interval = 700;
            }
            else
            {
                timer1.Interval = 20000;
                timer2.Interval = 20000;
                timer2.Start();
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
                string lcommand;
                if (DateTime.Now >= Convert.ToDateTime("07:00:00") && DateTime.Now <= Convert.ToDateTime("16:00:00"))
                {
                    radLabel1.Text = "DigiKala After Sales Live Dashboard - Processing   ** SHIFT 1 **";
                    lcommand =  "SELECT ROW_NUMBER() OVER(ORDER BY ROUND((Sel1.[Qty] / ((17*(Sel1.[Presence]*0.96))/60)) * 100,2) Desc) 'Rank' ,Sel1.[Agent], Sel1.[Qty], convert(nvarchar,ROUND((Sel1.[Qty] / ((17*(Sel1.[Presence]*0.96))/60)) * 100,2)) + '%' '% .Prod' FROM  " +
                                "(SELECT [Agent] ,convert(float,SUM(CASE WHEN [REC] = 1 AND ([Test_Result] = N'ارسال به انبار' OR  [Test_Result] = N'ارجاع به عودت') then 1 else 0 end))  " +
                                "+ convert(float,convert(float,SUM(CASE WHEN [REC] = 1 AND ([Test_Result] = N'ارجاع به تست فنی' ) then 1 else 0 end))/4) 'Qty' " +
                                ", DATEDIFF(MINUTE,Convert(time(0),'08:00:00'),Convert(time(0), getdate())) 'Presence' " +
                                "FROM [SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION] where [Insrt_DT_Per] = '" + DT_Yr + "/" + DT_Mth + "/" + DT_Day + "' and [Insrt_TM] <= '16:00:00' and [Insrt_TM] >= '07:00:00' and [RET_ITEM] = 0  and [Position] not Like 'LA%' group by [Agent]) Sel1";
                }
                else
                {
                    radLabel1.Text = "DigiKala After Sales Live Dashboard - Processing   ** SHIFT 2 **";
                    lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY ROUND((Sel1.[Qty] / ((17*(Sel1.[Presence]*0.96))/60)) * 100,2) Desc) 'Rank' ,Sel1.[Agent], Sel1.[Qty], convert(nvarchar,ROUND((Sel1.[Qty] / ((17*(Sel1.[Presence]*0.96))/60)) * 100,2)) + '%' '% .Prod' FROM  " +
                                "(SELECT [Agent] ,convert(float,SUM(CASE WHEN [REC] = 1 AND ([Test_Result] = N'ارسال به انبار' OR  [Test_Result] = N'ارجاع به عودت') then 1 else 0 end))  " +
                                "+ convert(float,convert(float,SUM(CASE WHEN [REC] = 1 AND ([Test_Result] = N'ارجاع به تست فنی' ) then 1 else 0 end))/4) 'Qty' " +
                                ", DATEDIFF(MINUTE,Convert(time(0),'16:00:00'),Convert(time(0), getdate())) 'Presence' " +
                                "FROM [SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION] where [Insrt_DT_Per] = '" + DT_Yr + "/" + DT_Mth + "/" + DT_Day + "' and [Insrt_TM] <= '23:59:59' and [Insrt_TM] >= '16:00:01' and [RET_ITEM] = 0  and [Position] not Like 'LA%' group by [Agent]) Sel1";
                }
                adp.SelectCommand.CommandText = lcommand;
                dt22.Clear();
                adp.Fill(dt22);
                if (dt22.Rows.Count != 0)
                {
                    radGridView1.DataSource = null;
                    radGridView1.DataSource = dt22;

                    radGridView1.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
                    radGridView1.Columns[1].TextAlignment = ContentAlignment.TopLeft;
                    radGridView1.Columns[2].TextAlignment = ContentAlignment.TopCenter;
                    radGridView1.Columns[3].TextAlignment = ContentAlignment.TopCenter;

                    radGridView1.Columns[0].Width = 15;
                    radGridView1.Columns[1].Width = 40;
                    radGridView1.Columns[2].Width = 25;
                    radGridView1.Columns[3].Width = 25;
                    //radGridView1.BestFitColumns();
                    /////////////////////////////////////////////////////////// Grid Color Coding
                    for (int i = 0; i<dt22.Rows.Count; i++)
                    {
                        if (double.Parse(dt22.Rows[i][3].ToString().Replace("%","")) >= 90)
                        {
                            GridViewCellInfo cell = radGridView1.Rows[i].Cells[0];
                            cell.Style.CustomizeFill = true;
                            cell.Style.BackColor = Color.LightGreen;
                            cell.Style.DrawFill = true;
                            GridViewCellInfo cell1 = radGridView1.Rows[i].Cells[1];
                            cell1.Style.CustomizeFill = true;
                            cell1.Style.BackColor = Color.LightGreen;
                            cell1.Style.DrawFill = true;
                            GridViewCellInfo cell2 = radGridView1.Rows[i].Cells[2];
                            cell2.Style.CustomizeFill = true;
                            cell2.Style.BackColor = Color.LightGreen;
                            cell2.Style.DrawFill = true;
                            GridViewCellInfo cell3 = radGridView1.Rows[i].Cells[3];
                            cell3.Style.CustomizeFill = true;
                            cell3.Style.BackColor = Color.LightGreen;
                            cell3.Style.DrawFill = true;
                        }
                    }

                }
            }

        }

        public void update_gauge()
        {
            if (DateTime.Now >= Convert.ToDateTime("00:01:00") && DateTime.Now <= Convert.ToDateTime("08:02:00"))
            {

            }
            else if (DateTime.Now >= Convert.ToDateTime("15:58:00") && DateTime.Now <= Convert.ToDateTime("16:03:00"))
            {
                
            }
            else
            {
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

                /////////////////////////////////////////////////////////// UPDATE GAUGE

                ///////////////////////////////////////////// TOTAL UINBOUND
                DataTable dt2 = new DataTable();
                OleDbDataAdapter adp2 = new OleDbDataAdapter();
                adp2.SelectCommand = new OleDbCommand();
                adp2.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand2 = " SELECT  [Insrt_Usr] , count([Batch_no]) FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [in_dt_per] = '" + DT_Yr + "/" + DT_Mth + "/" + DT_Day + "' group by [Insrt_Usr]";
                adp2.SelectCommand.CommandText = lcommand2;
                dt2.Clear();
                adp2.Fill(dt2);
                if (dt2.Rows.Count != 0)
                {
                    float tot_inbound = 0;
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        tot_inbound = tot_inbound + int.Parse(dt2.Rows[i][1].ToString());
                    }
                    lbl_tot_inbound.Text = Math.Truncate(tot_inbound).ToString();
                    ////////////////////////////////////// config gauges
                    total_gauge.Value = (tot_inbound / ((dt2.Rows.Count) * 900)) * 100;

                    //////////////////////////////////////////////////// Total Monitoring
                    if (total_gauge.Value <= 50)
                    {
                        radialGaugeArc3.BackColor = Color.OrangeRed;
                        radialGaugeArc3.BackColor2 = Color.OrangeRed;
                        lbl_tot_inbound.ForeColor = Color.Red;
                    }
                    else if (total_gauge.Value <= 85)
                    {
                        radialGaugeArc3.BackColor = Color.Yellow;
                        radialGaugeArc3.BackColor2 = Color.Yellow;
                        lbl_tot_inbound.ForeColor = Color.Orange;
                    }
                    else
                    {
                        radialGaugeArc3.BackColor = Color.YellowGreen;
                        radialGaugeArc3.BackColor2 = Color.YellowGreen;
                        lbl_tot_inbound.ForeColor = Color.Green;
                    }
                }

                ///////////////////////////////////////////// BACKLOG
                DataTable dt4 = new DataTable();
                OleDbDataAdapter adp4 = new OleDbDataAdapter();
                adp4.SelectCommand = new OleDbCommand();
                adp4.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand4 = " SELECT SUM(CASE WHEN [REC] = 0 then 1 else 0 end), SUM(CASE WHEN [REC] = 0 and [nature] = N'کوچک' then 1 else 0 end), SUM(CASE WHEN [REC] = 0 and [nature] = N'بزرگ' then 1 else 0 end) " +
                                   " , SUM(CASE WHEN [REC] = 0 and [Origin] = N'راننده' then 1 else 0 end), SUM(CASE WHEN [REC] = 0 and [Origin] = N'ماهکس' then 1 else 0 end), SUM(CASE WHEN [REC] = 0 and [Origin] = N'پست' then 1 else 0 end) FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] ";
                adp4.SelectCommand.CommandText = lcommand4;
                dt4.Clear();
                adp4.Fill(dt4);
                Proc_Back.Text = dt4.Rows[0][0].ToString();
                int backlog_qty = int.Parse(dt4.Rows[0][0].ToString());
                float tot_bk_ga = int.Parse(dt4.Rows[0][0].ToString());
                total_back_gauge.Value = (tot_bk_ga / 3200) * 100;

                if (backlog_qty <= 1000)
                {
                    Proc_Back.ForeColor = Color.Green;
                    radialGaugeArc1.BackColor = Color.YellowGreen;
                    radialGaugeArc1.BackColor2 = Color.YellowGreen;
                }
                else if (backlog_qty > 1000 && backlog_qty <= 2000)
                {
                    Proc_Back.ForeColor = Color.Orange;
                    radialGaugeArc1.BackColor = Color.Yellow;
                    radialGaugeArc1.BackColor2 = Color.Yellow;
                }
                else
                {
                    Proc_Back.ForeColor = Color.Red;
                    radialGaugeArc1.BackColor = Color.OrangeRed;
                    radialGaugeArc1.BackColor2 = Color.OrangeRed;
                }

                ///////////////////////////////////////////// Processed
                DataTable dt5 = new DataTable();
                OleDbDataAdapter adp5 = new OleDbDataAdapter();
                adp5.SelectCommand = new OleDbCommand();
                adp5.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand5 = " SELECT SUM(CASE WHEN [REC] = 1 and [Insrt_DT] = convert(date,getdate()) then 1 else 0 end), SUM(CASE WHEN [REC] = 1 and [Assign_Tech] = 1 and [Insrt_DT] = convert(date,getdate()) then 1 else 0 end) FROM [SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION] ";
                adp5.SelectCommand.CommandText = lcommand5;
                dt5.Clear();
                adp5.Fill(dt5);
                tot_proc.Text = dt5.Rows[0][0].ToString();
                int process = int.Parse(dt5.Rows[0][0].ToString());
                float tot_process_ga = int.Parse(dt5.Rows[0][0].ToString());
                total_process_gauge.Value = (tot_process_ga / 3200) * 100;

                if (process <= 1000)
                {
                    tot_proc.ForeColor = Color.Red;
                    radialGaugeArc5.BackColor = Color.OrangeRed;
                    radialGaugeArc5.BackColor2 = Color.OrangeRed;

                }
                else if (process > 1000 && process <= 2000)
                {
                    tot_proc.ForeColor = Color.Orange;
                    radialGaugeArc5.BackColor = Color.Yellow;
                    radialGaugeArc5.BackColor2 = Color.Yellow;
                }
                else
                {
                    tot_proc.ForeColor = Color.Green;
                    radialGaugeArc5.BackColor = Color.YellowGreen;
                    radialGaugeArc5.BackColor2 = Color.YellowGreen;
                }
                ///////////////////////////////////////////////////////////////////////// Assign Tech gauge

                //int ass_tech = int.Parse(dt5.Rows[0][1].ToString());
                //float ass_tech_ga = int.Parse(dt5.Rows[0][1].ToString());
                //total_gauge.Value = (ass_tech_ga / process) * 100;
                //lbl_tot_inbound.Text = dt5.Rows[0][1].ToString() + " (" + (Math.Floor((ass_tech_ga / process) * 100)).ToString() + "%)";

                //if (total_gauge.Value <= 10)
                //{
                //    lbl_tot_inbound.ForeColor = Color.Green;
                //    radialGaugeArc3.BackColor = Color.YellowGreen;
                //    radialGaugeArc3.BackColor2 = Color.YellowGreen;
                //}
                //else if (total_gauge.Value > 10 && total_gauge.Value <= 20)
                //{
                //    lbl_tot_inbound.ForeColor = Color.Orange;
                //    radialGaugeArc3.BackColor = Color.Yellow;
                //    radialGaugeArc3.BackColor2 = Color.Yellow;
                //}
                //else
                //{
                //    lbl_tot_inbound.ForeColor = Color.Red;
                //    radialGaugeArc3.BackColor = Color.OrangeRed;
                //    radialGaugeArc3.BackColor2 = Color.OrangeRed;
                //}


                if (dt4.Rows.Count != 0)
                {
                    ///////////////////////////////////////////////////////// Backlog by type
                    this.back_type.AreaType = ChartAreaType.Pie;
                    PieSeries series2 = new PieSeries();

                    series2.DataPoints.Add(new PieDataPoint(int.Parse(dt4.Rows[0][1].ToString()), "Small"));
                    series2.DataPoints.Add(new PieDataPoint(int.Parse(dt4.Rows[0][2].ToString()), "Large"));
                    series2.ShowLabels = true;
                    back_type.Series.Clear();
                    series2.SyncLinesToLabelsColor = true;
                    series2.DrawLinesToLabels = true;
                    this.back_type.Series.Add(series2);

                    series2.Children[0].BackColor = Color.Gray;
                    series2.Children[0].BorderColor = Color.Gray;
                    
                    series2.Children[1].BackColor = Color.Red;
                    series2.Children[1].BorderColor = Color.Red;


                }
                ////////////////////////////////////////////////////////////////////////// Processed TAT
                DataTable dt66 = new DataTable();
                OleDbDataAdapter adp66 = new OleDbDataAdapter();
                adp66.SelectCommand = new OleDbCommand();
                adp66.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand66 = " Select SUM(CASE WHEN [0~24] = 1 then 1 else 0 end) '< 24hrs', SUM(CASE WHEN [24~48] = 1 then 1 else 0 end) '24~48hrs', SUM(CASE WHEN [48~72] = 1 then 1 else 0 end) '48~72hrs', SUM(CASE WHEN [> 72] = 1 then 1 else 0 end) '> 72hrs' from " +
                                    "(Select DATEDIFF(hour, Sel2.[Inbound Date], Sel6.[Close Date]) 'TAT (h)', IIF(DATEDIFF(hour, Sel2.[Inbound Date], Sel6.[Close Date]) <= 24, '1', '0') AS '0~24', IIF(DATEDIFF(hour, Sel2.[Inbound Date], Sel6.[Close Date]) > 24 AND DATEDIFF(hour, Sel2.[Inbound Date], Sel6.[Close Date]) <= 48, '1', '0') '24~48', IIF(DATEDIFF(hour, Sel2.[Inbound Date], Sel6.[Close Date]) > 48 AND DATEDIFF(hour, Sel2.[Inbound Date], Sel6.[Close Date]) <= 72, '1', '0') '48~72', IIF(DATEDIFF(hour, Sel2.[Inbound Date], Sel6.[Close Date]) > 72, '1', '0') '> 72'   from( " +
                                    "(SELECT Distinct[STATUS_KEY], [Item_SN] FROM[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY]) Sel1 " +
                                    "left join(Select[STATUS_KEY], convert(nvarchar,[ST_Date]) + ' ' + convert(nvarchar,[ST_Time]) 'Inbound Date' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[Status] = N'دریافت کالا - در انتظار تخصیص به پذیرش' or[Status] = N'دریافت کالا - در انتظار پذیرش') Sel2 " +
                                    "on Sel1.[STATUS_KEY] = Sel2.[STATUS_KEY] " +
                                    "left join(Select[STATUS_KEY], convert(nvarchar,[ST_Date]) + ' ' + convert(nvarchar,[ST_Time]) 'Close Date' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[Status] = N'ارسال به انبار - در انتظار رسید انبار' or[Status] = N'ارجاع به عودت - در انتظار ارسال به مشتری') Sel6 " +
                                    "on Sel1.[STATUS_KEY] = Sel6.[STATUS_KEY]) where Sel1.[STATUS_KEY] is not null and Sel6.[Close Date] >= '"+ (datetime).ToString("yyyy-MM-dd") + "' and Sel6.[Close Date] <= '"+ (datetime.AddDays(1)).ToString("yyyy-MM-dd") + "') SelT ";
                adp66.SelectCommand.CommandText = lcommand66;
                dt66.Clear();
                adp66.Fill(dt66);
                if (dt66.Rows.Count != 0)
                {
                    double total = int.Parse(dt66.Rows[0][0].ToString()) + int.Parse(dt66.Rows[0][1].ToString()) + int.Parse(dt66.Rows[0][2].ToString()) + int.Parse(dt66.Rows[0][3].ToString());
                    this.back_channel.AreaType = ChartAreaType.Pie;
                    PieSeries series3 = new PieSeries();
                    
                    series3.DataPoints.Add(new PieDataPoint(int.Parse(dt66.Rows[0][0].ToString()), "< 24hrs")
                    { LegendTitle = "< 24hrs:     " + ((Math.Round(double.Parse(dt66.Rows[0][0].ToString()) / total, 4)) * 100).ToString() + "%"
                    });
                    
                    series3.DataPoints.Add(new PieDataPoint(int.Parse(dt66.Rows[0][1].ToString()), "24~48hrs")
                    { LegendTitle = "24~48hrs: " + ((Math.Round(double.Parse(dt66.Rows[0][1].ToString()) / total, 4)) * 100).ToString() + "%"
                    });
                    
                    series3.DataPoints.Add(new PieDataPoint(int.Parse(dt66.Rows[0][2].ToString()), "48~72hrs")
                    { LegendTitle = "48~72hrs: " + ((Math.Round(double.Parse(dt66.Rows[0][2].ToString()) / total, 4)) * 100).ToString() + "%"
                    });
                   
                    series3.DataPoints.Add(new PieDataPoint(int.Parse(dt66.Rows[0][3].ToString()), "> 72hrs")
                    { LegendTitle = "> 72hrs:     " + ((Math.Round(double.Parse(dt66.Rows[0][3].ToString()) / total, 4)) * 100).ToString() + "%" 
                    });

                    //series3.ShowLabels = true;
                    //series3.SyncLinesToLabelsColor = true;
                    //series3.DrawLinesToLabels = true;

                    back_channel.ShowLegend = true;
                    series3.RadiusFactor = 1.2F;
                    //AngleRange range = series3.Range;
                    //range.StartAngle = 45;
                    //series3.Range = range;

                    back_channel.Series.Clear();

                    this.back_channel.Series.Add(series3);
                    //this.back_channel.Area.View.Palette = KnownPalette.Fluent;
                    series3.Children[0].BackColor = Color.LightGreen;
                    series3.Children[0].BorderColor = Color.LightGreen;
                    series3.Children[1].BackColor = Color.Yellow;
                    series3.Children[1].BorderColor = Color.Yellow;
                    series3.Children[2].BackColor = Color.Orange;
                    series3.Children[2].BorderColor = Color.Orange;
                    series3.Children[3].BackColor = Color.Red;
                    series3.Children[3].BorderColor = Color.Red;
                }
                else
                {
                    back_channel.Series.Clear();
                }

                ////////////////////////////////////////////////////////////////////////// BACKLOG TAT
                ///////////////////////////////////////////// Processed
                DataTable dt6 = new DataTable();
                OleDbDataAdapter adp6 = new OleDbDataAdapter();
                adp6.SelectCommand = new OleDbCommand();
                adp6.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand6 = "Select SUM(CASE WHEN Sel1.[TAT] <= 1 then 1 else 0 end) " +
                                   ",SUM(CASE WHEN Sel1.[TAT] > 1 and  sel1.[TAT] <= 2 then 1 else 0 end) " +
                                   ",SUM(CASE WHEN Sel1.[TAT] > 2  then 1 else 0 end) from " +
                                   "(SELECT(convert(float, (DATEDIFF(MINUTE, convert(datetime, convert(nvarchar,[In_DT]) + ' ' + convert(nvarchar,[IN_TM])), getdate()))) / 60) / 24 AS TAT " +
                                   "FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where[rec] = 0) Sel1 ";
                adp6.SelectCommand.CommandText = lcommand6;
                dt6.Clear();
                adp6.Fill(dt6);
                if (dt6.Rows.Count != 0)
                {
                    //TAT1.Text = dt6.Rows[0][0].ToString() + " (" + (Math.Round(double.Parse(dt6.Rows[0][0].ToString()) / double.Parse(Proc_Back.Text), 4)) * 100 + "%)";
                    TAT2.Text = dt6.Rows[0][1].ToString() + " (" + (Math.Round(double.Parse(dt6.Rows[0][1].ToString()) / double.Parse(Proc_Back.Text), 4)) * 100 + "%)";
                    TAT3.Text = dt6.Rows[0][2].ToString() + " (" + (Math.Round(double.Parse(dt6.Rows[0][2].ToString()) / double.Parse(Proc_Back.Text), 4)) * 100 + "%)";
                }

                ///////////////////////////////////////////// BASKET QUEUE
                DataTable dt7 = new DataTable();
                OleDbDataAdapter adp7 = new OleDbDataAdapter();
                adp7.SelectCommand = new OleDbCommand();
                adp7.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand7 = "SELECT [Center],count(distinct [Position]) FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [Assigned_Rec] is null and [Nature] = N'کوچک' group by [center]";
                adp7.SelectCommand.CommandText = lcommand7;
                dt7.Clear();
                adp7.Fill(dt7);
                if (dt7.Rows.Count == 1)
                {
                    BS_IN_Q_G1.Text = "Basket In Q. -- " + dt7.Rows[0][0].ToString();
                    Bskt_Q_1.Text = dt7.Rows[0][1].ToString();
                    Bskt_Q_2.Text = "0";
                    BS_IN_Q_G1.Visible = true;
                    BS_IN_Q_G2.Visible = false;
                }
                else if (dt7.Rows.Count == 2)
                {
                    BS_IN_Q_G1.Visible = true;
                    BS_IN_Q_G2.Visible = true;
                    BS_IN_Q_G1.Text = "Basket In Q. -- " + dt7.Rows[0][0].ToString();
                    Bskt_Q_1.Text = dt7.Rows[0][1].ToString();
                    BS_IN_Q_G2.Text = "Basket In Q. -- " + dt7.Rows[1][0].ToString();
                    Bskt_Q_2.Text = dt7.Rows[1][1].ToString();
                }
                else
                {
                    BS_IN_Q_G1.Visible = true;
                    BS_IN_Q_G2.Visible = true;
                    Bskt_Q_1.Text = "0";
                    Bskt_Q_2.Text = "0";
                    BS_IN_Q_G1.Text = "Basket In Q. -- DHQ";
                    BS_IN_Q_G2.Text = "Basket In Q. -- ETD";
                }
                


                /////////////////////////////////////////////////////////////////////////// Tech data updation

                DataTable dt77 = new DataTable();
                OleDbDataAdapter adp77 = new OleDbDataAdapter();
                adp77.SelectCommand = new OleDbCommand();
                adp77.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand77 = " SELECT SUM(CASE WHEN [TECH] = 1 and [Insrt_DT] = convert(date,getdate()) then 1 else 0 end) FROM [SNAPP_CC_EVALUATION].[dbo].[AS_Technical] ";
                adp77.SelectCommand.CommandText = lcommand77;
                dt77.Clear();
                adp77.Fill(dt77);
                lbl_tech_proc.Text = "Done: " + dt77.Rows[0][0].ToString();
                float tech_ga = int.Parse(dt77.Rows[0][0].ToString());
                gg_tech_proc.Value = (tech_ga / 300) * 100;

                //////////////////////////////////////////////////// Total Monitoring
                if (gg_tech_proc.Value <= 50)
                {
                    radialGaugeArc7.BackColor = Color.OrangeRed;
                    radialGaugeArc7.BackColor2 = Color.OrangeRed;
                    lbl_tech_proc.ForeColor = Color.Red;
                }
                else if (gg_tech_proc.Value <= 85)
                {
                    radialGaugeArc7.BackColor = Color.Yellow;
                    radialGaugeArc7.BackColor2 = Color.Yellow;
                    lbl_tech_proc.ForeColor = Color.Orange;
                }
                else
                {
                    radialGaugeArc7.BackColor = Color.YellowGreen;
                    radialGaugeArc7.BackColor2 = Color.YellowGreen;
                    lbl_tech_proc.ForeColor = Color.Green;
                }

                ////////////////////////////////////////////////////////////////////////// BACKLOG TAT
                DataTable dt67 = new DataTable();
                OleDbDataAdapter adp67 = new OleDbDataAdapter();
                adp67.SelectCommand = new OleDbCommand();
                adp67.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand67 = "Select SUM(CASE WHEN Sel1.[TAT] <= 1 then 1 else 0 end) " +
                                   ",SUM(CASE WHEN Sel1.[TAT] > 1 and  sel1.[TAT] <= 2 then 1 else 0 end) " +
                                   ",SUM(CASE WHEN Sel1.[TAT] > 2  then 1 else 0 end) " +
                                   ",SUM(CASE WHEN Sel1.[TAT] <= 1 then 1 else 0 end) + SUM (CASE WHEN Sel1.[TAT] > 1 and sel1.[TAT] <= 2 then 1 else 0 end) + SUM(CASE WHEN Sel1.[TAT] > 2 then 1 else 0 end) from " +
                                   "(SELECT(convert(float, (DATEDIFF(MINUTE, convert(datetime, convert(nvarchar,[Insrt_DT]) + ' ' + convert(nvarchar,[Insrt_TM])), getdate()))) / 60) / 24 AS TAT  " +
                                   "FROM [SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION] where [rec] = 1 and [Assign_Tech] = 1 and [Tech] = 0) Sel1  ";
                adp67.SelectCommand.CommandText = lcommand67;
                dt67.Clear();
                adp67.Fill(dt67);
                if (dt67.Rows.Count != 0)
                {
                    //TAT1.Text = dt67.Rows[0][0].ToString() + " (" + (Math.Round(double.Parse(dt67.Rows[0][0].ToString()) / double.Parse(Proc_Back.Text), 4)) * 100 + "%)";
                    Tech_TAT2.Text = dt67.Rows[0][1].ToString() + " (" + (Math.Round(double.Parse(dt67.Rows[0][1].ToString()) / double.Parse(dt67.Rows[0][3].ToString()), 4)) * 100 + "%)";
                    Tech_TAT3.Text = dt67.Rows[0][2].ToString() + " (" + (Math.Round(double.Parse(dt67.Rows[0][2].ToString()) / double.Parse(dt67.Rows[0][3].ToString()), 4)) * 100 + "%)";
                    Pend_tech.Text = "Pending: " + dt67.Rows[0][3].ToString();
                }
            }
        }

        private void QC_GENERAL_REPORT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //update_grid();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radGridView1.Rows.Count > 17)
            {
                radGridView1.TableElement.ScrollToRow((radGridView1.Rows.Count) - 5);
                Thread.Sleep(50);
                radGridView1.Refresh();
                radGridView1.Update();
                radGridView1.TableElement.ScrollToRow((radGridView1.Rows.Count) - 4);
                Thread.Sleep(50);
                radGridView1.Refresh();
                radGridView1.Update();
                radGridView1.TableElement.ScrollToRow((radGridView1.Rows.Count) - 3);
                Thread.Sleep(50);
                radGridView1.Refresh();
                radGridView1.Update();
                radGridView1.TableElement.ScrollToRow((radGridView1.Rows.Count) - 2);
                Thread.Sleep(50);
                radGridView1.Refresh();
                radGridView1.Update();
                radGridView1.TableElement.ScrollToRow((radGridView1.Rows.Count) - 1);
                Thread.Sleep(5000);
                radGridView1.Refresh();
                radGridView1.Update();
                radGridView1.TableElement.ScrollToRow(5);
                Thread.Sleep(50);
                radGridView1.Refresh();
                radGridView1.Update();
                radGridView1.TableElement.ScrollToRow(4);
                Thread.Sleep(50);
                radGridView1.Refresh();
                radGridView1.Update();
                radGridView1.TableElement.ScrollToRow(3);
                Thread.Sleep(50);
                radGridView1.Refresh();
                radGridView1.Update();
                radGridView1.TableElement.ScrollToRow(2);
                Thread.Sleep(50);
                radGridView1.Refresh();
                radGridView1.Update();
                radGridView1.TableElement.ScrollToRow(1);
                Thread.Sleep(1);
                radGridView1.Refresh();
                radGridView1.Update();
            }
            
                update_grid();
                //update_gauge();
           
        }

        private System.Drawing.Font font1 = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);
        private void radChartView1_LabelFormatting(object sender, ChartViewLabelFormattingEventArgs e)
        {
            e.LabelElement.Font = font1;
            e.LabelElement.TextAlignment = ContentAlignment.MiddleCenter;
            e.LabelElement.BackColor = Color.Transparent;
            e.LabelElement.BorderColor = Color.Transparent;
            PiePointElement element = (PiePointElement)e.LabelElement.Parent;
            PieDataPoint dataPoint = (PieDataPoint)element.DataPoint;
            e.LabelElement.Text = string.Format("{0}:\n{1}%", dataPoint.LegendTitle, Math.Round(dataPoint.Percent,0).ToString());
        }

        private System.Drawing.Font font2 = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);
        private void radChartView2_LabelFormatting(object sender, ChartViewLabelFormattingEventArgs e)
        {
            e.LabelElement.Font = font2;
            e.LabelElement.BackColor = Color.Transparent;
            e.LabelElement.BorderColor = Color.Transparent;
            e.LabelElement.TextAlignment = ContentAlignment.MiddleCenter;
            PiePointElement element = (PiePointElement)e.LabelElement.Parent;
            PieDataPoint dataPoint = (PieDataPoint)element.DataPoint;
            e.LabelElement.Text = string.Format("{1}%", dataPoint.LegendTitle, Math.Round(dataPoint.Percent, 0).ToString());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                //update_grid();
                update_gauge();
            }
            catch
            {
                Header.Text = "Error Detected!";
            }
        }

        private void Bskt_Q_1_TextChanged(object sender, EventArgs e)
        {

            if ((int.Parse(Bskt_Q_1.Text) > 40) || (int.Parse(Bskt_Q_1.Text) < 5)) ///////////////////////// Red Area
            {
                Bskt_Q_1.ForeColor = Color.Red;
            }
            if ((int.Parse(Bskt_Q_1.Text) > 30 && int.Parse(Bskt_Q_1.Text) <= 40) || (int.Parse(Bskt_Q_1.Text) >= 5 && int.Parse(Bskt_Q_1.Text) < 10))///////////////////////// Yellow Area
            {
                Bskt_Q_1.ForeColor = Color.Orange;
            }
            if (int.Parse(Bskt_Q_1.Text) >= 10 && int.Parse(Bskt_Q_1.Text) <= 30) ///////////////////////// Green Area
            {
                Bskt_Q_1.ForeColor = Color.Green;
            }
        }

        private void Bskt_Q_2_TextChanged(object sender, EventArgs e)
        {
            if ((int.Parse(Bskt_Q_2.Text) > 40) || (int.Parse(Bskt_Q_2.Text) < 5)) ///////////////////////// Red Area
            {
                Bskt_Q_2.ForeColor = Color.Red;
            }
            if ((int.Parse(Bskt_Q_2.Text) > 30 && int.Parse(Bskt_Q_2.Text) <= 40) || (int.Parse(Bskt_Q_2.Text) >= 5 && int.Parse(Bskt_Q_2.Text) < 10))///////////////////////// Yellow Area
            {
                Bskt_Q_2.ForeColor = Color.Orange;
            }
            if (int.Parse(Bskt_Q_2.Text) >= 10 && int.Parse(Bskt_Q_2.Text) <= 30) ///////////////////////// Green Area
            {
                Bskt_Q_2.ForeColor = Color.Green;
            }
        }
    }
}
