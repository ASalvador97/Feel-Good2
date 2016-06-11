using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace StatusApp
{
    class Client_Info
    {
        public MySqlConnection connection;

        public Client_Info()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi338468;" +
                                    "user id=dbi338468;" +
                                    "password=Xm6y5xuH99;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public Visitor VisitorInfo(String chip)
        {
            //Information regarding the visitor whose chip was scanned

            String sql = "SELECT * FROM entered_visitor ev join paid_visitor pv on ev.PAID_VISITOR_REGISTERED_USER_email=pv.REGISTERED_USER_email join registered_user ru on ru.email=pv.REGISTERED_USER_email where ev.chip_id='"+chip+"'";
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                Visitor visdet=null;
                

                while (reader.Read())
                {
                    visdet = new Visitor(Convert.ToString(reader["fname"]), Convert.ToString(reader["lname"]), Convert.ToString(reader["email"]), Convert.ToString(reader["phone"]), Convert.ToString(reader["city"]), Convert.ToString(reader["country"]), Convert.ToDateTime(reader["dob"]), Convert.ToString(reader["gender"]), Convert.ToDouble(reader["balance_left"]));
  
                }

                return visdet;
            }
            catch
            {
                MessageBox.Show("error while loading the visitor");
            }
            finally
            {
                
                connection.Close();
            }
            return null;
        }

        public CampSpot CampingInfo(String chip)
        {
            //The camping information of this visitor that was just scanned

            String sql = "SELECT cm.CAMPINGSPOT_campingspot_nr,cm.PAID_VISITOR_REGISTERED_USER_email, ru.fname, ru.lname from entered_visitor ev join paid_visitor pv on ev.PAID_VISITOR_REGISTERED_USER_email=pv.REGISTERED_USER_email join campingspot_member cm on cm.PAID_VISITOR_REGISTERED_USER_email=pv.REGISTERED_USER_email join registered_user ru on ru.email=pv.REGISTERED_USER_email where ev.chip_id='"+chip+"'";
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
                    email = Convert.ToString(reader["PAID_VISITOR_REGISTERED_USER_email"]);
                    campingspot = Convert.ToInt32(reader["CAMPINGSPOT_campingspot_nr"]);

                }

                spot = new CampSpot(lname, fname, email, campingspot);

            }
            catch
            {
                MessageBox.Show("error while loading the visitor's camping info");
            }
            finally
            {
                connection.Close();
            }
            return spot;
        }

    }
}
