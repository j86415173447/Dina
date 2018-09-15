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
using Telerik.WinControls.UI;
using SmsIrRestful;

namespace SnappFood_Employee_Evaluation.System_Managment
{
    public partial class GEN_TRANSFER : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public string DT_Day;
        public string DT_Mth;
        public string DT_Yr;
        public SmsIrRestful.Token token_instance = new SmsIrRestful.Token();
        public string token = null;
        public string token_key;
        public string token_security;

        public GEN_TRANSFER()
        {
            InitializeComponent();
            //lbl_pic.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Name.TextAlignment = ContentAlignment.MiddleLeft;
            cur_dep.TextAlignment = ContentAlignment.MiddleLeft;
            cur_shift.TextAlignment = ContentAlignment.MiddleLeft;
            //Cur_Position.TextAlignment = ContentAlignment.MiddleLeft;
            Doc_No.TextAlignment = ContentAlignment.MiddleLeft;
            current_ext_cd.TextAlignment = ContentAlignment.MiddleLeft;
            radLabel1.TextAlignment = ContentAlignment.MiddleLeft;
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void GEN_POSITIONING_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            Doc_No.Text = "Loading";
            Doc_No.Text = "";
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
            DT_Yr = psdate.GetYear(datetime).ToString();


        }

        public void searching()
        {
            //Clear_Frm();
            
            /////////////////////////////// Update first tab
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT [Doc_No],[Department],[Main_Shift]" +
                               ",[Per_Name],[Per_Pic],[DEP_CD],[system_id]" +
                               " FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [doc_no] = '" + Doc_No.Text + "'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            cur_dep.Text = dt1.Rows[0][1].ToString();
            Per_Name.Text = dt1.Rows[0][3].ToString();
            cur_shift.Text = dt1.Rows[0][2].ToString();
            current_ext_cd.Text = dt1.Rows[0][5].ToString();
            sys_id.Text = dt1.Rows[0][6].ToString();
            if (dt1.Rows[0][4].ToString().Length != 0)
            {
                byte[] imageData = (byte[])dt1.Rows[0][4];
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

            ///////////////////////////////////////// Initialize Positions
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT '' 'Department_Nm','' 'Department_Cd' union SELECT [Department_Nm],[Department_Cd] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_DEPARTMENT] where [Department_Actv] = 1 and [Department_Nm] != N'" + cur_dep.Text + "' order by Department_Cd asc";
            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            new_dep.DataSource = dt2;
            new_dep.DisplayMember = "Department_Nm";
            new_dep.ValueMember = "Department_Cd";

            new_dep.SelectedIndex = 0;
            new_shift.SelectedIndex = -1;
        }

        private void Print_Click(object sender, EventArgs e)
        {
            System_Managment.SRCH_TRANSFER ob = new System_Managment.SRCH_TRANSFER(this);
            ob.constr = constr;
            ob.ShowDialog();
        }

