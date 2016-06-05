using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

namespace ProP_app_campingentrance
{
    public partial class Form1 : Form
    {
        private RFID myRFIDReader;
        private DataHelper myDataHelper;
        public Form1()
        {
            InitializeComponent();
            myDataHelper = new DataHelper();
            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Attach += new AttachEventHandler(ShowWhoIsAttached);
                myRFIDReader.Detach += new DetachEventHandler(ShowWhoIsDetached);
                myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);
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
            

            private void ProcessThisTag(object sender, TagEventArgs e)
        {
            if (myDataHelper.GetInfoFromChipID(e.Tag) != null)
            {
                lbName.Text = myDataHelper.GetInfoFromChipID(e.Tag).Name.ToString();
                lbEmail.Text = myDataHelper.GetInfoFromChipID(e.Tag).Email;
                lbCampingReg.Text = myDataHelper.GetInfoFromChipID(e.Tag).Registration;
                lbSpot.Text = myDataHelper.GetInfoFromChipID(e.Tag).Spot;

                this.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                lbName.Text = "There is no information about this user!";
                lbEmail.Text = "";
                lbCampingReg.Text = "";
                lbSpot.Text = "";

                this.BackColor = System.Drawing.Color.Red;
            }

        }

    }
    }

