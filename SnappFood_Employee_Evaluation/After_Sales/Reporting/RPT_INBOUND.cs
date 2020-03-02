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
    public partial class RPT_INBOUND : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt22 = new DataTable();


        public RPT_INBOUND()
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
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHl2AD0gPVknKsaW0un+3PuM6TTcPMUAWEURKXNso0e5OFPaZYasFtsxNoDemsFOXbvf7SIcnyAkFX/4u37NTfx7g+0IqLXw6QIPolr1PvCSZz8Z5wjBNakeCVozGGOiuCOQDy60XNqfbgrOjxgQ5y/u54K4g7R/xuWmpdx5OMAbUbcy3WbhPCbJJYTI5Hg8C/gsbHSnC2EeOCuyA9ImrNyjsUHkLEh9y4WoRw7lRIc1x+dli8jSJxt9C+NYVUIqK7MEeCmmVyFEGN8mNnqZp4vTe98kxAr4dWSmhcQahHGuFBhKQLlVOdlJ/OT+WPX1zS2UmnkTrxun+FWpCC5bLDlwhlslxtyaN9pV3sRLO6KXM88ZkefRrH21DdR+4j79HA7VLTAsebI79t9nMgmXJ5hB1JKcJMUAgWpxT7C7JUGcWCPIG10NuCd9XQ7H4ykQ4Ve6J2LuNo9SbvP6jPwdfQJB6fJBnKg4mtNuLMlQ4pnXDc+wJmqgw25NfHpFmrZYACZOtLEJoPtMWxxwDzZEYYfT";
            ////////////////////////////////////////////////////////////////////////// Initiate origin Combo
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT '1' 'row','' 'item' union select '2' 'row', N'راننده' 'item' union select '3' 'row', N'ماهکس' 'item' union select '4' 'row', N'پست' 'item' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] order by [row] asc";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            Origin.DataSource = dtsc4;
            Origin.DisplayMember = "item";
            ///////////////////////////////////////////////////////// initializing Rec Combo
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT '' 'Main_Shift' union SELECT N'شد' 'Main_Shift' union SELECT N'نشد' 'Main_Shift' ";
            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            Rec_combo.DataSource = dt2;
            Rec_combo.DisplayMember = "Main_Shift";
            ////////////////////////////////////////////////////////////////////////// Initiate Service Center
            DataTable dtsc44 = new DataTable();
            OleDbDataAdapter adpsc44 = new OleDbDataAdapter();
            adpsc44.SelectCommand = new OleDbCommand();
            adpsc44.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc44 = "SELECT '' 'Center' union SELECT DISTINCT [Center] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_AGENT_ROLE]";
            adpsc44.SelectCommand.CommandText = lcommandsc44;
            adpsc44.Fill(dtsc44);
            Center.DataSource = dtsc44;
            Center.DisplayMember = "Center";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            List<string> conditions = new List<string>();
            if (Origin.SelectedIndex != 0)
            {
                conditions.Add("[Origin] = N'" + Origin.Text + "'");
            }
            if (Center.SelectedIndex != 0)
            {
                conditions.Add("[Center] = N'" + Center.Text + "'");
            }
            if (driver_dc.Text != "")
            {
                conditions.Add("[Origin_NM] = N'" + driver_dc.Text + "'");
            }
            if (from_dt.Text != "")
            {
                conditions.Add("[In_DT_Per] >= N'" + from_dt.Text + "'");
            }
            if (to_dt.Text != "")
            {
                conditions.Add("[In_DT_Per] <= N'" + to_dt.Text + "'");
            }
            if (Rec_combo.Text == "شد")
            {
                conditions.Add("[rec] = 1");
            }
            if (Rec_combo.Text == "نشد")
            {
                conditions.Add("[rec] = 0");
            }
            if (post_id.Text != "")
            {
                conditions.Add("[Origin_NM] = N'" + post_id.Text + "'");
            }
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT [Batch_No] 'شناسه دریافت', [Center] 'مرکز خدمات' ,[Item_SN] 'سریال کالا',[In_DT_Per] 'تاریخ دریافت شمسی',[In_DT] 'تاریخ دریافت میلادی',[In_TM] 'ساعت دریافت',[Position] 'جایگاه',[Nature] 'ماهیت',[Origin] 'مبدا',[Origin_NM] 'شرح مبدا',[Assigned_Rec] 'تخصیص به',[REC] 'وضعیت پذیرش',[Insrt_Usr] 'کاربر ثبت کننده' FROM [SNAPP_CC_EVALUATION].[dbo].[AS_INBOUND] ";
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
            if (Origin.SelectedIndex == 1 || Origin.SelectedIndex == 2)
            {
                driver_dc.Visible = true;
                driver_dc_lbl.Visible = true;
                if (Origin.SelectedIndex == 1)
                {
                    driver_dc_lbl.Text = "نام راننده:";
                    DataTable dtsc4 = new DataTable();
                    OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
                    adpsc4.SelectCommand = new OleDbCommand();
                    adpsc4.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommandsc4 = "SELECT '' 'AS_AGENT_NM' union SELECT [AS_AGENT_NM] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_AGENT_ROLE] where [AS_Role_NM] = N'مامور جمع آوری'";
                    adpsc4.SelectCommand.CommandText = lcommandsc4;
                    adpsc4.Fill(dtsc4);
                    driver_dc.DataSource = dtsc4;
                    driver_dc.DisplayMember = "AS_AGENT_NM";
                }
                else if (Origin.SelectedIndex == 2)
                {
                    driver_dc_lbl.Text = "نام شعبه:";
                    DataTable dtsc4 = new DataTable();
                    OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
                    adpsc4.SelectCommand = new OleDbCommand();
                    adpsc4.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommandsc4 = "SELECT '' 'AS_AGENT_NM' union SELECT [AS_AGENT_NM] FROM [SNAPP_CC_EVALUATION].[dbo].[AS_AGENT_ROLE] where [AS_Role_NM] = N'شعبه'";
                    adpsc4.SelectCommand.CommandText = lcommandsc4;
                    adpsc4.Fill(dtsc4);
                    driver_dc.DataSource = dtsc4;
                    driver_dc.DisplayMember = "AS_AGENT_NM";
                }
            }
            else
            {
                //DataTable dtsc4 = new DataTable();
                driver_dc.DataSource = null;
                driver_dc.Visible = false;
                driver_dc_lbl.Visible = false;
            }
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

        private void driver_dc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt22.Clear();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
