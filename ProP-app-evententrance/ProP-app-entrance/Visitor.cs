using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProP_app_entrance
{
    public class Visitor
    {

        private String fname, lname, email, phone;
        private int campspot;

        public String Fname { get { return fname; } }
        public String Lname { get { return lname; } }
        public String Email { get { return email; } }
        public String Phone { get { return phone; } }
        public int Campspot { get { return campspot; } }
        
        public Visitor(String first,String last,String e, String ph, int camp)
        {
            this.fname = first;
            this.lname = last;
            this.email = e;
            this.phone = ph;
            this.campspot = camp;
           
        }

        
    }
}
