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
        public AsteroidsMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Jogo.Dock = DockStyle.Fill;
            Jogo.Image = new Bitmap(Jogo.Width,Jogo.Height);
            spaceship.Draw(Jogo);
        }



    }
}
