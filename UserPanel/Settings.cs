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
    public partial class Settings : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Admindtb.mdf;Integrated Security=True;Connect Timeout=30");
        public Settings()
        {
            InitializeComponent();
            fillClient();
            Data();
        }
        //CREATE THE SAVING OPTION SO DATA CAN BE UPDATED IN BASE OF THE ID

        private void Settings_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update();
        }

        public void Data()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Phone, Password, ID from Client_tbl where IdCard='" + Convert.ToString(Form1.loginUser) + "'", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                textBox1.Text = (rdr["Phone"].ToString());
                textBox2.Text = (rdr["Password"].ToString());
                textBox3.Text = (rdr["ID"].ToString());
            }
            Con.Close();
        }

        public void Update()
        {
            Con.Open();
            string myquery = "UPDATE Client_tbl set Phone='" + textBox1.Text + "',Password='" + textBox2.Text + "' where Id=" + textBox3.Text + ";";
            SqlCommand cmd = new SqlCommand(myquery, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Successfully Edited!");
            Con.Close();
            Data();
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;

        }

        public void fillClient()
        {
            String name = Convert.ToString(Form1.loginUser);
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Username from Client_tbl where IdCard='" + Convert.ToString(Form1.loginUser) + "'", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                label3.Text = (rdr["Username"].ToString());
            }
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
