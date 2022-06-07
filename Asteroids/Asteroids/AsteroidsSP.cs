using System.Drawing;

namespace Asteroids
{
    public class AsteroidSP : Sprite
    {
        
        public float AccelerationX { get; set; }
        public float AccelerationY { get; set; }
        public bool IsExploding { get; set; } = false;

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
            this.HitBox = HitBox.FromSprite(this);
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
            var info = HitBox.IsColliding(entity.HitBox);
            if (info.IsColliding)
            {
                if (entity is Spaceship)
                {
                    info.Type = EntityType.Spaceship;
                }
                else if (entity is Shots)
                {
                    info.Type = EntityType.Shot;

                }
                OnCollision(info, entity);
            }
        }

        public override void OnCollision(CollisionInfo info, Sprite sprite)
        {
             if (info.IsColliding && info.Type == EntityType.Shot)
            {
                this.IsExploding = true;
            }
        }
    }

}
