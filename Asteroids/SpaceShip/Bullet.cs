using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarvimyakiIlyaAsteroids
{
    class Bullet : BaseObject
    {
        private Image imageBullet = Image.FromFile(@"SpaceShip\Bullet.png");
        public bool Dead { get; set; } = false;
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override bool Collision(ICollision obj)
        {
            if (Rect.IntersectsWith(obj.Rect))
            {
                Die();
                return true;
            }            
            return false;
        }
        public override void Die()
        {
            Dead = true;
            Pos.X = 801;
            Pos.Y = 601;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(imageBullet, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            if (!Dead)
            {
                Pos.X += Dir.X;
            }
        }       
    }
}
