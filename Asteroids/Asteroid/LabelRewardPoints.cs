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
        public const int TIMELIFE = 50;
        public int timeLife;
        public bool lableShow;

        public LabelRewardPoints()
        {
            this.rewardPoints = new Random().Next(100, 200);
            label = new System.Windows.Forms.Label();
            label.BackColor = Color.Black;
            label.ForeColor = Color.White;
            label.Width = 25;
            label.Height = 15;
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
