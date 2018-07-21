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
    public partial class Search_Class : Telerik.WinControls.UI.RadForm
    {
        Training.TRN_REGISTRATION ob = null;
        public string constr;
        public List<string> conditions = new List<string>();
        public DataTable dt = new DataTable();

        public Search_Class(Training.TRN_REGISTRATION ob)
        {
            InitializeComponent();
            this.ob = ob;
            this.KeyPreview = true;
        }

        private void Search_Staff_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            /////////////////////////////////////////////// Get Class list only active ones
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT sel1.[CLS_CD]'کد کلاس',sel1.[CLS_CAPACITY]'ظرفیت',isnull(sel2.qty,0) 'تعداد ثبت نام',(sel1.[CLS_CAPACITY]-isnull(sel2.qty,0)) 'ظرفیت باقی مانده',sel1.[CLS_Course_Nm]'نام دوره',sel1.[CLS_Trainer]'مدرس' from ( " +
                                  "(SELECT[CLS_CD],[CLS_CAPACITY],[CLS_Location],[CLS_Course_Nm],[CLS_Trainer],[CLS_From_Time],[CLS_To_Time],[CLS_Date],[CLS_ACTV] FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES] where [CLS_ACTV] = 1) sel1 " +
                                  "left join (SELECT CLS_CD, count([CLS_Cd]) AS QTY FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] group by [CLS_CD]) sel2 on sel1.[CLS_CD] = sel2.[CLS_CD]) order by sel1.[CLS_CD] asc ";
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

        private void grid_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ob.CLS_CD.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
            ob.Search();
            ob.update_grid();
            this.Close();
        }
    }
}
