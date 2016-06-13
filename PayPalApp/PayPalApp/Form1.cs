﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PayPalApp
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;

        public Form1()
        {
            InitializeComponent();

            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi338468;" +
                                    "user id=dbi338468;" +
                                    "password=Xm6y5xuH99;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            //Introducing in the db
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                StreamReader sr = null;
                PaymentObject payment = null;
                

                try
                {
                    fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                    sr = new StreamReader(fs);


                    String bankaccount = sr.ReadLine();
                    DateTime start = DateTime.ParseExact(sr.ReadLine(), "yyyy/MM/dd/HH:mm:ss", provider);
                    DateTime end = DateTime.ParseExact(sr.ReadLine(), "yyyy/MM/dd/HH:mm:ss", provider);
                    int nrOfDeposits=Convert.ToInt32(sr.ReadLine());
                    int count=0;

                    String line=sr.ReadLine();
                    String[] numbers;

                    while (line!= null)
                    {
                        count++;
                        numbers = line.Split(' ');
                        payment = new PaymentObject(bankaccount, start, end, nrOfDeposits, Convert.ToInt32(numbers[0]), Convert.ToDouble(numbers[1]));
                        InsertingPaymentData(payment);
                        line = sr.ReadLine();

                    }

                    listBox1.Items.Add("*****!!!!There were " + count+ " records successfully added!!!!*****");

                }
                catch (IOException)
                {
                    listBox1.Items.Add("Something went wrong with getting the pay-list from the logfile.");
                }
                finally
                {
                    if (sr != null) sr.Close();
                    if (fs != null) fs.Close();
                }
            }
        }
        public void InsertingPaymentData(PaymentObject obj)
        {
            String sql = "insert into payment (`id`,`money`,`no_deposits`,`start_period`,`end_period`,`bank_account`) values(" + obj.Id + "," + obj.Money + "," + obj.NrOfDeposits+",'" + obj.Start.ToString("yyyy-MM-dd HH:mm:ss") + "','" + obj.End.ToString("yyyy-MM-dd HH:mm:ss") + "'," + obj.BankAccount + ");";
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                int c=command.ExecuteNonQuery();

            }
            catch
            {
                listBox1.Items.Add("Error while inserting the records in the database");
            }
            finally
            {           
                connection.Close();
            }
        }
    }
}