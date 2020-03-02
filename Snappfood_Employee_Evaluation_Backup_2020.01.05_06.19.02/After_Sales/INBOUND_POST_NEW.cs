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

namespace SnappFood_Employee_Evaluation.After_Sales
{
    public partial class INBOUND_POST_NEW : Telerik.WinControls.UI.RadForm
    {
        public DataTable items = new DataTable();
        
        public string username;
        public string constr;
        public int last_row = 0;
        public int item_count = 0;
        public int column_count = 1;
        public bool in_dbs = false;
        public List<string> in_dbs_arr = new List<string>();
        private ErrorProvider errorProvider;
        public string DT_Yr;
        public string DT_Mth;
        public string DT_Day;
        public string center;

        public INBOUND_POST_NEW()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            RadMessageBox.ThemeName = "Office2010Silver";
        }

        private void INBOUND_ITEM_Load(object sender, EventArgs e)
        {
            lbl_center.Text = center;
            RadMessageBox.ThemeName = "Office2010Silver";
            ///////////////////////////////////////////////////////// initializing Training DT
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "گروه1";
            items.Columns.Add(dc);

            DataColumn dc2 = new DataColumn();
            dc2.DataType = System.Type.GetType("System.String");
            dc2.ColumnName = "رسید1";
            items.Columns.Add(dc2);

            agent_nm.Text = username;
            oleDbConnection1.ConnectionString = constr;
            agent_nm.TextAlignment = ContentAlignment.MiddleLeft;
            item_qty.TextAlignment = ContentAlignment.MiddleLeft;
            item_nature.TextAlignment = ContentAlignment.MiddleLeft;
            batch_no.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_center.TextAlignment = ContentAlignment.MiddleLeft;
            //driver_dc.Left = (post.Location.X + post.Width) - driver_dc.Width - 8;
            //driver_dc_lbl.Top = post_lbl.Location.Y;

            //driver_dc.Top = post.Location.Y;
            item_qty.Text = item_count.ToString();
            //////////////////////////////////////////////////////////////////////////// Initiate origin Combo
            //DataTable dtsc4 = new DataTable();
            //OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            //adpsc4.SelectCommand = new OleDbCommand();
            //adpsc4.SelectCommand.Connection = oleDbConnection1;
            //oleDbCommand1.Parameters.Clear();
            //string lcommandsc4 = "SELECT '1' 'row','' 'item' union select '2' 'row', N'راننده' 'item' union select '3' 'row', N'ماهکس' 'item' union select '4' 'row', N'پست' 'item' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] order by [row] asc";
            //adpsc4.SelectCommand.CommandText = lcommandsc4;
            //adpsc4.Fill(dtsc4);
            //origin.DataSource = dtsc4;
            //origin.DisplayMember = "item";
        }

