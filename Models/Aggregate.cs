using Operation_Platform.Interfaces;

namespace Operation_Platform.Models
{
    public class Aggregate : IAggregate
    {
        public double Max { get; set; }
        public double Min { get; set; }
        public double Average { get; set; }
    }
}
