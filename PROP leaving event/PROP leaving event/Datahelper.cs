using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PROP_leaving_event
{
    public class DataHelper
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


        public Visitor GetVisitor(string chipid)
        {

            String sql = "select pv.REGISTERED_USER_email, ev.chip_id, ev.has_left_event, ifnull(l.final_price,0) from paid_visitor pv join entered_visitor ev on ev.PAID_VISITOR_REGISTERED_USER_email=pv.REGISTERED_USER_email right join lending l on l.ENTERED_VISITOR_chip_id=ev.chip_id where ev.chip_id='"+chipid+"';";
            MySqlCommand command = new MySqlCommand(sql, connection);

            Visitor myVisitor = null;
            
            bool returngoods = false;

           
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                

                while (reader.Read())
                {

                    //check if ifnull(l.final_price,0) is 0. if it is, then items need to be returned and bool returngoods==true
                    myVisitor = new Visitor(Convert.ToString(reader["REGISTERED_USER_email"]), Convert.ToString(reader["chip_id"]), returngoods);

                }

            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
            finally
            {
                connection.Close();
            }
            return myVisitor;
        }

        public List<String> GetBorrowedGoods(string chipid)
        {

            String sql = "select li.item_id, li.name, li.price_hour, li.deposit, l.lending_id, ll.time_borrowed, ll.time_returned, l.ENTERED_VISITOR_chip_id from lending l join lending_line ll on l.lending_id=ll.LENDING_lending_id join lend_item li on li.item_id = ll.LEND_ITEM_item_id where l.ENTERED_VISITOR_chip_id='"+chipid+"';";
            MySqlCommand command = new MySqlCommand(sql, connection);

            List<String> borrowedItems;
            borrowedItems = new List<string>();

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                   
                    string info = "Id: " + Convert.ToString(reader["li.item_id"]) + "/tName: " +Convert.ToString(reader["li.name"])+ "/t Price p/h: " 
                        + Convert.ToString(reader["li.price_hour"])+ "/t Deposit:" +Convert.ToString(reader["li.deposit"])+ "/ Time borrowed: " +Convert.ToString(reader["ll.time_borrowed"])+
                        "/t Time returned: " +Convert.ToString(reader["ll.time_returned"]) + "/t /t";

                    borrowedItems.Add(info);
                    
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
            finally
            {
                connection.Close();
            }
            return borrowedItems;
        }
    }
}

        