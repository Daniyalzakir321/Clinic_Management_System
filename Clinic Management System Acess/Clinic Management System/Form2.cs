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
    public partial class Form2 : Form
    {
        Form11 o = new Form11();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            { this.textBox10.Text = "Male"; }
            else if (radioButton2.Checked == true)
            { this.textBox10.Text = "Female"; }






            this.Username.Enabled = false;

            string[] a = { "Male","Female" };
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(a);



            //Doctor ID in admit patient
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select DoctorID from Doctor ", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox5.Items.Add(dr["DoctorID"]).ToString();

            }
            o.oleDbConnection1.Close();







            //Auto generate patient id 

            int PID = 0;

            o.oleDbConnection1.Open();
            OleDbCommand cmd2 = new OleDbCommand("select count(PID) from patient", o.oleDbConnection1);
            OleDbDataReader dr11 = cmd2.ExecuteReader();
            while (dr11.Read())
            {
                PID = Convert.ToInt32(dr11[0]);
                PID++;
            }
            o.oleDbConnection1.Close();
            this.Username.Text = "" + PID;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //Search patient
            Form3 f4 = new Form3();
            f4.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Patient
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //admin
            Form10 f11 = new Form10();
            f11.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                //Add Patient Not Admit
                o.oleDbConnection1.Open();
                OleDbCommand cmd1 = new OleDbCommand("Insert into Patient(PID,Name,Age,Gender,CNIC,FatherName,MobileNum,MotherName,Address,CheckupFees,AdmitDate,Disease,DoctorID,DoctorName,WardType,WardNum,RoomNum,BedNum) values (@PID,@Name,@Age,@Gender,@CNIC,@FatherName,@MobileNum,@MotherName,@Address,@CheckupFees,@AdmitDate,@Disease,@DoctorID,@DoctorName,@WardType,@WardNum,@RoomNum,@BedNum)", o.oleDbConnection1);
                cmd1.Parameters.AddWithValue("@PID", Username.Text);
                cmd1.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd1.Parameters.AddWithValue("@Age", textBox2.Text);
                cmd1.Parameters.AddWithValue("@Gender", textBox10.Text);
            

                cmd1.Parameters.AddWithValue("@CNIC", textBox4.Text);
                cmd1.Parameters.AddWithValue("@FatherName", textBox5.Text);
                cmd1.Parameters.AddWithValue("@MobileNum", textBox6.Text);
                cmd1.Parameters.AddWithValue("@MotherName", textBox7.Text);
                cmd1.Parameters.AddWithValue("@Address", textBox8.Text);
                cmd1.Parameters.AddWithValue("@CheckupFees", textBox9.Text);

                cmd1.Parameters.AddWithValue("@AdmitDate", dateTimePicker1);
                cmd1.Parameters.AddWithValue("@Disease", textBox11.Text);
                cmd1.Parameters.AddWithValue("@DoctorID", comboBox5.Text);
                cmd1.Parameters.AddWithValue("@DoctorName", textBox3.Text);
                cmd1.Parameters.AddWithValue("@WardType", comboBox1.Text);
                cmd1.Parameters.AddWithValue("@WardNum", comboBox2.Text);
                cmd1.Parameters.AddWithValue("@RoomNum", comboBox3.Text);
                cmd1.Parameters.AddWithValue("@BedNum", comboBox4.Text);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Patient Added");

                o.oleDbConnection1.Close();
                o.oleDbConnection1.Close();
            }

            catch { MessageBox.Show("Please Enter All Fields Correctly"); }

           
          



        }
    
        private void button1_Click(object sender, EventArgs e)
        {
          
                   
            
            
           
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
            this.textBox7.Clear();
            this.textBox8.Clear();
            this.textBox9.Clear();
            this.textBox11.Clear();
            this.dateTimePicker1.Text = "";
            this.textBox1.Clear();
            this.textBox3.Clear();
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";
            this.comboBox3.Text = "";
            this.comboBox4.Text = "";
            this.comboBox5.Text = "";


            

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Doctor ID in admit patient
            o.oleDbConnection1.Open();
            OleDbCommand cmddd = new OleDbCommand("Select *from Doctor where DoctorID = '" + comboBox5.Text + "'", o.oleDbConnection1);
            OleDbDataReader dnrnn = cmddd.ExecuteReader();

            if (dnrnn.Read())
            {
              this.textBox3.Text = dnrnn["DoctorName"].ToString();

            }
            o.oleDbConnection1.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ward num to room num  cb 2 to 3
            string[] M = { "1" };
           
            string[] F = { "2" };

            if (comboBox1.Text == "Male")
            {
                this.comboBox3.Items.AddRange(M);
                
            }
            else if (comboBox1.Text == "Female")
            {
                this.comboBox3.Items.AddRange(F);
          
            }
       
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {     //Ward type to Ward num cb 1 to 2
            string[] M = { "2", "3", "4" };
            string[] F = { "1", "5" };

            if (comboBox1.Text == "Male")
            {
                this.comboBox2.Items.AddRange(M);

            }
            else if (comboBox1.Text == "Female")
            {
                this.comboBox2.Items.AddRange(F);

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //room num to bed num  cb 3 to 4
            string[] M = { "4", "5", "6", "7", "8", "9", "10" };
            string[] F = { "1","2","3", "4", "5", "6", "7", "8", "9", "10" };

            if (comboBox1.Text == "Male")
            {
                this.comboBox4.Items.AddRange(M);
               // comboBox4.Items.Clear();
            }
            else if (comboBox1.Text == "Female")
            {
                this.comboBox4.Items.AddRange(F);
               // comboBox4.Items.Clear();
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            { this.textBox10.Text = "Male"; }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            { this.textBox10.Text = "Female"; }
        }
    }
}
