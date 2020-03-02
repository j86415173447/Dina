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
    public partial class RPT_QC_M : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public DataTable dt22 = new DataTable();

        public RPT_QC_M()
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
            string lcommand = "select Sel1.[QC_M_Aprv_Usr] 'نام کاربر', Sel2.[Aprv] + Sel3.[Rejc] 'کل بررسی شده', Sel2.[Aprv] 'تائید شده', Sel3.[Rejc] 'رد شده' from((SELECT distinct[QC_M_Aprv_Usr] FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where[QC_M_Aprv_Usr] != N'لاگ موفق' and[QC_M_Aprv_Usr] != 'NULL') Sel1 " +
                              "left join (Select[QC_M_Aprv_Usr], iif(count([QC_ID]) is null,0,count([QC_ID])) 'Aprv' FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where[QC_M_Approval] = 1 " + (dt_from.Text == "" ? "" : (" and [insrt_dt_per] >= N'" + dt_from.Text) + "'") + " group by[QC_M_Aprv_Usr] ) Sel2 on Sel1.[QC_M_Aprv_Usr] = Sel2.[QC_M_Aprv_Usr] " +
                              "left join (Select[QC_M_Aprv_Usr], iif(count([QC_ID]) is null,0,count([QC_ID])) 'Rejc' FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where[QC_M_Approval] = 0 " + (dt_from.Text == "" ? "" : (" and [insrt_dt_per] >= N'" + dt_from.Text) + "'") + " group by[QC_M_Aprv_Usr]) Sel3 on Sel1.[QC_M_Aprv_Usr] = Sel3.[QC_M_Aprv_Usr])";
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
                //for (int i = 0; i < radGridView1.Rows.Count; i++)
                //{
                //    radGridView1.Rows[i].Cells[1].Value = (int.Parse(radGridView1.Rows[i].Cells[2].Value.ToString()) + int.Parse(radGridView1.Rows[i].Cells[3].Value.ToString()) + int.Parse(radGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                //}
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
