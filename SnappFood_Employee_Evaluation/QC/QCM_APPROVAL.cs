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

namespace SnappFood_Employee_Evaluation.QC
{
    public partial class QCM_APPROVAL : Telerik.WinControls.UI.RadForm
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
        WaveOutEvent WaveOut = new WaveOutEvent();
        MemoryStream ms = new MemoryStream();
        public DataTable voice_dt = new DataTable();
        public bool coordinator;
        public int min_score;
        public bool no_coord;

        Point p = Point.Empty;
        public WaveFileReader mp3_rdr;


        public QCM_APPROVAL()
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

            QC_Agent.Text = user;

            ////////////////////////////////////////////////////////// Initilizing CAP
            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT [cap_0_30],[cap_30_60],[cap_60_90],[cap_ov_90],[min_suc_log] FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_QC_SETTING]";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            if (dtsc4.Rows.Count != 0)
            {
                min_score = int.Parse(dtsc4.Rows[0][4].ToString());
                min_score = min_score - 1;
            }
            else
            {
                RadMessageBox.Show(this, " بروز خطا در تنظیمات کنترل کیفی! " + "\n" + " لطفا با مدیریت شرکت تماس حاصل نمائید. ", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }

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

            voice_dt.Columns.Add("Byte", typeof(byte[]));

            radGridView1.DataSource = voice_dt;
            radGridView1.Columns[4].IsVisible = false;
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
                string lcommand4 = "SELECT [Department],[Per_Name],[termination],[Position],[coordinator] FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS] WHERE [System_Id] = '" + operator_ext.Text + "'";
                adp4.SelectCommand.CommandText = lcommand4;
                adp4.Fill(dt4);
                if (dt4.Rows.Count != 0)
                {
                    if (true)
                    {
                        operator_nm.Text = dt4.Rows[0][1].ToString();
                        Department.Text = dt4.Rows[0][0].ToString();
                        if (dt4.Rows[0][3].ToString() != "کارشناس")
                        {
                            coordinator = true;
                        }
                        else
                        {
                            coordinator = false;
                        }
                        if (dt4.Rows[0][4].ToString() == "نامشخص")
                        {
                            no_coord = true;
                        }
                        else
                        {
                            no_coord = false;
                        }
                    }
                }
                else
                {
                    this.errorProvider.SetError(this.operator_ext, "همکاری با شماره داخلی وارد شده یافت نشد.");
                    operator_nm.Text = "";
                    Department.Text = "";
                    coordinator = false;
                }
            }
            else
            {
                errorProvider.Clear();
                operator_nm.Text = "";
                Department.Text = "";
                coordinator = false;
            }
        }

        private void operator_ext_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void calculate_score()
        {
            if (!taboo.Checked & !No_Followup.Checked & !Bad_Followup.Checked)
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
                if (Spk4.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][10].ToString());
                }
                if (Qry1.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][11].ToString());
                }
                if (Cls1.Checked)
                {
                    score = score - int.Parse(dt4.Rows[0][12].ToString());
                }
                Call_Score_Final.Text = score.ToString();
            }
            else if (taboo.Checked)
            {
                Call_Score_Final.Text = "0";
            }
            else if (No_Followup.Checked)
            {
                Call_Score_Final.Text = "0";
            }
            else if (Bad_Followup.Checked)
            {
                Call_Score_Final.Text = "9";
            }
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
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

                calculate_score();
                Get_Date();


                ///////////////////////////////////////////////////// UPDATE DB
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] Set " +
                                            "[QC_ID] = ?, [QC_Score] = ?, [Agent_Ext] = ?, [Call_Type_Cd] = ?, [Log_Type_Cd] = ?, [Call_Tm] = ?, [Call_Dt] = ?, [QC_Param_1] = ?, [QC_Param_2] = ? " +
                                            ",[QC_Param_3] = ?, [QC_Param_4] = ?, [QC_Param_5] = ?, [QC_Param_6] = ?, [QC_Param_7] = ?, [QC_Param_8] = ?, [QC_Param_9] = ?, [QC_Param_10] = ?, [QC_Param_11] = ?, [QC_Param_12] = ? " +
                                            ",[Inv_link] = ?, [Remarks] = ?, [taboo] = ?, [QC_M_Approval] = ?, [QC_M_Aprv_Usr] = ?, [QC_M_Aprv_DT] = ?, [CC_M_Approval] = ?, [CC_M_Aprv_Usr] = ?, [CC_M_Aprv_Rmrk] = ?, [CC_M_Aprv_DT] = ? , [LD_M_Approval] = ?, [LD_M_Aprv_Usr] = ?, [LD_M_Aprv_Rmrk] = ?, [LD_M_Aprv_DT] = ? ,[MG_M_Approval] = ? ,[MG_M_Aprv_Usr] = ? ,[MG_M_Aprv_Rmrk] = ? ,[MG_M_Aprv_Dt] = ? ,[Final_Approval] = ? ,[Final_Aprv_Usr] = ? ,[Final_Aprv_Rmrk] = ? ,[Final_Aprv_DT] = ? " +
                                            " , [No_switch] = ?, [Bad_switch] = ?, [No_Followup] = ?, [Bad_Followup] = ? where [QC_ID] = '" + QC_ID.Text + "'";
                oleDbCommand1.Parameters.AddWithValue("@CLS_CD", QC_ID.Text);
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
                if (Spk4.Checked)
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
                oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Inv_link.Text);
                oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Remarks.Text);
                oleDbCommand1.Parameters.AddWithValue("@CLS_CD", taboo.Checked ? "1" : "0");
                /////////////////////////////////////////////////////////////////////////////////////////////// Because of Taboo
                if (int.Parse(Call_Score_Final.Text) <= min_score)
                {
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 1);
                }
                else
                {
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                }
                oleDbCommand1.Parameters.AddWithValue("@CLS_CD", user);
                oleDbCommand1.Parameters.AddWithValue("@CLS_CD", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                if (int.Parse(Call_Score_Final.Text) <= min_score)
                {
                    if (coordinator)
                    {
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "انتقال به کارتابل رهبر");
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "انتقال به کارتابل رهبر");
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "انتقال به کارتابل رهبر");
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
                    else if (no_coord)
                    {
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "انتقال به کارتابل رهبر");
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "انتقال به کارتابل رهبر");
                        oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "انتقال به کارتابل رهبر");
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
                    }

                }
                else
                {
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "عدم تائید کیفی");
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "عدم تائید کیفی");
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "عدم تائید کیفی");
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "عدم تائید کیفی");
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "عدم تائید کیفی");
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "عدم تائید کیفی");
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "عدم تائید کیفی");
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "عدم تائید کیفی");
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "عدم تائید کیفی");
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", 0);
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "عدم تائید کیفی");
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "عدم تائید کیفی");
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", "عدم تائید کیفی");
                }

                ///////////////////////////////////////////////////////////////////////////////////////////////// End of Taboo
                oleDbCommand1.Parameters.AddWithValue("@CLS_CD", No_swt.Checked ? "1" : "0");
                oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Bad_swt.Checked ? "1" : "0");
                oleDbCommand1.Parameters.AddWithValue("@CLS_CD", No_Followup.Checked ? "1" : "0");
                oleDbCommand1.Parameters.AddWithValue("@CLS_CD", Bad_Followup.Checked ? "1" : "0");
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();

                /////////////////////////////////////////////////////////// Delete current sound files
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "DELETE FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_VOICES] where [QC_ID] = '" + QC_ID.Text + "'";
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();

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
                    oleDbCommand1.Parameters.AddWithValue("@Voice", (byte[])voice_dt.Rows[i][4]);
                    oleDbCommand1.Parameters.AddWithValue("@Voice_len", voice_dt.Rows[i][2].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Voice_size", voice_dt.Rows[i][3].ToString());
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                }
                loading.Close();
                if (int.Parse(Call_Score_Final.Text) <= min_score)
                {
                    RadMessageBox.Show(this, "لاگ به شناسه " + QC_ID.Text + " با موفقیت تائید شد." + "\n" + " لاگ به کارتابل مسئول مربوطه در " + Department.Text + " منتقل شد. " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
                else
                {
                    RadMessageBox.Show(this, "لاگ به شناسه " + QC_ID.Text + " با موفقیت به موفق تغییر وضعیت یافت. " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
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
            if (QC_ID.Text == "")
            {
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
            if ((voice_dt.Rows.Count == 0 || radGridView1.Rows.Count == 0) & (No_Followup.Checked == Bad_Followup.Checked))
            {
                this.errorProvider.SetError(this.radButton1, "آرشیو فایل صوتی خالی است.");
                error = true;
            }
            if (error)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Get_Date()
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
        }

        private void taboo_CheckedChanged(object sender, EventArgs e)
        {
            if (taboo.Checked)
            {
                btnTaboo.BackColor = Color.Red;
                btnTaboo.ForeColor = Color.Yellow;
                btnTaboo.Image = Properties.Resources.danger_icon;
            }
            else
            {
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
            QC.QCM_CARTABLE ob = new QC.QCM_CARTABLE(this);
            ob.constr = constr;
            ob.ShowDialog();
        }

        private void LOG_ENTRY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                radMenuItem1_Click(null, null);
            }
            else if (e.KeyCode == Keys.F10)
            {
                radMenuItem2_Click(null, null);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
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
                timer3.Start();
            }
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {

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

                    WaveFileReader wf = new WaveFileReader(sound_add);
                    string call_duration = wf.TotalTime.ToString(@"mm\:ss");

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
                    newrow["Byte"] = ReadFile(op.FileName);
                    voice_dt.Rows.Add(newrow);
                    radGridView1.Columns[4].IsVisible = false;
                    radGridView1.BestFitColumns();

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

        private void radGridView1_SelectionChanged(object sender, EventArgs e) /////////////////////////////////////
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

                    ms.Write((byte[])voice_dt.Rows[radGridView1.SelectedRows[0].Index][4], 0, ((byte[])voice_dt.Rows[radGridView1.SelectedRows[0].Index][4]).Length);
                    ms.Position = 0;
                    this.mp3_rdr = new WaveFileReader(ms);
                    WaveOut.Dispose();
                    WaveOut.Init(mp3_rdr);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
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
            if (e.Button == MouseButtons.Right && QC_ID.Text != "")
            {
                Point p = (sender as Control).PointToScreen(e.Location);
                radContextMenu1.Show(p.X, p.Y);
            }
        }

        public void DEL_CLICK(object sender, EventArgs e)
        {
            int selected = radGridView1.SelectedRows[0].Index;
            radGridView1.Rows[selected].Delete();
            voice_dt.AcceptChanges();
            voice_DT_reorder();
        }

        public void clear()
        {
            QC_ID.Text = "";
            Call_Score_Final.Text = "";
            operator_ext.Text = "";
            call_dt.Text = "";
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
            Spk4.Checked = false;

            No_swt.Checked = false;
            Bad_swt.Checked = false;
            taboo.Checked = false;
            No_Followup.Checked = false;
            Bad_Followup.Checked = false;

            Remarks.Text = "";
            Inv_link.Text = "";

            ////////////////////////////////////// Reset Memory Stream ms
            ms.Position = 0;
            ms.SetLength(0);
            ////////////////////////////////////// End Reset

            handling_time = 0;
            handle_TM.Text = "";
            Insert_Date.Text = "";
            Insert_Time.Text = "";
            WaveOut.Dispose();

            ////////////////////////////////// voice DT reset
            voice_dt.Clear();
            radGridView1.DataSource = null;
            radGridView1.DataSource = voice_dt;
            errorProvider.Clear();
        }

        public void search()
        {
            DataTable dt22 = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT [QC_Score],[Agent_Ext],[Call_Type_Cd],[Log_Type_Cd],[Call_Tm],[Call_Dt],[QC_Param_1],[QC_Param_2],[QC_Param_3],[QC_Param_4],[QC_Param_5],[QC_Param_6],[QC_Param_7],[QC_Param_8],[QC_Param_9],  " +
                              "[QC_Param_10],[QC_Param_11],[QC_Param_12],[Bad_switch],[No_switch],[Inv_link],[Remarks],[Handling_tm],[taboo],[insrt_dt_per],[insrt_tm],[QC_Agent],[No_Followup],[bad_followup]  FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_DOCUMENTS] where [QC_ID] = '" + QC_ID.Text + "'";
            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);

            //////////////////////////////////// fill in the form
            Call_Score_Final.Text = dt22.Rows[0][0].ToString();
            Insert_Date.Text = dt22.Rows[0][24].ToString();
            Insert_Time.Text = dt22.Rows[0][25].ToString();
            operator_ext.Text = dt22.Rows[0][1].ToString();
            QC_Agent.Text = dt22.Rows[0][26].ToString();
            Call_Type.SelectedValue = dt22.Rows[0][2].ToString();
            Log_Type.SelectedValue = dt22.Rows[0][3].ToString();
            call_dt.Text = dt22.Rows[0][5].ToString();
            call_tm.Text = dt22.Rows[0][4].ToString();
            if (dt22.Rows[0][6].ToString() != "True")
            {
                Opn1.Checked = true;
            }
            if (dt22.Rows[0][7].ToString() != "True")
            {
                Opn2.Checked = true;
            }
            if (dt22.Rows[0][8].ToString() != "True")
            {
                Lsn1.Checked = true;
            }
            if (dt22.Rows[0][9].ToString() != "True")
            {
                Lsn2.Checked = true;
            }
            if (dt22.Rows[0][10].ToString() != "True")
            {
                Lsn3.Checked = true;
            }
            if (dt22.Rows[0][11].ToString() != "True")
            {
                Lsn4.Checked = true;
            }
            if (dt22.Rows[0][12].ToString() != "True")
            {
                Spk1.Checked = true;
            }
            if (dt22.Rows[0][13].ToString() != "True")
            {
                Spk2.Checked = true;
            }
            if (dt22.Rows[0][14].ToString() != "True")
            {
                Spk3.Checked = true;
            }
            if (dt22.Rows[0][15].ToString() != "True")
            {
                Spk4.Checked = true;
            }
            if (dt22.Rows[0][16].ToString() != "True")
            {
                Qry1.Checked = true;
            }
            if (dt22.Rows[0][17].ToString() != "True")
            {
                Cls1.Checked = true;
            }
            Remarks.Text = dt22.Rows[0][21].ToString();
            Inv_link.Text = dt22.Rows[0][20].ToString();
            handle_TM.Text = TimeSpan.FromSeconds(int.Parse(dt22.Rows[0][22].ToString())).ToString(@"mm\:ss");
            if (dt22.Rows[0][18].ToString() == "True")
            {
                Bad_swt.Checked = true;
            }
            if (dt22.Rows[0][19].ToString() == "True")
            {
                No_swt.Checked = true;
            }
            if (dt22.Rows[0][23].ToString() == "True")
            {
                taboo.Checked = true;
            } 
            if (dt22.Rows[0][27].ToString() == "True")
            {
                No_Followup.Checked = true;
            }
            if (dt22.Rows[0][28].ToString() == "True")
            {
                Bad_Followup.Checked = true;
            }
            //////////////////////////////////////////// Update voice_DT
            DataTable dt44 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT [Voice],[File_Row],[File_Name],[Voice_len],[Voice_size] FROM [SNAPP_CC_EVALUATION].[dbo].[QC_LOG_VOICES] where [QC_ID] = '" + QC_ID.Text + "'";
            adp2.SelectCommand.CommandText = lcommand2;
            dt44.Clear();
            adp2.Fill(dt44);

            for (int i = 0; i < dt44.Rows.Count; i++)
            {
                DataRow newrow = voice_dt.NewRow();
                newrow["ردیف"] = dt44.Rows[i][1].ToString();
                newrow["نام فایل"] = dt44.Rows[i][2].ToString();
                newrow["مدت مکالمه"] = dt44.Rows[i][3].ToString();
                newrow["حجم فایل"] = dt44.Rows[i][4].ToString();
                newrow["Byte"] = dt44.Rows[i][0];
                voice_dt.Rows.Add(newrow);
            }
            radGridView1.Columns[4].IsVisible = false;
            radGridView1.BestFitColumns();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (radGridView1.SelectedRows.Count != 0)
            {
                WaveOut.Stop();
                ms.Position = 0;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "MP3 files (*.MP3)|*.MP3";
                
                saveFileDialog1.FileName = QC_ID.Text + "_" + radGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                    {
                        ms.CopyTo(fs);
                    }
                }
            }
        }

        private void Inv_link_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                Inv_link.SelectAll();
            }
        }

        private void No_swt_CheckedChanged(object sender, EventArgs e)
        {
            //if (No_swt.Checked)
            //{
            //    btn_no_sw.BackColor = Color.Red;
            //    btn_no_sw.ForeColor = Color.Yellow;
            //    btn_no_sw.Image = Properties.Resources.danger_icon;
            //}
            //else
            //{
            //    btn_no_sw.BackColor = Color.WhiteSmoke;
            //    btn_no_sw.ForeColor = Color.Black;
            //    btn_no_sw.Image = Properties.Resources.small_tick;
            //}
        }

        private void Bad_swt_CheckedChanged(object sender, EventArgs e)
        {
            //if (Bad_swt.Checked)
            //{
            //    btn_bad_sw.BackColor = Color.Red;
            //    btn_bad_sw.ForeColor = Color.Yellow;
            //    btn_bad_sw.Image = Properties.Resources.danger_icon;
            //}
            //else
            //{
            //    btn_bad_sw.BackColor = Color.WhiteSmoke;
            //    btn_bad_sw.ForeColor = Color.Black;
            //    btn_bad_sw.Image = Properties.Resources.small_tick;
            //}
        }

        private void Bad_Followup_CheckedChanged(object sender, EventArgs e)
        {
            //if (Bad_Followup.Checked)
            //{
            //    BAD_FW_btn.BackColor = Color.Red;
            //    BAD_FW_btn.ForeColor = Color.Yellow;
            //    BAD_FW_btn.Image = Properties.Resources.danger_icon;
            //}
            //else
            //{
            //    BAD_FW_btn.BackColor = Color.WhiteSmoke;
            //    BAD_FW_btn.ForeColor = Color.Black;
            //    BAD_FW_btn.Image = Properties.Resources.small_tick;
            //}
        }

        private void No_Followup_CheckedChanged(object sender, EventArgs e)
        {
            //if (No_Followup.Checked)
            //{
            //    NO_FW_btn.BackColor = Color.Red;
            //    NO_FW_btn.ForeColor = Color.Yellow;
            //    NO_FW_btn.Image = Properties.Resources.danger_icon;
            //}
            //else
            //{
            //    NO_FW_btn.BackColor = Color.WhiteSmoke;
            //    NO_FW_btn.ForeColor = Color.Black;
            //    NO_FW_btn.Image = Properties.Resources.small_tick;
            //}
        }

        private void btn_bad_sw_Click(object sender, EventArgs e)
        {
            if (Bad_swt.Checked)
            {
                Bad_swt.Checked = false;
            }
            else
            {
                Bad_swt.Checked = true;
                No_swt.Checked = false;
            }
        }

        private void btn_no_sw_Click(object sender, EventArgs e)
        {
            if (No_swt.Checked)
            {
                No_swt.Checked = false;
            }
            else
            {
                No_swt.Checked = true;
                Bad_swt.Checked = false;
            }
        }

        private void BAD_FW_btn_Click(object sender, EventArgs e)
        {
            if (Bad_Followup.Checked)
            {
                Bad_Followup.Checked = false;
            }
            else
            {
                Bad_Followup.Checked = true;
                No_Followup.Checked = false;
            }
        }

        private void NO_FW_btn_Click(object sender, EventArgs e)
        {
            if (No_Followup.Checked)
            {
                No_Followup.Checked = false;
            }
            else
            {
                No_Followup.Checked = true;
                Bad_Followup.Checked = false;
            }
        }

        private void btnTaboo_Click_1(object sender, EventArgs e)
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

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (WaveOut != null && mp3_rdr != null)
            {
                TimeSpan currentTime = (WaveOut.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : mp3_rdr.CurrentTime;
                trackbar1.Value = Math.Min(trackbar1.Maximum, (int)(100 * currentTime.TotalSeconds / mp3_rdr.TotalTime.TotalSeconds));
                //labelCurrentTime.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes,
                //    currentTime.Seconds);
            }
            else
            {
                trackbar1.Value = 0;
            }
        }

        private void trackbar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (mp3_rdr != null)
            {
                //MessageBox.Show(WaveOut.GetPosition().ToString());
                //MessageBox.Show(wf.Length.ToString());
                //ms.Position = ms.Length / (100/trackBar1.Value);
                mp3_rdr.CurrentTime = TimeSpan.FromSeconds(mp3_rdr.TotalTime.TotalSeconds * trackbar1.Value / 100.0);
            }
        }

        private void radGridView1_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {

        }

        private void radGridView1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }
    }
}
