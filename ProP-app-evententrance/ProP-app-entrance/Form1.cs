using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProP_app_entrance
{
    public partial class Form1 : Form
    {
        DataHelper mydatahelper;
        public Form1()
        {
            mydatahelper = new DataHelper();
            InitializeComponent();
            
        }

        private void tbBraceletcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<String> temp;
            temp = mydatahelper.GetVisitor(Convert.ToString(1234));
            this.lbName.Text = temp[0];
            this.lbEmail.Text = temp[1];
            this.tbBarcode.Text = temp[2];

        }


        
    }
}
