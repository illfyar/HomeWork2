using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarvimyakiIlyaAsteroids
{
    class SpaceShip : BaseObject
    {
        //модель корябля
        private Image imageSpaceShip = Image.FromFile(@"SpaceShip\Spaceship.png");
        //Скорость корябля
        private int Speed {get;set;}        
        public SpaceShip(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            StartSettings();
        }
        public SpaceShip()
        {
            StartSettings();
        }
        //Стартовые настройки корабля
        private void StartSettings()
        {
            Pos = new Point(0, 300);
            Dir = new Point(0, 0);
            Size = new Size(40, 40);
            Speed = 6;
        }
        /// <summary>
        /// Прорисовка корябля
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(imageSpaceShip, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// Метод используется для изменения позиции коробля
        /// отображая таким образом его движение
        /// </summary>
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
        }
        /// <summary>
        /// Используется как обработчик событий нажатия 
        /// клавишь клавиатуры. Изменяет скорость корабля.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="move">По умолчанию true, если false то сворость движения = 0</param>
        public void MoveStopSpaceShip(Keys key,bool move = true)
        {
            if (key == Keys.Up || key == Keys.W)
            {
                Dir.Y = move? -1*Speed : 0;
            }else if(key == Keys.Right || key == Keys.D)
            {
                Dir.X = move ? Speed : 0;
            }
            else if (key == Keys.Down|| key == Keys.S)
            {
                Dir.Y = move ? Speed : 0;
            }
            else if (key == Keys.Left|| key == Keys.A)
            {
                Dir.X = move ? -1 * Speed : 0;
            }
        }
    }
}
