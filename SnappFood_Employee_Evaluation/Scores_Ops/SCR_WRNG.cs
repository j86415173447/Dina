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
    public partial class SCR_WRNG : Telerik.WinControls.UI.RadForm
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

        public SCR_WRNG()
        {
            InitializeComponent();
            lbl_cur_scr.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_pic.TextAlignment = ContentAlignment.MiddleCenter;
            lbl_scr_after.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_Wrng_Cd.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_Red_Amt.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_tot_wnrg.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Fa_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Dep.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Nk_Name.TextAlignment = ContentAlignment.MiddleLeft;
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void Print_Click(object sender, EventArgs e)
        {
            Scores_Ops.Search_Staff_WRNG ob = new Scores_Ops.Search_Staff_WRNG(this);
            ob.constr = constr;
            ob.ShowDialog();
        }

        public void searching()
        {
            Clear_Frm();
            /////////////////////////////// Query search
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

            ////////////////////////////////////////////// Get tot_cap
            //DataTable dtsc1 = new DataTable();
            //OleDbDataAdapter adpsc1 = new OleDbDataAdapter();
            //adpsc1.SelectCommand = new OleDbCommand();
            //adpsc1.SelectCommand.Connection = oleDbConnection1;
            //oleDbCommand1.Parameters.Clear();
            //string lcommandsc1 = "SELECT [Sc_Yearly_Cap] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_SCORE_MANEGERIAL] where [Sc_Sub_Cd] = 'MG01'";
            //adpsc1.SelectCommand.CommandText = lcommandsc1;
            //adpsc1.Fill(dtsc1);

            //if (dtsc1.Rows.Count != 0)
            //{
            //    lbl_tot_wnrg.Text = dtsc1.Rows[0][0].ToString();
            //}
            //else
            //{
            //    lbl_tot_wnrg.Text = "تعریف نشده";
            //}
            ////////////////////////////////////////////// Get rec_tot
            //DataTable dtsc2 = new DataTable();
            //OleDbDataAdapter adpsc2 = new OleDbDataAdapter();
            //adpsc2.SelectCommand = new OleDbCommand();
            //adpsc2.SelectCommand.Connection = oleDbConnection1;
            //oleDbCommand1.Parameters.Clear();
            //string lcommandsc2 = "SELECT sum([Sc_Score]) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '"+ doc_cd + "' and [Sc_Item_Cd] = 'SC07' and left([Sc_Eff_DT],4) = " + cur_year;
            //adpsc2.SelectCommand.CommandText = lcommandsc2;
            //adpsc2.Fill(dtsc2);

            //if (dtsc2.Rows[0][0].ToString() != "")
            //{
            //    lbl_tot_wrng_this_type.Text = dtsc2.Rows[0][0].ToString();
            //}
            //else
            //{
            //    lbl_tot_wrng_this_type.Text = "0";
            //}

            ////////////////////////////////////////////////////////////////////// Update Grid
            DataTable dtsc55 = new DataTable();
            OleDbDataAdapter adpsc55 = new OleDbDataAdapter();
            adpsc55.SelectCommand = new OleDbCommand();
            adpsc55.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc55 = "SELECT [Sc_Item_Sub_Cd]'کد زیرگروه',[Sc_Item_Nm]'عنوان امتیاز',[Sc_Eff_DT] 'تاریخ موثر',[Sc_Description]'توضیحات',[Sc_Score]'مقدار امتیاز', [Insert_User] 'ثبت کننده' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '" + doc_cd + "' and [Sc_Item_Cd] = 'SC06' ";
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

            update_scr_data();
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

        private void SCR_MNG_Load(object sender, EventArgs e)
        {
            
            oleDbConnection1.ConnectionString = constr;
            ///////////////////////////////////////////////////////// initializing scr_type combo
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT '' 'Sc_Sub_Cd','' 'Sc_sub_Nm' union SELECT [Sc_Sub_Cd],[Sc_sub_Nm] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_SCORE_WARNING] where Sc_Actv = 1";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            Wrng_Type.DataSource = dt;
            Wrng_Type.ValueMember = "Sc_Sub_Cd";
            Wrng_Type.DisplayMember = "Sc_Sub_Nm";
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
            DT_Day = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            DT_Mth = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            DT_Yr = cur_year = psdate.GetYear(datetime).ToString();
        }

        private void SCR_Type_SelectedValueChanged(object sender, EventArgs e)
        {
            update_scr_data();
        }

        private void lbl_Wrng_Cd_TextChanged(object sender, EventArgs e)
        {
            if (Wrng_Type.SelectedIndex != 0)
            {
                //////////////////////////////////////////// Get tot_cap
                DataTable dtsc1 = new DataTable();
                OleDbDataAdapter adpsc1 = new OleDbDataAdapter();
                adpsc1.SelectCommand = new OleDbCommand();
                adpsc1.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommandsc1 = "SELECT [Sc_Amount] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_SCORE_WARNING] where [Sc_Sub_Cd] = '" + lbl_Wrng_Cd.Text + "'";
                adpsc1.SelectCommand.CommandText = lcommandsc1;
                adpsc1.Fill(dtsc1);
                lbl_Red_Amt.Text = dtsc1.Rows[0][0].ToString();
            }
            else
            {
                lbl_Red_Amt.Text = "";
            }
            update_scr_data();
        }

        private void Wrng_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Wrng_Type.SelectedIndex != 0)
            {
                lbl_Wrng_Cd.Text = Wrng_Type.SelectedValue.ToString();
            }
            else
            {
                lbl_Wrng_Cd.Text = "";
            }
        }

        public void update_scr_data()
        {
            if (doc_cd != "")
            {
                //////////////////////////////////////////// Get tot_cap
                DataTable dtsc1 = new DataTable();
                OleDbDataAdapter adpsc1 = new OleDbDataAdapter();
                adpsc1.SelectCommand = new OleDbCommand();
                adpsc1.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommandsc1 = "SELECT SUM([Sc_Score]) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Sc_Item_Cd] = 'SC06' and [Doc_No] = '" + doc_cd + "' and left([Sc_Eff_DT],4) = " + cur_year;
                adpsc1.SelectCommand.CommandText = lcommandsc1;
                adpsc1.Fill(dtsc1);

                if (dtsc1.Rows[0][0].ToString() != "NULL")
                {
                    lbl_tot_wnrg.Text = dtsc1.Rows[0][0].ToString();
                }
                else
                {
                    lbl_tot_wnrg.Text = "0";
                }
            }
            if (Wrng_Type.SelectedIndex != 0 && doc_cd != "")
            {
                lbl_scr_after.Text = (int.Parse(lbl_cur_scr.Text) + int.Parse(lbl_Red_Amt.Text)).ToString();
            }
            //if (Wrng_Type.SelectedIndex != 0 && doc_cd != "")
            //{
            //    //////////////////////////////////////////// Get rec_tot
            //    DataTable dtsc2 = new DataTable();
            //    OleDbDataAdapter adpsc2 = new OleDbDataAdapter();
            //    adpsc2.SelectCommand = new OleDbCommand();
            //    adpsc2.SelectCommand.Connection = oleDbConnection1;
            //    oleDbCommand1.Parameters.Clear();
            //    string lcommandsc2 = "SELECT SUM([Sc_Score]) FROM[SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where[Sc_Item_Cd] = '" + Wrng_Type.SelectedValue.ToString() + "' and[Doc_No] = '" + doc_cd + "' and left([Sc_Eff_DT], 4) = " + cur_year; 
            //    adpsc2.SelectCommand.CommandText = lcommandsc2;
            //    adpsc2.Fill(dtsc2);

                //    if (dtsc2.Rows[0][0].ToString() != "")
                //    {
                //        lbl_rec_sel.Text = dtsc2.Rows[0][0].ToString();
                //    }
                //    else
                //    {
                //        lbl_rec_sel.Text = "0";
                //    }
                //}
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Per_Name.Text == "")
            {
                RadMessageBox.ThemeName = "Office2010Silver";
                RadMessageBox.Show(this, " پرسنلی انتخاب نشده است. ", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else if (Wrng_Type.SelectedIndex == 0)
            {
                RadMessageBox.ThemeName = "Office2010Silver";
                RadMessageBox.Show(this, " نوع اخطار انتخاب نشده است. ", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                update_scr_data();
                var load = new Loading();
                if (true)
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
                    load.label1.Text = "در حال ثبت امتیاز";
                    load.Refresh();
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] ([Doc_No],[Sc_Item_Cd],[Sc_Item_Sub_Cd],[Sc_Item_Nm],[Sc_Description],[Sc_Score],[Sc_Eff_DT],[Sc_Actv],[Insert_DT],[Insert_Tm],[Insert_User]) VALUES (?,?,?,?,?,?,?,?,getdate(),getdate(),?)";
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", doc_cd);
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Cd", "SC06");
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Sub_Cd", Wrng_Type.SelectedValue.ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Nm", "کسر امتیاز اخطار");
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Description", Wrng_Type.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Score", lbl_Red_Amt.Text);
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
                    customerClubSend.Messages = new List<string>() { name + " عزیز \n" + lbl_Red_Amt.Text.Replace("-","") + " امتیاز بابت " + Wrng_Type.Text + " از امتیازات شما کسر گردید. \n" + "مجموع امتیاز شغلی شما: " + Score_Total + "\n" + "(اسنپ فود)" }.ToArray();
                    customerClubSend.MobileNumbers = new List<string>() { mobile }.ToArray();
                    customerClubSend.SendDateTime = null;
                    customerClubSend.CanContinueInCaseOfError = false;
                    var customerClubContactResponse = new CustomerClub().Send(token, customerClubSend);
                    load.Close();
                    searching();
                    update_scr_data();
                    RadMessageBox.ThemeName = "Office2010Silver";
                    RadMessageBox.Show(this, " اخطار با موفقیت ثبت شد. ", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    Reopen_Frm();
                }
            }
        }

        public void Reopen_Frm ()
        {
            var new_staff = new Scores_Ops.SCR_WRNG();
            new_staff.constr = constr;
            new_staff.token_key = token_key;
            new_staff.token_security = token_security;
            new_staff.user = user;
            new_staff.MdiParent = this.ParentForm;
            this.Close();
            new_staff.Show();
        }
    }
}
