using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
namespace Asteroids
{
    public class Shots : Sprite
    {
        //public float AccelerationX { get; set; }
        //public float AccelerationY { get; set; }
        public bool IsHitting { get; set; } = false;
        public DateTime creation { get; set; }
        
        public Shots(float posX, float posY, float velX, float velY, int sizeX, int sizeY)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.VelX = velX;
            this.VelY = velY;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.HitBox = HitBox.FromSprite(this);
        }

        public override void Draw(PictureBox Jogo, Graphics g)
        {
            g.FillEllipse(Brushes.White, this.PosX, this.PosY,10,10);
            
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
        public override void CheckCollision(Sprite entity)
        {
            float dx = entity.PosX - this.PosX;
            float dy = entity.PosY - this.PosY;
            if (dx * dx + dy * dy > 100 * 100)
                return;
            var info = entity.HitBox.IsColliding(HitBox);
            if (info.IsColliding)
            {
                if (entity is Spaceship)
                {
                    info.Type = EntityType.Spaceship;
                }
                else if (entity is AsteroidSP)
                {
                    info.Type = EntityType.Asteroid;
                }
                OnCollision(info, entity);
            }
        }

        public override void OnCollision(CollisionInfo info, Sprite sprite)
        {
            if (info.IsColliding && info.Type == EntityType.Asteroid)
            {
                IsHitting = true;
            }
        }
    }
}
