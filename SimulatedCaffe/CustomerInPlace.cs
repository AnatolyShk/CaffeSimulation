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
        StateCustInPlace state;
        State st { get; set; }
        public CustomerInPlace(string name, int PositionX, int PositionY, int budget, State state) : base(name, PositionX, PositionY,budget)
        {
            rng = new Random();
            this.budget = budget;
            this.state = (StateCustInPlace)state;
            this.EatTime = rng.Next(10, 60);
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
        public void  MakeOrdering()
        {
            state.getOrder(this);
            state = new NewComer();
        }
    }
}
