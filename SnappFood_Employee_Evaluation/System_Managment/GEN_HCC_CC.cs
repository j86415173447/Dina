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
using Telerik.WinControls.UI;

namespace SnappFood_Employee_Evaluation.System_Managment
{
    public partial class GEN_HCC_CC : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public DataSet dataSet = new DataSet();
        private ErrorProvider errorProvider;
        public bool data_error = false;

        public GEN_HCC_CC()
        {
            InitializeComponent();

            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;

            pictureBox1.TextAlignment = ContentAlignment.MiddleCenter;
            Order_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // = dt_initial.Rows[0][0].ToString();
            VMS_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][1].ToString();
            Max_OTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][2].ToString();
            calling_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][3].ToString();
            vms_swtch_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][4].ToString();
            calling_swtch_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][5].ToString();
            NFC_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][6].ToString();
            VMS_delay_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][7].ToString();
            Rest_Call_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][8].ToString();
            Cancel_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][9].ToString();
            Rest_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][10].ToString();
            Avg_Prdct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][11].ToString();
            Avg_Area.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][12].ToString();
            Menu_Update_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][13].ToString();
            Prdct_Check.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][14].ToString();
            Area_Check_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][15].ToString();
            Area_Edit_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][16].ToString();
            Old_Prdct_Trans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][17].ToString();
            Profile_Creation_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][18].ToString();
            Prdct_Creation_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][19].ToString();
            Prdct_Trans_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][20].ToString();
            Prdct_Desc_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][21].ToString();
            Desc_Trans_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][22].ToString();
            Menu_Update_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][23].ToString();
            Profile_Edit_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][24].ToString();
            Area_Creation_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][25].ToString();
            Area_Check_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][26].ToString();
            Area_Edit_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][27].ToString();
            Trans_Revise_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][28].ToString();
            old_Prdct_Trans_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][29].ToString();
            Prdct_Check_HT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; // dt_initial.Rows[0][30].ToString();
            lbl_calling_count.TextAlignment = ContentAlignment.MiddleCenter;
            lbl_calling_swtch_Rate.TextAlignment = ContentAlignment.MiddleCenter;
            lbl_nfc_Rate.TextAlignment = ContentAlignment.MiddleCenter;
            lbl_Trans_Revise_Count.TextAlignment = ContentAlignment.MiddleCenter;
            lbl_vms_count.TextAlignment = ContentAlignment.MiddleCenter;
            lbl_vms_swtch_rate.TextAlignment = ContentAlignment.MiddleCenter;
        }

        private void GEN_HCC_SETTING_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
            RadMessageBox.ThemeName = "Office2010Silver";
            DataTable dt_initial = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = new OleDbCommand();
            adp.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_HANDLING]";
            adp.SelectCommand.CommandText = lcommand;
            dt_initial.Clear();
            adp.Fill(dt_initial);
            Order_count.Text = dt_initial.Rows[0][0].ToString();
            VMS_rate.Text = dt_initial.Rows[0][1].ToString();
            Max_OTA.Text = dt_initial.Rows[0][2].ToString();
            calling_HT.Text = dt_initial.Rows[0][3].ToString();
            vms_swtch_HT.Text = dt_initial.Rows[0][4].ToString();
            calling_swtch_HT.Text = dt_initial.Rows[0][5].ToString();
            NFC_HT.Text = dt_initial.Rows[0][6].ToString();
            VMS_delay_HT.Text = dt_initial.Rows[0][7].ToString();
            Rest_Call_HT.Text = dt_initial.Rows[0][8].ToString();
            Cancel_HT.Text = dt_initial.Rows[0][9].ToString();
            Rest_Count.Text = dt_initial.Rows[0][10].ToString();
            Avg_Prdct.Text = dt_initial.Rows[0][11].ToString();
            Avg_Area.Text = dt_initial.Rows[0][12].ToString();
            Menu_Update_Count.Text = dt_initial.Rows[0][13].ToString();
            Prdct_Check.Text = dt_initial.Rows[0][14].ToString();
            Area_Check_Count.Text = dt_initial.Rows[0][15].ToString();
            Area_Edit_Count.Text = dt_initial.Rows[0][16].ToString();
            Old_Prdct_Trans.Text = dt_initial.Rows[0][17].ToString();
            Profile_Creation_HT.Text = dt_initial.Rows[0][18].ToString();
            Prdct_Creation_HT.Text = dt_initial.Rows[0][19].ToString();
            Prdct_Trans_HT.Text = dt_initial.Rows[0][20].ToString();
            Prdct_Desc_HT.Text = dt_initial.Rows[0][21].ToString();
            Desc_Trans_HT.Text = dt_initial.Rows[0][22].ToString();
            Menu_Update_HT.Text = dt_initial.Rows[0][23].ToString();
            Profile_Edit_HT.Text = dt_initial.Rows[0][24].ToString();
            Area_Creation_HT.Text = dt_initial.Rows[0][25].ToString();
            Area_Check_HT.Text = dt_initial.Rows[0][26].ToString();
            Area_Edit_HT.Text = dt_initial.Rows[0][27].ToString();
            Trans_Revise_HT.Text = dt_initial.Rows[0][28].ToString();
            old_Prdct_Trans_HT.Text = dt_initial.Rows[0][29].ToString();
            Prdct_Check_HT.Text = dt_initial.Rows[0][30].ToString();

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //address.Text = fileDialog.FileName.ToString();
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
                //File_Status.Text = "غیر قابل قبول";
                //File_Status.ForeColor = Color.Red;
                pictureBox1.Visible = false;
                RadMessageBox.Show(this, " فایل پیوستی دارای اشکال در بخش های مشخص شده می باشد. " + "\n", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                return false;
            }
            else
            {
                //File_Status.Text = "قابل قبول";
                //File_Status.ForeColor = Color.Green;
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
            if (required_field())
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
                    DataTable dt23 = new DataTable();
                    OleDbDataAdapter adp23 = new OleDbDataAdapter();
                    adp23.SelectCommand = new OleDbCommand();
                    adp23.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommand23 = "SELECT [Time_Span] 'بازه زمانی',[Break_Percentage] 'درصد استراحت' " +
                                        ",Ceiling([Order_Dispatch] * " + Order_count.Text + ") 'کل سفارشات' " +
                                        ",Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) 'سفارشات VMS' " +
                                        ",Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)) 'سفارشات دستی' " +
                                        ",Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [VMS_Switch_Dispatch]) 'VMS Switch' " +
                                        ",Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)) * [Calling_Switch_Dispatch]) 'Calling Switch' " +
                                        ",Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [NFC_Dispatch]) - Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [VMS_Switch_Dispatch])) 'نیاز به تماس' " +
                                        ",Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [VMS_Delay_Dispatch]) 'VMS تاخیر' " +
                                        ",Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + ") * [Cancel_Dispatch]) 'سفارش لغو شده' " +
                                        ",Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + ") * [RES_Call_Dispatch]) 'خط 300' " +
                                        ",Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)))/((1800-(1800*[Break_Percentage]))/" + calling_HT.Text + ")) 'نیرو سفارش دستی' " +
                                        ",Ceiling((Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [VMS_Switch_Dispatch]))/((1800-(1800*[Break_Percentage]))/" + vms_swtch_HT.Text + ")) 'VMS Switch نیرو' " +
                                        ",Ceiling((Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)) * [Calling_Switch_Dispatch]))/((1800-(1800*[Break_Percentage]))/" + calling_swtch_HT.Text + ")) 'Calling Switch نیرو' " +
                                        ",Ceiling((Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [NFC_Dispatch]) - Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [VMS_Switch_Dispatch])))/((1800-(1800*[Break_Percentage]))/" + NFC_HT.Text + ")) 'نیرو نیاز به تماس' " +
                                        ",Ceiling((Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [VMS_Delay_Dispatch]))/((1800-(1800*[Break_Percentage]))/" + VMS_delay_HT.Text + ")) 'VMS نیرو تاخیر' " +
                                        ",Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + ") * [Cancel_Dispatch]))/((1800-(1800*[Break_Percentage]))/" + Cancel_HT.Text + ")) 'نیرو لغو سفارش' " +
                                        ",Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + ") * [RES_Call_Dispatch]))/((1800-(1800*[Break_Percentage]))/" + Rest_Call_HT.Text + ")) 'نیرو خط 300' " +
                                        ",(Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)))/((1800-(1800*[Break_Percentage]))/" + calling_HT.Text + "))) + " +
                                        "(Ceiling((Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)) * [Calling_Switch_Dispatch]))/((1800-(1800*[Break_Percentage]))/" + calling_swtch_HT.Text + "))) + " +
                                        "(Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + ") * [Cancel_Dispatch]))/((1800-(1800*[Break_Percentage]))/" + Cancel_HT.Text + "))) 'Calling مجموع نیرو'" +
                                        ",(Ceiling((Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [VMS_Switch_Dispatch]))/((1800-(1800*[Break_Percentage]))/" + vms_swtch_HT.Text + "))) + " +
                                        "(Ceiling((Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [NFC_Dispatch]) - Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [VMS_Switch_Dispatch])))/((1800-(1800*[Break_Percentage]))/" + NFC_HT.Text + "))) + " +
                                        "(Ceiling((Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [VMS_Delay_Dispatch]))/((1800-(1800*[Break_Percentage]))/" + VMS_delay_HT.Text + "))) 'VMS مجموع نیرو'" +
                                        "FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA] ";
                    adp23.SelectCommand.CommandText = lcommand23;
                    dt23.Clear();
                    adp23.Fill(dt23);
                    grid.DataSource = dt23;
                    grid.BestFitColumns(BestFitColumnMode.AllCells);
                    //////////////////////////////////////////////////////// Update Header Orders
                    lbl_vms_count.Text = Math.Round((int.Parse(Order_count.Text) * float.Parse(VMS_rate.Text))).ToString();
                    lbl_calling_count.Text = (int.Parse(Order_count.Text) - int.Parse(lbl_vms_count.Text)).ToString();
                    DataTable dt24 = new DataTable();
                    OleDbDataAdapter adp24 = new OleDbDataAdapter();
                    adp24.SelectCommand = new OleDbCommand();
                    adp24.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommand24 = "SELECT " + // NFC Rate
                                        "round((sum(Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [NFC_Dispatch]) - Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [VMS_Switch_Dispatch])))/ " +
                                        "sum(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1))))*100,2) 'DATA', '1' 'Row' FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA] " +

                                        //"UNION SELECT " + //Calling Count
                                        //"SUM(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1))) FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA] " +
                                        //"UNION SELECT " + //VMS Count
                                        //"SUM(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1))) FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA] " +

                                        "UNION SELECT " + // Switch Rate VMS
                                        "round(((sum(Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * " + VMS_rate.Text + ") * IIF([VMS_OTA] > " + Max_OTA.Text + " , (1+([VMS_OTA]-" + Max_OTA.Text + ")),1)) * [VMS_Switch_Dispatch]))) " +
                                        "/ " + lbl_vms_count.Text + ")*100,2) 'DATA', '2' 'Row' FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA] " +

                                        "UNION SELECT " + // Switch Rate Calling
                                        "round(((sum(Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)) * [Calling_Switch_Dispatch]))) " +
                                        "/ " + lbl_calling_count.Text + ")*100,2) 'DATA', '3' 'Row' FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA] " +

                                        " Order by [Row] asc ";
                    adp24.SelectCommand.CommandText = lcommand24;
                    dt24.Clear();
                    adp24.Fill(dt24);
                    lbl_nfc_Rate.Text = dt24.Rows[0][0].ToString() + "%";
                    lbl_vms_swtch_rate.Text = dt24.Rows[1][0].ToString() + "%";
                    lbl_calling_swtch_Rate.Text = dt24.Rows[2][0].ToString() + "%";
                    /////////////////////////////////////////////////////////////////////////// Update Order Summary table
                    DataTable dt25 = new DataTable();
                    OleDbDataAdapter adp25 = new OleDbDataAdapter();
                    adp25.SelectCommand = new OleDbCommand();
                    adp25.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommand25 = "(Select 'Calling' 'Team', " +
                                        "(SELECT MAX((Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)))/((1800-(1800*[Break_Percentage]))/120))) + (Ceiling((Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)) * [Calling_Switch_Dispatch]))/((1800-(1800*[Break_Percentage]))/500))) + (Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + ") * [Cancel_Dispatch]))/((1800-(1800*[Break_Percentage]))/120)))) FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA]  where ([Time_Span] >= '07_2' and [Time_Span] <= '11_1') or ([Time_Span] >= '16_1' and [Time_Span] <= '17_2')) 'Fix Qty' " +
                                        ",(SELECT MAX((Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)))/((1800-(1800*[Break_Percentage]))/120))) + (Ceiling((Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)) * [Calling_Switch_Dispatch]))/((1800-(1800*[Break_Percentage]))/500))) + (Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + ") * [Cancel_Dispatch]))/((1800-(1800*[Break_Percentage]))/120)))) FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA]  where [Time_Span] >= '11_2' and [Time_Span] <= '15_2' ) 'Peak Qty' " +
                                        ",(SELECT MAX((Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)))/((1800-(1800*[Break_Percentage]))/120))) + (Ceiling((Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)) * [Calling_Switch_Dispatch]))/((1800-(1800*[Break_Percentage]))/500))) + (Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + ") * [Cancel_Dispatch]))/((1800-(1800*[Break_Percentage]))/120)))) FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA]  where [Time_Span] >= '11_2' and [Time_Span] <= '15_2' ) - " +
                                        "(SELECT MAX((Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-" + VMS_rate.Text + ")) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)))/((1800-(1800*[Break_Percentage]))/120))) + (Ceiling((Ceiling(Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + " * (1-0.91)) * IIF([Calling_OTA] > " + Max_OTA.Text + " , (1+([Calling_OTA]-" + Max_OTA.Text + ")),1)) * [Calling_Switch_Dispatch]))/((1800-(1800*[Break_Percentage]))/500))) + (Ceiling((Ceiling(Ceiling([Order_Dispatch] * " + Order_count.Text + ") * [Cancel_Dispatch]))/((1800-(1800*[Break_Percentage]))/120)))) FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_DATA]  where ([Time_Span] >= '07_2' and [Time_Span] <= '11_1') or ([Time_Span] >= '16_1' and [Time_Span] <= '17_2')) 'Transfer Qty' " +
                                        "FROM [SNAPP_CC_EVALUATION].[dbo].[SYS_CC_HCC_HANDLING]) ";
                    adp25.SelectCommand.CommandText = lcommand25;
                    dt25.Clear();
                    adp25.Fill(dt25);
                    Order_Grid.DataSource = dt25;
                    Order_Grid.BestFitColumns(BestFitColumnMode.None);
                }
                else
                {
                    RadMessageBox.Show(this, "  دیتای HCC کال سنتر موجود نیست.  " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
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
        }

        public bool required_field()
        {
            data_error = false;
            errorProvider.Clear();
            if (Order_count.Text =="") { errorProvider.SetError(this.Order_count, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (VMS_rate.Text =="") { errorProvider.SetError(this.VMS_rate, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Max_OTA.Text =="") { errorProvider.SetError(this.Max_OTA, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (calling_HT.Text =="") { errorProvider.SetError(this.calling_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (vms_swtch_HT.Text =="") { errorProvider.SetError(this.vms_swtch_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (calling_swtch_HT.Text =="") { errorProvider.SetError(this.calling_swtch_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (NFC_HT.Text =="") { errorProvider.SetError(this.NFC_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (VMS_delay_HT.Text =="") { errorProvider.SetError(this.VMS_delay_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Rest_Call_HT.Text =="") { errorProvider.SetError(this.Rest_Call_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Cancel_HT.Text =="") { errorProvider.SetError(this.Cancel_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Rest_Count.Text =="") { errorProvider.SetError(this.Rest_Count, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Avg_Prdct.Text =="") { errorProvider.SetError(this.Avg_Prdct, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Avg_Area.Text =="") { errorProvider.SetError(this.Avg_Area, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Menu_Update_Count.Text =="") { errorProvider.SetError(this.Menu_Update_Count, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Prdct_Check.Text =="") { errorProvider.SetError(this.Prdct_Check, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Area_Check_Count.Text =="") { errorProvider.SetError(this.Area_Check_Count, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Area_Edit_Count.Text =="") { errorProvider.SetError(this.Area_Edit_Count, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Old_Prdct_Trans.Text =="") { errorProvider.SetError(this.Old_Prdct_Trans, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Profile_Creation_HT.Text =="") { errorProvider.SetError(this.Profile_Creation_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Prdct_Creation_HT.Text =="") { errorProvider.SetError(this.Prdct_Creation_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Prdct_Trans_HT.Text =="") { errorProvider.SetError(this.Prdct_Trans_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Prdct_Desc_HT.Text =="") { errorProvider.SetError(this.Prdct_Desc_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Desc_Trans_HT.Text =="") { errorProvider.SetError(this.Desc_Trans_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Menu_Update_HT.Text =="") { errorProvider.SetError(this.Menu_Update_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Profile_Edit_HT.Text =="") { errorProvider.SetError(this.Profile_Edit_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Area_Creation_HT.Text =="") { errorProvider.SetError(this.Area_Creation_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Area_Check_HT.Text =="") { errorProvider.SetError(this.Area_Check_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Area_Edit_HT.Text =="") { errorProvider.SetError(this.Area_Edit_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Trans_Revise_HT.Text =="") { errorProvider.SetError(this.Trans_Revise_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (old_Prdct_Trans_HT.Text =="") { errorProvider.SetError(this.old_Prdct_Trans_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (Prdct_Check_HT.Text =="") { errorProvider.SetError(this.Prdct_Check_HT, " لطفا مقداری وارد نمائید."); data_error = true; }
            if (data_error)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
