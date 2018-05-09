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
    public partial class TRN_REGISTRATION : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        public string To_Reg_Doc_No;
        public string To_Reg_Per_Nm;
        public string crs_cd;

        public TRN_REGISTRATION()
        {
            InitializeComponent();
            CLS_Cap.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_CD.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_DTs.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_From.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Reg.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Stat.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Rem.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_To.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Trainer.TextAlignment = ContentAlignment.MiddleLeft;
            CRS_NM.TextAlignment = ContentAlignment.MiddleLeft;
            CLS_Loc.TextAlignment = ContentAlignment.MiddleLeft;
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void TRN_REGISTRATION_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
        }

        public void Register()
        {
            if (CLS_CD.Text != "")
            {
                ////////////////////////////////////////// check if already registered
                DataTable reg_dt = new DataTable();
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand();
                adp.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand = "SELECT [CLS_CD],[Doc_No],[CRS_CD],[Per_Result] FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] where [CRS_CD] = '" + crs_cd + "' and [doc_no] = '" + To_Reg_Doc_No + "' and ([Per_Result] = 1 or [Per_result] is null)";
                adp.SelectCommand.CommandText = lcommand;
                reg_dt.Clear();
                adp.Fill(reg_dt);
                if (reg_dt.Rows.Count != 0)
                {
                    if (reg_dt.Rows[0][0].ToString() == CLS_CD.Text && reg_dt.Rows[0][3].ToString() == "")
                    {
                        RadMessageBox.Show(this, " این فرد قبلا در این کلاس ثبت نام شده است.  " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                    else if (reg_dt.Rows[0][3].ToString() == "True")
                    {
                        RadMessageBox.Show(this, "  این فرد قبلا این دوره آموزشی را با موفقیت گذرانده است.  " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                    else if (reg_dt.Rows[0][0].ToString() != CLS_CD.Text)
                    {
                        RadMessageBox.Show(this, "  این فرد قبلا در کلاس  " + reg_dt.Rows[0][0].ToString() + " در این دوره ثبت نام کرده است." + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                }
                else
                {
                    ////////////////////////////////////////////// INSERT INTO TRN_CLASSES TBL
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] ([CLS_Cd],[CRS_CD],[Doc_No],[Per_Nm],[Insrt_Usr],[Insrt_DT],[Insrt_Tm]) values (?,?,?,?,?,getdate(),getdate())";
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CD", CLS_CD.Text);
                    oleDbCommand1.Parameters.AddWithValue("@CLS_CAPACITY", crs_cd);
                    oleDbCommand1.Parameters.AddWithValue("@CLS_Location", To_Reg_Doc_No);
                    oleDbCommand1.Parameters.AddWithValue("@CLS_Course_Cd", To_Reg_Per_Nm);
                    oleDbCommand1.Parameters.AddWithValue("@CLS_Insrt_USR", user);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    Search();
                    update_grid();
                }
            }
            else
            {
                RadMessageBox.Show(this, "  ابتدا یک کلاس انتخاب نمائید.  " + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            Training.Search_Class ob = new Training.Search_Class(this);
            ob.constr = constr;
            ob.ShowDialog();
        }

        public void update_grid()
        {
            DataTable temp_dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT ROW_NUMBER() OVER(ORDER BY [Doc_No] ASC) AS 'ردیف',[Doc_No] 'شماره پرونده',[Per_Nm] 'نام و نام خانوادگی',[Insrt_Usr]'ثبت نام کننده' FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] where [CLS_CD] = '" + CLS_CD.Text + "'";
            adp.SelectCommand.CommandText = lcommand;
            temp_dt.Clear();
            adp.Fill(temp_dt);
            grid.DataSource = temp_dt;
            grid.BestFitColumns();
        }

        public void Search()
        {
            DataTable search_dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT sel1.[CLS_CD],sel1.[CLS_CAPACITY],isnull(sel2.qty,0) AS 'Reged',(sel1.[CLS_CAPACITY]-isnull(sel2.qty,0)) AS 'REM',sel1.[CLS_Location],sel1.[CLS_Course_Nm],sel1.[CLS_Trainer],sel1.[CLS_From_Time],sel1.[CLS_To_Time],sel1.[CLS_Date],sel1.[CLS_ACTV],sel1.[CLS_Course_Cd] from ( " +
                              "(SELECT[CLS_CD],[CLS_CAPACITY],[CLS_Location],[CLS_Course_Nm],[CLS_Trainer],[CLS_From_Time],[CLS_To_Time],[CLS_Date],[CLS_ACTV],[CLS_Course_Cd] FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASSES]) sel1 " +
                              "left join (SELECT CLS_CD, count([CLS_Cd]) AS QTY FROM[SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] group by[CLS_CD]) sel2 on sel1.[CLS_CD] = sel2.[CLS_CD]) where sel1.[CLS_CD] = '" + CLS_CD.Text + "'";
            adp.SelectCommand.CommandText = lcommand;
            search_dt.Clear();
            adp.Fill(search_dt);
            CLS_Cap.Text = search_dt.Rows[0][1].ToString();
            CLS_DTs.Text = search_dt.Rows[0][9].ToString();
            CLS_From.Text = search_dt.Rows[0][7].ToString().Substring(0,5);
            CLS_Reg.Text = search_dt.Rows[0][2].ToString();
            CLS_Stat.Text = "فعال";
            CLS_Rem.Text = search_dt.Rows[0][3].ToString();
            CLS_To.Text = search_dt.Rows[0][8].ToString().Substring(0, 5);
            CLS_Trainer.Text = search_dt.Rows[0][6].ToString();
            CRS_NM.Text = search_dt.Rows[0][5].ToString();
            CLS_Loc.Text = search_dt.Rows[0][4].ToString();
            if (CLS_DTs.Text.Length > 53)
            {
                CLS_DTs.Font = new Font("Tahoma", 7);
            }
            else
            {
                CLS_DTs.Font = new Font("Tahoma", 9);
            }
            crs_cd = search_dt.Rows[0][11].ToString();
        }

        private void New_Reg_Click(object sender, EventArgs e)
        {
            Training.Search_Staff_Reg ob = new Training.Search_Staff_Reg(this);
            ob.constr = constr;
            ob.ShowDialog();
        }

        private void grid_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            DialogResult dialogResult = RadMessageBox.Show(this,"آیا از حذف " + grid.SelectedRows[0].Cells[2].Value.ToString() + " از این کلاس اطمینان دارید؟ " + "\n", "پیغام", MessageBoxButtons.YesNo, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            if (dialogResult == DialogResult.Yes)
            {
                ////////////////////////////////////////////// Delet from Reg TBL
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "DELETE FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_CLASS_REGISTRATION] WHERE [CLS_CD] = '" + CLS_CD.Text + "' and [Doc_no] = '" + grid.SelectedRows[0].Cells[1].Value.ToString() + "'";
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();              Search();
                update_grid();
            }
        }

        private void CLS_Rem_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(CLS_Rem.Text) <= 0)
            {
                New_Reg.Enabled = false;
                New_Reg.Text = "ظرفیت تکمیل است";
            }
            else
            {
                New_Reg.Enabled = true;
                New_Reg.Text = "ثبت نام جدید";
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
