namespace SnappFood_Employee_Evaluation.After_Sales
{
    partial class RPT_INBOUND_DASHBOARD
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.Header = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radGroupBox6 = new Telerik.WinControls.UI.RadGroupBox();
            this.Productivity = new System.Windows.Forms.Label();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.total_gauge = new Telerik.WinControls.UI.Gauges.RadRadialGauge();
            this.lbl_tot_inbound = new System.Windows.Forms.Label();
            this.radialGaugeArc5 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeArc6 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeNeedle3 = new Telerik.WinControls.UI.Gauges.RadialGaugeNeedle();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radChartView1 = new Telerik.WinControls.UI.RadChartView();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.radChartView2 = new Telerik.WinControls.UI.RadChartView();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.Ass_Back = new System.Windows.Forms.Label();
            this.radGroupBox5 = new Telerik.WinControls.UI.RadGroupBox();
            this.Proc_Back = new System.Windows.Forms.Label();
            this.Shifting_Page = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.radLabel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).BeginInit();
            this.radGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.total_gauge)).BeginInit();
            this.total_gauge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).BeginInit();
            this.radGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.AutoScroll = true;
            this.radGridView1.Font = new System.Drawing.Font("IRANSansWeb", 35F, System.Drawing.FontStyle.Bold);
            this.radGridView1.Location = new System.Drawing.Point(0, 98);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.MasterTemplate.ShowFilteringRow = false;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.ShowGroupPanelScrollbars = false;
            this.radGridView1.ShowNoDataText = false;
            this.radGridView1.Size = new System.Drawing.Size(1728, 270);
            this.radGridView1.TabIndex = 69;
            this.radGridView1.ThemeName = "Office2010Silver";
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // Header
            // 
            this.Header.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Header.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.Navy;
            this.Header.Location = new System.Drawing.Point(1333, 0);
            this.Header.Name = "Header";
            this.Header.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Header.Size = new System.Drawing.Size(392, 98);
            this.Header.TabIndex = 3;
            this.Header.Text = "Date:";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Controls.Add(this.Header);
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold);
            this.radLabel1.ForeColor = System.Drawing.Color.Red;
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radLabel1.Size = new System.Drawing.Size(1728, 98);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "DigiKala After Sales Live Dashboard - Inbound";
            // 
            // radGroupBox6
            // 
            this.radGroupBox6.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox6.Controls.Add(this.Productivity);
            this.radGroupBox6.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold);
            this.radGroupBox6.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox6.HeaderText = "   Team Productivity   ";
            this.radGroupBox6.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.radGroupBox6.Location = new System.Drawing.Point(12, 386);
            this.radGroupBox6.Name = "radGroupBox6";
            this.radGroupBox6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGroupBox6.Size = new System.Drawing.Size(626, 136);
            this.radGroupBox6.TabIndex = 86;
            this.radGroupBox6.Text = "   Team Productivity   ";
            this.radGroupBox6.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox6.GetChildAt(0))).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox6.GetChildAt(0).GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox6.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Standard;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox6.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox6.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.LavenderBlush;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox6.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            // 
            // Productivity
            // 
            this.Productivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Productivity.Font = new System.Drawing.Font("Tahoma", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Productivity.ForeColor = System.Drawing.Color.Green;
            this.Productivity.Location = new System.Drawing.Point(8, 54);
            this.Productivity.Name = "Productivity";
            this.Productivity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Productivity.Size = new System.Drawing.Size(613, 71);
            this.Productivity.TabIndex = 87;
            this.Productivity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.total_gauge);
            this.radGroupBox1.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold);
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "   Total Inbound   ";
            this.radGroupBox1.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.radGroupBox1.Location = new System.Drawing.Point(14, 536);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGroupBox1.Size = new System.Drawing.Size(624, 433);
            this.radGroupBox1.TabIndex = 88;
            this.radGroupBox1.Text = "   Total Inbound   ";
            this.radGroupBox1.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox1.GetChildAt(0))).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Standard;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.LavenderBlush;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            // 
            // total_gauge
            // 
            this.total_gauge.BackColor = System.Drawing.Color.Transparent;
            this.total_gauge.CausesValidation = false;
            this.total_gauge.Controls.Add(this.lbl_tot_inbound);
            this.total_gauge.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radialGaugeArc5,
            this.radialGaugeArc6,
            this.radialGaugeNeedle3});
            this.total_gauge.Location = new System.Drawing.Point(14, 57);
            this.total_gauge.Name = "total_gauge";
            this.total_gauge.Size = new System.Drawing.Size(605, 513);
            this.total_gauge.StartAngle = 180D;
            this.total_gauge.SweepAngle = 180D;
            this.total_gauge.TabIndex = 84;
            this.total_gauge.Text = "radRadialGauge3";
            this.total_gauge.ThemeName = "Office2010Silver";
            this.total_gauge.Value = 0F;
            // 
            // lbl_tot_inbound
            // 
            this.lbl_tot_inbound.Font = new System.Drawing.Font("Tahoma", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tot_inbound.ForeColor = System.Drawing.Color.Navy;
            this.lbl_tot_inbound.Location = new System.Drawing.Point(20, 283);
            this.lbl_tot_inbound.Name = "lbl_tot_inbound";
            this.lbl_tot_inbound.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_tot_inbound.Size = new System.Drawing.Size(589, 93);
            this.lbl_tot_inbound.TabIndex = 77;
            this.lbl_tot_inbound.Text = "--";
            this.lbl_tot_inbound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radialGaugeArc5
            // 
            this.radialGaugeArc5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(84)))), ((int)(((byte)(190)))));
            this.radialGaugeArc5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(84)))), ((int)(((byte)(190)))));
            this.radialGaugeArc5.BindEndRange = true;
            this.radialGaugeArc5.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc5.Name = "radialGaugeArc5";
            this.radialGaugeArc5.RangeEnd = 0D;
            this.radialGaugeArc5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc5.UseCompatibleTextRendering = false;
            this.radialGaugeArc5.Width = 40D;
            // 
            // radialGaugeArc6
            // 
            this.radialGaugeArc6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.radialGaugeArc6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.radialGaugeArc6.BindStartRange = true;
            this.radialGaugeArc6.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc6.Name = "radialGaugeArc6";
            this.radialGaugeArc6.RangeEnd = 100D;
            this.radialGaugeArc6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc6.UseCompatibleTextRendering = false;
            this.radialGaugeArc6.Width = 40D;
            // 
            // radialGaugeNeedle3
            // 
            this.radialGaugeNeedle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.radialGaugeNeedle3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.radialGaugeNeedle3.BackLenghtPercentage = 0D;
            this.radialGaugeNeedle3.BindValue = true;
            this.radialGaugeNeedle3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeNeedle3.InnerPointRadiusPercentage = 0D;
            this.radialGaugeNeedle3.LenghtPercentage = 94D;
            this.radialGaugeNeedle3.Name = "radialGaugeNeedle3";
            this.radialGaugeNeedle3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeNeedle3.Thickness = 5D;
            this.radialGaugeNeedle3.UseCompatibleTextRendering = false;
            this.radialGaugeNeedle3.Value = 0F;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radGroupBox2.Controls.Add(this.radChartView1);
            this.radGroupBox2.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold);
            this.radGroupBox2.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox2.HeaderText = "   Nature   ";
            this.radGroupBox2.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.radGroupBox2.Location = new System.Drawing.Point(551, 536);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGroupBox2.Size = new System.Drawing.Size(626, 433);
            this.radGroupBox2.TabIndex = 89;
            this.radGroupBox2.Text = "   Nature   ";
            this.radGroupBox2.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox2.GetChildAt(0))).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox2.GetChildAt(0).GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox2.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Standard;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox2.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.LavenderBlush;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            // 
            // radChartView1
            // 
            this.radChartView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.radChartView1.AreaType = Telerik.WinControls.UI.ChartAreaType.Pie;
            this.radChartView1.BackColor = System.Drawing.SystemColors.Control;
            this.radChartView1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.radChartView1.Location = new System.Drawing.Point(5, 48);
            this.radChartView1.Name = "radChartView1";
            this.radChartView1.ShowGrid = false;
            this.radChartView1.Size = new System.Drawing.Size(617, 380);
            this.radChartView1.TabIndex = 85;
            this.radChartView1.ThemeName = "Office2010Silver";
            this.radChartView1.Title = "پذیرش 3 ماه گذشته";
            this.radChartView1.LabelFormatting += new Telerik.WinControls.UI.ChartViewLabelFormattingEventHandler(this.radChartView1_LabelFormatting);
            ((Telerik.WinControls.UI.RadChartElement)(this.radChartView1.GetChildAt(0))).BorderColor = System.Drawing.SystemColors.Control;
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox3.Controls.Add(this.radChartView2);
            this.radGroupBox3.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold);
            this.radGroupBox3.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox3.HeaderText = "   Origin   ";
            this.radGroupBox3.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.radGroupBox3.Location = new System.Drawing.Point(1089, 536);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGroupBox3.Size = new System.Drawing.Size(627, 433);
            this.radGroupBox3.TabIndex = 90;
            this.radGroupBox3.Text = "   Origin   ";
            this.radGroupBox3.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox3.GetChildAt(0))).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox3.GetChildAt(0).GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox3.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Standard;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox3.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox3.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.LavenderBlush;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox3.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            // 
            // radChartView2
            // 
            this.radChartView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radChartView2.AreaType = Telerik.WinControls.UI.ChartAreaType.Pie;
            this.radChartView2.BackColor = System.Drawing.SystemColors.Control;
            this.radChartView2.Location = new System.Drawing.Point(5, 48);
            this.radChartView2.Name = "radChartView2";
            this.radChartView2.ShowGrid = false;
            this.radChartView2.Size = new System.Drawing.Size(617, 380);
            this.radChartView2.TabIndex = 86;
            this.radChartView2.ThemeName = "Office2010Silver";
            this.radChartView2.Title = "پذیرش 3 ماه گذشته";
            this.radChartView2.LabelFormatting += new Telerik.WinControls.UI.ChartViewLabelFormattingEventHandler(this.radChartView2_LabelFormatting);
            ((Telerik.WinControls.UI.RadChartElement)(this.radChartView2.GetChildAt(0))).BorderColor = System.Drawing.SystemColors.Control;
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radGroupBox4.Controls.Add(this.Ass_Back);
            this.radGroupBox4.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold);
            this.radGroupBox4.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox4.HeaderText = "   Pending Assign   ";
            this.radGroupBox4.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.radGroupBox4.Location = new System.Drawing.Point(551, 386);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGroupBox4.Size = new System.Drawing.Size(626, 136);
            this.radGroupBox4.TabIndex = 88;
            this.radGroupBox4.Text = "   Pending Assign   ";
            this.radGroupBox4.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox4.GetChildAt(0))).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox4.GetChildAt(0).GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox4.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Standard;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox4.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox4.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.LavenderBlush;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox4.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            // 
            // Ass_Back
            // 
            this.Ass_Back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ass_Back.Font = new System.Drawing.Font("Tahoma", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ass_Back.ForeColor = System.Drawing.Color.Green;
            this.Ass_Back.Location = new System.Drawing.Point(8, 54);
            this.Ass_Back.Name = "Ass_Back";
            this.Ass_Back.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Ass_Back.Size = new System.Drawing.Size(613, 71);
            this.Ass_Back.TabIndex = 87;
            this.Ass_Back.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radGroupBox5
            // 
            this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox5.Controls.Add(this.Proc_Back);
            this.radGroupBox5.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold);
            this.radGroupBox5.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox5.HeaderText = "   Processing Backlog   ";
            this.radGroupBox5.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.radGroupBox5.Location = new System.Drawing.Point(1089, 386);
            this.radGroupBox5.Name = "radGroupBox5";
            this.radGroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGroupBox5.Size = new System.Drawing.Size(626, 136);
            this.radGroupBox5.TabIndex = 92;
            this.radGroupBox5.Text = "   Processing Backlog   ";
            this.radGroupBox5.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox5.GetChildAt(0))).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox5.GetChildAt(0).GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox5.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Standard;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox5.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.Pink;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox5.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.LavenderBlush;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radGroupBox5.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Pink;
            // 
            // Proc_Back
            // 
            this.Proc_Back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Proc_Back.Font = new System.Drawing.Font("Tahoma", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Proc_Back.ForeColor = System.Drawing.Color.Green;
            this.Proc_Back.Location = new System.Drawing.Point(8, 54);
            this.Proc_Back.Name = "Proc_Back";
            this.Proc_Back.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Proc_Back.Size = new System.Drawing.Size(613, 71);
            this.Proc_Back.TabIndex = 87;
            this.Proc_Back.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Shifting_Page
            // 
            this.Shifting_Page.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Shifting_Page.BackColor = System.Drawing.Color.Black;
            this.Shifting_Page.Font = new System.Drawing.Font("Tahoma", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shifting_Page.ForeColor = System.Drawing.Color.White;
            this.Shifting_Page.Location = new System.Drawing.Point(0, 0);
            this.Shifting_Page.Name = "Shifting_Page";
            this.Shifting_Page.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Shifting_Page.Size = new System.Drawing.Size(1725, 979);
            this.Shifting_Page.TabIndex = 93;
            this.Shifting_Page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RPT_INBOUND_DASHBOARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1728, 972);
            this.Controls.Add(this.Shifting_Page);
            this.Controls.Add(this.radGroupBox5);
            this.Controls.Add(this.radGroupBox4);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radGroupBox6);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RPT_INBOUND_DASHBOARD";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "داشبورد مانیتورینگ خدمات پس از فروش";
            this.ThemeName = "Office2010Silver";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QC_GENERAL_REPORT_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QC_GENERAL_REPORT_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.radLabel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).EndInit();
            this.radGroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.total_gauge)).EndInit();
            this.total_gauge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radChartView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).EndInit();
            this.radGroupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Timer timer1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox6;
        private System.Windows.Forms.Label Productivity;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.Gauges.RadRadialGauge total_gauge;
        private System.Windows.Forms.Label lbl_tot_inbound;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc5;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc6;
        private Telerik.WinControls.UI.Gauges.RadialGaugeNeedle radialGaugeNeedle3;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadChartView radChartView1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadChartView radChartView2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private System.Windows.Forms.Label Ass_Back;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox5;
        private System.Windows.Forms.Label Proc_Back;
        private System.Windows.Forms.Label Shifting_Page;
    }
}
