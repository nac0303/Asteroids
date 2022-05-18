using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class AsteroidsMain : Form
    {
        Spaceship spaceship = new Spaceship(200,200,00,00,60,60);
        Timer tm = new Timer();
        Graphics g = null;
        public AsteroidsMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Jogo.Dock = DockStyle.Fill;
            this.KeyPreview = true;
            Controls.Add(Jogo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Jogo.Image = new Bitmap(Jogo.Width, Jogo.Height);

            Bitmap bmp = Jogo.Image as Bitmap;
            g = Graphics.FromImage(bmp);

            spaceship.Draw(Jogo,g);

            tm.Interval = 20;
            tm.Tick += delegate
            {
                spaceship.Move();
                spaceship.Accelerate();
                spaceship.Frictionate();
                g.Clear(Color.Black);
                spaceship.Draw(Jogo,g);
                if(spaceship.PosY + spaceship.SizeX<=0 )
                {
                    spaceship.PosY = this.Height;
                }
                if (spaceship.PosY> this.Height)
                {
                    spaceship.PosY = -60;
                }
                if (spaceship.PosX + spaceship.SizeX <= 0)
                {
                    spaceship.PosX = this.Width;
                }
                if (spaceship.PosX > this.Width)
                {
                    spaceship.PosX = -60;
                }
                Jogo.Refresh();
            };
            tm.Start();

        }

        private void ReadKey(object sender, KeyEventArgs e)
        {
            var KeyPress = e.KeyCode;
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.Right)
            {
                spaceship.Rotate(8);
            }
            if (e.KeyCode == Keys.Left)
            {
                spaceship.Rotate(-8);
            }
            if (e.KeyCode == Keys.Down)
            {
                spaceship.Down();
            }
            if (e.KeyCode == Keys.Up)
            {
                spaceship.Up();
            }
        }

        private void Stop(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                spaceship.Stop();
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                spaceship.StopAngle();
        }

        private void Jogo_Click(object sender, EventArgs e)
        {

        }
    }
}
