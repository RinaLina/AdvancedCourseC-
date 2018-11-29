using System;
using System.Drawing;

namespace Asteroids
{
    class Nebula : BaseObject
    {
        public Nebula(Point pos, Point dir, Size size, string path) : base(pos, dir, size, path)
        {
            //"../../nebula.png"
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(newImage, Pos);
        }
        public override void Update()
        {
            return;
        }
    }
}
