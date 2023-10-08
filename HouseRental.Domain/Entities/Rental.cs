using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRental.Domain.Entities
{
    [Index(nameof(HouseId), IsUnique = true)]
    public class Rental
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime RentalStartDate { get; set; }
        [Required]
        public DateTime RentalEndDate { get; set; }
        [Required]
        public decimal TotalRentalCost { get; set; }
        public bool IsReturned { get; set; } = false;

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [InverseProperty("Rentals")]
        public User User { get; set; }

        [ForeignKey("House")]
        public Guid HouseId { get; set; }
        [InverseProperty("Rental")]
        public House House { get; set; }


        //public Rental()
        //{
        //    Id = Guid.NewGuid();
        //    House = new House();
        //    User = new User();
        //}
    }
}