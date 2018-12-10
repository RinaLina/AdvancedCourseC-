using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;


namespace Asteroids
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Image newImage;
        public static string BulletPicPath = "../../bullet.png";
        public static string AsterPicPath = "../../asteroid.png";
        public static string PlanetPicPath = "../../planet.png";
        public static string StarPicPath = "../../starr.png";
        public static string NebulaPicPath = "../../nebula.png";
        public static string shipImPath = "../../ss.png";
        public static string kitImPath = "../../hp.png";
        private static Timer _timer = new Timer { Interval = 100 };
        public static Random Rnd = new Random();
        private static int Level = 3; //количество астероидов
        //при создание корабля таким способом выетала ошибка : TypeInitializationException
        //private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), "../../spaseship.png", new Size(10, 10));
        public static Ship _ship
        { get; set; }
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
            form.KeyDown += Form_KeyDown;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            _ship = new Ship(new Point(10, 400), new Point(50, 50), shipImPath, new Size(50, 50));
            Ship.CreateShip += delegate (string s){Console.WriteLine(s);};
            Ship.CreateShip += s =>
            {
                using (var sw = new System.IO.StreamWriter("log.txt", true)) { sw.WriteLine(s); };
            };
            Load();
            //Timer timer = new Timer { Interval = 100 };
            _timer.Start();
            _timer.Tick += Timer_Tick;
            Ship.MessageDie += Finish;
        }
        public static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(newImage, new Rectangle(0, 0, Width, Height));
            foreach (BaseObject obj in _objs) obj.Draw();
            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();
            }
            foreach (Kit a in _kit)
            {
                a?.Draw();
            }
            foreach (Bullet a in _bullet)
            {
                a?.Draw();
            }
            _ship?.Draw();
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString("Exp:" + _ship._exp, SystemFonts.DefaultFont, Brushes.White, 100, 0);

            }

            Buffer.Render();
        }
        public static void Update()
        {
            foreach(BaseObject obj in _objs) obj.Update();
            //_bullet?.Update();
            for (int i = 0; i < _asteroids.Count; i++)
            {
                if (_ship.Collision(_asteroids[i]))
                {
                    var rnd = new Random();
                    _ship?.EnergyLow(rnd.Next(1, 10));
                    Ship.ChangeEnergy += delegate (string s)
                    {
                        Console.WriteLine(s);
                    };
                    Ship.ChangeEnergy += s =>
                    {
                        using (var sw = new System.IO.StreamWriter("log.txt", true)) { sw.WriteLine(s); };
                    };
                    System.Media.SystemSounds.Asterisk.Play();
                    if (_ship.Energy <= 0)
                    {
                        _ship?.Die();
                        Ship.DieShip += delegate (string s)
                        {
                            Console.WriteLine(s);
                        };
                        Ship.DieShip += s =>
                        {
                            using (var sw = new System.IO.StreamWriter("log.txt", true)) { sw.WriteLine(s); };
                        };
                    }
                }
                //if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                for(int j = 0; j< _bullet.Count; j++)
                {
                    if (_asteroids.Count == 0) break;
                    if (i >= _asteroids.Count)
                    {
                        i = _asteroids.Count - 1;
                    }
                    if (_bullet[j].Collision(_asteroids[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _ship._exp += _asteroids[i].Power;
                        _asteroids.RemoveAt(i);
                        _bullet.RemoveAt(j);
                        j--;
                        Asteroid.DieAsteroid += delegate (string s)
                        {
                            Console.WriteLine(s);
                        };
                        continue;
                    }
                    if(_bullet[j].Pos.X > Game.Width)
                    {
                        _bullet.RemoveAt(j);
                        j--;
                    }
                }
                                
            }
            foreach (Bullet a in _bullet)
            {
                a?.Update();
            }

            for (var i = 0; i < _kit.Length; i++)
            {
                if (_kit[i] == null) continue;
                _kit[i].Update();
                if (!_ship.Collision(_kit[i])) continue;
                var rnd = new Random();
                _ship?.EnergyLow(-rnd.Next(1, 10));
                Ship.ChangeEnergy += delegate (string s)
                {
                    Console.WriteLine(s);
                };
                Ship.ChangeEnergy += s =>
                {
                    using (var sw = new System.IO.StreamWriter("log.txt", true)) { sw.WriteLine(s); };
                };
                System.Media.SystemSounds.Asterisk.Play(); 
            }
            if(_asteroids.Count == 0)
            {
                NewLevel();
            }

        }
        public static BaseObject[] _objs;
        //private static Bullet _bullet;
        private static List<Bullet> _bullet = new List<Bullet>();
        //private static Asteroid[] _asteroids;
        private static List<Asteroid> _asteroids = new List<Asteroid>();
        private static Kit[] _kit;

        public static void Load()
        {
            int n = 1; // количество туманностей
            int p = 2; // количество планет
            int s = 10; // количество звезд
            int h = 4; // количество аптечек

            var rnd = new Random();

            _objs = new BaseObject[n + p + s];
           
            for (int i = 0; i < n; i++)
            {
                _objs[i] = new Nebula(new Point(200, Game.Height-560), new Point(0, 0), NebulaPicPath);
            }
            for (int i = n; i < n + p; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Planet(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), 
                    new Point(-r, r), PlanetPicPath );
            }
            for (int i = n + p; i < n + p + s; i++)
            {
                _objs[i] = new Star(new Point(600, (i - n + p) * 40), new Point(i, 0),
                    StarPicPath);
            }
            //_asteroids = new Asteroid[a];
            NewLevel();
            _kit = new Kit[h];
            for (int i = 0; i < h; i++)
            {
                int r = rnd.Next(5, 50);
                _kit[i] = new Kit(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)),
                    new Point(-r / 5, r), kitImPath, new Size(50, 50));
            }
            //_bullet = new Bullet(new Point(0, 200), new Point(5, 0), BulletPicPath, new Size(4, 1));
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet.Add(new Bullet(new Point(_ship.Rect.X + _ship.Size.Width / 2, _ship.Rect.Y + _ship.Size.Height /2), 
                new Point(50, 0), BulletPicPath, new Size(16, 4)));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }
        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 
                60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
        private static void NewLevel()
        {
            for (int i = 0; i < Level; i++)
            {
                int r = Rnd.Next(5, 50);
                _asteroids.Add(new Asteroid(new Point(Rnd.Next(2*_ship.Rect.X, Game.Width), Rnd.Next(0, Game.Height)),
                    new Point(-r / 5, r), AsterPicPath, new Size(50, 50)));
                Asteroid.CreateAsteroid += delegate (string d)
                {
                    Console.WriteLine(d);
                };
                Asteroid.CreateAsteroid += d =>
                {
                    using (var sw = new System.IO.StreamWriter("log.txt", true)) { sw.WriteLine(d); }
                };
            }
            Level += 1;
        }
    }

}