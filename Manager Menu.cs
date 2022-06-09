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
     
    public partial class Form7 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form7()
        {
            InitializeComponent();
            panel1.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.OF1;

            this.numericUpDown1.Maximum = 50000;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection(cs);

            string query2 = "update loggedinuserinfo set username='',phonenumber='', location='', age='', pass='',id='',  Picture='';";

            SqlCommand cmd2 = new SqlCommand(query2, con2);



            // cmd2.Parameters.AddWithValue("@Image", ImagemByte);



            con2.Open();
            int x = cmd2.ExecuteNonQuery();
            con2.Close();




            Form1 f = new Form1(); f.Show(); this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {


              
                LaborerRegistration f = new LaborerRegistration();

                f.Show();
                this.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd;


            string query;



            query = "select laborername LABORER,id 'ID[Laborer]',(select username from logintable where id= potentialcustomerid) 'Applicant',potentialcustomerid 'ID[Applicant]', picture 'Picture[Laborer]' from laborertable IMAGE where      (potentialcustomerid!=null or potentialcustomerid!='') and  hirerid!='Pending';";

            cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();


            if (dr.HasRows == false)
            { DialogResult d = MessageBox.Show("Customers are yet to apply for Laborers", "Not Now", MessageBoxButtons.OK, MessageBoxIcon.Information); con.Close(); }







            else
            {
                con.Close(); ManagerConfirmingHiring f = new ManagerConfirmingHiring();

                f.Show(); this.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Text != "")
            {

                SqlConnection conMM = new SqlConnection(cs);

                string queryMM = "update logintable set balance= cast(cast(balance as int)-@Salary as varchar(50)) from logintable where UserType='Manager';";

                SqlCommand cmdMM = new SqlCommand(queryMM, conMM);



                cmdMM.Parameters.AddWithValue("@Salary", numericUpDown1.Text);



                conMM.Open();
                int xMM = cmdMM.ExecuteNonQuery();
                conMM.Close();


                DialogResult dQ = MessageBox.Show("Withdrew Salary Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.ShowBalance();


            }


            else { DialogResult d = MessageBox.Show("Enter a Value First", "Not Now", MessageBoxButtons.OK, MessageBoxIcon.Information);   }

        }

        private void button3_Click(object sender, EventArgs e)
        {


            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            panel1.Visible = true;

            this.ShowBalance();

            label1.Text = "Salary Withdrawal";
        }


        private void ShowBalance()
        {
            SqlConnection conHHH = new SqlConnection(cs);

            string qryHHH = "select balance from logintable where usertype='Manager' and id=(select id from loggedinuserinfo);";

            SqlCommand scmdHHH = new SqlCommand(qryHHH, conHHH);





            conHHH.Open();

            int xHHH = scmdHHH.ExecuteNonQuery();

            SqlDataReader sdrHHH = scmdHHH.ExecuteReader();

            sdrHHH.Read();


            if (sdrHHH.HasRows == true)
            {

                label3.Text = sdrHHH.GetString(0);





            }

            sdrHHH.Close();
            conHHH.Close();

        }





        private void button6_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            panel1.Visible = false;

            label1.Text = "Manager Menu";
        }
    }
}
