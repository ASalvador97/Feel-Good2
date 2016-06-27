using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProP_app_entrance
{
    public class Visitor
    {

        private String fname, lname, email, phone,barcode;
        private int campspot;

        public String Fname { get { return fname; } }
        public String Lname { get { return lname; } }
        public String Email { get { return email; } }
        public String Phone { get { return phone; } }
        public int Campspot { get { return campspot; } }
        public string Barcode { get { return barcode; } }
        
        public Visitor(String first,String last,String e, String ph, int camp, string barcode)
        {
            this.fname = first;
            this.lname = last;
            this.email = e;
            this.phone = ph;
            this.campspot = camp;
            this.barcode = barcode;
           
        }

        
    }
}
