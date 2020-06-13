using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace YarvimyakiIlyaAsteroids
{
    static class LogGame
    {
        public static void WritenInfoShields(int damage,int currentValueShields)
        {
            Console.WriteLine($"Полученный урон = {damage}. Прочность щита = {currentValueShields}");
        }
        public static void WritenInfoRewardPoints(LabelRewardPoints label)
        {
            if (label.lableShow)
                Console.WriteLine($"Награда за уничтожение = {label.rewardPoints}");
        }
        public static void DataGameOver(string str)
        {
            Console.WriteLine(str);
        }
    }
}
