using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProP_app_shop
{
    class Visitor
    {
        //properties
        public string Name { get; }
        public string Email { get; }
        public double Balance { get; set; }

        //constructor
        public Visitor(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
        }
    }
}