        private void Doc_No_TextChanged(object sender, EventArgs e)
        {
            if (Doc_No.Text == "")
            {
                new_dep.Enabled = false;
                Save.Enabled = false;
                new_dep.SelectedIndex = 0;
            }
            else
            {
                Save.Enabled = true;
                new_dep.Enabled = true;
                new_dep.SelectedIndex = 0;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void new_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (new_dep.SelectedIndex != 0 && current_ext_cd.Text != "")
            {
                //given_scr.Text = (int.Parse(new_dep.SelectedValue.ToString().Substring(3, (new_dep.SelectedValue.ToString().Length)-3)) - int.Parse(current_ext_cd.Text)).ToString();   
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Doc_No.Text != "")
            {
                if (new_dep.SelectedIndex == 0)
                {
                    RadMessageBox.Show(this, "طبقه شغلی جدید انتخاب نشده است." + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
                else if (new_shift.SelectedIndex == -1)
                {
                    RadMessageBox.Show(this, " شیفت جدید انتخاب نشده است. " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
                else
                {
                    string new_sys_id;
                    if (current_ext_cd.Text != new_dep.SelectedValue.ToString())
                    {
                        //////////////////////////////////////////// Get System_ID
                        int system_no;
                        DataTable dt23 = new DataTable();
                        OleDbDataAdapter adp23 = new OleDbDataAdapter();
                        adp23.SelectCommand = new OleDbCommand();
                        adp23.SelectCommand.Connection = oleDbConnection1;
                        oleDbCommand1.Parameters.Clear();
                        string lcommand23 = "SELECT max(right([system_id],3)) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Dep_CD] = N'" + new_dep.SelectedValue.ToString() + "'";
                        adp23.SelectCommand.CommandText = lcommand23;
                        adp23.Fill(dt23);
                        if (dt23.Rows[0][0].ToString() == "")
                        {
                            system_no = int.Parse(new_dep.SelectedValue.ToString()) * 100;
                        }
                        else
                        {
                            system_no = int.Parse(dt23.Rows[0][0].ToString()) + 1;
                        }
                        if (system_no % 100 == 0)
                        {
                            system_no = system_no + 1;
                        }
                        new_sys_id = new_shift.SelectedIndex.ToString() + system_no.ToString();
                    }
                    else
                    {
                        new_sys_id = sys_id.Text;
                    }

                    //////////////////////////////////////////////// 1- Per_Doc Table Update
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] SET [Department] = ?, [Main_Shift] = ?, [System_Id] = ?, [Dep_Cd] = ?  WHERE [Doc_No] = '" + Doc_No.Text + "'";
                    oleDbCommand1.Parameters.AddWithValue("@Department", new_dep.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Main_Shift", new_shift.Text);
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", new_sys_id.ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Dep_Cd", new_dep.SelectedValue.ToString());
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    ////////////////////////////////////////////// 2- Per_Score Update
                    //if (int.Parse(given_scr.Text) != 0)
                    //{
                    //    oleDbCommand1.Parameters.Clear();
                    //    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] ([Doc_No],[Sc_Item_Cd],[Sc_Item_Sub_Cd],[Sc_Item_Nm],[Sc_Description],[Sc_Score],[Sc_Eff_DT],[Sc_Actv],[Insert_DT],[Insert_Tm],[Insert_User]) VALUES (?,?,?,?,?,?,?,?,getdate(),getdate(),?)";
                    //    oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_No.Text);
                    //    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Cd", "SC07");
                    //    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Sub_Cd", "MG01");
                    //    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Nm", "امتیاز تشویقی");
                    //    oleDbCommand1.Parameters.AddWithValue("@Sc_Description", "اصلاح سطح حقوق - انتصاب به عنوان " + new_dep.Text);
                    //    oleDbCommand1.Parameters.AddWithValue("@Sc_Score", given_scr.Text);
                    //    oleDbCommand1.Parameters.AddWithValue("@Sc_Eff_DT", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                    //    oleDbCommand1.Parameters.AddWithValue("@Sc_Actv", "1");
                    //    oleDbCommand1.Parameters.AddWithValue("@Insert_User", user);
                    //    oleDbConnection1.Open();
                    //    oleDbCommand1.ExecuteNonQuery();
                    //    oleDbConnection1.Close();
                    //}

                    //////////////////////////////////////////////// 3- User Table Update
                    //oleDbCommand1.Parameters.Clear();
                    //oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[Users] SET [usr_role_cd] = ? , [usr_role] = ? , [usr_role_nm] = ?  WHERE [Doc_No] = '" + Doc_No.Text + "'";
                    //oleDbCommand1.Parameters.AddWithValue("@usr_role_cd", new_dep.SelectedValue.ToString().Substring(0,3));
                    //oleDbCommand1.Parameters.AddWithValue("@usr_role", new_dep.Text + " " + cur_dep.Text);
                    //oleDbCommand1.Parameters.AddWithValue("@usr_role_nm", new_dep.Text + " " + cur_dep.Text);
                    //oleDbConnection1.Open();
                    //oleDbCommand1.ExecuteNonQuery();
                    //oleDbConnection1.Close();

                    RadMessageBox.Show(this, " تغییر واحد با موفقیت ثبت شد. " + "\n" +
                        (new_sys_id == sys_id.Text ? " " : " شماره داخلی " + Per_Name.Text + " به " + new_sys_id + " تغییر یافت. ") +
                        "\n", "اعلان سیستم", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }

            }
        }
    }
}
