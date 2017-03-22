using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeutschAktiv.Web.ViewModels
{
    public class AccountDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Неверно заполнено поле 'Имя'")]
        [DisplayName("Введите имя")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Неверно заполнено поле 'Пароль'")]
        [DataType(DataType.Password)]
        [DisplayName("Введите пароль")]
        public string Password { get; set; }
    }
}