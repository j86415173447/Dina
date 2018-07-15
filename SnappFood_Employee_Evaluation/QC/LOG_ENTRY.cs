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
using NAudio;
using NAudio.Wave;
using System.Media;
using System.Globalization;
using System.Linq;

namespace SnappFood_Employee_Evaluation.QC
{
    public partial class LOG_ENTRY : Telerik.WinControls.UI.RadForm
    {
        public int handling_time = 0;
        public DateTime dt = new DateTime();
        public string constr;
        public string user;
        private ErrorProvider errorProvider;
        SoundPlayer myPlayer = new SoundPlayer();
        public string DT_Day;
        public string DT_Mth;
        public string DT_Yr;
        public string DT_TM;
        //public bool taboo = false;
        WaveOutEvent WaveOut = new WaveOutEvent();
        MemoryStream ms = new MemoryStream();
        public DataTable voice_dt = new DataTable();
        public int amw_sec;
        ///////////////////////////////// Warning Caps
        public int cap_0_30 = 5;
        public int cap_30_60 = 37;
        public int cap_60_90 = 33;
        public int cap_ov_90 = 25;
        public DataTable dt22 = new DataTable();
        Point p = Point.Empty;


        public LOG_ENTRY()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            RadMessageBox.ThemeName = "Office2010Silver";
            WaveOut.PlaybackStopped += new EventHandler<StoppedEventArgs>(audioOutput_PlaybackStopped);
            this.radMenuItem4.Click += new System.EventHandler(this.DEL_CLICK);
        }

        private void LOG_ENTRY_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            call_dt.Culture = new System.Globalization.CultureInfo("fa-IR");
            call_dt.NullableValue = null;
            call_dt.SetToNullValue();
            QC_Agent.Text = user;

            ///////////////////////////// initilize call type combo
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '' 'Call_Type_id', '' 'Call_Type_nm' union SELECT [Call_Type_id],[Call_Type_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_CALL_TYPE] where [Call_Type_Actv] != 0 order by  [Call_Type_id] asc";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            Call_Type.DataSource = dt4;
            Call_Type.DisplayMember = "Call_Type_nm";
            Call_Type.ValueMember = "Call_Type_id";

            ///////////////////////////// initilize log type combo
            DataTable dt5 = new DataTable();
            OleDbDataAdapter adp5 = new OleDbDataAdapter();
            adp5.SelectCommand = new OleDbCommand();
            adp5.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand5 = "SELECT '' 'plan_id', '' 'plan_nm' union SELECT [Plan_id],[Plan_nm] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_PLAN] where [plan_Actv] != 0 order by  [plan_id] asc";
            adp5.SelectCommand.CommandText = lcommand5;
            adp5.Fill(dt5);
            Log_Type.DataSource = dt5;
            Log_Type.DisplayMember = "Plan_nm";
            Log_Type.ValueMember = "Plan_id";

            /////////////////////////////// initialize voice DT
            DataColumn dc;
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "ردیف";
            voice_dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "نام فایل";
            voice_dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "مدت مکالمه";
            voice_dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "حجم فایل";
            voice_dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "آدرس فایل";
            voice_dt.Columns.Add(dc);

            voice_dt.Columns.Add("Byte", typeof(byte[]));

            radGridView1.DataSource = voice_dt;
            radGridView1.Columns[4].IsVisible = false;
            radGridView1.Columns[5].IsVisible = false;

