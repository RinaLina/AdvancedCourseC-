using System;
using System.Drawing;

namespace Asteroids
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Image newImage;
        public BaseObject(Point pos, Point dir, Size size, string path)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            newImage = Image.FromFile(path);
        }
        virtual public void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        virtual public void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.X > Game.Height) Dir.Y = -Dir.Y;

        }
    }
}
