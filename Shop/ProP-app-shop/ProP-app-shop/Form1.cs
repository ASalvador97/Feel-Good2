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

namespace ProP_app_shop
{
    public partial class Form1: Form
    {
        //fields
        private Visitor visitor;
        private RFID myRFIDReader;
        private DataHelper myDataHelper;
        private List<ItemsForSale> itemList;

        //initializing the form
        public Form1()
        {
            InitializeComponent();
            myDataHelper = new DataHelper();
            itemList = new List<ItemsForSale>();

            //converting items from database to buttons
            int countButton = 0;
            int widthOfAButton = 169, heightOfAButton = 106;
            int spaceBetweenButtons = 50;
            int x = 850;
            int y = 130;
            Font myFont = new Font("Verdana", 10);
            foreach (ItemsForSale item in myDataHelper.GetAllItems())
            {
                Button myButton;
                myButton = new Button();
                myButton.Location = new System.Drawing.Point(x, y);
                myButton.Size = new System.Drawing.Size(widthOfAButton, heightOfAButton);
                myButton.Text = item.Name;
                myButton.Font = myFont;
                myButton.Click += new EventHandler(ShowItemInfo);
                myButton.Tag = item;
                this.Controls.Add(myButton);
                x = x + widthOfAButton + spaceBetweenButtons;
                countButton++;
                if (countButton % 4 == 0)
                {
                    x = 850;
                    y = y + heightOfAButton + spaceBetweenButtons;
                    myButton.Location = new System.Drawing.Point(x, y);
                    myButton.Size = new System.Drawing.Size(widthOfAButton, heightOfAButton);
                    myButton.Text = item.Name;
                    myButton.Font = myFont;
                    myButton.Tag = item;
                    this.Controls.Add(myButton);
                    x = x + widthOfAButton + spaceBetweenButtons;
                    countButton++;
                }
            }

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
        string itemName = null;
        double itemPrice = 0;
        double totalitemPrice = 0;
        double total = 0;
        string tag;

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
                lbBalance.Text = "Balance: " + visitor.Balance.ToString() + " euro";
                lbNotification.Text = "Welcome, " + visitor.Name;
                this.BackColor = System.Drawing.Color.BlueViolet;
                tag = e.Tag;
            }
            else
            {
                listboxItems.Items.Clear();
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
            if (myDataHelper.GetInfoFromEmail(tbEmail.Text) != null)
            {
                visitor = myDataHelper.GetInfoFromEmail(tbEmail.Text);
                lbBalance.Text = "Balance: " + visitor.Balance.ToString() + " euro";
                lbNotification.Text = "Welcome, " + visitor.Name;
                this.BackColor = System.Drawing.Color.BlueViolet;
                tag = myDataHelper.GetChipIdFromEmail(tbEmail.Text);
            }
            else
            {
                listboxItems.Items.Clear();
                lbNotification.Text = "There is no information about this user!";
                total = 0;
                lbTotal.Text = total.ToString() + " euro";
                lbBalance.Text = "Balance:";
                lbInfo.Text = "Item:";
                this.BackColor = System.Drawing.Color.IndianRed;
                tag = null;
            }
        }

        //items general info
        private void ShowItemInfo(object sender, EventArgs e)
        {
            if (lbNotification.Text == "Welcome," || lbNotification.Text == "There is no information about this user!")
            {
                MessageBox.Show("Please first scan the bracelet code of an user");
            }
            else
            {
                numudQuantity.Value = 1;
                lbInfo.Text = "Item: " + ((Button)sender).Text + " - " + ((ItemsForSale)(((Button)sender).Tag)).Price + " euro";
                itemPrice = ((ItemsForSale)(((Button)sender).Tag)).Price;
                itemName = ((Button)sender).Text;

            }
        }

        //add an item to the listbox
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbNotification.Text == "Welcome," || lbNotification.Text == "There is no information about this user!")
            {
                MessageBox.Show("Please first scan the bracelet code of an user");
            }
            else
            {
                if (numudQuantity.Value <= myDataHelper.GetInStock(myDataHelper.GetProductId(itemName)))
                {
                    totalitemPrice = itemPrice * Convert.ToDouble(numudQuantity.Value);
                    total += totalitemPrice;
                    if (itemName == null)
                    {
                        MessageBox.Show("Please choose a product first");
                    }
                    else
                    {
                        listboxItems.Items.Add(myDataHelper.GetProductId(itemName) + " - " + itemName + " - " + numudQuantity.Value + " - " + totalitemPrice);
                        lbTotal.Text = total.ToString() + " euro";
                        lbInfo.Text = "Item:";
                        numudQuantity.Value = 1;
                    }
                }
                else
                {
                    MessageBox.Show("There are only " + myDataHelper.GetInStock(myDataHelper.GetProductId(itemName)) + " " + itemName + " left in stock");
                    numudQuantity.Value = 1;
                    lbInfo.Text = "Item:";
                }
            }
        }

        //remove an item from the listbox
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listboxItems.SelectedItem != null)
            {
                string[] s = listboxItems.SelectedItem.ToString().Split(Convert.ToChar("-"));
                double getTotalItemPrice;
                Double.TryParse(s[3], out getTotalItemPrice);
                total -= getTotalItemPrice;
                listboxItems.Items.Remove(listboxItems.SelectedItem);
                lbTotal.Text = total.ToString() + " euro";
            }
            else
            {
                MessageBox.Show("Please first select an item from the list");
            }
        }

        //removing all items from the listbox
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (listboxItems.Items.Count != 0)
            {
                total = 0;
                lbTotal.Text = total.ToString() + " euro";
                lbInfo.Text = "Item:";
                listboxItems.Items.Clear();
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
                    myDataHelper.AddShopTransactionInfo(tag);
                    foreach (var item in listboxItems.Items)
                    {
                        string[] s = item.ToString().Split(Convert.ToChar("-"));
                        myDataHelper.AddShopLineTransactionInfo(Convert.ToInt32(s[0]), myDataHelper.GetShopOrderId(), Convert.ToInt32(s[2]));
                        myDataHelper.UpdateInStock(myDataHelper.GetInStock(Convert.ToInt32(s[0])) - Convert.ToInt32(s[2]), Convert.ToInt32(s[0]));
                    }
                    myDataHelper.UpdateBalance(myDataHelper.GetUpdatedBalance(tag) - total, tag);
                    MessageBox.Show("Transaction completed!");
                    itemList = myDataHelper.GetAllItems();
                    listboxItems.Items.Clear();
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

        //Renew the app (for instance if you scan a visitor which is not allowed to the event, the background turn red -> click this button to get everything cleaned)
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BackColor = Control.DefaultBackColor;
            lbNotification.Text = "Welcome,";
            lbBalance.Text = "Balance:";
            lbInfo.Text = "Item:";
            listboxItems.Items.Clear();
            total = 0;
            lbTotal.Text = total.ToString() + " euro";
            tag = null;
        }
    }
}
