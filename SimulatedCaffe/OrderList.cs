using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    class OrderList
    {
        List<string> orders;
        public void Notify(List<string> orders)
        {
            this.orders = orders;
        }
        public List<string> Request()
        {
            return this.orders;
        }
    }
}
