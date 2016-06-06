using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProP_app_loaning
{
    class ItemsForRent
    {
        //fields
        public string Name { get; }
        public double Price { get; }

        //constructor
        public ItemsForRent(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
