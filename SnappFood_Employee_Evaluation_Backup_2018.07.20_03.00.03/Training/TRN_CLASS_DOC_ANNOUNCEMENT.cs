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
    public partial class TRN_CLASS_DOC_ANNOUNCEMENT : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt1 = new DataTable();
        public string crs_code;

        public TRN_CLASS_DOC_ANNOUNCEMENT()
        {
            InitializeComponent();
            radLabel1.TextAlignment = ContentAlignment.MiddleCenter;
        }

        private void TRN_CLS_ANNOUNCEMENT_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;

            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '' 'CLS_Course_Cd','' 'CLS_Course_Nm' union SELECT DISTINCT [CLS_Course_Cd],[CLS_Course_Nm] FROM  [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES] where [CLS_ACTV] = 1";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            Trainer.DataSource = dt4;
            Trainer.DisplayMember = "CLS_Course_Nm";
            Trainer.ValueMember = "CLS_Course_Cd";
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (dt1.Rows.Count != 0)
            {
                if (File_Name.Text != "")
                {
                    crs_code = Trainer.SelectedValue.ToString();
                    backgroundWorker1.WorkerReportsProgress = true;
                    backgroundWorker1.WorkerSupportsCancellation = true;
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    RadMessageBox.Show(this, "فایل منابع آموزشی آپلود نشد. \n لطفا ابتدا فایل منابع آموزشی را آپلود نمائید.", "بروز خطا", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
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
            string lcommand2 = "select Sel3.[Per_Name], Sel2.[CRS_Name],Sel2.[CRS_Type],Sel4.[CLS_Exam_DT], CONVERT(nvarchar,Sel4.[CLS_Exam_TM],100),Sel4.[CLS_Trainer],Sel3.[Email],Sel4.[CLS_ACTV] from ( " +
                                    "(SELECT [CLS_Cd],[CRS_CD],[Doc_No] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] where Per_Result is null and [CRS_CD] = '" + crs_code + "') Sel1 left join (SELECT [CRS_CD],[CRS_Name],[CRS_Type] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_COURSE_MASTER]) Sel2 on Sel1.[CRS_CD] = Sel2.[CRS_CD] " +
                                    "left join (SELECT [Doc_No],[Sex] + ' ' +[Per_Name] as [Per_Name],[Per_Mob],[Email] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel3 on Sel1.[Doc_No] = Sel3.[Doc_No] " +
                                    "left join (SELECT [CLS_CD],[CLS_Trainer],[CLS_Exam_DT],[CLS_Exam_TM],[cls_actv] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) Sel4 on Sel4.[CLS_CD] = Sel1.[CLS_Cd])  where Sel4.[CLS_ACTV] = 1 ";

            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            Updation_Prog.Minimum = 0;
            Updation_Prog.Maximum = dt2.Rows.Count;
            ///////////////////////////////////////////////////////////////////////////////////////// Send Mail
            

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                
                if (dt2.Rows[i][6].ToString() != "-@zoodfood.com")
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
                    mail.To.Add(dt2.Rows[i][6].ToString());
                    mail.Subject = "منابع آموزشی دوره " + dt2.Rows[i][1].ToString();
                    mail.Body = "<table width = '100%'><tr><td align='right'><p dir='rtl'>" +
                                "<font face='Tahoma'><font size='4px'> <b>" + dt2.Rows[i][0].ToString() + " عزیز " + "</b></font>" + "<br>" + "<br>" + "<font size='3px'>" +
                                "منابع جهت مطالعه برای آزمون دوره آموزشی ثبت نام شده شما به پیوست ارسال گردید. اطلاعات زمان برگزاری آزمون شما به شرح زیر می باشد: " + "</b><br><br>" +
                                "نام دوره: <b>" + dt2.Rows[i][1].ToString() + "</b><br>" +
                                "نوع دوره: <b>" + dt2.Rows[i][2].ToString() + "</b><br>" +
                                "تاریخ برگزاری آزمون: <b>" + dt2.Rows[i][3].ToString() + "</b><br>" +
                                "ساعت برگزاری آزمون: <b>" + dt2.Rows[i][4].ToString() + "</b><br>" +
                                "مدرس: <b>" + dt2.Rows[i][5].ToString() + "</b>" +
                                "</font>" +
                                "<br><br><font size='3px'>" + "با تشکر" + "<br>" + "<b>" + "سامانه متمرکز اطلاعات و پایش عملکرد پرسنل اسنپ فود - SFES" + "</b>" + "</font>" +
                                "<br><br><br><font color='Red'>" + "این ایمیل به صورت اتوماتیک ارسال شده است. لطفا به آن پاسخ ندهید." + "</font>" +
                                "</font></p></td></tr></table>";

                    SmtpServer.Send(mail);
                    SmtpServer.Dispose();
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

        private void Trainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Trainer.SelectedIndex != 0)
            {
                dt1.Clear();
                OleDbDataAdapter adp1 = new OleDbDataAdapter();
                adp1.SelectCommand = new OleDbCommand();
                adp1.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand1 = "select Sel3.[Per_Name], Sel2.[CRS_Name],Sel2.[CRS_Type],Sel1.[CLS_Cd],Sel4.[CLS_Date],CONVERT(nvarchar,Sel4.[CLS_From_Time],100) + ' - ' + CONVERT(nvarchar,Sel4.[CLS_To_Time],100),Sel4.[CLS_Location],Sel4.[CLS_Trainer],Sel3.[Email],Sel4.[CLS_ACTV] from ( " +
                                    "(SELECT [CLS_Cd],[CRS_CD],[Doc_No] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] where Per_Result is null and [CRS_CD] = '" + Trainer.SelectedValue + "') Sel1 left join (SELECT [CRS_CD],[CRS_Name],[CRS_Type] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_COURSE_MASTER]) Sel2 on Sel1.[CRS_CD] = Sel2.[CRS_CD] " +
                                    "left join (SELECT [Doc_No],[Sex] + ' ' +[Per_Name] as [Per_Name],[Per_Mob],[Email] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel3 on Sel1.[Doc_No] = Sel3.[Doc_No] " +
                                    "left join (SELECT [CLS_CD],[CLS_Location],[CLS_Trainer],[CLS_From_Time],[CLS_To_Time],[CLS_Date],[CLS_ACTV] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) Sel4 on Sel4.[CLS_CD] = Sel1.[CLS_Cd]) where Sel4.[CLS_ACTV] = 1 ";

                adp1.SelectCommand.CommandText = lcommand1;
                adp1.Fill(dt1);
                radLabel1.Text = "تعداد نفرات ثبت نام شده در کلاس های فعال " + dt1.Rows.Count + " می باشد.";
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
