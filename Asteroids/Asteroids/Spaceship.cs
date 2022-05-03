using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    public class Spaceship : Sprite
    {
        public Spaceship(float posX, float posY,int velX, int velY, int sizeX,int sizeY)
        {
            this.Images = new Image[] {Properties.Resources.Astro1_2};
            this.PosX = posX;
            this.PosY = posY;
            this.VelX = velX;
            this.VelY = velY;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.PosImageAtual = 0;
        } 

        public void Right()
        { 
            this.PosX = 0;
            this.VelX = 10;
        }
        
        public void Left()
        {
            this.PosY = 0;
            this.VelX -= 10;
        }

        public void Up()
        {
            this.PosX = 0;
            this.VelY = 10;
        }

        public void Down()
        {
            this.PosX = 0;
            this.VelY = -10;
        }
    }
}
