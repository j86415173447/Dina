using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;

namespace SnappFood_Employee_Evaluation.System_Managment
{
    public partial class SRCH_GROUPING : Telerik.WinControls.UI.RadForm
    {
        System_Managment.GEN_GROUPING ob = null;
        public string constr;
        public List<string> conditions = new List<string>();
        public DataTable dt = new DataTable();

        public SRCH_GROUPING(System_Managment.GEN_GROUPING ob)
        {
            InitializeComponent();
            this.ob = ob;
            this.KeyPreview = true;
        }

        private void Search_Staff_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            Search_Btn_Click(null, null);
        }

        private void Search_Btn_Click(object sender, EventArgs e)
        {
            
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1;
            lcommand1 = "SELECT [Group_ID] 'شناسه گروه',[Group_Nm] 'نام گروه',[Group_Dep] 'واحد سازمانی',[Group_Shift] 'شیفت' FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_GROUPS_MASTER]";
            adp1.SelectCommand.CommandText = lcommand1;
            dt.Clear();
            adp1.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                grid.DataSource = dt;
                grid.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
                grid.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
                grid.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
                grid.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
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
            ob.Grp_Id.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
            ob.searching();
            this.Close();
        }
    }
}
