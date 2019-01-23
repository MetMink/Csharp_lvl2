﻿using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MyGame
{
        class BaseObject
        {
            protected Point Pos;
            protected Point Dir;
            protected Size Size;
            public BaseObject(Point pos, Point dir, Size size)
            {
                Pos = pos;
                Dir = dir;
                Size = size;
            }
        public virtual void Draw()
            {
            //Game.Buffer.Graphics.DrawImage(Image asteroid.png, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(Image.FromFile("asteroid1.png"), Pos.X, Pos.Y);
            }
        public virtual void Update()
            {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }

        }
}
