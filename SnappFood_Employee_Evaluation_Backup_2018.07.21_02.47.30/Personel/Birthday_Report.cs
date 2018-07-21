using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using Stimulsoft.Report;
using Stimulsoft.Report.Win;
using Stimulsoft.Report.Components;
using Stimulsoft.Base;
using System.IO;

namespace SnappFood_Employee_Evaluation.Personel
{
    public partial class Birthday_Report : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt22 = new DataTable();
        public bool loadfinish = false;
        public DataTable dtprint = new DataTable();

        public Birthday_Report()
        {
            InitializeComponent();
            month.SelectedIndex = 0;
            Main_Shift.SelectedIndex = 0;
            this.grid.TableElement.RowHeight = 80;
            RadMessageBox.SetThemeName("Office2010Silver");
            
        }

        private void Birthday_Report_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkvzF1o08hthhDtqY3mfT5D5YugnchRUILFmsJAH+MlystEun4HfKczPcJjASP/mnxJd9EgcqEEwKjl5OgcaUyPI807Lse0RyIQsNpWJQyh+EEy7hHxE0V24BdMYg7Es0aynDy6fBJ4b9Q/wLGbu3XML+fqEme2U9HCZcSdRZLJampqCua6C3pTXLKrfwph5cUSh02iMKXZFUum9dGAPTVg0t/k6JYEiTJ+zWkSkDYJQKUjRqd7c0ODs1eO/7qfbB5QLlA8EENysG+hwouUT6AuNXQwoewjfPgGQwA6RL8rbJGLlg7mGpoMpy2VJBeteZSAYwG8V8TyOrZSza7uVGzNDEiBBnMjGBTW8VztNiCD9OtsiK4Zjqe2tsM6JMWhbcfgV1min4H0y/qvBUKL2Zc+aWw8D09nJExn2OXDJKvT8Q==";
            ///////////////////////////////////////////////////////// Prepare gridview
            DataTable dt22 = new DataTable();
            OleDbDataAdapter adp22 = new OleDbDataAdapter();
            adp22.SelectCommand = new OleDbCommand();
            adp22.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand22 = "SELECT top 1 ROW_NUMBER() OVER(ORDER BY [Main_Shift],[Department],[Per_name] ASC) AS 'ردیف',[Per_Name]'نام و نام خانوادگی', [Department]'واحد سازمانی',[Main_Shift]'شیفت اصلی',[Birth_Dt]'تاریخ تولد',[Employment_Dt] 'تاریخ استخدام', [Per_Pic]'تصویر' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]";
            adp22.SelectCommand.CommandText = lcommand22;
            adp22.Fill(dt22);
            grid.DataSource = dt22;
            grid.Columns[6].DataType = typeof(Image);
            grid.BestFitColumns();
            grid.Columns[6].Width = 60;
            grid.Columns[6].ImageLayout = ImageLayout.Stretch;
            dt22.Clear();
            loadfinish = true;
            ///////////////////////////////////////////////////////// initializing department combo
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT '' 'Department_Nm','' 'Department_Cd' union SELECT [Department_Nm],[Department_Cd] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_DEPARTMENT] where [Department_Actv] = 1 order by Department_Cd asc";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt);
            Per_Dep.DataSource = dt;
            Per_Dep.ValueMember = "Department_Cd";
            Per_Dep.DisplayMember = "Department_Nm";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            dt22.Clear();
            if(month.SelectedIndex == 0)
            {
                RadMessageBox.Show(this, "انتخاب ماه تولد الزامیست", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                List<string> conditions = new List<string>();
                if (Per_Dep.SelectedIndex != 0)
                {
                    conditions.Add("[Department] = N'" + Per_Dep.Text + "'");
                }
                if (Main_Shift.SelectedIndex != 0)
                {
                    conditions.Add("[Main_Shift] = N'" + Main_Shift.Text + "'");
                }
                if(date_in.MaskFull)
                {
                    conditions.Add("[Employment_Dt] <= N'" + date_in.Text + "'");
                }
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand();
                adp.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY [Main_Shift],[Department],[Per_name] ASC) AS 'ردیف',[Per_Name]'نام و نام خانوادگی', [Department]'واحد سازمانی',[Main_Shift]'شیفت اصلی',[Birth_Dt]'تاریخ تولد',[Employment_Dt] 'تاریخ استخدام', [Per_Pic]'تصویر' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Termination] != 1 and substring(Birth_Dt,6,2) = " + month.SelectedIndex;
                if (conditions.Count != 0)
                {
                    lcommand = lcommand + " AND " + string.Join(" AND ", conditions.ToArray());
                }
                adp.SelectCommand.CommandText = lcommand;
                adp.Fill(dt22);
                grid.DataSource = dt22;
                //grid.Columns[4].DataType = typeof(Image);
                grid.BestFitColumns();
                if (this.WindowState == FormWindowState.Maximized)
                {
                    grid.Columns[6].Width = 120;
                    this.grid.TableElement.RowHeight = 160;
                }
                else
                {
                    grid.Columns[6].Width = 60;
                    this.grid.TableElement.RowHeight = 80;
                }
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (grid.Rows.Count != 0)
            {
                
                /////////////////////////////////////////////// make ds
                DataTable ds = new DataTable();
                List<string> conditions = new List<string>();
                if (Per_Dep.SelectedIndex != 0)
                {
                    conditions.Add("[Department] = N'" + Per_Dep.Text + "'");
                }
                if (Main_Shift.SelectedIndex != 0)
                {
                    conditions.Add("[Main_Shift] = N'" + Main_Shift.Text + "'");
                }
                if (date_in.MaskFull)
                {
                    conditions.Add("[Employment_Dt] <= N'" + date_in.Text + "'");
                }
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand();
                adp.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY [Main_Shift],[Department],[Per_name] ASC) AS Row,[Department],[Main_Shift],[Per_Name],[Birth_Dt],[Per_Pic],[Employment_Dt] 'EMP',[Birth_Dt] 'BRTH' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Termination] != 1 and substring(Birth_Dt,6,2) = " + month.SelectedIndex;
                if (conditions.Count != 0)
                {
                    lcommand = lcommand + " AND " + string.Join(" AND ", conditions.ToArray());
                }
                adp.SelectCommand.CommandText = lcommand;
                ds.Clear();
                adp.Fill(ds);

                StiReport report = new StiReport();
                report.Load(Application.StartupPath + "\\Reports\\Birthday.mrt");
                report.RegData(ds);
                report.Dictionary.Variables.Add("month", month.Text);
                Stimulsoft.Report.Print.StiPrintProvider.SetPaperSource = false;
                report.Render();
                report.Show();
            }
            else
            {
                RadMessageBox.Show(this, "اطلاعاتی جهت چاپ وجود ندارد", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt22.Clear();
        }
    }
}
