using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using Excel;
using System.IO;
using OpenXmlPackaging;
using System.Globalization;

namespace SnappFood_Employee_Evaluation.System_Managment
{
    public partial class GEN_SALARY_UPLOAD : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataSet dataSet = new DataSet();
        
        public GEN_SALARY_UPLOAD()
        {
            InitializeComponent();
            pictureBox1.TextAlignment = ContentAlignment.MiddleCenter;
            address.TextAlignment = ContentAlignment.MiddleLeft;
            File_Status.TextAlignment = ContentAlignment.MiddleLeft;
            RadMessageBox.ThemeName = "Office2010Silver";
        }

        private void GEN_HCC_SETTING_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            RadMessageBox.ThemeName = "Office2010Silver";
            /////////////////////////////////////// Get Date
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT day(GETDATE()), month(GETDATE()), year(GETDATE()) FROM [SNAPP_CC_EVALUATION].[dbo].[PER_DOCUMENTS]";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            DateTime datetime = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
            ///////////////////////////////////////// Convert Persian
            PersianCalendar psdate = new PersianCalendar();
            yr.Items.Add("");
            yr.Items.Add((psdate.GetYear(datetime) - 1).ToString());
            yr.Items.Add((psdate.GetYear(datetime)).ToString());
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                address.Text = fileDialog.FileName.ToString();
                pictureBox1.Visible = true;
                pictureBox1.Refresh();
                pictureBox1.Update();
                try
                {
                    dataSet.Clear();
                    FileStream stream = File.Open(fileDialog.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    dataSet = excelReader.AsDataSet();
                    excelReader.Close();

                    if (dataSet.Tables[0].Columns.Count != 27)
                    {
                        pictureBox1.Visible = false;
                        RadMessageBox.Show(this, " تعداد ستون های فراخوانی شده در فایل انتخابی " + (dataSet.Tables[0].Columns.Count).ToString() + " می باشد. " + "\n\n" + " تعداد ستون های مجاز 27 است. ", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                    else
                    {

                        int index = 0;
                        foreach (DataColumn col in dataSet.Tables[0].Columns)
                        {
                            col.ColumnName = dataSet.Tables[0].Rows[0][index].ToString();
                            index++;
                        }
                        dataSet.Tables[0].Rows[0].Delete();
                        grid.DataSource = dataSet.Tables[0];
                        //grid.BestFitColumns();

                        if (check_file())
                        {
                            pictureBox1.Visible = false;
                            RadMessageBox.Show(this, "فایل انتخابی با موفقیت فراخوانی گردید." + "\n\n" + " تعداد رکوردهای فراخوانی شده:  " + (dataSet.Tables[0].Rows.Count - 1).ToString(), "خطا", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                        }
                    }
                }
                catch (Exception ew)
                {
                    MessageBox.Show(ew.ToString());
                }
                pictureBox1.Visible = false;
            }
        }

        public bool check_file()
        {
            bool error = false;
            //List<string> err_list = new List<string>();
            if (dataSet.Tables[0].Columns[0].ColumnName == "System_Id" & dataSet.Tables[0].Columns[1].ColumnName == "Working_Days" & dataSet.Tables[0].Columns[2].ColumnName == "Base_Salary" & dataSet.Tables[0].Columns[3].ColumnName == "Child_Allowance" & dataSet.Tables[0].Columns[4].ColumnName == "Subsidy" &
            dataSet.Tables[0].Columns[5].ColumnName == "House_Allowance" & dataSet.Tables[0].Columns[6].ColumnName == "Performance_Bonus" &
            
            dataSet.Tables[0].Columns[7].ColumnName == "Holy_Work" & dataSet.Tables[0].Columns[8].ColumnName == "Holy_Work_Amt" &
            dataSet.Tables[0].Columns[9].ColumnName == "Low_Work" & dataSet.Tables[0].Columns[10].ColumnName == "Low_Work_Amt" &
            dataSet.Tables[0].Columns[11].ColumnName == "X3_Over_Time" & dataSet.Tables[0].Columns[12].ColumnName == "X3_Over_Time_Amt" &
            dataSet.Tables[0].Columns[13].ColumnName == "Normal_Over_Time" & dataSet.Tables[0].Columns[14].ColumnName == "Normal_Over_Time_Amt" &
            
            dataSet.Tables[0].Columns[15].ColumnName == "Over_Time" & dataSet.Tables[0].Columns[16].ColumnName == "Salary_Diff" & dataSet.Tables[0].Columns[17].ColumnName == "Total_Pay"
            & dataSet.Tables[0].Columns[18].ColumnName == "Insurance" & dataSet.Tables[0].Columns[19].ColumnName == "Taxt" & dataSet.Tables[0].Columns[20].ColumnName == "Attence_Reduction" 
            & dataSet.Tables[0].Columns[21].ColumnName == "Penalty" & dataSet.Tables[0].Columns[22].ColumnName == "QC_Penalty"
            & dataSet.Tables[0].Columns[23].ColumnName == "Comp_Insurance" & dataSet.Tables[0].Columns[24].ColumnName == "Advance_Payment" & dataSet.Tables[0].Columns[25].ColumnName == "Total_Reduction" & dataSet.Tables[0].Columns[26].ColumnName == "Payable")
            {
                error = false;
            }
            else
            {
                error = true;
            }

            for (int i = 1; i < dataSet.Tables[0].Rows.Count; i++)
            {
                for (int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                {
                    if (dataSet.Tables[0].Rows[i][j].GetType() != typeof(int) & dataSet.Tables[0].Rows[i][j].GetType() != typeof(float) & dataSet.Tables[0].Rows[i][j].GetType() != typeof(double))
                    {
                        if (dataSet.Tables[0].Rows[i][j].ToString() != "-")
                        {
                            error = true;
                        }
                    }
                }
            }

            if (error)
            {
                File_Status.Text = "غیر قابل قبول";
                File_Status.ForeColor = Color.Red;
                pictureBox1.Visible = false;
                RadMessageBox.Show(this, " ترتیب ستون ها یا صحت اطلاعات مندرج در فایل انتخابی صحیح نیست. " + "\n" + " لطفا ایرادات مشخص شده را در فایل انتخابی بر طرف نموده و مجددا نسبت به آپلود آن اقدام نمائید. ", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                return false;
            }
            else
            {
                File_Status.Text = "قابل قبول";
                File_Status.ForeColor = Color.Green;
                return true;
            }

        }

        private void grid_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "System_Id" || e.CellElement.ColumnInfo.Name == "Working_Days" || e.CellElement.ColumnInfo.Name == "Base_Salary" || e.CellElement.ColumnInfo.Name == "Child_Allowance" || e.CellElement.ColumnInfo.Name == "Subsidy" ||
                e.CellElement.ColumnInfo.Name == "House_Allowance" || e.CellElement.ColumnInfo.Name == "Performance_Bonus" ||

                e.CellElement.ColumnInfo.Name == "Holy_Work_Amt" || e.CellElement.ColumnInfo.Name == "Low_Work_Amt" ||
                e.CellElement.ColumnInfo.Name == "X3_Over_Time_Amt" || e.CellElement.ColumnInfo.Name == "Normal_Over_Time_Amt" ||

                e.CellElement.ColumnInfo.Name == "Over_Time" || e.CellElement.ColumnInfo.Name == "Salary_Diff" || e.CellElement.ColumnInfo.Name == "Total_Pay"
                || e.CellElement.ColumnInfo.Name == "Insurance" || e.CellElement.ColumnInfo.Name == "Taxt" || e.CellElement.ColumnInfo.Name == "Attence_Reduction" || e.CellElement.ColumnInfo.Name == "Penalty" || e.CellElement.ColumnInfo.Name == "QC_Penalty"
                || e.CellElement.ColumnInfo.Name == "Comp_Insurance" || e.CellElement.ColumnInfo.Name == "Advance_Payment" || e.CellElement.ColumnInfo.Name == "Total_Reduction" || e.CellElement.ColumnInfo.Name == "Payable")
            {
                if (e.CellElement.Value.GetType() != typeof(int) & e.CellElement.Value.GetType() != typeof(float) & e.CellElement.Value.GetType() != typeof(double))
                {
                    if (e.CellElement.Value.ToString() != "-")
                    {
                        e.CellElement.DrawFill = true;
                        e.CellElement.BackColor = Color.OrangeRed;
                        e.CellElement.NumberOfColors = 1;
                    }
                    else
                    {
                        e.CellElement.DrawFill = true;
                        e.CellElement.BackColor = Color.White;
                        e.CellElement.NumberOfColors = 1;
                    }
                }
                else
                {
                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.White;
                    e.CellElement.NumberOfColors = 1;
                }
            }
            else
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.White;
                e.CellElement.NumberOfColors = 1;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (address.Text == "")
            {
                RadMessageBox.Show(this, " فایلی جهت آپلود انتخاب نشده است. " + "\n", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else if (File_Status.Text == "غیر قابل قبول")
            {
                RadMessageBox.Show(this, " فایل انتخاب شده غیر قابل قبول است. لطفا فایل را اصلاح نمائید. " + "\n", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else if (mnth.SelectedIndex == -1 || yr.SelectedIndex == -1)
            {
                RadMessageBox.Show(this, " ماه و سال انتخاب نشده است. " + "\n", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                pictureBox1.Visible = true;
                pictureBox1.Refresh();
                pictureBox1.Update();
                //////////////////////////////////////////////////////////// Remove Everything
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = " DELETE FROM [SNAPP_CC_EVALUATION].[dbo].[PER_SALARY_SLIP] where [Mnth] = '" + mnth.SelectedIndex.ToString() + "' and [yr] = '" + yr.Text +"'";
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
                //////////////////////////////////////////////////////////// Insert All
                for (int j = 1; j < dataSet.Tables[0].Rows.Count; j++)
                {
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[PER_SALARY_SLIP] ([System_Id],[Mnth],[yr],[Working_Days],[Base_Salary],[Child_Allowance],[Subsidy],[House_Allowance], " +
                                                "[Performance_Bonus],[Holy_Work],[Holy_Work_Amt],[Low_Work],[Low_Work_Amt],[X3_Over_Time],[X3_Over_Time_Amt],[Normal_Over_Time],[Normal_Over_Time_Amt] " + 
                                                ",[Over_Time],[Salary_Diff],[Total_Pay],[Insurance],[Taxt],[Attence_Reduction],[Penalty],[QC_Penalty],[Comp_Insurance],[Advance_Payment], " + 
                                                "[Total_Reduction],[Payable]) " +
                                                "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                    oleDbCommand1.Parameters.AddWithValue("@System_Id", dataSet.Tables[0].Rows[j][0].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Mnth", mnth.SelectedIndex.ToString());
                    oleDbCommand1.Parameters.AddWithValue("@yr", yr.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Working_Days", dataSet.Tables[0].Rows[j][1].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Base_Salary", dataSet.Tables[0].Rows[j][2].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Child_Allowance", dataSet.Tables[0].Rows[j][3].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Subsidy", dataSet.Tables[0].Rows[j][4].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@House_Allowance", dataSet.Tables[0].Rows[j][5].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Performance_Bonus", dataSet.Tables[0].Rows[j][6].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Holy_Work", dataSet.Tables[0].Rows[j][7].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Holy_Work_Amt", dataSet.Tables[0].Rows[j][8].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Low_Work", dataSet.Tables[0].Rows[j][9].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Low_Work_Amt", dataSet.Tables[0].Rows[j][10].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@X3_Over_Time", dataSet.Tables[0].Rows[j][11].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@X3_Over_Time_Amt", dataSet.Tables[0].Rows[j][12].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Normal_Over_Time", dataSet.Tables[0].Rows[j][13].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Normal_Over_Time_Amt", dataSet.Tables[0].Rows[j][14].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Over_Time", dataSet.Tables[0].Rows[j][15].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Salary_Diff", dataSet.Tables[0].Rows[j][16].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Total_Pay", dataSet.Tables[0].Rows[j][17].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Insurance", dataSet.Tables[0].Rows[j][18].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Taxt", dataSet.Tables[0].Rows[j][19].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Attence_Reduction", dataSet.Tables[0].Rows[j][20].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Penalty", dataSet.Tables[0].Rows[j][21].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@QC_Penalty", dataSet.Tables[0].Rows[j][22].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Comp_Insurance", dataSet.Tables[0].Rows[j][23].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Advance_Payment", dataSet.Tables[0].Rows[j][24].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Total_Reduction", dataSet.Tables[0].Rows[j][25].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Payable", dataSet.Tables[0].Rows[j][26].ToString());
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                }
                pictureBox1.Visible = false;
                RadMessageBox.Show(this, " عملیات با موفقیت انجام شد. " + "\n", "اعلام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void Sample_DL_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "Sample_Salary.xlsx";
            saveFileDialog1.Filter = "Excel 2007(*.xlsx)|*.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Application.StartupPath + "\\Reports\\Sample_Salary.xlsx", saveFileDialog1.FileName);
            }

            RadMessageBox.Show(this, " عملیات با موفقیت انجام شد. " + "\n", "اعلام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
        }
    }
}
