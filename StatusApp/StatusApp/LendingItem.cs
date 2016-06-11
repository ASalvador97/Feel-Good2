using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatusApp
{
    class LendingItem
    {
        //A class that contains information about a lended item

        private int itemid;
        private String name;
        private double pricehour;
        private double deposit;
        private int instock;
        private int quantitysold;
        private double revenue;

        public int ItemID { get { return itemid; } }
        public String Name { get { return name; } }
        public double Pricehour { get { return pricehour; } }
        public double Deposit { get { return deposit; } }
        public int Instock { get { return instock; } }
        public int Quantitysold { get { return quantitysold; } }
        public double Revenue { get { return revenue; } }

        public LendingItem(int id,String nm,double ph,double dep,int instock,int quant,double revenue)
        {
            this.itemid = id;
            this.name = nm;
            this.pricehour = ph;
            this.deposit = dep;
            this.instock = instock;
            this.quantitysold = quant;
            this.revenue = revenue;
        }

        public override string ToString()
        {
            return itemid+" "+name;
        }
    }
}
