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

namespace SnappFood_Employee_Evaluation.System_Managment
{
    public partial class GEN_HCC_SETTING : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataSet dataSet = new DataSet();


        public GEN_HCC_SETTING()
        {
            InitializeComponent();
            pictureBox1.TextAlignment = ContentAlignment.MiddleCenter;
        }

        private void GEN_HCC_SETTING_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            RadMessageBox.ThemeName = "Office2010Silver";
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

                    if (dataSet.Tables[0].Rows.Count != 34)
                    {
                        pictureBox1.Visible = false;
                        RadMessageBox.Show(this, " تعداد ردیف های فراخوانی شده در فایل انتخابی " + (dataSet.Tables[0].Rows.Count - 1).ToString() + " می باشد. " + "\n\n" + " تعداد ردیف های مجاز 33 است. ", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                    else if (dataSet.Tables[0].Columns.Count != 11)
                    {
                        pictureBox1.Visible = false;
                        RadMessageBox.Show(this, " تعداد ستون های فراخوانی شده در فایل انتخابی " + (dataSet.Tables[0].Columns.Count).ToString() + " می باشد. " + "\n\n" + " تعداد ستون های مجاز 11 است. ", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
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
                        grid.BestFitColumns();

                        if (check_file())
                        {
                            pictureBox1.Visible = false;
                            RadMessageBox.Show(this, "فایل انتخابی با موفقیت فراخوانی گردید.", "خطا", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
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
            List<string> err_list = new List<string>();
            for (int i = 1; i < dataSet.Tables[0].Rows.Count; i++)
            {
                for (int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                {
                    if (dataSet.Tables[0].Rows[i][j].GetType() == typeof(int) || dataSet.Tables[0].Rows[i][j].GetType() == typeof(float) || dataSet.Tables[0].Rows[i][j].GetType() == typeof(double))
                    {
                        if (float.Parse(dataSet.Tables[0].Rows[i][j].ToString()) > 1 || dataSet.Tables[0].Rows[i][j].ToString().Substring(dataSet.Tables[0].Rows[i][j].ToString().IndexOf(".") + 1).Length > 4)
                        {
                            err_list.Add(dataSet.Tables[0].Rows[i][0].ToString() + " ---> " + dataSet.Tables[0].Columns[j].ColumnName);
                        }
                    }
                }
            }
            if (err_list.Count != 0)
            {
                File_Status.Text = "غیر قابل قبول";
                File_Status.ForeColor = Color.Red;
                pictureBox1.Visible = false;
                RadMessageBox.Show(this, " فایل پیوستی دارای اشکال در بخش های مشخص شده می باشد. " + "\n", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
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
            if (e.CellElement.ColumnInfo.Name == "Break_Percentage" || e.CellElement.ColumnInfo.Name == "Order_Dispatch" || e.CellElement.ColumnInfo.Name == "VMS_Switch_Dispatch" || e.CellElement.ColumnInfo.Name == "Calling_OTA" || e.CellElement.ColumnInfo.Name == "VMS_OTA" ||
                e.CellElement.ColumnInfo.Name == "Calling_Switch_Dispatch" || e.CellElement.ColumnInfo.Name == "NFC_Dispatch" || e.CellElement.ColumnInfo.Name == "VMS_Delay_Dispatch" || e.CellElement.ColumnInfo.Name == "Cancel_Dispatch" || e.CellElement.ColumnInfo.Name == "RES_Call_Dispatch")
            {
                if (e.CellElement.Value.GetType() == typeof(int) || e.CellElement.Value.GetType() == typeof(float) || e.CellElement.Value.GetType() == typeof(double))
                {
                    if (float.Parse(e.CellElement.Value.ToString()) > 1 || e.CellElement.Value.ToString().Substring(e.CellElement.Value.ToString().IndexOf(".") + 1).Length > 4)
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
                    e.CellElement.BackColor = Color.OrangeRed;
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
            if (File_Status.Text == "غیر قابل قبول")
            {
                RadMessageBox.Show(this, " فایل انتخاب شده غیر قابل است. لطفا فایل را اصلاح نمائید. " + "\n", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
            else
            {
                pictureBox1.Visible = true;
                pictureBox1.Refresh();
                pictureBox1.Update();
                //////////////////////////////////////////////////////////// Remove Everything
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = " Truncate Table [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA]";
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();
                //////////////////////////////////////////////////////////// Insert All
                for (int j = 1; j < dataSet.Tables[0].Rows.Count; j++)
                {
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA] ([Time_Span],[Break_Percentage],[Calling_OTA],[VMS_OTA],[Order_Dispatch],[VMS_Switch_Dispatch],[Calling_Switch_Dispatch],[NFC_Dispatch],[VMS_Delay_Dispatch],[Cancel_Dispatch],[RES_Call_Dispatch]) " + 
                                                "VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                    oleDbCommand1.Parameters.AddWithValue("@Time_Span", dataSet.Tables[0].Rows[j][0].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Break_Percentage", dataSet.Tables[0].Rows[j][1].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Order_Dispatch", dataSet.Tables[0].Rows[j][2].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@VMS_Switch_Dispatch", dataSet.Tables[0].Rows[j][3].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Calling_Switch_Dispatch", dataSet.Tables[0].Rows[j][4].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@NFC_Dispatch", dataSet.Tables[0].Rows[j][5].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@VMS_Delay_Dispatch", dataSet.Tables[0].Rows[j][6].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@Cancel_Dispatch", dataSet.Tables[0].Rows[j][7].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@RES_Call_Dispatch", dataSet.Tables[0].Rows[j][8].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@RES_Call_Dispatch", dataSet.Tables[0].Rows[j][9].ToString());
                    oleDbCommand1.Parameters.AddWithValue("@RES_Call_Dispatch", dataSet.Tables[0].Rows[j][10].ToString());
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
            DataTable dt22 = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA]";
            adp.SelectCommand.CommandText = lcommand;
            dt22.Clear();
            adp.Fill(dt22);
            if (dt22.Rows.Count != 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FileName = "Sample_HCC_CC.xlsx";
                saveFileDialog1.Filter = "Excel 2007(*.xlsx)|*.xlsx";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string add = saveFileDialog1.FileName;
                    using (var doc = new SpreadsheetDocument(@add))
                    {
                        Worksheet sheet1 = doc.Worksheets.Add("Report");
                        sheet1.ImportDataTable(dt22, "A1", true);
                    }
                    System.Diagnostics.Process.Start(@add);
                }
                else
                {

                }
            }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FileName = "Sample_HCC_CC.xlsx";
                saveFileDialog1.Filter = "Excel 2007(*.xlsx)|*.xlsx";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(Application.StartupPath + "\\Reports\\Sample_HCC_CC.xlsx", saveFileDialog1.FileName);
                }
            }
            RadMessageBox.Show(this, " عملیات با موفقیت انجام شد. " + "\n", "اعلام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
        }
    }
}
