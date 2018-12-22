using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class TransferOrder : StateWaiter
    {
        public void Handle(Waiter waiter)
        {
            waiter.MoveToTarget(waiter.targetPosX, waiter.targetPosY);
        }
    }
}
