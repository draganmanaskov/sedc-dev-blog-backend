namespace DevBlog.Shared.CustomExceptions
{
    public class CommentNotFoundException : Exception
    {
        public CommentNotFoundException(string message) : base(message)
        {

        }
    }
}
