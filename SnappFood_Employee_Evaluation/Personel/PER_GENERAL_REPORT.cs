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

namespace SnappFood_Employee_Evaluation.Personel
{
    public partial class PER_GENERAL_REPORT : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt22 = new DataTable();


        public PER_GENERAL_REPORT()
        {
            InitializeComponent();
            Main_Shift.SelectedIndex = 0;
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void PER_GENERAL_REPORT_Load(object sender, EventArgs e)
        {
            emp_from_dt.Mask = emp_to_dt.Mask = "0000/00/00";
            oleDbConnection1.ConnectionString = constr;
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkvzF1o08hthhDtqY3mfT5D5YugnchRUILFmsJAH+MlystEun4HfKczPcJjASP/mnxJd9EgcqEEwKjl5OgcaUyPI807Lse0RyIQsNpWJQyh+EEy7hHxE0V24BdMYg7Es0aynDy6fBJ4b9Q/wLGbu3XML+fqEme2U9HCZcSdRZLJampqCua6C3pTXLKrfwph5cUSh02iMKXZFUum9dGAPTVg0t/k6JYEiTJ+zWkSkDYJQKUjRqd7c0ODs1eO/7qfbB5QLlA8EENysG+hwouUT6AuNXQwoewjfPgGQwA6RL8rbJGLlg7mGpoMpy2VJBeteZSAYwG8V8TyOrZSza7uVGzNDEiBBnMjGBTW8VztNiCD9OtsiK4Zjqe2tsM6JMWhbcfgV1min4H0y/qvBUKL2Zc+aWw8D09nJExn2OXDJKvT8Q==";
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
            ///////////////////////////////////////////////////////// initializing Shift Combo
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT '' 'Main_Shift' union SELECT distinct [Main_Shift] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]";
            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            Main_Shift.DataSource = dt2;
            Main_Shift.DisplayMember = "Main_Shift";
            ///////////////////////////////////////////////////////// initializing Pic State Combo
            DataTable dt3 = new DataTable();
            OleDbDataAdapter adp3 = new OleDbDataAdapter();
            adp3.SelectCommand = new OleDbCommand();
            adp3.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand3 = "Select N'' 'State' union Select N'دارای عکس' 'State' union SELECT N'فاقد عکس' 'State'";
            adp3.SelectCommand.CommandText = lcommand3;
            adp3.Fill(dt3);
            pic_state.DataSource = dt3;
            pic_state.DisplayMember = "State";
            ///////////////////////////////////////////////////////// initializing Doc State Combo
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "Select N'' 'State' union Select N'در حال کار' 'State' union SELECT N'قطع همکاری' 'State'";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            Doc_State.DataSource = dt4;
            Doc_State.DisplayMember = "State";
            ///////////////////////////////////////////////////////// initializing Doc State Combo
            DataTable dt5 = new DataTable();
            OleDbDataAdapter adp5 = new OleDbDataAdapter();
            adp5.SelectCommand = new OleDbCommand();
            adp5.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand5 = "Select N'' 'Job_Level', '100000000' 'SALARY' union SELECT Job_Level,Min(Job_Salary_Base) AS 'SALARY' FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_JOB_LEVELING] group by [Job_Level] order by SALARY desc";
            adp5.SelectCommand.CommandText = lcommand5;
            adp5.Fill(dt5);
            Pay_level.DataSource = dt5;
            Pay_level.DisplayMember = "Job_Level";

            ///////////////////////////////////////////////////////// initializing Doc State Combo
            DataTable dt50 = new DataTable();
            OleDbDataAdapter adp50 = new OleDbDataAdapter();
            adp50.SelectCommand = new OleDbCommand();
            adp50.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand50 = "SELECT '' 'Pos_Name', '0' 'POS_Priority' union SELECT [Pos_Name], [POS_Priority] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_POSITIONS_MASTER] where [Pos_Actv] = 1 order by [Pos_Priority] asc";
            adp50.SelectCommand.CommandText = lcommand50;
            adp50.Fill(dt50);
            job_Level.DataSource = dt50;
            job_Level.DisplayMember = "Pos_Name";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            List<string> conditions = new List<string>();
            if (Per_Dep.SelectedIndex != 0)
            {
                conditions.Add("Sel1.[Department] = N'" + Per_Dep.Text + "'");
            }
            if (Main_Shift.SelectedIndex != 0)
            {
                conditions.Add("Sel1.[Main_Shift] = N'" + Main_Shift.Text + "'");
            }
            if (pic_state.SelectedIndex != 0)
            {
                conditions.Add("Sel1.[Per_Pic] " + (pic_state.SelectedIndex.ToString() == "1" ? " is not NULL" : " is NULL"));
            }
            if (Doc_State.SelectedIndex != 0)
            {
                conditions.Add("Sel1.[Termination] = '" + (Doc_State.SelectedIndex.ToString() == "1" ? "0'" : "1'"));
            }
            if (Pay_level.SelectedIndex != 0)
            {
                conditions.Add("Sel3.Job_Level = N'" + Pay_level.Text + "'");
            }
            if (job_Level.SelectedIndex != 0)
            {
                conditions.Add("Sel1.Position = N'" + job_Level.Text + "'");
            }
            if (emp_from_dt.MaskFull)
            {
                conditions.Add("Sel1.[Employment_Dt] >= '" + emp_from_dt.Text + "'");
            }
            if (emp_to_dt.MaskFull)
            {
                conditions.Add("Sel1.[Employment_Dt] <= '" + emp_to_dt.Text + "'");
            }
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY Sel1.[Doc_No] ASC) AS 'ردیف',Sel1.[Doc_No] 'شماره پرونده', Sel1.[System_Id] 'شناسه سیستم', Sel1.[Chargoon_Id] 'شناسه شرکت', Sel1.[Per_National_Cd] 'کد ملی',Sel1.[Sex] 'عنوان' , Sel1.[Per_Name]'نام و نام خانوادگی', " +
                              "Sel1.[Per_Fa_Name] 'نام پدر', Sel1.[Per_Nk_Name] 'نام مستعار', Sel1.[Per_Tel] 'تلفن', Sel1.[Per_Mob] 'موبایل', Sel1.[Per_Add] 'آدرس', Sel1.[Department]'واحد سازمانی', Sel1.[Main_Shift]'شیفت اصلی',Sel1.[Birth_Dt]'تاریخ تولد', " +
                              "Sel1.[Employment_Dt] 'تاریخ استخدام', Sel1.[history] 'سابقه کار', Sel1.[Email] 'ایمیل', Sel1.[Degree] 'تحصیلات', Sel1.[Position] 'طبقه شغلی' , sel2.[Scores] 'امتیاز شغلی', Sel3.[Job_Grade] 'رتبه شغلی',sel3.[Job_Level] 'طبقه پرداختی',replace(convert(varchar,convert(Money, Sel3.[Job_Salary_Base]),1),'.00','') 'حقوق پایه' , Sel1.[Coordinator] 'نام سرگروه', Sel1.[Leader] 'نام رهبر', Sel1.[Manager] 'نام مدیر', [Main_Task] 'تسک اصلی', [Side_Task] 'تسک فرعی',  " +
                              "IIF([Termination] = 0, N'در حال کار', N'قطع همکاری' ) 'وضعیت پرونده', [Termination_DT] 'تاریخ قطع همکاری'  FROM ( (Select * from [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel1 " +
                              "left join (SELECT [Doc_No],sum([Sc_Score]) AS Scores FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] group by [Doc_No]) Sel2 on sel1.[Doc_No] = Sel2.[Doc_No] " +
                              "left join (SELECT [Job_Score],[Job_Grade],[Job_Level],[Job_Department],[Job_Salary_Base] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_JOB_LEVELING]) Sel3 on sel1.[Department] = sel3.[Job_Department] and sel2.[Scores] = Sel3.[Job_Score]) ";
            if (conditions.Count != 0)
            {
                lcommand = lcommand + " WHERE " + string.Join(" AND ", conditions.ToArray());
            }
            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);
            grid.DataSource = dt22;
            grid.BestFitColumns();
        }

        private void Per_Dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt22.Clear();
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
    }
}
