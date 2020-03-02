using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using OpenXmlPackaging;

namespace SnappFood_Employee_Evaluation.QC
{
    public partial class RPT_COOR_PERFORMANCE : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public DataTable dt22 = new DataTable();

        public RPT_COOR_PERFORMANCE()
        {
            InitializeComponent();
        }

        private void QC_GENERAL_REPORT_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            dt_from.Culture = new System.Globalization.CultureInfo("fa-IR");
            dt_from.NullableValue = null;
            dt_from.SetToNullValue();

            dt_to.Culture = new System.Globalization.CultureInfo("fa-IR");
            dt_to.NullableValue = null;
            dt_to.SetToNullValue();

            
        }

        public void update_grid()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "select LS1.[Coordinator] 'نام سرگروه', LS2.Approved + LS3.Rejected + LS4.[NULL] 'مجموع لاگ ها', IIF(LS2.[Approved] is null, '0', LS2.[Approved]) 'تائید شده', IIF(LS3.[Rejected] is null, '0', LS3.[Rejected])  'رد شده', IIF(LS4.[NULL] is null, '0', LS4.[NULL]) 'منتظر بررسی' from( " +
                              "(SELECT Distinct [Coordinator] FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Coordinator] != 'NULL' and [Coordinator] != '' and [Coordinator] = N'" + user + "') LS1 " +
                              "left join (select Sel3.[Coordinator], count(Sel2.[QC_ID]) AS 'Approved' from((SELECT[QC_ID],[Agent_Ext] FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where[QC_M_Approval] = 1 and[CC_M_Approval] = 1 and[CC_M_Aprv_Usr] != N'لاگ موفق' and[CC_M_Aprv_Usr] != N'انتقال به کارتابل مدیر' and [CC_M_Aprv_Usr] != N'انتقال به کارتابل رهبر' and [CC_M_Aprv_Usr] != N'عدم تائید کیفی' and [CC_M_Aprv_Usr] != N'تائید اتوماتیک' " + (dt_from.Text == "" ? "" : (" and [insrt_dt_per] >= N'" + dt_from.Text + "'")) + (dt_to.Text == "" ? "" : (" and [insrt_dt_per] <= N'" + dt_to.Text + "'")) + ") Sel2 " +
                              "left join (SELECT[System_Id],[Coordinator] FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel3 on Sel2.[Agent_Ext] = Sel3.[System_Id]) group by Sel3.[Coordinator]) LS2 on LS1.[Coordinator] = LS2.[Coordinator] " +
                              "left join (select Sel5.[Coordinator], count(Sel4.[QC_ID]) AS 'Rejected' from((SELECT[QC_ID],[Agent_Ext] FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where[QC_M_Approval] = 1 and[CC_M_Approval] = 0 and[CC_M_Aprv_Usr] != N'لاگ موفق' and[CC_M_Aprv_Usr] != N'انتقال به کارتابل مدیر' and [CC_M_Aprv_Usr] != N'انتقال به کارتابل رهبر' and [CC_M_Aprv_Usr] != N'عدم تائید کیفی' and [CC_M_Aprv_Usr] != N'تائید اتوماتیک' " + (dt_from.Text == "" ? "" : (" and [insrt_dt_per] >= N'" + dt_from.Text + "'")) + (dt_to.Text == "" ? "" : (" and [insrt_dt_per] <= N'" + dt_to.Text + "'")) + ") Sel4 " +
                              "left join (SELECT[System_Id],[Coordinator] FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel5 on Sel4.[Agent_Ext] = Sel5.[System_Id]) group by Sel5.[Coordinator]) LS3 on LS1.[Coordinator] = LS3.[Coordinator] " +
                              "left join (select Sel7.[Coordinator], count(Sel6.[QC_ID]) AS 'NULL' from((SELECT[QC_ID],[Agent_Ext] FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where [QC_M_Approval] = 1 and [CC_M_Approval] is null " + (dt_from.Text == "" ? "" : (" and [insrt_dt_per] >= N'" + dt_from.Text + "'")) + (dt_to.Text == "" ? "" : (" and [insrt_dt_per] <= N'" + dt_to.Text + "'")) + ") Sel6 " +
                              "left join (SELECT[System_Id],[Coordinator] FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel7 on Sel6.[Agent_Ext] = Sel7.[System_Id]) group by Sel7.[Coordinator]) LS4 on LS1.[Coordinator] = LS4.[Coordinator]) order by LS1.Coordinator asc";
            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);
            if (dt22.Rows.Count != 0)
            {
                radGridView1.DataSource = dt22;
                radGridView1.BestFitColumns();
                //radGridView1.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
                for (int i = 0; i < radGridView1.Rows.Count; i++)
                {
                    radGridView1.Rows[i].Cells[1].Value = (int.Parse(radGridView1.Rows[i].Cells[2].Value.ToString()) + int.Parse(radGridView1.Rows[i].Cells[3].Value.ToString()) + int.Parse(radGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                }
            }
            else
            {
                RadMessageBox.Show(this, "مطابق با شرایط جستجو، موردی یافت نشد." + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            update_grid();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (radGridView1.Rows.Count != 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string add = saveFileDialog1.FileName;
                    add = add + ".xlsx";
                    using (var doc = new SpreadsheetDocument(@add))
                    {
                        Worksheet sheet1 = doc.Worksheets.Add("Report");
                        sheet1.ImportDataTable(dt22, "A1", true);
                    }
                    System.Diagnostics.Process.Start(@add);
                }
                else
                {

                }
            }
            else
            {
                RadMessageBox.Show(this, "اطلاعاتی جهت ارسال به اکسل وجود ندارد", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void QC_GENERAL_REPORT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                update_grid();
            }
        }
    }
}
