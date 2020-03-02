using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.Charting;

namespace SnappFood_Employee_Evaluation.After_Sales
{
    public partial class Test : Telerik.WinControls.UI.RadForm
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            var table = new DataTable();
            table.Columns.Add("Value", typeof(double));
            table.Columns.Add("Name", typeof(string));
            table.Rows.Add(1, "John");
            table.Rows.Add(3, "Adam");
            table.Rows.Add(5, "Peter");
            table.Rows.Add(12, "Sam");
            table.Rows.Add(6, "Paul");
            LineSeries lineSeria = new LineSeries();
            radChartView1.Series.Add(lineSeria);
            lineSeria.ValueMember = "Value";
            lineSeria.CategoryMember = "Name";
            lineSeria.DataSource = table;
        }
    }
}
