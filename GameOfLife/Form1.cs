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

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        
        System.Drawing.Graphics graphics;
        public Form1()
        {
            
            InitializeComponent();
            this.StartGameBut.Enabled = false;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 10;
            int y = e.Y / 10;
            UnitClick(x, y);
        }

        private void CreateField(object sender, EventArgs e)
        {
            int? FieldWidth = NumValidation(textBoxWidth.Text);
            int? FieldHeight = NumValidation(textBoxHeight.Text);
            FieldValidation(FieldWidth, FieldHeight);
            this.StartGameBut.Enabled = true;
        }

        private void Start(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}
