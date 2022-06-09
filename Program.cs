using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApp5
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            SqlConnection con = new SqlConnection(cs);

            string query = "select (select usertype from logintable where logintable.id=loggedinuserinfo.id), pass,picture from loggedinuserinfo;";

            SqlCommand cmd = new SqlCommand(query, con);





            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            try
            {

                if (dr.HasRows == true)
                {
                    dr.Read();
                    string UserType = dr.GetString(0);
                    string Password = dr.GetString(1);

                    if (UserType == "Admin")
                    {
                        Application.Run(new Form5());

                    }
                    else if (UserType == "Manager")
                    {
                        Application.Run(new Form7());

                    }

                    else if (UserType == "")
                    { Application.Run(new Form1()); }

                    else { Application.Run(new Form6()); }
                }

            }

            catch (System.Data.SqlTypes.SqlNullValueException) { Application.Run(new Form1()); }

             
            con.Close();

        }
    }
}
