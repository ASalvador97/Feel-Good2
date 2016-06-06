using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProP_app_loaning
{
    class Visitor
    {
        //properties
        public string Barcode { get; }
        public string BraceletCode { get; }
        public string Name { get; }
        public string Email { get; }
        public string CampStatus { get; }
        public string Spot { get; }
        public double Balance { get; set; }

        public Visitor(string barcode, string braceletcode, string name, string email, string campstatus, string spot, double balance)
        {
            this.Barcode = barcode;
            this.BraceletCode = braceletcode;
            this.Name = name;
            this.Email = email;
            this.CampStatus = campstatus;
            this.Spot = spot;
            this.Balance = balance;
        }

        public Visitor(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
        }
    }
}
