using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class QGrid
    {
        double?[,] q_grid = new double?[42, 4]; // 6x7 rows=42 states and columns=4 possibile actions
        //Therefore we have 42 states and 4 actions and Q-Tables shows each state with all Q-values for all States
        // 0=left, 1=up, 2=right 3=down

        public double?[,] GetGrid()
        {
            return this.q_grid;
        }

        public QGrid(Grid mainGrid)
        {
            Initialize(mainGrid);
        }

        private void Initialize(Grid mainGrid)
        {
            dynamic[,] grid = mainGrid.GetGrid();

            for (int i =0; i < grid.GetLength(0); i++)
            {
                for(int j=0; j < grid.GetLength(1); j++)
                {
                    if(grid[i,j] is string)
                    {
                        //If the Value in the Basic Grid is #### replace it with null which represents a wall which has no Q-values
                        if ((string)grid[i, j] == "####")
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                q_grid[i * 7 + j, k] = null;
                            }
                        }
                        //If the Value in the Basic Grid is Empty replace it with 0 which represents an Empty unaccessed cell which has 0 Q-values for now
                        else if ((string)grid[i, j] == "Empty")
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                q_grid[i * 7 + j, k] = 0;
                            }
                        }
                    }
                    //This is the case of terminal states we replace all Q-values with 1 Q-value which is the value of the terminal state
                    else
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            q_grid[i * 7 + j, k] = grid[i,j];
                        }
                    }
                }
            }
        }

        public void printGrid()
        {
            for (int i = 0; i < 42; i++)
            {
                Console.Write($"({(i / 7)}, {(i % 7)}): ");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(" " + (this.q_grid[i,j] is null ? "X" : this.q_grid[i,j]) + " ");
                }
                Console.Write("\n");
            }
        }
    }
}
