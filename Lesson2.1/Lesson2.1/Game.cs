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
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static Random random = new Random();
        
        static Game()
        {

        }
        public static int Random(int min, int max)
        {
            int num = random.Next(min, max);
            return num;
        }
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Load();
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
        public static void Load()
        {
            _objs = new BaseObject[33];
            int x, y;
            for (int i = 0; i < _objs.Length/3; i++)
            {
                x = Random(10, 599);
                y = Random(10, 799);
                _objs[i] = new BaseObject(new Point(x, y), new Point(- i, - i), new Size(1, 1));
            }
            for (int i = _objs.Length/3; i< _objs.Length - 8; i++)
            {
                x = Random(10, 599);
                y = Random(10, 799);
                _objs[i] = new Star(new Point(x, y), new Point(- i, 0), new Size(5, 5));
            }
            for (int i = _objs.Length - 8; i<=_objs.Length-2; i ++)
            {
                x = Random(10, 599);
                y = Random(10, 799);
                _objs[i] = new Line(new Point(x, y), new Point(-i, i), new Size(10, 1));
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
