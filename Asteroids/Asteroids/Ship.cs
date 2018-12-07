using System;
using System.Drawing;
namespace Asteroids
{
    class Ship : BaseObject
    {
        private int _energy = 100;
        public int Energy => _energy;
        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public Ship(Point pos, Point dir, string path, Size size) : base(pos, dir, path)
        {
            //"../../spaceship.png"
            Size = size;
        }
        public override void Draw()
        {
            Rectangle destRect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(newImage, destRect);
        }
        public override void Update()
        {
            if (Pos.X < 0) Pos.X = 0;
            if (Pos.X > Game.Width) Pos.X = Game.Width;
            if (Pos.Y < 0)
            {
                Pos.Y = 0;
            }
            if (Pos.Y > Game.Height)
            {
                Pos.Y = Game.Height;
            }
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }
        public static event Message MessageDie;

    }
}
