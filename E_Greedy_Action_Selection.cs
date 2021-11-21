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
            Random rnd = new Random();
            double random_value = rnd.NextDouble();
            Tuple<int, int> current_state = q_learn.currentState;
            if(random_value > q_learn.epsilon)
            {
                double? left_reward = q_learn.q_grid.GetGrid()[current_state.Item1 * 7 + current_state.Item2, 0];
                double? up_reward = q_learn.q_grid.GetGrid()[current_state.Item1 * 7 + current_state.Item2, 1];
                double? right_reward = q_learn.q_grid.GetGrid()[current_state.Item1 * 7 + current_state.Item2, 2];
                double? down_reward = q_learn.q_grid.GetGrid()[current_state.Item1 * 7 + current_state.Item2,3];

                if(left_reward==up_reward && up_reward==right_reward && right_reward == down_reward)
                {
                    return rnd.Next(0, 4);
                }
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
            else
            {
                return rnd.Next(0, 4);
            }
        }
    }
}
