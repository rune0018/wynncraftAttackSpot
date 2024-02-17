using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wynncraftAttackSpot
{
    public class Territory
    {
        public string territory { get; set; }
        public guild guild { get; set; }
        public DateTime acquired { get; set; }
        //"guild": {
        //      "uuid": str,
        //      "name": str,
        //      "prefix": str
    }

    public class guild
    {
        public string name { get; set; }
    }
}
