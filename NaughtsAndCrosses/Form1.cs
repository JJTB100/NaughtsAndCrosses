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

        string userMk = CROSS;
        string cpuMK = NOUGHT;

        Button[,] grid;
        public Form1()
        {
            InitializeComponent();
            grid = new Button[,] { { btn00, btn10, btn20 },
                                   { btn01, btn11, btn21 },
                                   { btn02, btn12, btn22 } };
            Wipe();
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
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int xCoord = int.Parse(btn.Name[3].ToString());
            int yCoord = int.Parse(btn.Name[4].ToString());

            if (btn.Text == "")
            {
                btn.Text = userMk; // place O or X
                // check for win
                if (LineCheck(userMk))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            grid[i, j].Text = "";
                        }
                    }
                    
                }
                // switches turn
            }

            
            
            // Debug // MessageBox.Show(xCoord.ToString()+ yCoord.ToString());
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
