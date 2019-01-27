using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MyGame
{
    /// <summary>
    /// Абстрактный класс описывающий базовый объект
    /// </summary>
    abstract class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            if (size.Height < 0 || size.Width < 0)
            {
                throw new GameObjectExeption("Размер не может быть отрицательным");
            }
        }
        /// <summary>
        /// Метод, описывающий, как будет выглядеть объект
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// Метод, описывающий поведение объекта
        /// </summary>
        public abstract void Update();
    }
}
