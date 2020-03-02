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
    public partial class REC_LABEL_CHANGE : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string username;
        private ErrorProvider errorProvider;
        public string DT_Yr;
        public string DT_Mth;
        public string DT_Day;

        public REC_LABEL_CHANGE()
        {
            InitializeComponent();

            /////////////////////////////////////////////////////////// UI Alignment
            origin.TextAlignment = ContentAlignment.MiddleLeft;
            org_desc.TextAlignment = ContentAlignment.MiddleLeft;
            position.TextAlignment = ContentAlignment.MiddleLeft;
            item_nature.TextAlignment = ContentAlignment.MiddleLeft;
            batch.TextAlignment = ContentAlignment.MiddleLeft;
            Inbound_DT.TextAlignment = ContentAlignment.MiddleLeft;
            //serial_type.TextAlignment = ContentAlignment.MiddleLeft;

            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            RadMessageBox.ThemeName = "Office2010Silver";
        }

        private void REC_RECEIPTION_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            RadMessageBox.ThemeName = "Office2010Silver";
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            //After_Sales.REC_CARTABLE ob = new After_Sales.REC_CARTABLE(this);
            //ob.constr = constr;
            //ob.username = username;
            //ob.ShowDialog();
        }

        private void item_sn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && item_sn.Text != "" && input_batch.Text != "")
            {
                DataTable dtsc4 = new DataTable();
                OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
                adpsc4.SelectCommand = new OleDbCommand();
                adpsc4.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommandsc4 = "SELECT [Batch_No],[Position],[Nature],[Origin],[Origin_NM],[In_DT_Per],[Assigned_Rec],[Rec] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [Item_SN] = '" + item_sn.Text + "' and [batch_no] = '" + input_batch.Text + "'";
                adpsc4.SelectCommand.CommandText = lcommandsc4;
                adpsc4.Fill(dtsc4);
                if (dtsc4.Rows.Count != 0)
                {
                    
                        batch.Text = dtsc4.Rows[0][0].ToString();
                        origin.Text = dtsc4.Rows[0][3].ToString();
                        org_desc.Text = dtsc4.Rows[0][4].ToString();
                        position.Text = dtsc4.Rows[0][1].ToString();
                        item_nature.Text = dtsc4.Rows[0][2].ToString();
                        Inbound_DT.Text = dtsc4.Rows[0][5].ToString();
                }
                else
                {
                    item_sn.Text = "";
                    input_batch.Text = "";
                    origin.Text = "";
                    org_desc.Text = "";
                    position.Text = "";
                    item_nature.Text = "";
                    Inbound_DT.Text = "";
                    batch.Text = "";
                    RadMessageBox.Show(this, " سریال وارد شده یافت نشد. " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
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
                ///////////////////////////////////////////////////// Insert LABEL CHANGE Table
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[AS_LABEL_CHANGE] ([old_sn],[new_sn],[Insrt_DT_Per],[Insrt_DT],[Insrt_TM],[Insrt_usr],[remark])" +
                                            " values (?,?,?,GETDATE(),GETDATE(),?,?)";
                oleDbCommand1.Parameters.AddWithValue("@old_sn", item_sn.Text);
                oleDbCommand1.Parameters.AddWithValue("@new_sn", new_sn.Text);
                oleDbCommand1.Parameters.AddWithValue("@Insrt_DT_Per", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                oleDbCommand1.Parameters.AddWithValue("@Insrt_usr", username);
                oleDbCommand1.Parameters.AddWithValue("@remark", remark.Text);
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
                To_Warehouse();
            }

        }

        private bool form_validation()
        {
            bool error = false;
            errorProvider.Clear();

            if (item_sn.Text == "")
            {
                error = true;
                errorProvider.SetError(this.item_sn, "سریال غلط وارد نشده است.");
            }
            if (remark.Text.Length < 10)
            {
                error = true;
                errorProvider.SetError(this.remark, "توضیح (کامل) وارد نشده است.");
            }
            if (new_sn.Visible && new_sn.Text == "")
            {
                error = true;
                errorProvider.SetError(this.new_sn, "سریال صحیح وارد نشده است.");
            }
            if (input_batch.Text == "")
            {
                error = true;
                errorProvider.SetError(this.new_sn, "شناسه دریافت وارد نشده است.");
            }
            if (batch.Text == "")
            {
                error = true;
                errorProvider.SetError(this.batch, "پس از وارد کردن سریال قبلی و شناسه دریافت، کلید اینتر را فشار دهید.");
            }
            if (item_sn.Text != "" && new_sn.Text != "" && new_sn.Text != item_sn.Text)
            {
                DataTable dtsc4 = new DataTable();
                OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
                adpsc4.SelectCommand = new OleDbCommand();
                adpsc4.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommandsc4 = "SELECT [Item_SN],DATEDIFF(day,[In_DT],getdate()) 'TT',[REC] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [item_sn] = N'" + new_sn.Text + "' order by [TT] asc";
                adpsc4.SelectCommand.CommandText = lcommandsc4;
                adpsc4.Fill(dtsc4);
                if (dtsc4.Rows.Count != 0)
                {
                    if (dtsc4.Rows[0][2].ToString() == "True")
                    {
                        if (int.Parse(dtsc4.Rows[0][1].ToString()) <= 7)
                        {
                            error = true;
                            RadMessageBox.Show(this, " سریال جدید کمتر از 7 روز پیش دریافت شده، قادر به تغییر لیبل به این سریال نمی باشید! " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                        }
                        else
                        {
                            //////////////////////////////// EVERYTHING OK. More than 7 days past the last inbound date.
                        }
                    }
                    else
                    {
                        error = true;
                        RadMessageBox.Show(this, " سریال جدید قبلا دریافت شده و هنوز پذیرش نشده است. قادر به تغییر لیبل به این سریال نمی باشید! " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                }
                else
                {
                    //////////////////////////////// EVERYTHING OK. Not inbounded yet!
                }
            }
            else
            {
                error = true;
                errorProvider.SetError(this.new_sn, "سریال جدید و قبلی نمی تواند یکی باشد.");
            }

            return !error;
        }

        private void To_Warehouse()
        {
            ///////////////////////////////////////////////////// Expire
            oleDbCommand1.Parameters.Clear();
            oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] Set [Item_SN] = '" + new_sn.Text + "', [STATUS_KEY] = '" + batch.Text + new_sn.Text + "' where [STATUS_KEY] = N'" + batch.Text + item_sn.Text + "' " +
                                        "UPDATE [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] Set [Item_SN] = '" + new_sn.Text + "', [INBOUND_ID] = '" + batch.Text + new_sn.Text + "' where [Item_SN] = N'" + item_sn.Text + "' and [batch_no] = N'" + batch.Text + "'" +
                                        "UPDATE [SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION] Set [Item_SN] = '" + new_sn.Text + "'  where [Item_SN] = N'" + item_sn.Text + "' and [batch_no] = N'" + batch.Text + "'";
            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();
            /////////////////////////////////////////// Update Journey
            Update_Journey(1);
        }
                
        private void Update_Journey(int type)
        {
            string status_text = "";
            switch (type)
            {
                case 1:
                    status_text = "تغییر لیبل کالا - در انتظار پذیرش";
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
            oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] Set [ST_Expired] = 1  where [STATUS_KEY] = N'" + batch.Text + new_sn.Text + "'";
            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();

            ///////////////////////////////////////////////////// Update Status Table
            oleDbCommand1.Parameters.Clear();
            oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] ([STATUS_KEY],[Item_SN],[Status],[ST_Per_Date],[ST_Date],[ST_Time],[ST_User],[ST_Expired])" +
                                        " values (?,?,?,?,GETDATE(),GETDATE(),?,?)";
            oleDbCommand1.Parameters.AddWithValue("@status_key", batch.Text + new_sn.Text);
            oleDbCommand1.Parameters.AddWithValue("@Item_SN", new_sn.Text);
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
            item_sn.Text = "";
            remark.Text = "";
            new_sn.Text = "";
            input_batch.Text = "";
            origin.Text = "";
            org_desc.Text = "";
            position.Text = "";
            item_nature.Text = "";
            Inbound_DT.Text = "";
            batch.Text = "";
            RadMessageBox.Show(this, " تغییر لیبل با موفقیت انجام شد! " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
