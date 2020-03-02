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
    public partial class MNG_ITEM_STATUS : Telerik.WinControls.UI.RadForm
    {
        public string constr;

        public MNG_ITEM_STATUS()
        {
            InitializeComponent();
            origin.TextAlignment = ContentAlignment.MiddleLeft;
            org_desc.TextAlignment = ContentAlignment.MiddleLeft;
            position.TextAlignment = ContentAlignment.MiddleLeft;
            item_nature.TextAlignment = ContentAlignment.MiddleLeft;
            latest_status_DT.TextAlignment = ContentAlignment.MiddleLeft;
            latest_status.TextAlignment = ContentAlignment.MiddleLeft;
        }

        private void item_sn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && item_sn.Text != "")
            {

                search();
            }
        }

        private void MNG_ITEM_STATUS_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
        }

        public void search()
        {
            oleDbConnection1.ConnectionString = constr;
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT [Batch_No],[Position],[Nature],[Origin],[Origin_NM] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] where [Item_SN] = '" + item_sn.Text + "' order by [INBOUND_ID] DESC";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            if (dtsc4.Rows.Count != 0)
            {
                origin.Text = dtsc4.Rows[0][0].ToString() + " / " + dtsc4.Rows[0][3].ToString();
                org_desc.Text = dtsc4.Rows[0][4].ToString();
                position.Text = dtsc4.Rows[0][1].ToString();
                item_nature.Text = dtsc4.Rows[0][2].ToString();

                DataTable dtsc6 = new DataTable();
                OleDbDataAdapter adpsc6 = new OleDbDataAdapter();
                adpsc6.SelectCommand = new OleDbCommand();
                adpsc6.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommandsc6 = "SELECT SUBSTRING([STATUS_KEY],0,8) 'شناسه', [Item_SN] 'سریال کالا',[Status] 'وضعیت',[ST_Per_Date] 'تاریخ',[ST_Time] 'ساعت',[ST_User] 'کاربر' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_ITEM_JOURNEY] where [Item_SN] = '" + item_sn.Text + "' order by [ID] ASC";
                adpsc6.SelectCommand.CommandText = lcommandsc6;
                adpsc6.Fill(dtsc6);
                item_grid.DataSource = dtsc6;
                item_grid.BestFitColumns();

                if (dtsc6.Rows.Count != 0)
                {
                    latest_status_DT.Text = dtsc6.Rows[dtsc6.Rows.Count - 1][3].ToString();
                    latest_status.Text = dtsc6.Rows[dtsc6.Rows.Count - 1][2].ToString();
                }
                else
                {
                    latest_status_DT.Text = "بروز خطا";
                    latest_status.Text = "بروز خطا";
                }

            }
            else
            {
                origin.Text = "";
                org_desc.Text = "";
                position.Text = "";
                item_nature.Text = "";
                latest_status_DT.Text = "";
                latest_status.Text = "";
                item_grid.DataSource = null;
                RadMessageBox.Show(this, " سریال وارد شده یافت نشد. " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            item_sn.Text = "";
            item_sn.Focus();
        }
    }
}
