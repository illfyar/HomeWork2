using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.RegularExpressions;

namespace YarvimyakiIlyaAsteroids
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public Rectangle Rect => new Rectangle(Pos,Size);

        public BaseObject(Point pos, Point dir, Size size)
        {

            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public BaseObject() { }
        /// <summary>
        /// Прорисовка объекта
        /// </summary>
        public abstract void Draw();        
        /// <summary>
        /// Обновление свойств объектов
        /// </summary>
        public abstract void Update();
        /// <summary>
        /// Признак столкновения объектов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Collision(ICollision obj)
        {
            return this.Rect.IntersectsWith(obj.Rect);
        }
        public void ChekBaseObject() 
        { 
            string message = Environment.NewLine + ChekPosBaseObject() + Environment.NewLine + ChekSizeBaseObject();
            if (message != "\r\n\r\n")
            {
                throw new GameObjectException(message);
            }
        }
        public string ChekPosBaseObject()
        {
            if (Pos.X < 0 || Pos.Y < 0 || Pos.X > 800 || Pos.Y > 600)
            {
                return $"Объект в не карты игры(X{Pos.X};Y{Pos.Y})";
            };
            return "";
        }
        public string ChekSizeBaseObject()
        {
            if (Size.Height < 0 || Size.Width < 0)
            {
                return $"Объект имеет отрицательный размер(Height{Size.Height};Width{Size.Width})";
            };
            return "";
        }
    }
}
