using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedCaffe
{
    public class People
    {
        public string name;
        public int positionX;
        public int positionY;
        public int targetPosX =5;
        public int targetPosY = 150;
        public void Move(int rangeX, int rangeY)
        {
            this.positionX += rangeX;
            this.positionY += rangeY;
        }
        public People(string name, int PositionX, int PositionY)
        {
            this.name = name;
            this.positionX = PositionX;
            this.positionY = PositionY;
        }
        public void MoveToTarget(int TargetPosX , int TargetPosY)
        {
                if (this.positionX < TargetPosX)
                {
                 
                        this.positionX ++;
                    
                }
                if (this.positionX > TargetPosX)
                {
                        this.positionX--;
                    
                }

                if (this.positionY < TargetPosY)
                {
                        this.positionY++;
                    
                }
                if (this.positionY > TargetPosY)
                {
                        this.positionY--;
                    
                }
            
        }

    }
}
