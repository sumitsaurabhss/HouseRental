using HouseRental.Application.DTOs.Common;

namespace HouseRental.Application.DTOs.UserDtos
{
    public class UserDetailsDto : BaseDto
    {
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}