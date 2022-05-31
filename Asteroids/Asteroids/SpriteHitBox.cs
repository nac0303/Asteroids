using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class SpriteHitBox : HitBox
    {
        public Sprite Sprite { get; set; }
        public override PointF[] Points => new PointF[]
        {
            new PointF(Sprite.PosX, Sprite.PosY),
            new PointF(Sprite.PosX + Sprite.SizeX, Sprite.PosY),
            new PointF(Sprite.PosX + Sprite.SizeX, Sprite.PosY + Sprite.SizeY),
            new PointF(Sprite.PosX, Sprite.PosY + Sprite.SizeY),
            new PointF(Sprite.PosX, Sprite.PosY)
        };
    }
}
