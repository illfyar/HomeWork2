using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarvimyakiIlyaAsteroids
{
    enum eTypeAsteroid { Asteroid, BonusStar, Bang}
    class Asteroid : BaseObject
    {
        //Рисунок атеройда по умолчанию
        private Image currentImage = Image.FromFile(@"Asteroid\Asteroid.png");
        //Соответствие типа астеройда его рисунку
        readonly Dictionary<eTypeAsteroid, Image> typeAsteroidDict = new Dictionary<eTypeAsteroid, Image>()
        { { eTypeAsteroid.Asteroid,Image.FromFile(@"Asteroid\Asteroid.png")}, 
          { eTypeAsteroid.BonusStar,Image.FromFile(@"Asteroid\BonusStar.png")},
          { eTypeAsteroid.Bang,Image.FromFile(@"Asteroid\Bang.png")}};
        //Тип астеройда
        private eTypeAsteroid typeAsteroid;
        //При изменение типа астеройда меняется его рисунок по умолчанию
        public eTypeAsteroid TypeAsteroid
        {
            get
            {
                return typeAsteroid;
            }
            set
            {
                if (typeAsteroidDict.TryGetValue(value, out currentImage))
                {
                    typeAsteroid = value;
                }
            }
        }
        public Asteroid(Point pos, Point dir, Size size,eTypeAsteroid typeAsteroid) : base(pos, dir, size)
        {
            TypeAsteroid = typeAsteroid;
            ChekBaseObject();
        }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            TypeAsteroid = eTypeAsteroid.Asteroid;
        }
        /// <summary>
        /// Прорисовка астеройда
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(currentImage, Pos.X, Pos.Y, Size.Width, Size.Height);
            ChekBaseObject();
        }
        /// <summary>
        /// Изменение свойст астеройда
        /// Если его координаты < 0 по X, то он пеерносится в конец
        /// области игры. Если астеройд был взорван и достиг начала области
        /// игры то его рисунок меняется на стандартный
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width;
                Pos.Y = Game.rand.Next(0, 600);
                Dir.X = Game.rand.Next(15, 30);
                if (TypeAsteroid == eTypeAsteroid.Bang)
                {
                    TypeAsteroid = eTypeAsteroid.Asteroid;
                }
            }
        }
    }
}
