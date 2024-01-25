using System.ComponentModel.DataAnnotations;

namespace Presentation.DTO
{
    public class UserDTO
    {
        //[MinLength(10, ErrorMessage = "Имя должно быть больше 10 символов")]
        public string Name { get; set; }

        //[EmailAddress(ErrorMessage = "Укажите валидный Email")]
        public string Email { get; set; }
    }
}