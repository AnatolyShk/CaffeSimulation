using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class StaffFactory : PeopleFactory
    {
        string workSpace;
        public People CreatePeople(string name, int PositionX, int PositionY)
        {
            return new Staff(name,PositionX,PositionY,workSpace);
        }
    }
}
