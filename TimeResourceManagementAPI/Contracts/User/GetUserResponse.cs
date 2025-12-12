namespace TimeResourceManagementAPI.Contracts.User
{
    /// <summary>
    /// Получить данные пользователя
    /// </summary>
    public class GetUserResponse
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Position { get; set; }

        public int? DepartmentId { get; set; }

        public DateOnly HireDate { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}