using System;
using System.Drawing;

namespace Asteroids
{
    class Planet : BaseObject
    {
        public Planet(Point pos, Point dir, Size size, string path) : base(pos, dir, size, path)
        {
            //"../../planet.png"
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(newImage, Pos);

        }
        public override void Update()
        {
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.Y < 0) Pos.Y = Game.Height + Size.Height;
        }
    }
}
