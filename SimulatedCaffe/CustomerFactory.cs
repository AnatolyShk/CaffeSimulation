using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class CustomerFactory : PeopleFactory
    {
        public int budget;
        public People CreatePeople(string name, int PositionX, int PositionY, State state)
       {
            return new CustomerInPlace(name,PositionX,PositionY,budget,(StateCustInPlace)state);
       }
    }
}
