using System.Drawing;

namespace Asteroids
{
    public class AsteroidSP : Sprite
    {
        
        public float AccelerationX { get; set; }
        public float AccelerationY { get; set; }

        public AsteroidSP(float posX, float posY,int velX, int velY, int sizeX,int sizeY)
        {
            this.Images = new Image[] {Properties.Resources.Astro2, Properties.Resources.Astro3, Properties.Resources.Astro4, Properties.Resources.Astro5, Properties.Resources.Astro6, Properties.Resources.Astro7};
            this.PosX = posX;
            this.PosY = posY;
            this.VelX = velX;
            this.VelY = velY;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.PosImageAtual = 1;
        }

        public override void HitTheWall(int Height, int Width)
        {
            if (this.PosY + this.SizeX <= 0)
            {
                this.PosY = Height;
            }
            if (this.PosY > Height)
            {
                this.PosY = -60;
            }
            if (this.PosX + this.SizeX <= 0)
            {
                this.PosX = Width;
            }
            if (this.PosX > Width)
            {
                this.PosX = -60;
            }
        }


        //public override void Draw(PictureBox Jogo, Graphics g)
        //{
        //    float deslocx = this.PosX + this.SizeX / 2,
        //          deslocy = this.PosY + this.SizeY / 2;
        //    g.TranslateTransform(deslocx, deslocy);
        //    g.RotateTransform(this.RotationAngle);
        //    g.TranslateTransform(-deslocx, -deslocy);

        //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        //    base.Draw(Jogo, g);

        //    g.TranslateTransform(deslocx, deslocy);
        //    g.RotateTransform(-this.RotationAngle);
        //    g.TranslateTransform(-deslocx, -deslocy);
        //}
    }

}
