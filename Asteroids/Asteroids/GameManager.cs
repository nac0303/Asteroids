using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Sprite> Sprites { get; private set; } = new List<Sprite>();

    }
}
