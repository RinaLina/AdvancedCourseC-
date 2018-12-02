using System;
using System.Drawing;

namespace Asteroids
{
    class Nebula : BaseObject
    {
        public Nebula(Point pos, Point dir, string path) : base(pos, dir, path)
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
