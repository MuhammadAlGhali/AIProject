using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public static class Rewards
    {

        public const int LEFT = -2;
        public const int RIGHT = -2;
        public const int UP =-3;
        public const int DOWN= -1;

        public static int GetReward(int action)
        {
            switch (action)
            {
                case 0: return LEFT;
                case 1: return UP;
                case 2: return RIGHT;
                case 3: return DOWN;
                default: throw new InvalidOperationException("Wrong Action");
            }
        }
    }
}
