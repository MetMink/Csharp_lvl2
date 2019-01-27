using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        private static Asteroid[] _asteroid;
        private static Bullets _bullet;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static Random random = new Random();
        const int max = 1000;
        const int min = 0;
        
        static Game()
        {

        }
        public static int Random(int min, int max)
        {
            int num = random.Next(min, max);
            return num;
        }
        /// <summary>
        /// Создание буфера и задание интервала, с которым будут отрисовываться объекты и обновляться их позиция
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            if ((Width < min || Height < min)||(Width > max||Height > max))
            {
                throw new ArgumentOutOfRangeException();
            }
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Load();
        }
        /// <summary>
        /// Отрисовка объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            foreach (Asteroid ast in _asteroid)
            {
                ast.Draw();
            }
            _bullet.Draw();

            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (Asteroid ast in _asteroid)
                ast.Update();
            _bullet.Draw();
        }
        /// <summary>
        /// Создание экземпляров класса
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[33];
            _asteroid = new Asteroid[10];
            _bullet = new Bullets(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            int x, y;
            for (int i = 0; i < _asteroid.Length; i++)
            {
                _asteroid[i] = new Asteroid(new Point(Random(10, 599), Random(10, 799)), new Point(2 * i, -i), new Size(1, 1));
            }
            for (int i = 0; i< _objs.Length - 8; i++)
            {
                _objs[i] = new Star(new Point(Random(10, 599), Random(10, 799)), new Point(- i, 0), new Size(5, 5));
            }
            for (int i = _objs.Length - 8; i<=_objs.Length-2; i ++)
            {

                _objs[i] = new Line(new Point(Random(10, 599), Random(10, 799)), new Point(-5*i, i), new Size(10, 1));
            }
            for (int i = _objs.Length - 2;i < _objs.Length ; i++)
            {
                _objs[i] = new Planet(new Point(600, 100), new Point(-i/15, 0), new Size(200, 200));
            }
            for (int i = _objs.Length - 1; i < _objs.Length; i++)
            {
                _objs[i] = new SpaceShip(new Point(200, 350), new Point(0, 0), new Size(1, 1));
            }

        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
