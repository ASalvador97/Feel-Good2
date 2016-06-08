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
        private CampInfo camp;

        public Form1()
        {
            InitializeComponent();
            camp = new CampInfo();

            try
            {
                myRFIDReader = new RFID();
                //myRFIDReader.Attach += new AttachEventHandler(ShowWhoIsAttached);
                //myRFIDReader.Detach += new DetachEventHandler(ShowWhoIsDetached);
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
            catch(DllNotFoundException)
            {
                MessageBox.Show("No device connected or the dll is wrong!");
            }
        }

        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            CampSpot spot=camp.CampingInfo(e.Tag);

            if (spot != null)
            {
                timer1.Enabled = true;
                lbName.Text = spot.Lname + " " + spot.Fname;
                lbEmail.Text = spot.Email;
                lbSpot.Text = spot.Spot.ToString();
            }
            else
            {
                timer2.Enabled = true;
                lbName.Text = "-";
                lbEmail.Text = "-";
                lbSpot.Text = "-";
                label1.Text = "YES/NO";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.BackColor = Color.AliceBlue;
            label1.Text = "YES";
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Red;
            label1.Text = "NO";
            timer2.Enabled = false;
        }

    }
}
