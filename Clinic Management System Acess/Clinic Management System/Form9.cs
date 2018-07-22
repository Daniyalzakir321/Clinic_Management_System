using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Clinic_Management_System
{
    public partial class Form9 : Form
    {
        Form11 o = new Form11();

        public Form9()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            //admin
            Form10 f11 = new Form10();
            f11.Show();
            this.Hide();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

            //show report
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select PID from Patient ", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["PID"]).ToString();

            }
            o.oleDbConnection1.Close();
        }





        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gridview to search report

            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from patient where PID='"+comboBox2.Text+"'", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
           o.oleDbConnection1.Close();

          




        }

        private void button2_Click(object sender, EventArgs e)
        {

           
        }
    }
}
