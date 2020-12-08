using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectronicCars.Core.Models
{


    [Table("SalesLocations")]
    public class SalesLocation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string LocationName { get; set; }
    }
}