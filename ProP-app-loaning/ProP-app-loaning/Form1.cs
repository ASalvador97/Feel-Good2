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
        private RFID myRFIDReader;
        private DataHelper myDataHelper;
        private List<ItemsForRent> itemList;
        private List<string> orderList;
        int countButton = 0;

        public Form1()
        {
            InitializeComponent();
            myDataHelper = new DataHelper();
            itemList = new List<ItemsForRent>();
            orderList = new List<string>();
            int widthOfAButton = 130, heightOfAButton = 70;
            int spaceBetweenButtons = 20;
            int x = 30; // (x,y) is the left-top of the button
            int y = 230;
            Font myFont = new Font("Verdana", 10);
            foreach (ItemsForRent item in myDataHelper.GetAllItems())
            {
                Button myButton;
                myButton = new Button();
                myButton.Location = new System.Drawing.Point(x, y);
                myButton.Size = new System.Drawing.Size(widthOfAButton, heightOfAButton);
                myButton.Text = item.Name;
                myButton.Font = myFont;
                myButton.Click += new EventHandler(ShowItemInfo);
                myButton.Tag = item;
                myButton.Enabled = false;
                this.Controls.Add(myButton);
                x = x + widthOfAButton + spaceBetweenButtons;
                countButton++;
                if (countButton % 3 == 0)
                {
                    x = 30;
                    y = y + heightOfAButton + spaceBetweenButtons;
                    myButton.Location = new System.Drawing.Point(x, y);
                    myButton.Size = new System.Drawing.Size(widthOfAButton, heightOfAButton);
                    myButton.Text = item.Name;
                    myButton.Font = myFont;
                    myButton.Click += new EventHandler(ShowItemInfo);
                    myButton.Tag = item;
                    this.Controls.Add(myButton);
                    x = x + widthOfAButton + spaceBetweenButtons;
                    countButton++;
                }
            }

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

        string itemName = null;
        double itemPrice = 0.00;
        double totalitemPrice = 0.00;
        double total = 0.00;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            totalitemPrice = itemPrice * Convert.ToDouble(numudQuantity.Value);
            total += totalitemPrice;
            if (itemName == null)
            {
                MessageBox.Show("Please choose a product first");
            }
            else
            {
                listboxPurchasingItems.Items.Add("Item: " + itemName + " - Quantity: " + numudQuantity.Value);
                lbTotal.Text = total.ToString() + " euro";
                orderList.Add(itemName);
            }
        }

        private void ShowWhoIsAttached(object sender, AttachEventArgs e)
        {
            this.Text = "RFIDReader attached, serial nr: " + e.Device.SerialNumber.ToString();
        }

        private void ShowWhoIsDetached(object sender, DetachEventArgs e)
        {
            this.Text = "RFIDReader detached";
        }

        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            if (myDataHelper.GetInfoFromChipID(e.Tag) != null)
            {
                lbBalance.Text = "Balance: " + myDataHelper.GetInfoFromChipID(e.Tag).Balance.ToString();
                lbNotification.Text = "Welcome, Mr/Mrs " + myDataHelper.GetInfoFromChipID(e.Tag).Name;
                this.BackColor = System.Drawing.Color.BlueViolet;
                foreach (Control control in Controls)
                {
                    control.Enabled = true;
                }
            }
            else
            {
                lbNotification.Text = "There is no information about this user!";
                this.BackColor = System.Drawing.Color.IndianRed;
                lbBalance.Text = "Balance: ";
            }

        }

        private void ShowItemInfo(object sender, EventArgs e)
        {
            numudQuantity.Value = 1;
            lbInfo.Text = "Item: " + ((Button)sender).Text + " - " + ((ItemsForRent)(((Button)sender).Tag)).Price + " euro";
            itemPrice = ((ItemsForRent)(((Button)sender).Tag)).Price;
            itemName = ((Button)sender).Text;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            listboxPurchasingItems.Items.Remove(listboxPurchasingItems.SelectedItem);
            total -= itemPrice;
            lbTotal.Text = total.ToString() + " euro";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listboxPurchasingItems_SelectedItemChanged(object sender, EventArgs e)
        {
            itemPrice = ((ItemsForRent)(((ListBox)sender).Tag)).Price;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            total = 0;
            lbTotal.Text = total.ToString() + " euro";
            lbInfo.Text = "Item:";
            numudQuantity.Value = 1;
            listboxPurchasingItems.Items.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BackColor = Control.DefaultBackColor;
            lbNotification.Text = "Welcome,";
            lbBalance.Text = "Balance:";
        }

        //private void SelectedItemInfo(object sender, EventArgs e)
        //{
        //    numudQuantity.Value = 1;
        //    lbInfo.Text = "Item: " + ((Button)sender).Text + " - " + ((ItemsForRent)(((Button)sender).Tag)).Price + " euro";
        //    itemPrice = ((ItemsForRent)(((Button)sender).Tag)).Price;
        //    itemName = ((Button)sender).Text;
        //    (listboxPurchasingItems.SelectedItem).
        //}
    }
}
