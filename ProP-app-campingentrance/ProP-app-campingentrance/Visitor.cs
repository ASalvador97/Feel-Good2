using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProP_app_campingentrance
{
    class Visitor
    {
        public string Name { get; }
        public string Email { get; }
        public string Registration { get; }
        public string Spot { get; }

        public Visitor(string name, string email, string registration, string spot)
        {
            this.Name = name;
            this.Email = email;
            this.Registration = registration;
            this.Spot = spot;
        }
    }
}
