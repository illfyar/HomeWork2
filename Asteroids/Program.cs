using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarvimyakiIlyaAsteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            MainForm form = new MainForm();            
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
