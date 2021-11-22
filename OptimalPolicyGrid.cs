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
            for(int x= 0; x<myBasicGrid.GetLength(0); x++)
            {
                for(int y=0; y < myBasicGrid.GetLength(1);y++) {
                    if (myBasicGrid[x, y] is string && (string)myBasicGrid[x, y] == "Empty")
                    {
                       for( int i=0; i< myQGrid.GetLength(1); i++)
                        {
                            double[] myQvalues = new double[4];
                            myQvalues[i] = (double)myQGrid[x * 7 + y, i];
                            myQvalues[i] = myQvalues[i] + 100;
                            
                            double max=myQvalues.Max();
                            int myIndex = Array.IndexOf(myQvalues, max);
                            myBasicGrid[x, y] = myQGrid[x * 7 + y, myIndex];    
                        }
                    }
                  
                };
            }
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
