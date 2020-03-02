namespace SnappFood_Employee_Evaluation.QC
{
    partial class RPT_QC_DASHBOARD
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
            this.amw_gauge = new Telerik.WinControls.UI.Gauges.RadRadialGauge();
            this.lbl_tot_amw = new System.Windows.Forms.Label();
            this.radialGaugeArc1 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeArc2 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeNeedle1 = new Telerik.WinControls.UI.Gauges.RadialGaugeNeedle();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aht_gauge = new Telerik.WinControls.UI.Gauges.RadRadialGauge();
            this.lbl_tot_aht = new System.Windows.Forms.Label();
            this.radialGaugeArc3 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeArc4 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeNeedle2 = new Telerik.WinControls.UI.Gauges.RadialGaugeNeedle();
            this.label5 = new System.Windows.Forms.Label();
            this.total_gauge = new Telerik.WinControls.UI.Gauges.RadRadialGauge();
            this.lbl_tot_monitored = new System.Windows.Forms.Label();
            this.radialGaugeArc5 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeArc6 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeNeedle3 = new Telerik.WinControls.UI.Gauges.RadialGaugeNeedle();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.test_label = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amw_gauge)).BeginInit();
            this.amw_gauge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aht_gauge)).BeginInit();
            this.aht_gauge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.total_gauge)).BeginInit();
            this.total_gauge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.test_label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.radLabel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGridView1.Font = new System.Drawing.Font("IRANSansWeb", 15.5F, System.Drawing.FontStyle.Bold);
            this.radGridView1.Location = new System.Drawing.Point(0, 66);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.radGridView1.MasterTemplate.ShowFilteringRow = false;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.ShowGroupPanelScrollbars = false;
            this.radGridView1.ShowNoDataText = false;
            this.radGridView1.Size = new System.Drawing.Size(1378, 359);
            this.radGridView1.TabIndex = 69;
            this.radGridView1.ThemeName = "Office2010Silver";
            this.radGridView1.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.radGridView1_CellFormatting);
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // Header
            // 
            this.Header.Font = new System.Drawing.Font("IRANSansWeb", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.Navy;
            this.Header.Location = new System.Drawing.Point(3, 0);
            this.Header.Name = "Header";
            this.Header.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Header.Size = new System.Drawing.Size(278, 66);
            this.Header.TabIndex = 3;
            this.Header.Text = "تاریخ:";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // amw_gauge
            // 
            this.amw_gauge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.amw_gauge.BackColor = System.Drawing.Color.Transparent;
            this.amw_gauge.CausesValidation = false;
            this.amw_gauge.Controls.Add(this.lbl_tot_amw);
            this.amw_gauge.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radialGaugeArc1,
            this.radialGaugeArc2,
            this.radialGaugeNeedle1});
            this.amw_gauge.Location = new System.Drawing.Point(626, 465);
            this.amw_gauge.Name = "amw_gauge";
            this.amw_gauge.Size = new System.Drawing.Size(301, 277);
            this.amw_gauge.StartAngle = 180D;
            this.amw_gauge.SweepAngle = 180D;
            this.amw_gauge.TabIndex = 6;
            this.amw_gauge.Text = "radRadialGauge1";
            this.amw_gauge.ThemeName = "Office2010Silver";
            this.amw_gauge.Value = 0F;
            // 
            // lbl_tot_amw
            // 
            this.lbl_tot_amw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_tot_amw.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tot_amw.ForeColor = System.Drawing.Color.Navy;
            this.lbl_tot_amw.Location = new System.Drawing.Point(0, 139);
            this.lbl_tot_amw.Name = "lbl_tot_amw";
            this.lbl_tot_amw.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_tot_amw.Size = new System.Drawing.Size(301, 138);
            this.lbl_tot_amw.TabIndex = 79;
            this.lbl_tot_amw.Text = "--";
            this.lbl_tot_amw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radialGaugeArc1
            // 
            this.radialGaugeArc1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(84)))), ((int)(((byte)(190)))));
            this.radialGaugeArc1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(84)))), ((int)(((byte)(190)))));
            this.radialGaugeArc1.BindEndRange = true;
            this.radialGaugeArc1.Name = "radialGaugeArc1";
            this.radialGaugeArc1.RangeEnd = 0D;
            this.radialGaugeArc1.Width = 40D;
            // 
            // radialGaugeArc2
            // 
            this.radialGaugeArc2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.radialGaugeArc2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.radialGaugeArc2.BindStartRange = true;
            this.radialGaugeArc2.Name = "radialGaugeArc2";
            this.radialGaugeArc2.RangeEnd = 100D;
            this.radialGaugeArc2.Width = 40D;
            // 
            // radialGaugeNeedle1
            // 
            this.radialGaugeNeedle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.radialGaugeNeedle1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.radialGaugeNeedle1.BackLenghtPercentage = 0D;
            this.radialGaugeNeedle1.BindValue = true;
            this.radialGaugeNeedle1.InnerPointRadiusPercentage = 0D;
            this.radialGaugeNeedle1.LenghtPercentage = 94D;
            this.radialGaugeNeedle1.Name = "radialGaugeNeedle1";
            this.radialGaugeNeedle1.Thickness = 5D;
            this.radialGaugeNeedle1.Value = 0F;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(632, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 52);
            this.label1.TabIndex = 72;
            this.label1.Text = "AMW";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(327, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 52);
            this.label3.TabIndex = 74;
            this.label3.Text = "AHT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aht_gauge
            // 
            this.aht_gauge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.aht_gauge.BackColor = System.Drawing.Color.Transparent;
            this.aht_gauge.CausesValidation = false;
            this.aht_gauge.Controls.Add(this.lbl_tot_aht);
            this.aht_gauge.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radialGaugeArc3,
            this.radialGaugeArc4,
            this.radialGaugeNeedle2});
            this.aht_gauge.Location = new System.Drawing.Point(319, 465);
            this.aht_gauge.Name = "aht_gauge";
            this.aht_gauge.Size = new System.Drawing.Size(301, 277);
            this.aht_gauge.StartAngle = 180D;
            this.aht_gauge.SweepAngle = 180D;
            this.aht_gauge.TabIndex = 73;
            this.aht_gauge.Text = "radRadialGauge2";
            this.aht_gauge.ThemeName = "Office2010Silver";
            this.aht_gauge.Value = 0F;
            // 
            // lbl_tot_aht
            // 
            this.lbl_tot_aht.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_tot_aht.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tot_aht.ForeColor = System.Drawing.Color.Navy;
            this.lbl_tot_aht.Location = new System.Drawing.Point(0, 139);
            this.lbl_tot_aht.Name = "lbl_tot_aht";
            this.lbl_tot_aht.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_tot_aht.Size = new System.Drawing.Size(301, 138);
            this.lbl_tot_aht.TabIndex = 78;
            this.lbl_tot_aht.Text = "--";
            this.lbl_tot_aht.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radialGaugeArc3
            // 
            this.radialGaugeArc3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(84)))), ((int)(((byte)(190)))));
            this.radialGaugeArc3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(84)))), ((int)(((byte)(190)))));
            this.radialGaugeArc3.BindEndRange = true;
            this.radialGaugeArc3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc3.Name = "radialGaugeArc3";
            this.radialGaugeArc3.RangeEnd = 0D;
            this.radialGaugeArc3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc3.UseCompatibleTextRendering = false;
            this.radialGaugeArc3.Width = 40D;
            // 
            // radialGaugeArc4
            // 
            this.radialGaugeArc4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.radialGaugeArc4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.radialGaugeArc4.BindStartRange = true;
            this.radialGaugeArc4.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc4.Name = "radialGaugeArc4";
            this.radialGaugeArc4.RangeEnd = 100D;
            this.radialGaugeArc4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc4.UseCompatibleTextRendering = false;
            this.radialGaugeArc4.Width = 40D;
            // 
            // radialGaugeNeedle2
            // 
            this.radialGaugeNeedle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.radialGaugeNeedle2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.radialGaugeNeedle2.BackLenghtPercentage = 0D;
            this.radialGaugeNeedle2.BindValue = true;
            this.radialGaugeNeedle2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeNeedle2.InnerPointRadiusPercentage = 0D;
            this.radialGaugeNeedle2.LenghtPercentage = 94D;
            this.radialGaugeNeedle2.Name = "radialGaugeNeedle2";
            this.radialGaugeNeedle2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeNeedle2.Thickness = 5D;
            this.radialGaugeNeedle2.UseCompatibleTextRendering = false;
            this.radialGaugeNeedle2.Value = 0F;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(10, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(301, 52);
            this.label5.TabIndex = 76;
            this.label5.Text = "Total Logs";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total_gauge
            // 
            this.total_gauge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.total_gauge.BackColor = System.Drawing.Color.Transparent;
            this.total_gauge.CausesValidation = false;
            this.total_gauge.Controls.Add(this.lbl_tot_monitored);
            this.total_gauge.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radialGaugeArc5,
            this.radialGaugeArc6,
            this.radialGaugeNeedle3});
            this.total_gauge.Location = new System.Drawing.Point(12, 465);
            this.total_gauge.Name = "total_gauge";
            this.total_gauge.Size = new System.Drawing.Size(301, 277);
            this.total_gauge.StartAngle = 180D;
            this.total_gauge.SweepAngle = 180D;
            this.total_gauge.TabIndex = 75;
            this.total_gauge.Text = "radRadialGauge3";
            this.total_gauge.ThemeName = "Office2010Silver";
            this.total_gauge.Value = 0F;
            // 
            // lbl_tot_monitored
            // 
            this.lbl_tot_monitored.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_tot_monitored.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tot_monitored.ForeColor = System.Drawing.Color.Navy;
            this.lbl_tot_monitored.Location = new System.Drawing.Point(-8, 139);
            this.lbl_tot_monitored.Name = "lbl_tot_monitored";
            this.lbl_tot_monitored.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_tot_monitored.Size = new System.Drawing.Size(301, 138);
            this.lbl_tot_monitored.TabIndex = 77;
            this.lbl_tot_monitored.Text = "--";
            this.lbl_tot_monitored.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("IRANSansWeb", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(933, 439);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(433, 33);
            this.label2.TabIndex = 80;
            this.label2.Text = "سامانه هوشمند هدایت کارشناسان کیفی";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // test_label
            // 
            this.test_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.test_label.AutoSize = false;
            this.test_label.BackColor = System.Drawing.Color.LightCyan;
            this.test_label.BorderVisible = true;
            this.test_label.Font = new System.Drawing.Font("IRANSansWeb", 20F, System.Drawing.FontStyle.Bold);
            this.test_label.Location = new System.Drawing.Point(933, 483);
            this.test_label.Name = "test_label";
            this.test_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.test_label.Size = new System.Drawing.Size(433, 259);
            this.test_label.TabIndex = 82;
            this.test_label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.test_label.ThemeName = "Office2010Silver";
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Controls.Add(this.Header);
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel1.Font = new System.Drawing.Font("IRANSansWeb", 29F, System.Drawing.FontStyle.Bold);
            this.radLabel1.ForeColor = System.Drawing.Color.Red;
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radLabel1.Size = new System.Drawing.Size(1378, 66);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "داشبورد عملکرد کارشناسان مانیتورینگ";
            // 
            // RPT_QC_DASHBOARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 754);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.test_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.total_gauge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.aht_gauge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.amw_gauge);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.KeyPreview = true;
            this.Name = "RPT_QC_DASHBOARD";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "داشبورد مانیتورینگ کیفی";
            this.ThemeName = "Office2010Silver";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QC_GENERAL_REPORT_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QC_GENERAL_REPORT_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amw_gauge)).EndInit();
            this.amw_gauge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aht_gauge)).EndInit();
            this.aht_gauge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.total_gauge)).EndInit();
            this.total_gauge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.test_label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.radLabel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Timer timer1;
        private Telerik.WinControls.UI.Gauges.RadRadialGauge amw_gauge;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc1;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc2;
        private Telerik.WinControls.UI.Gauges.RadialGaugeNeedle radialGaugeNeedle1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.Gauges.RadRadialGauge aht_gauge;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc3;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc4;
        private Telerik.WinControls.UI.Gauges.RadialGaugeNeedle radialGaugeNeedle2;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.Gauges.RadRadialGauge total_gauge;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc5;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc6;
        private Telerik.WinControls.UI.Gauges.RadialGaugeNeedle radialGaugeNeedle3;
        private System.Windows.Forms.Label lbl_tot_amw;
        private System.Windows.Forms.Label lbl_tot_aht;
        private System.Windows.Forms.Label lbl_tot_monitored;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadLabel test_label;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
    }
}
