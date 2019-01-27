using System;
using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Космический корабль
    /// </summary>
    class SpaceShip:BaseObject
    {
        public SpaceShip(Point pos, Point dir, Size size):base(pos, dir,size)
        {

        }
        Image image = Image.FromFile("spaceShip.png");
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y);
        }
        public override void Update()
        {
            Pos.X = Pos.X;
            Pos.Y = Pos.Y;
        }
    }
}
