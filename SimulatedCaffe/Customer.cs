using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    class Customer:People
    {

        int budget;
        public Customer(string name, double PositionX, double PositionY, int budget ):base(name,PositionX,PositionY)
        {
            this.budget = budget;
        }
    }
}
