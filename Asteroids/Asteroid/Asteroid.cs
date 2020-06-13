using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarvimyakiIlyaAsteroids
{
    enum eTypeAsteroid { Asteroid, BonusStar, Bang}
    class Asteroid : BaseObject, ICloneable, IComparable<Asteroid>
    {
        //НР астеройда
        public int Health { get; set; } = 3;
        //Рисунок атеройда по умолчанию
        private Image currentImage = Image.FromFile(@"Asteroid\Asteroid.png");
        //Соответствие типа астеройда его рисунку
        readonly Dictionary<eTypeAsteroid, Image> typeAsteroidDict = new Dictionary<eTypeAsteroid, Image>()
        { { eTypeAsteroid.Asteroid,Image.FromFile(@"Asteroid\Asteroid.png")}, 
          { eTypeAsteroid.BonusStar,Image.FromFile(@"Asteroid\BonusStar.png")},
          { eTypeAsteroid.Bang,Image.FromFile(@"Asteroid\Bang.png")}};
        //Тип астеройда
        private eTypeAsteroid typeAsteroid;
        //очки награды
        public LabelRewardPoints rewardPoints;
        //событие срабатывает при уничтожении астеройда
        public delegate void UpdateInfoRewardPoints(LabelRewardPoints rewardPoints);
        public event UpdateInfoRewardPoints EventUpdateInfoRewardPoints;
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
            ChekBaseObject();
            TypeAsteroid = typeAsteroid;
            Health = 1;
            rewardPoints = new LabelRewardPoints();

        }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            TypeAsteroid = eTypeAsteroid.Asteroid;
            Health = 1;
            rewardPoints = new LabelRewardPoints();
        }
        /// <summary>
        /// Прорисовка астеройда
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(currentImage, Pos.X, Pos.Y, Size.Width, Size.Height);
            //ChekBaseObject();
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
                Pos.Y = Game.rand.Next(0, 560);
                Dir.X = Game.rand.Next(1, 5);
                if (new Random().Next(1,100) < 5)
                {
                    TypeAsteroid = eTypeAsteroid.BonusStar;
                }
                else
                {
                    TypeAsteroid = eTypeAsteroid.Asteroid;
                    rewardPoints.ResetPoints();
                }
            }
            if (rewardPoints.timeLife > 0)
            {
                rewardPoints.timeLife += 1;
            }
            if (rewardPoints.timeLife > LabelRewardPoints.TIMELIFE)
            {
                rewardPoints.lableShow = false;
                rewardPoints.timeLife = 0;
                EventUpdateInfoRewardPoints(rewardPoints);
                Game.rewardPoints += rewardPoints.rewardPoints;
            }
        }
        /// <summary>
        /// Клонирование астеройда
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Asteroid(Pos, Dir, Size, typeAsteroid) { Health = Health };
        }
        /// <summary>
        /// метод для сравнения
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Asteroid other)
        {
            if (Health > other.Health)
                return 1;
            if (Health < other.Health)
                return -1;
            return 0;
        }
        public override void Die()
        {
            if (TypeAsteroid == eTypeAsteroid.Asteroid)
            {
                TypeAsteroid = eTypeAsteroid.Bang;
            }
            else if(TypeAsteroid == eTypeAsteroid.BonusStar)
            {
                Pos.X = 1100;
                Pos.Y = new Random().Next(0, 560);
            }
            rewardPoints.lableShow = true;
            rewardPoints.timeLife = 1;
            EventUpdateInfoRewardPoints(rewardPoints);
            rewardPoints.label.Location = Pos;
        }
    }
}
