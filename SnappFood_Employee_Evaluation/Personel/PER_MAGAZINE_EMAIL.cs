using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Net.Mail;
using System.Globalization;

namespace SnappFood_Employee_Evaluation.Personel
{
    public partial class PER_MAGAZINE_EMAIL : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string DT_Day;
        public string DT_Mth;
        public string DT_Yr;
        public DataTable dt1 = new DataTable();
        string sel_month;
        string sel_series;
        string sel_year;

        public PER_MAGAZINE_EMAIL()
        {
            InitializeComponent();
            radLabel1.TextAlignment = ContentAlignment.MiddleCenter;
        }

        private void TRN_CLS_ANNOUNCEMENT_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;

            //DataTable dt4 = new DataTable();
            //OleDbDataAdapter adp4 = new OleDbDataAdapter();
            //adp4.SelectCommand = new OleDbCommand();
            //adp4.SelectCommand.Connection = oleDbConnection1;
            //oleDbCommand1.Parameters.Clear();
            //string lcommand4 = "SELECT '' 'CLS_Course_Cd','' 'CLS_Course_Nm' union SELECT DISTINCT [CLS_Course_Cd],[CLS_Course_Nm] FROM  [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES] where [CLS_ACTV] = 1";
            //adp4.SelectCommand.CommandText = lcommand4;
            //adp4.Fill(dt4);
            //Trainer.DataSource = dt4;
            //Trainer.DisplayMember = "CLS_Course_Nm";
            //Trainer.ValueMember = "CLS_Course_Cd";
            Get_Date();
            year.Text = DT_Yr;
        }

        public void Get_Date()
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
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (dt1.Rows.Count != 0)
            {
                if (File_Name.Text != "")
                {
                    if (year.Text == "" || month.SelectedIndex == 0 || series.Text == "")
                    {
                        RadMessageBox.Show(this, "ورودی ها را کنترل نمائید.", "بروز خطا", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                    else
                    {
                        pictureBox2.Visible = true;
                        sel_month = month.Text;
                        sel_series = series.Text;
                        sel_year = year.Text;
                        backgroundWorker1.WorkerReportsProgress = true;
                        backgroundWorker1.WorkerSupportsCancellation = true;
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else
                {
                    RadMessageBox.Show(this, "فایل ماهنامه آپلود نشد. \n لطفا ابتدا فایل ماهنامه را آپلود نمائید.", "بروز خطا", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
            }
            else
            {
                RadMessageBox.Show(this, "گیرنده ای جهت ارسال ایمیل یافت نشد.", "بروز خطا", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT [Sex] + ' ' +[Per_Name] as [Per_Name],[Per_Mob],[Email] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [termination] != 1 ";

            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            Updation_Prog.Minimum = 0;
            Updation_Prog.Maximum = dt2.Rows.Count;
            ///////////////////////////////////////////////////////////////////////////////////////// Send Mail
            

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                
                if (dt2.Rows[i][2].ToString() != "-@zoodfood.com")
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("postman.sfes@gmail.com");
                        mail.IsBodyHtml = true;
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(File_Name.Text);
                        mail.Attachments.Add(attachment);
                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("postman.sfes@gmail.com", "j86415173447");
                        SmtpServer.EnableSsl = true;
                        mail.To.Add(dt2.Rows[i][2].ToString());
                        mail.Subject = "ماهنامه سازمانی دیجی کالا - شماره " + sel_series + " (" + sel_month + " " + sel_year + ")";
                        mail.Body = "<table width = '100%'><tr><td align='right'><p dir='rtl'>" +
                                    "<font face='Tahoma'><font size='4px'> <b>" + dt2.Rows[i][0].ToString() + " عزیز " + "</b></font>" + "<br>" + "<br>" + "<font size='3px'>" +
                                    "ماهنامه سازمانی دیجی کالا - شماره " + sel_series + " (" + sel_month + " " + sel_year + ")" + " به پیوست این ایمیل تقدیم می گردد. امیدواریم از آن لذت ببرید." + "</b><br><br>" +
                                    "</font>" +
                                    "<br><br><font size='3px'>" + "با تشکر" + "<br>" + "تیم تحریریه ماهنامه سازمانی دیجی کالا" + "<br><br>" + "<b>" + "ارسال شده توسط سامانه متمرکز اطلاعات و پایش عملکرد پرسنل دیجی کالا - SFES" + "</b>" + "</font>" +
                                    "<br><br><font color='Red'>" + "این ایمیل به صورت اتوماتیک ارسال شده است. لطفا به آن پاسخ ندهید." + "</font>" +
                                    "</font></p></td></tr></table>";

                        SmtpServer.Send(mail);
                        SmtpServer.Dispose();
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.ToString());
                    }
                }
                backgroundWorker1.ReportProgress(i + 1, "Updation");
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Updation_Prog.Value1 = e.ProgressPercentage;
            Updation_Prog.Text = "ارسال ایمیل: " + e.ProgressPercentage + " از " + Updation_Prog.Maximum;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
            RadMessageBox.Show(this, "ارسال ایمیل با موفقیت پایان یافت.", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
        }

        private void Trainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (month.SelectedIndex != 0)
            {
                dt1.Clear();
                OleDbDataAdapter adp1 = new OleDbDataAdapter();
                adp1.SelectCommand = new OleDbCommand();
                adp1.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand1 = "SELECT [Sex] + ' ' +[Per_Name] as [Per_Name],[Per_Mob],[Email] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [termination] != 1 ";
                adp1.SelectCommand.CommandText = lcommand1;
                adp1.Fill(dt1);
                radLabel1.Text = "تعداد همکاران در حال کار موجود، " + dt1.Rows.Count + " می باشد.";
            }
            else
            {
                radLabel1.Text = "";
            }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File_Name.Text = openFileDialog1.FileName;
            }
        }
    }
}
