using System.Collections.Generic;
namespace ElectronicCars.Core.Models
{
    public class SalesQueryResult
    {
        public SalesLocation SalesLocation { get; set; }
        public ICollection<SaleQueryMonths> SaleQueryMonths { get; set; }
        public int TotalItems { get; set; }
        public int AverageItems { get; set; }
        public int MidItems { get; set; }
    }
}