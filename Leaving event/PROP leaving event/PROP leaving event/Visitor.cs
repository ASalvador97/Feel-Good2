using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROP_leaving_event
{
    public class Visitor
    {

        private String  email, chipid;
        //private bool hasleftevent, 
        //    private bool hasgoodstoreturn;
        

       
        public String Email { get { return email; } }
        public String ChipId {get { return chipid; }}
        //public bool HasLeftEvent { get { return hasleftevent; } }
        //public bool HasGoodsToReturn { get { return hasgoodstoreturn; } }
        
        public Visitor(String e, string chip)
        {
            
            this.email = e;
        this.chipid= chip;
           // this.hasleftevent = hasleft;
           // this.hasgoodstoreturn = mustreturn;
           
        }

        
    }
}
