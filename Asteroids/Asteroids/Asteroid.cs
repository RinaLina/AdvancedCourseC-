using System;
using System.Drawing;

namespace Asteroids
{
    class Asteroid : BaseObject
    {
        public Asteroid(Point pos, Point dir, Size size, string path) : base(pos, dir, size, path)
        {
            //"../../asteroid.png"
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(newImage, Pos);
        }
    }
}
