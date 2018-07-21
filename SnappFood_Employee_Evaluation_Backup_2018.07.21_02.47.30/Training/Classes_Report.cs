using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using Stimulsoft.Report;
using Stimulsoft.Report.Win;
using Stimulsoft.Report.Components;
using Stimulsoft.Base;
using System.IO;
using OpenXmlPackaging;

namespace SnappFood_Employee_Evaluation.Training
{
    public partial class Classes_Report : Telerik.WinControls.UI.RadForm
    {
        public DataTable dt22 = new DataTable();
        public string constr;

        public Classes_Report()
        {
            InitializeComponent();
            date_in.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        }

        private void Classes_Report_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkvzF1o08hthhDtqY3mfT5D5YugnchRUILFmsJAH+MlystEun4HfKczPcJjASP/mnxJd9EgcqEEwKjl5OgcaUyPI807Lse0RyIQsNpWJQyh+EEy7hHxE0V24BdMYg7Es0aynDy6fBJ4b9Q/wLGbu3XML+fqEme2U9HCZcSdRZLJampqCua6C3pTXLKrfwph5cUSh02iMKXZFUum9dGAPTVg0t/k6JYEiTJ+zWkSkDYJQKUjRqd7c0ODs1eO/7qfbB5QLlA8EENysG+hwouUT6AuNXQwoewjfPgGQwA6RL8rbJGLlg7mGpoMpy2VJBeteZSAYwG8V8TyOrZSza7uVGzNDEiBBnMjGBTW8VztNiCD9OtsiK4Zjqe2tsM6JMWhbcfgV1min4H0y/qvBUKL2Zc+aWw8D09nJExn2OXDJKvT8Q==";
            CLS_Status.SelectedIndex = 0;
            date_in.Mask = "00/00/0000";
            ///////////////////////////////////////////////////////// initializing training item
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '' 'Trainer_Name' union SELECT [Trainer_Name] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TRAINERS_MASTER] order by [Trainer_Name]";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            Trainer.DataSource = dt4;
            Trainer.DisplayMember = "Trainer_Name";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            dt22.Clear();
            if (false)
            {
                //RadMessageBox.Show(this, "انتخاب ماه تولد الزامیست", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                List<string> conditions = new List<string>();
                if (CLS_Status.SelectedIndex != 0)
                {
                    conditions.Add("[CLS_ACTV] = N'" + (CLS_Status.SelectedIndex == 1 ? "1" : "0") + "'");
                }
                if (Trainer.SelectedIndex != 0)
                {
                    conditions.Add("[CLS_Trainer] = N'" + Trainer.Text + "'");
                }
                if (date_in.MaskFull)
                {
                    conditions.Add("[CLS_Date] like '%" + date_in.Text + "%'");
                }
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand();
                adp.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY sel1.[CLS_CD] ASC) AS 'ردیف',sel1.[CLS_CD]'کد کلاس',sel1.[CLS_CAPACITY]'ظرفیت',isnull(sel2.qty,0) 'تعداد ثبت نام',(sel1.[CLS_CAPACITY]-isnull(sel2.qty,0)) 'ظرفیت باقی مانده',sel1.[CLS_Location]'محل کلاس',sel1.[CLS_Course_Nm]'نام دوره',Sel3.[CRS_TYPE] 'نوع دوره',sel1.[CLS_Trainer]'مدرس',sel1.[CLS_From_Time]'ساعت شروع',sel1.[CLS_To_Time]'ساعت پایان',sel1.[CLS_Date]'تاریخ برگزاری',sel1.[CLS_ACTV]'وضعیت کلاس' from ( " +
                                  "(SELECT[CLS_CD],[CLS_CAPACITY],[CLS_Location],[CLS_Course_Nm],[CLS_Course_CD],[CLS_Trainer],[CLS_From_Time],[CLS_To_Time],[CLS_Date],[CLS_ACTV] FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) sel1 " +
                                  "left join (SELECT CLS_CD, count([CLS_Cd]) AS QTY FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] group by[CLS_CD]) sel2 on sel1.[CLS_CD] = sel2.[CLS_CD] " +
                                  "left join (SELECT [CRS_CD],[CRS_Type] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_COURSE_MASTER]) Sel3 on sel3.[CRS_CD] = sel1.[CLS_COURSE_CD]) ";
                if (conditions.Count != 0)
                {
                    lcommand = lcommand + " WHERE " + string.Join(" AND ", conditions.ToArray());
                }
                adp.SelectCommand.CommandText = lcommand;
                adp.Fill(dt22);
                grid.DataSource = dt22;
                grid.BestFitColumns();
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (grid.Rows.Count != 0)
            {

                /////////////////////////////////////////////// make ds
                DataTable ds = new DataTable();
                List<string> conditions = new List<string>();
                if (CLS_Status.SelectedIndex != 0)
                {
                    conditions.Add("[CLS_ACTV] = N'" + (CLS_Status.SelectedIndex == 1 ? "1" : "0") + "'");
                }
                if (Trainer.SelectedIndex != 0)
                {
                    conditions.Add("[CLS_Trainer] = N'" + Trainer.Text + "'");
                }
                if (date_in.MaskFull)
                {
                    conditions.Add("[CLS_Date] like '%" + date_in.Text + "%'");
                }
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand();
                adp.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY sel1.[CLS_CD] ASC) AS 'Row',sel1.[CLS_CD],sel1.[CLS_CAPACITY],isnull(sel2.qty,0) AS 'Reged',(sel1.[CLS_CAPACITY]-isnull(sel2.qty,0)) AS 'REM',sel1.[CLS_Location],sel1.[CLS_Course_Nm],sel1.[CLS_Trainer],sel1.[CLS_From_Time],sel1.[CLS_To_Time],sel1.[CLS_Date],sel1.[CLS_ACTV],sel3.[CRS_TYPE] 'Type' from ( " +
                                  "(SELECT[CLS_CD],[CLS_CAPACITY],[CLS_Location],[CLS_Course_Nm],[CLS_Course_CD],[CLS_Trainer],[CLS_From_Time],[CLS_To_Time],[CLS_Date],[CLS_ACTV] FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) sel1 " +
                                  "left join (SELECT CLS_CD, count([CLS_Cd]) AS QTY FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] group by[CLS_CD]) sel2 on sel1.[CLS_CD] = sel2.[CLS_CD] " +
                                  "left join (SELECT [CRS_CD],[CRS_Type] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_COURSE_MASTER]) Sel3 on sel3.[CRS_CD] = sel1.[CLS_COURSE_CD]) ";
                if (conditions.Count != 0)
                {
                    lcommand = lcommand + " WHERE " + string.Join(" AND ", conditions.ToArray());
                }
                adp.SelectCommand.CommandText = lcommand;
                ds.Clear();
                adp.Fill(ds);
                StiReport report = new StiReport();
                report.Load(Application.StartupPath + "\\Reports\\Class_Report.mrt");
                report.RegData(ds);
                Stimulsoft.Report.Print.StiPrintProvider.SetPaperSource = false;
                report.Render();
                report.Show();
            }
            else
            {
                RadMessageBox.Show(this, "اطلاعاتی جهت چاپ وجود ندارد", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void Export_Click(object sender, EventArgs e)
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
    }
}
