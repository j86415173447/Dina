using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace SnappFood_Employee_Evaluation.Training
{
    public partial class TRN_CLS_EXAM_REPORT : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataTable dt22 = new DataTable();

        public TRN_CLS_EXAM_REPORT()
        {
            InitializeComponent();
            this.grid.MasterTemplate.EnableGrouping = true;
            this.grid.MasterTemplate.AllowDragToGroup = false;
            this.grid.MasterTemplate.AutoExpandGroups = true;
            this.grid.ShowGroupPanel = false;
            GroupDescriptor descriptor1 = new GroupDescriptor();
            descriptor1.GroupNames.Add("تاریخ آزمون", ListSortDirection.Ascending);
            GroupDescriptor descriptor2 = new GroupDescriptor();
            descriptor2.GroupNames.Add("ساعت آزمون", ListSortDirection.Descending);
            this.grid.GroupDescriptors.Add(descriptor1);
            this.grid.GroupDescriptors.Add(descriptor2);
        }

        private void TRN_CLS_EXAM_REPORT_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;

            ///////////////////////////////////////////////////////// initializing exm dates
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '' 'CLS_Exam_DT' union SELECT distinct [CLS_Exam_DT] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES] where [CLS_ACTV] = 1";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            EXM_DT_CMBO.DataSource = dt4;
            EXM_DT_CMBO.DisplayMember = "CLS_Exam_DT";
        }

        private void EXM_DT_CMBO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EXM_DT_CMBO.SelectedIndex != 0)
            {
                ///////////////////////////////////////////////////////// initializing exm dates
                DataTable dt4 = new DataTable();
                OleDbDataAdapter adp4 = new OleDbDataAdapter();
                adp4.SelectCommand = new OleDbCommand();
                adp4.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand4 = "SELECT '' 'CLS_Exam_TM' union SELECT distinct [CLS_Exam_TM] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES] where [CLS_ACTV] = 1";
                adp4.SelectCommand.CommandText = lcommand4;
                adp4.Fill(dt4);
                EXM_TM_CMBO.DataSource = dt4;
                EXM_TM_CMBO.DisplayMember = "CLS_Exam_TM";
            }
            else
            {
                EXM_TM_CMBO.DataSource = null;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            dt22.Clear();
            List<string> conditions = new List<string>();
            if (EXM_DT_CMBO.SelectedIndex != 0)
            {
                conditions.Add("Sel2.[CLS_Exam_DT] = N'" + EXM_DT_CMBO.Text + "'");
            }
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT Sel2.[CLS_Exam_DT] 'تاریخ آزمون',Sel2.[CLS_Exam_TM] 'ساعت آزمون',Sel1.[CLS_Cd] 'کد کلاس',COUNT(Sel1.[Doc_No]) 'تعداد شرکت کنندگان' from ( " +
                              "(SELECT[CLS_Cd],[CRS_CD],[Doc_No] FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION]) Sel1 left join " +
                              "(SELECT[CLS_CD],[CLS_Exam_DT],[CLS_Exam_TM],[CLS_ACTV] FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) Sel2 " +
                              "on Sel1.[CLS_Cd] = Sel2.[CLS_CD]) ";
            if (conditions.Count != 0)
            {
                lcommand = lcommand + " WHERE Sel2.[CLS_ACTV] = 1 AND " + string.Join(" AND ", conditions.ToArray());
            }
            else
            {
                lcommand = lcommand + " WHERE Sel2.[CLS_ACTV] = 1 ";
            }
            lcommand = lcommand + " GROUP BY Sel2.[CLS_Exam_DT],Sel2.[CLS_Exam_TM],Sel1.[CLS_Cd]";
            adp.SelectCommand.CommandText = lcommand;
            adp.Fill(dt22);
            grid.DataSource = dt22;
            grid.Columns[1].TextAlignment = ContentAlignment.MiddleRight;
            

            grid.BestFitColumns();
        }

        private void grid_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            var groupContentCellElement = sender as GridGroupContentCellElement;
            if (groupContentCellElement != null)
            {
                groupContentCellElement.DrawFill = true;
                groupContentCellElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                if (groupContentCellElement.Text.Contains("تاریخ آزمون") == true)
                {
                    groupContentCellElement.BackColor = Color.LightPink;
                    groupContentCellElement.Font = new Font("Tahoma", groupContentCellElement.Font.Size,FontStyle.Bold);
                }
                else
                {
                    groupContentCellElement.BackColor = Color.LightYellow;
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
