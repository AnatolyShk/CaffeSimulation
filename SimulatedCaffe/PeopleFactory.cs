using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    interface PeopleFactory
    {
         People CreatePeople(string name, double PositionX, double PositionY);

        
    }
}
