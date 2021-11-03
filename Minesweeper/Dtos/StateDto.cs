using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Dtos
{
    class StateDto
    {
        //This object should be convert to json and send to API
        public List<List<object>> state { get; set; }
        public string flag { get; set; }
        public string mine { get; set; }

        // Compatiple json 
        //{
        //  "state" : [[]],
        //  "flag" : "1",
        //  "mine" : "1"
        //}
    }
}
