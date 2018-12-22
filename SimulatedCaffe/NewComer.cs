﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
   public  class NewComer: StateCustInPlace
    {
        public string name = "NewComer";
        public void Handle(CustomerInPlace customer)
        {
            if (customer != null)
            {
                customer.MoveToTarget(customer.Target.PositionX, customer.Target.PositionY);
            }
        }
    }
}
