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
    class DataHelper
    {
        public MySqlConnection connection;

        public DataHelper()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi338468;" +
                                    "user id=dbi338468;" +
                                    "password=Xm6y5xuH99;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public Visitor GetInfoFromChipID(string chipid)
        {
            //try + catch + finally
            Visitor visitorInfo; 
            String sql = "select * from visitor where chip_id = @chipid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@chipid", chipid);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        visitorInfo = new Visitor(Convert.ToString(reader["name"]), Convert.ToString(reader["email"]), 
                                                  Convert.ToString(reader["registration"]), Convert.ToString(reader["spot"]));
                        return visitorInfo;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Problem while finding the information of the user");
            }
            finally
            {
                connection.Close();
            }
            return null;
        }



    }
}
