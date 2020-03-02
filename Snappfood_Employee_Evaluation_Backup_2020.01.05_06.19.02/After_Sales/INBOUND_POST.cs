using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using Telerik.WinControls.UI;
using System.Globalization;
using Stimulsoft.Report;
using Stimulsoft.Report.Win;
using Stimulsoft.Report.Components;
using Stimulsoft.Base;
using System.Drawing.Printing;


namespace SnappFood_Employee_Evaluation.After_Sales
{
    public partial class INBOUND_POST : Telerik.WinControls.UI.RadForm
    {
        public DataTable items = new DataTable();
        
        public string username;
        public string constr;
        public int last_row = 0;
        public int item_count = 0;
        public bool in_dbs = false;
        public List<string> in_dbs_arr = new List<string>();
        private ErrorProvider errorProvider;
        public string DT_Yr;
        public string DT_Mth;
        public string DT_Day;

        public INBOUND_POST()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            RadMessageBox.ThemeName = "Office2010Silver";
        }

        private void INBOUND_ITEM_Load(object sender, EventArgs e)
        {
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkvzF1o08hthhDtqY3mfT5D5YugnchRUILFmsJAH+MlystEun4HfKczPcJjASP/mnxJd9EgcqEEwKjl5OgcaUyPI807Lse0RyIQsNpWJQyh+EEy7hHxE0V24BdMYg7Es0aynDy6fBJ4b9Q/wLGbu3XML+fqEme2U9HCZcSdRZLJampqCua6C3pTXLKrfwph5cUSh02iMKXZFUum9dGAPTVg0t/k6JYEiTJ+zWkSkDYJQKUjRqd7c0ODs1eO/7qfbB5QLlA8EENysG+hwouUT6AuNXQwoewjfPgGQwA6RL8rbJGLlg7mGpoMpy2VJBeteZSAYwG8V8TyOrZSza7uVGzNDEiBBnMjGBTW8VztNiCD9OtsiK4Zjqe2tsM6JMWhbcfgV1min4H0y/qvBUKL2Zc+aWw8D09nJExn2OXDJKvT8Q==";
            ///////////////////////////////////////////////////////// initializing Training DT
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "سریال";
            items.Columns.Add(dc);
            DataColumn dc2 = new DataColumn();
            dc2.DataType = System.Type.GetType("System.String");
            dc2.ColumnName = "شناسه پست";
            items.Columns.Add(dc2);
            item_grid.DataSource = items;
            agent_nm.Text = username;
            oleDbConnection1.ConnectionString = constr;
            agent_nm.TextAlignment = ContentAlignment.MiddleLeft;
            item_qty.TextAlignment = ContentAlignment.MiddleLeft;
            item_nature.TextAlignment = ContentAlignment.MiddleLeft;
            batch_no.TextAlignment = ContentAlignment.MiddleLeft;
            //driver_dc.Left = (post.Location.X + post.Width) - driver_dc.Width - 8;
            //driver_dc_lbl.Top = post_lbl.Location.Y;

            //driver_dc.Top = post.Location.Y;
            item_qty.Text = item_count.ToString();
            ////////////////////////////////////////////////////////////////////////// Initiate origin Combo
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT '1' 'row','' 'item' union select '2' 'row', N'راننده' 'item' union select '3' 'row', N'ماهکس' 'item' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] order by [row] asc";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            //origin.DataSource = dtsc4;
            //origin.DisplayMember = "item";
        }

        string check_duplicate(string sn)
        {
            if (items.Rows.Count != 0)
            {
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    for (int j = 0; j < items.Columns.Count; j++)
                    {
                        if (items.Rows[i][j].ToString() == sn)
                        {
                            return "in_list";
                        }
                    }
                }

            }
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT [Item_SN] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [item_sn] = N'" + sn + "'";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            if (dtsc4.Rows.Count != 0)
            {
                return "in_db";
            }
            else
            {
                return "OK";
            }
        }



        private void INBOUND_ITEM_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            item_sn.Text = "";
            batch_no.Text = "";
            item_nature.Text = "";
            item_position.Text = "";
            //origin.SelectedIndex = 0;
            post.Text = "";
            //driver_dc.Text = "";
            last_row = 0;
            item_count = 0;
            item_qty.Text = item_count.ToString();
            items.Clear();
            in_dbs = false;
            in_dbs_arr.Clear();
            //driver_dc.Visible = false;
            //driver_dc_lbl.Visible = false;
            //post.Visible = false;
            //post_lbl.Visible = false;
           
            radMenuItem1.Enabled = true;
            item_sn.Focus();
        }

        private void item_position_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl.Text != "" && ActiveControl.Text.Length == 11)
            {
                if (ActiveControl.Text.Substring(0,2) == "LA")
                {
                    item_nature.Text = "بزرگ";
                }
                else
                {
                    item_nature.Text = "کوچک";
                }
            }
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            if (form_validation())
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
                DateTime persian_date = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
                ///////////////////////////////////////// Convert Persian
                PersianCalendar psdate = new PersianCalendar();
                DT_Day = (psdate.GetDayOfMonth(persian_date).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(persian_date).ToString() : psdate.GetDayOfMonth(persian_date).ToString();
                DT_Mth = (psdate.GetMonth(persian_date).ToString().Length == 1) ? "0" + psdate.GetMonth(persian_date).ToString() : psdate.GetMonth(persian_date).ToString();
                DT_Yr = psdate.GetYear(persian_date).ToString();

                //////////////////////////////////////// Get Batch No
                Get_Batch_No();
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] ([Batch_No],[Year],[Month],[Item_SN],[In_DT_Per],[In_DT],[In_TM],[Position],[Nature],[Origin],[Origin_NM],[Rec],[Insrt_Usr])" +
                                                " values (?,?,?,?,?,GETDATE(),GETDATE(),?,?,?,?,?,?)";
                    oleDbCommand1.Parameters.AddWithValue("@Batch_No", batch_no.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Year", DT_Yr);
                    oleDbCommand1.Parameters.AddWithValue("@Month", DT_Mth);
                    oleDbCommand1.Parameters.AddWithValue("@Item_SN", items.Rows[i][0].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@In_DT_Per", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                    oleDbCommand1.Parameters.AddWithValue("@Position", item_position.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Nature", item_nature.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Origin", "پست");
                    oleDbCommand1.Parameters.AddWithValue("@Origin_NM", items.Rows[i][1].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@REC", false);
                    oleDbCommand1.Parameters.AddWithValue("@Insrt_Usr", agent_nm.Text);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                        
                }
                    
                radMenuItem1.Enabled = false;

                ///////////////////////////////////////////////////// Update Status Table
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    
                    if (!in_dbs_arr.Contains(items.Rows[i][0].ToString()))
                    {
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] ([Item_SN],[Status],[ST_Per_Date],[ST_Date],[ST_Time],[ST_User],[ST_Expired])" +
                                                    " values (?,?,?,GETDATE(),GETDATE(),?,?)";
                        oleDbCommand1.Parameters.AddWithValue("@Batch_No", items.Rows[i][0].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Year", "دریافت کالا - در انتظار تخصیص به پذیرش");
                        oleDbCommand1.Parameters.AddWithValue("@Month", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                        oleDbCommand1.Parameters.AddWithValue("@Insrt_Usr", agent_nm.Text);
                        oleDbCommand1.Parameters.AddWithValue("@REC", false);

                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                    }
                    
                }
                RadMessageBox.Show(this, " سریال های وارد شده با شماره دریافت " + batch_no.Text + "با موفقیت ثبت شد! " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);

            }
        }

        public bool form_validation ()
        {
            bool error = false;
            errorProvider.Clear();

            if (item_count == 0)
            {
                this.errorProvider.SetError(this.item_qty, "هیچ آیتمی وارد نشده است.");
                error = true;
            }
            if (item_position.Text == "")
            {
                this.errorProvider.SetError(this.item_position, "جایگاه وارد نشده است.");
                error = true;
            }
            //if (!driver_dc.Visible && !post.Visible)
            //{
            //    this.errorProvider.SetError(this.origin, "مبدا انتخاب نشده است.");
            //    error = true;
            //}
            //if (driver_dc.Text == "" && post.Text == "")
            //{
            //    this.errorProvider.SetError(this.post, "شرح مبدا وارد نشده است.");
            //    this.errorProvider.SetError(this.driver_dc, "شرح مبدا وارد نشده است.");
            //    error = true;
            //}
            //if (item_nature.Text == "کوچک")
            //{
            //    DataTable dtsc4 = new DataTable();
            //    OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            //    adpsc4.SelectCommand = new OleDbCommand();
            //    adpsc4.SelectCommand.Connection = oleDbConnection1;
            //    oleDbCommand1.Parameters.Clear();
            //    string lcommandsc4 = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [Position] = N'" + item_position.Text + "' and [REC] = 0";
            //    adpsc4.SelectCommand.CommandText = lcommandsc4;
            //    adpsc4.Fill(dtsc4);
            //    if (dtsc4.Rows.Count != 0)
            //    {
            //        this.errorProvider.SetError(this.item_position, " این جایگاه خالی نیست. ");
            //        error = true;
            //    }
            //}
            if (error)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Get_Batch_No()
        {
            string DT_Yr2;
            string DT_Mth2;
            string DT_Day2;
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
            DT_Day2 = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            DT_Mth2 = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            DT_Yr2 = psdate.GetYear(datetime).ToString();//.Substring(1,1);
            //DT_TM = dt1.Rows[0][3].ToString().Substring(0, 5);
            ///////////////////////////////////////////////// GET QC_ID
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT max([batch_no]) FROM [SNAPP_CC_EVALUATION].[dbo].[AS_Inbound] where [Year] = '" + DT_Yr2 + "' and [Month] = '" + DT_Mth2 + "'";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            int batch_no_NO;
            if (dt4.Rows[0][0].ToString() == "")
            {
                batch_no.Text = DT_Yr2.Substring(2, 2) + DT_Mth2 + "0000";
            }
            else
            {
                batch_no_NO = int.Parse(dt4.Rows[0][0].ToString().Substring(4, 4)) + 1;
                if (batch_no_NO < 10)
                {
                    batch_no.Text = DT_Yr2.Substring(2, 2) + DT_Mth2 + "000" + batch_no_NO.ToString();
                }
                else if (batch_no_NO < 100)
                {
                    batch_no.Text = DT_Yr2.Substring(2, 2) + DT_Mth2 + "00" + batch_no_NO.ToString();
                }
                else if (batch_no_NO < 1000)
                {
                    batch_no.Text = DT_Yr2.Substring(2, 2) + DT_Mth2 + "0" + batch_no_NO.ToString();
                }
                else
                {
                    batch_no.Text = DT_Yr2.Substring(2, 2) + DT_Mth2 + batch_no_NO.ToString();
                }
            }
        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            if (check_duplicate(item_sn.Text) == "OK")
            {
                if ((item_sn.Text == "" && post.Text != ""))
                {
                    ///////////////////////////////////////////////// GET item_ID
                    DataTable dt4 = new DataTable();
                    OleDbDataAdapter adp4 = new OleDbDataAdapter();
                    adp4.SelectCommand = new OleDbCommand();
                    adp4.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommand4 = "SELECT substring(CONVERT(varchar(255), NEWID()),10,9)";
                    adp4.SelectCommand.CommandText = lcommand4;
                    adp4.Fill(dt4);
                    string item_id = dt4.Rows[0][0].ToString();

                    DataRow newrow = items.NewRow();
                    newrow["سریال"] = item_id;
                    if (post.Text != "")
                    {
                        newrow["شناسه پست"] = post.Text;
                    }
                    else
                    {
                        newrow["شناسه پست"] = "بدون شناسه";
                    }
                    items.Rows.Add(newrow);
                    item_sn.Text = "";
                    post.Text = "";
                    item_sn.Focus();
                    item_grid.BestFitColumns();
                    item_count++;
                    item_qty.Text = item_count.ToString();

                    StiReport report = new StiReport();
                    report.Load(Application.StartupPath + "\\REPORTS\\Label_Print.mrt");
                    report.Dictionary.Variables.Add("CD", item_id);
                    Stimulsoft.Report.Print.StiPrintProvider.SetPaperSource = false;
                    report.Render();
                    PrinterSettings printerSettings = new PrinterSettings();
                    //foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    //{
                    //    if (printer == "Godex G500")
                    //    {
                    //        printerSettings.PrinterName = "Godex G500";
                    //        return;
                    //    }
                    //    else
                    //    {

                    //    }
                    //}
                    printerSettings.PrinterName = "Godex G500";
                    report.Print(false, printerSettings);
                }
                if ((item_sn.Text == "" && post.Text == ""))
                {
                    RadMessageBox.Show(this, " هم سریال و هم بارکد پستی نباید با هم خالی باشد! " + "\n", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
                else
                {
                    DataRow newrow = items.NewRow();
                    newrow["سریال"] = item_sn.Text;
                    if (post.Text != "")
                    {
                        newrow["شناسه پست"] = post.Text;
                    }
                    else
                    {
                        newrow["شناسه پست"] = "بدون شناسه";
                    }
                    items.Rows.Add(newrow);
                    item_sn.Text = "";
                    post.Text = "";
                    item_sn.Focus();
                    item_grid.BestFitColumns();
                    item_count++;
                    item_qty.Text = item_count.ToString();
                }
            }
            else if (check_duplicate(item_sn.Text) == "in_db")
            {
                RadMessageBox.Show(this, " این سریال قبلا پذیرش شده است! " + "\n", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                item_sn.Text = "";
                post.Text = "";
                item_sn.Focus();
            }
            else
            {
                RadMessageBox.Show(this, " این سریال در این لیست وجود دارد! " + "\n", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                item_sn.Text = "";
                post.Text = "";
                item_sn.Focus();
            }
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            report.Load(Application.StartupPath + "\\REPORTS\\Label_Print.mrt");
            report.Dictionary.Variables.Add("CD", "Test");
            Stimulsoft.Report.Print.StiPrintProvider.SetPaperSource = false;
            report.Render();
            PrinterSettings printerSettings = new PrinterSettings();
            printerSettings.PrinterName = "Godex G500";
            report.Print(false, printerSettings);
        }
    }
}
