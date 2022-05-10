using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    public class Spaceship : Sprite
    {
        public float RotationAngle { get; set; }
        public float AccelerationX { get; set; }
        public float AccelerationY { get; set; }

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

        private bool inmove = false;
        public void Up()
        {
            inmove = true;
            this.AccelerationX = (float)(1f * Math.Sin(Math.PI * this.RotationAngle / 180));
            this.AccelerationY = (float)(-1f * Math.Cos(Math.PI * this.RotationAngle / 180));
        }

        public void Down()
        {
        }

        public void Accelerate()
        {
            int velmax = 30;
            VelX += AccelerationX;
            if (VelX > velmax)
                VelX = velmax;
            else if (VelX < -velmax)
                VelX = -velmax;
            VelY += AccelerationY;
            if (VelY > velmax)
                VelY = velmax;
            else if (VelY < -velmax)
                VelY = -velmax;
        }
        public void Frictionate()
        {
            float friction = 0.5f;
            if (VelX > 0)
            {
                VelX -= friction;
                if (VelX < 0)
                    VelX = 0;
            }
            else if (VelX < 0)
            {
                VelX += friction;
                if (VelX > 0)
                    VelX = 0;
            }

            if (VelY > 0)
            {
                VelY -= friction;
                if (VelY < 0)
                    VelY = 0;
            }
            else if (VelY < 0)
            {
                VelY += friction;
                if (VelY > 0)
                    VelY = 0;
            }
        }

        public void Stop()
        {
            this.AccelerationX = 0;
            this.AccelerationY = 0;
            inmove = false;
        }
        public void Rotate(float angle)
        {
            RotationAngle += angle;
            if (inmove)
            {
                this.AccelerationX = (float)(5 * Math.Sin(Math.PI * this.RotationAngle / 180));
                this.AccelerationY = (float)(-5 * Math.Cos(Math.PI * this.RotationAngle / 180));
            }
        }
        public override void Draw(PictureBox Jogo, Graphics g)
        {
            float deslocx = this.PosX + this.SizeX / 2,
                  deslocy = this.PosY + this.SizeY / 2;
            g.TranslateTransform(deslocx, deslocy);
            g.RotateTransform(this.RotationAngle);
            g.TranslateTransform(-deslocx, -deslocy);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            base.Draw(Jogo, g);

            g.TranslateTransform(deslocx, deslocy);
            g.RotateTransform(-this.RotationAngle);
            g.TranslateTransform(-deslocx, -deslocy);
        }
    }

}
