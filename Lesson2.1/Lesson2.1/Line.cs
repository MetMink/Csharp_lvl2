﻿using System;
using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Линия
    /// </summary>
    class Line:BaseObject
    {
        public Line(Point pos, Point dir, Size size):base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

    }
}
