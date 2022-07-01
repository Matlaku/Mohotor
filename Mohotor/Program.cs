using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Mohotor
{
    class Program
    {

        SqlConnection scon;
        string connection;

        static void Main(string[] args)
        {
            //database connection

            //afteer everything, call main program again if user wants to.
            Program program = new Program();
            program.mainprogram();
        }

        public void mainprogram()
        {
            connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=annie;Integrated Security=True";
            scon = new SqlConnection(connection);

            Console.WriteLine("What would you like to do");
            Console.WriteLine("1. Get Charging Point\n2. Become a POP");

            int command = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(command);

            if (command == 1)
            {
                //get info about which places are available and add to data table
                SqlDataAdapter da = new SqlDataAdapter("select PopID from POP where availability = 1", scon);
                DataTable dt = new DataTable();
                da.Fill(dt);

                try
                {
                    //PopId is in the result variable
                    int id = Convert.ToInt32(dt.Rows[0][0]);
                    Console.WriteLine(id.ToString());

                    //select from the table the first available charging point, add to datatable
                    SqlDataAdapter selectlocation = new SqlDataAdapter("select Name, address from POP where PopID = " + id + "", scon);
                    DataTable location = new DataTable();
                    selectlocation.Fill(location);

                    //get the location and the name from the data table add to 'name' and 'address' variables
                    string name = location.Rows[0][0].ToString();
                    string address = location.Rows[0][1].ToString();
                    Console.WriteLine(name + " has an available charging point at : " + address);

                    //change availability to 0 
                    //SqlDataAdapter updateavail = new SqlDataAdapter("update POP set availability = 0 where PopID = " + id, scon);
                    SqlCommand scom = new SqlCommand("update POP set availability = 0 where PopID = " + id, scon);
                    scon.Open();
                    scom.ExecuteNonQuery();
                    scon.Close();
                    scom.Dispose();
                }
                catch
                {
                    Console.WriteLine("There are no available charging stations, wait a minute and try again");
                }
            }
            else if(command == 2)
            {
                Console.WriteLine("Name:");
                string username = Console.ReadLine();
                Console.WriteLine("address:");
                string useraddress = Console.ReadLine();

                //add new user into the database
                SqlCommand adduser = new SqlCommand("insert into POP values('" + useraddress + "','" + username + "', 1", scon);
                scon.Open();
                adduser.ExecuteNonQuery();
                scon.Close();
                adduser.Dispose();
            }
            else
            {
                Console.WriteLine("Incorrect entry");
                Program program = new Program();
                program.mainprogram();
            }
            Console.ReadLine();

        }

    }
}
