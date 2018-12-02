using System;
using System.Windows.Forms;
using System.Drawing;


namespace Asteroids
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Image newImage;

        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
        public static void Init(Form form)
        {
            Graphics g = form.CreateGraphics();
            _context = BufferedGraphicsManager.Current;
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            if (Width <= 0 || Width > 1000 || Height <= 0 || Height > 1000)
            {
                throw new ArgumentOutOfRangeException();
            }

            newImage = Image.FromFile("../../space.jpg");
            form.BackgroundImage = newImage;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        public static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(newImage, new Rectangle(0, 0, Width, Height));
            foreach (BaseObject obj in _objs) obj.Draw();
            foreach (Asteroid obj in _asteroids) obj.Draw();
            _bullet.Draw();

            Buffer.Render();
        }
        public static void Update()
        {
            foreach(BaseObject obj in _objs) obj.Update();
            foreach (Asteroid a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    a.Replace();
                    _bullet.Replace();
                }
            }
            _bullet.Update();
        }
        public static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;

        public static void Load()
        {
            int n = 1; // количество туманностей
            int p = 2; // количество планет
            int s = 10; // количество звезд
            int a = 10; //количество астероидов

            var rnd = new Random();

            _objs = new BaseObject[n + p + s];
           
            for (int i = 0; i < n; i++)
            {
                _objs[i] = new Nebula(new Point(200, Game.Height-560), new Point(0, 0),  "../../nebula.png");
            }
            for (int i = n; i < n + p; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Planet(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), 
                    new Point(-r, r), "../../planet.png");
            }
            for (int i = n + p; i < n + p + s; i++)
            {
                _objs[i] = new Star(new Point(600, (i - n + p) * 40), new Point(i, 0), 
                    "../../starr.png");
            }
            _asteroids = new Asteroid[a];
            for (int i = 0; i < a; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), 
                    new Point(-r / 5, r), "../../asteroid.png");
            }
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), "../../bullet.png", new Size(4, 1));
        }
    }
}