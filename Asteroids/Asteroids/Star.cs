using System;
using System.Drawing;


namespace Asteroids
{
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, string path) : base(pos, dir, path)
        {
            //"../../starr.png"
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(newImage, Pos);

        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

    }
}
