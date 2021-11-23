using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class NGrid
    {
        int?[,] n_grid = new int?[42, 4]; // 6x7 rows = 42 states and columns = 4 actions
                                          // 0=left, 1=up, 2=right 3=down

        public int?[,] GetGrid()
        {
            return this.n_grid;
        }

        public NGrid(Grid mainGrid)
        {
            Initialize(mainGrid);
        }

        private void Initialize(Grid mainGrid)
        {

            dynamic[,] grid = mainGrid.GetGrid();

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] is string)
                    {
                        //If the Value in the Basic Grid is #### replace it with null which represents a wall which has no N-values since no moves can be done in this square
                        if ((string)grid[i, j] == "####")
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                n_grid[i * 7 + j, k] = null;
                            }
                        }
                        //If the Value in the Basic Grid is Empty replace it with 0 which represents a wall which has 0 N-values for now
                        else if ((string)grid[i, j] == "Empty")
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                n_grid[i * 7 + j, k] = 0;
                            }
                        }
                    }
                    //This is the case of terminal states we replace all N-values with 1 N-value which is the value of the terminal state
                    else
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            n_grid[i * 7 + j, k] = grid[i, j];
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
                    Console.Write(" " + (this.n_grid[i, j] is null ? "X" : this.n_grid[i, j]) + " ");
                }
                Console.Write("\n");
            }
        }
        //Get the Value of the cell for a specific action
        //I did this function to simplify the code and use this function whenever i want the Frequency at the cell with the direction specified
        public int getCellN(Tuple<int, int> state, int action)
        {
           int? result = n_grid[state.Item1*7+state.Item2, action];
            if (result!=null)
            {
                return (int)result;
            }
            else
            {
                return -1;
            }
            
        }
    }
}
