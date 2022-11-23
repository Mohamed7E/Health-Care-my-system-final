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
        int key = 0;

        private void patientslist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            patNameTP.Text = patientslist.SelectedRows[0].Cells[1].Value.ToString();
           GenCb.SelectedItem = patientslist.SelectedRows[0].Cells[2].Value.ToString();
            DOBTb.Text = patientslist.SelectedRows[0].Cells[3].Value.ToString();
            patphoneTb.Text = patientslist.SelectedRows[0].Cells[4].Value.ToString();
            patAddTb.Text = patientslist.SelectedRows[0].Cells[5].Value.ToString();
            if (patNameTP.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(patientslist.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
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
                string Query = "Update patientTbl set patName ='{0}' , patGen='{1}', patDOb='{2}',patphone='{3}', patadd='{4}'where patCode= {5} " ;
                Query = string.Format(Query, patient, Gender, BDate, phone, Address);
                Con.setData(Query);
                Showpatients();
                Clear();
                MessageBox.Show("patient Updateed!!!");

            }
        }
        private void Clear()
        {
            patNameTP.Text = "";
            GenCb.SelectedIndex = -1;
            patphoneTb.Text = "";
            patAddTb.Text = "";


        }

        private void beletebtn_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("select a patient!!!!!!");
            }
            else
            {
                
                string Query = "Delete from patientTbl where  patCode= {0} ";
                Query = string.Format(Query, key);
                Con.setData(Query);
                Showpatients();
                Clear();
                MessageBox.Show("patient Deleteeed!!!");

            }

        }
    }
}
