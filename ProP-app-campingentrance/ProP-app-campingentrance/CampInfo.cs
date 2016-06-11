using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace ProP_app_campingentrance
{
    class CampInfo
    {
        public MySqlConnection connection;

        public CampInfo()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi338468;" +
                                    "user id=dbi338468;" +
                                    "password=Xm6y5xuH99;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public CampSpot CampingInfo(String chip)
        {
            String sql = "SELECT cm.CAMPINGSPOT_campingspot_nr,cm.PAID_VISITOR_REGISTERED_USER_email, ru.fname, ru.lname from entered_visitor ev join paid_visitor pv on ev.PAID_VISITOR_REGISTERED_USER_email=pv.REGISTERED_USER_email join campingspot_member cm on cm.PAID_VISITOR_REGISTERED_USER_email=pv.REGISTERED_USER_email join registered_user ru on ru.email=pv.REGISTERED_USER_email where ev.chip_id="+chip+";";
            MySqlCommand command = new MySqlCommand(sql, connection);

            CampSpot spot = null;

            String fname = "", lname = "", email = "";
            int campingspot = 0;

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    fname = Convert.ToString(reader["fname"]);
                    lname = Convert.ToString(reader["lname"]);
                    email = Convert.ToString(reader["email"]);
                    campingspot = Convert.ToInt32(reader["CAMPINGSPOT_campingspot_nr"]);
                    spot = new CampSpot(lname, fname, email, campingspot);

                }
            }
            catch
            {
                MessageBox.Show("Error while loading the visitor's camping info!");
            }
            finally
            {
                connection.Close();
            }
            return spot;
        }
    }
}
