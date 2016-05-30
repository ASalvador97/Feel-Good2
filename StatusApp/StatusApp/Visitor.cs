using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatusApp
{
    class Visitor
    {

        private String fname, lname, email, phone, city, country;
        private DateTime dob;
        private String gender;
        private double balance_left;

        public String Fname { get { return fname; } }
        public String Lname { get { return lname; } }
        public String Email { get { return email; } }
        public String Phone { get { return phone; } }
        public String City { get { return city; } }
        public String Country { get { return country; } }

        public DateTime DOB { get { return dob; } }
        public String Gender { get { return gender; } }
        public double Balance_left { get { return balance_left; } }

        public Visitor(String first,String last,String e,String ph,String cit,String count,DateTime birth,String gend,double balance)
        {
            this.fname = first;
            this.lname = last;
            this.email = e;
            this.phone = ph;
            this.city = cit;
            this.country = count;
            this.dob = birth;
            this.gender = gend;
            this.balance_left = balance;
        }

        public override string ToString()
        {
            return this.Fname + "\n" + this.Lname + "\n" + this.Email + "\n" + this.Phone + "\n" + this.City + "\n" + this.Country + "\n" + this.DOB + "\n" + this.Gender + "\n" + this.Balance_left;
        }
    }
}
