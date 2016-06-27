using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ProP_app_shop
{
    class DataHelper
    {
        //fields
        public MySqlConnection connection;

        //constructor
        public DataHelper()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi338468;" +
                                    "user id=dbi338468;" +
                                    "password=Xm6y5xuH99;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        //methods

        //get all items from the database (initializing / after updating)
        public List<ItemsForSale> GetAllItems()
        {
            String sql = "SELECT * FROM product";
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<ItemsForSale> SellingList = new List<ItemsForSale>();
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                int id;
                string name;
                double price;
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        name = Convert.ToString(reader["description"]);
                        price = Convert.ToDouble(reader["price"]);
                        id = Convert.ToInt32(reader["price"]);
                        SellingList.Add(new ItemsForSale(id, name, price));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error while loading items");
            }
            finally
            {
                connection.Close();
            }
            return SellingList;
        }

        //get visitor information through chip_id (bracelet code)
        public Visitor GetInfoFromChipID(string chipid)
        {
            Visitor visitorInfo;
            String sql = "select r.fname, p.balance_left from registered_user r join paid_visitor p on r.email = p.registered_user_email join entered_visitor e on r.email = e.paid_visitor_registered_user_email where e.chip_id = @chipid";
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
                        visitorInfo = new Visitor(Convert.ToString(reader["fname"]), Convert.ToDouble(reader["balance_left"]));
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

        //get visitor information through email (bracelet code)
        public Visitor GetInfoFromEmail(string email)
        {
            Visitor visitorInfo;
            String sql = "select r.fname, p.balance_left from registered_user r join paid_visitor p on r.email = p.registered_user_email join entered_visitor e on r.email = e.paid_visitor_registered_user_email where e.paid_visitor_registered_user_email = @email";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@email", email);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        visitorInfo = new Visitor(Convert.ToString(reader["fname"]), Convert.ToDouble(reader["balance_left"]));
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

        //using email to get the chip_id -> using other methods without scanning the chip_id at first
        public string GetChipIdFromEmail(string email)
        {
            String sql = "select chip_id from entered_visitor where paid_visitor_registered_user_email = @email";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@email", email);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        string chipId = Convert.ToString(reader["chip_id"]);
                        return chipId;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Problem while finding user chip_id from email");
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        //adding big transaction to the database (increment +1 on database whenever the visitor making a big transaction)
        public void AddShopTransactionInfo(string chipId)
        {
            String sql = "insert into shop (entered_visitor_chip_id) values (@chipId)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@chipId", chipId);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Problem while adding transaction info to the database");
            }
            finally
            {
                connection.Close();
            }
        }

        //get max order_id -> attached the small transactions to the big transaction where they belong
        public int GetShopOrderId()
        {
            String sql = "select max(order_id) from shop";
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int orderid = Convert.ToInt32(reader["max(order_id)"]);
                        return orderid;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Problem while finding the order_id");
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }

        //adding small transaction to the database
        public void AddShopLineTransactionInfo(int productId, int orderId, int quantity)
        {
            String sql = "insert into shop_line (quantity, product_product_id, shop_order_id) values (@quantity, @productId, @orderId)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@productId", productId);
            command.Parameters.AddWithValue("@orderId", orderId);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Problem while adding line transaction info to the database");
            }
            finally
            {
                connection.Close();
            }
        }

        //update visitor balance whenever a transaction is made
        public void UpdateBalance(double balanceLeft, string chipid)
        {
            string sql = "update paid_visitor p join entered_visitor e on p.registered_user_email = e.paid_visitor_registered_user_email set balance_left = @balanceleft where e.chip_id = @chipId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@balanceleft", balanceLeft);
            command.Parameters.AddWithValue("@chipId", chipid);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Problem while updating the balance of user");
            }
            finally
            {
                connection.Close();
            }
        }

        //update number of items in-stock after a transaction is made
        public void UpdateInStock(int instock, int productId)
        {
            string sql = "update product set in_stock = @instock where product_id = @productId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@instock", instock);
            command.Parameters.AddWithValue("@productId", productId);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Problem while updating the number in-stock");
            }
            finally
            {
                connection.Close();
            }
        }

        //get the number instock of an item
        public int GetInStock(int productId)
        {
            string sql = "select in_stock from product where product_id = @productId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@productId", productId);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int nrInStock = Convert.ToInt32(reader["in_stock"]);
                        return nrInStock;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Problem while getting the number instock of an item");
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }

        //get the new balance of the user to show on the interface after making transaction
        public double GetUpdatedBalance(string chipId)
        {
            string sql = "select p.balance_left from paid_visitor p join entered_visitor e on p.registered_user_email = e.paid_visitor_registered_user_email where e.chip_id = @chipId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@chipId", chipId);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        double balance = Convert.ToDouble(reader["balance_left"]);
                        return balance;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Problem while the updated balance of the user");
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }

        //get the id of a specific item
        public int GetProductId(string description)
        {
            string sql = "select product_id from product where description = @description";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@description", description);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int productId = Convert.ToInt32(reader["product_id"]);
                        return productId;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Problem while the updated balance of the user");
            }
            finally
            {
                connection.Close();
            }
            return -1;
        } 
    }
}
