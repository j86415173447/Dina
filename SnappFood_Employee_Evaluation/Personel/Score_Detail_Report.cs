using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using System.IO;

namespace SnappFood_Employee_Evaluation.Personel
{
    public partial class Score_Detail_Report : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string Doc_Cd;
        public string doc_number;
        
        public Score_Detail_Report()
        {
            InitializeComponent();
            Per_Dep.TextAlignment = ContentAlignment.MiddleLeft;
            Main_Shift.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Per_Fa_Name.TextAlignment = ContentAlignment.MiddleLeft;
            Grade_Point.TextAlignment = ContentAlignment.MiddleLeft;
            Salary.TextAlignment = ContentAlignment.MiddleLeft;
        }

        private void Points_Detail_Report_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            if (doc_number != "")
            {
                Search.Visibility = ElementVisibility.Collapsed;
                searching();
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            Personel.Search_Staff_Points ob = new Personel.Search_Staff_Points(this);
            ob.constr = constr;
            ob.ShowDialog();
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
            Salary.Text = string.Format("{0:#,##0}", int.Parse(dtsc333.Rows[0][4].ToString())) + " ریال";

            ///////////////////////////////////////////////////////////////////// Update Grid
            DataTable dtsc55 = new DataTable();
            OleDbDataAdapter adpsc55 = new OleDbDataAdapter();
            adpsc55.SelectCommand = new OleDbCommand();
            adpsc55.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc55;
            if (doc_number != "")
            {
                lcommandsc55 = "SELECT [Sc_Item_Sub_Cd]'کد زیرگروه',[Sc_Item_Nm]'عنوان امتیاز',[Sc_Eff_DT] 'تاریخ موثر',[Sc_Description]'توضیحات',[Sc_Score]'مقدار امتیاز' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '" + doc_number + "' order by [Sc_Eff_DT],[Sc_Item_Sub_Cd] asc";
            }
            else
            {
                lcommandsc55 = "SELECT [Sc_Item_Sub_Cd]'کد زیرگروه',[Sc_Item_Nm]'عنوان امتیاز',[Sc_Eff_DT] 'تاریخ موثر',[Sc_Description]'توضیحات',[Sc_Score]'مقدار امتیاز' FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] where [Doc_No] = '" + Doc_Cd + "' order by [Sc_Eff_DT],[Sc_Item_Sub_Cd] asc";
            }
            adpsc55.SelectCommand.CommandText = lcommandsc55;
            dtsc55.Clear();
            adpsc55.Fill(dtsc55);
            grid.DataSource = dtsc55;
            grid.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            grid.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
            grid.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            grid.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
            grid.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
            grid.BestFitColumns();
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
            Salary.Text = "";
        }
    }
}
