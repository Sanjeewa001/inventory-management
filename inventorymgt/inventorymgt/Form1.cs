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

namespace inventorymgt
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\Desktop\New folder\inv\inventorymgt\inventorymgt\Database1.mdf;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text; 
            cmd.CommandText = "select * from registration where username='"+textBox1.Text+"' and password='"+textBox2.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt=new DataTable();
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            da.Fill(dt);   
            i=Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("password username doesnt match");
            }
            else
            {
                this.Hide();
                MDIParent1 mdi = new MDIParent1();
                mdi.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open) 
            {
                con.Close();    
            }
            con.Open();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
