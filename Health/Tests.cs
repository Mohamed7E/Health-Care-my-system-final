using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Health
{
    public partial class Tests : Form
    {
        function Con;
        public Tests()
        {
            InitializeComponent();
            Con = new function();
            ShowTest();
        }
        public void ShowTest()
        {
            string Query = "select *form TestTb";
            Testlist.DataSource = Con.GetData(Query);
        }
      private void Clear()
        {
            TNameTb.Text = "";
            TCostTb.Text = "";
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (TNameTb.Text == "" || TCostTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!!!!");
            }
            else
            {
                string TName = TNameTb.Text;
                int Cost = Convert.ToInt32(TCostTb.Text);

                string Query = "inster into TestTbl values('{0}','{1}')";
                Query = string.Format(Query, TName, Cost);
                Con.setData(Query);
                ShowTest();
                Clear();
                MessageBox.Show("Test added!!!");

            }

        }
        int key = 0;
       

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if ( TNameTb.Text == "" || TCostTb.Text =="")
            {
                MessageBox.Show("Missing Data!!!!!!");
            }
            else
            {
                string TName = TNameTb.Text;
                int Cost = Convert.ToInt32(TCostTb.Text);

                string Query = "UPDate TestTbl set TestName='{0}', TestCost={1} where TestCode={2}";
                Query = string.Format(Query, TName, Cost ,key );
                Con.setData(Query);
                ShowTest();
                Clear();
                MessageBox.Show("Test UpDateee!!!");

            }
        }

        private void DeleteBTn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("select aTest!!!!!!");
            }
            else
            {
                string TName = TNameTb.Text;
                int Cost = Convert.ToInt32(TCostTb.Text);

                string Query = "Delete from TestTbl  where TestCode={}";
                Query = string.Format(Query, key);
                Con.setData(Query);
                ShowTest();
                Clear();
                MessageBox.Show("Test Deleteeee!!!");
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Disgnosis Obj = new Disgnosis();
            Obj.Show();
            this.Hide();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TNameTb.Text = Testlist.SelectedRows[0].Cells[1].Value.ToString();

            TCostTb.Text = Testlist.SelectedRows[0].Cells[2].Value.ToString();

            if (TNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Testlist.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    };
}
