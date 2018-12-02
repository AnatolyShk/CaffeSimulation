using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    class People
    {

        string name;
        double positionX;
        double positionY;
        public void Move(double rangeX, double rangeY)
        {
            this.positionX += rangeX;
            this.positionY += rangeY;
        }
        public People(string name, double PositionX, double PositionY)
        {
            this.name = name;
            this.positionX = PositionX;
            this.positionY = PositionY;
        }

    }
}
