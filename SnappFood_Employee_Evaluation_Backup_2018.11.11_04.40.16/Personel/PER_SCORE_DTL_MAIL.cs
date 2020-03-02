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
    public partial class PER_SCORE_DTL_MAIL : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt1 = new DataTable();

        public PER_SCORE_DTL_MAIL()
        {
            InitializeComponent();
            radLabel1.TextAlignment = ContentAlignment.MiddleCenter;
        }

        private void TRN_CLS_ANNOUNCEMENT_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;

            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "select [Sex] + ' ' +[Per_Name] as [Per_Name],[Per_Mob],[Email] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where termination = 0";

            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            radLabel1.Text = "تعداد پرونده های فعال موجود در سیستم " + dt1.Rows.Count + " می باشد.";
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (dt1.Rows.Count != 0)
            {
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.RunWorkerAsync();
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
            string lcommand2 = "select [Doc_no], [Sex] + ' ' +[Per_Name] as [Per_Name],[Per_Mob],[Email],[employment_dt] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where termination = 0 order by [doc_no] asc";
            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            Updation_Prog.Minimum = 0;
            Updation_Prog.Maximum = dt2.Rows.Count;
            

            ///////////////////////////////////////////////////////////////////////////////////////// Send Mail
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (dt2.Rows[i][3].ToString() != "-@zoodfood.com")
                {
                    // Make score datatable
                    DataTable dt = new DataTable();
                    OleDbDataAdapter adpsc55 = new OleDbDataAdapter();
                    adpsc55.SelectCommand = new OleDbCommand();
                    adpsc55.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommandsc55 = "SELECT ROW_NUMBER() OVER(ORDER BY [Sc_Eff_DT] ASC) 'ردیف',[Sc_Item_Sub_Cd]'کد زیرگروه',[Sc_Item_Nm]'عنوان امتیاز',[Sc_Eff_DT] 'تاریخ موثر',[Sc_Description]'توضیحات',[Sc_Score]'امتیاز' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '" + dt2.Rows[i][0].ToString() + "' order by [Sc_Eff_DT] asc";
                    adpsc55.SelectCommand.CommandText = lcommandsc55;
                    dt.Clear();
                    adpsc55.Fill(dt);

                    ////////// Get perviouse score
                    DataTable pre_score = new DataTable();
                    OleDbDataAdapter adpsc5555 = new OleDbDataAdapter();
                    adpsc5555.SelectCommand = new OleDbCommand();
                    adpsc5555.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommandsc5555 = "SELECT sum([Sc_Score]) 'sum' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where ([Sc_Eff_DT] <= '1396/08/01' or [Sc_Eff_Dt] <= '" + dt2.Rows[i][4].ToString() +"') and [Doc_No] = '" + dt2.Rows[i][0].ToString() + "'";
                    adpsc55.SelectCommand.CommandText = lcommandsc5555;
                    pre_score.Clear();
                    adpsc55.Fill(pre_score);


                    ///////////////////////////////// Worked history in days
                    DateTime end_dt;
                    DateTime start_dt;
                    PersianCalendar perdt = new PersianCalendar();
                    end_dt = perdt.ToDateTime(1396, 12, 29, 0, 0, 0, 0);
                    start_dt = perdt.ToDateTime(int.Parse(dt2.Rows[i][4].ToString().Substring(0, 4)), int.Parse(dt2.Rows[i][4].ToString().Substring(5, 2)), int.Parse(dt2.Rows[i][4].ToString().Substring(8, 2)), 0, 0, 0, 0);
                    int difference = int.Parse((end_dt - start_dt).TotalDays.ToString());


                    if (dt.Rows.Count != 0)
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("postman.sfes@gmail.com");
                        mail.IsBodyHtml = true;
                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("postman.sfes@gmail.com", "j86415173447");
                        SmtpServer.EnableSsl = true;
                        mail.To.Add(dt2.Rows[i][3].ToString());
                        mail.Subject = "جزئیات امتیازات شغلی - " + dt2.Rows[i][1].ToString();
                        mail.Body = "<table width = '100%'><tr><td align='right'><p dir='rtl'>" +
                                    "<font face='Tahoma'><font size='4px'> <b>" + dt2.Rows[i][1].ToString() + " عزیز " + "</b></font>" + "<br>" + "<br>" + "<font size='3px'>" +
                                    "به این وسیله  ضمن تبریک سال جدید، مراتب سپاس خود را از تلاش و زحمات ارزشمند و صادقانه جنابعالی در زمینه پیشبرد اهداف اسنپ فود تقدیم می داریم." + "<br>" +
                                    "در سالی که گذشت شاهد فراز و نشیب های زیادی بودیم، بخش های جدیدی به اسنپ فود اضافه شد، دوستان زیادی از جمع ما جدا و اضافه شدند، در کنار یکدیگر رکوردهای فراوانی رو تجربه کردیم که هیچ کدام از این اتفاقات بدون حضور و کمک شما میسر نبود." + "<br>" +
                                    "امیدواریم همانطور که تاکنون " + "<font color='Red'><b>" + difference.ToString() + "</b></font>" + " روز از همکاری صادقانه شما گذشته است، در سال جدید نیز شاهد روحیه و انگیزه بالای شما برای پیشرفت خود و اسنپ فود باشیم." + "<br>" +
                                    "در جدول زیر، نتیجه زحمات شما (تا تاریخ 29/12/1396) به امتیاز هایی تبدیل شده تا در نهایت جایگاه شغلی شما را در نظام هماهنگ پرداخت و ارتقا شغلی بهبود ببخشد." + "<br>";

                        //Table start.
                        mail.Body = mail.Body + "<table cellpadding='10' border='3px solid black' style='border-collapse: collapse' dir='rtl'> ";

                        //Building the Header row.
                        mail.Body = mail.Body + "<tr>";
                        foreach (DataColumn column in dt.Columns)
                        {
                            mail.Body = mail.Body + "<th>";
                            mail.Body = mail.Body + column.ColumnName;
                            mail.Body = mail.Body + "</th>";
                        }
                        mail.Body = mail.Body + "</tr>";

                        //Building the Data rows.
                        foreach (DataRow row in dt.Rows)
                        {
                            mail.Body = mail.Body + "<tr>";
                            foreach (DataColumn column in dt.Columns)
                            {
                                mail.Body = mail.Body + "<td>";
                                mail.Body = mail.Body + row[column.ColumnName];
                                mail.Body = mail.Body + "</td>";
                            }
                            mail.Body = mail.Body + "</tr>";
                        }

                        //Table end.
                        mail.Body = mail.Body + "</table>";

                        mail.Body = mail.Body + "<br>" + "مجموع امتیازات شغلی شما تا پایان سال جاری، " + "<font color='Red'><b>" + dt.Compute("sum(امتیاز)", string.Empty).ToString() + "</b></font>" + " امتیاز می باشد. ما بر این باور هستیم که در سال جدید بستر برای پیشرفت شما و ما در کنار یکدیگر بسیار فراهم می باشد. " + "<br>";
                                   


                        mail.Body = mail.Body + "<br><br><font size='3px'>" + "با تشکر" + "<br>" + "تیم مدیریت اسنپ فود" + "<br><b>" + "سامانه متمرکز اطلاعات و پایش عملکرد پرسنل اسنپ فود - SFES" + "</b>" + "</font>" +
                                    "<br><br><br><font color='Red'>" + "این ایمیل به صورت اتوماتیک ارسال شده است. لطفا به آن پاسخ ندهید." + "</font>" +
                                    "</font></p></td></tr></table>";

                        SmtpServer.Send(mail);
                    }
                    else
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("postman.sfes@gmail.com");
                        mail.IsBodyHtml = true;
                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("postman.sfes@gmail.com", "j86415173447");
                        SmtpServer.EnableSsl = true;
                        mail.To.Add(dt2.Rows[i][3].ToString());
                        mail.Subject = "جزئیات امتیازات شغلی - " + dt2.Rows[i][1].ToString();
                        mail.Body = "<table width = '100%'><tr><td align='right'><p dir='rtl'>" +
                                    "<font face='Tahoma'><font size='4px'> <b>" + dt2.Rows[i][1].ToString() + " عزیز " + "</b></font>" + "<br>" + "<br>" + "<font size='3px'>" +
                                    "هیچ امتیاز شغلی تا این لحظه برای شما در سامانه ثبت نگردیده است." + "</b><br><br></font>";
                        mail.Body = mail.Body +
                                    "<br><br><br><br><font size='3px'>" + "با تشکر" + "<br><br>" + "<b>" + "سامانه متمرکز اطلاعات و پایش عملکرد پرسنل اسنپ فود - SFES" + "</b>" + "</font>" +
                                    "<br><br><br><font color='Red'>" + "این ایمیل به صورت اتوماتیک ارسال شده است. لطفا به آن پاسخ ندهید." + "</font>" +
                                    "</font></p></td></tr></table>";

                        SmtpServer.Send(mail);
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
            RadMessageBox.Show(this, "ارسال ایمیل با موفقیت پایان یافت.", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
        }
    }
}
