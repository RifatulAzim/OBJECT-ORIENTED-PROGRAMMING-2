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
using System.IO;

namespace WindowsFormsApp5
{
    
    public partial class CustomerManagingLaborers : Form
    {
        string id;
        string laborerID;
        string customerBalance;
        string laborerWage;
        string laborerBalance;
        string laborerRating;


        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public CustomerManagingLaborers()
        {
            this.WindowState = FormWindowState.Maximized;


             

             

             
            InitializeComponent();

            /*comboBox1.Text = "All";
            comboBox1.Items.Add("Security Guard");
            comboBox1.Items.Add("Houseworker");
            comboBox1.Items.Add("Welder");
            comboBox1.Items.Add("Mason");
            comboBox1.Items.Add("Factory Worker");
            comboBox1.Items.Add("Janitor");
            comboBox1.Items.Add("Porter");
            comboBox1.Items.Add("Mechanic");
            comboBox1.Items.Add("Electrician");
            comboBox1.Items.Add("Plumber");
            comboBox1.Items.Add("All");

            comboBox2.Text = "None";
            comboBox2.Items.Add("Rating");
            comboBox2.Items.Add("Age");
            comboBox2.Items.Add("Experience");
            comboBox2.Items.Add("None");

            button1.Visible = false; */

            this.numericUpDown1.Maximum = 5;
            this.numericUpDown1.Minimum= 0;

            this.panel3.Visible = false;
            this.panel3.BackgroundImage = Properties.Resources.ImperialPattern;



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
                label8.Text = dr.GetString(0);
            }

            con.Close();


            BindGridView();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private byte[] SavePhoto()
        {

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms,pictureBox1.Image.RawFormat);

            return ms.GetBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = true;

            this.panel2.Visible = false;

            this.dataGridView1.Visible = false;

            this.label5.Visible = false;
            this.label4.Visible = false;
            this.comboBox1.Visible = false;
            this.button3.Visible = false;
             
            this.label2.Text = "         Dismissal";



            DialogResult d = MessageBox.Show("Confirm Application", "?", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
                 
                BindGridView();


             
        }

        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6(); f.Show(); this.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            
            }

             
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd;
           

            string query;

           /* if (comboBox1.Text != "All" && comboBox2.Text != "None")
            {
                if (comboBox2.Text == "Experience") { query = "select laborername,id, age,rating, job,hiredtimes, picture from laborertable where job= '" + comboBox1.Text + "' and (hirerid=null or hirerid='') and  (potentialcustomerid=null or potentialcustomerid='') order by hiredtimes desc;"; }
                else { query = "select laborername, id, age,rating, job,hiredtimes, picture from laborertable where job= '" + comboBox1.Text + "' and (hirerid=null or hirerid='') or  (potentialcustomerid=null and potentialcustomerid='')  order by " + comboBox2.Text + " desc;"; }

                 cmd = new SqlCommand(query, con);

                


               


            }

            else if (comboBox1.Text != "All" && comboBox2.Text == "None") 
            {
                query = "select laborername, id, age,rating, job,hiredtimes, picture from laborertable where job= '" + comboBox1.Text+ "' and (hirerid=null or hirerid='') and  (potentialcustomerid=null or potentialcustomerid='');";

                cmd = new SqlCommand(query, con);

                 

                 
            }

            else if (comboBox1.Text == "All" && comboBox2.Text != "None")
            {  if (comboBox2.Text == "Experience") { query = "select laborername, id,age,rating, job,hiredtimes, picture from laborertable where (hirerid=null or hirerid='') and  (potentialcustomerid=null or potentialcustomerid='')  order by hiredtimes desc;"; }
                else { query = "select laborername, id, age,rating, job,hiredtimes, picture from laborertable  where  (hirerid=null or hirerid='') or  (potentialcustomerid=null and potentialcustomerid='') order by " + comboBox2.Text + " desc;"; }

                  cmd = new SqlCommand(query, con);

                 

                 
            } */

             
                query = "select laborername,id, job, picture from laborertable where    hirerid=(select id from loggedinuserinfo) and  (potentialcustomerid=null or potentialcustomerid='');";

                  cmd = new SqlCommand(query, con);
                con.Open();
                
                con.Close();

            SqlConnection con2 = new SqlConnection(cs);
            con2.Open();

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

            DataGridViewImageColumn dgvic = new DataGridViewImageColumn();
            dgvic = (DataGridViewImageColumn)dataGridView1.Columns[3];
            dgvic.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 80;