        string check_duplicate (string sn)
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
            string lcommandsc4 = "SELECT [Item_SN],DATEDIFF(day,[In_DT],getdate()) 'TT',[REC] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [item_sn] = N'" + sn + "' order by [TT] asc";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            if (dtsc4.Rows.Count != 0)
            {
                if (dtsc4.Rows[0][2].ToString() == "True")
                {
                    if (int.Parse(dtsc4.Rows[0][1].ToString()) <= 7)
                    {
                        return "duplicate<7";
                    }
                    else
                    {
                        return "duplicate>7";
                    }
                }
                else
                {
                    return "duplicate_NR";
                }
            }
            else
            {
                return "OK";
            }
        }

        private void INBOUND_ITEM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && item_sn.Text != "" && post.Text != "")
            {
                if (item_sn.Text.Length >= 8 & post.Text.Length >= 19)
                {
                    string result = check_duplicate(item_sn.Text);
                    
                    if (result == "OK" || result == "duplicate>7" || result == "duplicate<7" || result == "duplicate_NR") //////////////////////////////////////////////// Check duplicate
                    {
                        if (last_row % 20 == 0 && last_row != 0)
                        {
                            column_count++;
                            DataColumn dc = new DataColumn();
                            dc.DataType = System.Type.GetType("System.String");
                            dc.ColumnName = "گروه" + column_count.ToString();
                            items.Columns.Add(dc);

                            DataColumn dc2 = new DataColumn();
                            dc2.DataType = System.Type.GetType("System.String");
                            dc2.ColumnName = "رسید" + column_count.ToString();
                            items.Columns.Add(dc2);
                            last_row = 0;
                        }
                        if (items.Rows.Count <= 19)
                        {
                            DataRow newrow = items.NewRow();
                            items.Rows.Add(newrow);
                            item_grid.DataSource = items;
                        }
                        items.Rows[last_row][(2 * column_count) - 2] = item_sn.Text;
                        items.Rows[last_row][(2 * column_count) - 1] = post.Text;


                        if (result == "duplicate>7")
                        {
                            GridViewCellInfo cell = item_grid.Rows[last_row].Cells[items.Columns.Count - 1];
                            cell.Style.CustomizeFill = true;
                            cell.Style.BackColor = Color.LightGreen;
                            cell.Style.DrawFill = true;
                            GridViewCellInfo cell2 = item_grid.Rows[last_row].Cells[items.Columns.Count - 2];
                            cell2.Style.CustomizeFill = true;
                            cell2.Style.BackColor = Color.LightGreen;
                            cell2.Style.DrawFill = true;
                            //in_dbs = true;
                            //in_dbs_arr.Add(item_sn.Text);
                        }
                        if (result == "duplicate<7")
                        {
                            GridViewCellInfo cell = item_grid.Rows[last_row].Cells[items.Columns.Count - 1];
                            cell.Style.CustomizeFill = true;
                            cell.Style.BackColor = Color.Orange;
                            cell.Style.DrawFill = true;
                            GridViewCellInfo cell2 = item_grid.Rows[last_row].Cells[items.Columns.Count - 2];
                            cell2.Style.CustomizeFill = true;
                            cell2.Style.BackColor = Color.Orange;
                            cell2.Style.DrawFill = true;
                            in_dbs = true;
                            in_dbs_arr.Add(item_sn.Text);
                        }
                        if (result == "duplicate_NR")
                        {
                            GridViewCellInfo cell = item_grid.Rows[last_row].Cells[items.Columns.Count - 1];
                            cell.Style.CustomizeFill = true;
                            cell.Style.BackColor = Color.Red;
                            cell.Style.DrawFill = true;
                            GridViewCellInfo cell2 = item_grid.Rows[last_row].Cells[items.Columns.Count - 2];
                            cell2.Style.CustomizeFill = true;
                            cell2.Style.BackColor = Color.Red;
                            cell2.Style.DrawFill = true;
                            in_dbs = true;
                            in_dbs_arr.Add(item_sn.Text);
                        }
                        last_row++;
                        item_sn.Text = "";
                        post.Text = "";
                        item_sn.Focus();
                        item_grid.BestFitColumns();
                        item_count++;
                        item_qty.Text = item_count.ToString();
                    }
                    else
                    {
                        item_sn.Text = "";
                        post.Text = "";
                        item_sn.Focus();
                    }
                }
                else
                {
                    item_sn.Text = "";
                    post.Text = "";
                    item_sn.Focus();
                }
            }
            else if (e.KeyChar == (char)13 && post.Text != "" && item_sn.Text == "")
            {
                item_sn.Focus();
            }
            else if (e.KeyChar == (char)13 && post.Text == "" && item_sn.Text != "")
            {
                post.Focus();
            }
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            item_sn.Text = "";
            batch_no.Text = "";
            item_nature.Text = "";
            item_position.Text = "";
            batch_no.Visible = true;
            post.Text = "";

            last_row = 0;
            item_count = 0;
            item_qty.Text = item_count.ToString();
            items.Clear();
            items.Columns.Clear();
            in_dbs = false;
            in_dbs_arr.Clear();

            //post.Visible = false;
            //post_lbl.Visible = false;
            ///////////////////////////////////////////////////////// initializing Training DT
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "گروه1";
            items.Columns.Add(dc);

            DataColumn dc2 = new DataColumn();
            dc2.DataType = System.Type.GetType("System.String");
            dc2.ColumnName = "رسید1";
            items.Columns.Add(dc2);

            item_grid.DataSource = null;
            radMenuItem1.Enabled = true;
            item_sn.Focus();
        }

        private void item_position_TextChanged(object sender, EventArgs e)
        {
            if (item_position.Text != "" && item_position.Text.Length >= 4)
            {
                if (item_position.Text.Substring(0,2) == "LA")
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
            batch_no.Visible = true;
            if (form_validation())
            {
                List<string> conditions = new List<string>();
                string text_command = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] ([INBOUND_ID],[Batch_No],[Year],[Month],[Item_SN],[In_DT_Per],[In_DT],[In_TM],[Position],[Nature],[Origin],[Origin_NM],[REC],[Insrt_Usr],[center]) VALUES ";
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
                if (in_dbs) ///////////////////////////////////////////// Have Repeated item in DB
                {
                    DialogResult dialogResult = RadMessageBox.Show(this, " در لیست سریال ها، سریالی وجود دارد که قبلا دریافت شده است. " + "\n" + " آیا از ثبت اطمینان دارید؟ " + "\n", " هشدار ", MessageBoxButtons.YesNo, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //////////////////////////////////////// Get Batch No
                        Get_Batch_No();
                        for (int i = 0; i < items.Rows.Count; i++)
                        {
                            for (int j = 0; j < items.Columns.Count; j++)
                            {
                                if (j % 2 == 0)
                                {
                                    if (!in_dbs_arr.Contains(items.Rows[i][j].ToString()) && items.Rows[i][j].ToString() != "")
                                    {
                                        conditions.Add("('" + batch_no.Text + items.Rows[i][j].ToString() + "','" + batch_no.Text + "','" + DT_Yr + "','" + DT_Mth + "',N'" + items.Rows[i][j].ToString() + "','" + DT_Yr + "/" + DT_Mth + "/" + DT_Day + "', GETDATE(),GETDATE(),N'" + item_position.Text + "',N'" + item_nature.Text + "',N'پست',N'" + items.Rows[i][j + 1].ToString() + "',0,N'" + agent_nm.Text + "',N'" + center +"')");
                                    }
                                }
                            }
                        }
                        try
                        {
                            oleDbCommand1.Parameters.Clear();
                            if (conditions.Count != 0)
                            {
                                oleDbCommand1.CommandText = text_command + string.Join(" , ", conditions.ToArray());
                                oleDbConnection1.Open();
                                oleDbCommand1.ExecuteNonQuery();
                                oleDbConnection1.Close();
                            }
                            else
                            {
                                batch_no.Visible = false;
                                RadMessageBox.Show(this, "  کد خطا: 90  " + "\n\n" + "  سریالی جهت دریافت وجود ندارد. " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                            }
                        }
                        catch
                        {
                            batch_no.Visible = false;
                            RadMessageBox.Show(this, "  کد خطا: 100  " + "\n\n" + "  بروز خطای پیش بینی نشده. لطفا مجددا امتحان نمائید. " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                            return;
                        }
                    }
                }
                else ///////////////////////////////////////////////////////////////// No repeated item DB
                {
                    //////////////////////////////////////// Get Batch No
                    Get_Batch_No();
                    for (int i = 0; i < items.Rows.Count; i++)
                    {
                        for (int j = 0; j < items.Columns.Count; j++)
                        {
                            if (j % 2 == 0)
                            {
                                if (!in_dbs_arr.Contains(items.Rows[i][j].ToString()) && items.Rows[i][j].ToString() != "")
                                {
                                    conditions.Add("('" + batch_no.Text + items.Rows[i][j].ToString() + "','" + batch_no.Text + "','" + DT_Yr + "','" + DT_Mth + "',N'" + items.Rows[i][j].ToString() + "','" + DT_Yr + "/" + DT_Mth + "/" + DT_Day + "', GETDATE(),GETDATE(),N'" + item_position.Text + "',N'" + item_nature.Text + "',N'پست',N'" + items.Rows[i][j + 1].ToString() + "',0,N'" + agent_nm.Text + "',N'" + center + "')");
                                }
                            }
                        }
                    }
                    try
                    {
                        oleDbCommand1.Parameters.Clear();
                        if (conditions.Count != 0)
                        {
                            oleDbCommand1.CommandText = text_command + string.Join(" , ", conditions.ToArray());
                            oleDbConnection1.Open();
                            oleDbCommand1.ExecuteNonQuery();
                            oleDbConnection1.Close();
                        }
                        else
                        {
                            batch_no.Visible = false;
                            RadMessageBox.Show(this, "  کد خطا: 90  " + "\n\n" + "  سریالی جهت دریافت وجود ندارد. " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                        }
                    }
                    catch
                    {
                        batch_no.Visible = false;
                        RadMessageBox.Show(this, "  کد خطا: 100  " + "\n\n" + "  بروز خطای پیش بینی نشده. لطفا مجددا امتحان نمائید. " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                        return;
                    }
                }
                ///////////////////////////////////////////////////// Update Status Table
                List<string> conditions2 = new List<string>();
                string text_command2 = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] ([STATUS_KEY],[Item_SN],[Status],[ST_Per_Date],[ST_Date],[ST_Time],[ST_User],[ST_Expired]) VALUES ";
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    for (int j = 0; j < items.Columns.Count; j++)
                    {
                        if (j % 2 == 0)
                        {
                            if (!in_dbs_arr.Contains(items.Rows[i][j].ToString()))
                            {
                                if (items.Rows[i][j].ToString() != "")
                                {
                                    conditions2.Add("('" + batch_no.Text + items.Rows[i][j].ToString() + "',N'" + items.Rows[i][j].ToString() + "',N'" + (item_nature.Text == "کوچک" ? "دریافت کالا - در انتظار تخصیص به پذیرش" : "دریافت کالا - در انتظار پذیرش") + "','" + DT_Yr + "/" + DT_Mth + "/" + DT_Day + "', GETDATE(),GETDATE(),N'" + agent_nm.Text + "',0)");
                                }
                            }
                        }
                    }
                }
                try
                {
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = text_command2 + string.Join(" , ", conditions2.ToArray());
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                }
                catch
                {
                    batch_no.Visible = false;
                    try
                    {
                        oleDbConnection1.Close();
                    }
                    catch
                    {

                    }
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "DELETE FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] WHERE [BATCH_NO] = '" + batch_no.Text + "'";
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    RadMessageBox.Show(this, "  کد خطا: 102  " + "\n\n" + "  بروز خطای پیش بینی نشده. لطفا مجددا امتحان نمائید. " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    return;
                }
                RadMessageBox.Show(this, " سریال های وارد شده با شماره دریافت " + batch_no.Text + "با موفقیت ثبت شد! " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                radMenuItem1.Enabled = false;

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
            if (item_nature.Text == "")
            {
                this.errorProvider.SetError(this.item_nature, "ماهیت سبد قابل تشخیص نیست.");
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
            if (item_nature.Text == "کوچک")
            {
                DataTable dtsc4 = new DataTable();
                OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
                adpsc4.SelectCommand = new OleDbCommand();
                adpsc4.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommandsc4 = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [Position] = N'" + item_position.Text + "' and [REC] = 0";
                adpsc4.SelectCommand.CommandText = lcommandsc4;
                adpsc4.Fill(dtsc4);
                if (dtsc4.Rows.Count != 0)
                {
                    this.errorProvider.SetError(this.item_position, " این جایگاه خالی نیست. ");
                    error = true;
                }
            }
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

        private void item_grid_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            var item_status = new After_Sales.MNG_ITEM_STATUS();
            GridDataCellElement cell = item_grid.CurrentCell;
            item_status.item_sn.Text = cell.Value.ToString();
            item_status.item_sn.Visible = false;
            item_status.radLabel1.Visible = false;
            item_status.constr = constr;
            item_status.search();
            item_status.ShowDialog();
        }

        private void post_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
