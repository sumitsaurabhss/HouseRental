using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRental.Domain.Entities
{
    public class House
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Type { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public decimal RentalCostPerMonth { get; set; }
        public bool IsAvailable { get; set; } = true;

        [InverseProperty("House")]
        public Rental Rental { get; set; }

        //public House()
        //{
        //    Id = Guid.NewGuid();
        //    Rental = new Rental();
        //}
    }
}
