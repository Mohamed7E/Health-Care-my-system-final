using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Health
{
    public partial class Disgnosis : Form
    {
        function Con;
        public Disgnosis()
        {
            InitializeComponent();
            Con = new function();
            Getpatients();
            GetTest();
            ShowDisgnosis();
        }
        private void GetCost()
        {
            string Query = "Select * from TestTbl Where TestCode ={0}";
            Query = string.Format(Query, testCb.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                CostTb.Text = dr["TestCost"].ToString();
            }
        }
        private void ShowDisgnosis()
        {
            string Query = "Select * from DisgnosisTbl";
            Disgnosislist.DataSource = Con.GetData(Query);

        }
        private void Getpatients()
        {
            string Query = "Select * from patientTbl";
            patientsCb.DisplayMember = Con.GetData(Query).Columns["patName"].ToString();
            patientsCb.ValueMember = Con.GetData(Query).Columns["patcode"].ToString();
            patientsCb.DataSource = Con.GetData(Query);
        }
        private void GetTest()
        {
            string Query = "Select * from TestTbl";
            testCb.DisplayMember = Con.GetData(Query).Columns["testName"].ToString();
            testCb.ValueMember = Con.GetData(Query).Columns["patcode"].ToString();
            testCb.DataSource = Con.GetData(Query);
        }
        private void Clesr()
        {
            CostTb.Text = "";
            ResltTb.Text = "";
            testCb.SelectedIndex = -1;
            patientsCb.SelectedIndex = -1;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (patientsCb.SelectedIndex == -1 || CostTb.Text == "" || ResltTb.Text == "" )
            {
                MessageBox.Show("Missing Data!!!!!!");
            }
            else
            {
                string DDate = DigDataIb.Value.Date.ToString();
                int patient= Convert.ToInt32( patientsCb.SelectedValue.ToString());
                int test= Convert.ToInt32( testCb.SelectedValue.ToString());
                int cost= Convert.ToInt32( CostTb.Text);
                string Reslt = ResltTb.Text;
                
                string Query = "inster into DisgnosisTbl values('{0}',{1},{2},{3},'{4}')";
                Query = string.Format(Query, patient, DDate, patient, test, cost,Reslt);
                Con.setData(Query);
                ShowDisgnosis();
                Clesr();
                MessageBox.Show("Disgnosis added!!!");

            }

        }

        private void testCb_SelectedValueChanged(object sender, EventArgs e)
        {
            GetCost();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int Key = 0;

      

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key==0)
            {
                MessageBox.Show("Missing Data!!!!!!");
            }
            else
            {
                

                string Query = "Delete from DisgnosisTbl where Digcode={0}";
                Query = string.Format(Query, Key);
                Con.setData(Query);
                ShowDisgnosis();
                Clesr();
                MessageBox.Show("Disgnosis Deleteeeeee!!!");

            }
        }

        private void EsitBtn_Click(object sender, EventArgs e)
        {
            if (patientsCb.SelectedIndex == -1 || CostTb.Text == "" || ResltTb.Text =="")
            {
                MessageBox.Show("Missing Data!!!!!!");
            }
            else
            {
                string DDate = DigDataIb.Value.Date.ToString();
                int patient = Convert.ToInt32(patientsCb.SelectedValue.ToString());
                int test = Convert.ToInt32(testCb.SelectedValue.ToString());
                int cost = Convert.ToInt32(CostTb.Text);
                string Reslt = ResltTb.Text;

                string Query = "update DisgnosisTbl set DigData={0},patient= {1}, test={2},Cost= {3},Reslt='{4}' where Didcode={5} ";
                Query = string.Format(Query, patient, DDate, patient, test, cost, Reslt);
                Con.setData(Query);
                ShowDisgnosis();
                Clesr();
                MessageBox.Show("Disgnosis Updateeeee!!!");

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            patients Obj = new patients();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Tests Obj = new Tests();
            Obj.Show();
            this.Hide();
        }

        private void Disgnosislist_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            DigDataIb.Text = Disgnosislist.SelectedRows[0].Cells[1].Value.ToString();
            patientsCb.SelectedItem = Disgnosislist.SelectedRows[0].Cells[2].Value.ToString();
            testCb.SelectedItem = Disgnosislist.SelectedRows[0].Cells[3].Value.ToString();
            CostTb.Text = Disgnosislist.SelectedRows[0].Cells[4].Value.ToString();
            ResltTb.Text = Disgnosislist.SelectedRows[0].Cells[5].Value.ToString();
            if (CostTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(Disgnosislist.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
