using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.Threading;

namespace SnappFood_Employee_Evaluation
{
    public partial class Main_Frm1 : Telerik.WinControls.UI.RadRibbonForm
    {
        public string constr;
        public string username;
        public string user_acc_name;
        public string token_key;
        public string token_security;
        public string sms_line;
        public string doc_number;
        public bool QC_GRID;
        ///////////////////////////////// Warning Caps
        public int cap_0_30;
        public int cap_30_60;
        public int cap_60_90;
        public int cap_ov_90;
        public int min_score;
        public int timer2_count = 0;

        public Main_Frm1()
        {
            InitializeComponent();
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void Main_Frm1_Load(object sender, EventArgs e)
        {
            radRibbonBar1.RibbonBarElement.TabStripElement.SelectedItem = radRibbonBar1.RibbonBarElement.TabStripElement.Items[0];
            this.AllowAero = false;
            this.radRibbonBar1.RibbonBarElement.QuickAccessToolBar.OverflowButtonElement.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            this.radRibbonBar1.OptionsButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            this.radRibbonBar1.ExitButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            this.radRibbonBar1.RibbonBarElement.ApplicationButtonElement.ShowTwoColumnDropDownMenu = false;
            if (radGridView1.Visible)
            {
                timer1.Interval = 30000;
                timer1.Start();
                timer1_Tick(null,null);
            }
            else
            {
                timer1.Stop();
            }
            /////////////////////////////////////////// Checking user access
            //DataTable roles = new DataTable();
            //OleDbDataAdapter adp1 = new OleDbDataAdapter();
            //adp1.SelectCommand = new OleDbCommand();
            //adp1.SelectCommand.Connection = oleDbConnection1;
            //oleDbCommand1.Parameters.Clear();
            //string lcommand = "SELECT [usr_role_cd] FROM [SNAPP_CC_EVALUATION].[dbo].[Users] where [Usr_name] = N'" + user_acc_name + "'";
            //adp1.SelectCommand.CommandText = lcommand;
            //roles.Clear();
            //adp1.Fill(roles);
            //if (roles.Rows[0][0].ToString() != "0")
            //{
            //    List<string> conditions = new List<string>();
            //    foreach (DataRow i in roles.Rows)
            //    {
            //        conditions.Add("[Role_Cd] = '" + i[0].ToString() + "'");
            //    }
            //    DataTable access_menus = new DataTable();
            //    OleDbDataAdapter adp2 = new OleDbDataAdapter();
            //    adp2.SelectCommand = new OleDbCommand();
            //    adp2.SelectCommand.Connection = oleDbConnection1;
            //    oleDbCommand1.Parameters.Clear();
            //    string lcommand2 = "SELECT DISTINCT [Role_Access_Cd] FROM [SNAPP_CC_EVALUATION].[dbo].[USR_ROLE_MASTER] where " + string.Join(" OR ", conditions.ToArray());
            //    adp2.SelectCommand.CommandText = lcommand2;
            //    access_menus.Clear();
            //    adp2.Fill(access_menus);
            //    List<string> conditions2 = new List<string>();
            //    foreach (DataRow j in access_menus.Rows)
            //    {
            //        conditions2.Add("[Menu_Cd] != " + j[0].ToString());
            //    }
            //    DataTable removed_menu = new DataTable();
            //    OleDbDataAdapter adp3 = new OleDbDataAdapter();
            //    adp3.SelectCommand = new OleDbCommand();
            //    adp3.SelectCommand.Connection = oleDbConnection1;
            //    oleDbCommand1.Parameters.Clear();
            //    string lcommand3 = "SELECT [Menu_tab],[menu_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[USR_MENU_MASTER] where " + string.Join(" AND ", conditions2.ToArray()) + "order by menu_nm , menu_tab desc";
            //    adp3.SelectCommand.CommandText = lcommand3;
            //    removed_menu.Clear();
            //    adp3.Fill(removed_menu);
            //    ////////////////////////////////////// remove non authorized menu group
            //    int c = 0;
            //    foreach (DataRow z in removed_menu.Rows)
            //    {
            //        ((RibbonTab)radRibbonBar1.CommandTabs[int.Parse(z[0].ToString())]).Items[int.Parse(z[1].ToString())].Visibility = ElementVisibility.Collapsed;
            //    }
            //    ///////////////////////////////////// remove blank tabs
            //    DataTable all_tabs = new DataTable();
            //    OleDbDataAdapter adp4 = new OleDbDataAdapter();
            //    adp4.SelectCommand = new OleDbCommand();
            //    adp4.SelectCommand.Connection = oleDbConnection1;
            //    oleDbCommand1.Parameters.Clear();
            //    string lcommand4 = "SELECT distinct SUBSTRING([Menu_Cd],1,2) FROM [SNAPP_CC_EVALUATION].[dbo].[USR_MENU_MASTER]";
            //    adp4.SelectCommand.CommandText = lcommand4;
            //    all_tabs.Clear();
            //    adp4.Fill(all_tabs);

            //    foreach (DataRow U in access_menus.Rows)
            //    {
            //        U[0] = U[0].ToString().Substring(0, 2);
            //    }

            //    DataView view = new DataView(access_menus);
            //    DataTable distinctValues = view.ToTable(true);

            //    c = 0;
            //    string s = "";
            //    DataColumn[] keyColumns = new DataColumn[1];
            //    keyColumns[0] = distinctValues.Columns["Role_Access_Cd"];
            //    distinctValues.PrimaryKey = keyColumns;

            //    foreach (DataRow k in all_tabs.Rows)
            //    {
            //        s = k[0].ToString();
            //        DataRow foundRow = distinctValues.Rows.Find(s);
            //        if (foundRow == null)
            //        {
            //            radRibbonBar1.CommandTabs.RemoveAt(int.Parse(k[0].ToString()) - c);
            //            c++;
            //        }
            //    }
            //}
            //else
            //{
            //    radRibbonBar1.Enabled = false;
            //    RadMessageBox.Show(this, "شما به هیچ بخشی دسترسی ندارید. لطفا با مدیر سیستم تماس حاصل نمائید", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            //    Application.Exit();
            //}
        }

        public void Pre_load ()
        {

            oleDbConnection1.ConnectionString = constr;
            /////////////////////////////////////////// Checking user access
            DataTable roles = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT [usr_role_cd] FROM [SNAPP_CC_EVALUATION].[dbo].[Users] where [Usr_name] = N'" + user_acc_name + "'";
            adp1.SelectCommand.CommandText = lcommand;
            roles.Clear();
            adp1.Fill(roles);
            if (roles.Rows[0][0].ToString() != "")
            {
                List<string> conditions = new List<string>();
                foreach (DataRow i in roles.Rows)
                {
                    conditions.Add("[Role_Cd] = '" + i[0].ToString() + "'");
                }
                DataTable access_menus = new DataTable();
                OleDbDataAdapter adp2 = new OleDbDataAdapter();
                adp2.SelectCommand = new OleDbCommand();
                adp2.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand2 = "SELECT DISTINCT [Role_Access_Cd] FROM [SNAPP_CC_EVALUATION].[dbo].[USR_ROLE_MASTER] where " + string.Join(" OR ", conditions.ToArray());
                adp2.SelectCommand.CommandText = lcommand2;
                access_menus.Clear();
                adp2.Fill(access_menus);
                List<string> conditions2 = new List<string>();
                foreach (DataRow j in access_menus.Rows)
                {
                    conditions2.Add("[Menu_Cd] != " + j[0].ToString());
                }
                DataTable removed_menu = new DataTable();
                OleDbDataAdapter adp3 = new OleDbDataAdapter();
                adp3.SelectCommand = new OleDbCommand();
                adp3.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand3 = "SELECT [Menu_tab],[menu_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[USR_MENU_MASTER] where " + string.Join(" AND ", conditions2.ToArray()) + "order by menu_nm , menu_tab desc";
                adp3.SelectCommand.CommandText = lcommand3;
                removed_menu.Clear();
                adp3.Fill(removed_menu);
                ////////////////////////////////////// remove non authorized menu group
                int c = 0;
                foreach (DataRow z in removed_menu.Rows)
                {
                    ((RibbonTab)radRibbonBar1.CommandTabs[int.Parse(z[0].ToString())]).Items[int.Parse(z[1].ToString())].Visibility = ElementVisibility.Collapsed;
                    //((RadRibbonBarGroup)radRibbonBar1.CommandTabs[0]). = ElementVisibility.Collapsed;
                }
                ///////////////////////////////////// remove blank tabs
                DataTable all_tabs = new DataTable();
                OleDbDataAdapter adp4 = new OleDbDataAdapter();
                adp4.SelectCommand = new OleDbCommand();
                adp4.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand4 = "SELECT distinct SUBSTRING([Menu_Cd],1,2) FROM [SNAPP_CC_EVALUATION].[dbo].[USR_MENU_MASTER]";
                adp4.SelectCommand.CommandText = lcommand4;
                all_tabs.Clear();
                adp4.Fill(all_tabs);

                foreach (DataRow U in access_menus.Rows)
                {
                    U[0] = U[0].ToString().Substring(0, 2);
                }

                DataView view = new DataView(access_menus);
                DataTable distinctValues = view.ToTable(true);

                c = 0;
                string s = "";
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = distinctValues.Columns["Role_Access_Cd"];
                distinctValues.PrimaryKey = keyColumns;

                foreach (DataRow k in all_tabs.Rows)
                {
                    s = k[0].ToString();
                    DataRow foundRow = distinctValues.Rows.Find(s);
                    if (foundRow == null)
                    {
                        radRibbonBar1.CommandTabs.RemoveAt(int.Parse(k[0].ToString()) - c);
                        c++;
                    }
                }
            }
            else
            {
                radRibbonBar1.Enabled = false;
                RadMessageBox.Show(this, "شما به هیچ بخشی دسترسی ندارید. لطفا با مدیر سیستم تماس حاصل نمائید", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                Application.Exit();
            }
        }

        private void Main_Frm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void radButtonElement2_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Personel.New_Staff))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Personel.New_Staff();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.token_key = token_key;
            new_staff.token_security = token_security;
            new_staff.sms_line = sms_line;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement3_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Personel.Doc_Amend))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Personel.Doc_Amend();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.token_key = token_key;
            new_staff.token_security = token_security;
            new_staff.sms_line = sms_line;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement4_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Personel.Birthday_Report))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Personel.Birthday_Report();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            var new_staff = new Pass_Change();
            new_staff.constr = constr;
            new_staff.username = user_acc_name;
            new_staff.ShowDialog();
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radButtonElement5_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Personel.Score_Detail_Report))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Personel.Score_Detail_Report();
            new_staff.constr = constr;
            if (doc_number != "")
            {
                new_staff.doc_number = doc_number;
            }
            else
            {
                new_staff.doc_number = "";
            }
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement6_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Scores_Ops.History_Auto_Calc))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Scores_Ops.History_Auto_Calc();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement11_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Training.TRN_COURSE_MASTER))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Training.TRN_COURSE_MASTER();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement12_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Training.TRN_CLASSES))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Training.TRN_CLASSES();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement16_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Training.Classes_Report))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Training.Classes_Report();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement13_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Training.TRN_REGISTRATION))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Training.TRN_REGISTRATION();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement7_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Scores_Ops.SCR_MNG))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Scores_Ops.SCR_MNG();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.token_key = token_key;
            new_staff.token_security = token_security;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement17_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Personel.Termination))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Personel.Termination();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement14_Click(object sender, EventArgs e)
        {
            foreach(Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Training.CLS_PRESENT_ABSENT))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Training.CLS_PRESENT_ABSENT();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement18_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Training.CLS_Results))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Training.CLS_Results();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.token_key = token_key;
            new_staff.token_security = token_security;
            new_staff.sms_line = sms_line;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement19_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Personel.Score_SMS))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Personel.Score_SMS();
            new_staff.constr = constr;
            new_staff.token_key = token_key;
            new_staff.token_security = token_security;
            new_staff.sms_line = sms_line;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement20_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Personel.PER_GENERAL_REPORT))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Personel.PER_GENERAL_REPORT();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement9_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Training.TRN_DOC_STAFF))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Training.TRN_DOC_STAFF();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement8_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Scores_Ops.SCR_PRFMC_EVL))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Scores_Ops.SCR_PRFMC_EVL();
            new_staff.constr = constr;
            new_staff.token_key = token_key;
            new_staff.token_security = token_security;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement10_Click(object sender, EventArgs e)
        {

        }

        private void radButtonElement15_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Scores_Ops.SCR_WRNG))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Scores_Ops.SCR_WRNG();
            new_staff.constr = constr;
            new_staff.token_key = token_key;
            new_staff.token_security = token_security;
            new_staff.user = username;
            new_staff.doc_number = doc_number;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement21_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Training.TRN_CLS_ANNOUNCEMENT))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Training.TRN_CLS_ANNOUNCEMENT();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement22_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Training.TRN_CLASS_DOC_ANNOUNCEMENT))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Training.TRN_CLASS_DOC_ANNOUNCEMENT();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement23_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Personel.Invitation_SMS))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Personel.Invitation_SMS();
            new_staff.constr = constr;
            new_staff.token_key = token_key;
            new_staff.token_security = token_security;
            new_staff.sms_line = sms_line;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement24_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Training.TRN_CLS_EXAM_REPORT))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Training.TRN_CLS_EXAM_REPORT();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement25_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Personel.PER_SCORE_DTL_MAIL))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Personel.PER_SCORE_DTL_MAIL();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement26_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.LOG_ENTRY))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.LOG_ENTRY();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement28_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.QC_PLAN_MASTER))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.QC_PLAN_MASTER();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement27_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.QC_CALL_TYPE))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.QC_CALL_TYPE();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement29_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.QCM_APPROVAL))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.QCM_APPROVAL();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement30_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.CCM_APPROVAL))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.CCM_APPROVAL();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement31_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_GENERAL))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_GENERAL();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement32_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.LDM_APPROVAL))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.LDM_APPROVAL();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement33_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.MNG_APPROVAL))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.MNG_APPROVAL();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement34_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.FINAL_APPROVAL))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.FINAL_APPROVAL();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement35_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Personel.PER_MAGAZINE_EMAIL))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Personel.PER_MAGAZINE_EMAIL();
            new_staff.constr = constr;
            //new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement36_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_COORDINATOR))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_COORDINATOR();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement37_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_LEADER))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_LEADER();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement38_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_MANAGER))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_MANAGER();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement41_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_GENERAL_MG))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_GENERAL_MG();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement39_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_M))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_M();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement40_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_Final))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_Final();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement42_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_PERFORMANCE))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_PERFORMANCE();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement43_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_COOR_4LEADER))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_COOR_4LEADER();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement44_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms) ///////////////////////////////////////////Dash Board
            {
                if (form.GetType() == typeof(QC.RPT_QC_DASHBOARD))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_DASHBOARD();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.token_key = token_key;
            new_staff.token_security = token_security;
            new_staff.sms_line = sms_line;
            //new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement45_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_DISPATCH))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_DISPATCH();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement46_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_DASHBOARD))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_DASHBOARD();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.Show();
        }

        private void radButtonElement47_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_DETAILS_MG))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_DETAILS_MG();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement48_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(QC.RPT_QC_PENALTY))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new QC.RPT_QC_PENALTY();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement49_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Personel.Score_Detail_Report))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Personel.Score_Detail_Report();
            new_staff.constr = constr;
            if (doc_number != "")
            {
                new_staff.doc_number = doc_number;
            }
            else
            {
                new_staff.doc_number = "";
            }
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement50_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Training.TRN_DOC_STAFF))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Training.TRN_DOC_STAFF();
            new_staff.constr = constr;
            if (doc_number != "")
            {
                new_staff.doc_number = doc_number;
            }
            else
            {
                new_staff.doc_number = "";
            }
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement51_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Agents_Panel.AGENT_QC_DETAIL))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Agents_Panel.AGENT_QC_DETAIL();
            new_staff.constr = constr;
            new_staff.doc_number = doc_number;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement52_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Scores_Ops.SCR_WRNG))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Scores_Ops.SCR_WRNG();
            new_staff.constr = constr;
            new_staff.token_key = token_key;
            new_staff.token_security = token_security;
            new_staff.user = username;
            new_staff.doc_number = doc_number;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement53_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Agents_Panel.MONTHLY_PERFORMANCE))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Agents_Panel.MONTHLY_PERFORMANCE();
            new_staff.constr = constr;
            new_staff.doc_number = doc_number;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement55_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(System_Managment.GEN_POSITIONING))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new System_Managment.GEN_POSITIONING();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.token_key = token_key;
            new_staff.token_security = token_security;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement54_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(System_Managment.GEN_GROUPING))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new System_Managment.GEN_GROUPING();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement56_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(System_Managment.GEN_TASKS))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new System_Managment.GEN_TASKS();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement57_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(System_Managment.GEN_HC_DASHBOARD))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new System_Managment.GEN_HC_DASHBOARD();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////// Initilizing CAP
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT [cap_0_30],[cap_30_60],[cap_60_90],[cap_ov_90],[min_suc_log] FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_QC_SETTING]";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            if (dtsc4.Rows.Count != 0)
            {
                cap_0_30 = int.Parse(dtsc4.Rows[0][0].ToString());
                cap_30_60 = int.Parse(dtsc4.Rows[0][1].ToString());
                cap_60_90 = int.Parse(dtsc4.Rows[0][2].ToString());
                cap_ov_90 = int.Parse(dtsc4.Rows[0][3].ToString());
                min_score = int.Parse(dtsc4.Rows[0][4].ToString());

                ////////////////////////////////////////////////////////////////// update board
                DataTable dt22 = new DataTable();
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand();
                adp.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand = " Select COUNT(sel1.[QC_ID]) 'کل لاگ ها',SUM(sel3.[LOG_QTY]) 'کل فایل ها',SUM(CASE WHEN sel1.[QC_Score]<" + min_score.ToString() + " then 1 else 0 end) 'ناموفق',SUM(CASE WHEN sel1.[QC_Score] >=" + min_score.ToString() + " then 1 else 0 end) 'موفق' ,SUM(CASE WHEN sel1.[CC_M_Aprv_Usr] = N'عدم تائید کیفی' then 1 else 0 end) 'رد کیفی', AVG(sel1.[Handling_tm]) 'AHT', AVG(Sel1.[Handling_tm] - Sel2.[Len]) 'AMW' " +
                                  " ,CAST(round(convert(float,SUM(CASE WHEN sel2.[Len] <= 30   then 1 else 0 end))/COUNT(sel1.[QC_ID]),4)*100 as nvarchar(5)) + '%' '0 ~ 30', CAST(round(convert(float,SUM(CASE WHEN sel2.[Len] <= 60 and sel2.[Len] > 30   then 1 else 0 end))/COUNT(sel1.[QC_ID]),4)*100 as nvarchar(5)) + '%' '30 ~ 60', CAST(round(convert(float,SUM(CASE WHEN sel2.[Len] <= 90 and sel2.[Len] > 60   then 1 else 0 end))/COUNT(sel1.[QC_ID]),4)*100 as nvarchar(5)) + '%' '60 ~ 90', CAST(round(convert(float,SUM(CASE WHEN sel2.[Len] > 90   then 1 else 0 end))/COUNT(sel1.[QC_ID]),4)*100 as nvarchar(5)) + '%' 'Over 90'   from ( " +
                                  " (SELECT [QC_ID],[Handling_tm],[taboo],[QC_M_Approval],[QC_Agent],[QC_Score],[CC_M_Aprv_Usr],[insrt_dt] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS]) Sel1 " +
                                  " left join (SELECT [QC_ID], sum((SUBSTRING([Voice_len], 1, 2) * 60) + SUBSTRING([Voice_len], 4, 2)) AS 'Len' FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_VOICES] group by [QC_ID]) Sel2 " +
                                  " on Sel1.[QC_ID] = Sel2.[QC_ID] " +
                                  "left join (SELECT [QC_ID], count([QC_ID]) 'LOG_QTY' FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_VOICES] group by [QC_ID]) Sel3 on Sel1.[QC_ID] = Sel3.[QC_ID] " +
                                  ") WHERE  Sel1.[QC_Agent] = N'" + username + "' and Sel1.[insrt_dt] = convert(date, getdate(), 111) group by Sel1.[QC_Agent] ";
                adp.SelectCommand.CommandText = lcommand;
                dt22.Clear();
                adp.Fill(dt22);
                if (dt22.Rows.Count != 0)
                {
                    radGridView1.DataSource = dt22;
                    //radGridView1.BestFitColumns();

                    radGridView1.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
                    radGridView1.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
                    radGridView1.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
                    radGridView1.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
                    radGridView1.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
                    radGridView1.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
                    radGridView1.Columns[7].TextAlignment = ContentAlignment.MiddleCenter;
                    radGridView1.Columns[8].TextAlignment = ContentAlignment.MiddleCenter;
                    radGridView1.Columns[9].TextAlignment = ContentAlignment.MiddleCenter;
                    radGridView1.Columns[10].TextAlignment = ContentAlignment.MiddleCenter;
                    radGridView1.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;

                    radGridView1.TableElement.RowHeight = 25;
                    radGridView1.TableElement.TableHeaderHeight = 25;
                    //radGridView1.Columns[0].BestFit();
                }
            }
            else
            {
                RadMessageBox.Show(this, " بروز خطا در تنظیمات کنترل کیفی! " + "\n" + " بُرد اطلاعات عملکرد شما بروزرسانی نمی شود. پس از رفع مشکل می بایست یکبار برنامه را بسته و مجددا باز نمائید. " + "\n" + " لطفا با مدیریت شرکت تماس حاصل نمائید. ", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                timer1.Stop();
            }
            
        }

        private void radGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "0 ~ 30" || e.CellElement.ColumnInfo.Name == "60 ~ 90" || e.CellElement.ColumnInfo.Name == "30 ~ 60" || e.CellElement.ColumnInfo.Name == "Over 90")
            {
                ////////////////////////////////////////// >30 Style
                if (e.CellElement.ColumnInfo.Name == "0 ~ 30" && float.Parse(e.CellElement.Value.ToString().Replace("%", "")) <= cap_0_30 + 1)
                {
                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.LightGreen;
                    e.CellElement.NumberOfColors = 1;
                }
                else if (e.CellElement.ColumnInfo.Name == "0 ~ 30" && float.Parse(e.CellElement.Value.ToString().Replace("%", "")) > cap_0_30 + 1)
                {
                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.OrangeRed;
                    e.CellElement.NumberOfColors = 1;
                }
                ////////////////////////////////////////// 60-90 Style
                if (e.CellElement.ColumnInfo.Name == "60 ~ 90" && float.Parse(e.CellElement.Value.ToString().Replace("%", "")) <= cap_60_90 + 1)
                {
                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.LightGreen;
                    e.CellElement.NumberOfColors = 1;
                }
                else if (e.CellElement.ColumnInfo.Name == "60 ~ 90" && float.Parse(e.CellElement.Value.ToString().Replace("%", "")) > cap_60_90 + 1)
                {
                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.OrangeRed;
                    e.CellElement.NumberOfColors = 1;
                }
                ////////////////////////////////////////// 30-60 Style
                if (e.CellElement.ColumnInfo.Name == "30 ~ 60" && float.Parse(e.CellElement.Value.ToString().Replace("%", "")) <= cap_30_60 + 1)
                {
                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.LightGreen;
                    e.CellElement.NumberOfColors = 1;
                }
                else if (e.CellElement.ColumnInfo.Name == "30 ~ 60" && float.Parse(e.CellElement.Value.ToString().Replace("%", "")) > cap_30_60 + 1)
                {
                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.OrangeRed;
                    e.CellElement.NumberOfColors = 1;
                }
                ////////////////////////////////////////// >90 Style
                if (e.CellElement.ColumnInfo.Name == "Over 90" && float.Parse(e.CellElement.Value.ToString().Replace("%", "")) <= cap_ov_90 + 1)
                {
                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.LightGreen;
                    e.CellElement.NumberOfColors = 1;
                }
                else if (e.CellElement.ColumnInfo.Name == "Over 90" && float.Parse(e.CellElement.Value.ToString().Replace("%", "")) > cap_ov_90 + 1)
                {
                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.OrangeRed;
                    e.CellElement.NumberOfColors = 1;
                }
            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
            }
        }

        private void radButtonElement58_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Agents_Panel.AGENT_SALARY_DETAIL))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new Agents_Panel.AGENT_SALARY_DETAIL();
            new_staff.constr = constr;
            new_staff.doc_number = doc_number;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement59_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(System_Managment.GEN_HCC_SETTING))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new System_Managment.GEN_HCC_SETTING();
            new_staff.constr = constr;
            //new_staff.doc_number = doc_number;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement60_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(System_Managment.GEN_HCC_CC))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new System_Managment.GEN_HCC_CC();
            new_staff.constr = constr;
            //new_staff.doc_number = doc_number;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement61_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(System_Managment.QC_CONTROL_PANEL))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new System_Managment.QC_CONTROL_PANEL();
            new_staff.constr = constr;
            //new_staff.doc_number = doc_number;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement62_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(System_Managment.GEN_TRANSFER))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new System_Managment.GEN_TRANSFER();
            new_staff.constr = constr;
            new_staff.user = username;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement63_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(System_Managment.GEN_SALARY_UPLOAD))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new System_Managment.GEN_SALARY_UPLOAD();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement64_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(System_Managment.GEN_USER_MANAGMENT))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new System_Managment.GEN_USER_MANAGMENT();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }

        private void radButtonElement65_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(System_Managment.GEN_PERFORMANCE_UPLOAD))
                {
                    form.Activate();
                    return;
                }
            }
            var new_staff = new System_Managment.GEN_PERFORMANCE_UPLOAD();
            new_staff.constr = constr;
            new_staff.MdiParent = this;
            new_staff.Show();
        }
    }
}
