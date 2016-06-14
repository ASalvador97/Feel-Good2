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


        public Visitor GetVisitorViaChip(string chipid)
        {
            String sql = "SELECT PAID_VISITOR_REGISTERED_USER_email from entered_visitor where chip_id='" + chipid + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            Visitor myVisitor = null;

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    myVisitor = new Visitor(Convert.ToString(reader["PAID_VISITOR_REGISTERED_USER_email"]), chipid);
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
            return myVisitor ;
        }


        public Visitor GetVisitorViaEmail(string email)
        {
            String sql = "SELECT PAID_VISITOR_REGISTERED_USER_email, chip_id from entered_visitor where PAID_VISITOR_REGISTERED_USER_email='" + email + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            Visitor myVisitor = null;

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    myVisitor = new Visitor(Convert.ToString(reader["PAID_VISITOR_REGISTERED_USER_email"]), Convert.ToString(reader["chip_id"]));
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

        public List<string> GetGoods(string chipid)
        {

            //String sql = "select pv.REGISTERED_USER_email, ev.chip_id, ev.has_left_event, ifnull(l.final_price,0) from paid_visitor pv join entered_visitor ev on ev.PAID_VISITOR_REGISTERED_USER_email=pv.REGISTERED_USER_email right join lending l on l.ENTERED_VISITOR_chip_id=ev.chip_id where ev.chip_id='"+chipid+"';";
            String sql = "SELECT l.ENTERED_VISITOR_chip_id,  ev.PAID_VISITOR_REGISTERED_USER_email, l.lending_id, ll.LEND_ITEM_item_id, ll.time_borrowed, ifnull(ll.time_returned,0), li.name from lend_item li join lending_line ll on li.item_id=ll.LEND_ITEM_item_id join lending l on l.lending_id=ll.LENDING_lending_id join entered_visitor ev on ev.chip_id=l.ENTERED_VISITOR_chip_id where l.ENTERED_VISITOR_chip_id='" + chipid + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);

            List<string> borrowedGoods = new List<string>();
           
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    String returned = Convert.ToString(reader["ifnull(ll.time_returned,0)"]);
                    if (returned == "0")
                    {
                        string info = "Id: " + Convert.ToString(reader["LEND_ITEM_item_id"]) + "   Name: " + Convert.ToString(reader["name"])  + "    Time borrowed: " + Convert.ToString(reader["time_borrowed"]) +
                        "    Time returned: " + Convert.ToString(reader["ifnull(ll.time_returned,0)"]);

                        borrowedGoods.Add(info);
                    }

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
            return borrowedGoods;
        }

        public bool UpdateExitStatus(string chipid)
        {
            String sql = "UPDATE `dbi338468`.`entered_visitor` SET `has_left_event` = 'Y' WHERE `entered_visitor`.`chip_id` ='"+chipid+"'";
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();
                int nrOfRecordsChanged = command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false; //which means the try-block was not executed succesfully, so  . . .
            }
            finally
            {
                connection.Close();
            }
        }



        
    }
}

        