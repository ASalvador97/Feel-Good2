using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace ProP_app_entrance
{
    public class DataHelper
    {
        public MySqlConnection connection;
        Visitor myVisitor = null;

        public DataHelper()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi338468;" +
                                    "user id=dbi338468;" +
                                    "password=Xm6y5xuH99;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }


        public Visitor GetVisitor(String barcode)
        {

            String initsql = "select r.fname, r.lname, r.email, r.phone, p.barcode, ifnull(cm.CAMPINGSPOT_campingspot_nr,0) from registered_user r join paid_visitor p on r.email=p.REGISTERED_USER_email left join campingspot_member cm on cm.PAID_VISITOR_REGISTERED_USER_email = r.email where p.barcode='" + barcode + "'";
            MySqlCommand command = new MySqlCommand(initsql, connection);

           
            

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    myVisitor = new Visitor(Convert.ToString(reader["fname"]), Convert.ToString(reader["lname"]),
                        Convert.ToString(reader["email"]), Convert.ToString(reader["phone"]), Convert.ToInt32(reader["ifnull(cm.CAMPINGSPOT_campingspot_nr,0)"]), Convert.ToString(reader["barcode"]));               

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

        public bool SyncBracelet(String chipid, string email, string eventid, string hasleftevent, string campingstatus)
        {

            String sql = "INSERT INTO `dbi338468`.`entered_visitor` (`chip_id`, `PAID_VISITOR_REGISTERED_USER_email`, `PAID_VISITOR_EVENT_event_id`, `has_left_event`, `Camping_status`) VALUES ('" + chipid + "', '" + email + "', '" + eventid + "', '" + hasleftevent + "', '" + campingstatus + "');";
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


        public bool CheckBarcode(String barcode)
        {

            String sql = "SELECT pv.barcode, ifnull(ev.chip_id,0), pv.REGISTERED_USER_email from paid_visitor pv left join entered_visitor ev on pv.REGISTERED_USER_email=ev.PAID_VISITOR_REGISTERED_USER_email WHERE pv.barcode='"+barcode+"'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            string chip = "";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    chip = Convert.ToString(reader["ifnull(ev.chip_id,0)"]);
                   
                }
                if (chip == "0")
                {
                    return true;
                }
                else { return false; }
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

        