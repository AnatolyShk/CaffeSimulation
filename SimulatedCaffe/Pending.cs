using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    class Pending:StateCustInPlace
    {
        public string name = "Pending";
        bool pay;
        public void Handle(CustomerInPlace customer)
        {
            
            if (pay == false)
            {
                customer.budget = customer.budget - 100;
            }
            pay = true;
        }
    }
}
