using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinic_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Username.Text == "" || textBox2.Text == "")
            {
                this.button1.Enabled = true;
                this.button2.Enabled = true;
                this.button3.Enabled = true;
                this.button4.Enabled = true;
                this.button5.Enabled = true;
                this.button6.Enabled = true;
                this.button8.Enabled = true;
                this.button10.Enabled = true;
            }
            else
            { MessageBox.Show("Invalid Password"); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
    
            //Admin
            Form10 f10 = new Form10();
            f10.Show();
            this.Hide();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button4.Enabled = false;
            this.button5.Enabled = false;
            this.button6.Enabled = false;
            this.button8.Enabled = false;
            this.button10.Enabled = false;
            this.button11.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Patient
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //medicine
            Form4 f11 = new Form4();
            f11.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //staff
            Form5 f11 = new Form5();
            f11.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //invoice
            Form7 f11 = new Form7();
            f11.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //appoint
            Form8 f11 = new Form8();
            f11.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //report
            Form9 f11 = new Form9();
            f11.Show();
            this.Hide();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
         
        }
    }
}
