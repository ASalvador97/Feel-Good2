using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StatusApp
{
    public partial class Form1 : Form
    {
        private General gen;
        private Client_Info client;
        private Camping_Availability camp;
        private ShopAndLending market;
        public Form1()
        {
            InitializeComponent();
            gen = new General();
            client = new Client_Info();
            camp = new Camping_Availability();
            market = new ShopAndLending();



            //shops and lending
            foreach (ShopProduct s in market.ShopItems())
            {
                comboBox1.Items.Add(s);
                comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            }

            foreach (LendingItem s in market.LendItems())
            {
                comboBox2.Items.Add(s);
                comboBox2.SelectedIndexChanged += new EventHandler(comboBox2_SelectedIndexChanged);
            }
        }

        private void btnLoadAllStudents_Click(object sender, EventArgs e)
        {
            this.DisplayingPersonalData(tbemail.Text);
        }
        public void DisplayingPersonalData(String code)
        {
            try
            {
                listboxStatusAndHistory.Items.Clear();

                Visitor v = client.VisitorInfo(code);
                listboxStatusAndHistory.Items.Add("PERSONAL INFORMATION:");
                listboxStatusAndHistory.Items.Add("First Name: " + v.Fname);
                listboxStatusAndHistory.Items.Add("Last Name: " + v.Lname);
                listboxStatusAndHistory.Items.Add("Email: " + v.Email);
                listboxStatusAndHistory.Items.Add("Gender: " + v.Gender);
                listboxStatusAndHistory.Items.Add("Phone: " + v.Phone);
                listboxStatusAndHistory.Items.Add("Country: " + v.Country);
                listboxStatusAndHistory.Items.Add("City: " + v.City);
                listboxStatusAndHistory.Items.Add("Balance left: " + v.Balance_left);

                listboxStatusAndHistory.Items.Add("");
                listboxStatusAndHistory.Items.Add("CAMPING INFORMATION:");

                CampSpot spot = client.CampingInfo(code);
                if (spot!=null)
                {
                    listboxStatusAndHistory.Items.Add("Spot: " + spot.Spot);
                    listboxStatusAndHistory.Items.Add("Email: " + spot.Email);
                    listboxStatusAndHistory.Items.Add("First Name: " + spot.Fname);
                    listboxStatusAndHistory.Items.Add("Last Name: " + spot.Lname);
                }

            }
            catch (NullReferenceException)
            {
                listboxStatusAndHistory.Items.Clear();
                listboxStatusAndHistory.Items.Add("There is no such person!!!!!!!!!!");
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //general
            int numberOfVisitors;
            int numberOfEntered;
            int numberOfLeft;
            double totalbalance, totalprofit;

            gen.GeneralStatistics(out numberOfVisitors, out numberOfEntered, out numberOfLeft);


            tbwhowillvisit.Text = numberOfVisitors.ToString();
            tbentered.Text = numberOfEntered.ToString();
            tbnotentered.Text = (numberOfVisitors - numberOfEntered).ToString();
            tbwholeft.Text = numberOfLeft.ToString();

            gen.TotalAmountOfEventAccounts(out totalbalance, out totalprofit);
            tbtotalamount.Text = totalbalance.ToString();
            tbmoney.Text = totalprofit.ToString();

            //camping availability


            int occupied;
            int free;
            int inside;
            int outside;
            int peoplewithspot;
            double money;

            money = camp.CampingNumbers(out occupied, out free, out inside, out outside, out peoplewithspot);

            tboccupied.Text = occupied.ToString();
            tbfree.Text = free.ToString();
            tbinside.Text = inside.ToString();
            tboutside.Text = outside.ToString();
            tbpeoplewithspot.Text = peoplewithspot.ToString();
            tbmoneyfromspots.Text = money.ToString();

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBoxcampinspotsandpeople.Items.Clear();
            listBoxcampinspotsandpeople.Items.Add("Free camping spots:");

            foreach (int c in camp.FreeSpots())
            {
                listBoxcampinspotsandpeople.Items.Add(c.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxcampinspotsandpeople.Items.Clear();
            listBoxcampinspotsandpeople.Items.Add("Camping spot: " + tbspot.Text);
            try
            {
                foreach (CampSpot c in camp.Specificspot(Convert.ToInt32(tbspot.Text)))
                {
                    listBoxcampinspotsandpeople.Items.Add(c.Fname + " " + c.Lname + " " + c.Email);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Wrong input!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShopProduct selecteditem = (ShopProduct)comboBox1.SelectedItem;

            tbQuantity.Text = selecteditem.Quantitysold.ToString();
            tbrevenue.Text = selecteditem.Revenue.ToString();

            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LendingItem selecteditem = (LendingItem)comboBox2.SelectedItem;
           
            tbtimeslend.Text = selecteditem.Quantitysold.ToString();
            tbrevenuee.Text = selecteditem.Revenue.ToString();
        }

    }
}
