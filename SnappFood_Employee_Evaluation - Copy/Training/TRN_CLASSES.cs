using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;

namespace SnappFood_Employee_Evaluation.Training
{
    public partial class TRN_CLASSES : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public bool data_error;
        public int period;
        private ErrorProvider errorProvider;
        public List<string> datesarray = new List<string>();

        public TRN_CLASSES()
        {
            InitializeComponent();
            session_qty.TextAlignment = ContentAlignment.MiddleCenter;
            CLS_DTs.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_CD.TextAlignment = ContentAlignment.MiddleCenter;
            CRS_NM.TextAlignment = ContentAlignment.MiddleLeft;
            CRS_CD.TextAlignment = ContentAlignment.MiddleLeft;
            CRS_Type.TextAlignment = ContentAlignment.MiddleLeft;
            from_tm.TextAlign = HorizontalAlignment.Center;
            to_tm.TextAlign = HorizontalAlignment.Center;
            EXM_TM.TextAlign = HorizontalAlignment.Center;
            EXM_DT.TextAlign = HorizontalAlignment.Center;
            date_in.TextAlign = HorizontalAlignment.Center;

            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void TRN_CLASSES_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            date_in.Mask = "0000/00/00";
            EXM_DT.Mask = "0000/00/00";
            ///////////////////////////////////////////////////////// initializing training item
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '' 'Trainer_Name' union SELECT [Trainer_Name] FROM [SNAPP_CC_EVALUATION].[dbo].[CONF_TRAINERS_MASTER] order by [Trainer_Name]";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            Trainer.DataSource = dt4;
            Trainer.DisplayMember = "Trainer_Name";

            //////CLS_Status.SelectedIndex = 0;
        }

        private void date_add_Click(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            if (date_in.MaskFull)
            {
                if (!datesarray.Contains(date_in.Text))
                {
                    if (int.Parse(date_in.Text.Substring(0, 4).ToString()) >= 1300)
                    {
                        datesarray.Add(date_in.Text);
                        CLS_DTs.Text = string.Join(" - ", datesarray.ToArray());
                        session_qty.Text = (datesarray.Count).ToString();
                        date_in.Text = "";
                    }
                    else
                    {
                        this.errorProvider.SetError(this.date_in, "تاریخ صحیح نیست.");
                    }
                }
                else
                {
                    this.errorProvider.SetError(this.date_in, "تاریخ تکراری است.");
                }
            }
        }

        private void date_remove_Click(object sender, EventArgs e)
        {
            if (datesarray.Contains(date_in.Text))
            {
                datesarray.Remove(date_in.Text);
                CLS_DTs.Text = string.Join(" - ", datesarray.ToArray());
                session_qty.Text = (datesarray.Count).ToString();
                date_in.Text = "";
            }
        }

