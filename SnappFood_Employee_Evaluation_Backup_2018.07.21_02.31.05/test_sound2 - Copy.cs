using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using System.Linq;
using System.Data.OleDb;
using System.Media;

namespace SnappFood_Employee_Evaluation
{
    public partial class test_sound : Telerik.WinControls.UI.RadForm
    {
        public string constr;
        public test_sound()
        {
            InitializeComponent();
        }

        private void test_sound_Load(object sender, EventArgs e)
        {
            oleDbConnection1.ConnectionString = constr;
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Sound |*.wav";
            if (op.ShowDialog() == DialogResult.OK)
            {
                //Per_Pic.ImageLocation = op.FileName;
                label1.Text = op.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] imageData = ReadFile(label1.Text);
            ////////////////////////////////////////////// INSERT INTO PER_DOCUMENTS TBL
            oleDbCommand1.Parameters.Clear();
            oleDbCommand1.CommandText = "INSERT INTO [locations].[dbo].[wav] ([sound]) " +
                                        "values (?)";
            oleDbCommand1.Parameters.AddWithValue("@Per_Pic", (object)imageData);

            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer myPlayer = new SoundPlayer();
            if (button2.Text == "Play")
            {
                button2.Text = "Stop";
                DataTable dt1 = new DataTable();
                OleDbDataAdapter adp1 = new OleDbDataAdapter();
                adp1.SelectCommand = new OleDbCommand();
                adp1.SelectCommand.Connection = oleDbConnection1;
                oleDbCommand1.Parameters.Clear();
                string lcommand1 = "SELECT [sound] from [locations].[dbo].[wav] where [id] = '" + textBox1.Text + "'";
                adp1.SelectCommand.CommandText = lcommand1;
                adp1.Fill(dt1);
                if (dt1.Rows[0][0].ToString().Length != 0)
                {
                    byte[] imageData = (byte[])dt1.Rows[0][0];
                    //Image newImage;
                    using (MemoryStream ms2 = new MemoryStream(imageData, 0, imageData.Length))
                    {
                        ms2.Write(imageData, 0, imageData.Length);
                        //newImage = Image.FromStream(ms, true);
                        myPlayer.Stream = ms2;
                        myPlayer.Stream.Position = 0;
                        myPlayer.Play();
                        label1.Text = myPlayer.Stream.Length.ToString();
                    }
                }
            }
            else
            {
                button2.Text = "Play";
                myPlayer.Stop();
            }
        }
    }
}
