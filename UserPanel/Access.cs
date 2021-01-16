using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserPanel
{
    public partial class Access : Form
    {

        public static string loginUser = null;
        public Access()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Please input the database network url!");
            }
            else
            {
                if(textBox1.Text != null)
                {
                    loginUser = textBox1.Text;
                    Testing t = new Testing();
                   t.Show();
                    this.Hide();
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
