using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatusApp
{
    class ShopProduct
    {//Here will be stored information regarding an item from the shops
        private int productid;
        private String description;
        private double price;
        private int stock;
        private int quantitysold;
        private double revenue;

        public int ProductId { get { return productid; } }
        public String Description { get { return description; } }
        public double Price { get { return price; } }
        public int Stock { get { return stock; } }
        public int Quantitysold { get { return quantitysold; } }
        public double Revenue { get { return revenue; } }

        public ShopProduct(int pr,String descr,double pri,int stock,int quantity,double rev)
        {
            this.productid = pr;
            this.description = descr;
            this.price = pri;
            this.stock = stock;

            this.quantitysold = quantity;
            this.revenue = rev;

        }
        public override string ToString()
        {
            return description;
        }
    }
}
