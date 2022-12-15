using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserName.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Dateee!!!");
            }
            else if(UserName.Text == "Mohamed" || PasswordTb.Text == "Ebrahim")
            {
                patients Obj = new patients();
                Obj.Show();
                this.Hide();
            }
            else
            {
                UserName.Text = "";
                PasswordTb.Text = "";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
