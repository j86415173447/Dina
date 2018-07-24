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
    public partial class MONTHLY_PERFORMANCE : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string Doc_Cd;
        public string doc_number;
        public bool load = true;
        
        public MONTHLY_PERFORMANCE()
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
            lbl_22.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_23.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_24.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_25.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_26.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_27.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_28.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_29.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_30.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_31.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_32.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_33.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_34.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_35.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_36.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_37.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_38.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_39.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_40.TextAlignment = ContentAlignment.MiddleLeft;
            lbl_41.TextAlignment = ContentAlignment.MiddleLeft;
        }

        private void Points_Detail_Report_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
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
            //lbl_3.Text = dt1.Rows[0][6].ToString();

            //searching();
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
                lcommand1 = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[PER_MONTHLY_PERFORMANCE] WHERE [Doc_no] = '" + doc_number + "' AND [yr] = N'" + yr.Text + "' AND [mnth] = N'" + (mnth.SelectedIndex + 1).ToString() + "'";
                adp1.SelectCommand.CommandText = lcommand1;
                adp1.Fill(dt1);
                if (dt1.Rows.Count == 1)
                {
                    lbl_3.Text = (dt1.Rows[0][3].ToString() != "") ? dt1.Rows[0][3].ToString() : "0";
                    lbl_4.Text = (dt1.Rows[0][4].ToString() != "") ? dt1.Rows[0][4].ToString() : "0";
                    lbl_5.Text = (dt1.Rows[0][5].ToString() != "") ? dt1.Rows[0][5].ToString() : "0";
                    lbl_6.Text = (dt1.Rows[0][6].ToString() != "") ? dt1.Rows[0][6].ToString() : "0";
                    lbl_7.Text = (dt1.Rows[0][7].ToString() != "") ? dt1.Rows[0][7].ToString() : "0";
                    lbl_8.Text = (dt1.Rows[0][8].ToString() != "") ? dt1.Rows[0][8].ToString() : "0";
                    lbl_9.Text = (dt1.Rows[0][9].ToString() != "") ? dt1.Rows[0][9].ToString() : "0";
                    lbl_10.Text = (dt1.Rows[0][10].ToString() != "") ? dt1.Rows[0][10].ToString() : "0";
                    lbl_11.Text = (dt1.Rows[0][11].ToString() != "") ? dt1.Rows[0][11].ToString() : "0";
                    lbl_12.Text = (dt1.Rows[0][12].ToString() != "") ? dt1.Rows[0][12].ToString() : "0";
                    lbl_13.Text = (dt1.Rows[0][13].ToString() != "") ? dt1.Rows[0][13].ToString() : "0";
                    lbl_14.Text = (dt1.Rows[0][14].ToString() != "") ? dt1.Rows[0][14].ToString() : "0";
                    lbl_15.Text = (dt1.Rows[0][15].ToString() != "") ? dt1.Rows[0][15].ToString() : "0";
                    lbl_16.Text = (dt1.Rows[0][16].ToString() != "") ? dt1.Rows[0][16].ToString() : "0";
                    lbl_17.Text = (dt1.Rows[0][17].ToString() != "") ? dt1.Rows[0][17].ToString() : "0";
                    lbl_18.Text = (dt1.Rows[0][18].ToString() != "") ? dt1.Rows[0][18].ToString() : "0";
                    lbl_19.Text = (dt1.Rows[0][19].ToString() != "") ? dt1.Rows[0][19].ToString() : "0";
                    lbl_20.Text = (dt1.Rows[0][20].ToString() != "") ? dt1.Rows[0][20].ToString() : "0";
                    lbl_21.Text = (dt1.Rows[0][21].ToString() != "") ? dt1.Rows[0][21].ToString() : "0";
                    lbl_22.Text = (dt1.Rows[0][22].ToString() != "") ? dt1.Rows[0][22].ToString() : "0";
                    lbl_23.Text = (dt1.Rows[0][23].ToString() != "") ? dt1.Rows[0][23].ToString() : "0";
                    lbl_24.Text = (dt1.Rows[0][24].ToString() != "") ? dt1.Rows[0][24].ToString() : "0";
                    lbl_25.Text = (dt1.Rows[0][25].ToString() != "") ? dt1.Rows[0][25].ToString() : "0";
                    lbl_26.Text = (dt1.Rows[0][26].ToString() != "") ? dt1.Rows[0][26].ToString() : "0";
                    lbl_27.Text = (dt1.Rows[0][27].ToString() != "") ? dt1.Rows[0][27].ToString() : "0";
                    lbl_28.Text = (dt1.Rows[0][28].ToString() != "") ? dt1.Rows[0][28].ToString() : "0";
                    lbl_29.Text = (dt1.Rows[0][29].ToString() != "") ? dt1.Rows[0][29].ToString() : "0";
                    lbl_30.Text = (dt1.Rows[0][30].ToString() != "") ? dt1.Rows[0][30].ToString() : "0";
                    lbl_31.Text = (dt1.Rows[0][31].ToString() != "") ? dt1.Rows[0][31].ToString() : "0";
                    lbl_32.Text = (dt1.Rows[0][32].ToString() != "") ? dt1.Rows[0][32].ToString() : "0";
                    lbl_33.Text = (dt1.Rows[0][33].ToString() != "") ? dt1.Rows[0][33].ToString() : "0";
                    lbl_34.Text = (dt1.Rows[0][34].ToString() != "") ? dt1.Rows[0][34].ToString() : "0";
                    lbl_35.Text = (dt1.Rows[0][35].ToString() != "") ? dt1.Rows[0][35].ToString() : "0";
                    lbl_36.Text = (dt1.Rows[0][36].ToString() != "") ? dt1.Rows[0][36].ToString() : "0";
                    lbl_37.Text = (dt1.Rows[0][37].ToString() != "") ? dt1.Rows[0][37].ToString() : "0";
                    lbl_38.Text = (dt1.Rows[0][38].ToString() != "") ? dt1.Rows[0][38].ToString() : "0";
                    lbl_39.Text = Convert.ToInt32(Math.Floor(float.Parse(dt1.Rows[0][39].ToString()) / 3600)).ToString() + ":" + TimeSpan.FromSeconds(float.Parse(dt1.Rows[0][39].ToString())).ToString(@"mm\:ss");
                    lbl_40.Text = Convert.ToInt32(Math.Floor(float.Parse(dt1.Rows[0][40].ToString()) / 3600)).ToString() + ":" + TimeSpan.FromSeconds(float.Parse(dt1.Rows[0][40].ToString())).ToString(@"mm\:ss");
                    lbl_41.Text = Convert.ToInt32(Math.Floor(float.Parse(dt1.Rows[0][41].ToString()) / 3600)).ToString() + ":" + TimeSpan.FromSeconds(float.Parse(dt1.Rows[0][41].ToString())).ToString(@"mm\:ss");
                }
                else
                {
                    lbl_3.Text = "";
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
                    lbl_22.Text = "";
                    lbl_23.Text = "";
                    lbl_24.Text = "";
                    lbl_25.Text = "";
                    lbl_26.Text = "";
                    lbl_27.Text = "";
                    lbl_28.Text = "";
                    lbl_29.Text = "";
                    lbl_30.Text = "";
                    lbl_31.Text = "";
                    lbl_32.Text = "";
                    lbl_33.Text = "";
                    lbl_34.Text = "";
                    lbl_35.Text = "";
                    lbl_36.Text = "";
                    lbl_37.Text = "";
                    lbl_38.Text = "";
                    lbl_39.Text = "";
                    lbl_40.Text = "";
                    lbl_41.Text = "";
                }
            }
            else
            {
                lbl_3.Text = "";
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
                lbl_22.Text = "";
                lbl_23.Text = "";
                lbl_24.Text = "";
                lbl_25.Text = "";
                lbl_26.Text = "";
                lbl_27.Text = "";
                lbl_28.Text = "";
                lbl_29.Text = "";
                lbl_30.Text = "";
                lbl_31.Text = "";
                lbl_32.Text = "";
                lbl_33.Text = "";
                lbl_34.Text = "";
                lbl_35.Text = "";
                lbl_36.Text = "";
                lbl_37.Text = "";
                lbl_38.Text = "";
                lbl_39.Text = "";
                lbl_40.Text = "";
                lbl_41.Text = "";
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
