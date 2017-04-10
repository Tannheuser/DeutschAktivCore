using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeutschAktiv.Web.ViewModels
{
    public class ClientMessageDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Имя' не заполнено")]
        [StringLength(50, ErrorMessage = "Поле 'Имя' содержит более 50 символов")]
        [DataType(DataType.Text)]
        [DisplayName("Имя *")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Email' не заполнено")]
        [EmailAddress(ErrorMessage = "Неверно заполнено поле 'Email'")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email *")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Телефон")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Сообщение' не заполнено")]
        [StringLength(1000, ErrorMessage = "Поле 'Сообщение' содержит более 1000 символов")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Сообщение *")]
        public string MessageText { get; set; }
    }
}