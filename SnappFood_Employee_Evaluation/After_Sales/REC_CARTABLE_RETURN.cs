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
    public partial class REC_CARTABLE_RETURN : Telerik.WinControls.UI.RadForm
    {
        After_Sales.REC_RECEIPTION_RETURN ob = null;
        public string constr;
        public DataTable dt22 = new DataTable();
        public string username;

        public REC_CARTABLE_RETURN(After_Sales.REC_RECEIPTION_RETURN ob)
        {
            InitializeComponent();
            this.ob = ob;
            RadMessageBox.ThemeName = "Office2010Silver";
        }

        private void QCM_CARTABLE_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            //basket.TextAlign = ContentAlignment.MiddleCenter;
            log_announcment.TextAlign = ContentAlignment.MiddleLeft;
            update_grid();
        }

        public void update_grid()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT Sel1.[Batch_No] 'شناسه دریافت',Sel1.[Item_SN] 'سریال کالا',[In_DT_Per] 'تاریخ دریافت',[In_TM] 'ساعت دریافت',[Nature] 'ماهیت',[Origin] 'مبدا' FROM (  " +
                              "(SELECT [Batch_No],[ITEM_SN] from [SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION]  where [Agent] = N'" + username + "' and [RET_ITEM] = 1 and [REC] = 0) Sel1 " +
                              "left join (SELECT [Inbound_ID],[In_DT_Per],[In_TM],[Nature],[Origin] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND]) Sel2 on (convert(nvarchar,Sel1.[Batch_no]) + convert(nvarchar,Sel1.[Item_SN])) = Sel2.[Inbound_ID]) ";
            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);
            if (dt22.Rows.Count != 0)
            {
                radGridView1.DataSource = dt22;

                radGridView1.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.BestFitColumns();
                log_announcment.Text = dt22.Rows.Count.ToString();
                //basket.Text = dt22.Rows[0][6].ToString();
            }
            else
            {
                log_announcment.Text = "0";
                //basket.Text = " - ";
                RadMessageBox.Show(this, "کالای منتظر پذیرش مجدد در کارتابل شما وجود ندارد." + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
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
