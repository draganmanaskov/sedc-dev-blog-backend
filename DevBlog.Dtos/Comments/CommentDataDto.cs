

using DevBlog.Dtos.Users;

namespace DevBlog.Dtos.Comments
{
    public class CommentDataDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public bool Anonymous { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public UserInfoDto UserInfo { get; set; }
    }
}
