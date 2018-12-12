using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class Waiter : Staff
    {
        List<string> orders;
        public Table workSpace;
        public Waiter(string name, int PositionX, int PositionY, Table workSpace):base(name,PositionX,PositionY,workSpace)
        {
            this.workSpace = workSpace;
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
