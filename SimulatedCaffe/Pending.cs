﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    class Pending:StateCustInPlace
    {
        public string name = "Pending";
        public void Handle(CustomerInPlace customer)
        {
            customer.state = new Pending();
        }
    }
}
