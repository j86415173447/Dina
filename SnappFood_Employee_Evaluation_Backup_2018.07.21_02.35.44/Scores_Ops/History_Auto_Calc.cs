using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using System.Globalization;

namespace SnappFood_Employee_Evaluation.Scores_Ops
{
    public partial class History_Auto_Calc : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        private ErrorProvider errorProvider;
        public bool errorhappen = false;


        public History_Auto_Calc()
        {
            InitializeComponent();
            RadMessageBox.SetThemeName("Office2010Silver");
            radLabel16.TextAlignment = ContentAlignment.MiddleCenter;
            radLabel17.TextAlignment = ContentAlignment.MiddleCenter;
            radLabel18.TextAlignment = ContentAlignment.MiddleCenter;
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Today_Btn_Click(object sender, EventArgs e)
        {
            /////////////////////////////////////// Get Date
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT day(GETDATE()), month(GETDATE()), year(GETDATE())";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            DateTime datetime = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
            ///////////////////////////////////////// Convert Persian
            PersianCalendar psdate = new PersianCalendar();
            DT_Day.Text = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            DT_Mth.Text = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            DT_Yr.Text = psdate.GetYear(datetime).ToString();
        }

        private void History_Auto_Calc_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            errorhappen = false;
            errorProvider.Clear();
            if (DT_Day.Text == "" || DT_Mth.Text == "" || DT_Yr.Text == "")
            {
                this.errorProvider.SetError(this.DT_Day, "تاریخ کامل وارد نشده است");
                errorhappen = true;
            }
            else
            {
                if (int.Parse(DT_Day.Text) > 31)
                {
                    this.errorProvider.SetError(this.DT_Day, "تاریخ معتبر نیست");
                    errorhappen = true;
                }
                if (int.Parse(DT_Mth.Text) > 12)
                {
                    this.errorProvider.SetError(this.DT_Day, "تاریخ معتبر نیست");
                    errorhappen = true;
                }
                if (int.Parse(DT_Yr.Text) < 1394)
                {
                    this.errorProvider.SetError(this.DT_Day, "تاریخ معتبر نیست");
                    errorhappen = true;
                }
                if (int.Parse(DT_Mth.Text) == 12 && int.Parse(DT_Day.Text) > 29)
                {
                    this.errorProvider.SetError(this.DT_Day, "عدد روز در ماه اسفند بزرگتر از 29 نمی تواند باشد");
                    errorhappen = true;
                }
            }
            if (errorhappen == false)
            {
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void DT_Day_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl.Text.Length == 2)
            {
                this.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void Br_Yr_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl.Text.Length == 4)
            {
                this.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime end_dt;
            DateTime start_dt;
            PersianCalendar perdt = new PersianCalendar();
            end_dt = perdt.ToDateTime(int.Parse(DT_Yr.Text), int.Parse(DT_Mth.Text), int.Parse(DT_Day.Text), 0, 0, 0, 0);
            //////////////////////////////////////////////// get score scheme
            DataTable dtsc3 = new DataTable();
            OleDbDataAdapter adpsc3 = new OleDbDataAdapter();
            adpsc3.SelectCommand = new OleDbCommand();
            adpsc3.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc3 = "SELECT [Sc_Item_Cd],[Sc_Item_Nm],[Sc_Sub_Cd],[Sc_Sub_Nm],[Sc_Tier1],[Sc_Tier2],[Sc_Tier3],[Sc_Tier4],[Sc_Yearly_Cap] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_SCORE_BACK_GROUND] where [SC_Actv] = 1 AND [Sc_Sub_Cd] = 'BG01'";
            adpsc3.SelectCommand.CommandText = lcommandsc3;
            adpsc3.Fill(dtsc3);
            ///////////////////////////////////////////// Score calculation
            int tier1 = int.Parse(dtsc3.Rows[0][4].ToString());
            int tier2 = int.Parse(dtsc3.Rows[0][5].ToString());
            int tier3 = int.Parse(dtsc3.Rows[0][6].ToString());
            int tier4 = int.Parse(dtsc3.Rows[0][7].ToString());
            int tier11 = 0;
            int tier22 = 0;
            int tier33 = 0;
            int tier44 = 0;
            /////////////////////////////////////// Get Employee list not terminated
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT [Doc_No],[Employment_Dt],[Termination] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] where [Termination] != '1'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            Calculation_Prog.Minimum = 0;
            Calculation_Prog.Maximum = dt1.Rows.Count - 1;
            Updation_Prog.Minimum = 0;
            Updation_Prog.Maximum = dt1.Rows.Count - 1;
            DataColumn workCol = dt1.Columns.Add("Score", typeof(Int32));
            DataColumn workCol2 = dt1.Columns.Add("Months", typeof(Int32));
            /////////////////////////////////////// start calculating the scores and updation in Data Table
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt1.Rows[i][1].ToString();
                start_dt = perdt.ToDateTime(int.Parse(dt1.Rows[i][1].ToString().Substring(0, 4)), int.Parse(dt1.Rows[i][1].ToString().Substring(5, 2)), int.Parse(dt1.Rows[i][1].ToString().Substring(8, 2)), 0, 0, 0, 0);
                int difference = int.Parse((end_dt - start_dt).TotalDays.ToString());
                difference = difference / 30;

                int BG_Amount = difference;
                if (BG_Amount > 6)
                {
                    tier11 = 6;
                    BG_Amount = BG_Amount - 6;
                    if (BG_Amount > 6)
                    {
                        tier22 = 6;
                        BG_Amount = BG_Amount - 6;
                        if (BG_Amount > 12)
                        {
                            tier33 = 12;
                            BG_Amount = BG_Amount - 12;
                            if (BG_Amount > 0)
                            {
                                tier44 = BG_Amount;
                            }
                        }
                        else
                        {
                            tier33 = BG_Amount;
                        }
                    }
                    else
                    {
                        tier22 = BG_Amount;
                    }
                }
                else
                {
                    tier11 = BG_Amount;
                }
                int result = ((tier1 * tier11) + (tier2 * tier22) + (tier3 * tier33) + (tier4 * tier44));
                dt1.Rows[i][3] = (result).ToString();
                dt1.Rows[i][4] = difference.ToString();
                tier11 = 0;
                tier22 = 0;
                tier33 = 0;
                tier44 = 0;
                //Calculation_Prog.Value1 = i;
                //this.Update();
                //this.Refresh();
                backgroundWorker1.ReportProgress(i, "Calculation");
            }
            ////////////////////////////////////////////// Update DB
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (dt1.Rows[i][3].ToString() != "0")
                {
                    /////////////////////////////////////////// Remove 
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "DELETE FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] WHERE [Doc_No] = '" + dt1.Rows[i][0].ToString() + "' AND [Sc_Item_Sub_Cd] = 'BG01'";
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    /////////////////////////////////////////// UPDATE SCORE TABLE
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_SCORES] ([Doc_No],[Sc_Item_Cd],[Sc_Item_Sub_Cd],[Sc_Item_Nm],[Sc_Description],[Sc_Score],[Sc_Eff_DT],[Sc_Actv],[Insert_DT],[Insert_Tm],[Insert_User]) VALUES (?,?,?,?,?,?,?,?,getdate(),getdate(),?)";
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", dt1.Rows[i][0].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Cd", dtsc3.Rows[0][0].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Sub_Cd", dtsc3.Rows[0][2].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Item_Nm", dtsc3.Rows[0][1].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Description", dt1.Rows[i][4].ToString() + " ماه " + dtsc3.Rows[0][3].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Score", dt1.Rows[i][3].ToString().ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Eff_DT", DT_Yr.Text + "/" + DT_Mth.Text + "/" + DT_Day.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Sc_Actv", "1");
                    oleDbCommand1.Parameters.AddWithValue("@Insert_User", "محاسبه اتوماتیک امتیاز سابقه کار در شرکت");
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                }
                //Updation_Prog.Value1 = i;
                //this.Update();
                //this.Refresh();
                backgroundWorker1.ReportProgress(i, "Updation");
            }          
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.UserState.ToString() == "Calculation")
            {
                Calculation_Prog.Value1 = e.ProgressPercentage;
                Calculation_Prog.Text = "محاسبه امتیازات: " + e.ProgressPercentage + " از " + Calculation_Prog.Maximum;
            }
            if (e.UserState.ToString() == "Updation")
            {
                Updation_Prog.Value1 = e.ProgressPercentage;
                Updation_Prog.Text = "بروزرسانی پرونده ها: " + e.ProgressPercentage + " از " + Calculation_Prog.Maximum;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RadMessageBox.Show(this, " محاسبات با موفقیت انجام شد. امتیازات در پرونده پرسنل بروزرسانی گردید. ", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
        }

        private void DT_Day_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
