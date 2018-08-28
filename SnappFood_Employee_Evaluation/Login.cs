using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using System.IO;
using SmsIrRestful;

namespace SnappFood_Employee_Evaluation
{
    public partial class Login : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        private ErrorProvider errorProvider;
        public string token_key = "9b9230cfade4f36cc0b430cf";
        public string token_security = "wyqy8htyq4368";
        public string sms_line = "10007896";
        public SmsIrRestful.Token token_instance = new SmsIrRestful.Token();
        public string token = null;


        public bool data_error = false;
        public Login()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.user.Select();
            //forget.Visible = false;
            //////////////////////////////////////////////////// Check .ini file
            //string con_str_exist = File.Exists(Application.StartupPath + "\\CONSTR.ini").ToString();
            ////System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + "\\CONSTR.ini");
            //constr = file.ReadLine();
            //constr = "Provider=SQLOLEDB;Data Source=185.140.5.93;Persist Security Info=True;Password=P@$$W0rD_DBdoofppans;User ID=sa;Initial Catalog=master";
            constr = "Provider=SQLOLEDB;Data Source=192.168.20.18;Persist Security Info=True;Password=P@$$W0rD_DBdoofppans;User ID=sa;Initial Catalog=master";
            oleDbConnection1.ConnectionString = constr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            DataSet ds = new DataSet();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT *,iif([usr_pass] = HashBytes('MD5', convert(nvarchar(max),'" + pass.Text + "')),'1','0') FROM [SNAPP_CC_EVALUATION].[dbo].[Users] where [usr_name] = N'" + user.Text + "'";
            adp2.SelectCommand.CommandText = lcommand;
            adp2.Fill(ds);
            Int32 check = ds.Tables[0].Rows.Count;
            if (check == 0)
            {
                this.errorProvider.SetError(this.user, "نام کاربری وارد شده صحیح نیست.");
            }
            else if (ds.Tables[0].Rows[0][6].ToString() == "False")
            {
                RadMessageBox.Show(this, "حساب کاربری شما غیر فعال شده است. لطفاً به واحد منابع انسانی مراجعه نمائید.", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                string currectpass = ds.Tables[0].Rows[0][1].ToString();
                string usr_pass = ds.Tables[0].Rows[0][9].ToString();
                if (ds.Tables[0].Rows[0][9].ToString() == "1")
                {
                    if (ds.Tables[0].Rows[0][7].ToString() == "False")
                    {
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// Not new user
                        var mainfrm = new Main_Frm1();
                        mainfrm.constr = constr;
                        mainfrm.username = ds.Tables[0].Rows[0][2].ToString();
                        mainfrm.Username_box.Text = ds.Tables[0].Rows[0][2].ToString();
                        mainfrm.User_Role.Text = ds.Tables[0].Rows[0][3].ToString();
                        mainfrm.user_acc_name = user.Text;
                        mainfrm.Access.Text = ds.Tables[0].Rows[0][5].ToString();
                        if (ds.Tables[0].Rows[0][8].ToString() != "")
                        {
                            mainfrm.doc_number = ds.Tables[0].Rows[0][8].ToString();
                            mainfrm.radLabelElement6.Text = ds.Tables[0].Rows[0][8].ToString();
                        }
                        else
                        {
                            mainfrm.doc_number = "";
                            mainfrm.radLabelElement5.Visibility = ElementVisibility.Collapsed;
                            mainfrm.radLabelElement6.Visibility = ElementVisibility.Collapsed;
                            mainfrm.commandBarSeparator2.Visibility = ElementVisibility.Collapsed;
                        }
                        mainfrm.token_key = token_key;
                        mainfrm.token_security = token_security;
                        mainfrm.sms_line = sms_line;
                        mainfrm.Pre_load();
                        if (ds.Tables[0].Rows[0][4].ToString().Substring(0, 2) != "QC")
                        {
                            mainfrm.radGridView1.Visible = false;
                        }
                        //Thread.Sleep(3000);
                        //////////////////////////////////////////////////////// Login Log table updation
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[Login_Log] ([Usr_ID],[Usr_Station],[Login_Dt],[Login_Tm]) " +
                                                    "values (?,?,getdate(),getdate())";
                        oleDbCommand1.Parameters.AddWithValue("@Doc_No", user.Text);
                        oleDbCommand1.Parameters.AddWithValue("@station", Environment.UserName + "/" + Environment.MachineName);
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                        ///////////////////////////////////////////////////////////
                        //DataSet ds3 = new DataSet();
                        //OleDbDataAdapter adp3 = new OleDbDataAdapter();
                        //adp3.SelectCommand = new OleDbCommand();
                        //adp3.SelectCommand.Connection = oleDbConnection1;
                        //oleDbCommand1.Parameters.Clear();
                        //string lcommand3 = "SELECT [User_ID],[User_Menu] FROM [SNAPP_CC_EVALUATION].[dbo].[Users_Access] where [User_ID] = N'" + user.Text + "'";
                        //adp3.SelectCommand.CommandText = lcommand3;
                        //adp3.Fill(ds3);
                        //Int32 check3 = ds3.Tables[0].Rows.Count;
                        //if (check3 != 0)
                        //{
                        //    for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                        //    {
                        //        //mainfrm.menuStrip1.Items.Find(ds3.Tables[0].Rows[i][1].ToString(), true)[0].Enabled = true;
                        //    }
                        //}
                        /////////////////////////////////////// load panel
                        //mainfrm.personel_id.Text = ds.Tables[0].Rows[0][0].ToString();
                        //DataTable dt222 = new DataTable();
                        //OleDbDataAdapter adp222 = new OleDbDataAdapter();
                        //adp222.SelectCommand = new OleDbCommand();
                        //adp222.SelectCommand.Connection = oleDbConnection1;
                        //oleDbCommand1.Parameters.Clear();
                        //string lcommand222 = "SELECT [Per_Pic],[per_f_name],[per_l_name] FROM [finance].[dbo].[PER_PERSONNEL_MASTER] where [Per_id] = '" + ds.Tables[0].Rows[0][0].ToString() + "'";
                        //adp2.SelectCommand.CommandText = lcommand222;
                        //adp2.Fill(dt222);
                        //if (dt222.Rows[0][0].ToString().Length != 0)
                        //{
                        //    byte[] imageData = (byte[])dt222.Rows[0][0];
                        //    Image newImage;
                        //    using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                        //    {
                        //        ms.Write(imageData, 0, imageData.Length);
                        //        newImage = Image.FromStream(ms, true);
                        //    }
                        //    //mainfrm.pictureBox1.Image = newImage;
                        //}
                        //else
                        //{
                        //    mainfrm.pictureBox1.Image = Properties.Resources.default_user;
                        //}
                        //mainfrm.per_f_name.Text = dt222.Rows[0][1].ToString();
                        //mainfrm.per_l_name.Text = dt222.Rows[0][2].ToString();
                        //mainfrm.per_role.Text = ds.Tables[0].Rows[0][4].ToString();
                        //mainfrm.username.Text = ds.Tables[0].Rows[0][3].ToString();
                        //mainfrm.user_role.Text = ds.Tables[0].Rows[0][4].ToString();
                        //mainfrm.per_id = ds.Tables[0].Rows[0][0].ToString();
                        this.Hide();
                        mainfrm.Show();
                        ////////////////////////////////////////////////////////////////////////////////////////////// End not new user
                    }
                    else
                    {
                        RadMessageBox.Show(this, ds.Tables[0].Rows[0][2].ToString() + " عزیز " + "\n\n" + "بنا به دلایل امنیتی، لطفا نسبت به تغییر کلمه عبور خود اقدام نمائید." + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                        var new_staff = new Pass_Change();
                        new_staff.constr = constr;
                        new_staff.username = user.Text;
                        new_staff.CUR_PASS.Text = pass.Text;
                        new_staff.frm_login = true;
                        new_staff.ShowDialog();
                    }

                }
                else
                {
                    this.errorProvider.SetError(this.pass, "کلمه عبور وارد شده صحیح نیست.");
                }
            }
        }

        private void pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1_Click(null, null);
            }
        }

        private void user_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1_Click(null, null);
            }
        }

        private void radLabel1_Click(object sender, EventArgs e)
        {
            if (user.Text == "")
            {
                RadMessageBox.Show(this, "ابتدا نام کاربری را وارد نمائید.", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                DataTable dt222 = new DataTable();
                OleDbDataAdapter adp222 = new OleDbDataAdapter();
                adp222.SelectCommand = new OleDbCommand();
                adp222.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand222 = "SELECT [sex] + ' ' + [Per_name],[Per_Mob] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Per_National_Cd] = '" + user.Text + "' and [Termination] = 0";
                adp222.SelectCommand.CommandText = lcommand222;
                adp222.Fill(dt222);
                if (dt222.Rows.Count == 0)
                {
                    RadMessageBox.Show(this, "  تلفن همراه شما در سامانه یافت نشد.  " + "\n\n" + "  لطفاً به واحد منابع انسانی مراجعه نمائید.  ", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
                else
                {
                    Random rndm = new Random();
                    int otp = rndm.Next(13681, 99843);
                    /////////////////////////////////////////// Send SMS
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
                        load.label1.Text = "در حال ارسال پیامک";
                        load.Refresh();
                        ////////////////////////////////////////////////////////// Send SMS
                        var customerClubSend = new CustomerClubSend();
                        customerClubSend.Messages = new List<string>() { dt222.Rows[0][0].ToString() + " عزیز " + "\n" + "رمز عبور موقت شما: " + otp.ToString() + "\n" + "(اسنپ فود)" }.ToArray();
                        customerClubSend.MobileNumbers = new List<string>() { dt222.Rows[0][1].ToString() }.ToArray();
                        customerClubSend.SendDateTime = null;
                        customerClubSend.CanContinueInCaseOfError = false;
                        var customerClubContactResponse = new CustomerClub().Send(token, customerClubSend);
                        load.Close();
                    }
                    /////////////////////////////////////////// Amend OTP
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "Update [SNAPP_CC_EVALUATION].[dbo].[Users] Set [USR_Pass] = HashBytes('MD5', convert(nvarchar(max),'" + otp.ToString() + "')) , [USR_first_login] = 1 where [usr_name] = N'" + user.Text + "'";

                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();

                    RadMessageBox.Show(this, "  رمز موقت با موفقیت برای شما پیامک شد.  " + "\n\n" + "  لطفا با استفاده از رمز موقت اقدام به ورود نمائید.  ", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
            }
        }
    }
}
