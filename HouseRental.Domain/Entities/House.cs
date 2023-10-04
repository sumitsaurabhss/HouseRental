using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRental.Domain.Entities
{
    public class House
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Maker { get; set; } = null!;
        [Required]
        public string Model { get; set; } = null!;
        [Required]
        public decimal RentalCostPerDay { get; set; }
        public bool IsAvailable { get; set; } = true;

        [InverseProperty("House")]
        public Rental Rental { get; set; }

        public House()
        {
            Id = Guid.NewGuid();
            Rental = new Rental();
        }
    }
}
