using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public static class E_Greedy_Action_Selection
    { 

        public static int Select_NextAction(E_Greedy_Q_Learning q_learn)
        {
            //Initialize a random value between 0 and 1
            Random rnd = new Random();
            double random_value = rnd.NextDouble();
            Tuple<int, int> current_state = q_learn.currentState;
            // If this Value is greater than 0.1 which is epsilon we do the best action
            if(random_value > q_learn.epsilon)
            {

                double? left_QValue = q_learn.q_grid.GetGrid()[current_state.Item1 * 7 + current_state.Item2, 0];
                double? up_QValue = q_learn.q_grid.GetGrid()[current_state.Item1 * 7 + current_state.Item2, 1];
                double? right_QValue = q_learn.q_grid.GetGrid()[current_state.Item1 * 7 + current_state.Item2, 2];
                double? down_QValue = q_learn.q_grid.GetGrid()[current_state.Item1 * 7 + current_state.Item2,3];

                //If we are at the initial move we choose a move at random since we have no best choice for now
                if(left_QValue==up_QValue && up_QValue== right_QValue && right_QValue == down_QValue)
                {
                    return rnd.Next(0, 4);
                }
                //We take the best action as the action who has the highest Q Value at that specific state and direction
                else
                {
                    int best_action = -1;
                    double highest_value = double.MinValue;
                    for(int i =0; i < 4; i++)
                    {
                        if(q_learn.q_grid.GetGrid()[current_state.Item1 * 7 + current_state.Item2, i] > highest_value)
                        {
                            best_action = i;
                            highest_value = (double)q_learn.q_grid.GetGrid()[current_state.Item1 * 7 + current_state.Item2, i];
                        }
                    }

                    return best_action;
                }
            }
            //This is the case were we don't choose the optimal policy where the random number is less than or equal to epsilon.
            //So, we choose a random next action
            else
            {
                return rnd.Next(0, 4);
            }
        }
    }
}
