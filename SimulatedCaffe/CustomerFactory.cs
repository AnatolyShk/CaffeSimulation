using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    class CustomerFactory : PeopleFactory
    {
        int budget;
       public  People CreatePeople(string name, double PositionX, double PositionY)
       {
            return new Customer(name,PositionX,PositionY,budget);
       }
    }
}
