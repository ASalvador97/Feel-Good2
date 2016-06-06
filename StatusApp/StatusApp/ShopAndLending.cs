using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace StatusApp
{
    class ShopAndLending
    {
        public MySqlConnection connection;

        public ShopAndLending()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi338468;" +
                                    "user id=dbi338468;" +
                                    "password=Xm6y5xuH99;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public List<ShopProduct> ShopItems()
        {
            String sql = "SELECT `product_id`,`description` ,`price`,`in_stock`, sum(quantity) FROM `product` ,shop_line WHERE `product_id`=`PRODUCT_product_id` group by `product_id`,`description` ,`price`,`in_stock`";
            MySqlCommand commandproduct = new MySqlCommand(sql,connection);

            List<ShopProduct> products = new List<ShopProduct>();
            int quantity;
            double price;
            try
            {
                connection.Open();
                MySqlDataReader reader = commandproduct.ExecuteReader();

                while (reader.Read())
                {
                    quantity = Convert.ToInt32(reader["sum(quantity)"]);
                    price = Convert.ToDouble(reader["price"]);
                    products.Add(new ShopProduct(Convert.ToInt32(reader["product_id"]), Convert.ToString(reader["description"]), Convert.ToDouble(reader["price"]), Convert.ToInt32(reader["in_stock"]), Convert.ToInt32(reader["sum(quantity)"]), price * quantity));
                }

                             
            }
            catch(MySqlException)
            {
                MessageBox.Show("Something went wrong with the connection");
                
            }
            finally
            {
                connection.Close();
            }
            return products;
        }

        public List<LendingItem> LendItems()
        {
            String sql = "SELECT item_id,name,price_hour,deposit,in_stock, count(*),sum(TIMESTAMPDIFF(HOUR,time_borrowed,time_returned)) FROM `lend_item`, lending_line WHERE `LEND_ITEM_item_id`=item_id group by item_id,name,price_hour,deposit,in_stock";
            MySqlCommand commandlending = new MySqlCommand(sql,connection);

            List<LendingItem> lendings = new List<LendingItem>();
            int time;
            double pricehour;
            try
            {
                connection.Open();
                MySqlDataReader reader = commandlending.ExecuteReader();

                while (reader.Read())
                {
                    time = Convert.ToInt32(reader["sum(TIMESTAMPDIFF(HOUR,time_borrowed,time_returned))"]);
                    pricehour = Convert.ToDouble(reader["price_hour"]);
                    lendings.Add(new LendingItem(Convert.ToInt32(reader["item_id"]), Convert.ToString(reader["name"]), Convert.ToDouble(reader["price_hour"]), Convert.ToDouble(reader["deposit"]), Convert.ToInt32(reader["in_stock"]), time,time*pricehour));
                }

                             
            }
            catch(MySqlException)
            {
                MessageBox.Show("Something went wrong with the connection");
                
            }
            finally
            {
                connection.Close();
            }
            return lendings;
        }
    }
}
