using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class OptimalPolicyGrid
    {
       public Grid ShowOP(QGrid q,Grid basicGrid)
        {
            var myQGrid=q.GetGrid();
            Grid myBasic = new Grid();
            var myBasicGrid = myBasic.GetGrid();
            for(int x= 0; x<myBasicGrid.GetLength(0); x++)
            {
                for(int y=0; y < myBasicGrid.GetLength(1);y++) {
                    if ((string)myBasicGrid[x, y] == "Empty")
                    {

                    }
                }
            }

            for (int i =0; i< myQGrid.GetLength(0); i++)
            {
                for (int j= 0; j < myQGrid.GetLength(1); j++)
                {
                    
                }
            }
        }
    }
}
