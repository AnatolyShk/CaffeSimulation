using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    class Waiter : Staff
    {
        List<string> orders;
        public Waiter(string name, int PositionX, int PositionY, string workSpace):base(name,PositionX,PositionY,workSpace)
        {

        }
        public void TakeOrder(OrderList order)
        {
            this.orders = order.Request();
        }
        public void AnnounceTheMenu(OrderList order)
        {
            order.Notify(this.orders);
        }
    }
}
