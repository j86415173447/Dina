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
    public partial class TRN_COURSE_MASTER : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        private ErrorProvider errorProvider;
        public bool data_error = false;

        public TRN_COURSE_MASTER()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void TRN_COURSE_MASTER_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            ///////////////////////////////////////////////////////// initializing training item
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '' 'CRS_Type' union SELECT N'حضوری' 'CRS_Type' union SELECT N'غیر حضوری' 'CRS_Type'";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            CRS_Type.DataSource = dt4;
            CRS_Type.DisplayMember = "CRS_Type";


            update_grid();
        }

        private void update_grid()
        {
            grid.DataSource = null;
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT [CRS_CD]'کد دوره',[CRS_Name]'نام دوره',[CRS_Period]'مدت',[CRS_Type]'نوع دوره',[Insrt_Usr]'ایجاد کننده' FROM [SNAPP_CC_EVALUATION].[dbo].[TRN_COURSE_MASTER]";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            grid.DataSource = dt1;
            if (dt1.Rows.Count != 0)
            {
                grid.BestFitColumns();
            }
        }

        private void grid_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            CRS_CD.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
            CRS_NM.Text = grid.SelectedRows[0].Cells[1].Value.ToString();
            Period.Text = grid.SelectedRows[0].Cells[2].Value.ToString();
            CRS_Type.Text = grid.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (CRS_CD.Text != "") /////////////////////////////////////// Amend Mode
            {
                ////////////////////////////////////////////// Required field check
                if (!this.AreRequiredFieldsValid())
                {
                    return;
                }
                else
                {
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[TRN_Course_Master] SET [CRS_Name] = ?,[CRS_Period] = ?,[Insrt_Usr] = ?, [CRS_Type] = ?  WHERE [CRS_CD] = '" + CRS_CD.Text + "'";
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", CRS_NM.Text);
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", Period.Text);
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", user);
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", CRS_Type.Text);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    update_grid();
                    clear_frm();
                    RadMessageBox.Show(this, "تغییرات ثبت شد", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
            }
            else /////////////////////////////////////// Add Mode
            {
                if (!this.AreRequiredFieldsValid())
                {
                    return;
                }
                else
                {
                    /////////////////////////////////////////////////// Get CRS_CD
                    DataTable dt1 = new DataTable();
                    OleDbDataAdapter adp1 = new OleDbDataAdapter();
                    adp1.SelectCommand = new OleDbCommand();
                    adp1.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommand1 = "SELECT max([CRS_CD]) from [SNAPP_CC_EVALUATION].[dbo].[TRN_Course_Master]";
                    adp1.SelectCommand.CommandText = lcommand1;
                    adp1.Fill(dt1);
                    string CD_result = "";
                    if (dt1.Rows[0][0].ToString() == "")
                    {
                        CD_result = "001";
                    }
                    else
                    {
                        int temp = int.Parse(dt1.Rows[0][0].ToString().Replace("CRS", ""));
                        temp = temp + 1;
                        if (temp <10)
                        {
                            CD_result = "00" + temp.ToString();
                        }
                        else if (temp >= 10 && temp <100)
                        {
                            CD_result = "0" + temp.ToString();
                        }
                        else if (temp >= 100)
                        {
                            CD_result = temp.ToString();
                        }
                    }
                    CRS_CD.Text = "CRS" + CD_result;
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "Insert INTO [SNAPP_CC_EVALUATION].[dbo].[TRN_Course_Master] ([CRS_CD],[CRS_Name],[CRS_Period],[CRS_Type],[Insrt_Usr],[Insrt_Dt],[Insrt_tm]) Values (?,?,?,?,?,getdate(),getdate())";
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", CRS_CD.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", CRS_NM.Text);
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", Period.Text);
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", CRS_Type.Text);
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", user);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    update_grid();
                    clear_frm();
                    RadMessageBox.Show(this, "دوره جدید ثبت شد", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
            }
        }

        private bool AreRequiredFieldsValid()
        {
            data_error = false;
            if (CRS_NM.Text == "")
            {
                this.errorProvider.SetError(this.CRS_NM, "نام دوره وارد نشده است");
                data_error = true;
            }
            if (Period.Text == "")
            {
                this.errorProvider.SetError(this.Period, "مدت دوره وارد نشده است");
                data_error = true;
            }
            if (CRS_Type.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.CRS_Type, "نوع دوره انتخاب نشده است");
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

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            clear_frm();
        }

        private void clear_frm()
        {
            CRS_CD.Text = "";
            CRS_NM.Text = "";
            Period.Text = "";
            CRS_Type.SelectedIndex = 0;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
