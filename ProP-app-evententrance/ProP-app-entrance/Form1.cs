﻿using System;
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
        Visitor v;
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
           // timer1.Enabled = true;
            try 
            { 
            v= mydatahelper.GetVisitor(tbBarcode.Text);
            this.lbName.Text = v.Fname + " " + v.Lname;
            this.lbEmail.Text = v.Email;
            this.lbphone.Text = v.Phone;
            this.lbexists.Visible = false;

            if (v.Campspot != 0)
            {
                this.lbCamping.Text = "YES:  nr: " + v.Campspot;
                this.panel1.BackColor = Color.Green;
            }
             if (v.Campspot==0)
            { 
                this.lbCamping.Text = "NO";
                this.panel1.BackColor = Color.Blue;
            }}

            catch
            {
                this.panel1.BackColor = Color.Red;
                this.lbEmail.Text = "-";
                this.lbName.Text = "-";
                this.lbphone.Text = "-";
                this.lbBracelet.Text = "-";
                this.lbCamping.Text = "-";
                this.lbexists.Visible = true;

            }

        }

       // private void timer1_Tick(object sender, EventArgs e)
      //  {this.panel1.BackColor = Color.Lavender;
        //    this.timer1.Enabled = false; }

        private void btnSync_Click(object sender, EventArgs e)
        {
            if (
             mydatahelper.SyncBracelet(tbBraceletCode.Text, v.Email, Convert.ToString(1), "N", "") )
            {
                this.panel1.BackColor = Color.Lavender;
                this.lbBracelet.Text = tbBraceletCode.Text;
            }
            else
            {
                this.panel1.BackColor = Color.IndianRed;
            }


        }


        
    }
}