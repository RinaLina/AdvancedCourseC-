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
            newImage = Image.FromFile("../../space.jpg");
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

            Buffer.Graphics.Clear(Color.Blue);
            Buffer.Graphics.DrawImage(newImage, 0, 0);
            foreach (BaseObject obj in _objs) obj.Draw();

            Buffer.Render();
        }
        public static void Update()
        {
            foreach(BaseObject obj in _objs) obj.Update();
        }
        public static BaseObject[] _objs;
        public static void Load()
        {
            int n = 1; // количество туманностей
            int p = 2; // количество планет
            int s = 10; // количество звезд
            int a = 10; //количество астероидов

            _objs = new BaseObject[n + p + s + a];
           
            for (int i = 0; i < n; i++)
            {
                _objs[i] = new Nebula(new Point(200 - 300 * (int)Math.Pow(-1, i), 200 - 100*(int)Math.Pow(-1, i)), new Point(0, 0), new Size(30, 30), "../../nebula.png");
            }
            for (int i = n; i < n + p; i++)
            {
                _objs[i] = new Planet(new Point(200 + 300 * (int)Math.Pow(-1, i), 200 + 300 * (int)Math.Pow(-1, i)), new Point(0, 2), new Size(30, 30), "../../planet.png");
            }
            for (int i = n + p; i < n + p + s; i++)
            {
                _objs[i] = new Star(new Point(600, (i - n + p) * 40), new Point(i, 0), new Size(5, 5), "../../starr.png");
            }
            for (int i = n + p + s; i < n + p + s + a; i++)
            {
                _objs[i] = new Asteroid(new Point(400, 300), new Point((int)Math.Pow(-1, i) * (i + 3) * 3, (int)Math.Pow(-1, i) * (i + 7) * 3), new Size(10, 10), "../../asteroid.png");
            }
        }
    }
}