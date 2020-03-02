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

namespace SnappFood_Employee_Evaluation.Training
{
    public partial class CLS_PRESENT_ABSENT : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public DataTable dt22 = new DataTable();

        public CLS_PRESENT_ABSENT()
        {
            InitializeComponent();
            CLS_Cap.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_DTs.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_From.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Reg.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Stat.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Rem.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_To.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Trainer.TextAlignment = ContentAlignment.MiddleLeft;
            CRS_NM.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Loc.TextAlignment = ContentAlignment.MiddleLeft;
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void CLS_PRESENT_ABSENT_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHl2AD0gPVknKsaW0un+3PuM6TTcPMUAWEURKXNso0e5OFPaZYasFtsxNoDemsFOXbvf7SIcnyAkFX/4u37NTfx7g+0IqLXw6QIPolr1PvCSZz8Z5wjBNakeCVozGGOiuCOQDy60XNqfbgrOjxgQ5y/u54K4g7R/xuWmpdx5OMAbUbcy3WbhPCbJJYTI5Hg8C/gsbHSnC2EeOCuyA9ImrNyjsUHkLEh9y4WoRw7lRIc1x+dli8jSJxt9C+NYVUIqK7MEeCmmVyFEGN8mNnqZp4vTe98kxAr4dWSmhcQahHGuFBhKQLlVOdlJ/OT+WPX1zS2UmnkTrxun+FWpCC5bLDlwhlslxtyaN9pV3sRLO6KXM88ZkefRrH21DdR+4j79HA7VLTAsebI79t9nMgmXJ5hB1JKcJMUAgWpxT7C7JUGcWCPIG10NuCd9XQ7H4ykQ4Ve6J2LuNo9SbvP6jPwdfQJB6fJBnKg4mtNuLMlQ4pnXDc+wJmqgw25NfHpFmrZYACZOtLEJoPtMWxxwDzZEYYfT";
            ///////////////////////////////////////////////////////// initializing training item
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '' 'CLS_Cd' union SELECT [CLS_Cd] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] where [Per_Result] is null";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            Class_Cd.DataSource = dt4;
            Class_Cd.DisplayMember = "CLS_Cd";
        }

        private void Trainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        public void clear_frm()
        {
            CLS_Cap.Text = "";
            CLS_DTs.Text = "";
            CLS_From.Text = "";
            CLS_Reg.Text = "";
            CLS_Stat.Text = "";
            CLS_Rem.Text = "";
            CLS_To.Text = "";
            CLS_Trainer.Text = "";
            CRS_NM.Text = "";
            CLS_Loc.Text = "";
            grid.DataSource = null;
        }

        public void Search()
        {
            if (Class_Cd.SelectedIndex != 0)
            {
                DataTable search_dt = new DataTable();
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand();
                adp.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand = "SELECT sel1.[CLS_CD],sel1.[CLS_CAPACITY],isnull(sel2.qty,0) AS 'Reged',(sel1.[CLS_CAPACITY]-isnull(sel2.qty,0)) AS 'REM',sel1.[CLS_Location],sel1.[CLS_Course_Nm],sel1.[CLS_Trainer],sel1.[CLS_From_Time],sel1.[CLS_To_Time],sel1.[CLS_Date],sel1.[CLS_ACTV],sel1.[CLS_Course_Cd] from ( " +
                                  "(SELECT[CLS_CD],[CLS_CAPACITY],[CLS_Location],[CLS_Course_Nm],[CLS_Trainer],[CLS_From_Time],[CLS_To_Time],[CLS_Date],[CLS_ACTV],[CLS_Course_Cd] FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) sel1 " +
                                  "left join (SELECT CLS_CD, count([CLS_Cd]) AS QTY FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] group by[CLS_CD]) sel2 on sel1.[CLS_CD] = sel2.[CLS_CD]) where sel1.[CLS_CD] = '" + Class_Cd.Text + "'";
                adp.SelectCommand.CommandText = lcommand;
                search_dt.Clear();
                adp.Fill(search_dt);
                CLS_Cap.Text = search_dt.Rows[0][1].ToString();
                CLS_DTs.Text = search_dt.Rows[0][9].ToString();
                CLS_From.Text = search_dt.Rows[0][7].ToString().Substring(0, 5);
                CLS_Reg.Text = search_dt.Rows[0][2].ToString();
                CLS_Stat.Text = "فعال";
                CLS_Rem.Text = search_dt.Rows[0][3].ToString();
                CLS_To.Text = search_dt.Rows[0][8].ToString().Substring(0, 5);
                CLS_Trainer.Text = search_dt.Rows[0][6].ToString();
                CRS_NM.Text = search_dt.Rows[0][5].ToString();
                CLS_Loc.Text = search_dt.Rows[0][4].ToString();
                ////////////////////////////////////////////////////////////// Update Grid
                DataTable grid_updt = new DataTable();
                OleDbDataAdapter adp2 = new OleDbDataAdapter();
                adp2.SelectCommand = new OleDbCommand();
                adp2.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand2 = "SELECT ROW_NUMBER() OVER(ORDER BY [Doc_No] ASC) AS 'ردیف', [Doc_No] 'شماره پرونده',[Per_Nm] 'نام و نام خانوادگی' FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] where [CLS_CD] = '" + Class_Cd.Text + "' ";
                adp2.SelectCommand.CommandText = lcommand2;
                grid_updt.Clear();
                adp2.Fill(grid_updt);
                grid.DataSource = grid_updt;
                grid.BestFitColumns();
            }
            else
            {

            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (grid.Rows.Count != 0)
            {

                /////////////////////////////////////////////// make ds
                DataTable ds = new DataTable();
                List<string> conditions = new List<string>();
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand();
                adp.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY [CLS_CD] ASC) AS 'Row', [Doc_No],[Per_Nm] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] where [CLS_CD] = '" + Class_Cd.Text + "'";
                if (conditions.Count != 0)
                {
                    lcommand = lcommand + " WHERE " + string.Join(" AND ", conditions.ToArray());
                }
                adp.SelectCommand.CommandText = lcommand;
                ds.Clear();
                adp.Fill(ds);
                StiReport report = new StiReport();
                report.Load(Application.StartupPath + "\\Reports\\CLS_Present_Absent.mrt");
                report.RegData(ds);
                report.Dictionary.Variables.Add("CLS_CD", Class_Cd.Text);
                report.Dictionary.Variables.Add("CRS_NM", CRS_NM.Text);
                report.Dictionary.Variables.Add("CLS_Loc", CLS_Loc.Text);
                report.Dictionary.Variables.Add("Trainer", CLS_Trainer.Text);
                report.Dictionary.Variables.Add("From", CLS_From.Text);
                report.Dictionary.Variables.Add("To", CLS_To.Text);
                report.Dictionary.Variables.Add("Status", CLS_Stat.Text);
                report.Dictionary.Variables.Add("CLS_DT", CLS_DTs.Text);
                Stimulsoft.Report.Print.StiPrintProvider.SetPaperSource = false;
                report.Render();
                report.Show();
            }
            else
            {
                RadMessageBox.Show(this, "اطلاعاتی جهت چاپ وجود ندارد", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }
}
