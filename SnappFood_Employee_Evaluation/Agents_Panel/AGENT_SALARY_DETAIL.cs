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
using Stimulsoft.Report;
using JntNum2Text;

namespace SnappFood_Employee_Evaluation.Agents_Panel
{
    public partial class AGENT_SALARY_DETAIL : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string Doc_Cd;
        public string doc_number;
        public bool load = true;
        
        public AGENT_SALARY_DETAIL()
        {
            InitializeComponent();
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
            lbl_20.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_21.TextAlignment = ContentAlignment.MiddleLeft;
            pictureBox1.TextAlignment = ContentAlignment.MiddleCenter;
        }

        private void Points_Detail_Report_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkvzF1o08hthhDtqY3mfT5D5YugnchRUILFmsJAH+MlystEun4HfKczPcJjASP/mnxJd9EgcqEEwKjl5OgcaUyPI807Lse0RyIQsNpWJQyh+EEy7hHxE0V24BdMYg7Es0aynDy6fBJ4b9Q/wLGbu3XML+fqEme2U9HCZcSdRZLJampqCua6C3pTXLKrfwph5cUSh02iMKXZFUum9dGAPTVg0t/k6JYEiTJ+zWkSkDYJQKUjRqd7c0ODs1eO/7qfbB5QLlA8EENysG+hwouUT6AuNXQwoewjfPgGQwA6RL8rbJGLlg7mGpoMpy2VJBeteZSAYwG8V8TyOrZSza7uVGzNDEiBBnMjGBTW8VztNiCD9OtsiK4Zjqe2tsM6JMWhbcfgV1min4H0y/qvBUKL2Zc+aWw8D09nJExn2OXDJKvT8Q==";
            /////////////////////////////////////// Get Date
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT day(GETDATE()), month(GETDATE()), year(GETDATE()),[Per_Name],[Department],[Main_Shift],[Chargoon_Id] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [doc_no] = '" + doc_number + "'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            DateTime datetime = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());

            ////////////////////////////////////////////////////////////////// Update Header
            lbl_0.Text = dt1.Rows[0][3].ToString();
            lbl_1.Text = dt1.Rows[0][4].ToString();
            lbl_2.Text = dt1.Rows[0][5].ToString();
            lbl_3.Text = dt1.Rows[0][6].ToString();

            ///////////////////////////////////////// Convert Persian
            PersianCalendar psdate = new PersianCalendar();
            mnth.SelectedIndex = psdate.GetMonth(datetime) - 2;
            yr.Items.Add((psdate.GetYear(datetime) - 1).ToString());
            yr.Items.Add((psdate.GetYear(datetime)).ToString());
            yr.SelectedIndex = 1;
            load = false;
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
                lcommand1 = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SALARY_SLIP] WHERE [System_Id] = '" + lbl_3.Text + "' AND [yr] = N'" + yr.Text + "' AND [mnth] = N'" + (mnth.SelectedIndex + 1).ToString() + "'";
                adp1.SelectCommand.CommandText = lcommand1;
                adp1.Fill(dt1);
                if (dt1.Rows.Count == 1)
                {
                    lbl_4.Text = (dt1.Rows[0][3].ToString() != "") ? dt1.Rows[0][3].ToString() : "0";
                    lbl_5.Text = (dt1.Rows[0][4].ToString() != "") ? dt1.Rows[0][4].ToString() : "0";
                    lbl_6.Text = (dt1.Rows[0][5].ToString() != "") ? dt1.Rows[0][5].ToString() : "0";
                    lbl_7.Text = (dt1.Rows[0][6].ToString() != "") ? dt1.Rows[0][6].ToString() : "0";
                    lbl_8.Text = (dt1.Rows[0][7].ToString() != "") ? dt1.Rows[0][7].ToString() : "0";
                    lbl_9.Text = (dt1.Rows[0][8].ToString() != "") ? dt1.Rows[0][8].ToString() : "0";
                    lbl_10.Text = (dt1.Rows[0][9].ToString() != "") ? dt1.Rows[0][9].ToString() : "0";
                    lbl_11.Text = (dt1.Rows[0][10].ToString() != "") ? dt1.Rows[0][10].ToString() : "0";
                    lbl_12.Text = (dt1.Rows[0][11].ToString() != "") ? dt1.Rows[0][11].ToString() : "0";
                    lbl_13.Text = (dt1.Rows[0][12].ToString() != "") ? dt1.Rows[0][12].ToString() : "0";
                    lbl_14.Text = (dt1.Rows[0][13].ToString() != "") ? dt1.Rows[0][13].ToString() : "0";
                    lbl_15.Text = (dt1.Rows[0][14].ToString() != "") ? dt1.Rows[0][14].ToString() : "0";
                    lbl_16.Text = (dt1.Rows[0][15].ToString() != "") ? dt1.Rows[0][15].ToString() : "0";
                    lbl_17.Text = (dt1.Rows[0][16].ToString() != "") ? dt1.Rows[0][16].ToString() : "0";
                    lbl_18.Text = (dt1.Rows[0][17].ToString() != "") ? dt1.Rows[0][17].ToString() : "0";
                    lbl_19.Text = (dt1.Rows[0][18].ToString() != "") ? dt1.Rows[0][18].ToString() : "0";
                    lbl_20.Text = (dt1.Rows[0][19].ToString() != "") ? dt1.Rows[0][19].ToString() : "0";
                    lbl_21.Text = (dt1.Rows[0][20].ToString() != "") ? dt1.Rows[0][20].ToString() : "0";
                    
                }
                else
                {
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
                    lbl_20.Text = "";
                    lbl_21.Text = "";
                }
            }
            else
            {
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
                lbl_20.Text = "";
                lbl_21.Text = "";
            }
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

        private void Print_Click(object sender, EventArgs e)
        {
            string horofi = Num2Text.ToFarsi(Convert.ToInt64((lbl_21.Text).Replace(",", "")));
            horofi = horofi + " ریال";
            StiReport report = new StiReport();
            report.Load(Application.StartupPath + "\\Reports\\Salary_Bill.mrt");
            report.Dictionary.Variables.Add("mnth", mnth.Text);
            report.Dictionary.Variables.Add("yr", yr.Text);
            report.Dictionary.Variables.Add("lbl_0", lbl_0.Text);
            report.Dictionary.Variables.Add("lbl_1", lbl_1.Text);
            report.Dictionary.Variables.Add("lbl_2", lbl_2.Text);
            report.Dictionary.Variables.Add("lbl_3", lbl_3.Text);
            report.Dictionary.Variables.Add("lbl_4", lbl_4.Text + " روز");
            report.Dictionary.Variables.Add("lbl_5", lbl_5.Text);
            report.Dictionary.Variables.Add("lbl_6", lbl_6.Text);
            report.Dictionary.Variables.Add("lbl_7", lbl_7.Text);
            report.Dictionary.Variables.Add("lbl_8", lbl_8.Text);
            report.Dictionary.Variables.Add("lbl_9", lbl_9.Text);
            report.Dictionary.Variables.Add("lbl_10", lbl_10.Text);
            report.Dictionary.Variables.Add("lbl_11", lbl_11.Text);
            report.Dictionary.Variables.Add("lbl_12", lbl_12.Text);
            report.Dictionary.Variables.Add("lbl_13", lbl_13.Text);
            report.Dictionary.Variables.Add("lbl_14", lbl_14.Text);
            report.Dictionary.Variables.Add("lbl_15", lbl_15.Text);
            report.Dictionary.Variables.Add("lbl_16", lbl_16.Text);
            report.Dictionary.Variables.Add("lbl_17", lbl_17.Text);
            report.Dictionary.Variables.Add("lbl_18", lbl_18.Text);
            report.Dictionary.Variables.Add("lbl_19", lbl_19.Text);
            report.Dictionary.Variables.Add("lbl_20", lbl_20.Text);
            report.Dictionary.Variables.Add("lbl_21", lbl_21.Text);
            report.Dictionary.Variables.Add("horofi", horofi);
            Stimulsoft.Report.Print.StiPrintProvider.SetPaperSource = false;
            report.Render();
            report.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
