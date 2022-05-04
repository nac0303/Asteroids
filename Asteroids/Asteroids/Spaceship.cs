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
            this.Images = new Image[] {Properties.Resources.Arrow};
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
            this.VelX = 5;
        }
        
        public void Left()
        {
            this.VelX = -5;
        }

        public void Up()
        {
            this.VelY = -5;
        }

        public void Down()
        {
            this.VelY = 5;
        }

        public void Stop()
        {
            this.VelX = 0;
            this.VelY = 0;
        }

        public Bitmap RotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, new Point(0, 0));
            }
            return returnBitmap;
        }
    }

}
