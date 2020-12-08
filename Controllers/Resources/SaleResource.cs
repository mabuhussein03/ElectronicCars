using System;
namespace ElectronicCars.Controllers.Resources
{
    public class SaleResource
    {
        public int Id { get; set; }
        public double Price { get; set; }

        public DateTime LastUpdate { get; set; }
        public SalesLocationResource SalesLocation { get; set; }
    }



}