namespace EverydayIsArtAPI.Exceptions
{
    public class UserDoesntExists : Exception, IBadRequestException
    {
        public UserDoesntExists()
        {
        }

        public UserDoesntExists(string message)
            : base(message)
        {
        }

        public UserDoesntExists(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}