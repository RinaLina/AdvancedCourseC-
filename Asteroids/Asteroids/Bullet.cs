using System;
using System.Drawing;
namespace Asteroids
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir,string path, Size size) : base(pos, dir, path)
        {
            //"../../bullet.png"
            Size = size;
        }
        public override void Draw()
        {
            Rectangle destRect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(newImage, destRect);
        }
        public override void Update()
        {
            Pos.X = Pos.X + 3;
        }
        public override void Replace()
        {
            Pos.Y = Game.Height / 2;
            Pos.X = 0;
        }

    }
}
