using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class QGrid
    {
        double?[,] q_grid = new double?[42, 4]; // 7x7 grid=42 states and 4 possibile actions
        // a0=left, a1=up, a2=right a3=down

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
                        if ((string)grid[i, j] == "####")
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                q_grid[i * 7 + j, k] = null;
                            }
                        }
                        else if ((string)grid[i, j] == "Empty")
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                q_grid[i * 7 + j, k] = 0;
                            }
                        }
                    }
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
