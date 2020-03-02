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

namespace SnappFood_Employee_Evaluation.Training
{
    public partial class TRN_CLS_ANNOUNCEMENT : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt1 = new DataTable();

        public TRN_CLS_ANNOUNCEMENT()
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
            string lcommand1 = "select Sel3.[Per_Name], Sel2.[CRS_Name],Sel2.[CRS_Type],Sel1.[CLS_Cd],Sel4.[CLS_Date],CONVERT(nvarchar,Sel4.[CLS_From_Time],100) + ' - ' + CONVERT(nvarchar,Sel4.[CLS_To_Time],100),Sel4.[CLS_Location],Sel4.[CLS_Trainer],Sel3.[Email] from ( " +
                                "(SELECT [CLS_Cd],[CRS_CD],[Doc_No] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] where Per_Result is null) Sel1 left join (SELECT [CRS_CD],[CRS_Name],[CRS_Type] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_COURSE_MASTER]) Sel2 on Sel1.[CRS_CD] = Sel2.[CRS_CD] " +
                                "left join (SELECT [Doc_No],[Sex] + ' ' +[Per_Name] as [Per_Name],[Per_Mob],[Email] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel3 on Sel1.[Doc_No] = Sel3.[Doc_No] " +
                                "left join (SELECT [CLS_CD],[CLS_Location],[CLS_Trainer],[CLS_From_Time],[CLS_To_Time],[CLS_Date] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) Sel4 on Sel4.[CLS_CD] = Sel1.[CLS_Cd]) ";

            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            radLabel1.Text = "تعداد نفرات ثبت نام شده در کلاس های فعال " + dt1.Rows.Count + " می باشد.";
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
            string lcommand2 = "select Sel3.[Per_Name], Sel2.[CRS_Name],Sel2.[CRS_Type],Sel1.[CLS_Cd],Sel4.[CLS_Date],CONVERT(nvarchar,Sel4.[CLS_From_Time],100) + ' - ' + CONVERT(nvarchar,Sel4.[CLS_To_Time],100),Sel4.[CLS_Location],Sel4.[CLS_Trainer],Sel3.[Email] from ( " +
                                "(SELECT [CLS_Cd],[CRS_CD],[Doc_No] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] where Per_Result is null) Sel1 left join (SELECT [CRS_CD],[CRS_Name],[CRS_Type] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_COURSE_MASTER]) Sel2 on Sel1.[CRS_CD] = Sel2.[CRS_CD] " +
                                "left join (SELECT [Doc_No],[Sex] + ' ' +[Per_Name] as [Per_Name],[Per_Mob],[Email] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel3 on Sel1.[Doc_No] = Sel3.[Doc_No] " +
                                "left join (SELECT [CLS_CD],[CLS_Location],[CLS_Trainer],[CLS_From_Time],[CLS_To_Time],[CLS_Date] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) Sel4 on Sel4.[CLS_CD] = Sel1.[CLS_Cd]) ";

            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            Updation_Prog.Minimum = 0;
            Updation_Prog.Maximum = dt2.Rows.Count;
            ///////////////////////////////////////////////////////////////////////////////////////// Send Mail
            

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (dt2.Rows[i][8].ToString() != "-@zoodfood.com")
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("postman.sfes@gmail.com");
                    mail.IsBodyHtml = true;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("postman.sfes@gmail.com", "j86415173447");
                    SmtpServer.EnableSsl = true;
                    mail.To.Add(dt2.Rows[i][8].ToString());
                    mail.Subject = "یادآوری دوره " + dt2.Rows[i][1].ToString();
                    mail.Body = "<table width = '100%'><tr><td align='right'><p dir='rtl'>" +
                                "<font face='Tahoma'><font size='4px'> <b>" + dt2.Rows[i][0].ToString() + " عزیز " + "</b></font>" + "<br>" + "<br>" + "<font size='3px'>" +
                                "اطلاعات ثبت نامی شما برای دوره آموزشی به شرح زیر می باشد: " + "</b><br><br>" +
                                "نام دوره: <b>" + dt2.Rows[i][1].ToString() + "</b><br>" +
                                "نوع دوره: <b>" + dt2.Rows[i][2].ToString() + "</b><br>" +
                                "کد کلاس: <b>" + dt2.Rows[i][3].ToString() + "</b><br>" +
                                "تاریخ(های) برگزاری: <b>" + dt2.Rows[i][4].ToString() + "</b><br>" +
                                "ساعت برگزاری: <b>" + dt2.Rows[i][5].ToString() + "</b><br>" +
                                "محل برگزاری: <b>" + dt2.Rows[i][6].ToString() + "</b><br>" +
                                "مدرس: <b>" + dt2.Rows[i][7].ToString() + "</b>" +
                                "</font>" +
                                "<br><br><font size='3px'>" + "با تشکر" + "<br>" + "<b>" + "سامانه متمرکز اطلاعات و پایش عملکرد پرسنل اسنپ فود - SFES" + "</b>" + "</font>" +
                                "<br><br><br><font color='Red'>" + "این ایمیل به صورت اتوماتیک ارسال شده است. لطفا به آن پاسخ ندهید." + "</font>" +
                                "</font></p></td></tr></table>";

                    SmtpServer.Send(mail);
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
