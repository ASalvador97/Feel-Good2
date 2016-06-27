using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProP_app_loaning
{
    class ItemsForLoan
    {
        //properties
        public string Name { get; }
        public double PriceHour { get; }
        public double Deposit { get; }
        public int ItemID { get; }
        public DateTime TimeBorrowed { get; }

        //constructor
        public ItemsForLoan(int itemid, string name, double priceHour, double deposit)
        {
            this.ItemID = itemid;
            this.Name = name;
            this.PriceHour = priceHour;
            this.Deposit = deposit;
        }

        public ItemsForLoan(int itemid, string name, double priceHour, double deposit, DateTime timeBorrowed)
        {
            this.ItemID = itemid;
            this.Name = name;
            this.PriceHour = priceHour;
            this.Deposit = deposit;
            this.TimeBorrowed = timeBorrowed;
        }

        public override string ToString()
        {
            return ItemID.ToString() + " / " + Name + " / " + Deposit.ToString() + " / " + PriceHour.ToString();
        }
    }
}
