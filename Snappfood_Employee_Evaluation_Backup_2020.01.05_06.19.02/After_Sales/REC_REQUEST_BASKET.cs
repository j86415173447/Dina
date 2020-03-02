using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using System.Globalization;
using System.Threading;

namespace SnappFood_Employee_Evaluation.After_Sales
{
    public partial class REC_REQUEST_BASKET : Telerik.WinControls.UI.RadForm
    {
        public string username;
        public string constr;
        public string center;

        public REC_REQUEST_BASKET()
        {
            InitializeComponent();
            this.Size = new Size(600, 200);
            RadMessageBox.ThemeName = "Office2010Silver";
        }

        private void REC_REQUEST_BASKET_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            RadMessageBox.ThemeName = "Office2010Silver";

            //////////////////////////////////////////////////// Get User role
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT [AS_Role_NM] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_AGENT_ROLE] where [AS_AGENT_NM] = N'" + username + "'";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            if (dtsc4.Rows.Count == 0) /////////////////////////////////////////// No Role
            {
                RadMessageBox.Show(this, " نقش شما تعریف نشده است! " + "\n", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                string role = dtsc4.Rows[0][0].ToString();
                switch (role)
                {
                    case "کارشناس پذیرش کالاهای کوچک":
                        Small_Assign();
                        break;
                    case "کارشناس پذیرش کالاهای بزرگ":
                        Large_Assign();
                        break;
                    case "کارشناس پذیرش کالاهای پست":
                        Post_Assign();
                        break;
                    default:
                        basket_no.Visible = true;
                        basket_no.Text = "شما به این بخش دسترسی ندارید! :(";
                        break;
                }
            }
        }
        public void Small_Assign()
        {
            ///////////////////////////////////// Check Agents Panel
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [Assigned_Rec] = N'" + username + "' and REC = 0";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            if (dtsc4.Rows.Count != 0)
            {
                ///////////////////////////////// You have an open bascket.
                basket_no.Visible = true;
                basket_no.Text = "هنوز همه ی کالاهای سبد قبلی را پذیرش نکردید! :(";
            }
            else
            {
                DataTable dtsc5 = new DataTable();
                OleDbDataAdapter adpsc5 = new OleDbDataAdapter();
                adpsc5.SelectCommand = new OleDbCommand();
                adpsc5.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.Parameters.Clear();
                string lcommandsc5 = "SELECT [Batch_No],[Position],min([In_DT_Per]) AS 'DT',min([In_TM]) AS 'TM' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [Assigned_Rec] is null and [Nature] = N'کوچک' and [Center] = N'" + center + "' group by [Batch_No],[Position] order by [Batch_No] asc";
                adpsc5.SelectCommand.CommandText = lcommandsc5;
                adpsc5.Fill(dtsc5);
                if (dtsc5.Rows.Count == 0)
                {
                    //////////////////////////////////////// NO bascket Available to Assign
                    basket_no.Visible = true;
                    basket_no.Text = "سبدی جهت تخصیص وجود ندارد! :)";
                }
                else
                {
                    lbl.Visible = true;
                    basket_no.Visible = true;
                    lbl.Text = "سبد تخصیص یافته به شما:";
                    basket_no.Text = dtsc5.Rows[0][1].ToString();
                    string batch_no = dtsc5.Rows[0][0].ToString();
                    Assign(batch_no);
                }
            }
        }

        public void Large_Assign()
        {
            ///////////////////////////////////// Check Agents Panel
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [NAture] = N'بزرگ' and REC = 0 and [Center] = N'" + center + "'";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            if (dtsc4.Rows.Count != 0)
            {
                ///////////////////////////////// You have an open bascket.
                basket_no.Visible = true;
                basket_no.Text = "هنوز همه ی کالاهای بزرگ پذیرش نشده است! :(";
            }
            else
            {
                Small_Assign();
            }
        }

        public void Post_Assign()
        {
            ///////////////////////////////////// Check Agents Panel
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [Assigned_Rec] = N'" + username + "' and REC = 0";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            if (dtsc4.Rows.Count != 0)
            {
                ///////////////////////////////// You have an open bascket.
                basket_no.Visible = true;
                basket_no.Text = "هنوز همه ی کالاهای سبد قبلی را پذیرش نکردید! :(";
            }
            else
            {
                DataTable dtsc5 = new DataTable();
                OleDbDataAdapter adpsc5 = new OleDbDataAdapter();
                adpsc5.SelectCommand = new OleDbCommand();
                adpsc5.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.Parameters.Clear();
                string lcommandsc5 = "SELECT [Batch_No],[Position],min([In_DT_Per]) AS 'DT',min([In_TM]) AS 'TM' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [Assigned_Rec] is null and [Nature] = N'کوچک' and [Origin] = N'پست' and [Center] = N'" + center + "' group by [Batch_No],[Position] order by [Batch_No] asc";
                adpsc5.SelectCommand.CommandText = lcommandsc5;
                adpsc5.Fill(dtsc5);
                if (dtsc5.Rows.Count == 0)
                {
                    Small_Assign();
                }
                else
                {
                    lbl.Visible = true;
                    basket_no.Visible = true;
                    lbl.Text = "سبد تخصیص یافته به شما:";
                    basket_no.Text = dtsc5.Rows[0][1].ToString();
                    string batch_no = dtsc5.Rows[0][0].ToString();
                    Assign(batch_no);
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Assign (string batch)
        {
            ///////////////////////////////////////////////////// UPDATE Inbound DB
            oleDbCommand1.Parameters.Clear();
            oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] Set " +
                                        "[Assigned_Rec] = N'" + username + "'  where [Batch_no] = '" + batch + "'";
            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();
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
            string DT_Day = (psdate.GetDayOfMonth(persian_date).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(persian_date).ToString() : psdate.GetDayOfMonth(persian_date).ToString();
            string DT_Mth = (psdate.GetMonth(persian_date).ToString().Length == 1) ? "0" + psdate.GetMonth(persian_date).ToString() : psdate.GetMonth(persian_date).ToString();
            string DT_Yr = psdate.GetYear(persian_date).ToString();
            ///////////////////////////////////// Get SN
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT [Item_SN],[Position] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [Batch_no] = '" + batch + "'";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            ///////////////////////////////////////////////////// Update Status Table
            for (int i = 0; i < dtsc4.Rows.Count; i++)
            {
                ///////////////////////////////////////////////////// Expire
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] Set " +
                                            "[ST_Expired] = 1  where [Item_SN] = N'" + dtsc4.Rows[i][0].ToString() + "'";
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
                ///////////////////////////////////////////////////// New status
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] ([STATUS_KEY],[Item_SN],[Status],[ST_Per_Date],[ST_Date],[ST_Time],[ST_User],[ST_Expired])" +
                                            " values (?,?,?,?,GETDATE(),GETDATE(),?,?)";
                oleDbCommand1.Parameters.AddWithValue("@STATUS_KEY", batch + dtsc4.Rows[i][0].ToString());
                oleDbCommand1.Parameters.AddWithValue("@Batch_No", dtsc4.Rows[i][0].ToString());
                oleDbCommand1.Parameters.AddWithValue("@Year", "تخصیص به پذیرش - در انتظار پذیرش");
                oleDbCommand1.Parameters.AddWithValue("@Month", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                oleDbCommand1.Parameters.AddWithValue("@Insrt_Usr", username);
                oleDbCommand1.Parameters.AddWithValue("@REC", false);
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
            }
        }

        private void REC_REQUEST_BASKET_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
