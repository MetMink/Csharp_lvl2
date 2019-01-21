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

        static Game()
        {

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
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            Buffer.Render();
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
            _objs = new BaseObject[30];
            for (int i = 0; i < 13; i++)
            {
                _objs[i] = new BaseObject(new Point(600, i * 20), new Point(- i, - i), new Size(10, 10));
            }
            for (int i = 17; i< _objs.Length; i++)
            {
                _objs[i] = new Star(new Point(600, i * 20), new Point(- i, 0), new Size(5, 5));
            }
            for (int i = 13; i<=16; i ++)
            {
                if (i == 13) _objs[i] = new Line(new Point(100, 200), new Point(-i, i), new Size(10, 1));
                else if (i == 14) _objs[i] = new Line(new Point(300, 400), new Point(-i, i), new Size(100, 1));
                else if (i == 15) _objs[i] = new Line(new Point(500, 600), new Point(-i, i), new Size(10, 1));
                else if (i == 16) _objs[i] = new Line(new Point(600, 750), new Point(-i, i), new Size(100, 1));
            }

        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
