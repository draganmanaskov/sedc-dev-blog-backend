namespace DevBlog.Dtos.Stars
{
    public class CreateStarDto
    {
        public int Value { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
