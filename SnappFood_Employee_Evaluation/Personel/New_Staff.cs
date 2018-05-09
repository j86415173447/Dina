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
    public partial class New_Staff : Telerik.WinControls.UI.RadForm
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
        public string pic_address;
        public string token_key;
        public string token_security;
        public string sms_line;

        private ErrorProvider errorProvider;
        public bool data_error = false;

        public New_Staff()
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
            if(Station.Text != "")
            {
                if (Station.Text.Length == 1)
                {
                    Station.Text = "00" + Station.Text;
                }
                else if(Station.Text.Length == 2)
                {
                    Station.Text = "0" + Station.Text;
                }
            }
            errorProvider.Clear();
            ////////////////////////////////////////////// Required field check
            if (!this.AreRequiredFieldsValid())
            {
                return;
            }
            ////////////////////////////////////////////// if required field was OK
            else
            {
                //////////////////////////////////////////// Get Doc_No
                int doc_no;
                string doc_no_str;
                DataTable dt22 = new DataTable();
                OleDbDataAdapter adp22 = new OleDbDataAdapter();
                adp22.SelectCommand = new OleDbCommand();
                adp22.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand22 = "SELECT max([Doc_No]) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]";
                adp22.SelectCommand.CommandText = lcommand22;
                adp22.Fill(dt22);
                if (dt22.Rows[0][0].ToString() == "")
                {
                    doc_no = 1;
                }
                else
                {
                    doc_no = int.Parse(dt22.Rows[0][0].ToString()) + 1;
                }
                if (doc_no < 10)
                {
                    doc_no_str = "000" + doc_no.ToString();
                }
                else if (doc_no > 9 && doc_no < 100)
                {
                    doc_no_str = "00" + doc_no.ToString();
                }
                else if (doc_no > 99 && doc_no < 1000)
                {
                    doc_no_str = "0" + doc_no.ToString();
                }
                else
                {
                    doc_no_str = doc_no.ToString();
                }
                Doc_Cd.Text = doc_no_str;
                //////////////////////////////////////////// Get System_ID
                int system_no;
                DataTable dt23 = new DataTable();
                OleDbDataAdapter adp23 = new OleDbDataAdapter();
                adp23.SelectCommand = new OleDbCommand();
                adp23.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand23 = "SELECT max(right([system_id],3)) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Department] = N'" + Per_Dep.Text + "'";
                adp23.SelectCommand.CommandText = lcommand23;
                adp23.Fill(dt23);
                if (dt23.Rows[0][0].ToString() == "")
                {
                    system_no = int.Parse(Per_Dep.SelectedValue.ToString()) * 100;
                }
                else
                {
                    system_no = int.Parse(dt23.Rows[0][0].ToString()) + 1;
                }
                if (system_no % 100 == 0)
                {
                    system_no = system_no + 1;
                }
                System_Id.Text = Main_Shift.SelectedIndex.ToString() + system_no.ToString();
                ////////////////////////////////////////////// convert picture
                byte[] imageData = ReadFile(pic_address);
                ////////////////////////////////////////////// INSERT INTO PER_DOCUMENTS TBL
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] ([Doc_No],[System_Id],[Chargoon_Id],[Per_National_Cd],[Department],[Main_Shift],[Per_Name]," +
                                            "[Per_Fa_Name],[Per_Nk_Name],[Per_Tel],[Per_Mob],[Per_Add],[Per_Pic],[History],[Employment_Dt],[Birth_Dt],[Email],[Degree],[Major],[Major_Status],[Insert_dt],[Insert_tm],[Insert_User],[Mentor],[Sex],[Termination]) " +
                                            "values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,getdate(),getdate(),?,?,?,?)";
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
                oleDbCommand1.Parameters.AddWithValue("@Employment_Dt", DT_Yr.Text + "/" + DT_Mth.Text + "/" + DT_Day.Text);
                oleDbCommand1.Parameters.AddWithValue("@Birth_Dt", Br_Yr.Text + "/" + Br_Mth.Text + "/" + Br_Day.Text);
                oleDbCommand1.Parameters.AddWithValue("@Email", (per_email.Text == "" ? "-" : per_email.Text)+"@zoodfood.com");
                oleDbCommand1.Parameters.AddWithValue("@Degree", Degree.Text);
                oleDbCommand1.Parameters.AddWithValue("@Major", Major.Text);
                oleDbCommand1.Parameters.AddWithValue("@Major_Status", Related_Mjr.Text);
                oleDbCommand1.Parameters.AddWithValue("@Insert_User", user);
                oleDbCommand1.Parameters.AddWithValue("@Mentor", Mentor.Text);
                oleDbCommand1.Parameters.AddWithValue("@Sex", Sex.Text);
                oleDbCommand1.Parameters.AddWithValue("@Termination", "0");
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
                ////////////////////////////////////////////// INSERT INTO PER_DOCUMENTS TBL
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
                ////////////////////////////////////////////// INSERT INTO PER_PRE_EVALUATION TBL
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_PRE_EVALUATION] ([Doc_No],[Attention],[Q_App],[Q_Factor],[SW_Factor],[Reg_Factor_FE],[Q_FE],[Reg_Factor],[Speech]) VALUES (?,?,?,?,?,?,?,?,?)";
                oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                oleDbCommand1.Parameters.AddWithValue("@Attention", s1);
                oleDbCommand1.Parameters.AddWithValue("@Q_App", s2);
                oleDbCommand1.Parameters.AddWithValue("@Q_Factor", s3);
                oleDbCommand1.Parameters.AddWithValue("@SW_Factor", s4);
                oleDbCommand1.Parameters.AddWithValue("@Reg_Factor_FE", s5);
                oleDbCommand1.Parameters.AddWithValue("@Q_FE", s6);
                oleDbCommand1.Parameters.AddWithValue("@Reg_Factor", s7);
                oleDbCommand1.Parameters.AddWithValue("@Speech", s8);
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
                //////////////////////////////////////////// SCORE CALCULATION AND SCORE TABLE UPDATE
                int score1 = 0;
                int score2 = 0;
                int score3 = 0;
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
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Eff_DT", DT_Yr.Text + "/" + DT_Mth.Text + "/" + DT_Day.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Actv", "1");
                    oleDbCommand1.Parameters.AddWithValue("@Insert_User", "محاسبه اتوماتیک - تشکیل پرونده");
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                }
                ////////////////////////// English SCORE - SC2

                if (int.Parse(english_score.Text) != 0)
                {
                    score2 = int.Parse(english_score.Text);
                    /////////////////////////////////////////// UPDATE SCORE TABLE
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] ([Doc_No],[Sc_Item_Cd],[Sc_Item_Sub_Cd],[Sc_Item_Nm],[Sc_Description],[Sc_Score],[Sc_Eff_DT],[Sc_Actv],[Insert_DT],[Insert_Tm],[Insert_User]) VALUES (?,?,?,?,?,?,?,?,getdate(),getdate(),?)";
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Cd", "SC00");
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Sub_Cd", "EN00");
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Nm", "امتیاز آزمون زبان انگلیسی");
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Description", "درصد پاسخگوئی: " + score2.ToString() + "%");
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Score", score2.ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Eff_DT", DT_Yr.Text + "/" + DT_Mth.Text + "/" + DT_Day.Text);
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
                        if(BG_Amount > 6)
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

                    /////////////////////////////////////////// UPDATE SCORE TABLE
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] ([Doc_No],[Sc_Item_Cd],[Sc_Item_Sub_Cd],[Sc_Item_Nm],[Sc_Description],[Sc_Score],[Sc_Eff_DT],[Sc_Actv],[Insert_DT],[Insert_Tm],[Insert_User]) VALUES (?,?,?,?,?,?,?,?,getdate(),getdate(),?)";
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_Cd.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Cd", dtsc3.Rows[0][0].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Sub_Cd", dtsc3.Rows[0][2].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Nm", dtsc3.Rows[0][1].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Description", History.Text + " ماه " + dtsc3.Rows[0][3].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Score", score3.ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Eff_DT", DT_Yr.Text + "/" + DT_Mth.Text + "/" + DT_Day.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Actv", "1");
                    oleDbCommand1.Parameters.AddWithValue("@Insert_User", "محاسبه اتوماتیک - تشکیل پرونده");
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                }
                Score_Total.Text = (score1 + score2 + score3).ToString();
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
                ////////////////////////////////////////////////////////// Send SMS
                SmsIrRestful.Token token_instance = new SmsIrRestful.Token();
                var token = token_instance.GetToken(token_key,token_security);

                SmsIrRestful.MessageSend message_instance = new SmsIrRestful.MessageSend();
                var res = message_instance.Send(token, new SmsIrRestful.MessageSendObject()
                {
                    MobileNumbers = new List<string>() { Per_mob.Text }.ToArray(),
                    Messages = new List<string>() { Sex.Text + " " + Per_Name.Text + " عزیز \n" + "مشخصات شما در سامانه متمرکز اطلاعات پرسنلی با شماره پرونده " + Doc_Cd.Text + " ثبت شد. \n" + "امتیاز شغلی شما: " + Score_Total.Text + "\n" + "به خانواده بزرگ اسنپ فود خوش آمدید" }.ToArray(),
                    LineNumber = sms_line,
                    SendDateTime = null,
                    CanContinueInCaseOfError = false
                });

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

                mailing();

                RadMessageBox.SetThemeName("Office2010Silver");
                RadMessageBox.Show(this,"  اطلاعات پرونده با موفقیت ثبت گردید " + "\n\n" + "شماره پرونده: " + doc_no_str + "\n\n" + "مجموع امتیاز شغلی محاسبه شده: " + Score_Total.Text + "\n\n" + "حقوق پایه منطبق با امتیاز: " + string.Format("{0:#,##0}", int.Parse(dtsc333.Rows[0][4].ToString())) + " ریال " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
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
            if (Sex.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Sex, "جنسیت انتخاب نشده است");
                data_error = true; tab1 = true;
            }
            if (Per_Dep.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Per_Dep, "واحد سازمانی وارد نشده است");
                data_error = true; tab1 = true;
            }
            if (Per_Cd.Text == "")
            {
                this.errorProvider.SetError(this.Per_Cd, "کد پرسنلی شرکت وارد نشده است");
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
            if (DT_Day.Text == "" || DT_Mth.Text == "" || DT_Yr.Text == "" || int.Parse(DT_Day.Text) > 31 || int.Parse(DT_Mth.Text) > 12  || int.Parse(DT_Yr.Text) < 1300 || DT_Day.Text.Length != 2 || DT_Mth.Text.Length != 2 || DT_Yr.Text.Length != 4)
            {
                this.errorProvider.SetError(this.Today_Btn, "تاریخ استخدام صحیح وارد نشده است");
                data_error = true; tab1 = true;
            }
            if (Br_Day.Text == "" || Br_Mth.Text == "" || Br_Yr.Text == "" || int.Parse(Br_Day.Text) > 31 || int.Parse(Br_Mth.Text) > 12 || int.Parse(Br_Yr.Text) < 1300 || Br_Day.Text.Length != 2 || Br_Mth.Text.Length != 2 || Br_Yr.Text.Length != 4)
            {
                this.errorProvider.SetError(this.Br_Yr, "تاریخ تولد صحیح وارد نشده است");
                data_error = true; tab1 = true;
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
                data_error = true; tab1 = true;
            }
            if (Per_Pic == null || Per_Pic.Image == null)
            {
                this.errorProvider.SetError(this.Per_Pic, "عکس پرسنلی آپلود نشده است");
                data_error = true; tab1 = true;
            }
            if (Station.Text == "")
            {
                this.errorProvider.SetError(this.Station, "استیشن وارد نشده است");
                data_error = true; tab1 = true;
            }
            if (Mentor.Text == "")
            {
                this.errorProvider.SetError(this.Mentor, "نام مربی وارد نشده است");
                data_error = true; tab1 = true;
            }
            ////////////////////////////////////////////////// check duplicate
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT [Per_Name],[Chargoon_Id],[Per_National_Cd],[Per_Mob] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Termination] = 0 and ([Chargoon_Id] = '" + Per_Cd.Text + "' or [Per_National_Cd] = '" + Per_Ntl_ID.Text + "' or [Per_Mob] = '" + Per_mob.Text + "')";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            if (dt1.Rows.Count != 0)
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
                        this.errorProvider.SetError(this.Station, "استیشن وارد شده متعلق به " + dt2.Rows[0][1].ToString() + " می باشد");
                        data_error = true; tab1 = true;
                    }
                }
                else
                {
                    this.errorProvider.SetError(this.Station, "استیشن وارد شده، تعریف شده نیست");
                    data_error = true; tab1 = true;
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
                RadMessageBox.SetThemeName("Office2010Silver");
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
            DT_Day.Text = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            DT_Mth.Text = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            DT_Yr.Text = psdate.GetYear(datetime).ToString();
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                Per_Cd.Select();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                Training_Item.Select();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                english_score.Select();
            }
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
            if (!Training_Date.MaskFull || Training_Item.SelectedIndex == 0 || Trainer.SelectedIndex == 0 || int.Parse(Training_Date.Text.Substring(0,4)) < 1396 || int.Parse(Training_Date.Text.Substring(5, 2)) > 12 || int.Parse(Training_Date.Text.Substring(8, 2)) > 31)
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

        private void Doc_Cd_TextChanged(object sender, EventArgs e)
        {
            Save.Enabled = false;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void New_Click(object sender, EventArgs e)
        {
            var new_staff = new Personel.New_Staff();
            new_staff.constr = constr;
            new_staff.user = user;
            new_staff.MdiParent = Application.OpenForms.OfType<Main_Frm1>().FirstOrDefault();
            this.Close();
            new_staff.Show();
        }

        public void mailing()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("postman.sfes@gmail.com");
                mail.To.Add("ali.hassanein@zoodfood.com,javad.taghinasab@zoodfood.com,saeed.lotfi@zoodfood.com");
                mail.Subject = "استخدام - " + Sex.Text + " " + Per_Name.Text;
                mail.IsBodyHtml = true;
                mail.Body = "<table width = '100%'><tr><td align='right'><p dir='rtl'>" +
                            "<font face='Tahoma'><font size='5px'> <b>" + "اعلام ثبت پرونده پرسنل جدید الورود - استخدام" + "</b></font>" + "<br>" + "<br>" + "<font size='3px'>" +
                            "شماره پرونده: <b>" + Doc_Cd.Text + "</b><br>" +
                            "نام همکار: <b>" + Sex.Text + " " + Per_Name.Text + "</b><br>" +
                            "واحد سازمانی: <b>" + Per_Dep.Text + "</b><br>" +
                            "شیفت کاری: <b>" + Main_Shift.Text + "</b><br>" +
                            "شماره داخلی: <b>" + System_Id.Text + "</b><br>" +
                            "تاریخ استخدام: <b>" + DT_Yr.Text + "/" + DT_Mth.Text + "/" + DT_Day.Text + "</b>" + "</font>" +
                            "<br><br><font size='3px'>" + "با تشکر" + "<br>" + "<b>" + "سامانه متمرکز اطلاعات و پایش عملکرد پرسنل اسنپ فود - SFES" + "</b></font>" +
                            "<br><br><br><font color='Red'>" + "این ایمیل به صورت اتوماتیک ارسال شده است. لطفا به آن پاسخ ندهید." + "</font>" +
                            "</font></p></td></tr></table>";


                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("postman.sfes@gmail.com", "j86415173447");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
