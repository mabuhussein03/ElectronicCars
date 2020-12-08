using ElectronicCars.Extensions;
using System.Collections.Generic;

namespace ElectronicCars.Core.Models
{
    public class SaleQuery : IQueryObject
    {
        public int? SaleId { get; set; }
        public ICollection<SalesLocation>? Locations { get; set; }

        public ICollection<SaleQueryMonths>? Months { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
    public class SaleQueryMonths
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalSales { get; set; }
    }
}