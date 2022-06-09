using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
namespace Asteroids
{
    public class GameManager
    {
        private static GameManager crr = new GameManager();
        public static GameManager Current => crr;
        SoundPlayer tiro = new SoundPlayer(Properties.Resources.TiroCerto);
        
        int qtde_asteroids = 0;
        private GameManager()
        {

        }

        public static void Reestart()
        {
            crr = new GameManager();
        }

        public void Frames(PictureBox Jogo, Graphics g, int Width, int Height, Spaceship spaceship)
        {
            spaceship.Draw(Jogo, g);

            spaceship.Move();
            foreach (Sprite sprite in Sprites)
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

            DrawLives(g,spaceship.Lifes,(int)(Height*0.03),(int)(Width*0.02));

            for (int i = 0; i < Sprites.Count; i++)
            {
                if (Sprites[i] is Shots shot && shot.IsHitting)
                {
                    Sprites.Remove(shot);
                    i--;
                }
                else if (Sprites[i] is AsteroidSP asteroid && asteroid.IsExploding)
                {
                    Sprites.Remove(asteroid);
                    Exploded(asteroid);
                    i--;
                }
            }

            for (int i = 0; i < Sprites.Count; i++)
            {
                spaceship.CheckCollision(Sprites[i]);
                for (int j = 0; j < Sprites.Count; j++)
                {
                    if (i != j)
                        Sprites[i].CheckCollision(Sprites[j]);
                }

            }

            for(int i = 0; i<Sprites.Count;i++)
            {
                if(Sprites[i] is Shots shot)
                {
                    if ((DateTime.Now - shot.creation).TotalSeconds > 1.1)
                        Sprites.Remove(shot);
                }
                    
            }
            if (spaceship.GotHit)
            {
                spaceship.PosX = Width / 2;
                spaceship.PosY = Height / 2;
                spaceship.VelX = 0;
                spaceship.VelY = 0;
                spaceship.GotHit = false;
            }

            spaceship.HitTheWall(Height, Width);

            foreach (Sprite sprite in Sprites)
            {
                sprite.HitTheWall(Height, Width);
            }

            foreach(Sprite sprite in Sprites)
            {
                if(sprite is AsteroidSP)
                {
                    qtde_asteroids++;
                }
            }

            if(qtde_asteroids == 0)
            {
                Application.Exit();
            }

            qtde_asteroids = 0;
            Jogo.Refresh();
        }

        public List<Sprite> Sprites { get; private set; } = new List<Sprite>();

        public void CreateAsteroids(int count = 4, int size = 100, int minx = 0, int miny = 0, int maxx = 2000, int maxy = 2000, int posimage = 1)
        {
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                int posx = rnd.Next(minx, maxx);
                int posy = rnd.Next(miny, maxy);
                int velx = rnd.Next(2, 10);
                int vely = rnd.Next(2, 10);
                Sprites.Add(new AsteroidSP(posx, posy, velx, vely, size, size, posimage));
            }
        }

        public void Shooting(Spaceship spaceship)
        {
            float VelX = (float)(2f * Math.Sin(Math.PI * spaceship.RotationAngle / 180));
            float VelY = (float)(-2f * Math.Cos(Math.PI * spaceship.RotationAngle / 180));
            Shots shot = new Shots(spaceship.PosX + spaceship.SizeX / 2, spaceship.PosY + spaceship.SizeY / 2, VelX * 15, VelY * 15, 7, 7);
            shot.creation = DateTime.Now;
            tiro.Play();
            Sprites.Add(shot);
        }

        private void Exploded(AsteroidSP asteroid)
        {
            if (asteroid.SizeX == 100)
            {
                CreateAsteroids(2, 70, (int)asteroid.PosX - 20, (int)asteroid.PosY - 20, (int)asteroid.PosX + 20, (int)asteroid.PosY + 20, 5);
            }

            if (asteroid.SizeX == 70)
            {
                CreateAsteroids(2, 55, (int)asteroid.PosX - 20, (int)asteroid.PosY - 20, (int)asteroid.PosX + 20, (int)asteroid.PosY + 20, 3);
            }
        }

        private void DrawLives(Graphics g,int lives,int height, int width)
        {
            for (int i = 0; i < lives; i++)
            {
                g.FillEllipse(Brushes.LightGreen,width, height, 15, 15);
                width += 30;
            }
        }

    }
}
