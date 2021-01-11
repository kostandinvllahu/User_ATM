﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserPanel
{
    public partial class Transactions : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Admindtb.mdf;Integrated Security=True;Connect Timeout=30");
        public Transactions()
        {
            InitializeComponent();

        }
        public void populate()
        {
            Con.Open();
            string Myquery = "select * from Client_tbl where IdCard='" + Convert.ToString(Form1.loginUser) + "'";
            SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
            SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            fillClient();
            populate();


            
            
        }



        public void fillClient()
        {
            //txtID.Text = Convert.ToString(Form1.loginUser);
            String name = Convert.ToString(Form1.loginUser);
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Username, Deposit, ID from Client_tbl where IdCard='" + name + "'", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                label3.Text = (rdr["Username"].ToString());
                txtDeposit.Text = (rdr["Deposit"].ToString());
                txtID.Text = (rdr["ID"].ToString());
            }
            Con.Close();
        }

        public void receiver()
        {
            //String name = Convert.ToString(Form1.loginUser);
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Deposit from Client_tbl where IBAN='" + txtIban.Text + "'", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
              //  label3.Text = (rdr["Username"].ToString());
                textBox1.Text = (rdr["Deposit"].ToString());
                //txtID.Text = (rdr["ID"].ToString());
            }
            Con.Close();
        }

        public void clear()
        {
            txtIban.Text = "";
            txtAmount.Text = "";
        }

        public void error()
        {
            if(txtIban.Text == "" || txtAmount.Text == "")
            {
                MessageBox.Show("Please fill both required fields!");
            }
            else
            {
                if (txtIban.Text == "" && txtAmount.Text == "")
                {
                    MessageBox.Show("Please fill both required fields!");
                }
            }
        }

       /* public void update()
        {
          //  String ID = Convert.ToString(Form1.loginUser);
            Con.Open();
            string myquery = "UPDATE Client_tbl set Deposit='" + txtDeposit.Text +"' where IdCard=" + txtID.Text + ";";
            SqlCommand cmd = new SqlCommand(myquery, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Successfully Edited!");
            Con.Close();
            fillClient();
            populate();
        }*/

        public void Update()
        {
            error();
            Con.Open();
            string myquery = "UPDATE Client_tbl set Deposit='" + txtDeposit.Text +"' where Id=" + txtID.Text + ";";
            SqlCommand cmd = new SqlCommand(myquery, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Successfully Edited!");
            Con.Close();
            fillClient();
            populate();
        }

       // public void payment()
       // {
            
      //  }

        public void Deposit()
        {
            // int update = 0;
            int amount = Convert.ToInt32(txtAmount.Text);
            int deposit = Convert.ToInt32(txtDeposit.Text);
            int total = deposit - amount;
            int receiver = Convert.ToInt32(textBox1.Text);
            int totrec = total + receiver;

            if (amount > deposit)
            {
                MessageBox.Show("You dont have enough founds to make this transaction!");
                txtDeposit.Text = "";
            }
            else
            {
                if( amount <= deposit)
                {
                    //txtDeposit.Text = "";
                    txtDeposit.Text = total.ToString();
                    Con.Open();
                    string myquery = "UPDATE Client_tbl set Deposit='" + totrec + "' where IBAN=" + txtIban.Text + ";";
                    SqlCommand cmd = new SqlCommand(myquery, Con);
                    cmd.ExecuteNonQuery(); //WRONG COLOUMN NAME ERROR WITH IBAN
                    MessageBox.Show("Transaction finished successfully!");
                    Con.Close();
                    fillClient();
                    populate();
                    clear();
                    //MessageBox.Show("Transaction was made with success!");
                   // Update();
                  //  clear();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         //   txtIban = ClientRec
        }

        private void txtBankCurrency_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if(txtIban.Text == "" || txtAmount.Text == "")
            {
                MessageBox.Show("Please fill both required fields!");
            }
            else
            {
                if (txtIban.Text == "" && txtAmount.Text == "")
                {
                    MessageBox.Show("Please fill both required fields!");
                }
                else
                {
                    receiver();
                    Deposit();
                }
            }
          //  Deposit();
        }

        private void txtDeposit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
