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

namespace SnappFood_Employee_Evaluation.After_Sales
{
    public partial class REC_RECEIPTION_LARGE : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string username;
        private ErrorProvider errorProvider;
        public string DT_Yr;
        public string DT_Mth;
        public string DT_Day;
        public bool valid_access;
        public string center;

        public REC_RECEIPTION_LARGE()
        {
            InitializeComponent();

            /////////////////////////////////////////////////////////// UI Alignment
            origin.TextAlignment = ContentAlignment.MiddleLeft;
            org_desc.TextAlignment = ContentAlignment.MiddleLeft;
            position.TextAlignment = ContentAlignment.MiddleLeft;
            item_nature.TextAlignment = ContentAlignment.MiddleLeft;
            batch.TextAlignment = ContentAlignment.MiddleLeft;
            Inbound_DT.TextAlignment = ContentAlignment.MiddleLeft;
            ylw_basket.TextAlignment = ContentAlignment.MiddleLeft;
            serial_type.TextAlignment = ContentAlignment.MiddleLeft;

            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            RadMessageBox.ThemeName = "Office2010Silver";
        }

        private void REC_RECEIPTION_Load(object sender, EventArgs e)
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
                this.Close();
                valid_access = false;
                RadMessageBox.Show(this, " نقش شما تعریف نشده است! " + "\n", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                string role = dtsc4.Rows[0][0].ToString();
                switch (role)
                {
                    case "کارشناس پذیرش کالاهای بزرگ":
                        valid_access = true;
                        break;
                    default:
                        valid_access = false;
                        RadMessageBox.Show(this, " شما به این بخش دسترسی ندارید.! " + "\n", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                        break;
                }
            }

            ////////////////////////////////////////////////////////////////////////// Initiate RESULT Combo
            DataTable dtsc6 = new DataTable();
            OleDbDataAdapter adpsc6 = new OleDbDataAdapter();
            adpsc6.SelectCommand = new OleDbCommand();
            adpsc6.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc6 = "SELECT '' 'Status_desc','0' 'priority' union SELECT [Status_desc],[priority] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_STATUS_MASTER] where [Status_Dep] = N'REC' order by [priority] asc";
            adpsc6.SelectCommand.CommandText = lcommandsc6;
            adpsc6.Fill(dtsc6);
            result_combo.DataSource = dtsc6;
            result_combo.DisplayMember = "Status_desc";

            ////////////////////////////////////////////////////////////////////////// Initiate RESULT Combo
            DataTable dtsc5 = new DataTable();
            OleDbDataAdapter adpsc5 = new OleDbDataAdapter();
            adpsc5.SelectCommand = new OleDbCommand();
            adpsc5.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc5 = "SELECT '' 'AS_AGENT_NM','0' 'priority' union SELECT [AS_AGENT_NM], ROW_NUMBER() over(ORDER BY [AS_AGENT_NM])  'Priority' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_AGENT_ROLE] where [AS_Role_NM] = N'کارشناس تست فنی' order by [priority] asc";
            adpsc5.SelectCommand.CommandText = lcommandsc5;
            adpsc5.Fill(dtsc5);
            Technician.DataSource = dtsc5;
            Technician.DisplayMember = "AS_AGENT_NM";
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            After_Sales.REC_CARTABLE_LARGE ob = new After_Sales.REC_CARTABLE_LARGE(this);
            ob.constr = constr;
            ob.username = username;
            ob.center = center;
            ob.ShowDialog();
        }

