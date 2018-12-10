using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class CustomerInPlace : Customer
    {
        int budget;
        public Table Target = null ;
        StateCustInPlace state;
        public CustomerInPlace(string name, int PositionX, int PositionY, int budget, State state) : base(name, PositionX, PositionY,budget)
        {
            this.budget = budget;
            this.state = (StateCustInPlace)state;
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
