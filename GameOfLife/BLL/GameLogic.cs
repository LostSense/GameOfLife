using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameOfLife.BLL;

namespace GameOfLife.BLL
{
    public static class GameLogic
    {
        public static UnitOfLife[,] Cells { get; set; }

        public static void CreateCells(int Width, int Height, ref System.Windows.Forms.ProgressBar pb)
        {
            Cells = new UnitOfLife[Width, Height];
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int c = 0; c < Cells.GetLength(1); c++)
                {
                    Cells[i, c] = new UnitOfLife();
                    pb.PerformStep();
                }
            }
        }

        public static bool UnitClick(int Width, int Height)
        {
            if (Cells[Width, Height].Alive == true)
            {
                Cells[Width, Height].Alive = false;
                return false;
            }
            else
            {
                Cells[Width, Height].Alive = true;
                return true;
            }
        }

        public static void CheckCells()
        {
            //int fieldCenter = Cells.GetLength(0) / 2;
            //Task t = new Task(CheckMarkedCells, (object)fieldCenter);
            //t.Start();
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int c = 0; c < Cells.GetLength(1); c++)
                {
                    CheckCell(i, c);
                }
            }
            //Task.WaitAny(t);
        }

        //private static void CheckMarkedCells(object from)
        //{
        //    int temp = (int)from;
        //    for (int i = temp; i < Cells.GetLength(0); i++)
        //    {
        //        for (int c = 0; c < Cells.GetLength(1); c++)
        //        {
        //            CheckCell(i, c);
        //        }
        //    }
        //}

        public static void UpdateCellsStatus()
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int c = 0; c < Cells.GetLength(1); c++)
                {
                    Cells[i, c].Alive = Cells[i, c].NextAlive;
                    Cells[i, c].NextAlive = false;
                }
            }
        }

        private static void CheckCell(int x, int y)
        {
            int life = AmountOfLife(x, y);
            switch (life)
            {
                case 3:
                    {
                        Cells[x, y].NextAlive = true;
                    } break;
                case 2:
                    {
                        Cells[x, y].NextAlive = Cells[x, y].Alive;
                    } break;
                default:
                    {
                        Cells[x, y].NextAlive = false;
                    } break;
            }
            //if (life > 3)
            //{
            //    Cells[x, y].NextAlive = false;
            //}
            //else if (life == 3)
            //{
            //    Cells[x, y].NextAlive = true;
            //}
            //else if (life == 2 && Cells[x, y].Alive)
            //{
            //    Cells[x, y].NextAlive = true;
            //}
            //else
            //{
            //    Cells[x, y].NextAlive = false;
            //}
        }

        private static int AmountOfLife(int x, int y)
        {
            int num = 0;
            if ((x > 0 && y>0) && Cells[x-1, y-1].Alive)
                num++;
            if ((y>0) && Cells[x, y - 1].Alive)
                num++;
            if ((y > 0 && x < Cells.GetLength(0)-1) && Cells[x + 1, y - 1].Alive)
                num++;
            if ((x < Cells.GetLength(0)-1) && Cells[x + 1, y].Alive)
                num++;
            if ((x < Cells.GetLength(0)-1 && y < Cells.GetLength(1)-1) && Cells[x + 1, y + 1].Alive)
                num++;
            if ((y < Cells.GetLength(1)-1) && Cells[x, y + 1].Alive)
                num++;
            if ((y < Cells.GetLength(1)-1 && x > 0) && Cells[x - 1, y + 1].Alive)
                num++;
            if ((x>0) && Cells[x - 1, y].Alive)
                num++;

            return num;
        }
        ///TODO: new logic
        //================================================
        public static UnitOfLife2[,] Cells2 { get; set; }
        
        public static void CreateCells2(int Width, int Height, ref System.Windows.Forms.ProgressBar pb)
        {
            Cells2 = new UnitOfLife2[Width, Height];
            for (int i = 0; i < Cells2.GetLength(0); i++)
            {
                for (int c = 0; c < Cells2.GetLength(1); c++)
                {
                    Cells2[i, c] = new UnitOfLife2();
                    pb.PerformStep();
                }
            }
        }

        public static bool UnitClick2(int Width, int Height)
        {
            if (Cells2[Width, Height].Alive == 1)
            {
                Cells2[Width, Height].Alive = 0;
                return false;
            }
            else
            {
                Cells2[Width, Height].Alive = 1;
                return true;
            }
        }

        public static void CheckCells2()
        {
            for (int i = 0; i < Cells2.GetLength(0); i++)
            {
                for (int c = 0; c < Cells2.GetLength(1); c++)
                {
                    CheckCell2(i, c);
                }
            }
        }

        private static void CheckCell2(int x, int y)
        {
            int life = AmountOfLife2(x, y);
            switch (life)
            {
                case 3:
                    {
                        Cells2[x, y].NextAlive = 1;
                    } break;
                case 2:
                    {
                        Cells2[x, y].NextAlive = Cells2[x, y].Alive;
                    } break;
                default:
                    {
                        Cells2[x, y].NextAlive = 0;
                    } break;
            }
        }

        public static void UpdateCellsStatus2()
        {
            for (int i = 0; i < Cells2.GetLength(0); i++)
            {
                for (int c = 0; c < Cells2.GetLength(1); c++)
                {
                    Cells2[i, c].Alive = Cells2[i, c].NextAlive;
                    Cells2[i, c].NextAlive = 0;
                }
            }
        }

        private static int AmountOfLife2(int x, int y)
        {
            int num = 0;
            if ((x > 0 && y > 0) && Cells2[x - 1, y - 1].Alive == 1)
                num++;
            if ((y > 0) && Cells2[x, y - 1].Alive== 1)
                num++;
            if ((y > 0 && x < Cells2.GetLength(0) - 1) && Cells2[x + 1, y - 1].Alive == 1)
                num++;
            if ((x < Cells2.GetLength(0) - 1) && Cells2[x + 1, y].Alive == 1)
                num++;
            if ((x < Cells2.GetLength(0) - 1 && y < Cells2.GetLength(1) - 1) && Cells2[x + 1, y + 1].Alive == 1)
                num++;
            if ((y < Cells2.GetLength(1) - 1) && Cells2[x, y + 1].Alive == 1)
                num++;
            if ((y < Cells2.GetLength(1) - 1 && x > 0) && Cells2[x - 1, y + 1].Alive == 1)
                num++;
            if ((x > 0) && Cells2[x - 1, y].Alive == 1)
                num++;

            return num;
        }
    }
}
