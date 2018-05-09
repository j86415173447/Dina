using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;

namespace SnappFood_Employee_Evaluation.QC
{
    public partial class MNG_CARTABLE : Telerik.WinControls.UI.RadForm
    {
        QC.MNG_APPROVAL ob = null;
        public string constr;
        public DataTable dt22 = new DataTable();
        public string user;

        public MNG_CARTABLE(QC.MNG_APPROVAL ob)
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

            ///////////////////////////// initilize Agent combo
            DataTable dt5 = new DataTable();
            OleDbDataAdapter adp5 = new OleDbDataAdapter();
            adp5.SelectCommand = new OleDbCommand();
            adp5.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand5 = "SELECT '' 'Per_Name' union SELECT [Per_name] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Coordinator] = N'" + user + "'";
            adp5.SelectCommand.CommandText = lcommand5;
            adp5.Fill(dt5);
            Agent.DataSource = dt5;
            Agent.DisplayMember = "Per_name";

            ///////////////////////////// initilize call type combo
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '' 'Call_Type_id', '' 'Call_Type_nm' union SELECT [Call_Type_id],[Call_Type_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_CALL_TYPE] where [Call_Type_Actv] != 0 order by  [Call_Type_id] asc";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            Call_Type.DataSource = dt4;
            Call_Type.DisplayMember = "Call_Type_nm";
            Call_Type.ValueMember = "Call_Type_id";


            ////////////////////////////////////////////////////////Initial grid updation
            DataTable dt234 = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY SEL1.[QC_ID] ASC) AS 'ردیف', SEL1.[QC_ID] 'شناسه کیفی', SEL1.[QC_Score] 'امتیاز کیفی', SEL1.[Agent_Ext] 'شماره داخلی', SEL2.[Per_Name] 'نام ایجنت', SEL2.[Department] 'واحد شغلی', " +
                              "SEL3.[Call_Type_nm] 'نوع تماس', SEL4.[Plan_nm] 'پلن کیفی', SEL1.[taboo] 'تابو؟', SEL1.[insrt_dt_per] 'تاریخ بررسی' FROM ( " +
                              "(SELECT [QC_ID],[QC_Score],[Agent_Ext],[Call_Type_Cd],[Log_Type_Cd],[taboo],[insrt_dt_per],[QC_Agent] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE ([QC_M_Approval] = 1 and [CC_M_Approval] = 0 and [LD_M_Approval] = 0 and [MG_M_Approval] is null)) SEL1 " +
                              "LEFT JOIN (SELECT [System_Id],[Department],[Per_Name],[Manager] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) SEL2 ON SEL1.[Agent_Ext] = SEL2.[System_Id] " +
                              "LEFT JOIN (SELECT [Call_Type_id],[Call_Type_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_CALL_TYPE]) SEL3 ON SEL1.[Call_Type_Cd] = SEL3.[Call_Type_id] " +
                              "LEFT JOIN (SELECT [Plan_id],[Plan_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_PLAN]) SEL4 ON SEL1.[Log_Type_Cd] = SEL4.[Plan_id]) ";

