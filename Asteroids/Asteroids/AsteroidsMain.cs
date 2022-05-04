using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class AsteroidsMain : Form
    {
        Spaceship spaceship = new Spaceship(10,20,10,00,100,100);
        Timer tm = new Timer();
        public AsteroidsMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Jogo.Dock = DockStyle.Fill;
            Controls.Add(Jogo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Jogo.Image = new Bitmap(Jogo.Width, Jogo.Height);

            Bitmap bmp = Jogo.Image as Bitmap;
            Graphics g = Graphics.FromImage(bmp);
            spaceship.Draw(Jogo,g);

            tm.Interval = 30;
            tm.Tick += delegate
            {
                spaceship.Move();
                g.Clear(Color.Black);
                spaceship.Draw(Jogo,g);
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
                return;
            }
            if (e.KeyCode == Keys.Right)
            {
                return;
            }
            if (e.KeyCode == Keys.Left)
            {
                spaceship.Left();
                return;
            }
            if (e.KeyCode == Keys.Down)
            {
                spaceship.Down();
                return;
            }
            if (e.KeyCode == Keys.Up)
            {
                spaceship.Up();
                return;
            }
        }

        private void Stop(object sender, KeyEventArgs e)
        {
            spaceship.Stop();
        }
    }
}
