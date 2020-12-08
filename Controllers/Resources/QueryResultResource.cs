using System.Collections.Generic;

namespace ElectronicCars.Controllers.Resources
{
    public class QueryResultResource<T>
    {
        public int TotalItems { get; set; }
        public int AverageItems { get; set; }
        public int MideItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}