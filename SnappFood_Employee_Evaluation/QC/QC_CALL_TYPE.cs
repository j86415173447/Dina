using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;

namespace SnappFood_Employee_Evaluation.QC
{
    public partial class QC_CALL_TYPE : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        private ErrorProvider errorProvider;
        public bool data_error = false;

        public QC_CALL_TYPE()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            RadMessageBox.SetThemeName("Office2010Silver");
        }

        private void TRN_COURSE_MASTER_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
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
            string lcommand1 = "SELECT [Call_Type_id] 'کد نوع تماس',[Call_Type_nm] 'نام نوع تماس',[Call_Type_actv] 'فعال؟',[Insrt_Usr] 'ایجاد کننده' FROM [SNAPP_CC_EVALUATION].[dbo].[QC_Call_Type]";
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
            if (grid.SelectedRows[0].Cells[2].Value.ToString() == "True")
            {
                ACTV.Checked = true;
            }
            else
            {
                ACTV.Checked = false;
            }
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
                    oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[QC_Call_Type] SET [Call_Type_nm] = ?,[Call_Type_actv] = ?, [Insrt_usr] = ?  WHERE [Call_Type_id] = '" + CRS_CD.Text + "'";
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", CRS_NM.Text);
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", ACTV.Checked == true ? "1" : "0");
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", user);
                    //oleDbCommand1.Parameters.AddWithValue("@System_Id", CRS_Type.Text);
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
                    string lcommand1 = "SELECT max([Call_Type_id]) from [SNAPP_CC_EVALUATION].[dbo].[QC_Call_Type]";
                    adp1.SelectCommand.CommandText = lcommand1;
                    adp1.Fill(dt1);
                    string CD_result = "";
                    if (dt1.Rows[0][0].ToString() == "")
                    {
                        CD_result = "001";
                    }
                    else
                    {
                        int temp = int.Parse(dt1.Rows[0][0].ToString().Replace("CTP", ""));
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
                    CRS_CD.Text = "CTP" + CD_result;
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "Insert INTO [SNAPP_CC_EVALUATION].[dbo].[QC_Call_Type] ([Call_Type_id],[Call_Type_nm],[Call_Type_actv],[Insrt_Usr]) Values (?,?,?,?)";
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", CRS_CD.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Doc_No", CRS_NM.Text);
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", ACTV.Checked == true ? "1" : "0");
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", user);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                    update_grid();
                    clear_frm();
                    RadMessageBox.Show(this, "نوع تماس جدید ثبت شد", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
            }
        }

        private bool AreRequiredFieldsValid()
        {
            data_error = false;
            if (CRS_NM.Text == "")
            {
                this.errorProvider.SetError(this.CRS_NM, "نام نوع تماس وارد نشده است");
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
            ACTV.Checked = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
