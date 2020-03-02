namespace SnappFood_Employee_Evaluation.Social_Media
{ 
    partial class TICKET_SEARCH
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.ticket_id = new Telerik.WinControls.UI.RadTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.order_id = new Telerik.WinControls.UI.RadTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gallery = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.reason = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.social_id = new Telerik.WinControls.UI.RadTextBox();
            this.dt_to = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.dt_from = new Telerik.WinControls.UI.RadDateTimePicker();
            this.tkt_status = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ticket_status = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.log_announcment = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ticket_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.social_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_to)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.ticket_id);
            this.radGroupBox1.Controls.Add(this.label8);
            this.radGroupBox1.Controls.Add(this.order_id);
            this.radGroupBox1.Controls.Add(this.label7);
            this.radGroupBox1.Controls.Add(this.gallery);
            this.radGroupBox1.Controls.Add(this.label6);
            this.radGroupBox1.Controls.Add(this.reason);
            this.radGroupBox1.Controls.Add(this.label3);
            this.radGroupBox1.Controls.Add(this.department);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.social_id);
            this.radGroupBox1.Controls.Add(this.dt_to);
            this.radGroupBox1.Controls.Add(this.radButton1);
            this.radGroupBox1.Controls.Add(this.dt_from);
            this.radGroupBox1.Controls.Add(this.tkt_status);
            this.radGroupBox1.Controls.Add(this.label4);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.ticket_status);
            this.radGroupBox1.Controls.Add(this.label22);
            this.radGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radGroupBox1.HeaderText = "      پنل جستجو تیکت     ";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(846, 95);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.Text = "      پنل جستجو تیکت     ";
            this.radGroupBox1.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Standard;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.LavenderBlush;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            // 
            // ticket_id
            // 
            this.ticket_id.Location = new System.Drawing.Point(681, 28);
            this.ticket_id.Name = "ticket_id";
            this.ticket_id.Size = new System.Drawing.Size(85, 20);
            this.ticket_id.TabIndex = 46;
            this.ticket_id.ThemeName = "Office2010Silver";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(772, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "شماره تیکت:";
            // 
            // order_id
            // 
            this.order_id.Location = new System.Drawing.Point(360, 28);
            this.order_id.Name = "order_id";
            this.order_id.Size = new System.Drawing.Size(84, 20);
            this.order_id.TabIndex = 44;
            this.order_id.ThemeName = "Office2010Silver";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(450, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "شماره سفارش:";
            // 
            // gallery
            // 
            this.gallery.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gallery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gallery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gallery.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gallery.FormattingEnabled = true;
            this.gallery.Items.AddRange(new object[] {
            "",
            "تصویر دارد",
            "تصویر ندارد"});
            this.gallery.Location = new System.Drawing.Point(371, 62);
            this.gallery.Name = "gallery";
            this.gallery.Size = new System.Drawing.Size(99, 21);
            this.gallery.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(476, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "وضعیت گالری:";
            // 
            // reason
            // 
            this.reason.BackColor = System.Drawing.Color.WhiteSmoke;
            this.reason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reason.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reason.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reason.FormattingEnabled = true;
            this.reason.Location = new System.Drawing.Point(7, 27);
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(120, 21);
            this.reason.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(133, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "موضوع:";
            // 
            // department
            // 
            this.department.BackColor = System.Drawing.Color.WhiteSmoke;
            this.department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.department.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.department.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.department.FormattingEnabled = true;
            this.department.Location = new System.Drawing.Point(182, 27);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(120, 21);
            this.department.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(308, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "دپارتمان:";
            // 
            // social_id
            // 
            this.social_id.Location = new System.Drawing.Point(537, 28);
            this.social_id.Name = "social_id";
            this.social_id.Size = new System.Drawing.Size(84, 20);
            this.social_id.TabIndex = 36;
            this.social_id.ThemeName = "Office2010Silver";
            // 
            // dt_to
            // 
            this.dt_to.AutoSize = false;
            this.dt_to.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dt_to.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.dt_to.CustomFormat = "yyyy/MM/dd";
            this.dt_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_to.Location = new System.Drawing.Point(556, 63);
            this.dt_to.Name = "dt_to";
            this.dt_to.Size = new System.Drawing.Size(96, 21);
            this.dt_to.TabIndex = 28;
            this.dt_to.TabStop = false;
            this.dt_to.ThemeName = "Office2010Silver";
            this.dt_to.Value = new System.DateTime(((long)(0)));
            // 
            // radButton1
            // 
            this.radButton1.BackColor = System.Drawing.Color.Azure;
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radButton1.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.search_icon;
            this.radButton1.Location = new System.Drawing.Point(7, 61);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(90, 24);
            this.radButton1.TabIndex = 31;
            this.radButton1.Text = "جستجو";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton1.ThemeName = "Office2010Silver";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // dt_from
            // 
            this.dt_from.AutoSize = false;
            this.dt_from.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dt_from.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.dt_from.CustomFormat = "yyyy/MM/dd";
            this.dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_from.Location = new System.Drawing.Point(681, 63);
            this.dt_from.Name = "dt_from";
            this.dt_from.Size = new System.Drawing.Size(96, 21);
            this.dt_from.TabIndex = 27;
            this.dt_from.TabStop = false;
            this.dt_from.ThemeName = "Office2010Silver";
            this.dt_from.Value = new System.DateTime(((long)(0)));
            // 
            // tkt_status
            // 
            this.tkt_status.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tkt_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tkt_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tkt_status.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tkt_status.FormattingEnabled = true;
            this.tkt_status.Location = new System.Drawing.Point(115, 62);
            this.tkt_status.Name = "tkt_status";
            this.tkt_status.Size = new System.Drawing.Size(173, 21);
            this.tkt_status.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(658, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "تا:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(783, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "تاریخ ایجاد:";
            // 
            // ticket_status
            // 
            this.ticket_status.AutoSize = true;
            this.ticket_status.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ticket_status.Location = new System.Drawing.Point(294, 65);
            this.ticket_status.Name = "ticket_status";
            this.ticket_status.Size = new System.Drawing.Size(71, 13);
            this.ticket_status.TabIndex = 13;
            this.ticket_status.Text = "وضعیت تیکت:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(627, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "نام کاربر:";
            // 
            // log_announcment
            // 
            this.log_announcment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log_announcment.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.log_announcment.ForeColor = System.Drawing.Color.Crimson;
            this.log_announcment.Location = new System.Drawing.Point(616, 113);
            this.log_announcment.Name = "log_announcment";
            this.log_announcment.Size = new System.Drawing.Size(92, 20);
            this.log_announcment.TabIndex = 9;
            this.log_announcment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(714, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "تعداد رکورد یافت شده:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radGridView1.Location = new System.Drawing.Point(12, 142);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.ShowFilteringRow = false;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.ShowGroupPanelScrollbars = false;
            this.radGridView1.ShowNoDataText = false;
            this.radGridView1.Size = new System.Drawing.Size(846, 354);
            this.radGridView1.TabIndex = 11;
            this.radGridView1.ThemeName = "Office2010Silver";
            this.radGridView1.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellDoubleClick);
            // 
            // TICKET_SEARCH
            // 
            this.AcceptButton = this.radButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 508);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.log_announcment);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "TICKET_SEARCH";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جستجوی تیکت شبکه های اجتماعی";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.QCM_CARTABLE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ticket_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.social_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_to)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label ticket_status;
        private System.Windows.Forms.ComboBox tkt_status;
        private System.Windows.Forms.Label log_announcment;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadTextBox social_id;
        private Telerik.WinControls.UI.RadDateTimePicker dt_to;
        private Telerik.WinControls.UI.RadDateTimePicker dt_from;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox reason;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox gallery;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadTextBox order_id;
        private System.Windows.Forms.Label label7;
        private Telerik.WinControls.UI.RadTextBox ticket_id;
        private System.Windows.Forms.Label label8;
    }
}
