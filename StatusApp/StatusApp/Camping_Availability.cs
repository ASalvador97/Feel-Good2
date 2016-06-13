using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace StatusApp
{
    class Camping_Availability
    {
        //this class regards information about the camping availability
        public MySqlConnection connection;

        public Camping_Availability()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi338468;" +
                                    "user id=dbi338468;" +
                                    "password=Xm6y5xuH99;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public Double CampingNumbers(out int occupied,out int free,out int peoplewithspot)
        {
            //Here are some statistics regarding the number of occupied/free spots, people with spots and the amount of money gained by the booked spots

            String sql = "SELECT count(distinct `CAMPINGSPOT_campingspot_nr`) FROM `campingspot_member`";
            MySqlCommand commandoccupied = new MySqlCommand(sql, connection);

            String sql1 = "SELECT count(*) FROM `campingspot` WHERE `campingspot_nr` not in(select `CAMPINGSPOT_campingspot_nr` from campingspot_member)";
            MySqlCommand commandfree = new MySqlCommand(sql1, connection);

            String sql4 = "SELECT count(`PAID_VISITOR_REGISTERED_USER_email`) FROM campingspot_member";
            MySqlCommand commandpeoplewithspot = new MySqlCommand(sql4, connection);

            occupied = -1; free = -1; peoplewithspot = -1;

            double money=-1;
            try
            {
                connection.Open();

                occupied = Convert.ToInt32(commandoccupied.ExecuteScalar());

                free = Convert.ToInt32(commandfree.ExecuteScalar());

                peoplewithspot = Convert.ToInt32(commandpeoplewithspot.ExecuteScalar());

                money = peoplewithspot * 20 + occupied * 30;

                return money;
            }
            catch
            {
                MessageBox.Show("error getting the data");
            }
            finally
            {
                connection.Close();
            }
            return money;
        }

        public List<CampSpot> Specificspot(int spot)
        {
            //Here will be generated information regarding one spot

            String sql = "SELECT fname,lname,`PAID_VISITOR_REGISTERED_USER_email` ,`CAMPINGSPOT_campingspot_nr` FROM `campingspot_member`,paid_visitor,registered_user WHERE `PAID_VISITOR_REGISTERED_USER_email`=REGISTERED_USER_email and REGISTERED_USER_email=email and `CAMPINGSPOT_campingspot_nr`=" + spot.ToString() + ";";
            MySqlCommand commandspecspot = new MySqlCommand(sql,connection);

            List<CampSpot> peopleintthatspot=new List<CampSpot>();

            try
            {
                connection.Open();
                MySqlDataReader reader = commandspecspot.ExecuteReader();

                while(reader.Read())
                    peopleintthatspot.Add(new CampSpot(Convert.ToString(reader["fname"]), Convert.ToString(reader["lname"]), Convert.ToString(reader["PAID_VISITOR_REGISTERED_USER_email"]), Convert.ToInt32(reader["CAMPINGSPOT_campingspot_nr"])));

                             
            }
            catch(MySqlException)
            {
                MessageBox.Show("Something went wrong with the connection");
                
            }
            finally
            {
                connection.Close();
            }
            return peopleintthatspot;
        }

        public List<int> FreeSpots() 
        {
            //This method will display the free spots

            String sql = "SELECT `campingspot_nr` FROM `campingspot` WHERE campingspot_nr NOT IN (select campingspot_campingspot_nr from campingspot_member)";
            MySqlCommand commandfreespot = new MySqlCommand(sql, connection);

            List<int> freespots = new List<int>();

            try
            {
                connection.Open();
                MySqlDataReader reader = commandfreespot.ExecuteReader();

                while (reader.Read())
                    freespots.Add(Convert.ToInt32(reader["campingspot_nr"]));


            }
            catch (MySqlException)
            {
                MessageBox.Show("Something went wrong with the connection");

            }
            finally
            {
                connection.Close();
            }
            return freespots;
        }

    }
}
