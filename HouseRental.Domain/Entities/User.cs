using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRental.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
        public bool IsAdmin { get; set; } = false;

        [InverseProperty("User")]
        public ICollection<Rental> Rentals { get; set; }


        public User()
        {
            Id = Guid.NewGuid();
            Rentals = new List<Rental>();
        }
    }
}
