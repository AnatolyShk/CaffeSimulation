using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class WaiterPending:StateWaiter
    {
        public void Handle(Waiter waiter)
        {
            waiter.targetPosX = 5;
            waiter.targetPosY = 150;
        }
    }
}
