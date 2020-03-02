using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
//using Excel = Microsoft.Office.Interop.Excel;
using OpenXmlPackaging;

namespace SnappFood_Employee_Evaluation.After_Sales
{
    public partial class RPT_PROCESSING_PERFORMANCE : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt22 = new DataTable();


        public RPT_PROCESSING_PERFORMANCE()
        {
            InitializeComponent();
            RadMessageBox.SetThemeName("Office2010Silver");

            from_dt.Culture = new System.Globalization.CultureInfo("fa-IR");
            from_dt.NullableValue = null;
            from_dt.SetToNullValue();

            to_dt.Culture = new System.Globalization.CultureInfo("fa-IR");
            to_dt.NullableValue = null;
            to_dt.SetToNullValue();
        }

        private void PER_GENERAL_REPORT_Load(object sender, EventArgs e)
        {
            //emp_from_dt.Mask = emp_to_dt.Mask = "0000/00/00";
            oleDbConnection1.ConnectionString = constr;
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkvzF1o08hthhDtqY3mfT5D5YugnchRUILFmsJAH+MlystEun4HfKczPcJjASP/mnxJd9EgcqEEwKjl5OgcaUyPI807Lse0RyIQsNpWJQyh+EEy7hHxE0V24BdMYg7Es0aynDy6fBJ4b9Q/wLGbu3XML+fqEme2U9HCZcSdRZLJampqCua6C3pTXLKrfwph5cUSh02iMKXZFUum9dGAPTVg0t/k6JYEiTJ+zWkSkDYJQKUjRqd7c0ODs1eO/7qfbB5QLlA8EENysG+hwouUT6AuNXQwoewjfPgGQwA6RL8rbJGLlg7mGpoMpy2VJBeteZSAYwG8V8TyOrZSza7uVGzNDEiBBnMjGBTW8VztNiCD9OtsiK4Zjqe2tsM6JMWhbcfgV1min4H0y/qvBUKL2Zc+aWw8D09nJExn2OXDJKvT8Q==";
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            List<string> conditions = new List<string>();
           
            if (from_dt.Text != "")
            {
                conditions.Add("[Insrt_DT_Per] >= N'" + from_dt.Text + "'");
            }
            else
            {
                RadMessageBox.Show(this, "  تاریخ نمی تواند خالی باشد. " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                return;
            }
            if (to_dt.Text != "")
            {
                conditions.Add("[Insrt_DT_Per] <= N'" + to_dt.Text + "'");
            }
            else
            {
                RadMessageBox.Show(this, "  تاریخ نمی تواند خالی باشد. " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                return;
            }
            
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT convert(nvarchar,[Batch_No])+[Item_SN] 'شناسه قبض',[Batch_No] 'شناسه دریافت',[Item_SN] 'سریال',[Agent] 'کارشناس',[Test_Result] 'نتیجه بررسی',[RET_ITEM] 'برگشتی',[Insrt_DT_Per] 'تاریخ',[Insrt_TM] 'ساعت' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_RECEIPTION] where [rec] = 1 and [Batch_No] != 0 " + (conditions.Count != 0 ? "AND" + string.Join(" AND ", conditions.ToArray()) : "") +
                        "UNION SELECT convert(nvarchar,[Batch_No])+[Item_SN] 'شناسه قبض',[Batch_No] 'شناسه دریافت',[Item_SN] 'سریال',[Agent] 'کارشناس',[Test_Result] 'نتیجه بررسی','0' 'برگشتی',[Insrt_DT_Per] 'تاریخ',[Insrt_TM] 'ساعت' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_TECHNICAL]  where [TECH] = 1 and [Batch_No] != 0 " + (conditions.Count != 0 ? "AND" + string.Join(" AND ", conditions.ToArray()) : "");
            //if (conditions.Count != 0)
            //{
            //    lcommand = lcommand + " WHERE " + string.Join(" AND ", conditions.ToArray());
            //}
            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);
            grid.DataSource = dt22;
            grid.BestFitColumns();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (grid.Rows.Count != 0)
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
                        sheet1.AutoFitColumns();
                        
                    }
                    System.Diagnostics.Process.Start(@add);
                }
                else
                {
                   
                }
            }
            else
            {
                RadMessageBox.Show(this, "اطلاعاتی جهت ارسال به اکسل وجود ندارد", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error,MessageBoxDefaultButton.Button1,RightToLeft.Yes);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
