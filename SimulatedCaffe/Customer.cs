using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class Customer:People
    {

        public int budget;
        
        public Customer(string name, int PositionX, int PositionY, int budget ):base(name,PositionX,PositionY)
        {
            this.budget = budget;
        }
    }
}
