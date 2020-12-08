using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectronicCars.Core.Models
{
    [Table("Sales")]
    public class Sale
    {
        public int Id { get; set; }
        public double Price { get; set; }

        public DateTime LastUpdate { get; set; }
        public SalesLocation SalesLocation { get; set; }
    }
    // public class SaleNew
    // {
    //     public string Month { get; set; }
    //     public string Year { get; set; }
    //     public SalesLocation Location { get; set; }
    //     public int TotalItems { get; set; }
    //     public int AverageItems { get; set; }
    //     public int MideItems { get; set; }
    // }
}