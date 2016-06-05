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

        public Double CampingNumbers(out int occupied,out int free,out int inside, out int outside,out int peoplewithspot)
        {
            String sql = "SELECT count(distinct `CAMPINGSPOT_campingspot_nr`) FROM `campingspot_member`";
            MySqlCommand commandoccupied = new MySqlCommand(sql, connection);

            String sql1 = "SELECT count(*) FROM `campingspot` WHERE `campingspot_nr` not in(select `CAMPINGSPOT_campingspot_nr` from campingspot_member)";
            MySqlCommand commandfree = new MySqlCommand(sql, connection);

            String sql2 = "";
            MySqlCommand commandinside = new MySqlCommand(sql, connection);

            String sql3 = "";
            MySqlCommand commandoutside = new MySqlCommand(sql, connection);

            String sql4 = "SELECT count(`PAID_VISITOR_REGISTERED_USER_email`) FROM campingspot_member";
            MySqlCommand commandpeoplewithspot = new MySqlCommand(sql, connection);

            String sql5 = "";
            MySqlCommand commandmoney = new MySqlCommand(sql, connection);

            occupied = -1; free = -1; inside = -1; outside = -1; peoplewithspot = -1;
            double money=-1;
            try
            {
                occupied = Convert.ToInt32(commandoccupied.ExecuteScalar());

                free = Convert.ToInt32(commandfree.ExecuteScalar());

                inside=

                outside=

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

    }
}
