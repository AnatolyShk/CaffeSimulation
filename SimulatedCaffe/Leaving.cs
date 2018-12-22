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
             customer.MoveToTarget(10, 10);

        }
    }
}
