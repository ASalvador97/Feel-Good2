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
        public Form1()
        {
            InitializeComponent();
            gen = new General();
            client = new Client_Info();

            tbwhowillvisit.Text = gen.NumberOfVisitors().ToString();

            tbentered.Text = gen.NumberOfVisitorsEntered().ToString();

            tbnotentered.Text = (Convert.ToInt32(tbwhowillvisit.Text) - Convert.ToInt32(tbentered.Text)).ToString();

            tbwholeft.Text = gen.NumberOfVisitorsLeft().ToString();

            tbtotalamount.Text = gen.TotalAmountOfEventAccounts().ToString();
        }

        private void btnLoadAllStudents_Click(object sender, EventArgs e)
        {
            Visitor v=client.VisitorInfo(tbemail.Text);
            listboxStatusAndHistory.Items.Add("PERSONAL INFORMATION:");
            listboxStatusAndHistory.Items.Add("First Name: "+v.Fname);
            listboxStatusAndHistory.Items.Add("Last Name: "+v.Lname);
            listboxStatusAndHistory.Items.Add("Email: "+v.Email);
            listboxStatusAndHistory.Items.Add("Gender: "+v.Gender);
            listboxStatusAndHistory.Items.Add("Phone: "+v.Phone);
            listboxStatusAndHistory.Items.Add("Country: "+v.Country);
            listboxStatusAndHistory.Items.Add("City: "+v.City);
            listboxStatusAndHistory.Items.Add("Balance left: "+v.Balance_left);

            listboxStatusAndHistory.Items.Add("CAMPING INFORMATION:\n");

            foreach (String str in client.CampingInfo(tbemail.Text))
                listboxStatusAndHistory.Items.Add(str);
        }

    }
}
