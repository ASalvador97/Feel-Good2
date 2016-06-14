using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Phidgets;
using Phidgets.Events;

namespace PROP_leaving_event
{
    public partial class Form1 : Form
    {
        DataHelper mydatahelper = new DataHelper();
        private RFID myRFIDReader;
        
       
        public Form1()
        {
            InitializeComponent();
            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);

                myRFIDReader.open();
                myRFIDReader.waitForAttachment(3000);
                myRFIDReader.Antenna = true;
                myRFIDReader.LED = true;
                lbStatus.Text = "READY TO GO";
            }
            catch (PhidgetException) { lbStatus.Text = "ERROR AT STARTUP"; }
        }

        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            Visitor v = null;
            this.lbInfo.Items.Clear();
            this.lbsuccess.Text = "-";
           
            try
            {
                    v = mydatahelper.GetVisitorViaChip(e.Tag);
                    
                    if (v == null) 
                    {
                        this.panel1.BackColor = Color.Lavender;
                        lbStatus.Text = "visitor doesnt exist";
                        lbemail.Text = "";

                    }
                    else
                    {
                        lbemail.Text = v.Email;

                        foreach (string s in mydatahelper.GetGoods(v.ChipId))
                        {
                            this.lbInfo.Items.Add(s);
                        }

                        if (lbInfo.Items.Count == 0)
                        {
                            panel1.BackColor = Color.LawnGreen;
                            this.lbStatus.Text = "NOTHING TO DECLARE";
                            try
                            {
                                mydatahelper.UpdateExitStatus(v.ChipId);
                                lbsuccess.Text = "success";
                            }
                            catch { lbsuccess.Text = "failed"; }

                        }
                        else
                        {
                            panel1.BackColor = Color.Red;
                            this.lbStatus.Text = "NEEDS TO RETURN ITEMS";
                        }
                    }

                   
               
            }
            catch (NullReferenceException)
            {
                lbStatus.Text = "NO VISITOR SELECTED";
            }
            catch
            {
                
                this.lbStatus.Text = "SOMETHING IS WRONG";
            }
            
        
        }
       
        private void btCheckviaemail_Click(object sender, EventArgs e)
        {
            Visitor v = null;
            this.lbInfo.Items.Clear();
            this.lbsuccess.Text = "-";
        
            //this.lbStatus.Text = "ready";
            //this.panel1.BackColor = Color.Lavender;
            try
            {
                 
                if (tbChipOrEmail.Text != "")
                {
                    v = mydatahelper.GetVisitorViaEmail(tbChipOrEmail.Text);
                    
                    if (v == null) 
                    {
                        this.panel1.BackColor = Color.Lavender;
                        lbStatus.Text = "visitor doesnt exist";
                        lbemail.Text = "";

                    }
                    else
                    {
                        lbemail.Text = v.Email;

                        foreach (string s in mydatahelper.GetGoods(v.ChipId))
                        {
                            this.lbInfo.Items.Add(s);
                        }

                        if (lbInfo.Items.Count == 0)
                        {
                            panel1.BackColor = Color.LawnGreen;
                            this.lbStatus.Text = "NOTHING TO DECLARE";
                            try { mydatahelper.UpdateExitStatus(v.ChipId);
                            lbsuccess.Text = "success";
                            }
                            catch { lbsuccess.Text = "failed"; }

                        }
                        else
                        {
                            panel1.BackColor = Color.Red;
                            this.lbStatus.Text = "NEEDS TO RETURN ITEMS";
                        }
                    }

                   

                }
                    
                else 
                {
                    MessageBox.Show("Please enter e-mail first");
                }
                this.tbChipOrEmail.Text = "";
               
            }
            catch
            {
                
                this.lbStatus.Text = "SOMETHING IS WRONG";
            }
            
        }
    }
}
