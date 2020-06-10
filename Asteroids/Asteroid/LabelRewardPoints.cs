using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace YarvimyakiIlyaAsteroids
{
    public class LabelRewardPoints
    {
        public int rewardPoints;
        public System.Windows.Forms.Label label;
        public const int TIMELIFE = 40;
        public int timeLife;
        public bool lableShow;

        public LabelRewardPoints(Point pos)
        {
            this.rewardPoints = new Random().Next(100, 200);
            label = new System.Windows.Forms.Label();
            label.Location = pos;
            label.BackColor = Color.Black;
            label.ForeColor = Color.White;
            label.Text = rewardPoints.ToString();
            timeLife = 0;
            lableShow = false;
        }
        public void ResetPoints()
        {
            rewardPoints = new Random().Next(100, 200);
        }
    }
}
