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

namespace PROP_leaving_event
{
    public partial class Form1 : Form
    {
        DataHelper mydatahelper = new DataHelper();
        Visitor v;
        public Form1()
        {
            InitializeComponent();
        }

        private void btCheckviaemail_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Lavender;
            List<String> borrowed;
            v = mydatahelper.GetVisitor(tbChipOrEmail.Text);
            this.lbemail.Text = v.Email;

            if (v.HasGoodsToReturn)
            {
                panel1.BackColor = Color.Red;
                 borrowed = mydatahelper.GetBorrowedGoods(v.ChipId);
                foreach(string s in borrowed)
                {
                    lbInfo.Items.Add(s);
                }
            }
            if (v.HasGoodsToReturn == false)
            {
                panel1.BackColor = Color.Green;

            }
            


        }
    }
}
