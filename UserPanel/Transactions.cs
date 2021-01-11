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
    public partial class Transactions : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Admindtb.mdf;Integrated Security=True;Connect Timeout=30");
        public Transactions()
        {
            InitializeComponent();
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            fillClient();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }
    }
}
