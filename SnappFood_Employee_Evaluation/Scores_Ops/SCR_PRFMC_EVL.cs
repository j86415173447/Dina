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
using SmsIrRestful;

namespace SnappFood_Employee_Evaluation.Scores_Ops
{

    public partial class SCR_PRFMC_EVL : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public string usr_mob;
        public string doc_cd = "";
        public string cur_year;
        public string DT_Yr, DT_Mth, DT_Day;
        public SmsIrRestful.Token token_instance = new SmsIrRestful.Token();
        public string token = null;
        public string token_key;
        public string token_security;

        public SCR_PRFMC_EVL()
        {
            InitializeComponent();
            lbl_cur_scr.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_pic.TextAlignment = ContentAlignment.MiddleCenter;
            Per_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Fa_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Dep.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Nk_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Period.TextAlignment = ContentAlignment.MiddleLeft;
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void SCR_PRFMC_EVL_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            /////////////////////////////////////////////////////////// Get Date
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT day(GETDATE()), month(GETDATE()), year(GETDATE())";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            DateTime datetime = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
            ///////////////////////// Convert Persian
            PersianCalendar psdate = new PersianCalendar();
            DT_Day = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            DT_Mth = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            DT_Yr = cur_year = psdate.GetYear(datetime).ToString();
            string DT_Mth_query = psdate.GetMonth(datetime).ToString();
            ///////////////////////////////////////////////////////// initializing Period_Combo combo
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT [season_name] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_SCORE_PA_SEASONS] where id = " + DT_Mth_query + " or id = " + (int.Parse(DT_Mth_query) + 1).ToString() + " or id = " + (int.Parse(DT_Mth_query) - 1).ToString();
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            Period.Text = dt.Rows[0][0].ToString() + " " + DT_Yr.Substring(2, 2);
            ///////////////////////////////////////////////////////// initializing Result_Combo combo
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT '' 'Sc_Sub_Nm','1000' 'Sc_Amount' union SELECT [Sc_Sub_Nm],[Sc_Amount] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_SCORE_PA] where Sc_Actv = 1 order by [Sc_Amount] desc";
            adp.SelectCommand.CommandText = lcommand2;
            adp.Fill(dt2);
            Result.DataSource = dt2;
            Result.ValueMember = "Sc_Amount";
            Result.DisplayMember = "Sc_Sub_Nm";
        }

        private void Print_Click(object sender, EventArgs e)
        {
            Scores_Ops.Search_Staff_PRFMC ob = new Scores_Ops.Search_Staff_PRFMC(this);
            ob.constr = constr;
            ob.ShowDialog();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Result.SelectedIndex == 0)
            {
                RadMessageBox.Show(this, " نتیجه ارزیابی انتخاب نشده است. ", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else if (Per_Name.Text == "")
            {
                RadMessageBox.Show(this, " پرسنلی انتخاب نشده است. ", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                var load = new Loading();
                if (token == null)
                {
                    load.label1.Text = "در حال ارتباط با پنل پیامکی";
                    load.Show();
                    load.Refresh();
                    ////////////////////////////////////////////////////////// Get token SMS
                    token = token_instance.GetToken(token_key, token_security);
                }
                if (token == null)
                {
                    RadMessageBox.Show(this, "دریافت توکن پیامک با مشکل مواجه گردید", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    load.Close();
                }
                else
                {
                    ///////////////////////////////////////////////////////// Check duplicate score
                    DataTable dt2 = new DataTable();
                    OleDbDataAdapter adp2 = new OleDbDataAdapter();
                    adp2.SelectCommand = new OleDbCommand();
                    adp2.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommand2 = "SELECT [Sc_Description],[Sc_Eff_DT],[Insert_User] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Sc_Description] like N'%" + Period.Text + "%' and [doc_no] = N'" + doc_cd + "'";
                    adp2.SelectCommand.CommandText = lcommand2;
                    adp2.Fill(dt2);
                    if (dt2.Rows.Count == 0)
                    {
                        ///////////////////////////////////////////////////////// Get SCR_SUB_CODE
                        DataTable dt = new DataTable();
                        OleDbDataAdapter adp = new OleDbDataAdapter();
                        adp.SelectCommand = new OleDbCommand();
                        adp.SelectCommand.Connection = oleDbConnection1;
                        oleDbCommand1.Parameters.Clear();
                        string lcommand = "SELECT [Sc_Sub_Cd] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_SCORE_PA] where [Sc_Sub_Nm] = N'" + Result.Text + "'";
                        adp.SelectCommand.CommandText = lcommand;
                        adp.Fill(dt);
                        string sub_cd = dt.Rows[0][0].ToString();
                        ///////////////////////////////////////////////////
                        load.label1.Text = "در حال ثبت امتیاز";
                        load.Refresh();
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] ([Doc_No],[Sc_Item_Cd],[Sc_Item_Sub_Cd],[Sc_Item_Nm],[Sc_Description],[Sc_Score],[Sc_Eff_DT],[Sc_Actv],[Insert_DT],[Insert_Tm],[Insert_User]) VALUES (?,?,?,?,?,?,?,?,getdate(),getdate(),?)";
                        oleDbCommand1.Parameters.AddWithValue("@Doc_No", doc_cd);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Cd", "SC03");
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Sub_Cd", sub_cd);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Nm", "امتیاز عملکرد فصلی");
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Description", Period.Text + " - " + Result.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Score", Result.SelectedValue.ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Eff_DT", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Actv", "1");
                        oleDbCommand1.Parameters.AddWithValue("@Insert_User", user);
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
                                             "(SELECT [Doc_No],sum([Sc_Score]) AS 'SUMit' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '" + doc_cd + "' group by [Doc_No]) Sel1 " +
                                             "left join (Select [Doc_No],[sex],[per_name],[Per_mob] from [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel2 on sel1.Doc_No = Sel2.Doc_No)";
                        adpsc4.SelectCommand.CommandText = lcommandsc4;
                        adpsc4.Fill(dtsc4);
                        Score_Total = dtsc4.Rows[0][1].ToString();
                        string mobile = dtsc4.Rows[0][2].ToString();
                        string name = dtsc4.Rows[0][0].ToString();

                        load.label1.Text = "در حال ارسال پیامک";
                        load.Refresh();
                        ////////////////////////////////////////////////////////// Send SMS
                        var customerClubSend = new CustomerClubSend();
                        customerClubSend.Messages = new List<string>() { name + " عزیز \n" + Result.SelectedValue.ToString() + " امتیاز بابت " + Result.Text + " در ارزیابی عملکرد دوره " + Period.Text + " برای شما ثبت گردید. " + "\n" + "مجموع امتیاز شغلی شما: " + Score_Total + "\n" + "(اسنپ فود)" }.ToArray();
                        customerClubSend.MobileNumbers = new List<string>() { mobile }.ToArray();
                        customerClubSend.SendDateTime = null;
                        customerClubSend.CanContinueInCaseOfError = false;
                        var customerClubContactResponse = new CustomerClub().Send(token, customerClubSend);
                        load.Close();
                        searching();

                        RadMessageBox.Show(this, " امتیاز تشویقی با موفقیت ثبت شد. ", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                    else
                    {
                        RadMessageBox.Show(this, " امتیاز تشویقی این دوره برای " + Per_Name.Text + " قبلا توسط " + dt2.Rows[0][2].ToString() + " در تاریخ " + dt2.Rows[0][1].ToString() + " ثبت شده است. امکان ثبت مجدد نمی باشد.", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                }
            }
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
                               ",[Mentor],[sex],[Insert_User],[Termination] FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [doc_no] = '" + doc_cd + "'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            //System_Id.Text = dt1.Rows[0][1].ToString();
            //Per_Cd.Text = dt1.Rows[0][2].ToString();
            //Per_Ntl_ID.Text = dt1.Rows[0][3].ToString();
            Per_Dep.Text = dt1.Rows[0][4].ToString();
            //Main_Shift.Text = dt1.Rows[0][5].ToString();
            Per_Name.Text = dt1.Rows[0][6].ToString();
            Per_Fa_Name.Text = dt1.Rows[0][7].ToString();
            Per_Nk_Name.Text = dt1.Rows[0][8].ToString();
            //Per_tel.Text = dt1.Rows[0][9].ToString();
            usr_mob = dt1.Rows[0][10].ToString();
            //Per_Add.Text = dt1.Rows[0][11].ToString();
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

            //////////////////////////////////////////// Get Score Total
            string Score_Total;
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT [Doc_No],sum([Sc_Score]) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '" + doc_cd + "' group by [Doc_No]";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);

            if (dtsc4.Rows.Count != 0)
            {
                Score_Total = dtsc4.Rows[0][1].ToString();
            }
            else
            {
                Score_Total = "0";
            }
            lbl_cur_scr.Text = Score_Total.ToString();

            ////////////////////////////////////////////////////////////////////// Update Grid
            DataTable dtsc55 = new DataTable();
            OleDbDataAdapter adpsc55 = new OleDbDataAdapter();
            adpsc55.SelectCommand = new OleDbCommand();
            adpsc55.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc55 = "SELECT [Sc_Item_Sub_Cd]'کد زیرگروه',[Sc_Item_Nm]'عنوان امتیاز',[Sc_Eff_DT] 'تاریخ موثر',[Sc_Description]'توضیحات',[Sc_Score]'مقدار امتیاز', [Insert_User] 'ثبت کننده' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '" + doc_cd + "' and [Sc_Item_Cd] = 'SC03' ";
            adpsc55.SelectCommand.CommandText = lcommandsc55;
            dtsc55.Clear();
            adpsc55.Fill(dtsc55);
            grid.DataSource = dtsc55;
            grid.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            grid.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
            grid.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            grid.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
            grid.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
            grid.BestFitColumns();
        }

        public void Clear_Frm()
        {
            grid.DataSource = null;
            Per_Dep.Text = "";
            Per_Name.Text = "";
            Per_Fa_Name.Text = "";
            Per_Nk_Name.Text = "";
            Per_Pic.Image = null;
            Save.Enabled = Enabled;
        }
    }
}
