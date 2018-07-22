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
    public partial class Form7 : Form
    {
        Form11 o = new Form11();
        public Form7()
        {
            InitializeComponent();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {////////////////////////////////////// 

                //gridview to search medicine

                o.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select *from Invoice where PID='" + comboBox2.Text + "'", o.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                o.oleDbConnection1.Close();
                o.oleDbConnection1.Close();
            }
            catch { MessageBox.Show("Go Back And Come Again"); }

            ///////////////////////////////////
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            //admin
            Form10 f11 = new Form10();
            f11.Show();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {  
            
            
            //add invoice
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select PID from Patient ", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["PID"]).ToString();

            }
            o.oleDbConnection1.Close();







            //Search invoice
            o.oleDbConnection1.Open();
            OleDbCommand cmdd = new OleDbCommand("select PID from Invoice ", o.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();
            while (drr.Read())
            {
                comboBox2.Items.Add(drr["PID"]).ToString();

            }
            o.oleDbConnection1.Close();



        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            
            //Search invoice
            o.oleDbConnection1.Open();
            OleDbCommand cd = new OleDbCommand("Select *from Patient where PID = '" + comboBox3.Text + "'", o.oleDbConnection1);
            OleDbDataReader dnr = cd.ExecuteReader();

            if (dnr.Read())
            {
                textBox15.Text = dnr["Name"].ToString();
                textBox13.Text = dnr["MobileNum"].ToString();

            }
            o.oleDbConnection1.Close();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //add invoice

                o.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Insert into Invoice(PID,PName,MobileNum,UltraSound,Drip,Lab,Others,Total) values (@PID,@PName,@MobileNum,@UltraSound,@Drip,@Lab,@Others,@Total)", o.oleDbConnection1);
                cmd.Parameters.AddWithValue("@PID", comboBox3.Text);
                cmd.Parameters.AddWithValue("@PName", textBox15.Text);
                cmd.Parameters.AddWithValue("@MobileNum", textBox13.Text);
                cmd.Parameters.AddWithValue("@UltraSound", textBox1.Text);
                cmd.Parameters.AddWithValue("@Drip", textBox2.Text);
                cmd.Parameters.AddWithValue("@Lab", textBox3.Text);
                cmd.Parameters.AddWithValue("@Others", textBox4.Text);
                cmd.Parameters.AddWithValue("@Total", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Invoice Generated");
                o.oleDbConnection1.Close();
            }
            catch { MessageBox.Show("Please Enter All Fields Correctly"); }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           


           

         
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int p = Convert.ToInt32(textBox1.Text);
                int r = Convert.ToInt32(textBox2.Text);
                int i = Convert.ToInt32(textBox3.Text);
                int f = Convert.ToInt32(textBox4.Text);

                int t = p + r + i + f;
                textBox5.Text = t.ToString();
            }
            catch { MessageBox.Show("Please Enter Numbers Only"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
