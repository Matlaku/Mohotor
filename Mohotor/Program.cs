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
                //get info and add to data table
                SqlDataAdapter da = new SqlDataAdapter("select PopID from POP where availability = 1", scon);
                DataTable dt = new DataTable();
                da.Fill(dt);

                try
                {
                    string result = dt.Rows[0][0].ToString();
                    Console.WriteLine(result);
                }
                catch
                {
                    Console.WriteLine("There are no available charging stations, wait a minute and try again");
                }
            }
            else if(command == 2)
            {

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
