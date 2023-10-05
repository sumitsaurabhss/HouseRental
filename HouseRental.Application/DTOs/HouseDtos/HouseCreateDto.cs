namespace HouseRental.Application.DTOs.HouseDtos
{
    public class HouseCreateDto
    {
        public string Type { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal RentalCostPerMonth { get; set; }
    }
}
