using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp5
{
     
    public partial class Form6 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        private string customerBalance;
        public Form6()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.OF3;

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd;
            string query = "select balance from logintable where id=(select id from loggedinuserinfo);";



            cmd = new SqlCommand(query, con);


            con.Open();


            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows == true)
            {

                this.customerBalance = dr.GetValue(0).ToString();

            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection(cs);

            string query2 = "update loggedinuserinfo set username='',phonenumber='', location='', age='', pass='',id='',  Picture='';";

            SqlCommand cmd2 = new SqlCommand(query2, con2);



            // cmd2.Parameters.AddWithValue("@Image", ImagemByte);



            con2.Open();
            int x=cmd2.ExecuteNonQuery();
            con2.Close();

           
            

            Form1 f = new Form1(); f.Show(); this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(this.customerBalance) <= 0)
            { DialogResult d = MessageBox.Show("Your Balance is 0", "Can't afford laborers", MessageBoxButtons.OK, MessageBoxIcon.Information); }



            else
            {
                LaborerRecruit f = new LaborerRecruit();
                f.Show();
                this.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd;


            string query;


            query = "select laborername 'Name', id 'I.D.' , job 'Job' from laborertable where potentialcustomerid=(select id from loggedinuserinfo) and hirerid='Pending';";

            cmd = new SqlCommand(query, con);
            con.Open();

             


            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
             

            if (dr.HasRows == false)
            { DialogResult d = MessageBox.Show("Manager is yet to set conditions", "Not Now", MessageBoxButtons.OK, MessageBoxIcon.Information); con.Close(); }







            else
            {
                con.Close();
                CustomerConfirmingHiring f = new CustomerConfirmingHiring();

                f.Show();

                this.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerManagingLaborers f = new CustomerManagingLaborers();
            f.Show();

            this.Visible = false;
        }
    }
}
