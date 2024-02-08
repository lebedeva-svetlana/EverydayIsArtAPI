namespace EverydayIsArtAPI.Models
{
    /// <summary>
    ///     Result of an authorization.
    /// </summary>
    public class AuthorizationResult
    {
        public AuthorizationResult(string token)
        {
            Token = token;
        }

        public AuthorizationResult(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        ///     Gets or sets an authorization token.
        /// </summary>
        /// <value>
        ///     The authorization token.
        /// </value>
        public string? Token { get; set; }

        /// <summary>
        ///     Gets or sets an exception.
        /// </summary>
        /// <value>
        ///     The exception.
        /// </value>
        public Exception? Exception { get; set; }
    }
}