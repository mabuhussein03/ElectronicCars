using ElectronicCars.Extensions;
using System.Collections.Generic;
using ElectronicCars.Core.Models;

namespace ElectronicCars.Controllers.Resources
{
    public class SaleQueryResource
    {
        public ICollection<SalesLocation>? Locations { get; set; }

        public ICollection<SaleQueryMonths>? Months { get; set; }
    }
}