using System;
using System.Drawing;

namespace Asteroids
{
    abstract class BaseObject : ICollision
    {
        public Point Pos;
        protected Point Dir;
        public Size Size;
        protected Image newImage;
        public BaseObject(Point pos, Point dir, string path)
        {
            if (Game.Width < pos.X || Game.Height < pos.Y)
            {
                throw new GameObjectException("неверная позиция");
            }
            else if (pos.X < 0 || pos.Y < 0)
            {
                throw new GameObjectException("отрицательные размеры");
            }
            else if (dir.X - pos.X >= Game.Width || dir.Y - pos.Y >= Game.Height)
            {
                throw new GameObjectException("слишком большая скорость");
            }
            else
            {
                Pos = pos;
                Dir = dir;
                newImage = Image.FromFile(path);
                Size = newImage.Size;
            }
        }
        abstract public void Draw();
        abstract public void Update();
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);
        virtual public void Replace() { }
        public delegate void Message();
    }
}
