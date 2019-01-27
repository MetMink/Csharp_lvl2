using System;
using System.Drawing;

namespace MyGame
{
    class Bullets:BaseObject
    {
        public Bullets(Point pos, Point dir, Size size):base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + 3;  
        }
    }
}
