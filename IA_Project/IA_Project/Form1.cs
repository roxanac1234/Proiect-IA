using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IA_Project
{
    public partial class GameForm : Form
    {
        private Rectangle[] boardColumns;
        private int[,] Board;
        private int turn;
        
       


        public GameForm()
        {
            InitializeComponent();
            this.boardColumns = new Rectangle[7];
            this.Board = new int[6, 7];
            this.turn = 2;
        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    // Click on the link below to continue learning how to build a desktop app using WinForms!
        //    System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        //}

        private void GameForm_Paint(Object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Blue, 24, 24, 340, 300);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 0)
                    {
                        this.boardColumns[j] = new Rectangle(32 + 48 * j, 24, 32, 300);
                    }
                    e.Graphics.FillEllipse(Brushes.White, 32 + 48 * j, 32 + 48 * i, 32, 32);
                }
            }
        }

        private void GameBoard_MouseClick(Object sender, MouseEventArgs e)
        {
            int columnIndex = this.columnNumber(e.Location);
            if (columnIndex != -1)
            {
                int rowIndex = this.EmptyRow(columnIndex);
                if (rowIndex != -1)
                {
                    this.Board[rowIndex, columnIndex] = this.turn;
                    if (this.turn == 1)
                    {
                        Graphics g = this.CreateGraphics();
                        g.FillEllipse(Brushes.Red, 32 + 48 * columnIndex, 32 + 48 * rowIndex, 32, 32);


                    }
                    else
                        if (this.turn == 2)
                    {
                        Graphics g = this.CreateGraphics();
                        g.FillEllipse(Brushes.Yellow, 32 + 48 * columnIndex, 32 + 48 * rowIndex, 32, 32);


                    }
                }
            }
        }

        private int columnNumber(Point mouse)
        {
            for (int i = 0; i < this.boardColumns.Length; i++)
            {
                if ((mouse.X >= this.boardColumns[i].X) && (mouse.Y >= this.boardColumns[i].Y))
                {
                    if (mouse.X <= this.boardColumns[i].X + this.boardColumns[i].Width && mouse.Y <= this.boardColumns[i].Y + this.boardColumns[i].Height)
                    {
                        return i;
                    }
                }

            }

            return -1;

        }
        private int EmptyRow(int col)
        {
            for(int i = 5; i >= 0; i--)
            {
                if (this.Board[i, col] == 0)
                    return i;
            }
            return -1;
        }

       
    }
}
