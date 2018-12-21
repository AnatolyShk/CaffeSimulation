using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class StateCustInPlace :State
    {
       public void getOrder(CustomerInPlace customer)
        {
            customer.state = new NewComer();
        }
    }
}
