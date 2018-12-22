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
        public int EatTime;
        public int Timer;
        Random rng;
        public StateCustInPlace state;
        public CustomerInPlace(string name, int PositionX, int PositionY, int budget, StateCustInPlace state) : base(name, PositionX, PositionY,budget)
        {
            this.state = state;
            rng = new Random();
            this.Timer = 0;
            this.budget = budget;
            this.EatTime = rng.Next(10000, 20000);
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
        public void Request()
        {
            this.state.Handle(this);
        }
    }
}
