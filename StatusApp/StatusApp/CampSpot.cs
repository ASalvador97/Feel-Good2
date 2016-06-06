using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatusApp
{
    class CampSpot
    {
        private String lname;
        private String fname;
        private String email;
        private int spot;

        public String Lname { get { return lname; } }

        public String Fname { get { return fname; } }

        public String Email { get { return email; } }

        public int Spot { get { return spot; } }

        public CampSpot(String l,String f,String e, int s)
        {
            this.lname = l;
            this.fname = f;
            this.email = e;
            this.spot = s;
        }

    }
}
