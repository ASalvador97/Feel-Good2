using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProP_app_shop
{
    class ItemsForSale
    {
        //properties
        public int Id { get; }
        public string Name { get; }
        public double Price { get; }

        //constructor
        public ItemsForSale(int id, string name, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }
    }
}
