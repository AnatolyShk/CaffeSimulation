using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class Table
    {
        public bool Free  = true;
        public int Number;
        public int PositionX;
        public int PositionY;
        public CustomerInPlace customer;
        public Table(int number,int PositionX, int PositionY)
        {
            this.Number = number;
            this.PositionX = PositionX;
            this.PositionY = PositionY;
        }
    }
}
