using System.ComponentModel.DataAnnotations;

namespace EverydayIsArtAPI.Models
{
    /// <summary>
    ///     A login data.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        ///     Gets or sets a name or email of an user.
        /// </summary>
        /// <value>
        ///     The name or email of the user.
        /// </value>
        [Required]
        public string? Login { get; set; }

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