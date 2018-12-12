using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class Dialogue
    {
        public void GetOrder(ref Waiter waiter, ref  People customer)
        {
            customer.state = new Pending();
            if (waiter.state.ToString() != "TransferOrder")
            {
                waiter.state = new WaiterGetOrder();
            }
        }
        public void PickUpOrder(ref Waiter waiter , ref People customer)
        {
            customer.state = new Eating();
            waiter.state = new TransferOrder();
        }
        public void LeaveOrder(ref Waiter waiter, ref People customer)
        {
            customer.state = new Leaving();
        }
    }
}
