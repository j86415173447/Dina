using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using SmsIrRestful;

namespace SnappFood_Employee_Evaluation.Personel
{

    public partial class Score_SMS : Telerik.WinControls.UI.RadForm
    {
        public string token_key;
        public string token_security;
        public string sms_line;
        public string constr;

        public Score_SMS()
        {
            InitializeComponent();
            radLabel1.TextAlignment = ContentAlignment.MiddleCenter;
        }

        private void Score_SMS_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "select sel3.[Per_Mob],sel1.[Doc_No],sel3.[Name],Sel1.[Score],sel2.[Job_Grade],sel2.[Job_Level] from ( " +
                                "(SELECT [Doc_No],sum([Sc_Score]) as 'Score' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] group by [Doc_No]) sel1 " +
                                "left join  (SELECT [Doc_no],[Sex] + ' ' + [Per_Name] as 'Name',[Termination],[Department],[per_mob] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel3 " +
                                "on sel1.[Doc_No] = sel3.[Doc_No] left join (SELECT [Job_Score],[Job_Grade],[Job_Level],[Job_Department],[Job_Salary_Base] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_JOB_LEVELING]) Sel2 " +
                                "on sel1.[Score] = sel2.[Job_Score] and sel3.[Department] = sel2.[Job_Department]) where sel3.[Termination] != 1 ";

            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            radLabel1.Text = "تعداد " + dt1.Rows.Count + "پرونده فعال موجود است.";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "select sel3.[Per_Mob],sel1.[Doc_No],sel3.[Name],Sel1.[Score],sel2.[Job_Grade],sel2.[Job_Level] from ( " +
                                "(SELECT [Doc_No],sum([Sc_Score]) as 'Score' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] group by [Doc_No]) sel1 " +
                                "left join  (SELECT [Doc_no],[Sex] + ' ' + [Per_Name] as 'Name',[Termination],[Department],[per_mob] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel3 " +
                                "on sel1.[Doc_No] = sel3.[Doc_No] left join (SELECT [Job_Score],[Job_Grade],[Job_Level],[Job_Department],[Job_Salary_Base] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_JOB_LEVELING]) Sel2 " +
                                "on sel1.[Score] = sel2.[Job_Score] and sel3.[Department] = sel2.[Job_Department]) where sel3.[Termination] != 1 ";

            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            Updation_Prog.Minimum = 0;
            Updation_Prog.Maximum = dt1.Rows.Count;
            ///////////////////////////////////////////////////////////////////////////////////////// Send SMS
            SmsIrRestful.Token token_instance = new SmsIrRestful.Token();
            var token = token_instance.GetToken(token_key, token_security);

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                ////////////////////////////////////////////////////////// Send SMS
                var customerClubSend = new CustomerClubSend();
                customerClubSend.Messages = new List<string>() { dt1.Rows[i][2].ToString() + "، وقت بخیر" + "\n" + "شماره پرونده: " + dt1.Rows[i][1].ToString() + "\n" + "امتیاز شغلی شما: " + dt1.Rows[i][3].ToString() + "\n" + "رتبه شغلی شما: " + dt1.Rows[i][4].ToString() + "\n" + "طبقه شغلی شما: " + dt1.Rows[i][5].ToString() + "\n\n" + "سامانه متمرکز اطلاعات شغلی دیجی کالا" }.ToArray();
                customerClubSend.MobileNumbers = new List<string>() { dt1.Rows[i][0].ToString() }.ToArray();
                customerClubSend.SendDateTime = null;
                customerClubSend.CanContinueInCaseOfError = false;
                var customerClubContactResponse = new CustomerClub().Send(token, customerClubSend);
                //SmsIrRestful.MessageSend message_instance = new SmsIrRestful.MessageSend();
                //var res = message_instance.Send(token, new SmsIrRestful.MessageSendObject()
                //{
                //    MobileNumbers = 
                //    Messages = 
                //    LineNumber = sms_line,
                //    SendDateTime = null,
                //    CanContinueInCaseOfError = false
                //});
                backgroundWorker1.ReportProgress(i + 1, "Updation");
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Updation_Prog.Value1 = e.ProgressPercentage;
            Updation_Prog.Text = "ارسال پیامک: " + e.ProgressPercentage + " از " + Updation_Prog.Maximum;
            
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RadMessageBox.Show("ارسال پیامک ها با موفقیت انجام شد.");
        }
    }
}
