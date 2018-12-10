using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class Ordering: StateCustInPlace
    {
        public string name = "Ordering";
        public void Handle(CustomerInPlace customer)
        {
            customer.state = new Ordering();
        }
    }
}
