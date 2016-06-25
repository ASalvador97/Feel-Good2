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

namespace ProP_app_entrance
{
    public partial class Form1 : Form
    {
        DataHelper mydatahelper;
        Visitor v;
        private RFID myRFIDReader;
        public Form1()
        {
            mydatahelper = new DataHelper();
            InitializeComponent();
            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);

                myRFIDReader.open();
                myRFIDReader.waitForAttachment(3000);
                myRFIDReader.Antenna = true;
                myRFIDReader.LED = true;
                lbtag.Text = "READY TO GO";
            }
            catch (PhidgetException) { lbtag.Text = "ERROR AT STARTUP"; }
           
        }

        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            try
            {
                if (mydatahelper.SyncBracelet(e.Tag, v.Email, Convert.ToString(1), "N"))
                {
                    this.panel1.BackColor = Color.Lavender;
                    this.lbBracelet.Text = "";
                    this.tbBraceletCode.Text = "";
                        this.lbbarcode.Text = v.Barcode;
                    this.lbBracelet.Text = e.Tag;
                    lbtag.Text = "SUCCESS";
                    this.tbBarcode.Text = "";

                }
                else
                {
                    this.panel1.BackColor = Color.IndianRed;
                    lbtag.Text = "ERROR";
                }
            }
            catch(NullReferenceException)
            {
                lbtag.Text = "NO VISITOR SELECTED";
            }
        }
        private void tbBraceletcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // timer1.Enabled = true;
            try
            {
                bool check = mydatahelper.CheckBarcode(tbBarcode.Text);
                if (check)
                {
                    v = mydatahelper.GetVisitor(tbBarcode.Text);

                    this.lbName.Text = v.Fname + " " + v.Lname;
                    this.lbEmail.Text = v.Email;
                    this.lbphone.Text = v.Phone;
                    this.lbbarcode.Text = v.Barcode;
                    this.lbtag.Text = "READY";
                    this.tbBraceletCode.Text = "";

                    if (v.Campspot != 0)
                    {
                        this.lbCamping.Text = "YES:  nr: " + v.Campspot;
                        this.panel1.BackColor = Color.Green;
                    }
                    if (v.Campspot == 0)
                    {
                        this.lbCamping.Text = "NO";
                        this.panel1.BackColor = Color.Blue;
                    }
                }
                else
                {
                    this.lbtag.Text = "WRONG BARCODE";
                    this.panel1.BackColor = Color.Red;
                    this.lbEmail.Text = "-";
                    this.lbName.Text = "-";
                    this.lbphone.Text = "-";
                    this.lbBracelet.Text = "-";
                    this.lbCamping.Text = "-";
                    this.lbbarcode.Text = "-";
                }
            }
           

            catch
            {
                this.panel1.BackColor = Color.Red;
                this.lbEmail.Text = "-";
                this.lbName.Text = "-";
                this.lbphone.Text = "-";
                this.lbBracelet.Text = "-";
                this.lbCamping.Text = "-";
                this.lbbarcode.Text = "-";

            }

        }

       // private void timer1_Tick(object sender, EventArgs e)
      //  {this.panel1.BackColor = Color.Lavender;
        //    this.timer1.Enabled = false; }

        private void btnSync_Click(object sender, EventArgs e)
        {
            if (
             mydatahelper.SyncBracelet(tbBraceletCode.Text, v.Email, Convert.ToString(1), "N") )
            {
                this.panel1.BackColor = Color.Lavender;
                this.lbBracelet.Text = tbBraceletCode.Text;
                this.lbtag.Text = "SUCCESS";
            }
            else
            {
                this.panel1.BackColor = Color.IndianRed;
                this.lbtag.Text = "ERROR";
            }


        }

       


        
    }
}
