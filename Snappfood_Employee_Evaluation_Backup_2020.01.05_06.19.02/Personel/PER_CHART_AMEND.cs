using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;

namespace SnappFood_Employee_Evaluation.Personel
{
    public partial class PER_CHART_AMEND : Telerik.WinControls.UI.RadForm
    {
        public string constr;

        public PER_CHART_AMEND()
        {
            InitializeComponent();
            RadMessageBox.ThemeName = "Office2010Silver";
            per_nm.TextAlignment = ContentAlignment.MiddleLeft;
            doc_no.TextAlignment = ContentAlignment.MiddleLeft;
        }

        private void PER_CHART_AMEND_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            ///////////////////////////////////////////////////////// initializing Coordinator item
            DataTable dt5 = new DataTable();
            OleDbDataAdapter adp5 = new OleDbDataAdapter();
            adp5.SelectCommand = new OleDbCommand();
            adp5.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand5 = "SELECT '1' 'row', '' 'Per_Name' union SELECT '2' 'row' , N'نامشخص' 'Per_Name' union SELECT '3' 'row', [Per_Name] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] WHERE [Position] = N'سرگروه' and [Termination] = 0 ";
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
            string lcommand4 = "SELECT '1' 'row', '' 'Per_Name' union SELECT '2' 'row' , N'نامشخص' 'Per_Name' union SELECT '3' 'row', [Per_Name] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] WHERE [Position] = N'سوپروایزر' and [Termination] = 0 ";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            supervisor.DataSource = dt4;
            supervisor.DisplayMember = "Per_Name";

            ///////////////////////////////////////////////////////// initializing Manager item
            DataTable dt3 = new DataTable();
            OleDbDataAdapter adp3 = new OleDbDataAdapter();
            adp3.SelectCommand = new OleDbCommand();
            adp3.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand3 = "SELECT '1' 'row', '' 'Per_Name' union SELECT '2' 'row' , N'لیلا مهارتی' 'Per_Name' ";
            adp3.SelectCommand.CommandText = lcommand3;
            adp3.Fill(dt3);
            manager.DataSource = dt3;
            manager.DisplayMember = "Per_Name";
        }

        private void Search_Click(object sender, EventArgs e)
        {

            if (Per_Cd.Text != "")
            {
                coordinator.SelectedIndex = 0;
                supervisor.SelectedIndex = 0;
                manager.SelectedIndex = 0;
                DataTable dt3 = new DataTable();
                OleDbDataAdapter adp3 = new OleDbDataAdapter();
                adp3.SelectCommand = new OleDbCommand();
                adp3.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand3 = "SELECT [Doc_No],[Per_Name],[Coordinator],[Leader],[Manager],[termination] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Chargoon_Id] = '" + Per_Cd.Text + "'";
                adp3.SelectCommand.CommandText = lcommand3;
                adp3.Fill(dt3);
                if (dt3.Rows.Count != 0)
                {
                    if (dt3.Rows[0][5].ToString() == "False")
                    {
                        per_nm.Text = dt3.Rows[0][1].ToString();
                        doc_no.Text = dt3.Rows[0][0].ToString();
                        coordinator.Text = dt3.Rows[0][2].ToString();
                        supervisor.Text = dt3.Rows[0][3].ToString();
                        manager.Text = dt3.Rows[0][4].ToString();
                        Per_Cd.Text = "";
                        name_search.Text = "";
                    }
                    else
                    {
                        RadMessageBox.Show(this, "  وضعیت پرونده ی این همکار --قطع همکاری-- می باشد.  " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                }
                else
                {
                    Per_Cd.Text = "";
                    RadMessageBox.Show(this, "  همکاری با این شماره پرسنلی یافت نشد.  " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
            }
            else if (name_search.Text != "")
            {
                coordinator.SelectedIndex = 0;
                supervisor.SelectedIndex = 0;
                manager.SelectedIndex = 0;
                DataTable dt3 = new DataTable();
                OleDbDataAdapter adp3 = new OleDbDataAdapter();
                adp3.SelectCommand = new OleDbCommand();
                adp3.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand3 = "SELECT [Doc_No],[Per_Name],[Coordinator],[Leader],[Manager],[termination] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Per_Name] Like N'%" + name_search.Text + "%'";
                adp3.SelectCommand.CommandText = lcommand3;
                adp3.Fill(dt3);
                if (dt3.Rows.Count != 0)
                {
                    per_nm.Text = dt3.Rows[0][1].ToString();
                    doc_no.Text = dt3.Rows[0][0].ToString();
                    coordinator.Text = dt3.Rows[0][2].ToString();
                    supervisor.Text = dt3.Rows[0][3].ToString();
                    manager.Text = dt3.Rows[0][4].ToString();
                    Per_Cd.Text = "";
                    name_search.Text = "";
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (supervisor.Text == "" || coordinator.Text == "" || manager.Text == "" || per_nm.Text == "")
            {
                RadMessageBox.Show(this, "  ورودی ها را کنترل کنید!  " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] SET [Coordinator] = N'" + coordinator.Text + "',[Leader] = N'" + supervisor.Text + "',[Manager] = N'" + manager.Text + "' WHERE [Doc_No] = '" + doc_no.Text + "'";
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
                per_nm.Text = "";
                name_search.Text = "";
                coordinator.SelectedIndex = 0;
                supervisor.SelectedIndex = 0;
                manager.SelectedIndex = 0;
                RadMessageBox.Show(this, "  تغییرات با موفقیت ثبت شد.  " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }
    }
}
