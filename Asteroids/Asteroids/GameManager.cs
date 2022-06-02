using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public class GameManager
    {
        private static GameManager crr = new GameManager();
        public static GameManager Current => crr;

        private GameManager()
        {
            

        }

        public static void Reestart()
        {
            crr = new GameManager();
        }

        public void Frames(PictureBox Jogo, Graphics g, int Width, int Height,Spaceship spaceship)
        {
            spaceship.Draw(Jogo, g);

            spaceship.Move();
            foreach(Sprite sprite in Sprites)
            {
                sprite.Move();
            }
            

            spaceship.Accelerate();
            spaceship.Frictionate();

            g.Clear(Color.Black);

            spaceship.Draw(Jogo, g);
            foreach (Sprite sprite in Sprites)
            {
                sprite.Draw(Jogo, g);
            }

            spaceship.HitBox.Draw(g);

            foreach (Sprite sprite in Sprites)
            {
                spaceship.CheckCollision(sprite);
            }
            

            spaceship.HitTheWall(Height, Width);
            
            foreach (Sprite sprite in Sprites)
            {
                sprite.HitTheWall(Height, Width);
            }

            Jogo.Refresh();
        }

        public List<Sprite> Sprites { get; private set; } = new List<Sprite>();

        public void CreateAsteroids()
        {
            Random rnd = new Random();
            
            for(int i = 0; i <5 ; i++)
            {
                int posx = rnd.Next(2000);
                int posy = rnd.Next(2000);
                int velx = rnd.Next(10);
                int vely = rnd.Next(10);
                Sprites.Add(new AsteroidSP(posx, posy, velx, vely, 80, 80));
            }
        }

        public void Shooting(Spaceship spaceship)
        {
            float VelX = (float)(2f * Math.Sin(Math.PI * spaceship.RotationAngle / 180));
            float VelY= (float)(-2f * Math.Cos(Math.PI * spaceship.RotationAngle / 180));
            Shots shot = new Shots(spaceship.PosX +spaceship.SizeX/2, spaceship.PosY+spaceship.SizeY/2, VelX*15, VelY*15, 7, 7);
            Sprites.Add(shot);
        }
    }
}
