using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarvimyakiIlyaAsteroids
{
    public partial class MainForm : Form
    {
        int rewardPoints = 0;
        private static int maxShields = SpaceShip.MAXSIELDS;
        public MainForm()
        {
            InitializeComponent();            
        }
        public void UpdateInfoShields(int damage, int currenValueShields)
        {
            ShieldsBar.Value = currenValueShields < 0 ? 0 : currenValueShields;
            ShieldsLabel.Text = ShieldsBar.Value.ToString();
        }
        public void CreateLabelRewardPoints(LabelRewardPoints labelRewardPoints)
        {
            if (labelRewardPoints.lableShow)
            {
                rewardPoints += labelRewardPoints.rewardPoints;
                this.Controls.Add(labelRewardPoints.label);
                rewardPointsLabel.Text = rewardPoints.ToString();
            }
            else
            {
                if (this.Controls.Contains(labelRewardPoints.label))
                {
                    this.Controls.Remove(labelRewardPoints.label);
                }                
            }
            
        }
    }
}
