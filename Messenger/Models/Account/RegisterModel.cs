using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Messenger.Models.Account;
public class RegisterModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Логин обязателен.")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Пароль обязателен.")]
    public string Password { get; set; }
    public string Name { get; set; }

    [DisplayName("Подтверждение пароля")]
    [Required(ErrorMessage = "Подтверждение обязательно.")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
    public string ConfirmPassword { get; set; }
}

