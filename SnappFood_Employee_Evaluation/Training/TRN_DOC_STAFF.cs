using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using System.Data.OleDb;

namespace SnappFood_Employee_Evaluation.Training
{
    public partial class TRN_DOC_STAFF : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string Doc_Cd;
        public string doc_number ="";

        public TRN_DOC_STAFF()
        {
            InitializeComponent();
            Per_Dep.TextAlignment = ContentAlignment.MiddleLeft;
            Main_Shift.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Fa_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Grade_Point.TextAlignment = ContentAlignment.MiddleLeft;
            total_hour.TextAlignment = ContentAlignment.MiddleLeft;
        }

        private void TRN_DOC_STAFF_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            if (doc_number != "")
            {
                Search.Visibility = ElementVisibility.Collapsed;
                searching();
            }
        }

        public void searching()
        {
            Clear_Frm();
            /////////////////////////////// Update first tab
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1;
            if (doc_number != "")
            {
                lcommand1 = "SELECT [Doc_No],[System_Id],[Chargoon_Id],[Per_National_Cd],[Department],[Main_Shift]" +
                               ",[Per_Name],[Per_Fa_Name],[Per_Nk_Name],[Per_Tel],[Per_Mob],[Per_Add],[Per_Pic]" +
                               ",[History],[Employment_Dt],[Birth_Dt],[Email],[Degree],[Major],[Major_Status]" +
                               ",[Mentor],[sex],[Insert_User] FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [doc_no] = '" + doc_number + "'";
            }
            else
            {
                lcommand1 = "SELECT [Doc_No],[System_Id],[Chargoon_Id],[Per_National_Cd],[Department],[Main_Shift]" +
                               ",[Per_Name],[Per_Fa_Name],[Per_Nk_Name],[Per_Tel],[Per_Mob],[Per_Add],[Per_Pic]" +
                               ",[History],[Employment_Dt],[Birth_Dt],[Email],[Degree],[Major],[Major_Status]" +
                               ",[Mentor],[sex],[Insert_User] FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [doc_no] = '" + Doc_Cd + "'";
            }
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            Per_Dep.Text = dt1.Rows[0][4].ToString();
            Main_Shift.Text = dt1.Rows[0][5].ToString();
            Per_Name.Text = dt1.Rows[0][6].ToString();
            Per_Fa_Name.Text = dt1.Rows[0][7].ToString();
            if (dt1.Rows[0][12].ToString().Length != 0)
            {
                byte[] imageData = (byte[])dt1.Rows[0][12];
                Image newImage;
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);
                    newImage = Image.FromStream(ms, true);
                }
                Per_Pic.Image = newImage;
            }
            else
            {
                Per_Pic.Image = null;
            }
            //////////////////////////////////////////// Get Score Total
            string Score_Total;
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4;
            if (doc_number != "")
            {
                lcommandsc4 = "SELECT [Doc_No],sum([Sc_Score]) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '" + doc_number + "' group by [Doc_No]";
            }
            else
            {
                lcommandsc4 = "SELECT [Doc_No],sum([Sc_Score]) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '" + Doc_Cd + "' group by [Doc_No]";
            }
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);

            if (dtsc4.Rows.Count != 0)
            {
                Score_Total = dtsc4.Rows[0][1].ToString();
            }
            else
            {
                Score_Total = "0";
            }
            //////////////////////////////////////////////// Fill Job Leveling
            DataTable dtsc333 = new DataTable();
            OleDbDataAdapter adpsc333 = new OleDbDataAdapter();
            adpsc333.SelectCommand = new OleDbCommand();
            adpsc333.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc333 = "SELECT [Job_Score],[Job_Grade],[Job_Level],[Job_Department],[Job_Salary_Base] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_JOB_LEVELING] where [Job_Department] = N'" + Per_Dep.Text + "' AND [Job_score] = '" + Score_Total + "'";
            adpsc333.SelectCommand.CommandText = lcommandsc333;
            adpsc333.Fill(dtsc333);
            Grade_Point.Text = Score_Total + " / " + dtsc333.Rows[0][1].ToString() + " / " + dtsc333.Rows[0][2].ToString();
            total_hour.Text = string.Format("{0:#,##0}", int.Parse(dtsc333.Rows[0][4].ToString())) + " ریال";

            ///////////////////////////////////////////////////////////////////// Update Grid
            DataTable dtsc55 = new DataTable();
            OleDbDataAdapter adpsc55 = new OleDbDataAdapter();
            adpsc55.SelectCommand = new OleDbCommand();
            adpsc55.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc55;
            if (doc_number != "")
            {
                lcommandsc55 = "SELECT sel1.CLS_Cd 'کد کلاس', sel2.CLS_Course_Nm 'نام دوره',Sel2.CLS_Trainer 'مدرس', Sel3.[CRS_Type] 'نوع دوره', Sel2.[Period] 'مدت دوره', iif(Sel2.[CLS_ACTV] = 1, N'درحال برگزاری', N'اتمام دوره') 'وضعیت کلاس' " +
                                  " ,iif(Sel1.[Per_Score] is NULL, N'گزارش نشده', Sel1.[Per_Score]) 'نمره',iif(Sel1.[Per_Result] = 1, N'قبول', iif(Sel1.[Per_Result] = 0, N'مردود', N'گزارش نشده')) 'نتیجه ارزیابی' " +
                                  " ,iif(Sel1.[Per_Result] = 1, Convert(nvarchar(255), Sel2.[CLS_Period] * 5), '-') 'امتیاز شغلی' from( " +
                                  " (SELECT[Doc_No],[CLS_Cd],[CRS_CD],[Per_Result],[Per_Score] FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION]) Sel1 " +
                                  " left join(SELECT[CLS_CD],[CLS_Course_Nm],[CLS_Trainer],[CLS_Period], CONVERT(nvarchar(255),[CLS_Period]) + N' ساعت' AS Period,[CLS_Date],[CLS_ACTV] FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) Sel2 " +
                                  " on sel1.CLS_Cd = Sel2.CLS_CD left join (SELECT [CRS_CD],[CRS_Type] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_COURSE_MASTER]) Sel3 on Sel1.[CRS_CD] = Sel3.[CRS_CD]) where Sel1.[Doc_No] = '" + doc_number + "' order by Sel1.[CLS_Cd] asc";
            }
            else
            {
                lcommandsc55 = "SELECT sel1.CLS_Cd 'کد کلاس', sel2.CLS_Course_Nm 'نام دوره',Sel2.CLS_Trainer 'مدرس', Sel3.[CRS_Type] 'نوع دوره', Sel2.[Period] 'مدت دوره', iif(Sel2.[CLS_ACTV] = 1, N'درحال برگزاری', N'اتمام دوره') 'وضعیت کلاس' " +
                                 " ,iif(Sel1.[Per_Score] is NULL, N'گزارش نشده', Sel1.[Per_Score]) 'نمره',iif(Sel1.[Per_Result] = 1, N'قبول', iif(Sel1.[Per_Result] = 0, N'مردود', N'گزارش نشده')) 'نتیجه ارزیابی' " +
                                 " ,iif(Sel1.[Per_Result] = 1, Convert(nvarchar(255), Sel2.[CLS_Period] * 5), '-') 'امتیاز شغلی' from( " +
                                 " (SELECT[Doc_No],[CLS_Cd],[CRS_CD],[Per_Result],[Per_Score] FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION]) Sel1 " +
                                 " left join(SELECT[CLS_CD],[CLS_Course_Nm],[CLS_Trainer],[CLS_Period], CONVERT(nvarchar(255),[CLS_Period]) + N' ساعت' AS Period,[CLS_Date],[CLS_ACTV] FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) Sel2 " +
                                 " on sel1.CLS_Cd = Sel2.CLS_CD left join (SELECT [CRS_CD],[CRS_Type] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_COURSE_MASTER]) Sel3 on Sel1.[CRS_CD] = Sel3.[CRS_CD]) where Sel1.[Doc_No] = '" + Doc_Cd + "' order by Sel1.[CLS_Cd] asc";
            }
            adpsc55.SelectCommand.CommandText = lcommandsc55;
            dtsc55.Clear();
            adpsc55.Fill(dtsc55);
            grid.DataSource = dtsc55;
            grid.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            grid.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
            grid.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            grid.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
            grid.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
            grid.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
            grid.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
            grid.Columns[7].TextAlignment = ContentAlignment.MiddleCenter;
            grid.BestFitColumns();

            //////////////////////////////////////////// Get Score Total
            string Score_Total2;
            DataTable dtsc42 = new DataTable();
            OleDbDataAdapter adpsc42 = new OleDbDataAdapter();
            adpsc42.SelectCommand = new OleDbCommand();
            adpsc42.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc42;
            if (doc_number != "")
            {
                lcommandsc42 = "SELECT Sel1.[Doc_No] , sum(convert(int,Sel2.[CLS_Period])) FROM ((SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION]) Sel1 left join (SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) Sel2" +
                                  " on sel1.[CLS_CD] = Sel2.[CLS_CD]) where Sel1.[Doc_No] = '" + doc_number + "' and sel1.[Per_Result] = 1 group by Sel1.[Doc_No]";
            }
            else
            {
                lcommandsc42 = "SELECT Sel1.[Doc_No] , sum(convert(int,Sel2.[CLS_Period])) FROM ((SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION]) Sel1 left join (SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) Sel2" +
                                  " on sel1.[CLS_CD] = Sel2.[CLS_CD]) where Sel1.[Doc_No] = '" + Doc_Cd + "' and sel1.[Per_Result] = 1 group by Sel1.[Doc_No]";
            }
            adpsc4.SelectCommand.CommandText = lcommandsc42;
            adpsc4.Fill(dtsc42);

            if (dtsc42.Rows.Count != 0)
            {
                Score_Total2 = dtsc42.Rows[0][1].ToString();
            }
            else
            {
                Score_Total2 = "0";
            }
            total_hour.Text = Score_Total2 + " ساعت "; 

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Clear_Frm()
        {
            Per_Dep.Text = ""; //4].ToString();
            Main_Shift.Text = ""; //5].ToString();
            Per_Name.Text = ""; //6].ToString();
            Per_Fa_Name.Text = ""; //7].ToString();
            Per_Pic.Image = null;
            Grade_Point.Text = "";
            total_hour.Text = "";
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Training.Search_Staff_TRN_Doc ob = new Training.Search_Staff_TRN_Doc(this);
            ob.constr = constr;
            ob.ShowDialog();
        }
    }
}
