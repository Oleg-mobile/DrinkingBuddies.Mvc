using System.ComponentModel.DataAnnotations;

namespace DrinkingBuddies.Mvc.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        // [DataType(DataType.Password)]
        // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z])\S{6,}$", ErrorMessage = "Не безопасный пароль")]
        public string Password { get; set; }
    }
}
