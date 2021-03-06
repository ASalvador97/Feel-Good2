﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;


namespace CampingEntrance
{
    public partial class Form1 : Form
    {
        private RFID myRFIDReader;
        private CampInfo camp;
        private static System.Timers.Timer aTimer;
        public Form1()
        {
            InitializeComponent();
            camp = new CampInfo();
            aTimer = new System.Timers.Timer(2000);

            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);

            }
            catch (PhidgetException)
            {
                MessageBox.Show("No RFID opened!");
            }
            catch (DllNotFoundException)
            {
                MessageBox.Show("No device connected or the dll is wrong!");
            }
        }
        
        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            CampSpot spot = camp.CampingInfo(e.Tag);
            

            if (spot != null)
            {
                panel1.BackColor = Color.Green;
                label1.Text = "YES";
                lbName.Text = spot.Lname + " " + spot.Fname;
                lbEmail.Text = spot.Email;
                lbSpot.Text = spot.Spot.ToString();
            }
            else
            {
                panel1.BackColor = Color.Red;
                label1.Text = "NO";
                lbName.Text = "-";
                lbEmail.Text = "-";
                lbSpot.Text = "-";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                myRFIDReader.open();

                myRFIDReader.waitForAttachment(3000);

                MessageBox.Show("RFID opened.");

                myRFIDReader.Antenna = true;
                myRFIDReader.LED = true;
            }
            catch (PhidgetException)
            {
                MessageBox.Show("error at start-up.");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            myRFIDReader.LED = false;
            myRFIDReader.Antenna = false;
            myRFIDReader.close();
        }

    }
}
