using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public partial class Form1
    {
        private void LabelError_BothParametersError()
        {
            labelError.Text = "Both parameters isn't valid";
        }

        private void LabelError_WidthParameterError()
        {
            labelError.Text = "Width parameter isn't valid";
        }

        private void LabelError_HeightParameterError()
        {
            labelError.Text = "Height parameter isn't valid";
        }

        private void PrintField(int Width, int Height)
        {
            //Validation and growing for main form
            if (Height > 15)
            {
                this.Size = new System.Drawing.Size(this.Size.Width, Height*10 + 150);
            }
            if (Width > 25)
            {
                this.Size = new System.Drawing.Size(Width*10 + 50, this.Size.Height);
            }
            this.Refresh();
            //Binding field Graphics to ImageBox
            pictureBox1.Size = new System.Drawing.Size(Width*10 + 1, Height*10 + 1);
            Bitmap area = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = area;
            graphics = Graphics.FromImage(area);
            //drawing grid
            Point one;
            Point two;
            for (int i = 0; i < pictureBox1.Size.Width; i += 10)
            {
                one = new Point(i, 0);
                two = new Point(i, pictureBox1.Size.Height);
                graphics.DrawLine(Pens.Black, one, two);
            }
            for (int i = 0; i < pictureBox1.Size.Height; i += 10)
            {
                one = new Point(0, i);
                two = new Point(pictureBox1.Size.Width, i);
                graphics.DrawLine(Pens.Black, one, two);
            }
            //===================
            //drawing boxes
            for (int i = 0; i < pictureBox1.Size.Height; i += 10)
            {
                for (int c = 0; c < pictureBox1.Size.Width; c += 10)
                {
                    DrawWhiteRect(c, i);
                    this.progressBar1.PerformStep();
                }
            }
        }

        public void DrawRedRect(int x, int y)
        {
            graphics.FillRectangle(new System.Drawing.SolidBrush(Color.Red), new Rectangle(x+1, y+1, 9, 9));
        }

        private void ChangeButtonText()
        {
            if (this.gameWork)
            {
                this.StartGameBut.Text = "Stop";
            }
            else
            {
                this.StartGameBut.Text = "Start";
            }
            this.StartGameBut.Refresh();
        }

        public void DrawWhiteRect(int x, int y)
        {
            graphics.FillRectangle(new System.Drawing.SolidBrush(Color.White), new Rectangle(x + 1, y + 1, 9, 9));
        }
    }
}
