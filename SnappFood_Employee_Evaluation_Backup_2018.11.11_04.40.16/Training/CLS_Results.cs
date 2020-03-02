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
using SmsIrRestful;

namespace SnappFood_Employee_Evaluation.Training
{
    public partial class CLS_Results : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public bool cls_active = true;
        public int per_hour_score;
        public string token_key;
        public string token_security;
        public string sms_line;
        public bool result;
        public SmsIrRestful.Token token_instance = new SmsIrRestful.Token();
        public string token = null;

        public CLS_Results()
        {
            InitializeComponent();
            CLS_CD.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_DTs.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_From.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Period.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_To.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Trainer.TextAlignment = ContentAlignment.MiddleLeft;
            CRS_NM.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Loc.TextAlignment = ContentAlignment.MiddleLeft;
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void CLS_Results_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            DataTable temp_dttt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT [Sc_Amount] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_SCORE_TRAINING]";
            adp.SelectCommand.CommandText = lcommand;
            temp_dttt.Clear();
            adp.Fill(temp_dttt);
            per_hour_score = int.Parse(temp_dttt.Rows[0][0].ToString());
        }

        private void Print_Click(object sender, EventArgs e)
        {
            Training.Search_Class_Result ob = new Training.Search_Class_Result(this);
            ob.constr = constr;
            ob.user = user;
            ob.ShowDialog();
        }

        public void update_grid()
        {
            grid.DataSource = null;
            if (cls_active)
            {
                DataTable temp_dt = new DataTable();
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand();
                adp.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY [Doc_No] ASC) AS 'ردیف',[Doc_No] 'شماره پرونده',[Per_Nm] 'نام و نام خانوادگی' FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] where [CLS_CD] = '" + CLS_CD.Text + "'";
                adp.SelectCommand.CommandText = lcommand;
                temp_dt.Clear();
                adp.Fill(temp_dt);
                DataColumn workCol = temp_dt.Columns.Add("قبول شده؟", typeof(bool));
                DataColumn workCol2 = temp_dt.Columns.Add("نمره/امتیاز", typeof(Int32));
                grid.DataSource = temp_dt;
                grid.BestFitColumns();
                grid.Columns[0].ReadOnly = true;
                grid.Columns[1].ReadOnly = true;
                grid.Columns[2].ReadOnly = true;
                grid.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
                Save_btn.Enabled = true;
            }
            else
            {
                DataTable temp_dt = new DataTable();
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand();
                adp.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY [Doc_No] ASC) AS 'ردیف',[Doc_No] 'شماره پرونده',[Per_Nm] 'نام و نام خانوادگی',[Per_result] 'قبول شده', [Per_Score] 'نمره/امتیاز' FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] where [CLS_CD] = '" + CLS_CD.Text + "'";
                adp.SelectCommand.CommandText = lcommand;
                temp_dt.Clear();
                adp.Fill(temp_dt);
                grid.DataSource = temp_dt;
                grid.BestFitColumns();
                grid.Columns[0].ReadOnly = true;
                grid.Columns[1].ReadOnly = true;
                grid.Columns[2].ReadOnly = true;
                grid.Columns[3].ReadOnly = true;
                grid.Columns[4].ReadOnly = true;
                grid.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
                Save_btn.Enabled = false;
            }
            Updation_Prog.Value1 = 0;
            Updation_Prog.Text = "";
        }

        public void Search()
        {
            DataTable search_dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT sel1.[CLS_CD],sel1.[CLS_Location],sel1.[CLS_Course_Nm],sel1.[CLS_Trainer],sel1.[CLS_From_Time],sel1.[CLS_To_Time],sel1.[CLS_Date],sel1.[CLS_ACTV],sel1.[CLS_Period] from ( " +
                              "(SELECT[CLS_CD],[CLS_CAPACITY],[CLS_Location],[CLS_Course_Nm],[CLS_Trainer],[CLS_From_Time],[CLS_To_Time],[CLS_Date],[CLS_ACTV],[CLS_Course_Cd],[CLS_Period] FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) sel1 " +
                              "left join (SELECT CLS_CD, count([CLS_Cd]) AS QTY FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] group by[CLS_CD]) sel2 on sel1.[CLS_CD] = sel2.[CLS_CD]) where sel1.[CLS_CD] = '" + CLS_CD.Text + "'";
            adp.SelectCommand.CommandText = lcommand;
            search_dt.Clear();
            adp.Fill(search_dt);
            CLS_DTs.Text = search_dt.Rows[0][6].ToString();
            CLS_From.Text = search_dt.Rows[0][4].ToString().Substring(0, 5);
            CLS_Period.Text = search_dt.Rows[0][8].ToString();
            CLS_To.Text = search_dt.Rows[0][5].ToString().Substring(0, 5);
            CLS_Trainer.Text = search_dt.Rows[0][3].ToString();
            CRS_NM.Text = search_dt.Rows[0][2].ToString();
            CLS_Loc.Text = search_dt.Rows[0][1].ToString();
            if (CLS_DTs.Text.Length > 53)
            {
                CLS_DTs.Font = new Font("Tahoma", 7);
            }
            else
            {
                CLS_DTs.Font = new Font("Tahoma", 9);
            }
            cls_active = bool.Parse(search_dt.Rows[0][7].ToString());
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            CLS_CD.Focus();
            CLS_CD.Select();
            if (token == null)
            {
                ////////////////////////////////////////////////////////// Get token SMS
                token = token_instance.GetToken(token_key, token_security);
                if (token == null)
                {
                    RadMessageBox.Show(this, "دریافت توکن پیامک با مشکل مواجه گردید", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
            }
            if (token != null)
            {
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.RunWorkerAsync();

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //////////////////////////////////////// Get Date Persian
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
            string DT_Day = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            string DT_Mth = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            string DT_Yr = psdate.GetYear(datetime).ToString();


            bool error = false;
            //////////////////////////////////////// check for blank entry
            for (int j = 0; j < grid.Rows.Count; j++)
            {
                if (grid.Rows[j].Cells[4].Value.ToString() == "")
                {
                    GridViewCellInfo cell = grid.Rows[j].Cells[4];
                    cell.Style.CustomizeFill = true;
                    cell.Style.BackColor = Color.Red;
                    cell.Style.DrawFill = true;
                    error = true;
                }
                else
                {
                    GridViewCellInfo cell = grid.Rows[j].Cells[4];
                    cell.Style.CustomizeFill = true;
                    cell.Style.BackColor = Color.Transparent;
                    cell.Style.DrawFill = true;
                }
            }
            if (error != true)
            {
                Updation_Prog.Minimum = 0;
                Updation_Prog.Maximum = grid.Rows.Count;
                

                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] SET [Per_Result] = ?,[Per_Score] = ?,[Update_Usr] = ?,[Update_DT] = getdate(),[Update_Tm] = getdate() " +
                                                " WHERE [CLS_CD] = '" + CLS_CD.Text + "' and [Doc_No] = '" + grid.Rows[i].Cells[1].Value.ToString() + "'";
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", grid.Rows[i].Cells[3].Value.ToString());
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", grid.Rows[i].Cells[4].Value.ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Chargoon_Id", user);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    /////////////////////////////////////////// Update Score table
                    if (grid.Rows[i].Cells[3].Value.ToString() == "True")
                    {
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] ([Doc_No],[Sc_Item_Cd],[Sc_Item_Sub_Cd],[Sc_Item_Nm],[Sc_Description],[Sc_Score],[Sc_Eff_DT],[Sc_Actv],[Insert_DT],[Insert_Tm],[Insert_User]) values (?,?,?,?,?,?,?,?,getdate(),getdate(),?)";
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", grid.Rows[i].Cells[1].Value.ToString());
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CAPACITY", "SC04");
                        oleDbCommand1.Parameters.AddWithValue("@CLS_Location", "TR01");
                        oleDbCommand1.Parameters.AddWithValue("@CLS_Course_Cd", "امتیاز آموزش ضمن خدمت");
                        oleDbCommand1.Parameters.AddWithValue("@CLS_Course_Nm", CRS_NM.Text + "-" + CLS_Period.Text + " ساعت" + "- نمره:" + grid.Rows[i].Cells[4].Value.ToString());
                        oleDbCommand1.Parameters.AddWithValue("@CLS_Trainer", (int.Parse(CLS_Period.Text) * per_hour_score).ToString());
                        oleDbCommand1.Parameters.AddWithValue("@CLS_From_Time", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_To_Time", "1");
                        oleDbCommand1.Parameters.AddWithValue("@CLS_Insrt_USR", user);
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();

                        ////////////////////////////////////////// Get total Score
                        string Score_Total;
                        DataTable dtsc4 = new DataTable();
                        OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
                        adpsc4.SelectCommand = new OleDbCommand();
                        adpsc4.SelectCommand.Connection = oleDbConnection1;
                        oleDbCommand1.Parameters.Clear();
                        string lcommandsc4 = "Select Sel2.[Sex] + ' ' + Sel2.[Per_Name] , Sel1.SUMit , Sel2.[Per_Mob] from (" +
                                             "(SELECT [Doc_No],sum([Sc_Score]) AS 'SUMit' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '" + grid.Rows[i].Cells[1].Value.ToString() + "' group by [Doc_No]) Sel1 " +
                                             "left join (Select [Doc_No],[sex],[per_name],[Per_mob] from [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel2 on sel1.Doc_No = Sel2.Doc_No)";
                        adpsc4.SelectCommand.CommandText = lcommandsc4;
                        adpsc4.Fill(dtsc4);
                        Score_Total = dtsc4.Rows[0][1].ToString();
                        string mobile = dtsc4.Rows[0][2].ToString();
                        string name = dtsc4.Rows[0][0].ToString();

                        ////////////////////////////////////////////////////////// Send SMS
                        var customerClubSend = new CustomerClubSend();
                        customerClubSend.Messages = new List<string>() { name + " عزیز \n" + (int.Parse(CLS_Period.Text) * per_hour_score).ToString() + " امتیاز بابت حضور در دوره آموزشی " + CRS_NM.Text + " برای شما ثبت شد. \n" + "مجموع امتیاز شغلی شما: " + Score_Total + "\n" + "(اسنپ فود)" }.ToArray();
                        customerClubSend.MobileNumbers = new List<string>() { mobile }.ToArray();
                        customerClubSend.SendDateTime = null;
                        customerClubSend.CanContinueInCaseOfError = false;
                        var customerClubContactResponse = new CustomerClub().Send(token, customerClubSend);
                        //SmsIrRestful.MessageSend message_instance = new SmsIrRestful.MessageSend();
                        //var res = customerClubSend.Send(token, new SmsIrRestful.MessageSendObject()
                        //{
                        //    MobileNumbers = new List<string>() { mobile }.ToArray(),
                        //    Messages = new List<string>() { name + " عزیز \n" + (int.Parse(CLS_Period.Text) * per_hour_score).ToString() + " امتیاز بابت حضور در دوره آموزشی " + CRS_NM.Text + " برای شما ثبت شد. \n" + "مجموع امتیاز شغلی شما: " + Score_Total + "(اسنپ فود)" }.ToArray(),
                        //    LineNumber = sms_line,
                        //    SendDateTime = null,
                        //    CanContinueInCaseOfError = false
                        //});
                    }

                    //////////////////////////////// progres update
                    backgroundWorker1.ReportProgress(i+1, "Updation");
                }
                /////////////////////////////////////////////// Deactivate class flag
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES] SET [CLS_ACTV] = 0 WHERE [CLS_CD] = '" + CLS_CD.Text + "'";
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
                result = true;
                this.Invoke((Func<DialogResult>)(() => RadMessageBox.Show(this, " نتایج با موفقیت ثبت گردید." + "\n\n" + " وضعیت کلاس به غیر فعال تغییر یافت." + "\n\n" + " امتیازات شغلی مربوطه محاسبه و اعمال شد." + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes)));
                this.BeginInvoke((Action)delegate () { Save_btn.Enabled = false; });
            }
            result = false;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Updation_Prog.Value1 = e.ProgressPercentage;
            Updation_Prog.Text = "پردازش رکورد ها: " + e.ProgressPercentage + " از " + Updation_Prog.Maximum;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void CLS_Period_TextChanged(object sender, EventArgs e)
        {
            //if (CLS_Period.Text == "غیر فعال")
            //{
            //    Save_btn.Enabled = false;
            //}
        }
    }
}
