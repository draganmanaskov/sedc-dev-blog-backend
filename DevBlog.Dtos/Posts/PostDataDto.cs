using DevBlog.Domain.Models;
using DevBlog.Dtos.Comments;
using DevBlog.Dtos.Stars;
using DevBlog.Dtos.Tags;
using DevBlog.Dtos.Users;

namespace DevBlog.Dtos.Posts
{
    public class PostDataDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<CommentDataDto> Comments { get; set; }
        public List<TagDataDto> Tags { get; set; }
        public StarDataDto  UserStar { get; set; }
        public UserInfoDto User { get; set; }
    }
}
