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

        /// <summary>
        /// it has to work for both chip code and the email so betta be working
        /// </summary>

        public Client_Info()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi338468;" +
                                    "user id=dbi338468;" +
                                    "password=Xm6y5xuH99;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public Visitor VisitorInfo(String visitoremail)
        {
            String sql = "SELECT * FROM registered_user,paid_visitor where registered_user_email=email and email='"+visitoremail+"'";
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

        public List<String> CampingInfo(String visitoremail)
        {
            String sql = "select campingspot_nr ,email,lname,fname FROM registered_user,paid_visitor,campingspot_member,campingspot WHERE `REGISTERED_USER_email`=email and `REGISTERED_USER_email`=`PAID_VISITOR_REGISTERED_USER_email` and `CAMPINGSPOT_campingspot_nr`=campingspot_nr and campingspot_nr = (select campingspot_nr FROM campingspot_member,campingspot WHERE `CAMPINGSPOT_campingspot_nr`=campingspot_nr and `PAID_VISITOR_REGISTERED_USER_email`='"+visitoremail+"')";
            MySqlCommand command = new MySqlCommand(sql, connection);

            List<String> visitorcampinginfo;
            visitorcampinginfo = new List<String>();

            String fname = "", lname = "", email = "",campingspot = "";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    fname = Convert.ToString(reader["fname"]);
                    lname = Convert.ToString(reader["lname"]);
                    email = Convert.ToString(reader["email"]);
                    campingspot = Convert.ToString(reader["campingspot_nr"]);

                }
                visitorcampinginfo.Add(campingspot+"\n");
                visitorcampinginfo.Add(fname+"\n");
                visitorcampinginfo.Add(lname+"\n");
                visitorcampinginfo.Add(email+"\n");


            }
            catch
            {
                MessageBox.Show("error while loading the visitor's camping info");
            }
            finally
            {
                connection.Close();
            }
            return visitorcampinginfo;
        }

    }
}
