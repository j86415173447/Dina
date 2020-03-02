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
            lb_01.TextAlignment = ContentAlignment.MiddleLeft;
            lb_02.TextAlignment = ContentAlignment.MiddleLeft;
            lb_03.TextAlignment = ContentAlignment.MiddleLeft;
            lb_04.TextAlignment = ContentAlignment.MiddleLeft;
            lb_05.TextAlignment = ContentAlignment.MiddleLeft;
            lb_06.TextAlignment = ContentAlignment.MiddleLeft;
            lb_07.TextAlignment = ContentAlignment.MiddleLeft;
            lb_08.TextAlignment = ContentAlignment.MiddleLeft;
            lb_09.TextAlignment = ContentAlignment.MiddleLeft;
            lb_10.TextAlignment = ContentAlignment.MiddleLeft;
            lb_11.TextAlignment = ContentAlignment.MiddleLeft;
            lb_12.TextAlignment = ContentAlignment.MiddleLeft;
            lb_13.TextAlignment = ContentAlignment.MiddleLeft;
            lb_14.TextAlignment = ContentAlignment.MiddleLeft;
            lb_15.TextAlignment = ContentAlignment.MiddleLeft;
            lb_16.TextAlignment = ContentAlignment.MiddleLeft;
            lb_17.TextAlignment = ContentAlignment.MiddleLeft;
            lb_18.TextAlignment = ContentAlignment.MiddleLeft;
            lb_19.TextAlignment = ContentAlignment.MiddleLeft;
            lb_20.TextAlignment = ContentAlignment.MiddleLeft;
            lb_21.TextAlignment = ContentAlignment.MiddleLeft;
            lb_22.TextAlignment = ContentAlignment.MiddleLeft;
            lb_23.TextAlignment = ContentAlignment.MiddleLeft;
            lb_24.TextAlignment = ContentAlignment.MiddleLeft;
            lb_25.TextAlignment = ContentAlignment.MiddleLeft;
            lb_26.TextAlignment = ContentAlignment.MiddleLeft;
            lb_27.TextAlignment = ContentAlignment.MiddleLeft;
            lb_28.TextAlignment = ContentAlignment.MiddleLeft;
            lb_29.TextAlignment = ContentAlignment.MiddleLeft;
            lb_30.TextAlignment = ContentAlignment.MiddleLeft;
            lb_31.TextAlignment = ContentAlignment.MiddleLeft;
            lb_32.TextAlignment = ContentAlignment.MiddleLeft;
            lb_33.TextAlignment = ContentAlignment.MiddleLeft;
            lb_34.TextAlignment = ContentAlignment.MiddleLeft;
            lb_35.TextAlignment = ContentAlignment.MiddleLeft;
            lb_36.TextAlignment = ContentAlignment.MiddleLeft;
            lb_37.TextAlignment = ContentAlignment.MiddleLeft;
            lb_38.TextAlignment = ContentAlignment.MiddleLeft;
            lb_39.TextAlignment = ContentAlignment.MiddleLeft;
            lb_40.TextAlignment = ContentAlignment.MiddleLeft;
            lb_41.TextAlignment = ContentAlignment.MiddleLeft;
            lb_42.TextAlignment = ContentAlignment.MiddleLeft;
            lb_43.TextAlignment = ContentAlignment.MiddleLeft;
            lb_44.TextAlignment = ContentAlignment.MiddleLeft;
            lb_45.TextAlignment = ContentAlignment.MiddleLeft;
            lb_47.TextAlignment = ContentAlignment.MiddleLeft;
            lb_46.TextAlignment = ContentAlignment.MiddleLeft;
            pictureBox1.TextAlignment = ContentAlignment.MiddleCenter;
            radLabel78.TextAlignment = ContentAlignment.MiddleLeft;
            radLabel80.TextAlignment = ContentAlignment.MiddleLeft;
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
                lcommand1 = "SELECT [Doc_no],[CALL_ORD] ,[Cancelled] ,[Switch_Order] ,[VMS_Delay] ,[NFC] ,[VMS_Failed] ,[Profile_Count] ,[Translate_Profile] ,[Profile_Edit] ,[Food_Count] ,[Translate_Food] ,[Desc_Count] ,[Translated_Desc] ,[Food_Update] ,[Translate_Food_Update] " +
                            ",[Desc_Update] ,[Translate_Desc_Update] ,[VMS_Chng_Review] ,[Menu_Pic_Upload] ,[Area_Check] ,[Area_Edit] ,[Area_Count] ,[Rest_Status_Chng] ,[Rest_Activation] ,[300_Incoming] ,[300_Outgoing] ,[Happy_Pass] ,[Happy_Failed] " +
                            ",[SUP_Incoming] ,[SUP_Outgoing] ,[Chat] ,[Comment] ,[Jira] ,[Delayed_Exp_1] ,[Delayed_Exp_2] ,[Delayed_1st] ,[Delayed_2nd] ,[Miss_U_Pass] ,[Miss_U_Failed] ,[Miss_U_Returned] ,[Pic_Monitoring] ,[Company_Profile] ,[800_in] ,[800_out] " +
                            ",[Project_Time] ,[Total_Activity] ,[Total_Present] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_MONTHLY_PERFORMANCE] WHERE [Doc_no] = '" + doc_number + "' AND [yr] = N'" + yr.Text + "' AND [mnth] = N'" + (mnth.SelectedIndex + 1).ToString() + "'";
                adp1.SelectCommand.CommandText = lcommand1;
                adp1.Fill(dt1);
                if (dt1.Rows.Count == 1)
                {
                    lb_01.Text = (dt1.Rows[0][1].ToString() != "") ? dt1.Rows[0][1].ToString() : "0";
                    lb_02.Text = (dt1.Rows[0][2].ToString() != "") ? dt1.Rows[0][2].ToString() : "0";
                    lb_03.Text = (dt1.Rows[0][3].ToString() != "") ? dt1.Rows[0][3].ToString() : "0";
                    lb_04.Text = (dt1.Rows[0][4].ToString() != "") ? dt1.Rows[0][4].ToString() : "0";
                    lb_05.Text = (dt1.Rows[0][5].ToString() != "") ? dt1.Rows[0][5].ToString() : "0";
                    lb_06.Text = (dt1.Rows[0][6].ToString() != "") ? dt1.Rows[0][6].ToString() : "0";
                    lb_07.Text = (dt1.Rows[0][7].ToString() != "") ? dt1.Rows[0][7].ToString() : "0";
                    lb_08.Text = (dt1.Rows[0][8].ToString() != "") ? dt1.Rows[0][8].ToString() : "0";
                    lb_09.Text = (dt1.Rows[0][9].ToString() != "") ? dt1.Rows[0][9].ToString() : "0";
                    lb_10.Text = (dt1.Rows[0][10].ToString() != "") ? dt1.Rows[0][10].ToString() : "0";
                    lb_11.Text = (dt1.Rows[0][11].ToString() != "") ? dt1.Rows[0][11].ToString() : "0";
                    lb_12.Text = (dt1.Rows[0][12].ToString() != "") ? dt1.Rows[0][12].ToString() : "0";
                    lb_13.Text = (dt1.Rows[0][13].ToString() != "") ? dt1.Rows[0][13].ToString() : "0";
                    lb_14.Text = (dt1.Rows[0][14].ToString() != "") ? dt1.Rows[0][14].ToString() : "0";
                    lb_15.Text = (dt1.Rows[0][15].ToString() != "") ? dt1.Rows[0][15].ToString() : "0";
                    lb_16.Text = (dt1.Rows[0][16].ToString() != "") ? dt1.Rows[0][16].ToString() : "0";
                    lb_17.Text = (dt1.Rows[0][17].ToString() != "") ? dt1.Rows[0][17].ToString() : "0";
                    lb_18.Text = (dt1.Rows[0][18].ToString() != "") ? dt1.Rows[0][18].ToString() : "0";
                    lb_19.Text = (dt1.Rows[0][19].ToString() != "") ? dt1.Rows[0][19].ToString() : "0";
                    lb_20.Text = (dt1.Rows[0][20].ToString() != "") ? dt1.Rows[0][20].ToString() : "0";
                    lb_21.Text = (dt1.Rows[0][21].ToString() != "") ? dt1.Rows[0][21].ToString() : "0";
                    lb_22.Text = (dt1.Rows[0][22].ToString() != "") ? dt1.Rows[0][22].ToString() : "0";
                    lb_23.Text = (dt1.Rows[0][23].ToString() != "") ? dt1.Rows[0][23].ToString() : "0";
                    lb_24.Text = (dt1.Rows[0][24].ToString() != "") ? dt1.Rows[0][24].ToString() : "0";
                    lb_25.Text = (dt1.Rows[0][25].ToString() != "") ? dt1.Rows[0][25].ToString() : "0";
                    lb_26.Text = (dt1.Rows[0][26].ToString() != "") ? dt1.Rows[0][26].ToString() : "0";
                    lb_27.Text = (dt1.Rows[0][27].ToString() != "") ? dt1.Rows[0][27].ToString() : "0";
                    lb_28.Text = (dt1.Rows[0][28].ToString() != "") ? dt1.Rows[0][28].ToString() : "0";
                    lb_29.Text = (dt1.Rows[0][29].ToString() != "") ? dt1.Rows[0][29].ToString() : "0";
                    lb_30.Text = (dt1.Rows[0][30].ToString() != "") ? dt1.Rows[0][30].ToString() : "0";
                    lb_31.Text = (dt1.Rows[0][31].ToString() != "") ? dt1.Rows[0][31].ToString() : "0";
                    lb_32.Text = (dt1.Rows[0][32].ToString() != "") ? dt1.Rows[0][32].ToString() : "0";
                    lb_33.Text = (dt1.Rows[0][33].ToString() != "") ? dt1.Rows[0][33].ToString() : "0";
                    lb_34.Text = (dt1.Rows[0][34].ToString() != "") ? dt1.Rows[0][34].ToString() : "0";
                    lb_35.Text = (dt1.Rows[0][35].ToString() != "") ? dt1.Rows[0][35].ToString() : "0";
                    lb_36.Text = (dt1.Rows[0][36].ToString() != "") ? dt1.Rows[0][36].ToString() : "0";
                    lb_37.Text = (dt1.Rows[0][37].ToString() != "") ? dt1.Rows[0][37].ToString() : "0";
                    lb_38.Text = (dt1.Rows[0][38].ToString() != "") ? dt1.Rows[0][38].ToString() : "0";
                    lb_39.Text = (dt1.Rows[0][39].ToString() != "") ? dt1.Rows[0][39].ToString() : "0";
                    lb_40.Text = (dt1.Rows[0][40].ToString() != "") ? dt1.Rows[0][40].ToString() : "0";
                    lb_41.Text = (dt1.Rows[0][41].ToString() != "") ? dt1.Rows[0][41].ToString() : "0";
                    lb_42.Text = (dt1.Rows[0][42].ToString() != "") ? dt1.Rows[0][42].ToString() : "0";
                    lb_43.Text = (dt1.Rows[0][43].ToString() != "") ? dt1.Rows[0][43].ToString() : "0";
                    lb_44.Text = (dt1.Rows[0][44].ToString() != "") ? dt1.Rows[0][44].ToString() : "0";
                    lb_45.Text = Convert.ToInt32(Math.Floor(float.Parse(dt1.Rows[0][45].ToString()) / 3600)).ToString() + ":" + TimeSpan.FromSeconds(float.Parse(dt1.Rows[0][45].ToString())).ToString(@"mm\:ss");
                    lb_46.Text = Convert.ToInt32(Math.Floor(float.Parse(dt1.Rows[0][46].ToString()) / 3600)).ToString() + ":" + TimeSpan.FromSeconds(float.Parse(dt1.Rows[0][46].ToString())).ToString(@"mm\:ss");
                    lb_47.Text = Convert.ToInt32(Math.Floor(float.Parse(dt1.Rows[0][47].ToString()) / 3600)).ToString() + ":" + TimeSpan.FromSeconds(float.Parse(dt1.Rows[0][47].ToString())).ToString(@"mm\:ss");
                }
                else
                {
                    lb_01.Text = "";
                    lb_02.Text = "";
                    lb_03.Text = "";
                    lb_04.Text = "";
                    lb_05.Text = "";
                    lb_06.Text = "";
                    lb_07.Text = "";
                    lb_08.Text = "";
                    lb_09.Text = "";
                    lb_10.Text = "";
                    lb_11.Text = "";
                    lb_12.Text = "";
                    lb_13.Text = "";
                    lb_14.Text = "";
                    lb_15.Text = "";
                    lb_16.Text = "";
                    lb_17.Text = "";
                    lb_18.Text = "";
                    lb_19.Text = "";
                    lb_20.Text = "";
                    lb_21.Text = "";
                    lb_22.Text = "";
                    lb_23.Text = "";
                    lb_24.Text = "";
                    lb_25.Text = "";
                    lb_26.Text = "";
                    lb_27.Text = "";
                    lb_28.Text = "";
                    lb_29.Text = "";
                    lb_30.Text = "";
                    lb_31.Text = "";
                    lb_32.Text = "";
                    lb_33.Text = "";
                    lb_34.Text = "";
                    lb_35.Text = "";
                    lb_36.Text = "";
                    lb_37.Text = "";
                    lb_38.Text = "";
                    lb_39.Text = "";
                    lb_40.Text = "";
                    lb_41.Text = "";
                    lb_42.Text = "";
                    lb_43.Text = "";
                    lb_44.Text = "";
                    lb_45.Text = "";
                    lb_46.Text = "";
                    lb_47.Text = "";
                }
            }
            else
            {
                lb_01.Text = "";
                lb_02.Text = "";
                lb_03.Text = "";
                lb_04.Text = "";
                lb_05.Text = "";
                lb_06.Text = "";
                lb_07.Text = "";
                lb_08.Text = "";
                lb_09.Text = "";
                lb_10.Text = "";
                lb_11.Text = "";
                lb_12.Text = "";
                lb_13.Text = "";
                lb_14.Text = "";
                lb_15.Text = "";
                lb_16.Text = "";
                lb_17.Text = "";
                lb_18.Text = "";
                lb_19.Text = "";
                lb_20.Text = "";
                lb_21.Text = "";
                lb_22.Text = "";
                lb_23.Text = "";
                lb_24.Text = "";
                lb_25.Text = "";
                lb_26.Text = "";
                lb_27.Text = "";
                lb_28.Text = "";
                lb_29.Text = "";
                lb_30.Text = "";
                lb_31.Text = "";
                lb_32.Text = "";
                lb_33.Text = "";
                lb_34.Text = "";
                lb_35.Text = "";
                lb_36.Text = "";
                lb_37.Text = "";
                lb_38.Text = "";
                lb_39.Text = "";
                lb_40.Text = "";
                lb_41.Text = "";
                lb_42.Text = "";
                lb_43.Text = "";
                lb_44.Text = "";
                lb_45.Text = "";
                lb_46.Text = "";
                lb_47.Text = "";
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
    }
}