            this.dataGridView1.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);



            con2.Close();



        }

        private void button4_Click(object sender, EventArgs e)
        {
             
            comboBox1.Text = "";

            pictureBox1.Image = Properties.Resources.head;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                button1.Visible = true;

                label9.Text = (dataGridView1.SelectedRows[0].Cells[0].Value).ToString();

                this.laborerID = (dataGridView1.SelectedRows[0].Cells[1].Value).ToString();

                //label10.Text = (dataGridView1.SelectedRows[0].Cells[2].Value).ToString();

                // label14.Text = (dataGridView1.SelectedRows[0].Cells[3].Value).ToString() + " Out of 5";

                label13.Text = (dataGridView1.SelectedRows[0].Cells[2].Value).ToString();

                // label12.Text = (dataGridView1.SelectedRows[0].Cells[5].Value).ToString();









                pictureBox1.Image = getPhoto((byte[])dataGridView1.SelectedRows[0].Cells[3].Value);


                SqlConnection conD = new SqlConnection(cs);
                SqlCommand cmdD;
                string queryD = "select  (select wage from dealings where dealings.LaborerID=laborertable.id and dealings.customerid=laborertable.hirerid and dealings.status='Started' ),laborertable.balance  from laborertable where laborertable.hirerid=(select id from loggedinuserinfo) and laborertable.id=@laborerID;";



                cmdD = new SqlCommand(queryD, conD);

                cmdD.Parameters.AddWithValue("@laborerID", this.laborerID);


                conD.Open();


                SqlDataReader drD = cmdD.ExecuteReader();
                drD.Read();

                if (drD.HasRows == true)
                {

                    this.customerBalance = drD.GetValue(0).ToString();
                    label12.Text = drD.GetString(0);
                    this.laborerBalance= drD.GetString(1);
                    this.laborerWage = label12.Text;
                }

                conD.Close();


                SqlConnection conx = new SqlConnection(cs);
                SqlCommand cmdx;
                string queryx = "select balance from laborertable where id=@laborerID;";

                cmdx = new SqlCommand(queryx, conx);

                cmdx.Parameters.AddWithValue("@laborerID", this.laborerID);






                conx.Open();


                SqlDataReader drx = cmdx.ExecuteReader();
                drx.Read();

                if (drx.HasRows == true)
                {

                    this.laborerBalance = drx.GetValue(0).ToString();

                }

                conx.Close();


            }
            catch (System.InvalidCastException) { }
            catch (System.ArgumentOutOfRangeException) { pictureBox1.Image = Properties.Resources.head; }
        }

        Image getPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);

            return Image.FromStream(ms);



        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.customerBalance = label8.Text;

             

            if (this.customerBalance != "0")
            {

                DialogResult d = MessageBox.Show("Pay Wage To Laborer???", "Wages", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (d == DialogResult.OK)
                {
                    this.customerBalance = (Convert.ToInt32(label8.Text) - Convert.ToInt32(label12.Text)).ToString();
                    this.laborerBalance = (Convert.ToInt32(this.laborerBalance) + Convert.ToInt32(label12.Text)).ToString();

                    label8.Text = this.customerBalance;

                    this.customerBalance = label8.Text;

                    SqlConnection conA = new SqlConnection(cs);
                    SqlCommand cmdA;
                    string queryA = "update logintable set balance=@customerBalance where id=(select id from loggedinuserinfo)";



                    cmdA = new SqlCommand(queryA, conA);

                    cmdA.Parameters.AddWithValue("@customerBalance", this.customerBalance);


                    conA.Open();


                    int x = cmdA.ExecuteNonQuery();

                    conA.Close();




                    SqlConnection conE = new SqlConnection(cs);
                    SqlCommand cmdE;
                    string queryE = "update laborertable set balance=@laborerBalance where id=@laborerID";



                    cmdE = new SqlCommand(queryE, conE);

                    cmdE.Parameters.AddWithValue("@laborerBalance", this.laborerBalance);

                    cmdE.Parameters.AddWithValue("@laborerID", this.laborerID);


                    conE.Open();


                    int xE = cmdE.ExecuteNonQuery();

                    conE.Close();




                    DialogResult dd = MessageBox.Show("Wage Payment Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

             
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.laborerRating = numericUpDown1.Text;

            SqlConnection conB = new SqlConnection(cs);
            SqlCommand cmdB;
            string queryB = "update laborertable set rating=@laborerRating,hirerid='' where id=@laborerID and hirerid=(select id from loggedinuserinfo);";



            cmdB = new SqlCommand(queryB, conB);

            cmdB.Parameters.AddWithValue("@laborerRating", this.laborerRating);

            cmdB.Parameters.AddWithValue("@laborerID", this.laborerID);


            conB.Open();
            int xB = cmdB.ExecuteNonQuery();

            conB.Close();


            SqlConnection conC = new SqlConnection(cs);
            SqlCommand cmdC;
            string queryC = "update dealings set  status='Finished 'where laborerid=@laborerID and customerid=(select id from loggedinuserinfo) and Status='Started';";



            cmdC = new SqlCommand(queryC, conC);

            

            cmdC.Parameters.AddWithValue("@laborerID", this.laborerID);


            conC.Open();


            int r = cmdC.ExecuteNonQuery();



            conC.Close();


            this.panel3.Visible = false;

            this.panel2.Visible = true;

            this.dataGridView1.Visible = true;

            this.label5.Visible = true;
            this.label4.Visible = true;
            this.comboBox1.Visible = true;
            this.button3.Visible = true;
            this.label2.Text = "Your Hired Laborers";


            BindGridView();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = false;

            this.panel2.Visible = true;

            this.dataGridView1.Visible = true;

            this.label5.Visible = true;
            this.label4.Visible = true;
            this.comboBox1.Visible = true;
            this.button3.Visible = true;
            this.label2.Text = "Your Hired Laborers";
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }
    }
}
