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

namespace SnappFood_Employee_Evaluation.After_Sales
{
    public partial class RPT_PROCESSING : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt22 = new DataTable();
        public DataTable dt23 = new DataTable();


        public RPT_PROCESSING()
        {
            InitializeComponent();
            RadMessageBox.SetThemeName("Office2010Silver");

            //in_dt_from.Culture = new System.Globalization.CultureInfo("en-EN");
            //in_dt_from.NullableValue = null;
            //in_dt_from.SetToNullValue();

            //in_dt_to.Culture = new System.Globalization.CultureInfo("fa-IR");
            //in_dt_to.NullableValue = null;
            //in_dt_to.SetToNullValue();
            result_count.TextAlignment = ContentAlignment.MiddleLeft;
        }

        private void PER_GENERAL_REPORT_Load(object sender, EventArgs e)
        {
            //emp_from_dt.Mask = emp_to_dt.Mask = "0000/00/00";
            oleDbConnection1.ConnectionString = constr;
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkvzF1o08hthhDtqY3mfT5D5YugnchRUILFmsJAH+MlystEun4HfKczPcJjASP/mnxJd9EgcqEEwKjl5OgcaUyPI807Lse0RyIQsNpWJQyh+EEy7hHxE0V24BdMYg7Es0aynDy6fBJ4b9Q/wLGbu3XML+fqEme2U9HCZcSdRZLJampqCua6C3pTXLKrfwph5cUSh02iMKXZFUum9dGAPTVg0t/k6JYEiTJ+zWkSkDYJQKUjRqd7c0ODs1eO/7qfbB5QLlA8EENysG+hwouUT6AuNXQwoewjfPgGQwA6RL8rbJGLlg7mGpoMpy2VJBeteZSAYwG8V8TyOrZSza7uVGzNDEiBBnMjGBTW8VztNiCD9OtsiK4Zjqe2tsM6JMWhbcfgV1min4H0y/qvBUKL2Zc+aWw8D09nJExn2OXDJKvT8Q==";
            ////////////////////////////////////////////////////////////////////////// Initiate origin Combo
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT '1' 'row','' 'item' union select '2' 'row', N'راننده' 'item' union select '3' 'row', N'ماهکس' 'item' union select '4' 'row', N'پست' 'item' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] order by [row] asc";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            Origin.DataSource = dtsc4;
            Origin.DisplayMember = "item";
            ///////////////////////////////////////////////////////// initializing Rec Combo
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT '' 'STATUS' union SELECT DISTINCT [Status] 'STATUS' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where [Status] != ''";
            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            latest_status.DataSource = dt2;
            latest_status.DisplayMember = "STATUS";
            ////////////////////////////////////////////////////////////////////////// Initiate Service Center
            DataTable dtsc44 = new DataTable();
            OleDbDataAdapter adpsc44 = new OleDbDataAdapter();
            adpsc44.SelectCommand = new OleDbCommand();
            adpsc44.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc44 = "SELECT '' 'Center' union SELECT DISTINCT [Center] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_AGENT_ROLE]";
            adpsc44.SelectCommand.CommandText = lcommandsc44;
            adpsc44.Fill(dtsc44);
            Center.DataSource = dtsc44;
            Center.DisplayMember = "Center";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            dt22.Clear();
            result_count.Text = "";
            grid.DataSource = null;
            pictureBox1.Visible = true;
            pictureBox1.Refresh();
            pictureBox1.Update();
            this.Refresh();
            this.Update();
            List<string> conditions = new List<string>();
            if (latest_status.Text != "")
            {
                conditions.Add("Sel7.[Last Status] = N'" + latest_status.Text + "'");
            }
            if (in_dt_from.Text != "")
            {
                conditions.Add("Sel2.[Inbound Date] >= N'" + in_dt_from.Text + " 00:00:00'");
            }
            if (in_dt_to.Text != "")
            {
                conditions.Add("Sel2.[Inbound Date] <= N'" + in_dt_to.Text + " 23:59:59'");
            }
            if (cl_dt_from.Text != "")
            {
                conditions.Add("Sel6.[Close Date] >= N'" + cl_dt_from.Text + " 00:00:00'");
            }
            if (cl_dt_to.Text != "")
            {
                conditions.Add("Sel6.[Close Date] <= N'" + cl_dt_to.Text + " 23:59:59'");
            }
            if (Origin.Text != "")
            {
                conditions.Add("Sel8.[Origin] = N'" + Origin.Text + "'");
            }
            if (Center.Text != "")
            {
                conditions.Add("Sel8.[Center] = N'" + Center.Text + "'");
            }
            if (tat1.Checked)
            {
                conditions.Add("DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) <= 24");
            }
            if (tat2.Checked)
            {
                conditions.Add("DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) > 24 AND DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) <= 48");
            }
            if (tat3.Checked)
            {
                conditions.Add("DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) > 48 AND DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) <= 72");
            }
            if (tat4.Checked)
            {
                conditions.Add("DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) > 72");
            }
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand =   "Select Sel1.[STATUS_KEY],Sel8.[Center] , Sel1.[Item_SN], Sel8.[Nature], Sel8.[Origin], Sel8.[Origin Description], Sel8.[Inbound User], Sel8.[Assign User], Sel9.[Receiption User], Sel9.[Assigned Tech User], Sel10.[Technical User], Sel2.[Inbound Date], Sel3.[Assign Date], Sel4.[Tech Assign Date], Sel5.[Seller Date], Sel6.[Close Date], Sel7.[Last Status], DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) 'TAT (h)', IIF(DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) <= 24, '1','0') AS '0~24', IIF(DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) > 24 AND DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) <= 48, '1','0') '24~48', IIF(DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) > 48 AND DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) <= 72, '1','0') '48~72', IIF(DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) > 72, '1','0') '> 72'   from ( " +
                                "(SELECT Distinct[STATUS_KEY], [Item_SN] FROM[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY]) Sel1 " +
                                "left join(Select[STATUS_KEY], convert(nvarchar,[ST_Date]) + ' ' + convert(nvarchar,[ST_Time]) 'Inbound Date' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[Status] = N'دریافت کالا - در انتظار تخصیص به پذیرش' or[Status] = N'دریافت کالا - در انتظار پذیرش') Sel2 " +
                                "on Sel1.[STATUS_KEY] = Sel2.[STATUS_KEY] " +
                                "left join (Select[STATUS_KEY], convert(nvarchar,[ST_Date]) + ' ' + convert(nvarchar,[ST_Time]) 'Assign Date' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[Status] = N'تخصیص به پذیرش - در انتظار پذیرش') Sel3 " +
                                "on Sel1.[STATUS_KEY] = Sel3.[STATUS_KEY] " +
                                "left join (Select[STATUS_KEY], convert(nvarchar,[ST_Date]) + ' ' + convert(nvarchar,[ST_Time]) 'Tech Assign Date' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[Status] = N'ارجاع به تست فنی - در انتظار تست فنی') Sel4 " +
                                "on Sel1.[STATUS_KEY] = Sel4.[STATUS_KEY] " +
                                "left join (Select[STATUS_KEY], convert(nvarchar,[ST_Date]) + ' ' + convert(nvarchar,[ST_Time]) 'Seller Date' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[Status] = N'ارجاع به فروشنده - در انتظار ارسال به فروشنده') Sel5 " +
                                "on Sel1.[STATUS_KEY] = Sel5.[STATUS_KEY] " +
                                "left join (Select[STATUS_KEY], convert(nvarchar,[ST_Date]) + ' ' + convert(nvarchar,[ST_Time]) 'Close Date' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[Status] = N'ارسال به انبار - در انتظار رسید انبار' or[Status] = N'ارجاع به عودت - در انتظار ارسال به مشتری') Sel6 " +
                                "on Sel1.[STATUS_KEY] = Sel6.[STATUS_KEY] " +
                                "left join (Select[STATUS_KEY],[Status] 'Last Status' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[st_expired] = 0) Sel7 " +
                                "on Sel1.[STATUS_KEY] = Sel7.[STATUS_KEY] " +
                                "left join (Select[INBOUND_ID], IIF([Nature] = N'بزرگ', 'Large', 'Small') 'Nature',[Insrt_Usr] 'Inbound User',[Origin],[Origin_NM] 'Origin Description',[Assigned_Rec] 'Assign User', [Center] From[SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND]) Sel8 " +
                                "on Sel1.[STATUS_KEY] = Sel8.[INBOUND_ID] " +
                                "left join(SELECT convert(nvarchar, [Batch_No]) + [Item_SN] 'REC_KEY',[Agent] 'Receiption User', [Technician] 'Assigned Tech User' FROM[SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION]) Sel9 " +
                                "on Sel1.[STATUS_KEY] = Sel9.[REC_KEY] " +
                                "left join(SELECT convert(nvarchar, [Batch_No]) + [Item_SN] 'TECH_KEY',[Agent] 'Technical User' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_TECHNICAL]) Sel10 " +
                                "on Sel1.[STATUS_KEY] = Sel10.[TECH_KEY]) where Sel1.[STATUS_KEY] is not null";
            if (conditions.Count != 0)
            {
                lcommand = lcommand + " AND " + string.Join(" AND ", conditions.ToArray());
            }
            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);
            grid.DataSource = dt22;
            grid.BestFitColumns();
            result_count.Text = dt22.Rows.Count.ToString("#,##0");
            pictureBox1.Visible = false;
        }

        private void Per_Dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt22.Clear();
            
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (grid.Rows.Count != 0)
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
                RadMessageBox.Show(this, "اطلاعاتی جهت ارسال به اکسل وجود ندارد", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error,MessageBoxDefaultButton.Button1,RightToLeft.Yes);
            }
        }

        private void driver_dc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt22.Clear();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            dt23.Clear();
            result_count.Text = "";
            grid.DataSource = null;
            pictureBox1.Visible = true;
            pictureBox1.Refresh();
            pictureBox1.Update();
            this.Refresh();
            this.Update();
            List<string> conditions = new List<string>();
            if (latest_status.Text != "")
            {
                conditions.Add("Sel7.[Last Status] = N'" + latest_status.Text + "'");
            }
            if (in_dt_from.Text != "")
            {
                conditions.Add("Sel2.[Inbound Date] >= N'" + in_dt_from.Text + "'");
            }
            if (in_dt_to.Text != "")
            {
                conditions.Add("Sel2.[Inbound Date] <= N'" + in_dt_to.Text + "'");
            }
            if (cl_dt_from.Text != "")
            {
                conditions.Add("Sel6.[Close Date] >= N'" + cl_dt_from.Text + "'");
            }
            if (cl_dt_to.Text != "")
            {
                conditions.Add("Sel6.[Close Date] <= N'" + cl_dt_to.Text + "'");
            }
            if (Origin.Text != "")
            {
                conditions.Add("Sel8.[Origin] = N'" + Origin.Text + "'");
            }
            if (tat1.Checked)
            {
                conditions.Add("DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) <= 24");
            }
            if (tat2.Checked)
            {
                conditions.Add("DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) > 24 AND DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) <= 48");
            }
            if (tat3.Checked)
            {
                conditions.Add("DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) > 48 AND DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) <= 72");
            }
            if (tat4.Checked)
            {
                conditions.Add("DATEDIFF(hour,Sel2.[Inbound Date],Sel6.[Close Date]) > 72");
            }
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "Select Count(Sel1.[STATUS_KEY]) 'Record Count' from ( " +
                                "(SELECT Distinct[STATUS_KEY], [Item_SN] FROM[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY]) Sel1 " +
                                "left join(Select[STATUS_KEY], convert(nvarchar,[ST_Date]) + ' ' + convert(nvarchar,[ST_Time]) 'Inbound Date' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[Status] = N'دریافت کالا - در انتظار تخصیص به پذیرش' or[Status] = N'دریافت کالا - در انتظار پذیرش') Sel2 " +
                                "on Sel1.[STATUS_KEY] = Sel2.[STATUS_KEY] " +
                                "left join (Select[STATUS_KEY], convert(nvarchar,[ST_Date]) + ' ' + convert(nvarchar,[ST_Time]) 'Assign Date' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[Status] = N'تخصیص به پذیرش - در انتظار پذیرش') Sel3 " +
                                "on Sel1.[STATUS_KEY] = Sel3.[STATUS_KEY] " +
                                "left join (Select[STATUS_KEY], convert(nvarchar,[ST_Date]) + ' ' + convert(nvarchar,[ST_Time]) 'Tech Assign Date' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[Status] = N'ارجاع به تست فنی - در انتظار تست فنی') Sel4 " +
                                "on Sel1.[STATUS_KEY] = Sel4.[STATUS_KEY] " +
                                "left join (Select[STATUS_KEY], convert(nvarchar,[ST_Date]) + ' ' + convert(nvarchar,[ST_Time]) 'Seller Date' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[Status] = N'ارجاع به فروشنده - در انتظار ارسال به فروشنده') Sel5 " +
                                "on Sel1.[STATUS_KEY] = Sel5.[STATUS_KEY] " +
                                "left join (Select[STATUS_KEY], convert(nvarchar,[ST_Date]) + ' ' + convert(nvarchar,[ST_Time]) 'Close Date' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[Status] = N'ارسال به انبار - در انتظار رسید انبار' or[Status] = N'ارجاع به عودت - در انتظار ارسال به مشتری') Sel6 " +
                                "on Sel1.[STATUS_KEY] = Sel6.[STATUS_KEY] " +
                                "left join (Select[STATUS_KEY],[Status] 'Last Status' From[SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where[st_expired] = 0) Sel7 " +
                                "on Sel1.[STATUS_KEY] = Sel7.[STATUS_KEY] " +
                                "left join (Select[INBOUND_ID], IIF([Nature] = N'بزرگ', 'Large', 'Small') 'Nature',[Insrt_Usr] 'Inbound User',[Origin],[Origin_NM] 'Origin Description',[Assigned_Rec] 'Assign User' From[SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND]) Sel8 " +
                                "on Sel1.[STATUS_KEY] = Sel8.[INBOUND_ID] " +
                                "left join(SELECT convert(nvarchar, [Batch_No]) + [Item_SN] 'REC_KEY',[Agent] 'Receiption User' FROM[SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION]) Sel9 " +
                                "on Sel1.[STATUS_KEY] = Sel9.[REC_KEY] " +
                                "left join(SELECT convert(nvarchar, [Batch_No]) + [Item_SN] 'TECH_KEY',[Agent] 'Technical User' FROM[SNAPP_CC_EVALUATION].[dbo].[AS_TECHNICAL]) Sel10 " +
                                "on Sel1.[STATUS_KEY] = Sel10.[TECH_KEY]) where Sel1.[STATUS_KEY] is not null";
            if (conditions.Count != 0)
            {
                lcommand = lcommand + " AND " + string.Join(" AND ", conditions.ToArray());
            }
            adp.SelectCommand.CommandText = lcommand;
            dt23.Clear();
            adp.Fill(dt23);
            grid.DataSource = dt23;
            grid.BestFitColumns();
            int temp = int.Parse(dt23.Rows[0][0].ToString());
            result_count.Text = temp.ToString("#,##0");
            pictureBox1.Visible = false;
        }
    }
}