            string lcommand3434 = " union SELECT ROW_NUMBER() OVER(ORDER BY SEL1.[QC_ID] ASC) AS 'ردیف', SEL1.[QC_ID] 'شناسه کیفی', SEL1.[QC_Score] 'امتیاز کیفی', SEL1.[Agent_Ext] 'شماره داخلی', SEL2.[Per_Name] 'نام ایجنت', SEL2.[Department] 'واحد شغلی', " +
                              "SEL3.[Call_Type_nm] 'نوع تماس', SEL4.[Plan_nm] 'پلن کیفی', SEL1.[taboo] 'تابو؟', SEL1.[insrt_dt_per] 'تاریخ بررسی' FROM ( " +
                              "(SELECT [QC_ID],[QC_Score],[Agent_Ext],[Call_Type_Cd],[Log_Type_Cd],[taboo],[insrt_dt_per],[QC_Agent] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_M_Approval] = 1 and [CC_M_Approval] is null) SEL1 " +
                              "LEFT JOIN (SELECT [System_Id],[Department],[Per_Name],[Manager],[Coordinator] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] ) SEL2 ON SEL1.[Agent_Ext] = SEL2.[System_Id] " +
                              "LEFT JOIN (SELECT [Call_Type_id],[Call_Type_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_CALL_TYPE]) SEL3 ON SEL1.[Call_Type_Cd] = SEL3.[Call_Type_id] " +
                              "LEFT JOIN (SELECT [Plan_id],[Plan_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_PLAN]) SEL4 ON SEL1.[Log_Type_Cd] = SEL4.[Plan_id]) where sel2.[Coordinator] = N'نامشخص' and sel2.[Manager] = N'" + user + "'";
            adp.SelectCommand.CommandText = lcommand + search_query() + lcommand3434;
            dt234.Clear();
            adp.Fill(dt234);
            if (dt234.Rows.Count != 0)
            {
                radGridView1.DataSource = dt234;
                radGridView1.BestFitColumns();
                log_announcment.Text = dt234.Rows.Count.ToString();
            }
            else
            {

                RadMessageBox.Show(this, "لاگ منتظر تائید در کارتابل شما وجود ندارد." + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                this.Close();
            }

            /////////////////////////////////////////////////////////// Total remaining
            //DataTable dt33 = new DataTable();
            //OleDbDataAdapter adp33 = new OleDbDataAdapter();
            //adp33.SelectCommand = new OleDbCommand();
            //adp33.SelectCommand.Connection = oleDbConnection1;
            //oleDbCommand1.Parameters.Clear();
            //string lcommand33 = "SELECT * FROM ( " +
            //                  "(SELECT [Agent_Ext] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_M_Approval] = 1 and [CC_M_Approval] = 0 and [LD_M_Approval] = 0 and [MG_M_Approval] is null) SEL1 " +
            //                  "LEFT JOIN (SELECT [System_Id],[Manager] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) SEL2 ON SEL1.[Agent_Ext] = SEL2.[System_Id]) " +
            //                  "where SEL2.[Manager] = N'" + user + "'";
            //adp33.SelectCommand.CommandText = lcommand33;
            //adp33.Fill(dt33);
            //log_announcment.Text = dt33.Rows.Count.ToString();
        }

