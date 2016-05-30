using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MySql.Data;
using MySql.Data.MySqlClient;

namespace StatusApp
{
    class General
    {
        public MySqlConnection connection;

        public General()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi338468;" +
                                    "user id=dbi338468;" +
                                    "password=Xm6y5xuH99;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public int NumberOfVisitors()
        {
            String sql = "SELECT COUNT(*) FROM paid_visitor";
            MySqlCommand command = new MySqlCommand(sql, connection);

            int number = 0;

            try
            {
                connection.Open();
                number = Convert.ToInt32(command.ExecuteScalar());
                return number;
            }
            catch
            {
                return -1;

            }
            finally
            {
                connection.Close();
            }
        }

        public int NumberOfVisitorsEntered()
        {
            String sql = "SELECT COUNT(*) FROM entered_visitor";
            MySqlCommand command = new MySqlCommand(sql, connection);

            int number = 0;

            try
            {
                connection.Open();
                number = Convert.ToInt32(command.ExecuteScalar());
                return number;
            }
            catch
            {
                return -1;

            }
            finally
            {
                connection.Close();
            }

        }

        public int NumberOfVisitorsLeft()
        {
            String sql = "SELECT COUNT(*) FROM entered_visitor WHERE has_left_event='Y'";
            MySqlCommand command = new MySqlCommand(sql, connection);

            int number = 0;

            try
            {
                connection.Open();
                number = Convert.ToInt32(command.ExecuteScalar());
                return number;
            }
            catch
            {
                return -1;

            }
            finally
            {
                connection.Close();
            }

        }
        public int TotalAmountOfEventAccounts()
        {
            String sql = "SELECT Sum(balance_left) FROM paid_visitor";
            MySqlCommand command = new MySqlCommand(sql, connection);

            int number = 0;

            try
            {
                connection.Open();
                number = Convert.ToInt32(command.ExecuteScalar());
                return number;
            }
            catch
            {
                return -1;

            }
            finally
            {
                connection.Close();
            }
        }
    }
}
