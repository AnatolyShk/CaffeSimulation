using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class CustomerWithHim : Customer
    {
        int Target;
        public CustomerWithHim(string name, int PositionX, int PositionY, int budget) : base(name, PositionX, PositionY, budget)
        {

        }
        public void FindFreeTable(List<Table> tables)
        {
            int i = 0;
            while (tables[i].Free != true)
            {
                i++;
                if (tables[i].Free == true)
                {
                    Target = tables[i].Number;
                }
            }
        }
    }
}
