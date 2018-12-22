using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class Dialogue
    {
        public void GetOrder(ref Waiter waiter, ref CustomerInPlace customer)
        {
            customer.state = new Pending();
            if (waiter.state.ToString() != "TransferOrder")
            {
                waiter.state = new TransferOrder();
            }
        }
        public void PickUpOrder(ref Waiter waiter , ref CustomerInPlace customer)
        {
            customer.state = new Eating();
        }
        public void LeaveOrder(ref Waiter waiter, ref CustomerInPlace customer)
        {
            customer.state = new Leaving();
        }
    }
}
