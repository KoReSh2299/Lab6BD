using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.Dtos
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина имени пользователя должна быть от 3 до 50 символов")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Длина пароля должна быть от 6 до 100 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
    }
}
