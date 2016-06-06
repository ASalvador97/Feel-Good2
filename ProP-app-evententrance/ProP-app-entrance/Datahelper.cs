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

        public DataHelper()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi338468;" +
                                    "user id=dbi338468;" +
                                    "password=Xm6y5xuH99;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }


        public List<String> GetVisitor(string barcode)
        {

            String sql = "select r.fname, r.lname, r.email, p.barcode from registered_user r join paid_visitor p on r.email=p.REGISTERED_USER_email where p.barcode='" + barcode + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);

            List<String> VisitorData = new List<String>();


            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    string name = Convert.ToString(reader["fname"]) + Convert.ToString(reader["lname"]);
                    VisitorData.Add(name);
                    string email = Convert.ToString(reader["email"]);
                    VisitorData.Add(email);
                    VisitorData.Add(barcode);

                }
            }
            catch
            {
                MessageBox.Show("this visitor doesnt exist");
            }
            finally
            {
                connection.Close();
            }
            return VisitorData;
        }
    }
}

        