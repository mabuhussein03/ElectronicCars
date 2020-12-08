using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace ElectronicCars.Core.Models
{


    [Table("SalesLocations")]
    public class SalesLocation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string LocationName { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}