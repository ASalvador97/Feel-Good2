using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayPalApp
{
    public class PaymentObject
    {
        private String id;
        private double money;
        private int nrOfDeposits;
        private DateTime start;
        private DateTime end;
        private String bankAccount;

        public String Id { get { return id; } }
        public double Money { get { return money; } }
        public int NrOfDeposits { get { return this.nrOfDeposits; } }
        public DateTime Start { get { return this.start; } }
        public DateTime End { get { return this.end; } }
        public String BankAccount { get { return this.bankAccount; } }


        public PaymentObject(String ba,DateTime st,DateTime en, int nr, String i,double mon)
        {
            this.bankAccount = ba;
            this.start = st;
            this.end = en;
            this.nrOfDeposits = nr;
            this.id = i;
            this.money = mon;
        }
    }
}
