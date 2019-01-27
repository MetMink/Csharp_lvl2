using System;
using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Планета
    /// </summary>
    class Planet:BaseObject
    {
        public Planet(Point pos, Point dir, Size size):base(pos,dir,size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.Brown, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.FillEllipse(Brushes.Brown, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