        private void item_sn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && item_sn.Text != "")
            {
                item_validation();
            }
        }

        private void result_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Technician.SelectedIndex = 0;
            //ylw_basket.Text = "";
            if (result_combo.SelectedIndex == 2)
            {
                Technician.Visible = true;
                technician_lbl.Visible = true;
                ylw_basket.Visible = false;
                ylw_basket_lbl.Visible = false;
            }
            else if (result_combo.SelectedIndex == 1)
            {
                Technician.Visible = false;
                technician_lbl.Visible = false;
                ylw_basket.Visible = true;
                ylw_basket_lbl.Visible = true;
            }
            else
            {
                Technician.Visible = false;
                technician_lbl.Visible = false;
                ylw_basket.Visible = false;
                ylw_basket_lbl.Visible = false;
            }
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
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

            
            if (form_validation())
            {
                switch (result_combo.SelectedIndex)
                {
                    case 1:
                        To_Warehouse();
                        break;
                    case 2:
                        To_Tech();
                        break;
                    case 3:
                        To_Customer();
                        break;
                    case 4:
                        To_Seller();
                        break;
                }
            }
        }

        private bool form_validation()
        {
            bool error = false;
            errorProvider.Clear();

            if (item_sn.Text == "")
            {
                error = true;
                errorProvider.SetError(this.item_sn, "هیچ سریالی وارد نشده است.");
            }
            if (Technician.Visible && Technician.SelectedIndex == 0)
            {
                error = true;
                errorProvider.SetError(this.Technician, "تکنسین انتخاب نشده است.");
            }
            if (ylw_basket.Visible && ylw_basket.Text == "")
            {
                error = true;
                errorProvider.SetError(this.ylw_basket, "سبد زرد وارد نشده است.");
            }
            if (result_combo.SelectedIndex == 0)
            {
                error = true;
                errorProvider.SetError(this.result_combo, "نتیجه پذیرش انتخاب نشده است.");
            }
            if (batch.Text == "")
            {
                error = true;
                errorProvider.SetError(this.item_sn, "سریال وارد شده معتبر نیست.");
            }
            return !error;
        }

        private void To_Warehouse()
        {
            ///////////////////////////////////////////////////// Insert Receiption Table
            oleDbCommand1.Parameters.Clear();
            oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION] ([Batch_No],[Item_SN],[Position],[Test_Result],[YLW_Basket],[RET_ITEM],[REC],[Assign_WH],[WH],[Insrt_DT_Per],[Insrt_DT],[Insrt_TM],[Agent])" +
                                        " values (?,?,?,?,?,?,?,?,?,?,GETDATE(),GETDATE(),?)";
            oleDbCommand1.Parameters.AddWithValue("@Batch_No", batch.Text);
            oleDbCommand1.Parameters.AddWithValue("@Item_SN", item_sn.Text);
            oleDbCommand1.Parameters.AddWithValue("@Position", position.Text);
            oleDbCommand1.Parameters.AddWithValue("@Test_Result", result_combo.Text);
            oleDbCommand1.Parameters.AddWithValue("@YLW_Basket", ylw_basket.Text);
            oleDbCommand1.Parameters.AddWithValue("@RET_ITEM", false);
            oleDbCommand1.Parameters.AddWithValue("@REC", true);
            oleDbCommand1.Parameters.AddWithValue("@Assign_WH", true);
            oleDbCommand1.Parameters.AddWithValue("@WH", false);
            oleDbCommand1.Parameters.AddWithValue("@Insrt_DT_Per", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
            oleDbCommand1.Parameters.AddWithValue("@Agent", username);
            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();
            /////////////////////////////////////////// Update Journey
            Update_Journey(1);
        }

        private void To_Tech()
        {
            ///////////////////////////////////////////////////// Insert Receiption Table
            oleDbCommand1.Parameters.Clear();
            oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION] ([Batch_No],[Item_SN],[Position],[Test_Result],[Technician],[RET_ITEM],[REC],[Assign_Tech],[Tech],[Insrt_DT_Per],[Insrt_DT],[Insrt_TM],[Agent])" +
                                        " values (?,?,?,?,?,?,?,?,?,?,GETDATE(),GETDATE(),?)";
            oleDbCommand1.Parameters.AddWithValue("@Batch_No", batch.Text);
            oleDbCommand1.Parameters.AddWithValue("@Item_SN", item_sn.Text);
            oleDbCommand1.Parameters.AddWithValue("@Position", position.Text);
            oleDbCommand1.Parameters.AddWithValue("@Test_Result", result_combo.Text);
            //oleDbCommand1.Parameters.AddWithValue("@YLW_Basket", ylw_basket.Text);
            oleDbCommand1.Parameters.AddWithValue("@Technician", Technician.Text);
            oleDbCommand1.Parameters.AddWithValue("@RET_ITEM", false);
            oleDbCommand1.Parameters.AddWithValue("@REC", true);
            oleDbCommand1.Parameters.AddWithValue("@Assign_Tech", true);
            oleDbCommand1.Parameters.AddWithValue("@Tech", false);
            oleDbCommand1.Parameters.AddWithValue("@Insrt_DT_Per", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
            oleDbCommand1.Parameters.AddWithValue("@Agent", username);
            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();
            /////////////////////////////////////////// Update Journey
            Update_Journey(2);
        }

        private void To_Customer()
        {
            ///////////////////////////////////////////////////// Insert Receiption Table
            oleDbCommand1.Parameters.Clear();
            oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION] ([Batch_No],[Item_SN],[Position],[Test_Result],[RET_ITEM],[REC],[Assign_Cust],[Cust],[Insrt_DT_Per],[Insrt_DT],[Insrt_TM],[Agent])" +
                                        " values (?,?,?,?,?,?,?,?,?,GETDATE(),GETDATE(),?)";
            oleDbCommand1.Parameters.AddWithValue("@Batch_No", batch.Text);
            oleDbCommand1.Parameters.AddWithValue("@Item_SN", item_sn.Text);
            oleDbCommand1.Parameters.AddWithValue("@Position", position.Text);
            oleDbCommand1.Parameters.AddWithValue("@Test_Result", result_combo.Text);
            //oleDbCommand1.Parameters.AddWithValue("@YLW_Basket", ylw_basket.Text);
            oleDbCommand1.Parameters.AddWithValue("@RET_ITEM", false);
            oleDbCommand1.Parameters.AddWithValue("@REC", true);
            oleDbCommand1.Parameters.AddWithValue("@Assign_Cust", true);
            oleDbCommand1.Parameters.AddWithValue("@Cust", false);
            oleDbCommand1.Parameters.AddWithValue("@Insrt_DT_Per", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
            oleDbCommand1.Parameters.AddWithValue("@Agent", username);
            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();
            /////////////////////////////////////////// Update Journey
            Update_Journey(3);
        }

        private void To_Seller()
        {
            ///////////////////////////////////////////////////// Insert Receiption Table
            oleDbCommand1.Parameters.Clear();
            oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION] ([Batch_No],[Item_SN],[Position],[Test_Result],[RET_ITEM],[REC],[Assign_Seller],[Seller],[Insrt_DT_Per],[Insrt_DT],[Insrt_TM],[Agent])" +
                                        " values (?,?,?,?,?,?,?,?,?,GETDATE(),GETDATE(),?)";
            oleDbCommand1.Parameters.AddWithValue("@Batch_No", batch.Text);
            oleDbCommand1.Parameters.AddWithValue("@Item_SN", item_sn.Text);
            oleDbCommand1.Parameters.AddWithValue("@Position", position.Text);
            oleDbCommand1.Parameters.AddWithValue("@Test_Result", result_combo.Text);
            //oleDbCommand1.Parameters.AddWithValue("@YLW_Basket", ylw_basket.Text);
            oleDbCommand1.Parameters.AddWithValue("@RET_ITEM", false);
            oleDbCommand1.Parameters.AddWithValue("@REC", true);
            oleDbCommand1.Parameters.AddWithValue("@Assign_Seller", true);
            oleDbCommand1.Parameters.AddWithValue("@Seller", false);
            oleDbCommand1.Parameters.AddWithValue("@Insrt_DT_Per", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
            oleDbCommand1.Parameters.AddWithValue("@Agent", username);
            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();
            /////////////////////////////////////////// Update Journey
            Update_Journey(4);
        }

        private void Update_Journey(int type)
        {
            string status_text = "";
            switch (type)
            {
                case 1:
                    status_text = "ارسال به انبار - در انتظار رسید انبار";
                    break;
                case 2:
                    status_text = "ارجاع به تست فنی - در انتظار تست فنی";
                    break;
                case 3:
                    status_text = "ارجاع به عودت - در انتظار ارسال به مشتری";
                    break;
                case 4:
                    status_text = "ارجاع به فروشنده - در انتظار ارسال به فروشنده";
                    break;
            }
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

            ///////////////////////////////////////////////////// Expire
            oleDbCommand1.Parameters.Clear();
            oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] Set [ST_Expired] = 1  where [STATUS_KEY] = N'" + batch.Text + item_sn.Text + "'";
            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();

            ///////////////////////////////////////////////////// Update Status Table
            oleDbCommand1.Parameters.Clear();
            oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] ([STATUS_KEY],[Item_SN],[Status],[ST_Per_Date],[ST_Date],[ST_Time],[ST_User],[ST_Expired])" +
                                        " values (?,?,?,?,GETDATE(),GETDATE(),?,?)";
            oleDbCommand1.Parameters.AddWithValue("@STATUS_KEY", batch.Text + item_sn.Text);
            oleDbCommand1.Parameters.AddWithValue("@Item_SN", item_sn.Text);
            oleDbCommand1.Parameters.AddWithValue("@Status", status_text);
            oleDbCommand1.Parameters.AddWithValue("@ST_Per_Date", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
            oleDbCommand1.Parameters.AddWithValue("@ST_User", username);
            oleDbCommand1.Parameters.AddWithValue("@ST_Expired", false);

            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();

            Form_Clear();
        }

        private void Form_Clear()
        {
            ///////////////////////////////////////////////////// Expire
            oleDbCommand1.Parameters.Clear();
            oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] Set [REC] = 1  where [Item_SN] = N'" + item_sn.Text + "' and [batch_no] = '" + batch.Text + "'";

            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();

            item_sn.Text = "";
            sys_serial.Text = "";
            //ylw_basket.Text = "";
            Technician.SelectedIndex = 0;
            result_combo.SelectedIndex = 0;
            origin.Text = "";
            org_desc.Text = "";
            position.Text = "";
            item_nature.Text = "";
            Inbound_DT.Text = "";
            batch.Text = "";
            RadMessageBox.Show(this, " کالا با موفقیت پذیرش شد! " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
        }

        private void REC_RECEIPTION_LARGE_Shown(object sender, EventArgs e)
        {
            if (!valid_access)
            {
                this.Close();
            }
        }

        public bool item_validation()
        {
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT [Batch_No],[Position],[Nature],[Origin],[Origin_NM],[In_DT_Per],[Assigned_Rec],[Rec] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [Item_SN] = '" + item_sn.Text + "' and [rec] = 0";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            if (dtsc4.Rows.Count != 0)
            {
                if (dtsc4.Rows[0][7].ToString() == "False")
                {
                    batch.Text = dtsc4.Rows[0][0].ToString();
                    origin.Text = dtsc4.Rows[0][3].ToString();
                    org_desc.Text = dtsc4.Rows[0][4].ToString();
                    position.Text = dtsc4.Rows[0][1].ToString();
                    item_nature.Text = dtsc4.Rows[0][2].ToString();
                    Inbound_DT.Text = dtsc4.Rows[0][5].ToString();
                    if (item_sn.Text.Contains("-"))
                    {
                        serial_type.Text = "موقت";
                        sys_serial.Text = "";
                    }
                    else
                    {
                        serial_type.Text = "سیستمی";
                        sys_serial.Text = item_sn.Text;
                    }
                    return true;
                }
                //else if (dtsc4.Rows[0][6].ToString() != username)
                //{
                //    item_sn.Text = "";
                //    result_combo.SelectedIndex = 0;
                //    origin.Text = "";
                //    org_desc.Text = "";
                //    position.Text = "";
                //    item_nature.Text = "";
                //    Inbound_DT.Text = "";
                //    batch.Text = "";
                //    if (dtsc4.Rows[0][6].ToString() != "")
                //    {
                //        RadMessageBox.Show(this, "  سریال وارد شده در سبد شما نیست.  " + "\n" + "\n" + "  این سریال به " + dtsc4.Rows[0][6].ToString() + " تخصیص یافته است. " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                //    }
                //    else
                //    {
                //        RadMessageBox.Show(this, "  این سریال هنوز تخصیص نیافته است.  " + "\n" + "\n" + "  شما مجاز به پذیرش این کالا نیستید.  " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                //    }
                //    return false;
                //}
                else if (dtsc4.Rows[0][7].ToString() != "False")
                {
                    item_sn.Text = "";
                    result_combo.SelectedIndex = 0;
                    origin.Text = "";
                    org_desc.Text = "";
                    position.Text = "";
                    item_nature.Text = "";
                    Inbound_DT.Text = "";
                    batch.Text = "";
                    RadMessageBox.Show(this, "  این سریال قبلا پذیرش شده است. " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                item_sn.Text = "";
                result_combo.SelectedIndex = 0;
                origin.Text = "";
                org_desc.Text = "";
                position.Text = "";
                item_nature.Text = "";
                Inbound_DT.Text = "";
                batch.Text = "";
                RadMessageBox.Show(this, " سریال وارد شده یافت نشد. " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                return false;
            }

        }
    }
}
