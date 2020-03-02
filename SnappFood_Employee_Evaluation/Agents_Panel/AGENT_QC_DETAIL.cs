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
using System.Globalization;
using System.Threading;

namespace SnappFood_Employee_Evaluation.Agents_Panel
{
    public partial class AGENT_QC_DETAIL : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string Doc_Cd;
        public string doc_number;
        public bool load = true;
        
        public AGENT_QC_DETAIL()
        {
            InitializeComponent();
            lbl_1.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_0.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_1.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_2.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_3.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_4.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_5.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_6.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_7.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_8.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_9.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_10.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_11.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_12.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_13.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_14.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_15.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_16.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_17.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_18.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_19.TextAlignment = ContentAlignment.MiddleLeft;
            avg_score.TextAlignment = ContentAlignment.MiddleLeft;
            pending.TextAlignment = ContentAlignment.MiddleLeft;
            suc_perc.TextAlignment = ContentAlignment.MiddleLeft;

        }

        private void Points_Detail_Report_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;

            ///////////////////////////////// Get pending cases
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2;
            lcommand2 = "SELECT Sel1.* from ( " +
                        " (SELECT [Agent_Ext] 'Extension', count([QC_ID]) 'Total Logs' FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where [Final_Approval] is null group by [Agent_Ext]) Sel1 " +
                        " left join (SELECT [Doc_no],[System_Id] FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel2 on Sel1.[Extension] = Sel2.[System_Id]) WHERE Sel2.[Doc_no] = '" + doc_number + "'";
            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            if (dt2.Rows.Count == 0)
            {
                pending.Text = "0";
            }
            else
            {
                pending.Text = dt2.Rows[0][1].ToString();
            }

