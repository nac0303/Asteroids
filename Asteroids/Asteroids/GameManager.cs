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
            
            for(int i = 0; i < Sprites.Count; i++)
            {
                if (Sprites[i] is AsteroidSP asteroid && asteroid.IsExploding)
                {
                    Sprites.Remove(asteroid);

                    i--;
                }
            }

            for(int i = 0; i<Sprites.Count;i++)
            {
                spaceship.CheckCollision(Sprites[i]);
                for(int j = 0; j < Sprites.Count; j++)
                {
                    Sprites[i].CheckCollision(Sprites[j]);
                }

            }
            

            spaceship.HitTheWall(Height, Width);
            
            foreach (Sprite sprite in Sprites)
            {
                sprite.HitTheWall(Height, Width);
            }

            Jogo.Refresh();
        }

        public List<Sprite> Sprites { get; private set; } = new List<Sprite>();

        public void CreateAsteroids(int count = 4, int size = 80, int minx = 0, int miny = 0, int maxx = 2000, int maxy = 2000)
        {
            Random rnd = new Random();
            
            for(int i = 0; i < count; i++)
            {
                int posx = rnd.Next(minx, maxx);
                int posy = rnd.Next(miny, maxy);
                int velx = rnd.Next(10);
                int vely = rnd.Next(10);
                Sprites.Add(new AsteroidSP(posx, posy, velx, vely, size, size));
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
