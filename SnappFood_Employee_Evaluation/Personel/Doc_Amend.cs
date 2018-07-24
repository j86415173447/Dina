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
using System.Linq;
using Telerik.WinControls.UI;
using System.IO;
using SmsIrRestful;
using System.Net.Mail;

namespace SnappFood_Employee_Evaluation.Personel
{
    public partial class Doc_Amend : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public string s1 = "";
        public string s2 = "";
        public string s3 = "";
        public string s4 = "";
        public string s5 = "";
        public string s6 = "";
        public string s7 = "";
        public string s8 = "";
        public DataTable Training_list = new DataTable();
        public string pic_address = "";
        private ErrorProvider errorProvider;
        public bool data_error = false;
        public string token_key;
        public string token_security;
        public string sms_line;

        public Doc_Amend()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            RadMessageBox.SetThemeName("Office2010Silver");
            radLabel35.TextAlignment = ContentAlignment.MiddleCenter;
            System_Id.TextAlignment = ContentAlignment.MiddleLeft;
            user_box.TextAlignment = ContentAlignment.MiddleLeft;
            Doc_Cd.TextAlignment = ContentAlignment.MiddleLeft;
            Score_Total.TextAlignment = ContentAlignment.MiddleLeft;
            Job_Level.TextAlignment = ContentAlignment.MiddleLeft;
            Doc_status.TextAlignment = ContentAlignment.MiddleCenter;
            Base_Salary.TextAlignment = ContentAlignment.MiddleLeft;
            termin_dt.TextAlignment = ContentAlignment.MiddleCenter;
            emp_dt.TextAlignment = ContentAlignment.MiddleLeft;
            birth_dt.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Cd.Select();
        }

        private void New_Staff_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            this.KeyPreview = true;
            Related_Mjr.SelectedIndex = 0;
            Main_Shift.SelectedIndex = 0;
            Sex.SelectedIndex = 0;
            Training_grid.DataSource = Training_list;
            user_box.Text = user;
            ///////////////////////////////////////////////////////// initializing department combo
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT '' 'Department_Nm','' 'Department_Cd' union SELECT [Department_Nm],[Department_Cd] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_DEPARTMENT] where [Department_Actv] = 1 order by Department_Cd asc";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            Per_Dep.DataSource = dt;
            Per_Dep.ValueMember = "Department_Cd";
            Per_Dep.DisplayMember = "Department_Nm";
            ///////////////////////////////////////////////////////// initializing Degree
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT [Degree] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_DEGREE_MASTER] order by ID asc";
            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            Degree.DataSource = dt2;
            Degree.DisplayMember = "degree";
            ///////////////////////////////////////////////////////// initializing training item
            DataTable dt3 = new DataTable();
            OleDbDataAdapter adp3 = new OleDbDataAdapter();
            adp3.SelectCommand = new OleDbCommand();
            adp3.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand3 = "SELECT '' 'Course_Title' union SELECT [Course_Title] FROM[SNAPP_CC_EVALUATION].[dbo].[CONF_COURSE_MASTER] WHERE[Course_Type] = N'اولیه' order by [Course_Title]";
            adp3.SelectCommand.CommandText = lcommand3;
            adp3.Fill(dt3);
            Training_Item.DataSource = dt3;
            Training_Item.DisplayMember = "Course_Title";
            ///////////////////////////////////////////////////////// initializing training item
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '' 'Trainer_Name' union SELECT [Trainer_Name] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TRAINERS_MASTER] WHERE [ACTIVE] = 'true' order by [Trainer_Name]";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            Trainer.DataSource = dt4;
            Trainer.DisplayMember = "Trainer_Name";
            ///////////////////////////////////////////////////////// initializing Coordinator item
            DataTable dt5 = new DataTable();
            OleDbDataAdapter adp5 = new OleDbDataAdapter();
            adp5.SelectCommand = new OleDbCommand();
            adp5.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand5 = "SELECT '1' 'row', '' 'Per_Nm' union SELECT '2' 'row' , N'نامشخص' 'Per_Nm' union SELECT '3' 'row', [Per_Nm] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TEAM_LEADERS_MASTER] WHERE [Level_Nm] = N'سرگروه' and [ACTV] = 1 ";
            adp5.SelectCommand.CommandText = lcommand5;
            adp5.Fill(dt5);
            Coord.DataSource = dt5;
            Coord.DisplayMember = "Per_Nm";
            ///////////////////////////////////////////////////////// initializing Leader item
            DataTable dt6 = new DataTable();
            OleDbDataAdapter adp6 = new OleDbDataAdapter();
            adp6.SelectCommand = new OleDbCommand();
            adp6.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand6 = "SELECT '1' 'row', '' 'Per_Nm' union SELECT '2' 'row' , N'نامشخص' 'Per_Nm' union SELECT '3' 'row', [Per_Nm] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TEAM_LEADERS_MASTER] WHERE [Level_Nm] = N'رهبر' and [ACTV] = 1 ";
            adp6.SelectCommand.CommandText = lcommand6;
            adp6.Fill(dt6);
            Leader.DataSource = dt6;
            Leader.DisplayMember = "Per_Nm";
            ///////////////////////////////////////////////////////// initializing Leader item
            DataTable dt7 = new DataTable();
            OleDbDataAdapter adp7 = new OleDbDataAdapter();
            adp7.SelectCommand = new OleDbCommand();
            adp7.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand7 = "SELECT '1' 'row', '' 'Per_Nm' union SELECT '2' 'row' , N'نامشخص' 'Per_Nm' union SELECT '3' 'row', [Per_Nm] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TEAM_LEADERS_MASTER] WHERE [Level_Nm] = N'رهبر' and [ACTV] = 1 ";
            adp7.SelectCommand.CommandText = lcommand7;
            adp7.Fill(dt7);
            Manager.DataSource = dt7;
            Manager.DisplayMember = "Per_Nm";
            ///////////////////////////////////////////////////////// initializing Training DT
            DataColumn dc;
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "عنوان آموزش";
            Training_list.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "مدرس";
            Training_list.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "تاریخ آموزش";
            Training_list.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "نوع آموزش";
            Training_list.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "مدت آموزش";
            Training_list.Columns.Add(dc);
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
                ////////////////////////////////////////////// Required field check
                if (!this.AreRequiredFieldsValid())
                {
                    return;
                }
                ////////////////////////////////////////////// if required field was OK
                else
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
                    string DT_Day = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
                    string DT_Mth = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
                    string DT_Yr = psdate.GetYear(datetime).ToString();
                    ////////////////////////////////////////////// Get Doc_No
                    //int doc_no;
                    //string doc_no_str;
                    //DataTable dt22 = new DataTable();
                    //OleDbDataAdapter adp22 = new OleDbDataAdapter();
                    //adp22.SelectCommand = new OleDbCommand();
                    //adp22.SelectCommand.Connection = oleDbConnection1;
                    //oleDbCommand1.Parameters.Clear();
                    //string lcommand22 = "SELECT max([Doc_No]) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]";
                    //adp22.SelectCommand.CommandText = lcommand22;
                    //adp22.Fill(dt22);
                    //if (dt22.Rows[0][0].ToString() == "")
                    //{
                    //    doc_no = 1;
                    //}
                    //else
                    //{
                    //    doc_no = int.Parse(dt22.Rows[0][0].ToString()) + 1;
                    //}
                    //if (doc_no < 10)
                    //{
                    //    doc_no_str = "000" + doc_no.ToString();
                    //}
                    //else if (doc_no > 9 && doc_no < 100)
                    //{
                    //    doc_no_str = "00" + doc_no.ToString();
                    //}
                    //else if (doc_no > 99 && doc_no < 1000)
                    //{
                    //    doc_no_str = "0" + doc_no.ToString();
                    //}
                    //else
                    //{
                    //    doc_no_str = doc_no.ToString();
                    //}
                    //Doc_Cd.Text = doc_no_str;
                    ////////////////////////////////////////////// Get System_ID
                    //int system_no;
                    //DataTable dt23 = new DataTable();
                    //OleDbDataAdapter adp23 = new OleDbDataAdapter();
                    //adp23.SelectCommand = new OleDbCommand();
                    //adp23.SelectCommand.Connection = oleDbConnection1;
                    //oleDbCommand1.Parameters.Clear();
                    //string lcommand23 = "SELECT max(right([system_id],3)) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Department] = N'" + Per_Dep.Text + "'";
                    //adp23.SelectCommand.CommandText = lcommand23;
                    //adp23.Fill(dt23);
                    //if (dt23.Rows[0][0].ToString() == "")
                    //{
                    //    system_no = int.Parse(Per_Dep.SelectedValue.ToString()) * 100;
                    //}
                    //else
                    //{
                    //    system_no = int.Parse(dt23.Rows[0][0].ToString()) + 1;
                    //}
                    //if (system_no % 100 == 0)
                    //{
                    //    system_no = system_no + 1;
                    //}
                    //System_Id.Text = Main_Shift.SelectedIndex.ToString() + system_no.ToString();
                    if (pic_address != "")
                    {
                        ////////////////////////////////////////////// convert picture
                        byte[] imageData = ReadFile(pic_address);
                        ////////////////////////////////////////////// INSERT INTO PER_DOCUMENTS TBL
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] SET [Doc_No] = ?,[System_Id] = ?,[Chargoon_Id] = ?,[Per_National_Cd] = ?,[Department] = ?,[Main_Shift] = ?,[Per_Name] = ?," +
                                                    "[Per_Fa_Name] = ?,[Per_Nk_Name] = ?,[Per_Tel] = ?,[Per_Mob] = ?,[Per_Add] = ?,[Per_Pic] = ?,[History] = ?,[Email] = ?,[Degree] = ?,[Major] = ?,[Major_Status] = ?,[Mentor] = ?, [Sex] = ? " + 
                                                    ", [English_Score] = ? , [Coordinator] = ? , [Leader] = ? , [Manager] = ? WHERE [Doc_No] = '" + Doc_Cd.Text + "'";
                        oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                        oleDbCommand1.Parameters.AddWithValue("@System_Id", System_Id.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Chargoon_Id", Per_Cd.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_National_Cd", Per_Ntl_ID.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Department", Per_Dep.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Main_Shift", Main_Shift.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Name", Per_Name.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Fa_Name", Per_Fa_Name.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Nk_Name", Per_Nk_Name.Text == "" ? "-" : Per_Nk_Name.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Tel", Per_tel.Text == "" ? "-" : Per_tel.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Mob", Per_mob.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Add", Per_Add.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Pic", (object)imageData);
                        oleDbCommand1.Parameters.AddWithValue("@History", History.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Email", (per_email.Text == "" ? "-" : per_email.Text) + "@zoodfood.com");
                        oleDbCommand1.Parameters.AddWithValue("@Degree", Degree.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Major", Major.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Major_Status", Related_Mjr.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Mentor", Mentor.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Sex", Sex.Text);
                        oleDbCommand1.Parameters.AddWithValue("@English_score", english_score.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Coordinator", Coord.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Leader", Leader.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Manager", Manager.Text);
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                    }
                    else
                    {
                        ////////////////////////////////////////////// INSERT INTO PER_DOCUMENTS TBL
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] SET [Doc_No] = ?,[System_Id] = ?,[Chargoon_Id] = ?,[Per_National_Cd] = ?,[Department] = ?,[Main_Shift] = ?,[Per_Name] = ?," +
                                                    "[Per_Fa_Name] = ?,[Per_Nk_Name] = ?,[Per_Tel] = ?,[Per_Mob] = ?,[Per_Add] = ?,[History] = ?,[Email] = ?,[Degree] = ?,[Major] = ?,[Major_Status] = ?,[Mentor] = ?, [Sex] = ?, [English_Score] = ? , [Coordinator] = ? , [Leader] = ? , [Manager] = ?  WHERE [Doc_No] = '" + Doc_Cd.Text + "'";
                        oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                        oleDbCommand1.Parameters.AddWithValue("@System_Id", System_Id.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Chargoon_Id", Per_Cd.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_National_Cd", Per_Ntl_ID.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Department", Per_Dep.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Main_Shift", Main_Shift.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Name", Per_Name.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Fa_Name", Per_Fa_Name.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Nk_Name", Per_Nk_Name.Text == "" ? "-" : Per_Nk_Name.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Tel", Per_tel.Text == "" ? "-" : Per_tel.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Mob", Per_mob.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Per_Add", Per_Add.Text);
                        oleDbCommand1.Parameters.AddWithValue("@History", History.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Email", (per_email.Text == "" ? "-" : per_email.Text) + "@zoodfood.com");
                        oleDbCommand1.Parameters.AddWithValue("@Degree", Degree.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Major", Major.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Major_Status", Related_Mjr.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Mentor", Mentor.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Sex", Sex.Text);
                        oleDbCommand1.Parameters.AddWithValue("@English_score", english_score.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Coordinator", Coord.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Leader", Leader.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Manager", Manager.Text);
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                    }

                    /////////////////////////////////////////// remove PRE_EVALUATION
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "DELETE FROM [SNAPP_CC_EVALUATION].[dbo].[PER_TRAINING] WHERE [Doc_No] = '" + Doc_Cd.Text + "' AND [Training_Type] = N'اولیه'";
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    
                    ////////////////////////////////////////////// INSERT INTO PER_PRE_Evaluation
                    for (int i = 0; i < Training_list.Rows.Count; i++)
                    {
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_TRAINING] ([Doc_No],[Training_Item],[Trainer],[Train_DT],[Training_Type],[Training_Period],[Insert_DT],[Insert_TM],[Insert_User]) VALUES (?,?,?,?,?,?,getdate(),getdate(),?)";
                        oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Training_Item", Training_list.Rows[i][0].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Trainer", Training_list.Rows[i][1].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Train_DT", Training_list.Rows[i][2].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Training_Type", Training_list.Rows[i][3].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Training_Period", Training_list.Rows[i][4].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Insert_User", user);
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                    }
                    //////////////////////////////////////////////// INSERT INTO PER_PRE_EVALUATION TBL
                    //oleDbCommand1.Parameters.Clear();
                    //oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[PER_PRE_EVALUATION] SET ([Doc_No] = ?,[Attention] = ?,[Q_App] = ?,[Q_Factor] = ?,[SW_Factor] = ?,[Reg_Factor_FE] = ?,[Q_FE] = ?,[Reg_Factor] = ?,[Speech] = ?) WHERE [Doc_No] = '" + Doc_Cd.Text + "'";
                    //oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                    //oleDbCommand1.Parameters.AddWithValue("@Attention", s1);
                    //oleDbCommand1.Parameters.AddWithValue("@Q_App", s2);
                    //oleDbCommand1.Parameters.AddWithValue("@Q_Factor", s3);
                    //oleDbCommand1.Parameters.AddWithValue("@SW_Factor", s4);
                    //oleDbCommand1.Parameters.AddWithValue("@Reg_Factor_FE", s5);
                    //oleDbCommand1.Parameters.AddWithValue("@Q_FE", s6);
                    //oleDbCommand1.Parameters.AddWithValue("@Reg_Factor", s7);
                    //oleDbCommand1.Parameters.AddWithValue("@Speech", s8);
                    //oleDbConnection1.Open();
                    //oleDbCommand1.ExecuteNonQuery();
                    //oleDbConnection1.Close();
                    //////////////////////////////////////////// SCORE CALCULATION AND SCORE TABLE UPDATE
                    int score1 = 0;
                    int score2 = 0;
                    int score3 = 0;

                    /////////////////////////////////////////// remove score table
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "DELETE FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] WHERE [Doc_No] = '" + Doc_Cd.Text + "' AND [Sc_Item_Cd] = 'SC01'";
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();

                    //////////////////////// DEGREE SCORE - SC1
                    DataTable dtsc1 = new DataTable();
                    OleDbDataAdapter adpsc1 = new OleDbDataAdapter();
                    adpsc1.SelectCommand = new OleDbCommand();
                    adpsc1.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommandsc1 = "SELECT [Sc_Item_Cd],[Sc_Sub_Cd],[Sc_Item_Nm],[Sc_Sub_Nm],[Sc_Amount] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_SCORE_DEGREE] where [SC_Actv] = 1 AND [Sc_sub_Nm] = N'" + Degree.Text + " " + Related_Mjr.Text + "'";
                    adpsc1.SelectCommand.CommandText = lcommandsc1;
                    adpsc1.Fill(dtsc1);

                    if (dtsc1.Rows.Count == 1)
                    {
                        

                        score1 = int.Parse(dtsc1.Rows[0][4].ToString());
                        /////////////////////////////////////////// UPDATE SCORE TABLE
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] ([Doc_No],[Sc_Item_Cd],[Sc_Item_Sub_Cd],[Sc_Item_Nm],[Sc_Description],[Sc_Score],[Sc_Eff_DT],[Sc_Actv],[Insert_DT],[Insert_Tm],[Insert_User]) VALUES (?,?,?,?,?,?,?,?,getdate(),getdate(),?)";
                        oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Cd", dtsc1.Rows[0][0].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Sub_Cd", dtsc1.Rows[0][1].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Nm", dtsc1.Rows[0][2].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Description", dtsc1.Rows[0][3].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Score", dtsc1.Rows[0][4].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Eff_DT", emp_dt.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Actv", "1");
                        oleDbCommand1.Parameters.AddWithValue("@Insert_User", "محاسبه اتوماتیک - تشکیل پرونده");
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                    }

                    /////////////////////////////////////////// remove score table
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "DELETE FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] WHERE [Doc_No] = '" + Doc_Cd.Text + "' AND [Sc_Item_Cd] = 'SC00'";
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();

                    ////////////////////////// English SCORE - SC2

                    if (int.Parse(english_score.Text) != 0)
                    {
                        score2 = int.Parse(english_score.Text);
                        /////////////////////////////////////////// get ENG score
                        DataTable dtsc1111 = new DataTable();
                        OleDbDataAdapter adpsc1111 = new OleDbDataAdapter();
                        adpsc1111.SelectCommand = new OleDbCommand();
                        adpsc1111.SelectCommand.Connection = oleDbConnection1;
                        oleDbCommand1.Parameters.Clear();
                        string lcommandsc1111 = "SELECT [ENG_SCR] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_SCORE_ENG] where  [ENG_PNT] = '" + english_score.Text + "'";
                        adpsc1.SelectCommand.CommandText = lcommandsc1111;
                        adpsc1.Fill(dtsc1111);
                        /////////////////////////////////////////// UPDATE SCORE TABLE
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] ([Doc_No],[Sc_Item_Cd],[Sc_Item_Sub_Cd],[Sc_Item_Nm],[Sc_Description],[Sc_Score],[Sc_Eff_DT],[Sc_Actv],[Insert_DT],[Insert_Tm],[Insert_User]) VALUES (?,?,?,?,?,?,?,?,getdate(),getdate(),?)";
                        oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Cd", "SC00");
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Sub_Cd", "EN00");
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Nm", "امتیاز آزمون زبان انگلیسی");
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Description", "درصد پاسخگوئی: " + score2.ToString() + "%");
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Score", dtsc1111.Rows[0][0].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Eff_DT", emp_dt.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Actv", "1");
                        oleDbCommand1.Parameters.AddWithValue("@Insert_User", "محاسبه اتوماتیک - تشکیل پرونده");
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                    }
                    /////////////////////////////////////////////// BACK GROUND SCORE - SC3
                    if (int.Parse(History.Text) > 0)
                    {
                        DataTable dtsc3 = new DataTable();
                        OleDbDataAdapter adpsc3 = new OleDbDataAdapter();
                        adpsc3.SelectCommand = new OleDbCommand();
                        adpsc3.SelectCommand.Connection = oleDbConnection1;
                        oleDbCommand1.Parameters.Clear();
                        string lcommandsc3 = "SELECT [Sc_Item_Cd],[Sc_Item_Nm],[Sc_Sub_Cd],[Sc_Sub_Nm],[Sc_Tier1],[Sc_Tier2],[Sc_Tier3],[Sc_Tier4],[Sc_Yearly_Cap] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_SCORE_BACK_GROUND] where [SC_Actv] = 1 AND [Sc_Sub_Cd] = 'BG02'";
                        adpsc3.SelectCommand.CommandText = lcommandsc3;
                        adpsc3.Fill(dtsc3);

                        int tier1 = int.Parse(dtsc3.Rows[0][4].ToString());
                        int tier2 = int.Parse(dtsc3.Rows[0][5].ToString());
                        int tier3 = int.Parse(dtsc3.Rows[0][6].ToString());
                        int tier4 = int.Parse(dtsc3.Rows[0][7].ToString());
                        int tier11 = 0;
                        int tier22 = 0;
                        int tier33 = 0;
                        int tier44 = 0;
                        int BG_Amount = int.Parse(History.Text);
                        if (BG_Amount > 6)
                        {
                            tier11 = 6;
                            BG_Amount = BG_Amount - 6;
                            if (BG_Amount > 6)
                            {
                                tier22 = 6;
                                BG_Amount = BG_Amount - 6;
                                if (BG_Amount > 12)
                                {
                                    tier33 = 12;
                                    BG_Amount = BG_Amount - 12;
                                    if (BG_Amount > 0)
                                    {
                                        tier44 = BG_Amount;
                                    }
                                }
                                else
                                {
                                    tier33 = BG_Amount;
                                }
                            }
                            else
                            {
                                tier22 = BG_Amount;
                            }
                        }
                        else
                        {
                            tier11 = BG_Amount;
                        }
                        score3 = (tier1 * tier11) + (tier2 * tier22) + (tier3 * tier33) + (tier4 * tier44);
                        /////////////////////////////////////////// Remove 
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "DELETE FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] WHERE [Doc_No] = '" + Doc_Cd.Text + "' AND [Sc_Item_Sub_Cd] = 'BG02'";
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                        /////////////////////////////////////////// UPDATE SCORE TABLE
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] ([Doc_No],[Sc_Item_Cd],[Sc_Item_Sub_Cd],[Sc_Item_Nm],[Sc_Description],[Sc_Score],[Sc_Eff_DT],[Sc_Actv],[Insert_DT],[Insert_Tm],[Insert_User]) VALUES (?,?,?,?,?,?,?,?,getdate(),getdate(),?)";
                        oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Cd", dtsc3.Rows[0][0].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Sub_Cd", dtsc3.Rows[0][2].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Nm", dtsc3.Rows[0][1].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Description", History.Text + " ماه " + dtsc3.Rows[0][3].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Score", score3.ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Eff_DT", emp_dt.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Actv", "1");
                        oleDbCommand1.Parameters.AddWithValue("@Insert_User", "محاسبه اتوماتیک - تشکیل پرونده");
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                        
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
                    }
                    //Score_Total.Text = (score1 + score2 + score3).ToString();
                    //////////////////////////////////////////////// remove previuos station
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[PER_STATIONS] SET [Doc_No] = ''  where [Doc_no] = '" + Doc_Cd.Text + "'";
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    //////////////////////////////////////////////// Update station table
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[PER_STATIONS] SET [Doc_No] = ?  where [main_shift] = N'" + Main_Shift.Text + "' and [station_no] = '" + Station.Text + "'";
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
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

                    //////////////////////////////////////////////////////////// Send SMS
                    //SmsIrRestful.Token token_instance = new SmsIrRestful.Token();
                    //var token = token_instance.GetToken(token_key, token_security);

                    //SmsIrRestful.MessageSend message_instance = new SmsIrRestful.MessageSend();
                    //var res = message_instance.Send(token, new SmsIrRestful.MessageSendObject()
                    //{
                    //    MobileNumbers = new List<string>() { Per_mob.Text }.ToArray(),
                    //    Messages = new List<string>() { Sex.Text + " " + Per_Name.Text + " عزیز \n" + "مشخصات شما در سامانه متمرکز اطلاعات پرسنلی با شماره پرونده " + Doc_Cd.Text + " ثبت شد. \n" + "امتیاز شغلی شما: " + Score_Total.Text + "\n" + "به خانواده بزرگ اسنپ فود خوش آمدید" }.ToArray(),
                    //    LineNumber = sms_line,
                    //    SendDateTime = null,
                    //    CanContinueInCaseOfError = false
                    //});
                    SmsIrRestful.Token token_instance = new SmsIrRestful.Token();
                    var token = token_instance.GetToken(token_key, token_security);
                    ////////////////////////////////////////////////////////// add to customer club
                    var customerClubContactObject = new CustomerClubContactObject()
                    {
                        Prefix = Sex.Text,
                        FirstName = "-",
                        LastName = Per_Name.Text,
                        Mobile = Per_mob.Text,
                        BirthDay = null,
                        CategoryId = null
                    };
                    var customerClubContactResponse = new CustomerClubContact().Create(token, customerClubContactObject);

                    RadMessageBox.Show(this, " اطلاعات پرونده با موفقیت ویرایش گردید " + "\n\n" + " شماره پرونده: " + Doc_Cd.Text + "\n\n" + "مجموع امتیاز شغلی محاسبه شده: " + Score_Total.Text + "\n\n" + "حقوق پایه منطبق با امتیاز: " + string.Format("{0:#,##0}", int.Parse(dtsc333.Rows[0][4].ToString())) + " ریال " + "\n" , "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
            }
        }

        byte[] ReadFile(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private bool AreRequiredFieldsValid()
        {
            data_error = false;
            bool tab1 = false;
            bool tab2 = false;
            bool tab3 = false;
            bool tab4 = false;

            if (Per_Ntl_ID.Text.Length < 10)
            {
                this.errorProvider.SetError(this.Per_Ntl_ID, "کد ملی صحیح وارد نشده است");
                data_error = true; tab1 = true;
            }
            if (Main_Shift.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Main_Shift, "شیفت انتخاب نشده است");
                data_error = true; tab1 = true;
            }
            if (Per_Dep.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Per_Dep, "واحد سازمانی وارد نشده است");
                data_error = true; tab4 = true;
            }
            if (Per_Cd.Text == "")
            {
                this.errorProvider.SetError(this.Per_Cd, "کد پرسنلی شرکت وارد نشده است");
                data_error = true; tab1 = true;
            }
            if (Sex.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Sex, "جنسیت انتخاب نشده است");
                data_error = true; tab1 = true;
            }
            if (Per_Name.Text == "")
            {
                this.errorProvider.SetError(this.Per_Name, "نام وارد نشده است");
                data_error = true; tab1 = true;
            }
            if (Per_Fa_Name.Text == "")
            {
                this.errorProvider.SetError(this.Per_Fa_Name, "نام پدر وارد نشده است");
                data_error = true; tab1 = true;
            }
            if (History.Text == "")
            {
                this.errorProvider.SetError(this.radLabel20, "سابقه کار وارد نشده است");
                data_error = true; tab1 = true;
            }
            if (Per_Add.Text == "")
            {
                this.errorProvider.SetError(this.Per_Add, "آدرس وارد نشده است");
                data_error = true; tab1 = true;
            }
            if (Station.Text == "")
            {
                this.errorProvider.SetError(this.Station, "استیشن وارد نشده است");
                data_error = true; tab4 = true;
            }
            if (Coord.SelectedIndex == 0)
            {
                errorProvider.SetError(this.Coord, "سرگروه مرتبط انتخاب نشده است");
                data_error = true; tab4 = true;
            }
            if (Leader.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Leader, "رهبر مرتبط انتخاب نشده است");
                data_error = true; tab4 = true;
            }
            if (Manager.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Manager, "مدیر مرتبط انتخاب نشده است");
                data_error = true; tab4 = true;
            }
            if (Per_mob.Text.Length != 11)
            {
                this.errorProvider.SetError(this.Per_mob, "شماره موبایل صحیح وارد نشده است");
                data_error = true; tab1 = true;
            }
            if (Degree.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Degree, "آخرین مدرک تحصیلی انتخاب نشده است");
                data_error = true; tab1 = true;
            }
            if (Major.Text == "")
            {
                this.errorProvider.SetError(this.Major, "رشته تحصیلی وارد نشده است");
                data_error = true; tab1 = true;
            }
            if (Related_Mjr.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Related_Mjr, "نوع رشته انتخاب نشده است");
                data_error = true; tab1 = true;
            }
            if (Training_list.Rows.Count == 0)
            {
                this.errorProvider.SetError(this.Training_Item, "آموزش اولیه وارد نشده است");
                data_error = true; tab2 = true;
            }
            if (s1 == "" || s2 == "" || s3 == "" || s4 == "" || s5 == "" || s6 == "" || s7 == "" || s8 == "")
            {
                this.errorProvider.SetError(this.Attention, "ارزیابی اولیه تکمیل نشده است");
                data_error = true; tab3 = true;
            }
            if (english_score.Text == "" || int.Parse(english_score.Text) >= 101)
            {
                this.errorProvider.SetError(this.english_score, "نمره آزمون زبان صحیح وارد نشده است");
                data_error = true; tab3 = true;
            }
            if (Per_Pic == null || Per_Pic.Image == null)
            {
                this.errorProvider.SetError(this.Per_Pic, "عکس پرسنلی آپلود نشده است");
                data_error = true; tab1 = true;
            }
            if (Mentor.Text == "")
            {
                this.errorProvider.SetError(this.Mentor, "نام مربی وارد نشده است");
                data_error = true; tab4 = true;
            }
            ////////////////////////////////////////////////// check duplicate
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT [Per_Name],[Chargoon_Id],[Per_National_Cd],[Per_Mob] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Doc_No] != '" + Doc_Cd.Text + "' and ([Chargoon_Id] = '" + Per_Cd.Text + "' or [Per_National_Cd] = '" + Per_Ntl_ID.Text + "' or [Per_Mob] = '" + Per_mob.Text + "')";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            if (dt1.Rows.Count > 1)
            {
                this.errorProvider.SetError(this.Per_Cd, "داده تکراری در کد پرسنلی یا شماره موبایل یا کد ملی");
                data_error = true; tab1 = true;
                RadMessageBox.SetThemeName("Office2010Silver");
                RadMessageBox.Show(this, "داده مشابه یافت شد: " + dt1.Rows[0][0].ToString() + "\n", "بروز خطا", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            if (Main_Shift.SelectedIndex != 0 && Station.Text != "")
            {
                ////////////////////////////////////////////////// check duplicate station
                DataTable dt2 = new DataTable();
                OleDbDataAdapter adp2 = new OleDbDataAdapter();
                adp2.SelectCommand = new OleDbCommand();
                adp2.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand2 = "Select sel1.Doc_No, Sel2.Per_Name from ((SELECT [Station_No],[Main_Shift],[Doc_No] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_STATIONS]) Sel1 " +
                                   "left join (select[Doc_No],[per_name] from[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel2 on sel1.Doc_No = Sel2.Doc_No) where Sel1.[main_shift] = N'" + Main_Shift.Text + "' and sel1.[station_no] = '" + Station.Text + "'";
                adp2.SelectCommand.CommandText = lcommand2;
                adp2.Fill(dt2);
                if (dt2.Rows.Count != 0)
                {
                    if (dt2.Rows[0][0].ToString() != "")
                    {
                        if (dt2.Rows[0][1].ToString() != Per_Name.Text)
                        {
                            this.errorProvider.SetError(this.Station, "استیشن وارد شده متعلق به " + dt2.Rows[0][1].ToString() + " می باشد");
                            data_error = true; tab4 = true;
                        }
                    }
                }
                else
                {
                    this.errorProvider.SetError(this.Station, "استیشن وارد شده، تعریف شده نیست");
                    data_error = true; tab4 = true;
                }
            }
            if (data_error == false)
            {
                return true;
            }
            else
            {
                string error_message = "بروز خطا در بخش" + "\n\n";
                if (tab1 == true)
                {
                    error_message = error_message + "اطلاعات پرسنلی" + "\n";
                }
                if (tab2 == true)
                {
                    error_message = error_message + "آموزش اولیه" + "\n";
                }
                if (tab3 == true)
                {
                    error_message = error_message + "ارزیابی اولیه" + "\n";
                }
                if (tab4 == true)
                {
                    error_message = error_message + "اطلاعات سازمانی" + "\n";
                }

                RadMessageBox.Show(this, error_message + "\n", "بروز خطا", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                return false;
            }
        }

        private void Per_Pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Images |*.JPG";
            if (op.ShowDialog() == DialogResult.OK)
            {
                Per_Pic.ImageLocation = op.FileName;
                pic_address = op.FileName;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
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
            //DT_Day.Text = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            //DT_Mth.Text = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            //DT_Yr.Text = psdate.GetYear(datetime).ToString();
        }

        private void radRadioButton4_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            s1 = (sender as RadRadioButton).Text;
        }

        private void radRadioButton8_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            s2 = (sender as RadRadioButton).Text;
        }

        private void radRadioButton12_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            s3 = (sender as RadRadioButton).Text;
        }

        private void radRadioButton13_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            s4 = (sender as RadRadioButton).Text;
        }

        private void radRadioButton17_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            s5 = (sender as RadRadioButton).Text;
        }

        private void radRadioButton21_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            s6 = (sender as RadRadioButton).Text;
        }

        private void radRadioButton25_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            s7 = (sender as RadRadioButton).Text;
        }

        private void radRadioButton29_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            s8 = (sender as RadRadioButton).Text;
        }

        private void english_score_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DT_Day_TextChanged(object sender, EventArgs e)
        {
            if(ActiveControl.Text.Length == 2)
            {
                this.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void Br_Yr_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl.Text.Length == 4)
            {
                this.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            if (!Training_Date.MaskFull || Training_Item.SelectedIndex == 0 || Trainer.SelectedIndex == 0 || int.Parse(Training_Date.Text.Substring(0, 4)) < 1396 || int.Parse(Training_Date.Text.Substring(5, 2)) > 12 || int.Parse(Training_Date.Text.Substring(8, 2)) > 31)
            {
                RadMessageBox.Show(this, "حداقل یکی از پارامترهای آموزش صحیح نبود یا وارد نشده است", "بروز خطا", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                DataRow newrow = Training_list.NewRow();
                newrow["عنوان آموزش"] = Training_Item.Text;
                newrow["مدرس"] = Trainer.Text;
                newrow["تاریخ آموزش"] = Training_Date.Text;
                newrow["نوع آموزش"] = "اولیه";
                newrow["مدت آموزش"] = "پیش فرض";
                Training_list.Rows.Add(newrow);
                List<string> conditions = new List<string>();
                for (int i = 0; i < Training_list.Rows.Count; i++)
                {
                    conditions.Add("[Course_Title] != N'" + Training_list.Rows[i][0].ToString() + "'");
                }
                ///////////////////////////////////////////////////////// initializing training item
                DataTable dt3 = new DataTable();
                OleDbDataAdapter adp3 = new OleDbDataAdapter();
                adp3.SelectCommand = new OleDbCommand();
                adp3.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand3 = "SELECT '' 'Course_Title' union SELECT [Course_Title] FROM[SNAPP_CC_EVALUATION].[dbo].[CONF_COURSE_MASTER] WHERE [Course_Type] = N'اولیه' ";
                if (conditions.Count != 0)
                {
                    lcommand3 = lcommand3 + " AND " + string.Join(" AND ", conditions.ToArray());
                }
                lcommand3 = lcommand3 + " order by [Course_Title]";
                adp3.SelectCommand.CommandText = lcommand3;
                adp3.Fill(dt3);
                Training_Item.DataSource = dt3;
                Training_Item.DisplayMember = "Course_Title";
                Trainer.SelectedIndex = 0;
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            pic_address = "";
            Personel.Search_Staff ob = new Personel.Search_Staff(this);
            ob.constr = constr;
            ob.ShowDialog();
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
                               ",[Mentor],[sex],[Insert_User],[Termination],[English_Score],[Coordinator],[Leader]" + 
                               ",[Manager],[Termination_DT] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [doc_no] = '" + Doc_Cd.Text + "'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            System_Id.Text = dt1.Rows[0][1].ToString();
            Per_Cd.Text = dt1.Rows[0][2].ToString();
            Per_Ntl_ID.Text = dt1.Rows[0][3].ToString();
            Per_Dep.Text = dt1.Rows[0][4].ToString();
            Main_Shift.Text = dt1.Rows[0][5].ToString();
            Per_Name.Text = dt1.Rows[0][6].ToString();
            Per_Fa_Name.Text = dt1.Rows[0][7].ToString();
            Per_Nk_Name.Text = dt1.Rows[0][8].ToString();
            Per_tel.Text = dt1.Rows[0][9].ToString();
            Per_mob.Text = dt1.Rows[0][10].ToString();
            Per_Add.Text = dt1.Rows[0][11].ToString();
            english_score.Text = dt1.Rows[0][24].ToString();
            Coord.Text = dt1.Rows[0][25].ToString();
            Leader.Text = dt1.Rows[0][26].ToString();
            Manager.Text = dt1.Rows[0][27].ToString();
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
            History.Text = dt1.Rows[0][13].ToString();
            emp_dt.Text = dt1.Rows[0][14].ToString();
            birth_dt.Text = dt1.Rows[0][15].ToString();
            per_email.Text = dt1.Rows[0][16].ToString().Replace("@zoodfood.com","");
            Degree.Text = dt1.Rows[0][17].ToString();
            Major.Text = dt1.Rows[0][18].ToString();
            Related_Mjr.Text = dt1.Rows[0][19].ToString();
            Mentor.Text = dt1.Rows[0][20].ToString();
            Sex.Text = dt1.Rows[0][21].ToString();
            user_box.Text = dt1.Rows[0][22].ToString();
            if (dt1.Rows[0][23].ToString() == "False")
            {
                Doc_status.Text = "در حال کار";
            }
            else
            {
                Doc_status.Text = "قطع همکاری";
                termin_dt.Text =  dt1.Rows[0][28].ToString();
            }
            ///////////////////////////////////////////////// Update Thirs Tab
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT [Doc_No],[Attention],[Q_App],[Q_Factor],[SW_Factor],[Reg_Factor_FE],[Q_FE],[Reg_Factor],[Speech] " + 
                               " FROM [SNAPP_CC_EVALUATION].[dbo].[PER_PRE_EVALUATION] where [doc_no] = '" + Doc_Cd.Text + "'";
            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            if (dt2.Rows.Count != 0)
            {
                if (dt2.Rows[0][1].ToString() == "D")
                {
                    radRadioButton1.Select();
                }
                if (dt2.Rows[0][1].ToString() == "C")
                {
                    radRadioButton2.Select();
                }
                if (dt2.Rows[0][1].ToString() == "B")
                {
                    radRadioButton3.Select();
                }
                if (dt2.Rows[0][1].ToString() == "A")
                {
                    radRadioButton4.Select();
                }
                if (dt2.Rows[0][2].ToString() == "D")
                {
                    radRadioButton5.Select();
                }
                if (dt2.Rows[0][2].ToString() == "C")
                {
                    radRadioButton6.Select();
                }
                if (dt2.Rows[0][2].ToString() == "B")
                {
                    radRadioButton7.Select();
                }
                if (dt2.Rows[0][2].ToString() == "A")
                {
                    radRadioButton8.Select();
                }
                if (dt2.Rows[0][3].ToString() == "D")
                {
                    radRadioButton9.Select();
                }
                if (dt2.Rows[0][3].ToString() == "C")
                {
                    radRadioButton10.Select();
                }
                if (dt2.Rows[0][3].ToString() == "B")
                {
                    radRadioButton11.Select();
                }
                if (dt2.Rows[0][3].ToString() == "A")
                {
                    radRadioButton12.Select();
                }
                if (dt2.Rows[0][4].ToString() == "D")
                {
                    radRadioButton13.Select();
                }
                if (dt2.Rows[0][4].ToString() == "C")
                {
                    radRadioButton14.Select();
                }
                if (dt2.Rows[0][4].ToString() == "B")
                {
                    radRadioButton15.Select();
                }
                if (dt2.Rows[0][4].ToString() == "A")
                {
                    radRadioButton16.Select();
                }
                if (dt2.Rows[0][5].ToString() == "D")
                {
                    radRadioButton17.Select();
                }
                if (dt2.Rows[0][5].ToString() == "C")
                {
                    radRadioButton18.Select();
                }
                if (dt2.Rows[0][5].ToString() == "B")
                {
                    radRadioButton19.Select();
                }
                if (dt2.Rows[0][5].ToString() == "A")
                {
                    radRadioButton20.Select();
                }
                if (dt2.Rows[0][6].ToString() == "D")
                {
                    radRadioButton21.Select();
                }
                if (dt2.Rows[0][6].ToString() == "C")
                {
                    radRadioButton22.Select();
                }
                if (dt2.Rows[0][6].ToString() == "B")
                {
                    radRadioButton23.Select();
                }
                if (dt2.Rows[0][6].ToString() == "A")
                {
                    radRadioButton24.Select();
                }
                if (dt2.Rows[0][7].ToString() == "D")
                {
                    radRadioButton25.Select();
                }
                if (dt2.Rows[0][7].ToString() == "C")
                {
                    radRadioButton26.Select();
                }
                if (dt2.Rows[0][7].ToString() == "B")
                {
                    radRadioButton27.Select();
                }
                if (dt2.Rows[0][7].ToString() == "A")
                {
                    radRadioButton28.Select();
                }
                if (dt2.Rows[0][8].ToString() == "D")
                {
                    radRadioButton29.Select();
                }
                if (dt2.Rows[0][8].ToString() == "C")
                {
                    radRadioButton30.Select();
                }
                if (dt2.Rows[0][8].ToString() == "B")
                {
                    radRadioButton31.Select();
                }
                if (dt2.Rows[0][8].ToString() == "A")
                {
                    radRadioButton32.Select();
                }
                ///////////////////////////////////////////////// Update Second Tab
                DataTable dt3 = new DataTable();
                OleDbDataAdapter adp3 = new OleDbDataAdapter();
                adp3.SelectCommand = new OleDbCommand();
                adp3.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand3 = "SELECT [Training_Item],[Trainer],[Train_DT], " +
                                   "[Training_Type],[Training_Period] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_TRAINING] where [Training_Type] = N'اولیه' AND [doc_no] = '" + Doc_Cd.Text + "'";
                adp3.SelectCommand.CommandText = lcommand3;
                adp3.Fill(dt3);

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DataRow newrow = Training_list.NewRow();
                    newrow["عنوان آموزش"] = dt3.Rows[i][0].ToString();
                    newrow["مدرس"] = dt3.Rows[i][1].ToString();
                    newrow["تاریخ آموزش"] = dt3.Rows[i][2].ToString();
                    newrow["نوع آموزش"] = dt3.Rows[i][3].ToString();
                    newrow["مدت آموزش"] = dt3.Rows[i][4].ToString();
                    Training_list.Rows.Add(newrow);
                }
                List<string> conditions = new List<string>();
                for (int i = 0; i < Training_list.Rows.Count; i++)
                {
                    conditions.Add("[Course_Title] != N'" + Training_list.Rows[i][0].ToString() + "'");
                }
                ///////////////////////////////////////////////////////// initializing training item
                DataTable dt4 = new DataTable();
                OleDbDataAdapter adp4 = new OleDbDataAdapter();
                adp4.SelectCommand = new OleDbCommand();
                adp4.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand4 = "SELECT '' 'Course_Title' union SELECT [Course_Title] FROM[SNAPP_CC_EVALUATION].[dbo].[CONF_COURSE_MASTER] WHERE [Course_Type] = N'اولیه' ";
                if (conditions.Count != 0)
                {
                    lcommand4 = lcommand4 + " AND " + string.Join(" AND ", conditions.ToArray());
                }
                lcommand4 = lcommand4 + " order by [Course_Title]";
                adp4.SelectCommand.CommandText = lcommand4;
                adp4.Fill(dt4);
                Training_Item.DataSource = dt4;
                Training_Item.DisplayMember = "Course_Title";
                Trainer.SelectedIndex = 0;
                //////////////////////////////////////////// Get English Score
                //DataTable dtsc5 = new DataTable();
                //OleDbDataAdapter adpsc5 = new OleDbDataAdapter();
                //adpsc5.SelectCommand = new OleDbCommand();
                //adpsc5.SelectCommand.Connection = oleDbConnection1;
                //oleDbCommand1.Parameters.Clear();
                //string lcommandsc5 = "SELECT [Doc_No],[Sc_Score] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] WHERE [Doc_No] = '" + Doc_Cd.Text + "' AND [Sc_Item_Sub_Cd] = 'EN00'";
                //adpsc5.SelectCommand.CommandText = lcommandsc5;
                //adpsc5.Fill(dtsc5);

                //if (dtsc5.Rows.Count != 0)
                //{
                //    english_score.Text = dtsc5.Rows[0][1].ToString();
                //}
                //else
                //{
                //    english_score.Text = "0";
                //}
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
                string salary = dtsc333.Rows[0][4].ToString();
                Base_Salary.Text = Int64.Parse(salary).ToString("#,##0") + " ریال";
                //////////////////////////////////////////////// Update station
                DataTable dtsc4445 = new DataTable();
                OleDbDataAdapter adpsc4445 = new OleDbDataAdapter();
                adpsc4445.SelectCommand = new OleDbCommand();
                adpsc4445.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommandsc4445 = "SELECT [Station_No] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_STATIONS] where [Doc_no] = '" + Doc_Cd.Text + "'";
                adpsc4445.SelectCommand.CommandText = lcommandsc4445;
                adpsc4445.Fill(dtsc4445);
                if (dtsc4445.Rows.Count != 0)
                {
                    Station.Text = dtsc4445.Rows[0][0].ToString();
                }
                else
                {
                    Station.Text = "";
                }
            }
        }

        public void Clear_Frm()
        {
            Training_list.Clear();
            System_Id.Text = ""; //1].ToString();
            Per_Cd.Text = ""; //2].ToString();
            Per_Ntl_ID.Text = ""; //3].ToString();
            Per_Dep.Text = ""; //4].ToString();
            Main_Shift.Text = ""; //5].ToString();
            Per_Name.Text = ""; //6].ToString();
            Per_Fa_Name.Text = ""; //7].ToString();
            Per_Nk_Name.Text = ""; //8].ToString();
            Per_tel.Text = ""; //9].ToString();
            Per_mob.Text = ""; //10].ToString();
            Per_Add.Text = ""; //11].ToString();
            Per_Pic.Image = null;
            History.Text = ""; //13].ToString();
            emp_dt.Text = ""; //14].ToString();
            birth_dt.Text = ""; //15].ToString();
            per_email.Text = ""; //16].ToString();
            Degree.Text = ""; //17].ToString();
            Major.Text = ""; //18].ToString();
            Related_Mjr.Text = ""; //19].ToString();
            Mentor.Text = ""; //20].ToString();
            english_score.Text = "";
            Doc_status.Text = "";
            Save.Enabled = Enabled;
            //Training_grid.DataSource = null;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Doc_status_TextChanged(object sender, EventArgs e)
        {
            if (Doc_status.Text == "در حال کار")
            {
                Doc_status.ForeColor = Color.Green;
                termin_dt.Visible = false;
                Doc_status.Dock = DockStyle.Fill;
            }
            else
            {
                Doc_status.ForeColor = Color.Red;
                Save.Enabled = false;
                Doc_status.Dock = DockStyle.Top;
                termin_dt.Dock = DockStyle.Bottom;
                termin_dt.Visible = true;
            }
        }

        private void Phone_Click(object sender, EventArgs e)
        {
            if (System_Id.Text != "")
            {
                var tel_page = new Personel.PER_TEL_INFO();
                tel_page.constr = constr;
                tel_page.ext_no = System_Id.Text;
                tel_page.ShowDialog(this);
            }
        }

        private void Password_Click(object sender, EventArgs e)
        {
            if (Doc_Cd.Text.Length == 0)
            {
                return;
            }
            else
            {
                //////////////////////////////////////////////// remove previuos station
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[Users] SET [usr_pass] = HashBytes('MD5', convert(nvarchar(max),'" + System_Id.Text + "')) ,[usr_per_name] = ? ,[usr_role] = ? ,[usr_role_nm] = ? ,[usr_actv] = ? ,[usr_first_login] = ? ,[Doc_No] = ? WHERE  [usr_name] = '" + Per_Ntl_ID.Text + "'";
                //oleDbCommand1.Parameters.AddWithValue("@usr_pass", System_Id.Text);
                oleDbCommand1.Parameters.AddWithValue("@usr_per_name", Per_Name.Text);
                oleDbCommand1.Parameters.AddWithValue("@usr_role", "کارشناس " + Per_Dep.Text);
                oleDbCommand1.Parameters.AddWithValue("@usr_role_nm", "کارشناس " + Per_Dep.Text);
                oleDbCommand1.Parameters.AddWithValue("@usr_actv", 1);
                oleDbCommand1.Parameters.AddWithValue("@usr_first_login", 1);
                oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                oleDbConnection1.Open();
                int affected = oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
                if (affected == 0)
                {
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "Insert into [SNAPP_CC_EVALUATION].[dbo].[Users] ([usr_name],[usr_pass],[usr_per_name],[usr_role],[usr_role_cd],[usr_role_nm],[usr_actv],[usr_first_login],[Doc_No]) VALUES (?,HashBytes('MD5', convert(nvarchar(max),'" + System_Id.Text + "')),?,?,?,?,?,?,?)";
                    oleDbCommand1.Parameters.AddWithValue("@usr_name", Per_Ntl_ID.Text);
                    //oleDbCommand1.Parameters.AddWithValue("@usr_pass", System_Id.Text);
                    oleDbCommand1.Parameters.AddWithValue("@usr_per_name", Per_Name.Text);
                    oleDbCommand1.Parameters.AddWithValue("@usr_role", "کارشناس " + Per_Dep.Text);
                    oleDbCommand1.Parameters.AddWithValue("@usr_role_cd", "AGT");
                    oleDbCommand1.Parameters.AddWithValue("@usr_role_nm", "کارشناس " + Per_Dep.Text);
                    oleDbCommand1.Parameters.AddWithValue("@usr_actv", 1);
                    oleDbCommand1.Parameters.AddWithValue("@usr_first_login", 1);
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                }
                RadMessageBox.Show(this, "حساب کاربری " + Sex.Text + " " + Per_Name.Text + " با موفقیت باز نشانی شد. " + "\n\n" + "نام کاربری: " + Per_Ntl_ID.Text + "\n" + "کلمه عبور (موقت): " + System_Id.Text + "\n", "بازنشانی حساب کاربری", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void Save_EnabledChanged(object sender, EventArgs e)
        {
            if (Save.Enabled)
            {
                Password.Enabled = true;
            }
            else
            {
                Password.Enabled = false;
            }
        }
    }
}