            timer2.Interval = 120000;
            timer2.Start();
            radDesktopAlert1.AutoCloseDelay = 15;
        }

        private void operator_ext_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled != true && QC_ID.Text == "")
            {
                timer1.Interval = 1000;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            handling_time++;
            handle_TM.Text = dt.AddSeconds(handling_time).ToString("mm:ss");
            //if (WaveOut.PlaybackState == PlaybackState.Playing)
            //{
            //    radTrackBar1.Value = (int)(WaveOut.GetPosition() * 1d / WaveOut.OutputWaveFormat.AverageBytesPerSecond);
            //}
            //if (WaveOut.PlaybackState == PlaybackState.Stopped)
            //{
            //    radTrackBar1.Value = 0;
            //    ms.Position = 0;
            //}
        }

        private void operator_ext_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void operator_ext_TextChanged(object sender, EventArgs e)
        {
            if (operator_ext.Text.Length == 4)
            {
                DataTable dt4 = new DataTable();
                OleDbDataAdapter adp4 = new OleDbDataAdapter();
                adp4.SelectCommand = new OleDbCommand();
                adp4.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand4 = "SELECT [Department],[Per_Name],[termination] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] WHERE [System_Id] = '" + operator_ext.Text + "'";
                adp4.SelectCommand.CommandText = lcommand4;
                adp4.Fill(dt4);
                if (dt4.Rows.Count != 0)
                {
                    if (dt4.Rows[0][2].ToString() == "False")
                    {
                        operator_nm.Text = dt4.Rows[0][1].ToString();
                        Department.Text = dt4.Rows[0][0].ToString();
                    }
                    else
                    {
                        this.errorProvider.SetError(this.operator_ext, "داخلی " + operator_ext.Text + " مربوطه به " + dt4.Rows[0][1].ToString() + " است و وضعیت پرونده ایشان قطع همکاری می باشد.");

                        operator_nm.Text = "";
                        Department.Text = "";
                    }
                }
                else
                {
                    this.errorProvider.SetError(this.operator_ext, "همکاری با شماره داخلی وارد شده یافت نشد.");
                    operator_nm.Text = "";
                    Department.Text = "";
                }
            }
            else
            {
                errorProvider.Clear();
                operator_nm.Text = "";
                Department.Text = "";
            }
        }

        private void operator_ext_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (timer1.Enabled != true && e.KeyCode != Keys.F10)
            {
                timer1.Interval = 1000;
                timer1.Start();
            }
        }

        private void call_tm_Enter(object sender, EventArgs e)
        {
            call_tm.Select(0, 0);
        }

        private void calculate_score()
        {
            if (!taboo.Checked)
            {
                DataTable dt4 = new DataTable();
                OleDbDataAdapter adp4 = new OleDbDataAdapter();
                adp4.SelectCommand = new OleDbCommand();
                adp4.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand4 = "SELECT [Call_Type_Id],[QC01],[QC02],[QC03],[QC04],[QC05],[QC06],[QC07],[QC08],[QC09],[QC10],[QC11],[QC12] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_SCORES_MASTER] WHERE [Call_Type_Id] = '" + Call_Type.SelectedValue.ToString() + "'";
                adp4.SelectCommand.CommandText = lcommand4;
                adp4.Fill(dt4);
                int score = 25;
                if (Opn1.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][1].ToString());
                }
                if (Opn2.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][2].ToString());
                }
                if (Lsn1.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][3].ToString());
                }
                if (Lsn2.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][4].ToString());
                }
                if (Lsn3.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][5].ToString());
                }
                if (Lsn4.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][6].ToString());
                }
                if (Spk1.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][7].ToString());
                }
                if (Spk2.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][8].ToString());
                }
                if (Spk3.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][9].ToString());
                }
                if (Qry1.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][10].ToString());
                }
                if (Cls1.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][11].ToString());
                }
                if (Cls2.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][12].ToString());
                }
                Call_Score_Final.Text = score.ToString();
            }
            else
            {
                Call_Score_Final.Text = "0";
            }
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            calculate_log_duration();
            if (QC_ID.Text == "")
            {
                if (required_field_check())
                {
                    if (WaveOut.PlaybackState != PlaybackState.Stopped)
                    {
                        WaveOut.Stop();
                        ms.Position = 0;
                        btnPlay.Image = Properties.Resources.Media_Controls_Play_icon;
                    }
                    var loading = new Loading();
                    loading.label1.Text = "در حال ثبت اطلاعات. شکیبا باشید...";
                    loading.Show();

                    timer1.Stop();
                    calculate_score();
                    Get_QC_ID();

                    if (taboo.Checked)
                    {
                        ///////////////////////////////////////////////////// Insert in DB
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] ( " +
                                                    "[QC_ID],[QC_Year],[QC_Month],[QC_Score],[Agent_Ext],[Call_Type_Cd],[Log_Type_Cd],[Call_Tm],[Call_Dt],[QC_Param_1],[QC_Param_2] " +
                                                    ",[QC_Param_3],[QC_Param_4],[QC_Param_5],[QC_Param_6],[QC_Param_7],[QC_Param_8],[QC_Param_9],[QC_Param_10],[QC_Param_11],[QC_Param_12] " +
                                                    ",[Inv_link],[Remarks],[Handling_tm],[taboo],[insrt_dt_per],[insrt_tm],[insrt_dt],[QC_M_Approval],[QC_M_Aprv_Usr],[QC_M_Aprv_DT],[CC_M_Approval],[CC_M_Aprv_Usr],[CC_M_Aprv_Rmrk],[CC_M_Aprv_DT]" +
                                                     " ,[QC_Agent],[No_switch],[Bad_switch],[Active_Status]) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,getdate(),getdate(),?,?,?,?,?,?,?,?,?,?,?)";
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", QC_ID.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Yr);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Mth);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Call_Score_Final.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", operator_ext.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Call_Type.SelectedValue.ToString());
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Log_Type.SelectedValue.ToString());
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", call_tm.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", call_dt.Text);
                        if (Opn1.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Opn2.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Lsn1.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Lsn2.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Lsn3.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Lsn4.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Spk1.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Spk2.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Spk3.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Qry1.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Cls1.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Cls2.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }

                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Inv_link.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Remarks.Text);
                        //oleDbCommand1.Parameters.AddWithValue("@CLS_CD", ReadFile(sound_add.Text));
                        ////oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Call_Duration_Sec.Text);
                        //oleDbCommand1.Parameters.AddWithValue("@CLS_CD", file_size.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", handling_time.ToString());
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                        /////////////////////////////////////////////////////////////////////////////////////////////// Because of Taboo
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        ///////////////////////////////////////////////////////////////////////////////////////////////// End of Taboo
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", QC_Agent.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", No_swt.Checked ? "1" : "0");
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Bad_swt.Checked ? "1" : "0");
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "1");
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                    }
                    else
                    {
                        ///////////////////////////////////////////////////// Insert in DB
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] ( " +
                                                    "[QC_ID],[QC_Year],[QC_Month],[QC_Score],[Agent_Ext],[Call_Type_Cd],[Log_Type_Cd],[Call_Tm],[Call_Dt],[QC_Param_1],[QC_Param_2] " + //11
                                                    ",[QC_Param_3],[QC_Param_4],[QC_Param_5],[QC_Param_6],[QC_Param_7],[QC_Param_8],[QC_Param_9],[QC_Param_10],[QC_Param_11],[QC_Param_12] " + //10
                                                    ",[Inv_link],[Remarks],[Handling_tm],[taboo],[insrt_dt_per],[insrt_tm],[insrt_dt],[QC_M_Approval],[QC_M_Aprv_Usr],[QC_M_Aprv_DT],[CC_M_Approval],[CC_M_Aprv_Usr],[CC_M_Aprv_Rmrk],[CC_M_Aprv_DT],[LD_M_Approval],[LD_M_Aprv_Usr],[LD_M_Aprv_Rmrk],[LD_M_Aprv_DT],[MG_M_Approval],[MG_M_Aprv_Usr],[MG_M_Aprv_Rmrk],[MG_M_Aprv_Dt],[Final_Approval],[Final_Aprv_Usr],[Final_Aprv_Rmrk],[Final_Aprv_DT]" + //17
                                                    " ,[QC_Agent],[No_switch],[Bad_switch],[Active_Status]) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,getdate(),getdate(),?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", QC_ID.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Yr);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Mth);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Call_Score_Final.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", operator_ext.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Call_Type.SelectedValue.ToString());
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Log_Type.SelectedValue.ToString());
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", call_tm.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", call_dt.Text);
                        if (Opn1.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Opn2.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Lsn1.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Lsn2.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Lsn3.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Lsn4.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Spk1.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Spk2.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Spk3.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Qry1.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Cls1.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }
                        if (Cls2.Checked)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        }
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        }

                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Inv_link.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Remarks.Text);
                        //oleDbCommand1.Parameters.AddWithValue("@CLS_CD", ReadFile(sound_add.Text));
                        ////oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Call_Duration_Sec.Text);
                        //oleDbCommand1.Parameters.AddWithValue("@CLS_CD", file_size.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", handling_time.ToString());
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                        if (int.Parse(Call_Score_Final.Text) > 17)
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "لاگ موفق");
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "لاگ موفق");
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "لاگ موفق");
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "لاگ موفق");
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "لاگ موفق");
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "لاگ موفق");
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "لاگ موفق");
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "لاگ موفق");
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "لاگ موفق");
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                        }
                        //else if (int.Parse(Call_Score_Final.Text) >= 15 && int.Parse(Call_Score_Final.Text) <= 17)
                        //{
                        //    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                        //    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "لاگ موفق کیفی");
                        //    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                        //    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        //    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        //    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        //    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        //    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        //    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        //    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        //    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        //}
                        else
                        {
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                            oleDbCommand1.Parameters.AddWithValue("@CLS_CD", null);
                        }
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", QC_Agent.Text);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", No_swt.Checked ? "1" : "0");
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Bad_swt.Checked ? "1" : "0");
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "1");
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                    }
                    ///////////////////////////////////////////// Insert voice files
                    for (int i = 0; i < voice_dt.Rows.Count; i++)
                    {
                        oleDbCommand1.Parameters.Clear();
                        oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_VOICES] ( " +
                                                    "[QC_ID],[File_Row],[File_Name],[Voice],[Voice_len],[Voice_size]" +
                                                    ") values (?,?,?,?,?,?)";
                        oleDbCommand1.Parameters.AddWithValue("@QC_ID", QC_ID.Text);
                        oleDbCommand1.Parameters.AddWithValue("@File_Row", voice_dt.Rows[i][0].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@File_Name", voice_dt.Rows[i][1].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Voice", voice_dt.Rows[i][5]);
                        oleDbCommand1.Parameters.AddWithValue("@Voice_len", voice_dt.Rows[i][2].ToString());
                        oleDbCommand1.Parameters.AddWithValue("@Voice_size", voice_dt.Rows[i][3].ToString());
                        oleDbConnection1.Open();
                        oleDbCommand1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                    }
                    loading.Close();
                    Insert_Date.Text = DT_Yr + "/" + DT_Mth + "/" + DT_Day;
                    Insert_Time.Text = DT_TM;
                    RadMessageBox.Show(this, "لاگ به شناسه " + QC_ID.Text + " با موفقیت ثبت شد." + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
            }
            else
            {
                RadMessageBox.Show(this, "لاگ به شناسه " + QC_ID.Text + " قبلا ثبت شده و امکان ویرایش ندارد." + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            btnPlay.Image = Properties.Resources.Media_Controls_Play_icon;
            
        }

        byte[] ReadFile(string sPath)
        {
            byte[] data = null;
            data = System.IO.File.ReadAllBytes(sPath);
            return data;
        }

        private void LOG_ENTRY_FormClosed(object sender, FormClosedEventArgs e)
        {
            WaveOut.Dispose();
            timer1.Stop();
        }

        public bool required_field_check()
        {
            bool error = false;
            errorProvider.Clear();

            if (operator_nm.Text == "")
            {
                this.errorProvider.SetError(this.label2, "شماره داخلی بررسی شود.");
                error = true;
            }
            if(Call_Type.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.label7, "نوع تماس انتخاب نشده است.");
                error = true;
            }
            if (Log_Type.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.label1, "پلن کیفی انتخاب نشده است.");
                error = true;
            }
            if (call_dt.Text == "" || !call_tm.MaskFull)
            {
                this.errorProvider.SetError(this.label6, "ساعت/تاریخ مکالمه بررسی شود.");
                error = true;
            }
            if (Inv_link.Text == "")
            {
                this.errorProvider.SetError(this.label14, "لینک فاکتور وارد نشده است.");
                error = true;
            }
            if (Remarks.Text == "")
            {
                this.errorProvider.SetError(this.label18, "توضیحات وارد نشده است.");
                error = true;
            }
            if (voice_dt.Rows.Count == 0 || radGridView1.Rows.Count == 0)
            {
                this.errorProvider.SetError(this.radButton1, "آرشیو فایل صوتی خالی است.");
                error = true;
            }
            if (error)
            {
                return false;
            }
            else if (amw_sec == 0 || handling_time < calculate_log_duration() + amw_sec)
            {
                RadMessageBox.Show(this, "مجاز به ثبت لاگ نمی باشید." + "\n\n" + " خطای محدودیت AMW. " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Get_QC_ID()
        {
            //////////////////////////////////////// Get Date Persian
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT day(GETDATE()), month(GETDATE()), year(GETDATE()), CONVERT(time(0), CURRENT_TIMESTAMP) ";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            DateTime datetime = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
            ///////////////////////////////////////// Convert Persian
            PersianCalendar psdate = new PersianCalendar();
            DT_Day = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            DT_Mth = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            DT_Yr = psdate.GetYear(datetime).ToString();
            DT_TM = dt1.Rows[0][3].ToString().Substring(0, 5);
            ///////////////////////////////////////////////// GET QC_ID
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT max([QC_ID]) FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where [QC_Year] = '" + DT_Yr + "' and [QC_Month] = '" + DT_Mth + "'";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            int QC_ID_NO;
            if (dt4.Rows[0][0].ToString() == "")
            {
                QC_ID.Text = DT_Yr.Substring(2, 2) + DT_Mth + "00000";
            }
            else
            {
                QC_ID_NO = int.Parse(dt4.Rows[0][0].ToString().Substring(4,5)) + 1;
                if (QC_ID_NO < 10)
                {
                    QC_ID.Text = DT_Yr.Substring(2, 2) + DT_Mth + "0000" + QC_ID_NO.ToString();
                }
                else if (QC_ID_NO < 100)
                {
                    QC_ID.Text = DT_Yr.Substring(2, 2) + DT_Mth + "000" + QC_ID_NO.ToString();
                }
                else if (QC_ID_NO < 1000)
                {
                    QC_ID.Text = DT_Yr.Substring(2, 2) + DT_Mth + "00" + QC_ID_NO.ToString();
                }
                else if (QC_ID_NO < 10000)
                {
                    QC_ID.Text = DT_Yr.Substring(2, 2) + DT_Mth + "0" + QC_ID_NO.ToString();
                }
                else if (QC_ID_NO >= 10000)
                {
                    QC_ID.Text = DT_Yr.Substring(2, 2) + DT_Mth + QC_ID_NO.ToString();
                }
            }
        }

        private void taboo_CheckedChanged(object sender, EventArgs e)
        {
            if (taboo.Checked)
            {
                btnTaboo.Text = "وضعیت تابو: فعال";
                btnTaboo.BackColor = Color.Red;
                btnTaboo.ForeColor = Color.Yellow;
                btnTaboo.Image = Properties.Resources.danger_icon;
            }
            else
            {
                btnTaboo.Text = "وضعیت تابو: غیر فعال";
                btnTaboo.BackColor = Color.WhiteSmoke;
                btnTaboo.ForeColor = Color.Black;
                btnTaboo.Image = Properties.Resources.small_tick;
            }
        }

        private void btnTaboo_Click(object sender, EventArgs e)
        {
            if (taboo.Checked)
            {
                taboo.Checked = false;
            }
            else
            {
                taboo.Checked = true;
            }
        }

        private void Insert_Time_TextChanged(object sender, EventArgs e)
        {
            if (Insert_Time.Text == "")
            {
                label13.Visible = false;
            }
            else
            {
                label13.Visible = true;
            }
        }

        public void audioOutput_PlaybackStopped(object sender, EventArgs e)
        {
            ms.Position = 0;
            WaveOut.Stop();
            btnPlay.Image = Properties.Resources.Media_Controls_Play_icon;
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            QC_ID.Text = "";
            Call_Score_Final.Text = "";
            operator_ext.Text = "";
            call_dt.SetToNullValue();
            call_tm.Text = "";
            Opn1.Checked = false;
            Opn2.Checked = false;
            Spk1.Checked = false;
            Spk2.Checked = false;
            Spk3.Checked = false;
            Lsn1.Checked = false;
            Lsn2.Checked = false;
            Lsn3.Checked = false;
            Lsn4.Checked = false;
            Qry1.Checked = false;
            Cls1.Checked = false;
            Cls2.Checked = false;

            No_swt.Checked = false;
            Bad_swt.Checked = false;
            Call_Type.SelectedIndex = 0;

            Remarks.Text = "";
            Inv_link.Text = "";
            //sound_add.Text = "";
            //Call_Duration.Text = "";
            //Call_Duration_Sec.Text = "";
            //file_size.Text = "";
            ////////////////////////////////////// Reset Memory Stream ms
            ms.Position = 0;
            ms.SetLength(0);
            ////////////////////////////////////// End Reset
            taboo.Checked = false;
            handling_time = 0;
            handle_TM.Text = "";
            Insert_Date.Text = "";
            Insert_Time.Text = "";
            WaveOut.Dispose();

            ////////////////////////////////// voice DT reset
            voice_dt.Clear();
            radGridView1.DataSource = null;
            radGridView1.DataSource = voice_dt;
            radGridView1.Columns[4].IsVisible = false;
            radGridView1.Columns[5].IsVisible = false;
            errorProvider.Clear();
            timer1.Stop();
            handling_time = 0;
            handle_TM.Text = "";


        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LOG_ENTRY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                radMenuItem1_Click(null,null);
            }
            else if (e.KeyCode == Keys.F10)
            {
                radMenuItem2_Click(null, null);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (voice_dt.Rows.Count != 0)
            {
                if (WaveOut.PlaybackState == PlaybackState.Playing)
                {
                    btnPlay.Image = Properties.Resources.Media_Controls_Play_icon;
                    WaveOut.Pause();
                }
                else if (WaveOut.PlaybackState == PlaybackState.Paused || WaveOut.PlaybackState == PlaybackState.Stopped)
                {
                    btnPlay.Image = Properties.Resources.Media_Controls_Pause_icon;
                    WaveOut.Play();
                }
            }
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            if (timer1.Enabled != true && QC_ID.Text == "")
            {
                timer1.Interval = 1000;
                timer1.Start();
            }

            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "MP3 Files |*.MP3";
            if (op.ShowDialog() == DialogResult.OK)
            {
                string sound_add = op.FileName;
                if (sound_add != "")
                {
                    var loading = new Loading();
                    loading.label1.Text = "در حال تبدیل فایل. شکیبا باشید...";
                    loading.Show();

                    Mp3FileReader wf = new Mp3FileReader(sound_add);
                    string call_duration = wf.TotalTime.ToString(@"mm\:ss");
                    //Call_Duration_Sec.Text = (int.Parse(wf.TotalTime.ToString(@"ss")) + (int.Parse(wf.TotalTime.ToString(@"mm")) * 60) + (int.Parse(wf.TotalTime.ToString(@"hh")) * 3600)).ToString();
                    /////////////////////////////////////////////////////////// Get File Size
                    string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                    double len = new FileInfo(sound_add).Length;
                    int order = 0;
                    while (len >= 1024 && order < sizes.Length - 1)
                    {
                        order++;
                        len = len / 1024;
                    }
                    string file_size = String.Format("{0:0.##} {1}", len, sizes[order]); ;
                    
                    //////////////////////////////////////// Fill Voice DT
                    DataRow newrow = voice_dt.NewRow();
                    newrow["ردیف"] = (voice_dt.Rows.Count + 1).ToString();
                    newrow["نام فایل"] = (Path.GetFileName(op.FileName)).ToString().Substring(0, (Path.GetFileName(op.FileName)).Length - 4);
                    newrow["مدت مکالمه"] = call_duration;
                    newrow["حجم فایل"] = file_size;
                    newrow["آدرس فایل"] = op.FileName;
                    newrow["byte"] = ReadFile(op.FileName);
                    voice_dt.Rows.Add(newrow);
                    radGridView1.Columns[4].IsVisible = false;
                    radGridView1.BestFitColumns();
                    Total_Vce_Duration.Text = TimeSpan.FromSeconds(calculate_log_duration()).ToString(@"mm\:ss");
                    loading.Close();
                }
            }
        }

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            ms.Position = 0;
            WaveOut.Stop();
            btnPlay.Image = Properties.Resources.Media_Controls_Play_icon;
        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (radGridView1.SelectedRows.Count != 0)
                {
                    WaveOut.Stop();
                    ////////////////////////////////////// Reset Memory Stream ms
                    ms.Position = 0;
                    ms.SetLength(0);
                    ////////////////////////////////////// End Reset

                    ms.Write(ReadFile(voice_dt.Rows[radGridView1.SelectedRows[0].Index][4].ToString()), 0, ReadFile(voice_dt.Rows[radGridView1.SelectedRows[0].Index][4].ToString()).Length);
                    ms.Position = 0;
                    Mp3FileReader mp3_rdr = new Mp3FileReader(ms);
                    WaveOut.Dispose();
                    WaveOut.Init(mp3_rdr);
                }
            }
            catch
            {

            }
        }

        public void voice_DT_reorder()
        {
            for (int i = 0; i < voice_dt.Rows.Count; i++)
            {
                voice_dt.Rows[i][0] = (i + 1).ToString();
                voice_dt.AcceptChanges();
            }
            radGridView1.DataSource = voice_dt;
        }

        private void radGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && QC_ID.Text == "")
            {
                Point p = (sender as Control).PointToScreen(e.Location);
                radContextMenu1.Show(p.X, p.Y);
            }
        }

        public void DEL_CLICK(object sender, EventArgs e)
        {
            if (radGridView1.Rows.Count != 0)
            {
                int selected = radGridView1.SelectedRows[0].Index;
                radGridView1.Rows[selected].Delete();
                voice_dt.AcceptChanges();
                voice_DT_reorder();
                calculate_log_duration();
            }
        }

        public int calculate_log_duration()
        {
            int tot_duration = 0;
            for (int i=0; i<voice_dt.Rows.Count; i++)
            {
                tot_duration = tot_duration + int.Parse(TimeSpan.Parse("00:" + voice_dt.Rows[i][2].ToString()).TotalSeconds.ToString());
            }
            //MessageBox.Show(tot_duration.ToString());
            Total_Vce_Duration.Text = TimeSpan.FromSeconds(tot_duration).ToString(@"mm\:ss");
            return tot_duration;
        }

        private void Log_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Log_Type.Text != "")
            {
                DataTable dt5 = new DataTable();
                OleDbDataAdapter adp5 = new OleDbDataAdapter();
                adp5.SelectCommand = new OleDbCommand();
                adp5.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand5 = "SELECT [AMW] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_PLAN] where [plan_id] = '" + Log_Type.SelectedValue.ToString() + "'";
                adp5.SelectCommand.CommandText = lcommand5;
                adp5.Fill(dt5);
                amw_sec = int.Parse(dt5.Rows[0][0].ToString());
            }
            else
            {
                amw_sec = 0;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = " Select Sel1.[QC_Agent] 'کارشناس', COUNT(sel1.[QC_ID]) 'کل لاگ ها',SUM(sel3.[LOG_QTY]) 'کل فایل ها',SUM(CASE WHEN sel1.[QC_Score]<=17 then 1 else 0 end) 'ناموفق',SUM(CASE WHEN sel1.[QC_Score] >17 then 1 else 0 end) 'موفق' ,SUM(CASE WHEN sel1.[CC_M_Aprv_Usr] = N'عدم تائید کیفی' then 1 else 0 end) 'رد کیفی', AVG(sel1.[Handling_tm]) 'AHT', AVG(Sel1.[Handling_tm] - Sel2.[Len]) 'AMW' " +
                              " ,CAST(round(convert(float,SUM(CASE WHEN sel2.[Len] <= 30   then 1 else 0 end))/COUNT(sel1.[QC_ID]),4)*100 as nvarchar(5)) + '%' '0 ~ 30', CAST(round(convert(float,SUM(CASE WHEN sel2.[Len] <= 60 and sel2.[Len] > 30   then 1 else 0 end))/COUNT(sel1.[QC_ID]),4)*100 as nvarchar(5)) + '%' '30 ~ 60', CAST(round(convert(float,SUM(CASE WHEN sel2.[Len] <= 90 and sel2.[Len] > 60   then 1 else 0 end))/COUNT(sel1.[QC_ID]),4)*100 as nvarchar(5)) + '%' '60 ~ 90', CAST(round(convert(float,SUM(CASE WHEN sel2.[Len] > 90   then 1 else 0 end))/COUNT(sel1.[QC_ID]),4)*100 as nvarchar(5)) + '%' 'Over 90'   from ( " +
                              " (SELECT [QC_ID],[Handling_tm],[taboo],[QC_M_Approval],[QC_Agent],[QC_Score],[CC_M_Aprv_Usr],[insrt_dt] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS]) Sel1 " +
                              " left join (SELECT [QC_ID], sum((SUBSTRING([Voice_len], 1, 2) * 60) + SUBSTRING([Voice_len], 4, 2)) AS 'Len' FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_VOICES] group by [QC_ID]) Sel2 " +
                              " on Sel1.[QC_ID] = Sel2.[QC_ID] " +
                              "left join (SELECT [QC_ID], count([QC_ID]) 'LOG_QTY' FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_VOICES] group by [QC_ID]) Sel3 on Sel1.[QC_ID] = Sel3.[QC_ID] " +
                              ") WHERE Sel1.[insrt_dt] = convert(date, getdate(), 111) and sel1.[QC_Agent] = N'" + user + "' group by Sel1.[QC_Agent] ";
            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);
            if (dt22.Rows.Count == 1)
            {
                List<string> conditions = new List<string>();
                for (int i = 0; i < dt22.Rows.Count; i++)
                {
                    if (int.Parse(dt22.Rows[i][1].ToString()) > 30)
                    {
                        if (float.Parse(dt22.Rows[i][8].ToString().Replace("%", "")) > cap_0_30 + 1)
                        {
                            float[] set = { cap_30_60 - float.Parse(dt22.Rows[i][9].ToString().Replace("%", "")), cap_60_90 - float.Parse(dt22.Rows[i][10].ToString().Replace("%", "")), cap_ov_90 - float.Parse(dt22.Rows[i][11].ToString().Replace("%", "")) };
                            int max_index = Array.IndexOf(set, set.Max());
                            conditions.Add((max_index == 0 ? "30~60" : (max_index == 1 ? "60~90" : ">90")));
                            continue;

                        }
                        if (float.Parse(dt22.Rows[i][9].ToString().Replace("%", "")) > cap_30_60 + 1)
                        {
                            float[] set = { cap_0_30 - float.Parse(dt22.Rows[i][8].ToString().Replace("%", "")), cap_60_90 - float.Parse(dt22.Rows[i][10].ToString().Replace("%", "")), cap_ov_90 - float.Parse(dt22.Rows[i][11].ToString().Replace("%", "")) };
                            int max_index = Array.IndexOf(set, set.Max());
                            conditions.Add((max_index == 0 ? "0~30" : (max_index == 1 ? "60~90" : ">90")));
                            continue;
                        }
                        if (float.Parse(dt22.Rows[i][10].ToString().Replace("%", "")) > cap_60_90 + 1)
                        {
                            float[] set = { cap_0_30 - float.Parse(dt22.Rows[i][8].ToString().Replace("%", "")), cap_30_60 - float.Parse(dt22.Rows[i][9].ToString().Replace("%", "")), cap_ov_90 - float.Parse(dt22.Rows[i][11].ToString().Replace("%", "")) };
                            int max_index = Array.IndexOf(set, set.Max());
                            conditions.Add((max_index == 0 ? "0~30" : (max_index == 1 ? "30~60" : ">90")));
                            continue;
                        }
                        if (float.Parse(dt22.Rows[i][11].ToString().Replace("%", "")) > cap_ov_90 + 1)
                        {
                            float[] set = { cap_0_30 - float.Parse(dt22.Rows[i][8].ToString().Replace("%", "")), cap_30_60 - float.Parse(dt22.Rows[i][9].ToString().Replace("%", "")), cap_60_90 - float.Parse(dt22.Rows[i][10].ToString().Replace("%", "")) };
                            int max_index = Array.IndexOf(set, set.Max());
                            conditions.Add((max_index == 0 ? "0~30" : (max_index == 1 ? "30~60" : "60~90")));
                            continue;
                        }
                    }
                }
                if (conditions.Count != 0)
                {
                    string test_label = string.Join("", conditions.ToArray());
                    radDesktopAlert1.CaptionText = "<html><span><color=Red><b>" + "سامانه هوشمند هدایت مانیتورینگ کارشناسان کیفی" + "</b></span></html>";
                    radDesktopAlert1.ContentText = user + " عزیز" + "\n" + "خسته نباشید." + "\n\n" + "بهترین لاگ برای شما جهت ادامه مانیتورینگ، گروه " + test_label + " می باشد." + "\n\n";
                    this.radDesktopAlert1.Popup.AlertElement.ContentElement.Font = new Font("Tahoma" , 9);
                    this.radDesktopAlert1.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.Font = new Font("Tahoma", 9);

                    radDesktopAlert1.Popup.LocationChanged += Popup_LocationChanged;
                    radDesktopAlert1.Show();
                }
            }
        }

        private void Popup_LocationChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.DesktopAlertPopup popup = sender as Telerik.WinControls.UI.DesktopAlertPopup;
            if (p == Point.Empty)
            {
                p = popup.Location;
            }
            else
            {
                radDesktopAlert1.Popup.LocationChanged -= Popup_LocationChanged;
                radDesktopAlert1.Popup.Location = p;
                radDesktopAlert1.Popup.LocationChanged += Popup_LocationChanged;
            }
        }
    }
}
