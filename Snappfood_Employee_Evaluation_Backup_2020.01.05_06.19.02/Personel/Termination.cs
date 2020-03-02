using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using System.IO;
using System.Globalization;
using System.Net.Mail;

namespace SnappFood_Employee_Evaluation.Personel
{
    public partial class Termination : Telerik.WinControls.UI.RadForm
    {
        public string pic_address = "";
        public string constr;
        public string user;
        private ErrorProvider errorProvider;
        public bool data_error = false;

        public Termination()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            RadMessageBox.SetThemeName("Office2010Silver");
            radLabel35.TextAlignment = ContentAlignment.MiddleCenter;
            System_Id.TextAlignment = ContentAlignment.MiddleLeft;
            Doc_Cd.TextAlignment = ContentAlignment.MiddleLeft;
            Score_Total.TextAlignment = ContentAlignment.MiddleLeft;
            Job_Level.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Dep.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Cd.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Dep.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Fa_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Nk_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Ntl_ID.TextAlignment = ContentAlignment.MiddleLeft;
            Main_Shift.TextAlignment = ContentAlignment.MiddleLeft;
            user_box.TextAlignment = ContentAlignment.MiddleLeft;
            emp_dt.TextAlignment = ContentAlignment.MiddleLeft;
            birth_dt.TextAlignment = ContentAlignment.MiddleLeft;
            radLabel12.TextAlignment = ContentAlignment.MiddleLeft;
        }

