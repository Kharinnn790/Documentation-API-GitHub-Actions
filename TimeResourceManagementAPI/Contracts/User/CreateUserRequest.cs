using System.ComponentModel.DataAnnotations;

namespace TimeResourceManagementAPI.Contracts.User
{
    /// <summary>
    /// для создания пользователя
    /// </summary>
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Фамилия должна быть от 2 до 50 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Неверный формат email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Должность не должна превышать 100 символов")]
        public string Position { get; set; }

        public int? DepartmentId { get; set; }

        [Required(ErrorMessage = "Дата приема обязательна")]
        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? CreatedDate { get; set; }
    }
}