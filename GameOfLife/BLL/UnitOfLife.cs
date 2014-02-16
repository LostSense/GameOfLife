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

    public class UnitOfLife2
    {
        public byte Alive { get; set; }
        public byte NextAlive { get; set; }

        public UnitOfLife2()
        {
            Alive = 0;
        }
    }
}
