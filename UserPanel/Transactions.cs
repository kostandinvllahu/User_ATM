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
            String name = Convert.ToString(Form1.loginUser);
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Username, Deposit from Client_tbl where IdCard='" + Convert.ToString(Form1.loginUser) + "'", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                label3.Text = (rdr["Username"].ToString());
                txtDeposit.Text = (rdr["Deposit"].ToString());
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         //   txtIban = ClientRec
        }
    }
}
