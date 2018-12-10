using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    class Leaving:StateCustInPlace
    {
        public void Handle(CustomerInPlace customer)
        {
            customer.state = new Leaving();
        }
    }
}
