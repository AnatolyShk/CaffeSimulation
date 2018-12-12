﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class StaffFactory : PeopleFactory
    {
        Table workSpace;
        public People CreatePeople(string name, int PositionX, int PositionY,State state)
        {
            return new Waiter(name,PositionX,PositionY,workSpace);
        }
    }
}
