using System;

namespace AIProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initializing Grid, Q-Grid, N-Grid, Q-learning, and E-Greedy algorithm
            Grid MDP = new Grid();
            QGrid q_grid = new QGrid(MDP);
            NGrid n_grid = new NGrid(MDP);
            E_Greedy_Q_Learning q_learning = new E_Greedy_Q_Learning(MDP, q_grid, n_grid);
            OptimalPolicyGrid OP_grid = new OptimalPolicyGrid();

            //Start the learning Process and Print the output Grids
            q_learning.Train();
            Console.WriteLine("Optimal Policy Grid: ");
            Console.WriteLine();
            OP_grid.ShowOP(q_grid);
            Console.WriteLine();
            Console.WriteLine("Frequency Grid: ");
            Console.WriteLine();
            n_grid.printGrid();
            Console.WriteLine();
            Console.WriteLine("Q-Values Grid: ");
            Console.WriteLine();
            q_grid.printGrid();

        }
    }
}
