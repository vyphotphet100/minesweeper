using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Dtos
{
    class ProblemDto
    {
        //This object should be convert to json and send to API
        public int[,] state { get; set; }
        public int mine { get; set; }

        // Compatiple json 
        //{
        //  "state" : [[]],
        //  "flag" : "1",
        //  "mine" : "1"
        //}
    }
}
