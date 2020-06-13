using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarvimyakiIlyaAsteroids
{
    class SpaceShip : BaseObject
    {
        //Щиты корябля
        public const int MAXSIELDS = 10;
        private int shields = 100;
        public int Shields { get { return shields; } set { 
                shields = value < 0 ? 0 : value;
                if (value < 0)
                {
                    shields = 0;
                    Die();
                }
                shields = value > 100 ? 100 : value;
            } }
        /// <summary>
        /// делегат для обновления информаци по щитам
        /// </summary>
        /// <param name="damage">Полученный урон</param>
        /// <param name="cuurentValueShilds">Текущая прочность щита</param>
        public delegate void UpdateInfoShields(int damage, int cuurentValueShilds);
        public event UpdateInfoShields EventUpdateInfoShields;
        //Заряды для выстрела
        public const int MAXCHARGE = 40;
        private int charge;
        public int Charge { get { return charge; } set { charge = value; charge = charge > MAXCHARGE ? MAXCHARGE : charge = value; } }
        //модель корябля
        private Image imageSpaceShip = Image.FromFile(@"SpaceShip\Spaceship.png");
        //Скорость корябля
        private int Speed {get;set;}
        public bool Dead { get; set; } = false;
        public SpaceShip(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            StartSettings();
        }
        public SpaceShip()
        {
            StartSettings();
        }
        public void EnergyLow(int n)
        {
            shields -= n;
        }
        //Стартовые настройки корабля
        private void StartSettings()
        {
            Pos = new Point(0, 300);
            Dir = new Point(0, 0);
            Size = new Size(40, 40);
            Speed = 4;
            Charge = MAXCHARGE;
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
            if (Dead)
            {
                return;
            }
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            Charge += 1;
            if (Pos.Y > 560)
            {
                Pos.Y = 560;
            }
            if (Pos.Y < 0)
            {
                Pos.Y = 0;
            }
            if (Pos.X > 760)
            {
                Pos.X = 760;
            }
            if (Pos.X < 0)
            {
                Pos.X = 0;
            }
        }
        /// <summary>
        /// Используется как обработчик событий нажатия 
        /// клавишь клавиатуры. Изменяет скорость корабля.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="move">По умолчанию true, если false то сворость движения = 0</param>
        public void MoveStopSpaceShip(Keys key,bool move = true)
        {
            if (Dead)
            {
                return;
            }
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
        public Bullet Volley()
        {
            if (Dead)
            {
                return null;
            }
            Charge = 0;
            return new Bullet(Pos, new Point(10, 0), new Size(10, 10));
        }
        public override bool Collision(ICollision obj)
        {
            if (Dead)
            {
                return false;
            }
            if (obj is Asteroid)
            {
                Asteroid asteroid = obj as Asteroid;
                if (asteroid.TypeAsteroid == eTypeAsteroid.Asteroid && this.Rect.IntersectsWith(obj.Rect))
                {
                    UpdateValueShields(-1);
                    return true;
                }
                else if (asteroid.TypeAsteroid == eTypeAsteroid.BonusStar && this.Rect.IntersectsWith(obj.Rect))
                {
                    UpdateValueShields(1);
                    return true;
                }                
            }
            return false;

            void UpdateValueShields(int value)
            {
                Random random = new Random();
                int damage = random.Next(10, 20);
                Shields += damage* value;
                if (!Dead)
                {
                    EventUpdateInfoShields(damage, shields);
                }                
            }
        }
        public override void Die()
        {
            Dead = true;
            Size = new Size(70, 70);
            imageSpaceShip = Image.FromFile(@"SpaceShip\Bang.png");
            Game.GameOver();
        }
    }
}
