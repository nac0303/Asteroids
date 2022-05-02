using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class Sprites
    {
        protected float posX;
        protected float posY;
        protected float velX;
        protected float velY;
        protected int sizeX;
        protected int sizeY;

        private Bitmap sprite;

        protected int SizeX { get => sizeX; set => sizeX = value; }
        protected int SizeY { get => sizeY; set => sizeY = value; }
        protected float PosX { get => posX; set => posX = value; }
        protected float PosY { get => posY; set => posY = value; }
        protected float VelX { get => velX; set => velX = value; }
        protected float VelY { get => velY; set => velY = value; }
        protected Bitmap Sprite { get => sprite; set => sprite = value; }

        protected void Move()
        {
            posX += velX;
            posX += velY;
        }
    }
}
