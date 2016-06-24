using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;



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

        public void GeneralStatistics(out int numberOfVisitors,out int numberOfEntered,out int numberOfLeft)
        {
            //This method will generated the number of visitors that have paid, the number of visitors that entered, the number of visitor that have still to come, and the number of visitors who left
            
            String sql = "SELECT COUNT(*) FROM paid_visitor";
            MySqlCommand commandNrOfVisitors = new MySqlCommand(sql, connection);

            String sql1="SELECT COUNT(*) FROM entered_visitor";
            MySqlCommand commandNrOfEntered = new MySqlCommand(sql1, connection);

            String sql2 = "SELECT COUNT(*) FROM entered_visitor WHERE has_left_event='Y'";
            MySqlCommand commandNrOfLeft = new MySqlCommand(sql2, connection);

            numberOfVisitors = -1;
            numberOfEntered = -1;
            numberOfLeft = -1;

            try
            {
                connection.Open();
                numberOfVisitors = Convert.ToInt32(commandNrOfVisitors.ExecuteScalar());

                numberOfEntered = Convert.ToInt32(commandNrOfEntered.ExecuteScalar());

                numberOfLeft = Convert.ToInt32(commandNrOfLeft.ExecuteScalar());

            }
            catch(MySqlException)
            {
                MessageBox.Show("Something went wrong with the connection");
            }
            finally
            {
                connection.Close();
            }
        }

        
        public void TotalAmountOfEventAccountsAndProfit(out double totalbalance)
        {
            //This method calculated the total money from all the event-accounts

            String sql = "SELECT ifnull(Sum(balance_left),0) FROM paid_visitor";
            MySqlCommand command = new MySqlCommand(sql, connection);

            totalbalance = -1;

            try
            {
                connection.Open();
                totalbalance = Convert.ToDouble(command.ExecuteScalar());
            }
            catch (MySqlException)
            {
                MessageBox.Show("Something went wrong with the connection");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
