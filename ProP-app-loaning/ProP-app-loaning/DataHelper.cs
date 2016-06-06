using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ProP_app_loaning
{
    class DataHelper
    {
        public MySqlConnection connection;

        public DataHelper()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi333223;" +
                                    "user id=dbi333223;" +
                                    "password=RBj8KAOq0E;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public List<ItemsForRent> GetAllItems()
        {
            String sql = "SELECT * FROM prop_itemforrent";
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<ItemsForRent> RentingList = new List<ItemsForRent>();
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                String name;
                double price;
                while (reader.Read())
                {
                    name = Convert.ToString(reader["r_item_name"]);
                    price = Convert.ToDouble(reader["r_item_price"]);
                    RentingList.Add(new ItemsForRent(name, price));
                }
            }
            catch
            {
                MessageBox.Show("error while loading items");
            }
            finally
            {
                connection.Close();
            }
            return RentingList;
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
                        visitorInfo = new Visitor(Convert.ToString(reader["name"]), Convert.ToDouble(reader["balance"]));
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
