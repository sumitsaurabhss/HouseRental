namespace HouseRental.Application.DTOs.RentalDtos
{
    public class RentalCreateDto
    {
        public Guid HouseId { get; set; }

        public Guid UserId { get; set; }
        public decimal TotalRentalCost { get; set; }
        public int DurationInMonths { get; set; }
    }
}
