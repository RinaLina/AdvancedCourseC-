using System;
using System.Drawing;
namespace Asteroids
{
    class Ship : BaseObject
    {
        static public event Action<string> CreateShip;
        static public event Action<string> DieShip;
        static public event Action<string> ChangeEnergy;
        private int _energy = 100;
        public int _exp = 0;
        public int Energy => _energy;
        public void EnergyLow(int n)
        {
            _energy -= n;
            Ship.ChangeEnergy?.Invoke($"{DateTime.Now}: Кораблик: энергия {-n}");
        }
        public Ship(Point pos, Point dir, string path, Size size) : base(pos, dir, path)
        {
            //"../../spaceship.png"
            Size = size;
            Ship.CreateShip?.Invoke($"{DateTime.Now}: Кораблик создан");
        }
        public override void Draw()
        {
            Rectangle destRect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(newImage, destRect);
        }
        public override void Update()
        {
            if (Pos.Y < 0)
            {
                Pos.Y = Size.Height;
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
            Ship.DieShip?.Invoke($"{DateTime.Now}: Кораблик погиб");

        }
        public static event Message MessageDie;

    }
}