            /////////////////////////////////////// Get Date
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT day(GETDATE()), month(GETDATE()), year(GETDATE()),[Per_Name],[Department],[Main_Shift],[System_Id] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [doc_no] = '" + doc_number + "'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            DateTime datetime = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
            ///////////////////////////////////////// Convert Persian
            PersianCalendar psdate = new PersianCalendar();
            //DT_Day.Text = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            mnth.SelectedIndex = psdate.GetMonth(datetime) - 1;
            //DT_Yr.Text = psdate.GetYear(datetime).ToString();
            yr.Items.Add((psdate.GetYear(datetime) - 1).ToString());
            yr.Items.Add((psdate.GetYear(datetime)).ToString());
            yr.SelectedIndex = 1;
            ////////////////////////////////////////////////////////////////// Update Header
            load = false;
            lbl_0.Text = dt1.Rows[0][3].ToString();
            lbl_1.Text = dt1.Rows[0][4].ToString();
            lbl_2.Text = dt1.Rows[0][5].ToString();
            lbl_3.Text = dt1.Rows[0][6].ToString();

            
        }

        public void searching()
        {
            if (yr.Text != "" && mnth.Text != "")
            {
                /////////////////////////////// Update first tab
                DataTable dt1 = new DataTable();
                OleDbDataAdapter adp1 = new OleDbDataAdapter();
                adp1.SelectCommand = new OleDbCommand();
                adp1.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand1;
                lcommand1 = "SELECT Sel2.[Per_Name] 'Agent Name', Sel2.[Department] 'Department',Sel2.[Main_Shift] 'Shift', Sel1.* from ( " +
                                  " (SELECT[Agent_Ext] 'Extension', count([QC_ID]) 'Total Logs' , SUM(CASE WHEN[QC_Score] <= 19 then 1 else 0 end) 'Failed Logs' , count([QC_ID]) - SUM(CASE WHEN[QC_Score] <= 19 then 1 else 0 end) 'OK Logs' , SUM(CASE WHEN[taboo] = 1 then 1 else 0 end) 'Taboo Count' , SUM(CASE WHEN[QC_Param_1] = 0 then 1 else 0 end) 'Greeting' " +
                                  " ,SUM(CASE WHEN[QC_Param_2] = 0 then 1 else 0 end) 'Opening Sen/Que' , SUM(CASE WHEN[QC_Param_3] = 0 then 1 else 0 end) 'Active Listening' , SUM(CASE WHEN[QC_Param_4] = 0 then 1 else 0 end) 'Call Holding' " +
                                  " ,SUM(CASE WHEN[QC_Param_5] = 0 then 1 else 0 end) 'Interruption' , SUM(CASE WHEN[QC_Param_6] = 0 then 1 else 0 end) 'Summarizing' , SUM(CASE WHEN[QC_Param_7] = 0 then 1 else 0 end) 'Speaking Type' " +
                                  " ,SUM(CASE WHEN[QC_Param_8] = 0 then 1 else 0 end) 'Speaking Tone' , SUM(CASE WHEN[QC_Param_9] = 0 then 1 else 0 end) 'Guide/Result' , SUM(CASE WHEN[QC_Param_10] = 0 then 1 else 0 end) 'Query' " +
                                  " ,SUM(CASE WHEN[QC_Param_11] = 0 then 1 else 0 end) 'Appreciation' , SUM(CASE WHEN[QC_Param_12] = 0 then 1 else 0 end) 'Bye' " +
                                  " ,convert(DECIMAL(10,2),avg(convert(float,[qc_score]))) 'AVG' , SUM(CASE WHEN[Bad_Followup] = 1 then 1 else 0 end) 'Bad_Followup' " +
                                  " FROM[SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where [Final_Approval] is not null  AND [final_aprv_dt] >= N'" + yr.Text + "/" + (((mnth.SelectedIndex + 1) >= 10) ? ((mnth.SelectedIndex - 1)).ToString() : "0" + (mnth.SelectedIndex + 1).ToString()) + "/01'" + " AND [final_aprv_dt] <= N'" + yr.Text + "/" + (((mnth.SelectedIndex + 1) >= 10) ? ((mnth.SelectedIndex + 1)).ToString() : "0" + (mnth.SelectedIndex + 1).ToString()) + "/31'" + " group by [Agent_Ext]) Sel1 " +
                                  " left join(SELECT [Doc_no],[System_Id],[Department],[Main_Shift],[Per_Name] FROM[SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]) Sel2 on Sel1.[Extension] = Sel2.[System_Id]) WHERE Sel2.[Doc_no] = '" + doc_number + "'";
                adp1.SelectCommand.CommandText = lcommand1;
                adp1.Fill(dt1);
                if (dt1.Rows.Count == 1)
                {
                    //lbl_0.Text = dt1.Rows[0][0].ToString();
                    //lbl_1.Text = dt1.Rows[0][1].ToString();
                    //lbl_2.Text = dt1.Rows[0][2].ToString();
                    //lbl_3.Text = dt1.Rows[0][3].ToString();
                    lbl_4.Text = dt1.Rows[0][4].ToString();
                    lbl_5.Text = dt1.Rows[0][5].ToString();
                    lbl_6.Text = dt1.Rows[0][6].ToString();
                    lbl_7.Text = dt1.Rows[0][7].ToString();
                    lbl_8.Text = dt1.Rows[0][8].ToString();
                    lbl_9.Text = dt1.Rows[0][9].ToString();
                    lbl_10.Text = dt1.Rows[0][10].ToString();
                    lbl_11.Text = dt1.Rows[0][11].ToString();
                    lbl_12.Text = dt1.Rows[0][12].ToString();
                    lbl_13.Text = dt1.Rows[0][13].ToString();
                    lbl_14.Text = dt1.Rows[0][14].ToString();
                    lbl_15.Text = dt1.Rows[0][15].ToString();
                    lbl_16.Text = dt1.Rows[0][16].ToString();
                    lbl_17.Text = dt1.Rows[0][17].ToString();
                    lbl_18.Text = dt1.Rows[0][18].ToString();
                    lbl_19.Text = dt1.Rows[0][19].ToString();
                    avg_score.Text = dt1.Rows[0][20].ToString();
                    //bad_fl.Text = dt1.Rows[0][21].ToString();

                    if (lbl_6.Text != "" && lbl_6.Text != "0" && lbl_4.Text != "" && lbl_4.Text != "0")
                    suc_perc.Text = Math.Round(((double.Parse(lbl_6.Text) / (double.Parse(lbl_4.Text) + double.Parse(pending.Text)))*100),2).ToString() + "%";

                    if (avg_score.Text != "")
                    {
                        double avgscr = double.Parse(avg_score.Text);
                        if (avgscr <= 19)
                        {
                            avg_score.ForeColor = Color.Red;
                        }
                        else if (avgscr > 19 && avgscr < 23)
                        {
                            avg_score.ForeColor = Color.Orange;
                        }
                        else
                        {
                            avg_score.ForeColor = Color.Green;
                        }
                        avg_score.Text = avg_score.Text + " از 25";
                    }
                
                }
                else
                {
                    //lbl_0.Text = "0";
                    //lbl_1.Text = "0";
                    //lbl_2.Text = "0";
                    //lbl_3.Text = "0";
                    lbl_4.Text = "0";
                    lbl_5.Text = "0";
                    lbl_6.Text = "0";
                    lbl_7.Text = "0";
                    lbl_8.Text = "0";
                    lbl_9.Text = "0";
                    lbl_10.Text = "0";
                    lbl_11.Text = "0";
                    lbl_12.Text = "0";
                    lbl_13.Text = "0";
                    lbl_14.Text = "0";
                    lbl_15.Text = "0";
                    lbl_16.Text = "0";
                    lbl_17.Text = "0";
                    lbl_18.Text = "0";
                    lbl_19.Text = "0";
                    avg_score.Text = "0";
                    //bad_fl.Text = "0";
                }
            }
            else
            {
                //lbl_0.Text = "0";
                //lbl_1.Text = "0";
                //lbl_2.Text = "0";
                //lbl_3.Text = "0";
                lbl_4.Text = "";
                lbl_5.Text = "";
                lbl_6.Text = "";
                lbl_7.Text = "";
                lbl_8.Text = "";
                lbl_9.Text = "";
                lbl_10.Text = "";
                lbl_11.Text = "";
                lbl_12.Text = "";
                lbl_13.Text = "";
                lbl_14.Text = "";
                lbl_15.Text = "";
                lbl_16.Text = "";
                lbl_17.Text = "";
                lbl_18.Text = "";
                lbl_19.Text = "";
                avg_score.Text = "0";
                //bad_fl.Text = "0";
            }

            foreach (Control control in this.Controls)
            {
                if (control.Name == "radGroupBox3")
                {
                    Change_shape(control);
                    foreach (Control Child1 in control.Controls)
                    {
                        Change_shape(Child1);
                        foreach (Control Child2 in Child1.Controls)
                        {
                            Change_shape(Child2);
                            foreach (Control Child3 in Child2.Controls)
                            {
                                Change_shape(Child3);
                            }
                        }
                    }
                }
            }
        }

        public void Change_shape (Control control)
        {
            if (control.Name.ToString().Contains("lbl"))
            {
                if (control.Text == "0")
                {
                    control.ForeColor = Color.DarkGreen;
                }
                else
                {
                    control.ForeColor = Color.Red;
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnth_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox1.Refresh();
            pictureBox1.Update();
            if (!load)
            {
                Thread.Sleep(2000);
            }
            searching();
            pictureBox1.Visible = false;
        }

        private void lbl_7_TextChanged(object sender, EventArgs e)
        {
            if (lbl_7.Text.Length != 0)
            {
                if (int.Parse(lbl_7.Text) == 0)
                {
                    lbl_7.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lbl_7.ForeColor = Color.Red;
                }
            }
        }
    }
}
