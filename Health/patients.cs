using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Health
{
    public partial class patients : Form
    {
        function Con;
        public patients()
        {
            InitializeComponent();
            Con = new function();
            Showpatients();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void Showpatients()
        {
            string Query = "select *form patientTb";
            patientslist.DataSource = Con..GetData(Query);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (patNameTP.Text == "" || patphoneTb.Text = "" || patAddTb.Text = "" || GenCb.SelectedIndex = "")
            {
                MessageBox.Show("Missing Data!!!!!!");
            }
            else
            {
                string patient = patNameTP.Text;
                string Gender = GenCb.SelectedItem.ToString();
                string BDate = DOBTb.Value.Date.ToString();
                string phone = patphoneTb.Text;
                string Address = patAddTb.Text;
                string Query = "inster into patientTbl values('{0}','{1}','{2}','{3}','{4}')";
                Query = string.Format(Query, patient, Gender, BDate, phone, Address);
                Con.setData(Query);
                Showpatients();
                MessageBox.Show("patient added!!!");

            }

        }
    }
}
