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

namespace SnappFood_Employee_Evaluation.System_Managment
{
    public partial class GEN_POSITIONING : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public string DT_Day;
        public string DT_Mth;
        public string DT_Yr;

        public GEN_POSITIONING()
        {
            InitializeComponent();
            lbl_pic.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Dep.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Nk_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Cur_Position.TextAlignment = ContentAlignment.MiddleLeft;
            Doc_No.TextAlignment = ContentAlignment.MiddleLeft;
            Cur_Score.TextAlignment = ContentAlignment.MiddleLeft;
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

            ///////////////////////////////////////// Initialize Positions
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT '' 'Pos_Name', '' 'ACC_SCR', '0' 'POS_Priority' union SELECT [Pos_Name],[Pos_Access]+[Pos_Min_Score] 'ACC_SCR', [POS_Priority] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_POSITIONS_MASTER] where [Pos_Actv] = 1 order by [Pos_Priority] asc";
            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            new_position.DataSource = dt2;
            new_position.DisplayMember = "Pos_Name";
            new_position.ValueMember = "ACC_SCR";
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
            string lcommand1 = "SELECT [Doc_No],[System_Id],[Chargoon_Id],[Per_National_Cd],[Department],[Main_Shift]" +
                               ",[Per_Name],[Per_Fa_Name],[Per_Nk_Name],[Position],[Per_Mob],[Per_Add],[Per_Pic]" +
                               ",[History],[Employment_Dt],[Birth_Dt],[Email],[Degree],[Major],[Major_Status]" +
                               ",[Mentor],[sex],[Insert_User],[Termination] FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [doc_no] = '" + Doc_No.Text + "'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            //System_Id.Text = dt1.Rows[0][1].ToString();
            //Per_Cd.Text = dt1.Rows[0][2].ToString();
            //Per_Ntl_ID.Text = dt1.Rows[0][3].ToString();
            //Main_Shift.Text = dt1.Rows[0][5].ToString();
            //Per_Fa_Name.Text = dt1.Rows[0][7].ToString();
            //usr_mob = dt1.Rows[0][10].ToString();
            //Per_Add.Text = dt1.Rows[0][11].ToString();
            Per_Dep.Text = dt1.Rows[0][4].ToString();
            Per_Name.Text = dt1.Rows[0][6].ToString();
            Per_Nk_Name.Text = dt1.Rows[0][8].ToString();
            Cur_Position.Text = dt1.Rows[0][9].ToString();
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
            string lcommandsc4 = "SELECT [Doc_No],sum([Sc_Score]) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '" + Doc_No.Text + "' group by [Doc_No]";
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
            Cur_Score.Text = Score_Total.ToString();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            System_Managment.SRCH_POSITIONING ob = new System_Managment.SRCH_POSITIONING(this);
            ob.constr = constr;
            ob.ShowDialog();
        }

        private void Doc_No_TextChanged(object sender, EventArgs e)
        {
            if (Doc_No.Text == "")
            {
                new_position.Enabled = false;
                Save.Enabled = false;
                new_position.SelectedIndex = 0;
            }
            else
            {
                Save.Enabled = true;
                new_position.Enabled = true;
                new_position.SelectedIndex = 0;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void new_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (new_position.SelectedIndex != 0 && Cur_Score.Text != "")
            {
                given_scr.Text = (int.Parse(new_position.SelectedValue.ToString().Substring(3, (new_position.SelectedValue.ToString().Length)-3)) - int.Parse(Cur_Score.Text)).ToString();   
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Doc_No.Text != "")
            {
                if (new_position.SelectedIndex == 0)
                {
                    RadMessageBox.Show(this, "طبقه شغلی جدید انتخاب نشده است." + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
                else if (given_scr.Text == "")
                {
                    RadMessageBox.Show(this, " امتیاز اصلاح سطح پرداختی وارد نشده است." + "\n" + " در صورتی که قصد ندارید سطح پرداختی تغییر نماید، عدد 0 را وارد نمائید. " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
                else
                {
                    ////////////////////////////////////////////// 1- Per_Doc Table Update
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] SET [Position] = ?  WHERE [Doc_No] = '" + Doc_No.Text + "'";
                    oleDbCommand1.Parameters.AddWithValue("@Position", new_position.Text);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    ////////////////////////////////////////////// 2- Per_Score Update
                    if (int.Parse(given_scr.Text) != 0)
                    {
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] ([Doc_No],[Sc_Item_Cd],[Sc_Item_Sub_Cd],[Sc_Item_Nm],[Sc_Description],[Sc_Score],[Sc_Eff_DT],[Sc_Actv],[Insert_DT],[Insert_Tm],[Insert_User]) VALUES (?,?,?,?,?,?,?,?,getdate(),getdate(),?)";
                        oleDbCommand1.Parameters.AddWithValue("@Doc_No", Doc_No.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Cd", "SC07");
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Sub_Cd", "MG01");
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Nm", "امتیاز تشویقی");
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Description", "اصلاح سطح حقوق - انتصاب به عنوان " + new_position.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Score", given_scr.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Eff_DT", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                        oleDbCommand1.Parameters.AddWithValue("@Sc_Actv", "1");
                        oleDbCommand1.Parameters.AddWithValue("@Insert_User", user);
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                    }

                    ////////////////////////////////////////////// 3- User Table Update
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[Users] SET [usr_role_cd] = ? , [usr_role] = ? , [usr_role_nm] = ?  WHERE [Doc_No] = '" + Doc_No.Text + "'";
                    oleDbCommand1.Parameters.AddWithValue("@usr_role_cd", new_position.SelectedValue.ToString().Substring(0,3));
                    oleDbCommand1.Parameters.AddWithValue("@usr_role", new_position.Text + " " + Per_Dep.Text);
                    oleDbCommand1.Parameters.AddWithValue("@usr_role_nm", new_position.Text + " " + Per_Dep.Text);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();

                    ////////////////////////////////////////////// 4- Score Change Informing SMS
                }
                RadMessageBox.Show(this, "انتصاب با موفقیت انجام شد." + "\n", "اعلان سیستم", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void Only_Digit(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '-');
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar))
        && (e.KeyChar != '-'))
                e.Handled = true;


            // only allow minus sign at the beginning
            if (e.KeyChar == '-' && (sender as RadTextBox).Text.Length > 0)
                e.Handled = true;
        }

        private void given_scr_TextChanged(object sender, EventArgs e)
        {
            if (given_scr.Text != "" && given_scr.Text != "-")
            {
                
                if (Int64.Parse(given_scr.Text) < 0)
                {
                    given_scr.ForeColor = Color.Red;
                }
                else
                {
                    given_scr.ForeColor = Color.Black;
                }
                
            }
            
        }
    }
}
