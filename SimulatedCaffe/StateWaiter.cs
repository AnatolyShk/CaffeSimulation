using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public interface StateWaiter:State
    {
        void Handle(Waiter customer);
    }
}
