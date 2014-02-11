using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameOfLife.BLL
{
    public class UnitOfLife
    {
        public bool Alive { get; set; }
        public bool NextAlive { get; set; }

        public UnitOfLife()
        {
            Alive = false;
        }
    }
}
