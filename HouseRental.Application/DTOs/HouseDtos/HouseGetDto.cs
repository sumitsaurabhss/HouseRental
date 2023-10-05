using HouseRental.Application.DTOs.Common;

namespace HouseRental.Application.DTOs.HouseDtos
{
    public class HouseGetDto : BaseDto
    {
        public string Type { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal RentalCostPerMonth { get; set; }
        public bool IsAvailable { get; set; }
    }
}
