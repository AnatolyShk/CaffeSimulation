using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class Staff:People
    {
        string workSpace;
        public Staff(string name, int PositionX, int PositionY,string workSpace):base(name,PositionX,PositionY)
        {
            this.workSpace = workSpace;
        }
    }
}
