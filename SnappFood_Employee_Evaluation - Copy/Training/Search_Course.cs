using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;

namespace SnappFood_Employee_Evaluation.Training
{
    public partial class Search_Course : Telerik.WinControls.UI.RadForm
    {
        Training.TRN_CLASSES ob = null;
        public string constr;
        public List<string> conditions = new List<string>();
        public DataTable dt = new DataTable();

        public Search_Course(Training.TRN_CLASSES ob)
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
            if (CRS_ID.Text.Length != 0)
            {
                conditions.Add("[CRS_Cd] like N'%" + CRS_ID.Text + "%'");
            }
            if (CRS_NM.Text.Length != 0)
            {
                conditions.Add("[CRS_Name] like N'%" + CRS_NM.Text + "%'");
            }
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1;
            lcommand1 = "SELECT [CRS_CD] 'کد دوره',[CRS_Name] 'نام دوره',[CRS_Period] 'طول دوره',[CRS_Type] 'نوع دوره' FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_COURSE_MASTER]";
            if (conditions.Count != 0)
            {
                lcommand1 = lcommand1 + " WHERE " + string.Join(" AND ", conditions.ToArray());
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
            ob.CRS_CD.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
            ob.CRS_NM.Text = grid.SelectedRows[0].Cells[1].Value.ToString();
            ob.period = int.Parse(grid.SelectedRows[0].Cells[2].Value.ToString());
            ob.CRS_Type.Text = grid.SelectedRows[0].Cells[3].Value.ToString();
            this.Close();
        }
    }
}
