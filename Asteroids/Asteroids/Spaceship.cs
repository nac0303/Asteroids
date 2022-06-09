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
        public int Lifes { get; set; } = 5;
        public float RotationAngle { get; set; }
        public float AngularAcceleration { get; set; }
        public float AccelerationX { get; set; }
        public float AccelerationY { get; set; }
        public bool GotHit { get; set; } = false;
        
        
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
            this.HitBox = HitBox.FromSprite(this);
        }

        private bool inmove = false;
        private int teleportstep = 0;
        public void Up()
        {
            inmove = true;
            this.AccelerationX = (float)(1.5f * Math.Sin(Math.PI * this.RotationAngle / 180));
            this.AccelerationY = (float)(-1.5f * Math.Cos(Math.PI * this.RotationAngle / 180));
        }

        public override void Move()
        {
            if (teleportstep > 0)
            {
                int duration = 10;
                int size = 60 / duration / 2;

                teleportstep++;
                if (teleportstep < duration + 2)
                {
                    this.PosX += size;
                    this.PosY += size;
                    this.SizeX -= 2 * size;
                    this.SizeY -= 2 * size;
                }
                else if (teleportstep == duration + 2)
                {
                    Random rnd = new Random();

                    PosX = (float)(rnd.Next(0, 1920));
                    PosY = (float)(rnd.Next(0, 1080));
                    VelX = 0;
                    VelY = 0;
                    AccelerationX = 0;
                    AccelerationY = 0;
                }
                else if (teleportstep < 2 * duration + 3)
                {
                    this.PosX -= size;
                    this.PosY -= size;
                    this.SizeX += 2 * size;
                    this.SizeY += 2 * size;
                }
                else
                {
                    teleportstep = 0;
                }
            }
            else
            {
                base.Move();
                RotationAngle += AngularAcceleration;
                if (inmove)
                {
                    this.AccelerationX = (float)(2 * Math.Sin(Math.PI * this.RotationAngle / 180));
                    this.AccelerationY = (float)(-2 * Math.Cos(Math.PI * this.RotationAngle / 180));
                }
            }
        }

        public void Down()
        {
            if (teleportstep == 0)
                teleportstep = 1;
        }

        public void Accelerate()
        {
            int velmax = 26;
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
            float friction = 0.95f;

            VelX *= friction;
            VelY *= friction;
        }

        public void Stop()
        {
            this.AccelerationX = 0;
            this.AccelerationY = 0;
            inmove = false;
        }

        public void StopAngle()
        {
            this.AngularAcceleration = 0;
        }

        public void Rotate(float angle)
        {
            AngularAcceleration = angle;
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

        public override void HitTheWall(int Height, int Width)
        {
            if ( this.PosY + this.SizeX <= 0)
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

        public override void OnCollision(CollisionInfo info, Sprite sprite)
        {
            if (info.Type == EntityType.Asteroid)
            {
                if (Lifes > 0 )
                {
                    GotHit = true;
                    Lifes--;
                }
                if(Lifes <= 0)
                {
                    Application.Exit();
                }
                    
            }
        }

        public override void CheckCollision(Sprite entity)
        {
            float dx = entity.PosX - this.PosX;
            float dy = entity.PosY - this.PosY;
            if (dx * dx + dy * dy > 100 * 100)
                return;
            var info = HitBox.IsColliding(entity.HitBox);
            if (info.IsColliding)
            {
                if (entity is AsteroidSP)
                {
                    info.Type = EntityType.Asteroid;
                }
                else if (entity is Shots)
                {
                    info.Type = EntityType.Shot;

                }
                OnCollision(info, entity);
            }
        }
    }

}
