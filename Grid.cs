using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class Grid
    {
        dynamic[,] gridworld = new dynamic[6, 7]
        {
                {-50,-50,-50,-50,-50,-50,-50},
                {-50,"Empty","Empty","Empty","Empty","####",-50},
                {-50,"####","Empty","Empty","####","Empty",-50},
                {-50,"####","Empty",+100,"####","Empty",-50},
                {-50,"Empty","Empty","Empty","Empty","Empty",-50},
                {-50,-50,-50,-50,-50,-50,-50},
        };

        public dynamic[,] GetGrid()
        {
            return gridworld;
        }

        public void printGrid()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j=0; j < 7; j++)
                {
                    Console.Write(" "+ this.gridworld[i, j]+" ");
                }
                Console.Write("\n");
            }
            
        }
    }
}
