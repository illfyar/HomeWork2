using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
    }
}
