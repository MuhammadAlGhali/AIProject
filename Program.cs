using System;

namespace AIProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid MDP = new Grid();
            QGrid q_grid = new QGrid(MDP);
            NGrid n_grid = new NGrid(MDP);
            E_Greedy_Q_Learning q_learning = new E_Greedy_Q_Learning(MDP, q_grid, n_grid);
            OptimalPolicyGrid OP_grid = new OptimalPolicyGrid();

            //MDP.printGrid();
            //Console.WriteLine();
            //q_grid.printGrid();
            //Console.WriteLine();
            //n_grid.printGrid();
            //Console.WriteLine();
            //q_learning.PrintInitialStates();
            q_grid.printGrid();
            Console.WriteLine();
            q_learning.Train();
            OP_grid.ShowOP(q_grid,MDP);
            q_grid.printGrid();

        }
    }
}
