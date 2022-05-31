using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class RecHitBox : HitBox
    {
        public RectangleF Rectangle { get; set; }
        public override PointF[] Points => new PointF[]
        {
            Rectangle.Location,
            new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y),
            new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height),
            new PointF(Rectangle.X, Rectangle.Y + Rectangle.Height),
            Rectangle.Location,

        };
    }
}
