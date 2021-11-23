using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class OptimalPolicyGrid
    {
       public void ShowOP(QGrid q)
        {
            var myQGrid= q.GetGrid();
            Grid myBasic = new Grid();
            var myBasicGrid = myBasic.GetGrid();
            //going over every Empty state to get the best Q-Value and direction for the optimal policy
            for(int x= 0; x<myBasicGrid.GetLength(0); x++)
            {
                for(int y=0; y < myBasicGrid.GetLength(1);y++) {
                    if (myBasicGrid[x, y] is string && (string)myBasicGrid[x, y] == "Empty")
                    {
                       
                        List<double> myQvalues = new List<double>();
                        int MaxIDX = -1;
                        double Max = -1;
                        //For every specific Empty state go and get the Q value of the 4 directions and put them in a list.
                        for ( int i=0; i< myQGrid.GetLength(1); i++)
                        {
                                                       
                            myQvalues.Add((double)myQGrid[x * 7 + y, i]);
                            
                        }
                        //Get the maximum value in the list of Q-Values to draw the optimal policy Grid.
                        if (myQvalues.Count == 4)
                        {
                            for (int j = 0; j < myQvalues.Count; j++)
                            {
                                
                                if (j == 0)
                                {
                                    Max = myQvalues[0];
                                    MaxIDX = 0;
                                }
                                else
                                {
                                    if (myQvalues[j] > Max)
                                    {
                                        Max = myQvalues[j];
                                        MaxIDX = j;
                                    }
                                }
                                
                            }
                            //Changing the values of the basic Grid to the optimal policy which shows the directions
                            myBasicGrid[x, y] = MaxIDX switch
                            {
                                0 => "<<<<",
                                1 => "^^^^",
                                2 => ">>>>",
                                3 => "vvvv",
                                _ => myQGrid[x * 7 + y, MaxIDX],
                            };
                            
                        }

                        
                        
                    }
                  
                };
            }
            //This is the printng algorithm which is basically looping over the grid and printing all states.
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(" " + myBasicGrid[i, j] + " ");
                }
                Console.Write("\n");
            } 
        }
    }
}
