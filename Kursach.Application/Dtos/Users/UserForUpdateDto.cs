using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.Dtos
{
    public class UserForUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя пользователя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина имени пользователя должна быть от 3 до 50 символов")]
        public string Username { get; set; }

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Задайте роль")]
        public string Role { get; set; }
    }
}
