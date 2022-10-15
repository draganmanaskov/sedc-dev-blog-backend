namespace DevBlog.Shared.CustomExceptions
{
    public class EmailNotFoundException : Exception
    {
        public EmailNotFoundException(string message) : base(message)
        {

        }
    }
}
