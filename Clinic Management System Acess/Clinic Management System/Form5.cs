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
    public partial class Form5 : Form
    {
        Form11 o = new Form11();
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox57_TextChanged(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            //admin
            Form10 f11 = new Form10();
            f11.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //staff search
            Form6 f11 = new Form6();
            f11.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            { this.textBox9.Text = "Male"; }
            else  if (radioButton2.Checked == true)
        { this.textBox9.Text = "Female"; }





            int SID = 0;

            o.oleDbConnection1.Open();
            OleDbCommand cmd2 = new OleDbCommand("select count(SID) from Staff", o.oleDbConnection1);
            OleDbDataReader dr11 = cmd2.ExecuteReader();
            while (dr11.Read())
            {
                SID = Convert.ToInt32(dr11[0]);
                SID++;
            }
            o.oleDbConnection1.Close();
            this.textBox1.Text = "" + SID;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                o.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Insert into Staff(SID,SName,StaffType,Gender,DOB,Address,City,MobileNum,EmailID,Experience ) values (@SID,@SName,@StaffType,@Gender,@DOB,@Address,@City,@MobileNum,@EmailID,@Experience)", o.oleDbConnection1);
                cmd.Parameters.AddWithValue("@SID", textBox1.Text);
                cmd.Parameters.AddWithValue("@SName", textBox2.Text);
                cmd.Parameters.AddWithValue("@StaffType", textBox3.Text);

                cmd.Parameters.AddWithValue("@Gender", textBox9.Text);
           

                cmd.Parameters.AddWithValue("@DOB", dateTimePicker1);

                cmd.Parameters.AddWithValue("@Address", textBox4.Text);
                cmd.Parameters.AddWithValue("@City", textBox5.Text);
                cmd.Parameters.AddWithValue("@MobileNum", textBox6.Text);
                cmd.Parameters.AddWithValue("@EmailID", textBox7.Text);
                cmd.Parameters.AddWithValue("@Experience", textBox8.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff Added");
                o.oleDbConnection1.Close();
            }
            catch { MessageBox.Show("Please Enter All Fields Correctly"); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
              this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
            this.textBox7.Clear();
            this.textBox8.Clear();
         
            this.dateTimePicker1.Text = "";
           
            this.textBox3.Clear();
           

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            { this.textBox9.Text = "Male"; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            { this.textBox9.Text = "Female"; }
        }
    }
}
