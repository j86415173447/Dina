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
    public partial class Search_Staff_Termination : Telerik.WinControls.UI.RadForm
    {
        Personel.Termination ob = null;
        public string constr;
        public List<string> conditions = new List<string>();
        public DataTable dt = new DataTable();

        public Search_Staff_Termination(Personel.Termination ob)
        {
            InitializeComponent();
            this.ob = ob;
            this.KeyPreview = true;
        }

        private void Search_Staff_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
        }

        private void Search_Btn_Click(object sender, EventArgs e)
        {
            conditions.Clear();
            if (Per_Ntl_ID.Text.Length != 0)
            {
                conditions.Add("[Per_National_Cd] like '%" + Per_Ntl_ID.Text + "%'");
            }
            if (Per_Cd.Text.Length != 0)
            {
                conditions.Add("[Chargoon_Id] like '%" + Per_Cd.Text + "%'");
            }
            if (Per_Name.Text.Length != 0)
            {
                conditions.Add("[Per_Name] like N'%" + Per_Name.Text + "%'");
            }
            if (Doc_No.Text.Length != 0)
            {
                conditions.Add("[Doc_No] like '%" + Doc_No.Text + "%'");
            }
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1;
            lcommand1 = "SELECT [Doc_No] 'شماره پرونده',[Chargoon_Id] 'کد شرکت',[Per_National_Cd]'کد ملی',[Per_Name]'نام و نام خانوادگی' " +
                        ",[Per_Mob] 'موبایل',[Department]'واحد' FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Termination] = 0";
            if (conditions.Count != 0)
            {
                lcommand1 = lcommand1 + " and " + string.Join(" AND ", conditions.ToArray());
            }
            adp1.SelectCommand.CommandText = lcommand1;
            dt.Clear();
            adp1.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                grid.DataSource = dt;
                grid.BestFitColumns();
            }
            else
            {
                grid.DataSource = null;
            }
        }

        private void Search_Staff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_Btn_Click(null, null);
            }
        }

        private void grid_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ob.Doc_Cd.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
            ob.searching();
            this.Close();
        }
    }
}
