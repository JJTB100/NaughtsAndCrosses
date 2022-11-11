using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaughtsAndCrosses
{
    public partial class Form1 : Form
    {
        
        const string CROSS = "X";
        const string NOUGHT = "O";

        int TurnNum = 0;

        string userMk = CROSS;
        string cpuMk = NOUGHT;

        string turn = "";

        Button[,] grid;
        public Form1()
        {
            InitializeComponent();
            grid = new Button[,] { { btn00, btn10, btn20 },
                                   { btn01, btn11, btn21 },
                                   { btn02, btn12, btn22 } };
            Wipe();
            turn = userMk;
            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            TurnNum++;
            Console.WriteLine(TurnNum);
            Button btn = (Button)sender;
            int xCoord = int.Parse(btn.Name[3].ToString());
            int yCoord = int.Parse(btn.Name[4].ToString());

            HaveTurn(btn);
            
            // Debug // MessageBox.Show(xCoord.ToString()+ yCoord.ToString());
        }

        void HaveTurn(Button btn)
        {
            if (btn.Text == "")
            {
                btn.Text = turn; // place O or X
                // check for win
                if (LineCheck(turn))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            grid[i, j].Text = "";
                        }
                    }

                }
                //check for draw
                if (DrawCheck())
                {
                    Wipe();

                }

                // switches turn
                if (turn == userMk)
                {
                    turn = cpuMk;
                }
                else
                {
                    turn = userMk;
                }
                // Increment Turn Number

            }
        }

        private void Wipe()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j].Text = "";
                }
            }
            TurnNum = 0;
        }

        private bool DrawCheck()
        {
            if (TurnNum == 9)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private bool LineCheck(string mark)
        {
            bool win = false;

            for (int i=0; i<3; i++)
            {
                // check the vertical lines
                if (grid[i,0].Text == mark & grid[i,1].Text == mark & grid[i,2].Text == mark)
                {
                    win = true;
                }
            }
            for (int j=0; j<3; j++)
            {
                // check the horizontal lines
                if (grid[0,j].Text == mark & grid[1,j].Text == mark & grid[2,j].Text == mark)
                {
                    win = true;
                }
            }
            // check the diagonal line for the +ve gradient
            if (grid[0, 0].Text == mark & grid[1, 1].Text == mark & grid[2, 2].Text == mark)
            {
                win = true;
            }
            // check the diagonal line for the -ve gradient
            if (grid[0, 2].Text == mark & grid[1, 1].Text == mark & grid[2, 0].Text == mark)
            {
                win = true;
            }
            if (win)
            {
                MessageBox.Show(mark + " has won");
                return true;
            }
            return false;

        }
    }
}
