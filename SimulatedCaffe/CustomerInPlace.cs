using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class CustomerInPlace : Customer
    {
        public Table Target = null ;
        public CustomerInPlace(string name, int PositionX, int PositionY, int budget) : base(name, PositionX, PositionY,budget)
        {

        }
        public Table FindFreeTable(Table tables)
        {
                if(tables.Free == true && Target == null )
                {
                Target = tables;
                tables.Free = false;
                return tables;
                }
            return tables;

        }
    }
}
