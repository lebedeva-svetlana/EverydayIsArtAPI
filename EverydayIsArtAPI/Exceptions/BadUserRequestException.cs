namespace EverydayIsArtAPI.Exceptions
{
    public class BadUserRequestException : Exception
    {
        public BadUserRequestException()
        {
        }

        public BadUserRequestException(string message)
            : base(message)
        {
        }

        public BadUserRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}