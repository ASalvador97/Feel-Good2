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
        public List<ItemsForLoan> GetAllItems()
        {
            String sql = "SELECT * FROM lend_item where lend_item_status is null";
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<ItemsForLoan> RentingList = new List<ItemsForLoan>();
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                int itemid;
                string name;
                double priceHour;
                double deposit;
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        itemid = Convert.ToInt32(reader["item_id"]);
                        name = Convert.ToString(reader["name"]);
                        priceHour = Convert.ToDouble(reader["price_hour"]);
                        deposit = Convert.ToDouble(reader["deposit"]);
                        RentingList.Add(new ItemsForLoan(itemid, name, priceHour, deposit));
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
            return RentingList;
        }

        //Get items that are borrowed by user and not being returned yet
        public List<ItemsForLoan> GetItemsToReturn(string chipid)
        {
            String sql = "select i.item_id, i.name, i.price_hour, i.deposit, l.time_borrowed from lend_item i join lending_line l on l.lend_item_item_id = i.item_id join lending g on g.lending_id = l.lending_lending_id where g.entered_visitor_chip_id = @chipid and l.time_returned is null";
            List<ItemsForLoan> ReturnList = new List<ItemsForLoan>();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@chipid", chipid);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                int itemid;
                string name;
                double priceHour;
                double deposit;
                DateTime timeBorrowed;
                while (reader.Read())
                {
                    itemid = Convert.ToInt32(reader["item_id"]);
                    name = Convert.ToString(reader["name"]);
                    priceHour = Convert.ToDouble(reader["price_hour"]);
                    deposit = Convert.ToDouble(reader["deposit"]);
                    timeBorrowed = Convert.ToDateTime(reader["time_borrowed"]);
                    ReturnList.Add(new ItemsForLoan(itemid, name, priceHour, deposit, timeBorrowed));
                }
            }
            catch
            {
                MessageBox.Show("Error while loading items to be returned");
            }
            finally
            {
                connection.Close();
            }
            return ReturnList;
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
        public void AddLendingTransactionInfo(string chipId)
        {
            String sql = "insert into lending (entered_visitor_chip_id) values (@chipId)";           
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

        //get max lending_id -> attached the small transactions to the big transaction where they belong
        public int GetLendingId()
        {
            String sql = "select max(lending_id) from lending";
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int lendingid = Convert.ToInt32(reader["max(lending_id)"]);
                        return lendingid;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Problem while finding the lending_id");
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }

        //adding small transaction to the database
        public void AddLendingLineTransactionInfo(int lendingId, int itemId, DateTime borrowDateTime)
        {
            String sql = "insert into lending_line (lending_lending_id, lend_item_item_id, time_borrowed) values (@lendingId, @itemId, @borrowDateTime)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@lendingId", lendingId);
            command.Parameters.AddWithValue("@itemId", itemId);
            command.Parameters.AddWithValue("@borrowDateTime", borrowDateTime);
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

        //update items info after a transaction is made
        public void UpdateItemInfo()
        {
            string sql = "update lend_item set lend_item_status = 'Y' where item_id in (select lend_item_item_id from lending_line where time_returned is null)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Problem while updating the item info");
            }
            finally
            {
                connection.Close();
            }
        }

        //update item status after the visitor return the item
        public void ReturnItems(DateTime timeReturned, int itemId)
        {
            string sql = "update lend_item i join lending_line l on i.item_id = l.lend_item_item_id set l.time_returned = @timeReturned, i.lend_item_status = null where l.lend_item_item_id = @itemId and l.time_returned is null";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@timeReturned", timeReturned);
            command.Parameters.AddWithValue("@itemId", itemId);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Problem while returning items");
            }
            finally
            {
                connection.Close();
            }
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
                MessageBox.Show("Problem while get the updated balance of the user");
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }
    }
}
