using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace YarvimyakiIlyaAsteroids
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static Asteroid[] asteroids;
        public static BaseObject[] stars;
        public static SpaceShip spaceShip;
        public static List<Bullet> bullets = new List<Bullet>();
        public static Random rand = new Random();
        public static int points = 0;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
        public static void Init(MainForm form)
        {
            form.KeyDown += ActionSpaceShip;
            form.KeyUp += StopSpaceShip;
            form.SizeChanged += Form_SizeChanged;
            form.MaximizeBox = false;
            form.MinimizeBox = false;            
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load(form);
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }        
        /// <summary>
        /// Создание объектов
        /// </summary>
        private static void Load(MainForm form)
        {
            asteroids = new Asteroid[10];
            stars = new BaseObject[10];
            //Создание астеройдов
            try
            {
                for (int i = 0; i < asteroids.Length; i++)
                {
                    asteroids[i] = new Asteroid(new Point(rand.Next(0, 600), rand.Next(0, 600)), new Point(rand.Next(3, 8), 0),
                        new Size(30, 30), i % 5 == 0 ? eTypeAsteroid.BonusStar : eTypeAsteroid.Asteroid);
                    asteroids[i].EventUpdateInfoRewardPoints += form.CreateLabelRewardPoints;
                    asteroids[i].EventUpdateInfoRewardPoints += LogGame.WritenInfoRewardPoints;
                }
            }
            catch (GameObjectException ex)
            {
                DialogResult dialogResult = MessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
                asteroids[9] = new Asteroid(new Point(rand.Next(0, 600), rand.Next(0, 600)), new Point(rand.Next(5, 15), 0),
                    new Size(30, 30), eTypeAsteroid.Asteroid);
            }
            //Создание звезд
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(new Point(rand.Next(0, 600), rand.Next(0, 600)), new Point(i, 0), new Size(rand.Next(1, 4), rand.Next(1, 4)));
            }
            //Создание космического корабля и настройка подписок
            spaceShip = new SpaceShip();
            spaceShip.EventUpdateInfoShields += form.UpdateInfoShields;
            spaceShip.EventUpdateInfoShields += LogGame.WritenInfoShields;
        }

        #region UpdateDraw
        /// <summary>
        /// ОБработчик таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        /// <summary>
        /// Изменения свойств объектов
        /// </summary>
        private static void Update()
        {
            foreach (Asteroid asteroid in asteroids)
            {
                asteroid.Update();
                //CollisionWithAsteroid<SpaceShip>(spaceShip, asteroid);
                if (spaceShip.Collision(asteroid))
                {
                    asteroid.TypeAsteroid = eTypeAsteroid.Bang;
                }
                foreach (Bullet bullet in bullets)
                {
                    //CollisionWithAsteroid<Bullet>(bullet, asteroid);
                    if (bullet.Collision(asteroid))
                    {
                        asteroid.rewardPoints.lableShow = true;
                        asteroid.TypeAsteroid = eTypeAsteroid.Bang;                        
                    }
                    bullet.Update();
                }
            }
            foreach (BaseObject star in stars) star.Update();
            spaceShip.Update();            
            //void CollisionWithAsteroid<T>(T baseObject, Asteroid asteroid) where T : BaseObject
            //{
            //    if (((T)baseObject).Collision(asteroid))
            //    {
            //        asteroid.TypeAsteroid = eTypeAsteroid.Bang;
            //    }
            //};
        }
        /// <summary>
        /// Вывод всех объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (Asteroid asteroid in asteroids) asteroid.Draw();
            foreach (BaseObject star in stars) star.Draw();
            foreach (Bullet bullet in bullets) bullet.Draw();
            spaceShip.Draw();
            Buffer.Render();
        }
        #endregion

        #region ActionSpaceShip
        /// <summary>
        /// Обработчик события формы KeyDown, вызывает метод класса 
        /// корябля для его движения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ActionSpaceShip(object sender, KeyEventArgs e)
        {
            spaceShip.MoveStopSpaceShip(e.KeyCode);
        }
        /// <summary>
        /// Обработчик события формы KeyUP, вызывает метод класса 
        /// корябля для его остановки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void StopSpaceShip(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey && spaceShip.Charge == SpaceShip.MAXCHARGE)
            {
                bullets.Add(spaceShip.Volley());
            }
            else
            {
                spaceShip.MoveStopSpaceShip(e.KeyCode, false);
            }
        }
        #endregion

        /// <summary>
        /// Обработка изменения размера формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (((System.Windows.Forms.Form)sender).Size.Width > 1000
                    || ((System.Windows.Forms.Form)sender).Size.Width < 0
                    || ((System.Windows.Forms.Form)sender).Size.Height > 1000
                    || ((System.Windows.Forms.Form)sender).Size.Height < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                DialogResult dialogResult = MessageBox.Show("Размер формы больше положенной", "", MessageBoxButtons.OK);
                if (dialogResult == DialogResult.OK)
                {
                    Size size = new Size(800, 600);
                    ((System.Windows.Forms.Form)sender).Size = size;
                }
            }
        }
    }
}
