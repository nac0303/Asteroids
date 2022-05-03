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

        public int SizeX { get => sizeX; set => sizeX = value; }
        public int SizeY { get => sizeY; set => sizeY = value; }
        public float PosX { get => posX; set => posX = value; }
        public float PosY { get => posY; set => posY = value; }
        public float VelX { get => velX; set => velX = value; }
        public float VelY { get => velY; set => velY = value; }
        public Image[] Images { get => image; set => image = value; }
        public int PosImageAtual { get => posImageAtual; set => posImageAtual = value; }

        public void Move()
        {
            posX += velX;
            posY += velY;
        }

        public void Draw(PictureBox Jogo)
        {
            Bitmap bmp = Jogo.Image as Bitmap;
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(image[PosImageAtual], this.PosX, this.PosY, this.SizeX, this.SizeY);
        }
    }
}
