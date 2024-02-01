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
        [Required]
        public string? Username { get; set; }

        /// <summary>
        ///     Gets or sets an email of an user.
        /// </summary>
        /// <value>
        ///     The email of the user.
        /// </value>
        [Required]
        public string? Email { get; set; }

        /// <summary>
        ///     Gets or sets a password of an user.
        /// </summary>
        /// <value>
        ///     The password of the user.
        /// </value>
        [Required]
        public string? Password { get; set; }
    }
}