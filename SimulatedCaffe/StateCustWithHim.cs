﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public interface StateCustWithHim:State
    {
        void Handle(CustomerWithHim customer);
    }
}
