namespace HotelManagementSystem.Models.DTOs
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public int RoleId { get; set; }
        public bool IsEnable { get; set; }
    }
}
