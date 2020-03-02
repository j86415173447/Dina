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
    public partial class Search_Class_Result : Telerik.WinControls.UI.RadForm
    {
        Training.CLS_Results ob = null;
        public string constr;
        public string user;
        public List<string> conditions = new List<string>();
        public DataTable dt = new DataTable();

        public Search_Class_Result(Training.CLS_Results ob)
        {
            InitializeComponent();
            this.ob = ob;
            this.KeyPreview = true;
            radCheckBox1.Checked = true;
        }

        private void Search_Staff_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            ///////////////////////////////////////////////// Get Class list only active ones
            //OleDbDataAdapter adp1 = new OleDbDataAdapter();
            //adp1.SelectCommand = new OleDbCommand();
            //adp1.SelectCommand.Connection = oleDbConnection1;
            //oleDbCommand1.Parameters.Clear();
            //string lcommand1;
            //lcommand1 = "SELECT [CLS_CD]'کد کلاس',[CLS_CAPACITY]'ظرفیت',[CLS_Course_Nm]'نام دوره',[CLS_Trainer]'مدرس',[CLS_ACTV] 'فعال؟' FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]";
            //adp1.SelectCommand.CommandText = lcommand1;
            //dt.Clear();
            //adp1.Fill(dt);
            //if (dt.Rows.Count != 0)
            //{
            //    grid.DataSource = dt;
            //    grid.BestFitColumns();
            //}
            //else
            //{
            //    grid.DataSource = null;
            //}
            ///////////////////////////////////////////////////////// initializing training item
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '' 'Trainer_Name' union SELECT [Trainer_Name] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TRAINERS_MASTER]";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            Trainer.DataSource = dt4;
            Trainer.DisplayMember = "Trainer_Name";
            //Trainer.Enabled = false;
            //Trainer.SelectedIndex = 1;
        }

        private void grid_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ob.CLS_CD.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
            ob.Search();
            ob.update_grid();
            this.Close();
        }

        private void Search_Btn_Click(object sender, EventArgs e)
        {
            conditions.Clear();
            grid.DataSource = null;
            if (CLS_CD.Text.Length != 0)
            {
                conditions.Add("[CLS_CD] like '%" + CLS_CD.Text + "%'");
            }
            if (CRS_NM.Text.Length != 0)
            {
                conditions.Add("[CLS_Course_Nm] like N'%" + CRS_NM.Text + "%'");
            }
            if (radCheckBox1.Checked)
            {
                conditions.Add("[CLS_ACTV] = 1");
            }
            else
            {
                conditions.Add("[CLS_ACTV] = 0");
            }
            if (Trainer.SelectedIndex != 0)
            {
                conditions.Add("[CLS_Trainer] = N'" + Trainer.Text + "'");
            }
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1;
            lcommand1 = "SELECT [CLS_CD]'کد کلاس',[CLS_CAPACITY]'ظرفیت',[CLS_Course_Nm]'نام دوره',[CLS_Trainer]'مدرس',[CLS_ACTV] 'فعال؟' FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]";
            if (conditions.Count != 0)
            {
                lcommand1 = lcommand1 + " WHERE " + string.Join(" AND ", conditions.ToArray()) + "order by [CLS_CD] asc";
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

        private void Search_Class_Result_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_Btn_Click(null, null);
            }
        }
    }
}
