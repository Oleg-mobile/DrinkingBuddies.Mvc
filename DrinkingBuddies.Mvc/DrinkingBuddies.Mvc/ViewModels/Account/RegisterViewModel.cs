using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DrinkingBuddies.Mvc.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z])\S{6,}$", ErrorMessage = "Не безопасный пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [ValidateNever]
        public string Description { get; set; }

        public bool IsAdmin { get; set; }
    }
}
