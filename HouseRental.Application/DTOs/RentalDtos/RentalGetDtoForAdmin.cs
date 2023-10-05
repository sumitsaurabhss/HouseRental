using HouseRental.Application.DTOs.Common;

namespace HouseRental.Application.DTOs.RentalDtos
{
    public class RentalGetDtoForAdmin : BaseDto
    {
        public string Type { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public decimal TotalRentalCost { get; set; }
        public bool IsReturned { get; set; }
        public string UserName { get; set; } = null!;
    }
}
