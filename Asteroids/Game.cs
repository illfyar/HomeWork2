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
        public static BaseObject[] asteroids;
        public static BaseObject[] stars;
        public static SpaceShip spaceShip;
        public static Queue<BaseObject> bullet;
        public static Random rand = new Random();
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
        public static void Init(Form form)
        {
            form.KeyDown += MoveSpaceShip;
            form.KeyUp += StopSpaceShip;
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
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        /// <summary>
        /// Вывод всех объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject asteroid in asteroids)
                asteroid.Draw();
            foreach (BaseObject star in stars)
                star.Draw();
            spaceShip.Draw();
            Buffer.Render();
        }
        /// <summary>
        /// Создание объектов
        /// </summary>
        private static void Load()
        {
            asteroids = new BaseObject[10];
            stars = new BaseObject[20];
            for (int i = 0; i < asteroids.Length; i++)
            {                
                asteroids[i] = new Asteroid(new Point(rand.Next(0, 600), rand.Next(0, 600)), new Point(15 - i, 15 - i),
                    new Size(30, 30),i%5 == 0 ? eTypeAsteroid.BonusStar : eTypeAsteroid.Asteroid);
            }
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(new Point(rand.Next(0, 600), rand.Next(0, 600)), new Point(i, 0), new Size(rand.Next(1, 3), rand.Next(1, 3)));
            }
            spaceShip = new SpaceShip();
        }
        /// <summary>
        /// Изменения свойств объектов
        /// </summary>
        private static void Update()
        {
            foreach (Asteroid asteroid in asteroids)
            {
                asteroid.Update();
                if (spaceShip.Collision(asteroid))
                {
                    asteroid.TypeAsteroid = eTypeAsteroid.Bang;
                }
            }
            foreach (BaseObject star in stars)
                star.Update();
            spaceShip.Update();
            
        }
        /// <summary>
        /// Обработчик события формы KeyDown, вызывает метод класса 
        /// корябля для его движения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MoveSpaceShip(object sender, KeyEventArgs e)
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
            spaceShip.MoveStopSpaceShip(e.KeyCode,false);
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
