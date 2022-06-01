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
        Spaceship spaceship;

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

            spaceship = new Spaceship(this.Width-(this.Width/2), this.Height - (this.Height / 2), 00, 00, 60, 60);

            GameManager.Current.CreateAsteroids();
            tm.Interval = 20;
            tm.Tick += delegate
            {
                GameManager.Current.Frames(Jogo, g, this.Width, this.Height, spaceship);
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
            if (e.KeyCode == Keys.Down)
            {
                spaceship.Down();
            }
            if(e.KeyCode == Keys.Space)
            {
                GameManager.Current.Shooting(spaceship);
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
