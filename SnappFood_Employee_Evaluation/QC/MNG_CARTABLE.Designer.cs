namespace SnappFood_Employee_Evaluation.QC
{
    partial class MNG_CARTABLE
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
            this.scr_to = new Telerik.WinControls.UI.RadTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.scr_from = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.Taboo = new System.Windows.Forms.CheckBox();
            this.Agent = new System.Windows.Forms.ComboBox();
            this.dt_to = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dt_from = new Telerik.WinControls.UI.RadDateTimePicker();
            this.Call_Type = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.log_announcment = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scr_to)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scr_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_to)).BeginInit();
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
            this.radGroupBox1.Controls.Add(this.scr_to);
            this.radGroupBox1.Controls.Add(this.label6);
            this.radGroupBox1.Controls.Add(this.scr_from);
            this.radGroupBox1.Controls.Add(this.label3);
            this.radGroupBox1.Controls.Add(this.radButton1);
            this.radGroupBox1.Controls.Add(this.Taboo);
            this.radGroupBox1.Controls.Add(this.Agent);
            this.radGroupBox1.Controls.Add(this.dt_to);
            this.radGroupBox1.Controls.Add(this.dt_from);
            this.radGroupBox1.Controls.Add(this.Call_Type);
            this.radGroupBox1.Controls.Add(this.label4);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.label22);
            this.radGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radGroupBox1.HeaderText = "     پنل جستجو     ";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(737, 95);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.Text = "     پنل جستجو     ";
            this.radGroupBox1.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Standard;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.LavenderBlush;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            // 
            // scr_to
            // 
            this.scr_to.Location = new System.Drawing.Point(14, 28);
            this.scr_to.Name = "scr_to";
            this.scr_to.Size = new System.Drawing.Size(58, 20);
            this.scr_to.TabIndex = 35;
            this.scr_to.ThemeName = "Office2010Silver";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(78, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "تا:";
            // 
            // scr_from
            // 
            this.scr_from.Location = new System.Drawing.Point(112, 28);
            this.scr_from.Name = "scr_from";
            this.scr_from.Size = new System.Drawing.Size(58, 20);
            this.scr_from.TabIndex = 34;
            this.scr_from.ThemeName = "Office2010Silver";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(176, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "امتیاز لاگ  از:";
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radButton1.Image = global::SnappFood_Employee_Evaluation.Properties.Resources.search_icon;
            this.radButton1.Location = new System.Drawing.Point(14, 61);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 31;
            this.radButton1.Text = "جستجو";
            this.radButton1.ThemeName = "Office2010Silver";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // Taboo
            // 
            this.Taboo.AutoSize = true;
            this.Taboo.BackColor = System.Drawing.Color.MistyRose;
            this.Taboo.Location = new System.Drawing.Point(177, 64);
            this.Taboo.Name = "Taboo";
            this.Taboo.Size = new System.Drawing.Size(110, 17);
            this.Taboo.TabIndex = 24;
            this.Taboo.Text = "تماس های تابــو";
            this.Taboo.UseVisualStyleBackColor = false;
            // 
            // Agent
            // 
            this.Agent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Agent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Agent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Agent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Agent.FormattingEnabled = true;
            this.Agent.Location = new System.Drawing.Point(441, 27);
            this.Agent.Name = "Agent";
            this.Agent.Size = new System.Drawing.Size(207, 21);
            this.Agent.TabIndex = 29;
            // 
            // dt_to
            // 
            this.dt_to.AutoSize = false;
            this.dt_to.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dt_to.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.dt_to.CustomFormat = "yyyy/MM/dd";
            this.dt_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_to.Location = new System.Drawing.Point(334, 63);
            this.dt_to.Name = "dt_to";
            this.dt_to.Size = new System.Drawing.Size(127, 21);
            this.dt_to.TabIndex = 28;
            this.dt_to.TabStop = false;
            this.dt_to.ThemeName = "Office2010Silver";
            this.dt_to.Value = new System.DateTime(((long)(0)));
            // 
            // dt_from
            // 
            this.dt_from.AutoSize = false;
            this.dt_from.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dt_from.Culture = new System.Globalization.CultureInfo("fa-IR");
            this.dt_from.CustomFormat = "yyyy/MM/dd";
            this.dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_from.Location = new System.Drawing.Point(487, 63);
            this.dt_from.Name = "dt_from";
            this.dt_from.Size = new System.Drawing.Size(132, 21);
            this.dt_from.TabIndex = 27;
            this.dt_from.TabStop = false;
            this.dt_from.ThemeName = "Office2010Silver";
            this.dt_from.Value = new System.DateTime(((long)(0)));
            // 
            // Call_Type
            // 
            this.Call_Type.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Call_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Call_Type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Call_Type.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Call_Type.FormattingEnabled = true;
            this.Call_Type.Location = new System.Drawing.Point(250, 27);
            this.Call_Type.Name = "Call_Type";
            this.Call_Type.Size = new System.Drawing.Size(124, 21);
            this.Call_Type.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(464, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "تا:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(625, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "تاریخ بررسی لاگ از:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(380, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "نوع تماس:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(654, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "نام کارشناس:";
            // 
            // log_announcment
            // 
            this.log_announcment.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.log_announcment.ForeColor = System.Drawing.Color.Crimson;
            this.log_announcment.Location = new System.Drawing.Point(393, 113);
            this.log_announcment.Name = "log_announcment";
            this.log_announcment.Size = new System.Drawing.Size(92, 20);
            this.log_announcment.TabIndex = 9;
            this.log_announcment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(480, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "تعداد لاگ های منتظر بررسی در کارتابل شما:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radGridView1
            // 
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
            this.radGridView1.Size = new System.Drawing.Size(737, 342);
            this.radGridView1.TabIndex = 11;
            this.radGridView1.ThemeName = "Office2010Silver";
            this.radGridView1.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellDoubleClick);
            // 
            // MNG_CARTABLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 496);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.log_announcment);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "MNG_CARTABLE";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "کارتابل مدیر";
            this.ThemeName = "Office2010Silver";
            this.Load += new System.EventHandler(this.QCM_CARTABLE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scr_to)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scr_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_to)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Call_Type;
        private Telerik.WinControls.UI.RadDateTimePicker dt_to;
        private Telerik.WinControls.UI.RadDateTimePicker dt_from;
        private System.Windows.Forms.ComboBox Agent;
        private System.Windows.Forms.Label log_announcment;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadButton radButton1;
        private System.Windows.Forms.CheckBox Taboo;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadTextBox scr_to;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadTextBox scr_from;
        private System.Windows.Forms.Label label3;
    }
}
