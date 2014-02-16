using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.BLL;
using System.Timers;

namespace GameOfLife
{
    public partial class Form1
    {
        int speedOfLifeChange;
        int Generation;
        bool gameWork;
        System.Threading.Thread WorkThread;

        private void UnitClick(int x, int y)
        {
            //bool Check_Life = GameLogic.UnitClick(x, y);
            bool Check_Life = GameLogic.UnitClick2(x, y);
            if (Check_Life)
            {
                DrawRedRect(x*10, y*10);
            }
            else
            {
                DrawWhiteRect(x*10, y*10);
            }
            this.pictureBox1.Refresh();
        }

        private int? NumValidation(string text)
        {
            int num;
            bool temp = int.TryParse(text, out num);
            return num;
        }

        private void FieldValidation(int? x, int? y)
        {
            labelError.ForeColor = System.Drawing.Color.Red;
            if (x == 0 && y == 0)
            {
                LabelError_BothParametersError();
                labelError.Visible = true;
                labelError.Refresh();
            }
            else if (x == 0)
            {
                LabelError_WidthParameterError();
                labelError.Visible = true;
                labelError.Refresh();
            }
            else if (y == 0)
            {
                LabelError_HeightParameterError();
                labelError.Visible = true;
                labelError.Refresh();
            }
            else
            {
                labelError.Visible = false;
                labelError.Refresh();
                progressBar1.Value = 0;
                progressBar1.Maximum = ((int)x * (int)y)*2;
                progressBar1.Step = 1;
                //============================================================
                
                this.AutoScroll = true;
                this.ScrollControlIntoView(pictureBox1);
                System.Drawing.Point p = new System.Drawing.Point(10,10);
                pictureBox1.AutoScrollOffset = p;

                //pictureBox1.AutoScrollOffset = p;

                //============================================================
                PrintField((int)x, (int)y);
                //GameLogic.CreateCells((int)x, (int)y, ref progressBar1);
                GameLogic.CreateCells2((int)x, (int)y, ref progressBar1);
                Generation = 0;
            }
        }

        private void StartGame()
        {
            
            if (!gameWork)
            {
                speedOfLifeChange = 0;
                gameWork = true;
                ChangeButtonText();
                //WorkThread = new System.Threading.Thread(GameWork);
                WorkThread = new System.Threading.Thread(GameWork2);
                WorkThread.Start();
            }
            else
            {
                gameWork = false;
                ChangeButtonText();
            }
        }

        private void AddGeneration()
        {
            this.labelGeneration.Text = this.Generation.ToString();
        }

        private void GameWork()
        {
            #region Actions
            Action<int, int> RedRect = new Action<int, int>(DrawRedRect);
            Action<int, int> whiteRect = new Action<int, int>(DrawWhiteRect);
            Action refreshPicBox = new Action(this.pictureBox1.Refresh);
            Action addG = new Action(AddGeneration);
            Action<long> AddTimeSpeed = new Action<long>(ChangeTimeSpeed); 
            #endregion
            System.Diagnostics.Stopwatch sw;
            Timer t = new Timer(2000);
            t.AutoReset = true;
            t.Elapsed += t_Elapsed;
            t.Start();
            do
            {
                sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                GameLogic.CheckCells();
                try
                {
                    #region For cicle
                    for (int i = 0; i < GameLogic.Cells.GetLength(0); i++)
                    {
                        for (int c = 0; c < GameLogic.Cells.GetLength(1); c++)
                        {
                            if (!(GameLogic.Cells[i, c].Alive && GameLogic.Cells[i, c].NextAlive) || !(!GameLogic.Cells[i, c].Alive && !GameLogic.Cells[i, c].NextAlive))
                            {
                                if (GameLogic.Cells[i, c].NextAlive)
                                {
                                    this.Invoke(RedRect, i * 10, c * 10);

                                }
                                else
                                {
                                    this.Invoke(whiteRect, i * 10, c * 10);
                                }
                            }
                        }
                    } 
                    #endregion
                    this.Invoke(refreshPicBox);
                    Generation++;
                    this.Invoke(addG);
                    GameLogic.UpdateCellsStatus();
                    System.Threading.Thread.Sleep(speedOfLifeChange);
                    sw.Stop();
                    this.Invoke(AddTimeSpeed, sw.ElapsedMilliseconds);
                }
                catch
                {
                    t.Stop();
                    t.Dispose();
                    WorkThread.Abort();
                }
            } while (gameWork);
        }

        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            int SpeedOfGame;
            bool check = int.TryParse(textBoxOfSpeed.Text, out SpeedOfGame);
            if (check)
            {
                speedOfLifeChange = SpeedOfGame;
            }
        }

        //===================================================
        private void GameWork2()
        {
            #region Actions
            Action<int, int> RedRect = new Action<int, int>(DrawRedRect);
            Action<int, int> whiteRect = new Action<int, int>(DrawWhiteRect);
            Action refreshPicBox = new Action(this.pictureBox1.Refresh);
            Action addG = new Action(AddGeneration);
            Action<long> AddTimeSpeed = new Action<long>(ChangeTimeSpeed);
            #endregion
            System.Diagnostics.Stopwatch sw;
            Timer t = new Timer(2000);
            t.AutoReset = true;
            t.Elapsed += t_Elapsed;
            t.Start();
            do
            {
                sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                GameLogic.CheckCells2();
                try
                {
                    #region For cicle
                    for (int i = 0; i < GameLogic.Cells2.GetLength(0); i++)
                    {
                        for (int c = 0; c < GameLogic.Cells2.GetLength(1); c++)
                        {
                            if (!(GameLogic.Cells2[i, c].Alive == GameLogic.Cells2[i, c].NextAlive))
                            {
                                if (GameLogic.Cells2[i, c].NextAlive == 1)
                                {
                                    this.Invoke(RedRect, i * 10, c * 10);

                                }
                                else
                                {
                                    this.Invoke(whiteRect, i * 10, c * 10);
                                }
                            }
                        }
                    }
                    #endregion
                    this.Invoke(refreshPicBox);
                    Generation++;
                    this.Invoke(addG);
                    GameLogic.UpdateCellsStatus2();
                    System.Threading.Thread.Sleep(speedOfLifeChange);
                    sw.Stop();
                    this.Invoke(AddTimeSpeed, sw.ElapsedMilliseconds);
                }
                catch
                {
                    t.Stop();
                    t.Dispose();
                    WorkThread.Abort();
                }
            } while (gameWork);
        }
    }
}
