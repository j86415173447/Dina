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
using System.IO;
using Telerik.WinControls.UI;

namespace SnappFood_Employee_Evaluation.Social_Media
{
    public partial class TICKET_ENTRY : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public string user;
        private ErrorProvider errorProvider;
        public string DT_Day;
        public string DT_Mth;
        public string DT_Yr;
        public bool gl_srch;
        public string last_state;

        public TICKET_ENTRY()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
            social_dt.Culture = new System.Globalization.CultureInfo("fa-IR");
            ticket_id.TextAlignment = ContentAlignment.MiddleLeft;
            insrt_username.TextAlignment = ContentAlignment.MiddleLeft;
            answer_qty.TextAlignment = ContentAlignment.MiddleLeft;
        }
        private void btn_exit_form_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TICKET_ENTRY_Load(object sender, EventArgs e)
        {
            //scial_dt_lbl.Left = 88;
            //scial_dt_lbl.Top = 278;
            scial_dt_lbl.Location = social_dt.Location;
            //user = user;
            oleDbConnection1.ConnectionString = constr;
            /////////////////////////////////////////////////////////////////////// Initiate Comboboxes

            ///////////////////////////////////////////// ORIGIN
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT '0' 'OR_ID', '' 'Origin' union SELECT [OR_ID], [Origin] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_ORIGIN] where [Origin_ACTV] = 1 order by [OR_ID] asc";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            Origin.DataSource = dt1;
            Origin.DisplayMember = "Origin";

            ///////////////////////////////////////////// CHANNEL
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adp2 = new OleDbDataAdapter();
            adp2.SelectCommand = new OleDbCommand();
            adp2.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand2 = "SELECT '0' 'CH_ID', '' 'Channel' union SELECT [CH_ID],[Channel] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_CHANNEL] where [Channel_ACTV] = 1 order by [CH_ID] asc";
            adp2.SelectCommand.CommandText = lcommand2;
            adp2.Fill(dt2);
            Channel.DataSource = dt2;
            Channel.DisplayMember = "Channel";

            ///////////////////////////////////////////// DEPARTMENT
            DataTable dt3 = new DataTable();
            OleDbDataAdapter adp3 = new OleDbDataAdapter();
            adp3.SelectCommand = new OleDbCommand();
            adp3.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand3 = "SELECT '0' 'DEP_ID', '' 'Dep_NM' union SELECT [DEP_ID],[Dep_NM] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_DEPARTMENT] where [DEP_ACTV] = 1 order by [DEP_ID] asc";
            adp3.SelectCommand.CommandText = lcommand3;
            adp3.Fill(dt3);
            department.DataSource = dt3;
            department.DisplayMember = "Dep_NM";

            ///////////////////////////////////////////// STATUS
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT '0' 'ST_Priority', '' 'ST_Text' union SELECT [ST_Priority],[ST_Text] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_STATUS_MASTER] WHERE [ST_ACTV] = 1 order by [ST_Priority] asc";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            ticket_status.DataSource = dt4;
            ticket_status.DisplayMember = "ST_Text";

            ///////////////////////////////////////////// HISTORY
            DataTable dt5 = new DataTable();
            OleDbDataAdapter adp5 = new OleDbDataAdapter();
            adp5.SelectCommand = new OleDbCommand();
            adp5.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand5 = "SELECT '0' 'ID', '' 'SIDE' union SELECT '1' 'ID', N'دیجی کالا' 'SIDE' union SELECT '2' 'ID', N'کاربر' 'SIDE'  order by [ID] asc";
            adp5.SelectCommand.CommandText = lcommand5;
            adp5.Fill(dt5);
            history_party.DataSource = dt5;
            history_party.DisplayMember = "SIDE";

            ///////////////////////////////////////////// Remark
            DataTable dt7 = new DataTable();
            OleDbDataAdapter adp7 = new OleDbDataAdapter();
            adp7.SelectCommand = new OleDbCommand();
            adp7.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand7 = "SELECT '0' 'RMTP_id', '' 'RMTP_Type' union SELECT [RMTP_id],[RMTP_Type] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_REMARK_TYPE] where [RMTP_ACTV] = 1  order by [RMTP_id] asc";
            adp7.SelectCommand.CommandText = lcommand7;
            adp7.Fill(dt7);
            remark_type.DataSource = dt7;
            remark_type.DisplayMember = "RMTP_Type";

            ///////////////////////////////////////////// REASON
            DataTable dt6 = new DataTable();
            OleDbDataAdapter adp6 = new OleDbDataAdapter();
            adp6.SelectCommand = new OleDbCommand();
            adp6.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand6 = "SELECT '' 'RSN_Desc' union SELECT distinct [RSN_Desc] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_REASON] where [RSN_ACTV] = 1";
            adp6.SelectCommand.CommandText = lcommand6;
            adp6.Fill(dt6);
            reason.DataSource = dt6;
            reason.DisplayMember = "RSN_Desc";

        }

        private void Origin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Origin.SelectedIndex != 0)
            {
                ///////////////////////////////////////////// TYPE
                DataTable dt1 = new DataTable();
                OleDbDataAdapter adp1 = new OleDbDataAdapter();
                adp1.SelectCommand = new OleDbCommand();
                adp1.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand1 = "SELECT '0' 'TP_ID', '' 'Type_Desc' union SELECT [TP_ID],[Type_Desc] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_TYPE] where [TP_ACTV] = 1 and [TP_Origin] = N'" + Origin.Text + "' order by [TP_ID] asc";
                adp1.SelectCommand.CommandText = lcommand1;
                adp1.Fill(dt1);
                Type.DataSource = dt1;
                Type.DisplayMember = "Type_Desc";
            }
        }

        private void reason_sub1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reason_sub1.SelectedIndex != 0)
            {
                ///////////////////////////////////////////// REASON 2
                DataTable dt2 = new DataTable();
                OleDbDataAdapter adp2 = new OleDbDataAdapter();
                adp2.SelectCommand = new OleDbCommand();
                adp2.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand2 = "SELECT '' 'RSN_Sub2' union SELECT DISTINCT [RSN_Sub2] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_REASON] where [RSN_ACTV] = 1 and [RSN_Sub1] = N'" + reason_sub1.Text + "'";
                adp2.SelectCommand.CommandText = lcommand2;
                adp2.Fill(dt2);
                reason_sub2.DataSource = dt2;
                reason_sub2.DisplayMember = "RSN_Sub2";
            }
        }

        private void reason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reason.SelectedIndex != 0)
            {
                ///////////////////////////////////////////// REASON 1
                DataTable dt1 = new DataTable();
                OleDbDataAdapter adp1 = new OleDbDataAdapter();
                adp1.SelectCommand = new OleDbCommand();
                adp1.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand1 = "SELECT '' 'RSN_Sub1' union SELECT DISTINCT [RSN_Sub1] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_REASON] where [RSN_ACTV] = 1 and [RSN_Desc] = N'" + reason.Text + "'";
                adp1.SelectCommand.CommandText = lcommand1;
                adp1.Fill(dt1);
                reason_sub1.DataSource = dt1;
                reason_sub1.DisplayMember = "RSN_Sub1";
            }
        }

        private void history_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (history_party.SelectedIndex != 0)
            {
                ///////////////////////////////////////////// MOOD
                DataTable dt1 = new DataTable();
                OleDbDataAdapter adp1 = new OleDbDataAdapter();
                adp1.SelectCommand = new OleDbCommand();
                adp1.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand1 = "SELECT '0' 'MD_ID', '' 'Mood' union SELECT [MD_ID],[Mood] FROM [SNAPP_CC_EVALUATION].[dbo].[SM_MOOD] where [Mood_ACTV] = 1 and [side] = N'" + history_party.Text + "' order by [MD_ID] asc ";
                adp1.SelectCommand.CommandText = lcommand1;
                adp1.Fill(dt1);
                history_mood.DataSource = dt1;
                history_mood.DisplayMember = "Mood";
            }
        }

        private void pic_upload_Click(object sender, EventArgs e)
        {
            if (!ticket_status.Text.Contains("بسته") && ticket_id.Text != "")
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Images |*.JPG";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    picture_box.ImageLocation = op.FileName;

                    byte[] imageData = ReadFile(op.FileName);
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
                    DT_Day = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
                    DT_Mth = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
                    DT_Yr = psdate.GetYear(datetime).ToString();


                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_GALLERY] ([Ticket_id],[Image],[Image_Size],[Insrt_user],[Insrt_DT_per],[Insrt_DT],[Insrt_TM]) VALUES (?,?,?,?,?,getdate(),getdate())";
                    oleDbCommand1.Parameters.AddWithValue("@Ticket_id", ticket_id.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Image", (object)imageData);
                    oleDbCommand1.Parameters.AddWithValue("@Image_Size", Image_Size(op.FileName));
                    oleDbCommand1.Parameters.AddWithValue("@Insrt_user", user);
                    oleDbCommand1.Parameters.AddWithValue("@Insrt_DT_Per", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();

                    Gallery_Search();
                }
            }
            else
            {
                RadMessageBox.Show(this, " آپلود تصویر مجاز نیست " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        byte[] ReadFile(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        public string Image_Size(string spath)
        {
            FileInfo FileVol = new FileInfo(spath);
            string fileLength = FileVol.Length.ToString();
            string length = string.Empty;
            if (FileVol.Length >= (1 << 10))
                length = string.Format("{0} Kb", FileVol.Length >> 10);
            return length;
        }

        public void Gallery_Search()
        {
            gl_srch = true;
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT [id] 'شناسه',[image],[image_size] 'حجم',[Insrt_user] 'کارشناس',[Insrt_DT_per] 'تاریخ',[Insrt_TM] 'ساعت' FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_GALLERY] where [Ticket_ID] = N'" + ticket_id.Text + "'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            if (dt1.Rows.Count != 0)
            {
                gallery_grid.DataSource = dt1;
                gallery_grid.Columns[1].IsVisible = false;
                gallery_grid.BestFitColumns();
            }


        }

        private void btn_ad_history_Click(object sender, EventArgs e)
        {
            if (history_party.SelectedIndex != 0 && history_text.Text != "" && history_mood.SelectedIndex != 0 && !ticket_status.Text.Contains("بسته") && ticket_id.Text != "")
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
                DT_Day = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
                DT_Mth = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
                DT_Yr = psdate.GetYear(datetime).ToString();

            
                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_HISTORY] ([Ticket_id],[History_Type],[History_Tone],[History_Text],[Insrt_User],[Insrt_DT],[Insrt_DT_Per],[Insrt_TM]) VALUES (?,?,?,?,?,getdate(),?,getdate())";
                oleDbCommand1.Parameters.AddWithValue("@Ticket_id", ticket_id.Text);
                oleDbCommand1.Parameters.AddWithValue("@History_Type", history_party.Text);
                oleDbCommand1.Parameters.AddWithValue("@History_Tone", history_mood.Text);
                oleDbCommand1.Parameters.AddWithValue("@History_Text", history_text.Text);
                oleDbCommand1.Parameters.AddWithValue("@Insrt_User", user);
                oleDbCommand1.Parameters.AddWithValue("@Insrt_DT_Per", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();

                history_party.SelectedIndex = 0;
                history_mood.SelectedIndex = 0;
                history_text.Text = "";

                History_Search();
            }
            else
            {
                RadMessageBox.Show(this, " ثبت سابقه مجاز نیست " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void History_Search()
        {
            history_grid.DataSource = null;
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT [History_Type] 'نوع',[History_tone] 'لحن',[Insrt_User] 'کارشناس',[History_Text] 'متن',[Insrt_DT_Per] 'تاریخ',[Insrt_TM] 'ساعت' FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_HISTORY] where [Ticket_ID] = N'" + ticket_id.Text + "'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            if (dt1.Rows.Count != 0)
            {
                int count_temp = 0;
                history_grid.DataSource = dt1;
                history_grid.Columns[4].IsVisible = false;
                history_grid.Columns[5].IsVisible = false;
                history_grid.BestFitColumns();
                history_grid.Columns[3].WrapText = true;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (dt1.Rows[i][0].ToString() == "دیجی کالا")
                    {
                        GridViewCellInfo cell = history_grid.Rows[i].Cells[0];
                        cell.Style.CustomizeFill = true;
                        cell.Style.BackColor = Color.LightGreen;
                        cell.Style.DrawFill = true;
                        GridViewCellInfo cell1 = history_grid.Rows[i].Cells[1];
                        cell1.Style.CustomizeFill = true;
                        cell1.Style.BackColor = Color.LightGreen;
                        cell1.Style.DrawFill = true;
                        GridViewCellInfo cell2 = history_grid.Rows[i].Cells[2];
                        cell2.Style.CustomizeFill = true;
                        cell2.Style.BackColor = Color.LightGreen;
                        cell2.Style.DrawFill = true;
                        GridViewCellInfo cell3 = history_grid.Rows[i].Cells[3];
                        cell3.Style.CustomizeFill = true;
                        cell3.Style.BackColor = Color.LightGreen;
                        cell3.Style.DrawFill = true;
                        count_temp++;
                    }
                    else
                    {
                        GridViewCellInfo cell = history_grid.Rows[i].Cells[0];
                        cell.Style.CustomizeFill = true;
                        cell.Style.BackColor = Color.LightPink;
                        cell.Style.DrawFill = true;
                        GridViewCellInfo cell1 = history_grid.Rows[i].Cells[1];
                        cell1.Style.CustomizeFill = true;
                        cell1.Style.BackColor = Color.LightPink;
                        cell1.Style.DrawFill = true;
                        GridViewCellInfo cell2 = history_grid.Rows[i].Cells[2];
                        cell2.Style.CustomizeFill = true;
                        cell2.Style.BackColor = Color.LightPink;
                        cell2.Style.DrawFill = true;
                        GridViewCellInfo cell3 = history_grid.Rows[i].Cells[3];
                        cell3.Style.CustomizeFill = true;
                        cell3.Style.BackColor = Color.LightPink;
                        cell3.Style.DrawFill = true;
                    }
                }
                answer_qty.Text = count_temp.ToString();
            }
        }

        private void history_grid_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var new_staff = new Social_Media.TICKET_HISTORY_DETAIL();
            new_staff.tick_id.Text = ticket_id.Text;
            new_staff.type.Text = history_grid.SelectedRows[0].Cells[0].Value.ToString();
            new_staff.tone.Text = history_grid.SelectedRows[0].Cells[1].Value.ToString();
            new_staff.text.Text = history_grid.SelectedRows[0].Cells[2].Value.ToString();
            new_staff.insrt_user.Text = history_grid.SelectedRows[0].Cells[3].Value.ToString();
            new_staff.insrt_dt.Text = history_grid.SelectedRows[0].Cells[4].Value.ToString();
            new_staff.insrt_tm.Text = history_grid.SelectedRows[0].Cells[5].Value.ToString();
            new_staff.ShowDialog();
        }

        private void btn_copy_clipboard_Click(object sender, EventArgs e)
        {
            bool result = Uri.IsWellFormedUriString(link.Text, UriKind.RelativeOrAbsolute);
            if (link.Text != "" && result)
            {
                try
                {
                    System.Diagnostics.Process.Start(link.Text);
                }
                catch
                {

                }
            }
        }

        private void btn_add_remark_Click(object sender, EventArgs e)
        {
            if (remark_type.SelectedIndex != 0 && remark_text.Text != "" && !ticket_status.Text.Contains("بسته") && ticket_id.Text != "")
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
                DT_Day = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
                DT_Mth = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
                DT_Yr = psdate.GetYear(datetime).ToString();

                oleDbCommand1.Parameters.Clear();
                oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_REMARK] ([Ticket_id],[Remark_Type],[Remark_Text],[Insrt_User],[Insrt_DT],[Insrt_DT_Per],[Insrt_TM]) VALUES (?,?,?,?,getdate(),?,getdate())";
                oleDbCommand1.Parameters.AddWithValue("@Ticket_id", ticket_id.Text);
                oleDbCommand1.Parameters.AddWithValue("@Remark_Type", remark_type.Text);
                oleDbCommand1.Parameters.AddWithValue("@Remark_Text", remark_text.Text);
                oleDbCommand1.Parameters.AddWithValue("@Insrt_User", user);
                oleDbCommand1.Parameters.AddWithValue("@Insrt_DT_Per", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                oleDbConnection1.Open();
                oleDbCommand1.ExecuteNonQuery();
                oleDbConnection1.Close();

                remark_type.SelectedIndex = 0;
                remark_text.Text = "";

                Remark_Search();
            }
            else
            {
                RadMessageBox.Show(this, " ثبت توضیحات مجاز نیست " + "\n", "اخطار", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private void Remark_Search()
        {
            remark_grid.DataSource = null;
            DataTable dt1 = new DataTable();
            OleDbDataAdapter adp1 = new OleDbDataAdapter();
            adp1.SelectCommand = new OleDbCommand();
            adp1.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand1 = "SELECT [Remark_Type] 'نوع',[Insrt_User] 'کارشناس',[Remark_Text] 'متن',[Insrt_DT_Per] 'تاریخ',[Insrt_TM] 'ساعت' FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKET_REMARK] where [Ticket_ID] = N'" + ticket_id.Text + "'";
            adp1.SelectCommand.CommandText = lcommand1;
            adp1.Fill(dt1);
            if (dt1.Rows.Count != 0)
            {
                remark_grid.DataSource = dt1;
                remark_grid.Columns[3].IsVisible = false;
                remark_grid.Columns[4].IsVisible = false;
                remark_grid.BestFitColumns();
                remark_grid.Columns[2].WrapText = true;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (dt1.Rows[i][0].ToString() == "اطلاع رسانی")
                    {
                        GridViewCellInfo cell = remark_grid.Rows[i].Cells[0];
                        cell.Style.CustomizeFill = true;
                        cell.Style.BackColor = Color.LightYellow;
                        cell.Style.DrawFill = true;
                        GridViewCellInfo cell1 = remark_grid.Rows[i].Cells[1];
                        cell1.Style.CustomizeFill = true;
                        cell1.Style.BackColor = Color.LightYellow;
                        cell1.Style.DrawFill = true;
                        GridViewCellInfo cell2 = remark_grid.Rows[i].Cells[2];
                        cell2.Style.CustomizeFill = true;
                        cell2.Style.BackColor = Color.LightYellow;
                        cell2.Style.DrawFill = true;
                        GridViewCellInfo cell3 = remark_grid.Rows[i].Cells[3];
                        cell3.Style.CustomizeFill = true;
                        cell3.Style.BackColor = Color.LightYellow;
                        cell3.Style.DrawFill = true;
                    }
                    else
                    {
                        GridViewCellInfo cell = remark_grid.Rows[i].Cells[0];
                        cell.Style.CustomizeFill = true;
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.DrawFill = true;
                        GridViewCellInfo cell1 = remark_grid.Rows[i].Cells[1];
                        cell1.Style.CustomizeFill = true;
                        cell1.Style.BackColor = Color.LightGray;
                        cell1.Style.DrawFill = true;
                        GridViewCellInfo cell2 = remark_grid.Rows[i].Cells[2];
                        cell2.Style.CustomizeFill = true;
                        cell2.Style.BackColor = Color.LightGray;
                        cell2.Style.DrawFill = true;
                        GridViewCellInfo cell3 = remark_grid.Rows[i].Cells[3];
                        cell3.Style.CustomizeFill = true;
                        cell3.Style.BackColor = Color.LightGray;
                        cell3.Style.DrawFill = true;
                    }
                }
            }
        }

        private void gallery_grid_SelectionChanged(object sender, EventArgs e)
        {
            if (gallery_grid.Rows.Count != 0 && !gl_srch)
            {
                byte[] imageData = (byte[])gallery_grid.Rows[gallery_grid.CurrentCell.RowIndex].Cells[1].Value;
                Image newImage;
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);
                    newImage = Image.FromStream(ms, true);
                }
                picture_box.Image = newImage;
            }
            gl_srch = false;
        }

        private void ticket_id_TextChanged(object sender, EventArgs e)
        {
            if (ticket_id.Text != "") //////////////////////////////////////////////////// Edit Mode
            {
                btn_save.Text = "ثبت تیکت";
                Origin.Enabled = false;
                Channel.Enabled = false;
                Type.Enabled = false;
                social_id.Enabled = false;
                social_dt.Enabled = false;
                social_tm.Enabled = false;
                department.Enabled = false;
                order_id.Enabled = false;
                link.Enabled = false;
                reason.Enabled = false;
                reason_sub1.Enabled = false;
                reason_sub2.Enabled = false;
            }
            else ///////////////////////////////////////////////////////////////////////// New Mode
            {
                btn_save.Text = "ویرایش تیکت";
                Origin.Enabled = true;
                Channel.Enabled = true;
                Type.Enabled = true;
                social_id.Enabled = true;
                social_dt.Enabled = true;
                social_tm.Enabled = true;
                department.Enabled = true;
                order_id.Enabled = true;
                link.Enabled = true;
                reason.Enabled = true;
                reason_sub1.Enabled = true;
                reason_sub2.Enabled = true;
            }
        }

        private void btn_copy_link_Click(object sender, EventArgs e)
        {
            if (link.Text != "")
            {
                Clipboard.SetText(link.Text);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (ticket_id.Text == "") /////////////////////////////////////////////////////////// NEW Ticket injection
            {
                if (New_Ticket_Validation())
                {
                    Get_ticket_id();
                    //////////////////////////////////////// Get Date Persian
                    DataTable dt1 = new DataTable();
                    OleDbDataAdapter adp1 = new OleDbDataAdapter();
                    adp1.SelectCommand = new OleDbCommand();
                    adp1.SelectCommand.Connection = oleDbConnection1;
                    oleDbCommand1.Parameters.Clear();
                    string lcommand1 = "SELECT day(GETDATE()), month(GETDATE()), year(GETDATE()), CONVERT(time(0), CURRENT_TIMESTAMP) ";
                    adp1.SelectCommand.CommandText = lcommand1;
                    adp1.Fill(dt1);
                    DateTime persian_date = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
                    ///////////////////////////////////////// Convert Persian
                    PersianCalendar psdate = new PersianCalendar();
                    DT_Day = (psdate.GetDayOfMonth(persian_date).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(persian_date).ToString() : psdate.GetDayOfMonth(persian_date).ToString();
                    DT_Mth = (psdate.GetMonth(persian_date).ToString().Length == 1) ? "0" + psdate.GetMonth(persian_date).ToString() : psdate.GetMonth(persian_date).ToString();
                    DT_Yr = psdate.GetYear(persian_date).ToString();
                    
                    
                    ///////////////////////////////////////////////////////////////////////////////// Injection in DB
                    oleDbCommand1.Parameters.Clear();
                    oleDbCommand1.CommandText = "INSERT INTO [SNAPP_CC_EVALUATION].[dbo].[SM_TICKETING] ([TKT_ID],[Year],[Month],[Social_Media],[Channel],[TKT_Type],[Social_User_Nm],[Social_Insrt_Dt],[Social_Insrt_Tm] " +
                                                ",[TKT_Dep],[Order_No],[TKT_Link],[TKT_RSN],[TKT_RSN_Sub1],[TKT_RSN_Sub2],[TKT_Status],[TKT_Insrt_DT_Per],[TKT_Insrt_usr],[TKT_Closed],[TKT_Insrt_DT],[TKT_Insrt_TM]) " +
                                                "values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,GETDATE(),GETDATE())";
                    oleDbCommand1.Parameters.AddWithValue("@TKT_ID", ticket_id.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Year", DT_Yr);
                    oleDbCommand1.Parameters.AddWithValue("@Month", DT_Mth);
                    oleDbCommand1.Parameters.AddWithValue("@Social_Media", Origin.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Channel", Channel.Text);
                    oleDbCommand1.Parameters.AddWithValue("@TKT_Type", Type.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Social_User_Nm", social_id.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Social_Insrt_Dt", social_dt.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Social_Insrt_Tm", social_tm.Text);
                    oleDbCommand1.Parameters.AddWithValue("@TKT_Dep", department.Text);
                    oleDbCommand1.Parameters.AddWithValue("@Order_No", order_id.Text);
                    oleDbCommand1.Parameters.AddWithValue("@TKT_Link", link.Text);
                    oleDbCommand1.Parameters.AddWithValue("@TKT_RSN", reason.Text);
                    oleDbCommand1.Parameters.AddWithValue("@TKT_RSN_Sub1", reason_sub1.Text);
                    oleDbCommand1.Parameters.AddWithValue("@TKT_RSN_Sub2", reason_sub2.Text);
                    oleDbCommand1.Parameters.AddWithValue("@TKT_Status", "جدید");
                    oleDbCommand1.Parameters.AddWithValue("@TKT_Insrt_DT_Per", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                    oleDbCommand1.Parameters.AddWithValue("@TKT_Insrt_usr", user); 
                    oleDbCommand1.Parameters.AddWithValue("@TKT_Closed", false);

                    oleDbConnection1.Open();
                    oleDbCommand1.ExecuteNonQuery();
                    oleDbConnection1.Close();

                    search();

                    RadMessageBox.Show(this, " تیکت با شماره  " + ticket_id.Text + " با موفقیت ثبت شد. " + "\n", "ایجاد تیکت جدید", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
            }
            else //////////////////////////////////////////////////////////////////////////////// Update current Ticket
            {
                if (ticket_status.Text != "جدید")
                {
                    if (last_state != ticket_status.Text)
                    {
                        if (ticket_status.Text == "در حال بررسی")
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
                            DateTime persian_date = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
                            ///////////////////////////////////////// Convert Persian
                            PersianCalendar psdate = new PersianCalendar();
                            DT_Day = (psdate.GetDayOfMonth(persian_date).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(persian_date).ToString() : psdate.GetDayOfMonth(persian_date).ToString();
                            DT_Mth = (psdate.GetMonth(persian_date).ToString().Length == 1) ? "0" + psdate.GetMonth(persian_date).ToString() : psdate.GetMonth(persian_date).ToString();
                            DT_Yr = psdate.GetYear(persian_date).ToString();

                            oleDbCommand1.Parameters.Clear();
                            oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[SM_TICKETING] SET [TKT_Status] = ? ,[TKT_Update_DT] = convert(date,getdate()) ,[TKT_Update_DT_Per] = ? ,[TKT_Update_TM] = convert(time(0),getdate()) ,[TKT_Update_usr] = ? " +
                                                       ", [TKT_Closed] = 0 ,[TKT_Close_DT] = NULL ,[TKT_Close_DT_Per] = NULL ,[TKT_Close_TM] = NULL, [TKT_Close_usr] = NULL WHERE [TKT_ID] = '" + ticket_id.Text + "'";
                            oleDbCommand1.Parameters.AddWithValue("@TKT_Status", ticket_status.Text);
                            oleDbCommand1.Parameters.AddWithValue("@TKT_Update_DT_Per", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                            oleDbCommand1.Parameters.AddWithValue("@TKT_Update_usr", user);

                            oleDbConnection1.Open();
                            oleDbCommand1.ExecuteNonQuery();
                            oleDbConnection1.Close();

                            search();

                            RadMessageBox.Show(this, " تغییر وضعیت با موفقیت ثبت شد. " + "\n", "ثبت تغییرات", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                        }
                        else
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
                            DateTime persian_date = DateTime.Parse(dt1.Rows[0][2].ToString() + "/" + dt1.Rows[0][1].ToString() + "/" + dt1.Rows[0][0].ToString());
                            ///////////////////////////////////////// Convert Persian
                            PersianCalendar psdate = new PersianCalendar();
                            DT_Day = (psdate.GetDayOfMonth(persian_date).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(persian_date).ToString() : psdate.GetDayOfMonth(persian_date).ToString();
                            DT_Mth = (psdate.GetMonth(persian_date).ToString().Length == 1) ? "0" + psdate.GetMonth(persian_date).ToString() : psdate.GetMonth(persian_date).ToString();
                            DT_Yr = psdate.GetYear(persian_date).ToString();

                            oleDbCommand1.Parameters.Clear();
                            oleDbCommand1.CommandText = "UPDATE [SNAPP_CC_EVALUATION].[dbo].[SM_TICKETING] SET [TKT_Status] = ? ,[TKT_Closed] = 1 ,[TKT_Close_DT] = convert(date,getdate()) ,[TKT_Close_DT_Per] = ? ,[TKT_Close_TM] = convert(time(0),getdate()), [TKT_Close_usr] = ? " + //--
                                                       " WHERE [TKT_ID] = '" + ticket_id.Text + "'";
                            oleDbCommand1.Parameters.AddWithValue("@TKT_Status", ticket_status.Text);
                            oleDbCommand1.Parameters.AddWithValue("@TKT_Close_DT_Per", DT_Yr + "/" + DT_Mth + "/" + DT_Day);
                            oleDbCommand1.Parameters.AddWithValue("@TKT_Close_usr", user);

                            oleDbConnection1.Open();
                            oleDbCommand1.ExecuteNonQuery();
                            oleDbConnection1.Close();

                            search();

                            RadMessageBox.Show(this, " تغییر وضعیت با موفقیت ثبت شد. " + "\n", "ثبت تغییرات", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                        }
                    }
                    else
                    {
                        RadMessageBox.Show(this, " تغییری جهت ثبت یافت نشد. " + "\n", "عدم تغییر", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                    }
                }
                else
                {
                    RadMessageBox.Show(this, " شما مجاز به تغییر وضعیت تیکت به وضعیت *جدید* نیستید " + "\n", "تغییر وضعیت غیر مجاز", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
                }
            }
        }

        public void Get_ticket_id()
        {
            string DT_Yr2;
            string DT_Mth2;
            string DT_Day2;
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
            DT_Day2 = (psdate.GetDayOfMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetDayOfMonth(datetime).ToString() : psdate.GetDayOfMonth(datetime).ToString();
            DT_Mth2 = (psdate.GetMonth(datetime).ToString().Length == 1) ? "0" + psdate.GetMonth(datetime).ToString() : psdate.GetMonth(datetime).ToString();
            DT_Yr2 = psdate.GetYear(datetime).ToString();//.Substring(1,1);
            //DT_TM = dt1.Rows[0][3].ToString().Substring(0, 5);
            ///////////////////////////////////////////////// GET QC_ID
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT max([TKT_ID]) FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKETING] where [Year] = '" + DT_Yr2 + "' and [Month] = '" + DT_Mth2 + "'";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            int batch_no_NO;
            if (dt4.Rows[0][0].ToString() == "")
            {
                ticket_id.Text = DT_Yr2.Substring(2, 2) + DT_Mth2 + "0000";
            }
            else
            {
                batch_no_NO = int.Parse(dt4.Rows[0][0].ToString().Substring(4, 4)) + 1;
                if (batch_no_NO < 10)
                {
                    ticket_id.Text = DT_Yr2.Substring(2, 2) + DT_Mth2 + "000" + batch_no_NO.ToString();
                }
                else if (batch_no_NO < 100)
                {
                    ticket_id.Text = DT_Yr2.Substring(2, 2) + DT_Mth2 + "00" + batch_no_NO.ToString();
                }
                else if (batch_no_NO < 1000)
                {
                    ticket_id.Text = DT_Yr2.Substring(2, 2) + DT_Mth2 + "0" + batch_no_NO.ToString();
                }
                else
                {
                    ticket_id.Text = DT_Yr2.Substring(2, 2) + DT_Mth2 + batch_no_NO.ToString();
                }
            }
        }

        public bool New_Ticket_Validation()
        {
            bool error = false;
            errorProvider.Clear();

            if (Origin.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Origin, "شبکه اجتماعی نشده است.");
                error = true;
            }
            if (Channel.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Channel, "کانال انتخاب نشده است.");
                error = true;
            }
            if (Type.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Type, "نوع تیکت انتخاب نشده است.");
                error = true;
            }
            if (social_id.Text == "")
            {
                this.errorProvider.SetError(this.social_id, "نام کاربری وارد نشده است.");
                error = true;
            }
            if (social_dt.Text == "" || (social_dt.Text.Substring(0,4) != "1397" && social_dt.Text.Substring(0, 4) != "1398"))
            {
                this.errorProvider.SetError(this.social_dt, "تاریخ درج صحیح نیست.");
                error = true;
            }
            if (!social_tm.MaskFull)
            {
                this.errorProvider.SetError(this.social_tm, "ساعت درج صحیح نیست.");
                error = true;
            }
            if (department.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.department, "نوع تیکت انتخاب نشده است.");
                error = true;
            }
            if (reason.SelectedIndex == 0 || reason_sub1.SelectedIndex == 0 || reason_sub2.SelectedIndex == 0)
            {
                this.errorProvider.SetError(this.Reason_Box, "موضوع/زیرگروه های تیکت انتخاب نشده است.");
                error = true;
            }

            DataTable dtsc4 = new DataTable();
            OleDbDataAdapter adpsc4 = new OleDbDataAdapter();
            adpsc4.SelectCommand = new OleDbCommand();
            adpsc4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommandsc4 = "SELECT * FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKETING] where [Social_User_Nm] = N'" + social_id.Text + "' and [Social_Insrt_Dt] = '" + social_dt.Text + "' and [Social_Media] = N'" + Origin.Text + "'";
            adpsc4.SelectCommand.CommandText = lcommandsc4;
            adpsc4.Fill(dtsc4);
            if (dtsc4.Rows.Count != 0)
            {
                RadMessageBox.Show(this, " تیکت دیگری به شماره " + dtsc4.Rows[0][0].ToString() + " از این کاربر با تاریخ درج " + social_dt.Text + "در سامانه یافت شد." +"\n\n" + " مجاز به ثبت تیکت جدید از این کاربر نمی باشید. " + "\n", "اخطار تیکت تکراری", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
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

        private void btn_search_Click(object sender, EventArgs e)
        {
            Social_Media.TICKET_SEARCH ob = new Social_Media.TICKET_SEARCH(this);
            ob.constr = constr;
            ob.user = user;
            ob.ShowDialog();
        }
        
        public void clear()
        {
            scial_dt_lbl.Visible = false;
            ticket_id.Text = "";
            ticket_status.SelectedIndex = 0;
            social_dt.SetToNullValue();
            social_tm.Text = "";
            social_id.Text = "";
            link.Text = "";
            Origin.SelectedIndex = 0;
            Channel.SelectedIndex = 0;
            //Type.SelectedIndex = 0;
            department.SelectedIndex = 0;
            TKT_DT.Text = "";
            answer_qty.Text = "";
            order_id.Text = "";
            reason.SelectedIndex = 0;
            //reason_sub1.SelectedIndex = 0;
            //reason_sub2.SelectedIndex = 0;
            history_grid.DataSource = null;
            remark_grid.DataSource = null;
            history_text.Text = "";
            remark_text.Text = "";
            //history_mood.SelectedIndex = 0;
            history_party.SelectedIndex = 0;
            remark_type.SelectedIndex = 0;
            gallery_grid.DataSource = null;
            picture_box.Image = null;
            last_state = "";
        }

        public void search()
        {
            errorProvider.Clear();
            History_Search();
            Remark_Search();
            Gallery_Search();
            ///////////////////////////////////////////////////// GET Ticket Header Info
            DataTable dt4 = new DataTable();
            OleDbDataAdapter adp4 = new OleDbDataAdapter();
            adp4.SelectCommand = new OleDbCommand();
            adp4.SelectCommand.Connection = oleDbConnection1;
            oleDbCommand1.Parameters.Clear();
            string lcommand4 = "SELECT [Social_Media],[Channel],[TKT_Type],[Social_User_Nm],[Social_Insrt_Dt],[Social_Insrt_Tm],[TKT_Dep],[Order_No],[TKT_Link],[TKT_RSN],[TKT_RSN_Sub1],[TKT_RSN_Sub2],[TKT_Status],[TKT_Insrt_DT_Per],[TKT_Insrt_TM] " +
                                ",[TKT_Insrt_usr] + ' (' + [TKT_Insrt_DT_Per] + ' - ' + substring(convert(nvarchar,[TKT_Insrt_TM]),1,5) + ')' " +
                                ",iif([TKT_Closed] = 0, [TKT_update_usr] + ' (' + [TKT_update_DT_Per] + ' - ' + substring(convert(nvarchar,[TKT_update_TM]),1,5) + ')', [TKT_close_usr] + ' (' + [TKT_close_DT_Per] + ' - ' + substring(convert(nvarchar,[TKT_close_TM]),1,5) + ')')" +
                                "FROM [SNAPP_CC_EVALUATION].[dbo].[SM_TICKETING] WHERE [TKT_ID] = '" + ticket_id.Text + "'";
            adp4.SelectCommand.CommandText = lcommand4;
            adp4.Fill(dt4);
            Origin.Text = dt4.Rows[0][0].ToString();
            Channel.Text = dt4.Rows[0][1].ToString();
            Type.Text = dt4.Rows[0][2].ToString();
            social_id.Text = dt4.Rows[0][3].ToString();
            scial_dt_lbl.Visible = true;
            
            scial_dt_lbl.Text = dt4.Rows[0][4].ToString();
            social_tm.Text = dt4.Rows[0][5].ToString();
            department.Text = dt4.Rows[0][6].ToString();
            order_id.Text = dt4.Rows[0][7].ToString();
            link.Text = dt4.Rows[0][8].ToString();
            reason.Text = dt4.Rows[0][9].ToString();
            reason_sub1.Text = dt4.Rows[0][10].ToString();
            reason_sub2.Text = dt4.Rows[0][11].ToString();
            ticket_status.Text = dt4.Rows[0][12].ToString();
            TKT_DT.Text = dt4.Rows[0][13].ToString() + "\n" + dt4.Rows[0][14].ToString(); ;
            insrt_username.Text = dt4.Rows[0][15].ToString();
            if (dt4.Rows[0][16].ToString() == "")
            {
                update_username.Text = dt4.Rows[0][15].ToString();
            }
            else
            {
                update_username.Text = dt4.Rows[0][16].ToString();
            }
            last_state = ticket_status.Text;
        }

        private void scial_dt_lbl_VisibleChanged(object sender, EventArgs e)
        {
            if (scial_dt_lbl.Visible == true)
            {
                social_dt.Visible = false;
            }
            else
            {
                social_dt.Visible = true;
            }
        }

        private void pic_download_Click(object sender, EventArgs e)
        {
            if (gallery_grid.Rows.Count != 0 && ticket_id.Text != "" & picture_box.Image != null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPG files (*.JPG)|*.JPG";
                saveFileDialog1.FileName = ticket_id.Text + "_" + gallery_grid.SelectedRows[0].Cells[0].Value.ToString();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //picture_box.Image.Save(saveFileDialog1.FileName);
                    byte[] imageData = (byte[])gallery_grid.SelectedRows[0].Cells[1].Value;
                    using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                    {
                        ms.Write(imageData, 0, imageData.Length);
                        //using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                        //{
                        //    //ms.CopyTo(fs);

                        //}
                        System.IO.File.WriteAllBytes(saveFileDialog1.FileName, ms.ToArray());
                    }
                }
            }
        }

        private void scl_usr_clipboard_Click(object sender, EventArgs e)
        {
            if (social_id.Text != "")
            {
                Clipboard.SetText(social_id.Text);
            }
        }

        private void order_id_clipboard_Click(object sender, EventArgs e)
        {
            if (order_id.Text != "")
            {
                Clipboard.SetText(social_id.Text);
            }
        }

        private void btn_new_ticket_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void gallery_grid_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (gallery_grid.Rows.Count != 0 && !gl_srch)
            {
                byte[] imageData = (byte[])gallery_grid.Rows[gallery_grid.CurrentCell.RowIndex].Cells[1].Value;
                Image newImage;
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);
                    newImage = Image.FromStream(ms, true);
                }
                picture_box.Image = newImage;
            }
            gl_srch = false;
        }
    }
}