        private void Termination_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
        }

        public void searching()
        {
            Clear_Frm();
            /////////////////////////////// Update first tab
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT [Doc_No],[System_Id],[Chargoon_Id],[Per_National_Cd],[Department],[Main_Shift]" +
                               ",[Per_Name],[Per_Fa_Name],[Per_Nk_Name],[Per_Tel],[Per_Mob],[Per_Add],[Per_Pic]" +
                               ",[History],[Employment_Dt],[Birth_Dt],[Email],[Degree],[Major],[Major_Status]" +
                               ",[Mentor],[sex],[Insert_User] FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [doc_no] = '" + Doc_Cd.Text + "'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            System_Id.Text = dt1.Rows[0][1].ToString();
            Per_Cd.Text = dt1.Rows[0][2].ToString();
            Per_Ntl_ID.Text = dt1.Rows[0][3].ToString();
            Per_Dep.Text = dt1.Rows[0][4].ToString();
            Main_Shift.Text = dt1.Rows[0][5].ToString();
            Per_Name.Text = dt1.Rows[0][21].ToString() + " " +dt1.Rows[0][6].ToString();
            Per_Fa_Name.Text = dt1.Rows[0][7].ToString();
            Per_Nk_Name.Text = dt1.Rows[0][8].ToString();
            if (dt1.Rows[0][12].ToString().Length != 0)
            {
                byte[] imageData = (byte[])dt1.Rows[0][12];
                Image newImage;
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);
                    newImage = Image.FromStream(ms, true);
                }
                Per_Pic.Image = newImage;
            }
            else
            {
                Per_Pic.Image = null;
            }
            emp_dt.Text = dt1.Rows[0][14].ToString();
            birth_dt.Text = dt1.Rows[0][15].ToString();
            user_box.Text = dt1.Rows[0][22].ToString();
            
                
            //////////////////////////////////////////// Get Score Total
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT [Doc_No],sum([Sc_Score]) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '" + Doc_Cd.Text + "' group by [Doc_No]";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);

            if (dtsc4.Rows.Count != 0)
            {
                Score_Total.Text = dtsc4.Rows[0][1].ToString();
            }
            else
            {
                Score_Total.Text = "0";
            }
            //////////////////////////////////////////////// Fill Job Leveling
            DataTable dtsc333 = new DataTable();
            OleDbDataAdapter adpsc333 = new OleDbDataAdapter();
            adpsc333.SelectCommand = new OleDbCommand();
            adpsc333.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc333 = "SELECT [Job_Score],[Job_Grade],[Job_Level],[Job_Department],[Job_Salary_Base] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_JOB_LEVELING] where [Job_Department] = N'" + Per_Dep.Text + "' AND [Job_score] = '" + Score_Total.Text + "'";
            adpsc333.SelectCommand.CommandText = lcommandsc333;
            adpsc333.Fill(dtsc333);
            Job_Level.Text = dtsc333.Rows[0][2].ToString();
        }

        public void Clear_Frm()
        {
            
            System_Id.Text = ""; //1].ToString();
            Per_Cd.Text = ""; //2].ToString();
            Per_Ntl_ID.Text = ""; //3].ToString();
            Per_Dep.Text = ""; //4].ToString();
            Main_Shift.Text = ""; //5].ToString();
            Per_Name.Text = ""; //6].ToString();
            Per_Fa_Name.Text = ""; //7].ToString();
            Per_Nk_Name.Text = ""; //8].ToString();
            Per_Pic.Image = null;
            emp_dt.Text = ""; //14].ToString();
            birth_dt.Text = ""; //15].ToString();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            Personel.Search_Staff_Termination ob = new Personel.Search_Staff_Termination(this);
            ob.constr = constr;
            ob.ShowDialog();
        }

        private void Today_Btn_Click(object sender, EventArgs e)
        {
            /////////////////////////////////////// Get Date
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT day(GETDATE()), month(GETDATE()), year(GETDATE())";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            DateTime datetime = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
            ///////////////////////////////////////// Convert Persian
            PersianCalendar psdate = new PersianCalendar();
            DT_Day.Text = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            DT_Mth.Text = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            DT_Yr.Text = psdate.GetYear(datetime).ToString();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (Doc_Cd.Text.Length == 0)
            {
                return;
            }
            else
            {
                if (!this.AreRequiredFieldsValid())
                {
                    return;
                }
                else
                {
                    ////////////////////////////////////////// Check active class
                    /////////////////////////////////////// Get Date
                    DataTable dt1 = new DataTable();
                    OleDbDataAdapter adp1 = new OleDbDataAdapter();
                    adp1.SelectCommand = new OleDbCommand();
                    adp1.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommand1 = "SELECT [CLS_Cd] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] where Per_Result is null and doc_no = '" + Doc_Cd.Text + "'";
                    adp1.SelectCommand.CommandText = lcommand1;
                    adp1.Fill(dt1);
                    if (dt1.Rows.Count == 0)
                    {
                        ////////////////////////////////////////////// UPDATE PER_DOCUMENTS TBL
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] SET [Termination_Reason] = ?, [Termination] = ?,[Termination_DT] = ?,[Termination_Insrt_DT] = getdate(),[Termination_Insrt_TM] = getdate(),[Termination_User] = ?, [Termination_Type] = ? WHERE [Doc_No] = '" + Doc_Cd.Text + "'";
                        oleDbCommand1.Parameters.AddWithValue("@Reason", Reason.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Doc_No", 1);
                        oleDbCommand1.Parameters.AddWithValue("@System_Id", DT_Yr.Text + "/" + DT_Mth.Text + "/" + DT_Day.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Chargoon_Id", user);
                        oleDbCommand1.Parameters.AddWithValue("@Chargoon_Id", Termination_Type.Text);
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                        //////////////////////////////////////////////// remove previuos station
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[PER_STATIONS] SET [Doc_No] = ''  where [Doc_no] = '" + Doc_Cd.Text + "'";
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                        mailing2();
                        RadMessageBox.Show(this, " پرونده پرسنلی " + "\n" + " به شماره: " + Doc_Cd.Text + "\n" + " به نام " + Per_Name.Text + "\n" + " با موفقیت بسته شده و قطع همکاری ثبت گردید." + "\n\n تاریخ قطع همکاری: " + DT_Yr.Text + "/" + DT_Mth.Text + "/" + DT_Day.Text + "\n" + "استیشن مربوطه تخلیه گردید." + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                    else
                    {
                        RadMessageBox.Show(this, Per_Name.Text + " در کلاس فعال " + dt1.Rows[0][0].ToString() + " ثبت نام کرده است. " + "\n\n" + "برای قطع همکاری می بایست از کلاس حذف شده و یا کلاس را به اتمام برساند." + "\n", "بروز خطا...", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                }
            }
        }

        public void mailing2()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("postman.dkes@gmail.com");
                mail.To.Add("j.taghinasab@digikala.com,L.maharati@digikala.com,S.Khodabandeh@digikala.com"); //
                mail.Subject = "قطع همکاری - " + Per_Name.Text;
                mail.IsBodyHtml = true;
                mail.Body = "<table width = '100%'><tr><td align='right'><p dir='rtl'>" +
                            "<font face='Tahoma'><font size='5px'> <b>" + "اعلام قطع همکاری پرسنل" + "</b></font>" + "<br>" + "<br>" + "<font size='3px'>" +
                            "شماره پرونده: <b>" + Doc_Cd.Text + "</b><br>" +
                            "نام همکار: <b>" + Per_Name.Text + "</b><br>" +
                            "واحد سازمانی: <b>" + Per_Dep.Text + "</b><br>" +
                            "شیفت کاری: <b>" + Main_Shift.Text + "</b><br>" +
                            "شماره داخلی: <b>" + System_Id.Text + "</b><br>" +
                            "نوع قطع همکاری: <b>" + Termination_Type.Text + "</b><br>" +
                            "علت قطع همکاری: <b>" + Reason.Text + "</b><br>" +
                            "تاریخ قطع همکاری: <b>" + DT_Yr.Text + "/" + DT_Mth.Text + "/" + DT_Day.Text + "</b>" + "</font>" +
                            "<br><br><font size='3px'>" + "با تشکر" + "<br>" + "<b>" + "سامانه متمرکز اطلاعات و پایش عملکرد پرسنل دیجی کالا - DKES" + "</b></font>" +
                            "<br><br><br><font color='Red'>" + "این ایمیل به صورت اتوماتیک ارسال شده است. لطفا به آن پاسخ ندهید." + "</font>" +
                            "</font></p></td></tr></table>";


                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("postman.dkes@gmail.com", "j86415173447");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool AreRequiredFieldsValid()
        {
            data_error = false;
            if (DT_Day.Text == "" || DT_Mth.Text == "" || DT_Yr.Text == "" || int.Parse(DT_Day.Text) > 31 || int.Parse(DT_Mth.Text) > 12 || int.Parse(DT_Yr.Text) < 1300)
            {
                this.errorProvider.SetError(this.Today_Btn, "تاریخ استخدام صحیح وارد نشده است");
                data_error = true;
            }
            if (Reason.Text == "")
            {
                this.errorProvider.SetError(this.Reason, "علت قطع همکاری مشخص نشده است");
                data_error = true;
            }
            else if (Reason.Text.Length <= 15)
            {
                this.errorProvider.SetError(this.Reason, "توضیحات قطع همکاری کافی نیست");
                data_error = true;
            }
            if (data_error == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void DT_Day_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl.Text.Length == 2)
            {
                this.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void english_score_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
