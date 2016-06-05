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
        public Form1()
        {
            InitializeComponent();
            gen = new General();
            client = new Client_Info();
            camp = new Camping_Availability();
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
                foreach (String str in client.CampingInfo(tbemail.Text))
                    listboxStatusAndHistory.Items.Add(str);
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

            money=camp.CampingNumbers(out occupied, out free, out inside, out outside, out peoplewithspot);

            tboccupied.Text = occupied.ToString();
            tbfree.Text = free.ToString();
            tbinside.Text = inside.ToString();
            tboutside.Text = outside.ToString();
            tbpeoplewithspot.Text = peoplewithspot.ToString();
            tbmoneyfromspots.Text = money.ToString();


        }

    }
}
