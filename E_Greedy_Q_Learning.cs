using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class E_Greedy_Q_Learning
    {

        public Tuple<int, int> currentState { get; set; }
        public Grid grid;
        public QGrid q_grid;
        public NGrid n_grid;
        public double learning_rate;
        public double discount_factor = 0.9;
        public double epsilon = 0.1;
        public List<Tuple<int, int>> possibleIntialStates;

        public E_Greedy_Q_Learning(Grid grid, QGrid q_grid, NGrid n_grid, double discount_factor=0.9, double epsilon=0.1)
        {
            this.grid = grid;
            this.q_grid = q_grid;
            this.n_grid = n_grid;
            this.discount_factor = discount_factor;
            this.epsilon = epsilon;
            this.possibleIntialStates = new List<Tuple<int, int>>();
            FindInitialStates();
        }
        public double getLearningRate(NGrid n_grid,Tuple<int,int> state, int action)
        {
            return n_grid.getCellN(state, action);
        }
        private void FindInitialStates()
        {
            for(int i =0; i < grid.GetGrid().GetLength(0); i++)
            {
                for(int j=0; j < grid.GetGrid().GetLength(1); j++)
                {
                    dynamic[,] grid_values = grid.GetGrid();
                    if(grid_values[i,j] is string && ((string)grid_values[i, j]) == "Empty"){
                        possibleIntialStates.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
        }
        //public void PrintInitialStates()
        //{
        //    for(int i=0; i < possibleIntialStates.Count; i++)
        //    {
        //        Console.Write(possibleIntialStates[i] + ", ");
        //    }
        //}
        

        private Tuple<int,int> ApplyAction(Tuple<int, int> currentState ,int action)
        {
            switch (action)
            {
                case 0: return new Tuple<int, int>(currentState.Item1, currentState.Item2 - 1); // go left
                case 1: return new Tuple<int, int>(currentState.Item1 - 1, currentState.Item2); // go up
                case 2: return new Tuple<int, int>(currentState.Item1, currentState.Item2 + 1); // go right
                case 3: return new Tuple<int, int>(currentState.Item1 + 1, currentState.Item2); // go down
                default: return new Tuple<int, int>(-1, -1);
            }
        }

        private double GetNextActionMax(Tuple<int,int> nextState)
        {
            double highest_value = double.MinValue;

            if(q_grid.GetGrid()[nextState.Item1 * 7 + nextState.Item2, 0] is null)
            {
                return 0;
            }

            for (int i = 0; i < 4; i++)
            {
                if (q_grid.GetGrid()[nextState.Item1 * 7 + nextState.Item2, i] > highest_value)
                {
                    highest_value = (double)q_grid.GetGrid()[nextState.Item1 * 7 + nextState.Item2, i];
                }
            }

            return highest_value;
        }
        

        public void Train()
        {
            for(int trial=0; trial < 50000; trial++)
            {
                int steps = 0;

                Tuple<int, int> initialState = possibleIntialStates[new Random().Next(0, possibleIntialStates.Count)];
                this.currentState = initialState;

                while (steps < 100)
                {
                    
                    int next_action = E_Greedy_Action_Selection.Select_NextAction(this);

                    Random drift = new Random();
                    double driftrate = drift.NextDouble();

                    if (driftrate>0.8 && driftrate < 0.9)
                    {
                        next_action = (next_action + 1) % 3;
                    }
                    if(driftrate > 0.9 && driftrate < 1.0)
                    {
                        next_action = (next_action + 3) % 3;
                    }
                    
                    // N(s,a) = N(s,a) + 1
                    n_grid.GetGrid()[this.currentState.Item1 * 7 + this.currentState.Item2, next_action]++;

                    // Q(s,a) = Q(s,a) + 1/N(s,a)(R(s,a) + gamma * max Q(s', a') - Q(s,a))
                    Tuple<int, int> nextQState = ApplyAction(this.currentState, next_action); //Q(s',a')
                    double currentQ_value = (double)q_grid.GetGrid()[this.currentState.Item1 * 7 + this.currentState.Item2, next_action];//Q(s,a)
                    this.learning_rate = 1 / n_grid.getCellN(this.currentState, next_action);
                    q_grid.GetGrid()[this.currentState.Item1 * 7 + this.currentState.Item2, next_action] =
                        currentQ_value + this.learning_rate * (Rewards.GetReward(next_action) + this.discount_factor * GetNextActionMax(nextQState) - currentQ_value);

                    // if next state is not an obstacle set current state to next state
                    if (!(grid.GetGrid()[nextQState.Item1, nextQState.Item2] is string && (string)grid.GetGrid()[nextQState.Item1, nextQState.Item2] == "####"))
                    {
                        this.currentState = nextQState;
                    }

                    // check if terminal state reached
                    if (grid.GetGrid()[this.currentState.Item1, this.currentState.Item2] is int)
                    {
                        break; // stop the trial
                    }

                    steps++;
                }
            }
        }
        
        



    }
}
