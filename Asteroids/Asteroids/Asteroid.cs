using System;
using System.Drawing;

namespace Asteroids
{
    class Asteroid : BaseObject
    {
        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, string path) : base(pos, dir, path)
        {
            Power = 1;
            //"../../asteroid.png"
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(newImage, Pos);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0)
            {
                Pos.Y = 0;
                Dir.Y = -Dir.Y;
            }
            if (Pos.Y > Game.Height)
            {
                Pos.Y = Game.Height;
                Dir.Y = -Dir.Y;
            }
        }

        public override void Replace()
        {
            Pos.Y = Game.Height;
            Pos.X = Game.Width;
        }
    }
}
