namespace HotelManagementSystem.Models.DTOs
{
    public class AccountDTO
    {
        public string AccountId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
    }
}
