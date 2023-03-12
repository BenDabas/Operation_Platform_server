using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Operation_Platform.Interfaces
{
    interface IAggregate
    {
        public double Max { get; set; }
        public double Min { get; set; }
        public double Average { get; set; }

    }
}