        private void crs_select_Click(object sender, EventArgs e)
        {
            Training.Search_Course ob = new Training.Search_Course(this);
            ob.constr = constr;
            ob.ShowDialog();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if(AreRequiredFieldsValid() && CLS_CD.Text == "")
            {
                //////////////////////////////////////////// Get Class CD
                int doc_no;
                string doc_no_str;
                DataTable dt22 = new DataTable();
                OleDbDataAdapter adp22 = new OleDbDataAdapter();
                adp22.SelectCommand = new OleDbCommand();
                adp22.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand22 = "SELECT max(replace([CLS_CD],'CLS','')),getdate() FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]";
                adp22.SelectCommand.CommandText = lcommand22;
                adp22.Fill(dt22);
                if (dt22.Rows[0][0].ToString() == "")
                {
                    doc_no = 1;
                }
                else
                {
                    doc_no = int.Parse(dt22.Rows[0][0].ToString()) + 1;
                }
                if (doc_no < 10)
                {
                    doc_no_str = "0000" + doc_no.ToString();
                }
                else if (doc_no > 9 && doc_no < 100)
                {
                    doc_no_str = "000" + doc_no.ToString();
                }
                else if (doc_no > 99 && doc_no < 1000)
                {
                    doc_no_str = "00" + doc_no.ToString();
                }
                else if (doc_no > 999 && doc_no < 10000)
                {
                    doc_no_str = "0" + doc_no.ToString();
                }
                else
                {
                    doc_no_str = doc_no.ToString();
                }
                CLS_CD.Text = "CLS" + doc_no_str;

                ////////////////////////////////////////////// INSERT INTO TRN_CLASSES TBL
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES] ([CLS_CD],[CLS_CAPACITY],[CLS_Location],[CLS_Course_Cd],[CLS_Course_Nm],[CLS_Trainer],[CLS_From_Time],[CLS_To_Time],[CLS_Date],[CLS_ACTV]," +
                                            "[CLS_Insrt_DT],[CLS_Insrt_TM],[CLS_Insrt_USR],[CLS_Period],[CLS_Exam_DT],[CLS_Exam_TM]) values (?,?,?,?,?,?,?,?,?,?,getdate(),getdate(),?,?,?,?)";
                oleDbCommand1.Parameters.AddWithValue("@CLS_CD", CLS_CD.Text);
                //oleDbCommand1.Parameters.AddWithValue("@CLS_NM", CLS_NM.Text);
                oleDbCommand1.Parameters.AddWithValue("@CLS_CAPACITY", CLS_CAP.Text);
                oleDbCommand1.Parameters.AddWithValue("@CLS_Location", CLS_Location.Text);
                oleDbCommand1.Parameters.AddWithValue("@CLS_Course_Cd", CRS_CD.Text);
                oleDbCommand1.Parameters.AddWithValue("@CLS_Course_Nm", CRS_NM.Text);
                oleDbCommand1.Parameters.AddWithValue("@CLS_Trainer", Trainer.Text);
                oleDbCommand1.Parameters.AddWithValue("@CLS_From_Time", from_tm.Text);
                oleDbCommand1.Parameters.AddWithValue("@CLS_To_Time", to_tm.Text);
                oleDbCommand1.Parameters.AddWithValue("@CLS_Date", CLS_DTs.Text);
                oleDbCommand1.Parameters.AddWithValue("@CLS_ACTV", 1);
                oleDbCommand1.Parameters.AddWithValue("@CLS_Insrt_USR", user);
                oleDbCommand1.Parameters.AddWithValue("@CLS_Insrt_USR", period);
                oleDbCommand1.Parameters.AddWithValue("@CLS_Insrt_USR", EXM_DT.Text);
                oleDbCommand1.Parameters.AddWithValue("@CLS_Insrt_USR", EXM_TM.Text);
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();

                RadMessageBox.Show(this, "  کلاس با موفقیت ثبت گردید  " + "\n\n" + "  کلاس آماده ثبت نام گردید  " + "\n\n" + "کد کلاس: " + CLS_CD.Text + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private bool AreRequiredFieldsValid()
        {
            data_error = false;
            //if (CLS_NM.Text == "")
            //{
            //    this.errorProvider.SetError(this.CLS_NM, "نام کلاس وارد نشده است");
            //    data_error = true;
            //}
            if (CLS_Location.Text == "")
            {
                this.errorProvider.SetError(this.CLS_Location, "محل کلاس وارد نشده است");
                data_error = true;
            }
            if (CLS_CAP.Text == "")
            {
                this.errorProvider.SetError(this.CLS_CAP, "ظرفیت کلاس وارد نشده است");
                data_error = true;
            }
            if (CRS_CD.Text == "")
            {
                this.errorProvider.SetError(this.radLabel3, "دوره آموزشی انتخاب نشده است");
                data_error = true;
            }
            if (Trainer.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Trainer, "مدرس انتخاب نشده است");
                data_error = true;
            }
            if (CLS_DTs.Text == "")
            {
                this.errorProvider.SetError(this.CLS_DTs, "تاریخ برگزاری کلاس وارد نشده است");
                data_error = true;
            }
            if (from_tm.Text.Replace("_", "").Replace(":","").Length < 4)
            {
                this.errorProvider.SetError(this.from_tm, "ساعت شروع وارد نشده است");
                data_error = true;
            }
            if (to_tm.Text.Replace("_", "").Replace(":", "").Length < 4)
            {
                this.errorProvider.SetError(this.to_tm, "ساعت پایان وارد نشده است");
                data_error = true;
            }
            if (EXM_DT.MaskFull)
            {
                if (int.Parse(EXM_DT.Text.Substring(0, 4).ToString()) <= 1300)
                {
                    this.errorProvider.SetError(this.EXM_DT, "تاریخ آزمون صحیح نیست.");
                    data_error = true;
                }
            }
            else
            {
                this.errorProvider.SetError(this.EXM_DT, "تاریخ آزمون صحیح نیست.");
                data_error = true;
            }
            if (!EXM_TM.MaskFull)
            {
                this.errorProvider.SetError(this.EXM_TM, "ساعت آزمون صحیح نیست.");
                data_error = true; 
            }
            if (data_error == false)
            {
                DateTime from = DateTime.Parse(from_tm.Text);
                DateTime to = DateTime.Parse(to_tm.Text);
                if (((int.Parse(session_qty.Text)) * (to - from).TotalHours) != period)
                {
                    RadMessageBox.Show(this, " مدت کلاس با مدت تعریف شده دوره همخوانی ندارد " + "\n\n" + " مدت تعریف شده دوره: " + period.ToString() + "\n\n" + " مدت کلاس: " + (int.Parse(session_qty.Text)) * (to - from).TotalHours, "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    data_error = true;
                }
                if (data_error == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            datesarray.Clear();
            CLS_CD.Text = "";
            CLS_Location.Text = "اتاق آموزش1";
            CLS_CAP.Text = "";
            Trainer.SelectedIndex = 0;
            CRS_CD.Text = "";
            CRS_NM.Text = "";
            date_in.Text = "";
            CLS_DTs.Text = "";
            session_qty.Text = "";
            from_tm.Text = "";
            to_tm.Text = "";
            //////CLS_Status.SelectedIndex = 0;
        }
    }
}