        public string search_query()
        {
            List<string> conditions = new List<string>();
            string query = "";

            if (Call_Type.SelectedIndex != 0)
            {
                conditions.Add("SEL3.[Call_Type_nm] = N'" + Call_Type.Text + "'");
            }
            if (Agent.SelectedIndex != 0)
            {
                conditions.Add("SEL2.[Per_Name] = N'" + Agent.Text + "'");
            }
            if (true)
            {
                conditions.Add("SEL2.[Manager] = N'" + user + "'");
            }
            if (dt_from.Text != "")
            {
                conditions.Add("SEL1.[Insrt_dt_per] >= '" + dt_from.Text + "'");
            }
            if (dt_to.Text != "")
            {
                conditions.Add("SEL1.[Insrt_dt_per] <= '" + dt_to.Text + "'");
            }
            if (scr_from.Text != "")
            {
                conditions.Add("SEL1.[QC_Score] >= '" + scr_from.Text + "'");
            }
            if (scr_to.Text != "")
            {
                conditions.Add("SEL1.[QC_Score] <= '" + scr_to.Text + "'");
            }
            if (Taboo.Checked)
            {
                conditions.Add("SEL1.[taboo] = 1");
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
            string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY SEL1.[QC_ID] ASC) AS 'ردیف', SEL1.[QC_ID] 'شناسه کیفی', SEL1.[QC_Score] 'امتیاز کیفی', SEL1.[Agent_Ext] 'شماره داخلی', SEL2.[Per_Name] 'نام ایجنت', SEL2.[Department] 'واحد شغلی', " +
                              "SEL3.[Call_Type_nm] 'نوع تماس', SEL4.[Plan_nm] 'پلن کیفی', SEL1.[taboo] 'تابو؟', SEL1.[insrt_dt_per] 'تاریخ بررسی' FROM ( " +
                              "(SELECT [QC_ID],[QC_Score],[Agent_Ext],[Call_Type_Cd],[Log_Type_Cd],[taboo],[insrt_dt_per],[QC_Agent] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_M_Approval] = 1 and [CC_M_Approval] = 0 and [LD_M_Approval] = 0 and [MG_M_Approval] is null) SEL1 " +
                              "LEFT JOIN (SELECT [System_Id],[Department],[Per_Name],[Manager] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) SEL2 ON SEL1.[Agent_Ext] = SEL2.[System_Id] " +
                              "LEFT JOIN (SELECT [Call_Type_id],[Call_Type_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_CALL_TYPE]) SEL3 ON SEL1.[Call_Type_Cd] = SEL3.[Call_Type_id] " +
                              "LEFT JOIN (SELECT [Plan_id],[Plan_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_PLAN]) SEL4 ON SEL1.[Log_Type_Cd] = SEL4.[Plan_id]) ";
            string lcommand3434 = " union SELECT ROW_NUMBER() OVER(ORDER BY SEL1.[QC_ID] ASC) AS 'ردیف', SEL1.[QC_ID] 'شناسه کیفی', SEL1.[QC_Score] 'امتیاز کیفی', SEL1.[Agent_Ext] 'شماره داخلی', SEL2.[Per_Name] 'نام ایجنت', SEL2.[Department] 'واحد شغلی', " +
                              "SEL3.[Call_Type_nm] 'نوع تماس', SEL4.[Plan_nm] 'پلن کیفی', SEL1.[taboo] 'تابو؟', SEL1.[insrt_dt_per] 'تاریخ بررسی' FROM ( " +
                              "(SELECT [QC_ID],[QC_Score],[Agent_Ext],[Call_Type_Cd],[Log_Type_Cd],[taboo],[insrt_dt_per],[QC_Agent] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] WHERE [QC_M_Approval] = 1 and [CC_M_Approval] is null) SEL1 " +
                              "LEFT JOIN (SELECT [System_Id],[Department],[Per_Name],[Manager],[Coordinator] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] ) SEL2 ON SEL1.[Agent_Ext] = SEL2.[System_Id] " +
                              "LEFT JOIN (SELECT [Call_Type_id],[Call_Type_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_CALL_TYPE]) SEL3 ON SEL1.[Call_Type_Cd] = SEL3.[Call_Type_id] " +
                              "LEFT JOIN (SELECT [Plan_id],[Plan_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_PLAN]) SEL4 ON SEL1.[Log_Type_Cd] = SEL4.[Plan_id]) where sel2.[Coordinator] = N'نامشخص' and sel2.[Manager] = N'" + user + "'";
            adp.SelectCommand.CommandText = lcommand + search_query() + lcommand3434;
            dt22.Clear();
            adp.Fill(dt22);
            if (dt22.Rows.Count != 0)
            {
                radGridView1.DataSource = dt22;
                radGridView1.BestFitColumns();
            }
            else
            {
                dt22.Clear();
                radGridView1.DataSource = dt22;
                RadMessageBox.Show(this, "لاگ با مشخصات وارد شده یافت نشد." + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            update_grid();
        }

        private void radGridView1_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ob.clear();
            ob.aprv_button.Enabled = true;
            ob.rejct_button.Enabled = true;
            ob.QC_ID.Text = radGridView1.SelectedRows[0].Cells[1].Value.ToString();
            ob.search();
            
            this.Close();
        }
    }
}
