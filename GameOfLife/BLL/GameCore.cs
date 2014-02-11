using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.BLL
{
    class GameCore
    {
        private static GameCore g;
        private System.Threading.Thread t;
        private static bool coreCreated = false;
        private GameCore()
        {

        }

        public static GameCore CreateCore()
        {
            if (coreCreated)
            {
                return g;
            }
            else
            {
                g = new GameCore();
                coreCreated = true;
                return g;
            }
        }
    }
}
