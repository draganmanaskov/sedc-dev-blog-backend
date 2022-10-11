namespace DevBlog.Dtos.Stars
{
    public class UpdateStarDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
