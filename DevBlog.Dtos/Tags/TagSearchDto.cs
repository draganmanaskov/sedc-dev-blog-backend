using DevBlog.Dtos.Posts;

namespace DevBlog.Dtos.Tags
{
    public class TagSearchDto
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<PostDataDto> Posts { get; set; }
    }
}
