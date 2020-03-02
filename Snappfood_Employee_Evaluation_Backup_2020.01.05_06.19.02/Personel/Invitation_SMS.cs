using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.OleDb;
using SmsIrRestful;

namespace SnappFood_Employee_Evaluation.Personel
{

    public partial class Invitation_SMS : Telerik.WinControls.UI.RadForm
    {
        public string token_key;
        public string token_security;
        public string sms_line;
        public string constr;
        private ErrorProvider errorProvider;
        public bool data_error = false;

        public Invitation_SMS()
        {
            InitializeComponent();
            radLabel1.TextAlignment = ContentAlignment.MiddleCenter;
            this.errorProvider = new ErrorProvider();
            errorProvider.RightToLeft = true;
        }

        private void Score_SMS_Load(object sender, EventArgs e)
        {
           
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (AreRequiredFieldsValid())
            {
                ////////////////////////////////////////////////////////// Send SMS
                SmsIrRestful.Token token_instance = new SmsIrRestful.Token();
                var token = token_instance.GetToken(token_key, token_security);

                SmsIrRestful.MessageSend message_instance = new SmsIrRestful.MessageSend();
                var res = message_instance.Send(token, new SmsIrRestful.MessageSendObject()
                {
                    MobileNumbers = new List<string>() { Per_Ntl_ID.Text }.ToArray(),
                    Messages = new List<string>() { radTextBox1.Text + " عزیز \n" + "وقت مصاحبه شما در شرکت دیجی کالا مورخ  " + Invw_Date.Text + " و ساعت " + from_tm.Text + " می باشد. لطفا راس ساعت مقرر در شرکت به آدرس اتوبان اشرفی اصفهانی، بالاتر از مرزداران، کوچه بی نظیر، ساختمان امین، طبقه اول حضور به عمل آورید." + "\n" + "مسئول هماهنگی شما خانم شهروان می باشد." + "\n" + "دیجی کالا" }.ToArray(),
                    LineNumber = sms_line,
                    SendDateTime = null,
                    CanContinueInCaseOfError = false
                });
                RadMessageBox.Show(this, "پیامک با موفقیت ارسال گردید" + "\n", "پیغام", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Yes);
            }
        }

        private bool AreRequiredFieldsValid()
        {
            data_error = false;
            errorProvider.Clear();       
            if (Per_Ntl_ID.Text.Length != 11)
            {
                this.errorProvider.SetError(this.Per_Ntl_ID, "شماره موبایل صحیح وارد نشده است");
                data_error = true;
            }
            if (!Invw_Date.MaskCompleted)
            {
                this.errorProvider.SetError(this.Invw_Date, "تاریخ صحیح وارد نشده است");
                data_error = true;
            }
            if (!from_tm.MaskCompleted)
            {
                this.errorProvider.SetError(this.from_tm, "ساعت صحیح وارد نشده است");
                data_error = true;
            }
            if (radTextBox1.Text == "")
            {
                this.errorProvider.SetError(this.radTextBox1, "نام وارد نشده است");
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
     }
}
