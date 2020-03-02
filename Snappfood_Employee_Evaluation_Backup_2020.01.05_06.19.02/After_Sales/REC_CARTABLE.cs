using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;

namespace SnappFood_Employee_Evaluation.After_Sales
{
    public partial class REC_CARTABLE : Telerik.WinControls.UI.RadForm
    {
        After_Sales.REC_RECEIPTION ob = null;
        public string constr;
        public DataTable dt22 = new DataTable();
        public string username;

        public REC_CARTABLE(After_Sales.REC_RECEIPTION ob)
        {
            InitializeComponent();
            this.ob = ob;
            RadMessageBox.ThemeName = "Office2010Silver";
        }

        private void QCM_CARTABLE_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            basket.TextAlign = ContentAlignment.MiddleCenter;
            log_announcment.TextAlign = ContentAlignment.MiddleLeft;
            update_grid();
        }

        public void update_grid()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT [Batch_No] 'شناسه دریافت',[Item_SN] 'سریال کالا',[In_DT_Per] 'تاریخ دریافت',[In_TM] 'ساعت دریافت' " +
                              ",[Nature] 'ماهیت',[Origin] 'مبدا', [position] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] " +
                              " where [Assigned_Rec] = N'" + username + "' and REC = 0";
            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);
            if (dt22.Rows.Count != 0)
            {
                radGridView1.DataSource = dt22;
                radGridView1.Columns[6].IsVisible = false;
                radGridView1.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.BestFitColumns();
                log_announcment.Text = dt22.Rows.Count.ToString();
                basket.Text = dt22.Rows[0][6].ToString();
            }
            else
            {
                log_announcment.Text = "0";
                basket.Text = " - ";
                RadMessageBox.Show(this, "کالای منتظر پذیرش در کارتابل شما وجود ندارد." + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            update_grid();
        }

        private void radGridView1_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            
        }
    }
}
