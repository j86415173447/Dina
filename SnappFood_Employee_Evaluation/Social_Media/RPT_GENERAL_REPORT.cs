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

namespace SnappFood_Employee_Evaluation.Social_Media
{
    public partial class RPT_GENERAL_REPORT : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt22 = new DataTable();


        public RPT_GENERAL_REPORT()
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
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            List<string> conditions = new List<string>();
           
            if (from_dt.Text != "")
            {
                conditions.Add("[TKT_Insrt_DT_Per] >= N'" + from_dt.Text + "'");
            }
            else
            {
                RadMessageBox.Show(this, "  تاریخ نمی تواند خالی باشد. " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                return;
            }
            if (to_dt.Text != "")
            {
                conditions.Add("[TKT_Insrt_DT_Per] <= N'" + to_dt.Text + "'");
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
            string lcommand = "Select Sel0.*,Sel1.[Count] 'تعداد سابقه',Sel2.[History_Tone] 'اولین لحن مشتری',Sel3.[History_Tone] 'آخرین لحن مشتری' from ( " +
                              "(SELECT [TKT_ID],[Year] 'سال ایجاد',[Month] 'ماه ایجاد',[Social_Media] 'شبکه ی اجتماعی',[Channel] 'کانال',[TKT_Type] 'نوع تیکت',[Social_User_Nm] 'نام کاربر',[Social_Insrt_Dt] 'تاریخ درج کاربر',[Social_Insrt_Tm] 'ساعت درج کاربر',[TKT_Dep] 'دپارتمان',[Order_No] 'شماره سفارش',[TKT_Link] 'لینک یا عنوان',[TKT_RSN] 'موضوع' " +
                              ",[TKT_RSN_Sub1] 'زیر گروه 1',[TKT_RSN_Sub2] 'زیر گروه 2',[TKT_Status] 'وضعیت تیکت',[TKT_Insrt_DT_Per] 'تاریخ ثبت تیکت',[TKT_Insrt_TM] 'ساعت ثبت تیکت',[TKT_Insrt_usr] 'کارشناس ثبت کننده',[TKT_Update_DT_Per] 'تاریخ آخرین ویرایش',[TKT_Update_TM] 'ساعت آخرین ویرایش' ,[TKT_Update_usr] 'کارشناس آخرین ویرایش' " +
                              ",[TKT_Closed] 'تیکت بسته؟',[TKT_Close_DT_Per] 'تاریخ بسته شدن',[TKT_Close_TM] 'ساعت بسته شدن',[TKT_Close_usr] 'کارشناس بستن' FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKETING]) Sel0 " +
                              "left join (SELECT [Ticket_id],MIN([History_id]) 'Min_Key',Max([History_id]) 'Max_Key',COUNT([History_id]) 'Count' FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_HISTORY] where [History_Type] = N'کاربر' group by [Ticket_id]) Sel1 on Sel0.[TKT_ID] = Sel1.[Ticket_id] " +
                              "left join (SELECT [Ticket_id],[History_id],[History_Tone] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_HISTORY]) Sel2 on Sel1.[Min_Key] = Sel2.[History_id] " +
                              "left join (SELECT [Ticket_id],[History_id],[History_Tone] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_HISTORY]) Sel3 on Sel1.[Max_Key] = Sel3.[History_id] ) where Sel0.[تاریخ ثبت تیکت] >= '" + from_dt.Text + "' AND Sel0.[تاریخ ثبت تیکت] <= '" + to_dt.Text + "'";
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
