namespace EverydayIsArtAPI.Exceptions
{
    public class UserExistsException : Exception, IBadRequestException
    {
        public UserExistsException()
        {
        }

        public UserExistsException(string message)
            : base(message)
        {
        }

        public UserExistsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}