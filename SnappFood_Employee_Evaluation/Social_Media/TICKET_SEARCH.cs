using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;

namespace SnappFood_Employee_Evaluation.Social_Media
{
    public partial class TICKET_SEARCH : Telerik.WinControls.UI.RadForm
    {
        Social_Media.TICKET_ENTRY ob = null;
        public string constr;
        public DataTable dt22 = new DataTable();
        public string user;

        public TICKET_SEARCH(Social_Media.TICKET_ENTRY ob)
        {
            InitializeComponent();
            this.ob = ob;
            RadMessageBox.ThemeName = "Office2010Silver";
        }

        private void QCM_CARTABLE_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            dt_from.Culture = new System.Globalization.CultureInfo("fa-IR");
            dt_from.NullableValue = null;
            dt_from.SetToNullValue();

            dt_to.Culture = new System.Globalization.CultureInfo("fa-IR");
            dt_to.NullableValue = null;
            dt_to.SetToNullValue();

            
            ///////////////////////////////////////////// DEPARTMENT
            DataTable dt3 = new DataTable();
            OleDbDataAdapter adp3 = new OleDbDataAdapter();
            adp3.SelectCommand = new OleDbCommand();
            adp3.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand3 = "SELECT '0' 'DEP_ID', '' 'Dep_NM' union SELECT [DEP_ID],[Dep_NM] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_DEPARTMENT] where [DEP_ACTV] = 1 order by [DEP_ID] asc";
            adp3.SelectCommand.CommandText = lcommand3;
            adp3.Fill(dt3);
            department.DataSource = dt3;
            department.DisplayMember = "Dep_NM";

            ///////////////////////////////////////////// STATUS
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '0' 'ST_Priority', '' 'ST_Text' union SELECT [ST_Priority],[ST_Text] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_STATUS_MASTER] WHERE [ST_ACTV] = 1 order by [ST_Priority] asc";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            tkt_status.DataSource = dt4;
            tkt_status.DisplayMember = "ST_Text";

            ///////////////////////////////////////////// REASON
            DataTable dt6 = new DataTable();
            OleDbDataAdapter adp6 = new OleDbDataAdapter();
            adp6.SelectCommand = new OleDbCommand();
            adp6.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand6 = "SELECT '' 'RSN_Desc' union SELECT distinct [RSN_Desc] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_REASON] where [RSN_ACTV] = 1";
            adp6.SelectCommand.CommandText = lcommand6;
            adp6.Fill(dt6);
            reason.DataSource = dt6;
            reason.DisplayMember = "RSN_Desc";
        }

        public string search_query()
        {
            List<string> conditions = new List<string>();
            string query = "";

            if (ticket_id.Text != "")
            {
                conditions.Add("SEL1.[TKT_id] = N'" + ticket_id.Text + "'");
            }
            if (social_id.Text != "")
            {
                conditions.Add("SEL1.[Social_user_nm] = N'" + social_id.Text + "'");
            }
            if (order_id.Text != "")
            {
                conditions.Add("SEL1.[order_no] = N'" + social_id.Text + "'");
            }
            if (dt_from.Text != "")
            {
                conditions.Add("SEL1.[TKT_Insrt_DT_Per] >= '" + dt_from.Text + "'");
            }
            if (dt_to.Text != "")
            {
                conditions.Add("SEL1.[TKT_Insrt_DT_Per] <= '" + dt_to.Text + "'");
            }
            if (department.SelectedIndex != 0)
            {
                conditions.Add("SEL1.[tkt_dep] = N'" + department.Text + "'");
            }
            if (reason.SelectedIndex != 0)
            {
                conditions.Add("SEL1.[tkt_rsn] = N'" + reason.Text + "'");
            }
            if (gallery.SelectedIndex == 1)
            {
                conditions.Add("SEL2.[Pic_Count] is not null");
            }
            if (tkt_status.SelectedIndex != 0)
            {
                conditions.Add("SEL1.[Tkt_STATUS] = N'" + tkt_status.Text + "'");
            }
            if (conditions.Count != 0)
            {
                query = query + " WHERE " + string.Join(" AND ", conditions.ToArray());
            }

            return query;
        }

        public void update_grid()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "Select Sel1.[TKT_ID] 'شماره تیکت',Sel1.[Social_Media] 'شبکه اجتماعی',Sel1.[Channel] 'کانال',Sel1.[Social_User_Nm] 'نام کاربری',Sel1.[TKT_Dep] 'دپارتمان',Sel1.[Order_No] 'شماره سفارش',Sel1.[TKT_RSN] 'موضوع',Sel1.[TKT_Status] 'وضعیت تیکت',Sel1.[TKT_Insrt_DT_Per] 'تاریخ ثبت',Sel1.[TKT_Insrt_usr] 'ایجاد کننده' from ( " +
                              "(SELECT [TKT_ID],[Social_Media],[Channel],[Social_User_Nm],[TKT_Dep],[Order_No],[TKT_RSN],[TKT_Status],[TKT_Insrt_DT_Per],[TKT_Insrt_usr] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKETING]) Sel1 " +
                              "left join (SELECT [Ticket_id],count([id]) 'Pic_Count' FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_GALLERY] group by [Ticket_id]) Sel2 on Sel1.[tkt_id] = Sel2.[Ticket_id]) ";
            adp.SelectCommand.CommandText = lcommand + search_query();
            dt22.Clear();
            adp.Fill(dt22);
            if (dt22.Rows.Count != 0)
            {
                log_announcment.Text = dt22.Rows.Count.ToString();
                radGridView1.DataSource = dt22;
                radGridView1.BestFitColumns();
            }
            else
            {
                dt22.Clear();
                radGridView1.DataSource = dt22;
                RadMessageBox.Show(this, "  هیچ تیکتی با مشخصات وارد شده یافت نشد.  " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            update_grid();
        }

        private void radGridView1_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ob.clear();
            ob.ticket_id.Text = radGridView1.SelectedRows[0].Cells[0].Value.ToString();
            ob.search();
            this.Close();
        }
    }
}
