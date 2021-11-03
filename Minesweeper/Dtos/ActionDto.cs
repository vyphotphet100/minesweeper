using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Dtos
{
    class ActionDto
    {
        // the X Y is the coordinay of the click action 
        //    that sent in the json format from the api
        public string X { get; set; }
        public string Y { get; set; }
    }
}
