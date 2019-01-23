using System;
using System.Drawing;

namespace MyGame
{
    class SpaceShip:BaseObject
    {
        public SpaceShip(Point pos, Point dir, Size size):base(pos, dir,size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image.FromFile("spaceShip.png"), Pos.X, Pos.Y);
        }
        //public override void Update()
        //{
            
        //}
    }
}
