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
    public partial class Testing : Form
    {
       
        String url = Convert.ToString(Access.loginUser);
        SqlConnection Con = new SqlConnection(Access.loginUser);
        
        public Testing()
        {
            InitializeComponent();
           // populate();
            test();
        }



        public void populate()
        {
             String name = comboBox1.SelectedValue.ToString();
             Con.Open();
             string Myquery = "SELECT * from " + name;
             SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
             SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
             var ds = new DataSet();
             da.Fill(ds);
             dataGridView1.DataSource = ds.Tables[0];
             Con.Close();
           
        }

        public void test()
        {

            Con.Open();
            SqlCommand cmd = new SqlCommand("Select table_name from information_schema.tables", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TABLE_NAME", typeof(string));
            dt.Load(rdr);
            comboBox1.ValueMember = "TABLE_NAME";
            comboBox1.DataSource = dt;
            Con.Close();

            /*Con.Open();

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = Con;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select table_name from information_schema.tables";

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            comboBox1.DataSource = dtRecord;
            comboBox1.ValueMember = "TABLE_NAME";
            Con.Close();*/

        }

        private void Testing_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
