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
    public partial class RPT_QC_PENALTY : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public DataTable dt22 = new DataTable();

        public RPT_QC_PENALTY()
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
            string lcommand = "SELECT Sel2.*,Sel1.[Failed_log] 'لاگ ناموفق' FROM ( " +
                              "(SELECT [Agent_Ext], COUNT([Final_Approval]) AS [Failed_log] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where [Final_Approval] = 1 " + (dt_from.Text == "" ? "" : (" AND [Final_Aprv_DT] >= N'" + dt_from.Text + "'")) + (dt_to.Text == "" ? "" : (" AND [Final_Aprv_DT] <= N'" + dt_to.Text + "'")) + "group by [Agent_Ext]) Sel1 " +
                              "left join (SELECT [Doc_No] 'شماره پرونده',[System_Id] 'داخلی',[Per_Name] 'نام کارشناس',[Department] 'واحد شغلی',[Main_Shift] 'شیفت' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel2 on Sel2.[داخلی] = Sel1.[Agent_Ext]) order by Sel1.[Failed_log] desc ";
            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);
            if (dt22.Rows.Count != 0)
            {
                radGridView1.DataSource = dt22;
                radGridView1.BestFitColumns();
                radGridView1.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
                radGridView1.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
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
