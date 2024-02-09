namespace EverydayIsArtAPI.Exceptions
{
    public class WrongPasswordException : Exception, IBadRequestException
    {
        public WrongPasswordException()
        {
        }

        public WrongPasswordException(string message)
            : base(message)
        {
        }

        public WrongPasswordException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}