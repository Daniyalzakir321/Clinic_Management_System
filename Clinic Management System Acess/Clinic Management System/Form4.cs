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
    public partial class Form4 : Form
    {
        Form11 o = new Form11();
        public Form4()
        {
            InitializeComponent();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //admin
            Form10 f11 = new Form10();
            f11.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //admin
            Form10 f1 = new Form10();
            f1.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //search MEdicine
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select MID from Medicine ", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["MID"]).ToString();

            }
            o.oleDbConnection1.Close();



            ///////////





            int MID = 0;

            o.oleDbConnection1.Open();
            OleDbCommand cmd2 = new OleDbCommand("select count(MID) from medicine", o.oleDbConnection1);
            OleDbDataReader dr11 = cmd2.ExecuteReader();
            while (dr11.Read())
            {
                MID = Convert.ToInt32(dr11[0]);
                MID++;
            }
            o.oleDbConnection1.Close();
            this.textBox1.Text = "" + MID;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        

            //gridview to search medicine

            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Medicine", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            o.oleDbConnection1.Close();

            ///////////////////////////////////
            /*
                        
            //Dtat type mismatch if i use this query
             * 
                        o.oleDbConnection1.Open();
                        OleDbCommand cmd = new OleDbCommand("Select *from Medicine where MID='" + comboBox2.Text + "'", o.oleDbConnection1);
                        OleDbDataReader dlr = cmd.ExecuteReader();
                        DataTable dtt = new DataTable();
                        dtt.Load(dlr);
                        dataGridView1.DataSource = dtt;
                        o.oleDbConnection1.Close();
        
                        */

        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                o.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Insert into Medicine(MID,MedicinesName) values (@MID,@MedicinesName)", o.oleDbConnection1);
                cmd.Parameters.AddWithValue("@MID", textBox1.Text);
                cmd.Parameters.AddWithValue("@MedicinesName", textBox6.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine Added");
                o.oleDbConnection1.Close();
            }
            catch { MessageBox.Show("Please Enter Medicine"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox6.Clear();
           

        }
    }
}
