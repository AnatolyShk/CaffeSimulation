using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    class Staff:People
    {
        string workSpace;
        public Staff(string name, double PositionX, double PositionY,string workSpace):base(name,PositionX,PositionY)
        {
            this.workSpace = workSpace;
        }
    }
}
