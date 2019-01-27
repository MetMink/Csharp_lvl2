using System;
using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Астероид
    /// </summary>
    class Asteroid:BaseObject
    {
        public int Power { get; set; }
        Image image = Image.FromFile("asteroid1.png");
        public Asteroid(Point pos, Point dir, Size size):base(pos,dir,size)
        {
            Power = 1;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y);
        }
        public override void Update()
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
