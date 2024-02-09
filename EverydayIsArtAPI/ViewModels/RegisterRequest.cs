using System.ComponentModel.DataAnnotations;

namespace EverydayIsArtAPI.Models
{
    /// <summary>
    ///     A registration data.
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        ///     Gets or sets a name of an user.
        /// </summary>
        /// <value>
        ///     The name of the user.
        /// </value>
        [Required(ErrorMessage = "Имя пользователя не может быть пустым.")]
        [RegularExpression("^[a-zA-Z0-9_].*$", ErrorMessage = "Имя может содержать только латинские буквы, цифры и символ подчёркивания.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Длина имени пользователя должна составлять от четырёх до двадцати символов.")]
        public string? Username { get; set; }

        /// <summary>
        ///     Gets or sets an email of an user.
        /// </summary>
        /// <value>
        ///     The email of the user.
        /// </value>
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "Email должен содержать символ @.")]
        [MaxLength(50, ErrorMessage = "Длина email не может превышать 50 символов.")]
        [Required(ErrorMessage = "Email не может быть пустым.")]
        public string? Email { get; set; }

        /// <summary>
        ///     Gets or sets a password of an user.
        /// </summary>
        /// <value>
        ///     The password of the user.
        /// </value>
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).*$", ErrorMessage = "Пароль должен содержать хотя бы одну заглавную латинску букву, строчную латинскую букву, цифру и специальный символ.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Длина пароля должна составлять от шести до двадцати символов.")]
        [Required(ErrorMessage = "Пароль не может быть пустым.")]
        public string? Password { get; set; }
    }
}