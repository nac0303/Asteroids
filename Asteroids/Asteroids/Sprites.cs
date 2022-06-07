using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public class Sprite
    {
        private float posX;
        private float posY;
        private float velX;
        private float velY;
        private int sizeX;
        private int sizeY;
        private Image[] image;
        int posImageAtual;
        
        public Sprite()
        {

        
        }

        public HitBox HitBox { get; set; }

        public int SizeX { get => sizeX; set => sizeX = value; }
        public int SizeY { get => sizeY; set => sizeY = value; }
        public float PosX { get => posX; set => posX = value; }
        public float PosY { get => posY; set => posY = value; }
        public float VelX { get => velX; set => velX = value; }
        public float VelY { get => velY; set => velY = value; }
        public Image[] Images { get => image; set => image = value; }
        public int PosImageAtual { get => posImageAtual; set => posImageAtual = value; }

        public virtual void Move()
        {
            posX += velX;
            posY += velY;
        }

        public virtual void Draw(PictureBox Jogo, Graphics g)
        {
            g.DrawImage(image[PosImageAtual], this.PosX, this.PosY, this.SizeX, this.SizeY);
        }

        public virtual void HitTheWall(int Height, int Width)
        {

        }

        public virtual void Colisao(PictureBox Jogo, Timer tm)
        {

        }

        public virtual void CheckCollision(Sprite entity)
        {

        }
       
        public virtual void OnCollision(CollisionInfo info, Sprite sprite) {
           
        }
    }
}
