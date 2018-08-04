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
    public partial class GEN_GROUPING : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public string DT_Day;
        public string DT_Mth;
        public string DT_Yr;
        private ErrorProvider errorProvider;

        public GEN_GROUPING()
        {
            InitializeComponent();

            Grp_Id.TextAlignment = ContentAlignment.MiddleLeft;
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;

        }

        private void GEN_POSITIONING_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            RadMessageBox.SetThemeName("Office2010Silver");
            Grp_Id.Text = "Loading";
            Grp_Id.Text = "";
            //DataTable dt100 = new DataTable();
            //OleDbDataAdapter adp100 = new OleDbDataAdapter();
            //adp100.SelectCommand = new OleDbCommand();
            //adp100.SelectCommand.Connection = oleDbConnection1;
            //oleDbCommand1.Parameters.Clear();
            //string lcommand100 = "SELECT day(GETDATE()), month(GETDATE()), year(GETDATE())";
            //adp100.SelectCommand.CommandText = lcommand100;
            //adp100.Fill(dt100);
            //DateTime datetime = DateTime.Parse(dt100.Rows[0][2].ToString() + "/" + dt100.Rows[0][1].ToString() + "/" + dt100.Rows[0][0].ToString());
            /////////////////////////////////////////// Convert Persian
            //PersianCalendar psdate = new PersianCalendar();
            //DT_Day = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            //DT_Mth = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            //DT_Yr = psdate.GetYear(datetime).ToString();

            ///////////////////////////////////////////////////////// initializing department combo
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT '' 'Department_Nm','' 'Department_Cd' union SELECT [Department_Nm],[Department_Cd] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_DEPARTMENT] where [Department_Actv] = 1 order by Department_Cd asc";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            dep.DataSource = dt;
            dep.ValueMember = "Department_Cd";
            dep.DisplayMember = "Department_Nm";

            
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
            string lcommand1 = "SELECT [Group_ID],[Group_Nm],[Group_Dep],[Group_Shift],[Group_Coor],[Group_LD],[Group_SP],[Group_MG],[Group_ACTV] " +
                               " FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_GROUPS_MASTER] where [Group_ID] = '" + Grp_Id.Text + "'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            //System_Id.Text = dt1.Rows[0][1].ToString();
            dep.Text = dt1.Rows[0][2].ToString();
            shift.Text = dt1.Rows[0][3].ToString();
            leader.Text = dt1.Rows[0][5].ToString();
            manager.Text = dt1.Rows[0][7].ToString();
            supervisor.Text = dt1.Rows[0][6].ToString();
            coordinator.Text = dt1.Rows[0][4].ToString();
            Grp_ACTV.Checked = (dt1.Rows[0][8].ToString() == "True" ? true : false);
            Grp_Nm.Text = dt1.Rows[0][1].ToString();

        }

        private void Print_Click(object sender, EventArgs e)
        {
            System_Managment.SRCH_GROUPING ob = new System_Managment.SRCH_GROUPING(this);
            ob.constr = constr;
            ob.ShowDialog();
        }

        private void Doc_No_TextChanged(object sender, EventArgs e)
        {
            if (Grp_Id.Text == "")
            {

                Save.Text = "ثبت";
                Grp_Nm.Enabled = true;
            }
            else
            {
                Save.Text = "ویرایش";
                Grp_Nm.Enabled = false;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (AreRequiredFieldsValid()) 
            {
                if (Grp_Id.Text != "") //////////////////////////////////////////////// Update Mode
                {
                    ////////////////////////////////////////////// 1- Per_Doc Table Update
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[CONF_GROUPS_MASTER] SET [Group_Nm]= ?, [Group_Dep]= ?, [Group_Shift]= ?, [Group_Coor]= ?, [Group_LD]= ?, [Group_SP]= ?, [Group_MG]= ?, [Group_ACTV]= ?  WHERE [Group_ID] = N'" + Grp_Id.Text + "'";
                    oleDbCommand1.Parameters.AddWithValue("@Group_Nm", Grp_Nm.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Group_Dep", dep.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Group_Shift", shift.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Coordinator", coordinator.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Leader", leader.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Supervisor", supervisor.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Manager", manager.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Group_ACTV", (Grp_ACTV.Checked == true ? "1" : "0"));
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();

                    ////////////////////////////////////////////// 2- Per_Doc Table Update
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] SET [Coordinator] = ?, [Leader] = ?, [Supervisor] = ?, [Manager] = ?  WHERE [Team_Group] = N'" + Grp_Nm.Text + "'";
                    oleDbCommand1.Parameters.AddWithValue("@Coordinator", coordinator.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Leader", leader.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Supervisor", supervisor.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Manager", manager.Text);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();

                    RadMessageBox.Show(this, " گروه " + Grp_Nm.Text + " با موفقیت ویرایش شد. " +"\n", "اعلان سیستم", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
                else ////////////////////////////////////////////////////////////////// Insert mode
                {
                    ////////////////////////////////////////////////////////////// check duplicate
                    DataTable dt = new DataTable();
                    OleDbDataAdapter adp = new OleDbDataAdapter();
                    adp.SelectCommand = new OleDbCommand();
                    adp.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommand = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_GROUPS_MASTER] where [Group_Nm] = N'" + Grp_Nm.Text + "'";
                    adp.SelectCommand.CommandText = lcommand;
                    adp.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        RadMessageBox.Show(this, " گروه شغلی " + Grp_Nm.Text + " قبلا ثبت شده است. " + "\n", "اخطار سیستم", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                    else
                    {
                        ////////////////////////////////////////////// 1- Insert in Group Table
                        //////////////////////////////////////////// Get Doc_No
                        int doc_no;
                        string doc_no_str;
                        DataTable dt22 = new DataTable();
                        OleDbDataAdapter adp22 = new OleDbDataAdapter();
                        adp22.SelectCommand = new OleDbCommand();
                        adp22.SelectCommand.Connection = oleDbConnection1;
                        oleDbCommand1.Parameters.Clear();
                        string lcommand22 = "SELECT max([Group_ID]) FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_GROUPS_MASTER]";
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
                        Grp_Id.Text = doc_no_str;

                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[CONF_GROUPS_MASTER] ([Group_ID],[Group_Nm],[Group_Dep],[Group_Shift],[Group_Coor],[Group_LD],[Group_SP],[Group_MG],[Group_ACTV],[Insrt_DT],[Insrt_TM],[Insrt_User]) VALUES (?,?,?,?,?,?,?,?,?,getdate(),getdate(),?)";
                        oleDbCommand1.Parameters.AddWithValue("@Group_ID", Grp_Id.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Group_Nm", Grp_Nm.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Group_Dep", dep.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Group_Shift", shift.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Group_Coor", coordinator.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Group_LD", leader.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Group_SP", supervisor.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Group_MG", manager.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Group_ACTV", (Grp_ACTV.Checked == true ? "1" : "0"));
                        oleDbCommand1.Parameters.AddWithValue("@Insrt_User", user);
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();

                        ////////////////////////////////////////////// 2- Per_Doc Table Update
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] SET [Coordinator] = ?, [Leader] = ?, [Supervisor] = ?, [Manager] = ?  WHERE [Team_Group] = N'" + Grp_Nm.Text + "'";
                        oleDbCommand1.Parameters.AddWithValue("@Coordinator", coordinator.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Leader", leader.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Supervisor", supervisor.Text);
                        oleDbCommand1.Parameters.AddWithValue("@Manager", manager.Text);
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                        RadMessageBox.Show(this, " گروه " + Grp_Nm.Text + " با موفقیت ثبت شد. " + "\n", "اعلان سیستم", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                }
            }
        }

        private void dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dep.SelectedIndex != 0 && shift.SelectedIndex != 0)
            {
                ///////////////////////////////////////////////////////// initializing Coordinator item
                DataTable dt5 = new DataTable();
                OleDbDataAdapter adp5 = new OleDbDataAdapter();
                adp5.SelectCommand = new OleDbCommand();
                adp5.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand5 = "SELECT '1' 'row', '' 'Per_Name' union SELECT '2' 'row' , N'نامشخص' 'Per_Name' union SELECT '3' 'row', [Per_Name] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] WHERE [Position] = N'سرگروه' and [Department] = N'" + dep.Text + "'  and [Main_Shift] = N'" + shift.Text + "' and [Termination] = 0 ";
                adp5.SelectCommand.CommandText = lcommand5;
                adp5.Fill(dt5);
                coordinator.DataSource = dt5;
                coordinator.DisplayMember = "Per_Name";

                ///////////////////////////////////////////////////////// initializing Leader item
                DataTable dt4 = new DataTable();
                OleDbDataAdapter adp4 = new OleDbDataAdapter();
                adp4.SelectCommand = new OleDbCommand();
                adp4.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand4 = "SELECT '1' 'row', '' 'Per_Name' union SELECT '2' 'row' , N'نامشخص' 'Per_Name' union SELECT '3' 'row', [Per_Name] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] WHERE [Position] = N'رهبر' and [Main_Shift] = N'" + shift.Text + "' and [Termination] = 0 ";
                adp4.SelectCommand.CommandText = lcommand4;
                adp4.Fill(dt4);
                leader.DataSource = dt4;
                leader.DisplayMember = "Per_Name";

                ///////////////////////////////////////////////////////// initializing Supervisor item
                DataTable dt3 = new DataTable();
                OleDbDataAdapter adp3 = new OleDbDataAdapter();
                adp3.SelectCommand = new OleDbCommand();
                adp3.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand3 = "SELECT '1' 'row', '' 'Per_Name' union SELECT '2' 'row' , N'نامشخص' 'Per_Name' union SELECT '3' 'row', [Per_Name] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] WHERE [Position] = N'سرپرست' and [Main_Shift] = N'" + shift.Text + "' and [Termination] = 0 ";
                adp3.SelectCommand.CommandText = lcommand3;
                adp3.Fill(dt3);
                supervisor.DataSource = dt3;
                supervisor.DisplayMember = "Per_Name";

                ///////////////////////////////////////////////////////// initializing Manager item
                DataTable dt2 = new DataTable();
                OleDbDataAdapter adp2 = new OleDbDataAdapter();
                adp2.SelectCommand = new OleDbCommand();
                adp2.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand2 = "SELECT '1' 'row', '' 'Per_Nm' union SELECT '2' 'row' , N'نامشخص' 'Per_Nm' union SELECT '3' 'row', [Per_Nm] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TEAM_LEADERS_MASTER] WHERE [Level_Nm] = N'مدیر' and [ACTV] = 1 ";
                adp2.SelectCommand.CommandText = lcommand2;
                adp2.Fill(dt2);
                manager.DataSource = dt2;
                manager.DisplayMember = "Per_Nm";
            }
            else
            {
                coordinator.DataSource = null;
                leader.DataSource = null;
                supervisor.DataSource = null;
                manager.DataSource = null;
            }
        }

        private void coordinator_Click(object sender, EventArgs e)
        {
            if (coordinator.Items.Count == 0)
            {
                RadMessageBox.Show(this, "ابتدا واحد سازمانی و شیفت را انتخاب نمائید." + "\n", "هشدار", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private bool AreRequiredFieldsValid()
        {
            bool data_error = false;

            if (Grp_Nm.Text == "")
            {
                this.errorProvider.SetError(this.Grp_Nm, "نام گروه شغلی وارد نشده است");
                data_error = true;
            }
            if (dep.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.dep, "واحد سازمانی انتخاب نشده است");
                data_error = true;
            }
            if (shift.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.shift, "شیفت انتخاب نشده است");
                data_error = true;
            }
            if (coordinator.Text == "")
            {
                this.errorProvider.SetError(this.coordinator, "سرگروه انتخاب نشده است");
                data_error = true;
            }
            if (leader.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.leader, "رهبر انتخاب نشده است");
                data_error = true;
            }
            if (supervisor.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.supervisor, "سرپرست انتخاب نشده است");
                data_error = true;
            }
            if (manager.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.manager, "مدیر انتخاب نشده است");
                data_error = true;
            }
           
            if (data_error == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            var new_staff = new System_Managment.GEN_GROUPING();
            new_staff.constr = constr;
            new_staff.user = user;
            new_staff.MdiParent = this.ParentForm;
            this.Close();
            new_staff.Show();
        }
    }
}
