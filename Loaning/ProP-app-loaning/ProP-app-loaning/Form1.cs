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

namespace ProP_app_loaning
{
    public partial class Form1 : Form
    {
        //fields
        private Visitor visitor;
        private RFID myRFIDReader;
        private DataHelper myDataHelper;
        private List<ItemsForLoan> myList;
        private List<ItemsForLoan> myReturnList;

        //initializing the form
        public Form1()
        {
            InitializeComponent();
            myDataHelper = new DataHelper();
            myList = myDataHelper.GetAllItems();

            //connecting with the RFID-reader
            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Attach += new AttachEventHandler(ShowWhoIsAttached);
                myRFIDReader.Detach += new DetachEventHandler(ShowWhoIsDetached);
                myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);
                myRFIDReader.open();
                myRFIDReader.waitForAttachment(3000);
                myRFIDReader.Antenna = true;
                myRFIDReader.LED = true;
            }
            catch (PhidgetException)
            {
                MessageBox.Show("Error while connecting with the RFID-reader");
            }
        }

        //variables
        double itemDeposit = 0;
        double totalLoaningFee = 0;
        double total = 0;
        string tag;
        DateTime timeReturned;

        //2 methods for declaring the attached rfid-reader
        private void ShowWhoIsAttached(object sender, AttachEventArgs e)
        {
            this.Text = "RFIDReader attached, serial nr: " + e.Device.SerialNumber.ToString();
        }

        private void ShowWhoIsDetached(object sender, DetachEventArgs e)
        {
            this.Text = "RFIDReader detached";
        }

        //Checking visitor's info
        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            if (myDataHelper.GetInfoFromChipID(e.Tag) != null)
            {
                visitor = myDataHelper.GetInfoFromChipID(e.Tag);
                myReturnList = myDataHelper.GetItemsToReturn(e.Tag);
                foreach (ItemsForLoan item in myReturnList)
                {
                    listboxItemsToReturn.Items.Add(item.ToString() + " / " + item.TimeBorrowed);
                }
                lbBalance.Text = "Balance: " + visitor.Balance.ToString() + " euro";
                lbNotification.Text = "Welcome, " + visitor.Name;
                this.BackColor = System.Drawing.Color.BlueViolet;
                tag = e.Tag;
            }
            else
            {
                listboxItemsToLoan.Items.Clear();
                listboxItemsToReturn.Items.Clear();
                lbNotification.Text = "There is no information about this user!";
                total = 0;
                lbTotal.Text = total.ToString() + " euro";
                lbBalance.Text = "Balance:";
                lbInfo.Text = "Item:";
                this.BackColor = System.Drawing.Color.IndianRed;
                tag = null;
            }
        }

        //checking visitor's info through email (in case if the visitor loses his/her bracelet)
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if(tbEmail.Text == "")
            {
                MessageBox.Show("Please first enter the email address");
            }
            else
            {
                if (myDataHelper.GetInfoFromEmail(tbEmail.Text) != null)
                {
                    visitor = myDataHelper.GetInfoFromEmail(tbEmail.Text);
                    myReturnList = myDataHelper.GetItemsToReturn(myDataHelper.GetChipIdFromEmail(tbEmail.Text));
                    foreach (ItemsForLoan item in myReturnList)
                    {
                        listboxItemsToReturn.Items.Add(item.ToString() + " / " + item.TimeBorrowed);
                    }
                    lbBalance.Text = "Balance: " + visitor.Balance.ToString() + " euro";
                    lbNotification.Text = "Welcome, " + visitor.Name;
                    this.BackColor = System.Drawing.Color.BlueViolet;
                    tag = myDataHelper.GetChipIdFromEmail(tbEmail.Text);
                }
                else
                {
                    listboxItemsToLoan.Items.Clear();
                    listboxItemsToReturn.Items.Clear();
                    lbNotification.Text = "There is no information about this user!";
                    total = 0;
                    lbTotal.Text = total.ToString() + " euro";
                    lbBalance.Text = "Balance:";
                    lbInfo.Text = "Item:";
                    this.BackColor = System.Drawing.Color.IndianRed;
                    tag = null;
                }
            }
        }

        //Items general info
        private void ShowItemInfo(object sender, EventArgs e)
        {            
                if(((Button)sender).Text == "Camera")
                {
                    itemDeposit = 30;
                    lbInfo.Text = "Item: " + ((Button)sender).Text + " - Deposit: 30 - Price per hour: 4";
                }
                else if (((Button)sender).Text == "Camera battery")
                {
                    itemDeposit = 6;
                    lbInfo.Text = "Item: " + ((Button)sender).Text + " - Deposit: 6 - Price per hour: 1.5";
                }
                else if (((Button)sender).Text == "Headphones")
                {
                    itemDeposit = 4;
                    lbInfo.Text = "Item: " + ((Button)sender).Text + " - Deposit: 4 - Price per hour: 1.5";
                }
                else if (((Button)sender).Text == "iPhone charger")
                {
                    itemDeposit = 5;
                    lbInfo.Text = "Item: " + ((Button)sender).Text + " - Deposit: 5 - Price per hour: 2";
                }
                else if (((Button)sender).Text == "Laptop charger")
                {
                    itemDeposit = 6;
                    lbInfo.Text = "Item: " + ((Button)sender).Text + " - Deposit: 6 - Price per hour: 3";
                }
                else if (((Button)sender).Text == "Samsung charger")
                {
                    itemDeposit = 4;
                    lbInfo.Text = "Item: " + ((Button)sender).Text + " - Deposit: 4 - Price per hour: 1.5";
                }
                else if (((Button)sender).Text == "Tripod")
                {
                    itemDeposit = 10;
                    lbInfo.Text = "Item: " + ((Button)sender).Text + " - Deposit: 10 - Price per hour: 4";
                }
                else if (((Button)sender).Text == "Umbrella")
                {
                    itemDeposit = 1;
                    lbInfo.Text = "Item: " + ((Button)sender).Text + " - Deposit: 1 - Price per hour: 0.5";
                }
                else if (((Button)sender).Text == "USB (10GB)")
                {
                    itemDeposit = 3;
                    lbInfo.Text = "Item: " + ((Button)sender).Text + " - Deposit: 3 - Price per hour: 1.5";
                }
        }
        
        //event clicking on item respectively
        private void btnItemCamera_Click(object sender, EventArgs e)
        {
            if (lbNotification.Text == "Welcome," || lbNotification.Text == "There is no information about this user!")
            {
                MessageBox.Show("Please first scan the bracelet code of an user");
            }
            else
            {
                ShowItemInfo(sender, e);
                int i = 0;
                foreach (ItemsForLoan item in myList)
                {
                    if (i < 1)
                    {
                        if (item.Name == "Camera")
                        {
                            if (!listboxItemsToLoan.Items.Contains(item.ToString()))
                            {
                                listboxItemsToLoan.Items.Add(item.ToString());
                                i++;
                                total += itemDeposit;
                                lbTotal.Text = total.ToString() + " euro";
                            }
                        }
                    }
                }
                if (i == 0)
                {
                    MessageBox.Show("No more camera available");
                }
            }
        }

        private void btnItemCameraBt_Click(object sender, EventArgs e)
        {
            if (lbNotification.Text == "Welcome," || lbNotification.Text == "There is no information about this user!")
            {
                MessageBox.Show("Please first scan the bracelet code of an user");
            }
            else
            {
                ShowItemInfo(sender, e);
                int i = 0;
                foreach (ItemsForLoan item in myList)
                {
                    if (i < 1)
                    {
                        if (item.Name == "Camera battery")
                        {
                            if (!listboxItemsToLoan.Items.Contains(item.ToString()))
                            {
                                listboxItemsToLoan.Items.Add(item.ToString());
                                i++;
                                total += itemDeposit;
                                lbTotal.Text = total.ToString() + " euro";
                            }
                        }
                    }
                }
                if (i == 0)
                {
                    MessageBox.Show("No more camera battery available");
                }
            }
        }

        private void btnItemHeadphones_Click(object sender, EventArgs e)
        {
            if (lbNotification.Text == "Welcome," || lbNotification.Text == "There is no information about this user!")
            {
                MessageBox.Show("Please first scan the bracelet code of an user");
            }
            else
            {
                ShowItemInfo(sender, e);
                int i = 0;
                foreach (ItemsForLoan item in myList)
                {
                    if (i < 1)
                    {
                        if (item.Name == "Headphones")
                        {
                            if (!listboxItemsToLoan.Items.Contains(item.ToString()))
                            {
                                listboxItemsToLoan.Items.Add(item.ToString());
                                i++;
                                total += itemDeposit;
                                lbTotal.Text = total.ToString() + " euro";
                            }
                        }
                    }
                }
                if (i == 0)
                {
                    MessageBox.Show("No more headphones available");
                }
            }
        }

        private void btnItemIPhoneCharger_Click(object sender, EventArgs e)
        {
            if (lbNotification.Text == "Welcome," || lbNotification.Text == "There is no information about this user!")
            {
                MessageBox.Show("Please first scan the bracelet code of an user");
            }
            else
            {
                ShowItemInfo(sender, e);
                int i = 0;
                foreach (ItemsForLoan item in myList)
                {
                    if (i < 1)
                    {
                        if (item.Name == "iPhone charger")
                        {
                            if (!listboxItemsToLoan.Items.Contains(item.ToString()))
                            {
                                listboxItemsToLoan.Items.Add(item.ToString());
                                i++;
                                total += itemDeposit;
                                lbTotal.Text = total.ToString() + " euro";
                            }
                        }
                    }
                }
                if (i == 0)
                {
                    MessageBox.Show("No more iPhone charger available");
                }
            }
        }

        private void btnItemLaptopCharger_Click(object sender, EventArgs e)
        {
            if (lbNotification.Text == "Welcome," || lbNotification.Text == "There is no information about this user!")
            {
                MessageBox.Show("Please first scan the bracelet code of an user");
            }
            else
            {
                ShowItemInfo(sender, e);
                int i = 0;
                foreach (ItemsForLoan item in myList)
                {
                    if (i < 1)
                    {
                        if (item.Name == "Laptop charger")
                        {
                            if (!listboxItemsToLoan.Items.Contains(item.ToString()))
                            {
                                listboxItemsToLoan.Items.Add(item.ToString());
                                i++;
                                total += itemDeposit;
                                lbTotal.Text = total.ToString() + " euro";
                            }
                        }
                    }
                }
                if (i == 0)
                {
                    MessageBox.Show("No more laptop charger available");
                }
            }
        }

        private void btnItemSamsungCharger_Click(object sender, EventArgs e)
        {
            if (lbNotification.Text == "Welcome," || lbNotification.Text == "There is no information about this user!")
            {
                MessageBox.Show("Please first scan the bracelet code of an user");
            }
            else
            {
                ShowItemInfo(sender, e);
                int i = 0;
                foreach (ItemsForLoan item in myList)
                {
                    if (i < 1)
                    {
                        if (item.Name == "Samsung charger")
                        {
                            if (!listboxItemsToLoan.Items.Contains(item.ToString()))
                            {
                                listboxItemsToLoan.Items.Add(item.ToString());
                                i++;
                                total += itemDeposit;
                                lbTotal.Text = total.ToString() + " euro";
                            }
                        }
                    }
                }
                if (i == 0)
                {
                    MessageBox.Show("No more Samsung charger available");
                }
            }
        }

        private void btnItemTripod_Click(object sender, EventArgs e)
        {
            if (lbNotification.Text == "Welcome," || lbNotification.Text == "There is no information about this user!")
            {
                MessageBox.Show("Please first scan the bracelet code of an user");
            }
            else
            {
                ShowItemInfo(sender, e);
                int i = 0;
                foreach (ItemsForLoan item in myList)
                {
                    if (i < 1)
                    {
                        if (item.Name == "Tripod")
                        {
                            if (!listboxItemsToLoan.Items.Contains(item.ToString()))
                            {
                                listboxItemsToLoan.Items.Add(item.ToString());
                                i++;
                                total += itemDeposit;
                                lbTotal.Text = total.ToString() + " euro";
                            }
                        }
                    }
                }
                if (i == 0)
                {
                    MessageBox.Show("No more tripod available");
                }
            }
        }

        private void btnItemUmbrella_Click(object sender, EventArgs e)
        {
            if (lbNotification.Text == "Welcome," || lbNotification.Text == "There is no information about this user!")
            {
                MessageBox.Show("Please first scan the bracelet code of an user");
            }
            else
            {
                ShowItemInfo(sender, e);
                int i = 0;
                foreach (ItemsForLoan item in myList)
                {
                    if (i < 1)
                    {
                        if (item.Name == "Umbrella")
                        {
                            if (!listboxItemsToLoan.Items.Contains(item.ToString()))
                            {
                                listboxItemsToLoan.Items.Add(item.ToString());
                                i++;
                                total += itemDeposit;
                                lbTotal.Text = total.ToString() + " euro";
                            }
                        }
                    }
                }
                if (i == 0)
                {
                    MessageBox.Show("No more umbrella available");
                }
            }
        }

        private void btnItemUSB_Click(object sender, EventArgs e)
        {
            if (lbNotification.Text == "Welcome," || lbNotification.Text == "There is no information about this user!")
            {
                MessageBox.Show("Please first scan the bracelet code of an user");
            }
            else
            {
                ShowItemInfo(sender, e);
                int i = 0;
                foreach (ItemsForLoan item in myList)
                {
                    if (i < 1)
                    {
                        if (item.Name == "USB (10GB)")
                        {
                            if (!listboxItemsToLoan.Items.Contains(item.ToString()))
                            {
                                listboxItemsToLoan.Items.Add(item.ToString());
                                i++;
                                total += itemDeposit;
                                lbTotal.Text = total.ToString() + " euro";
                            }
                        }
                    }
                }
                if (i == 0)
                {
                    MessageBox.Show("No more USB available");
                }
            }
        }

        //removing items from the listbox ItemsToBeLoaned
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listboxItemsToLoan.SelectedItem != null)
            {
                string[] s = listboxItemsToLoan.SelectedItem.ToString().Split(Convert.ToChar("/"));
                double getDeposit;
                Double.TryParse(s[2], out getDeposit);
                total -= getDeposit;
                listboxItemsToLoan.Items.Remove(listboxItemsToLoan.SelectedItem);
                lbTotal.Text = total.ToString() + " euro";
            }
            else
            {
                MessageBox.Show("Please first select an item from the list");
            }
        }

        //removing ALL items from the listbox ItemsToBeLoaned
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(listboxItemsToLoan.Items.Count != 0)
            {
                total = 0;
                lbTotal.Text = total.ToString() + " euro";
                lbInfo.Text = "Item:";
                listboxItemsToLoan.Items.Clear();
            }
            else
            {
                MessageBox.Show("There is no item in the list");
            }
        }

        //Confirming the transaction
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (lbNotification.Text == "Welcome," || lbNotification.Text == "There is no information about this user!")
            {
                MessageBox.Show("Please first scan the bracelet code of an user");
            }
            else
            {
                if (myDataHelper.GetUpdatedBalance(tag) > total)
                {
                    myDataHelper.AddLendingTransactionInfo(tag);
                    foreach (var item in listboxItemsToLoan.Items)
                    {
                        string[] s = item.ToString().Split(Convert.ToChar("/"));
                        myDataHelper.AddLendingLineTransactionInfo(myDataHelper.GetLendingId(), Convert.ToInt32(s[0]), DateTime.Now);
                    }
                    myDataHelper.UpdateBalance(myDataHelper.GetUpdatedBalance(tag) - total, tag);
                    myDataHelper.UpdateItemInfo();
                    MessageBox.Show("Transaction completed!");
                    myReturnList = myDataHelper.GetItemsToReturn(tag);
                    myList = myDataHelper.GetAllItems();
                    listboxItemsToLoan.Items.Clear();
                    listboxItemsToReturn.Items.Clear();
                    foreach (ItemsForLoan item in myReturnList)
                    {
                        listboxItemsToReturn.Items.Add(item.ToString() + " / " + item.TimeBorrowed);
                    }
                    total = 0;
                    lbTotal.Text = total.ToString() + " euro";
                    lbBalance.Text = "Balance: " + Convert.ToString(myDataHelper.GetUpdatedBalance(tag)) + " euro";
                    lbInfo.Text = "Item:";
                }
                else
                {
                    MessageBox.Show("Your account balance is not enough for this transaction");
                }
            }          
        }

        //return items + removing items from the listbox ItemsToBeReturned
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (listboxItemsToReturn.SelectedItem != null)
            {
                string[] s = listboxItemsToReturn.SelectedItem.ToString().Split(Convert.ToChar("/"));
                DateTime timeBorrowed;
                double getPriceHour;
                double LoaningFee;
                DateTime.TryParse(s[4], out timeBorrowed);
                Double.TryParse(s[3], out getPriceHour);
                LoaningFee = Math.Round((DateTime.Now - timeBorrowed).TotalHours * getPriceHour);
                totalLoaningFee += LoaningFee;
                timeReturned = DateTime.Now;
                if(myDataHelper.GetUpdatedBalance(tag) > LoaningFee)
                {
                    myDataHelper.ReturnItems(timeReturned, Convert.ToInt32(s[0]));
                    myDataHelper.UpdateBalance(myDataHelper.GetUpdatedBalance(tag) - LoaningFee, tag);
                    MessageBox.Show("You have returned item: " + s[1] + ", item-id: " + s[0] + ", loaning fee (automatically charged to your account): " + LoaningFee + " euro");
                    lbBalance.Text = "Balance: " + Convert.ToString(myDataHelper.GetUpdatedBalance(tag)) + " euro";
                    listboxItemsToReturn.Items.Remove(listboxItemsToReturn.SelectedItem);
                    myList = myDataHelper.GetAllItems();
                }
                else
                {
                    MessageBox.Show("Your account balance is not enough for paying the loaning fee of this item: " + Convert.ToString(LoaningFee));
                }
            }
            else
            {
                MessageBox.Show("Please first select an item from the list");
            }
        }

        //Renew the app (for instance if you scan a visitor which is not allowed to the event, the background turn red -> click this button to get everything cleaned)
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BackColor = Control.DefaultBackColor;
            lbNotification.Text = "Welcome,";
            lbBalance.Text = "Balance:";
            lbInfo.Text = "Item:";
            listboxItemsToLoan.Items.Clear();
            listboxItemsToReturn.Items.Clear();
            total = 0;
            lbTotal.Text = total.ToString() + " euro";
            tag = null;
        }
    }
}
