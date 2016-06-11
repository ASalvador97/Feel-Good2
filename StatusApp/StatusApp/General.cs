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

        
        public void TotalAmountOfEventAccountsAndProfit(out double totalbalance,out double totalprofit)
        {
            //This method calculated the total money from all the event-accounts, the amount of money from all items sold in the shops plus the one from all lended items

            String sql = "SELECT ifnull(Sum(balance_left),0) FROM paid_visitor";
            MySqlCommand command = new MySqlCommand(sql, connection);

            String sql1 = "SELECT ifnull(Sum(total_price),0) FROM shop";
            MySqlCommand commandprofitshop = new MySqlCommand(sql1, connection);

            String sql2 = "SELECT ifnull(Sum(final_price),0) FROM lending";
            MySqlCommand commandprofitlend = new MySqlCommand(sql2, connection);

            double shop=0,lend=0;
            totalbalance = -1;
            totalprofit = -1;

            try
            {
                connection.Open();
                totalbalance = Convert.ToDouble(command.ExecuteScalar());

                shop = Convert.ToDouble(commandprofitshop.ExecuteScalar());

                lend = Convert.ToDouble(commandprofitlend.ExecuteScalar());

                totalprofit = shop + lend;

                
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
    }
}
