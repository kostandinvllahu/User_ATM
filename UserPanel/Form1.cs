using System;
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
    public partial class Form1 : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Admindtb.mdf;Integrated Security=True;Connect Timeout=30");

        public static string loginUser = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Close();
            this.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from Client_tbl where IdCard='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                loginUser = txtUsername.Text;
                Main m = new Main();
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username Or Password");
            }
            Con.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    }
