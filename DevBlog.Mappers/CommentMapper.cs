using DevBlog.Domain.Models;
using DevBlog.Dtos.Comments;

namespace DevBlog.Mappers
{
    public static class CommentMapper
    {
        public static Comment ToComment(this CreateCommentDto createCommentDto)
        {
            return new Comment
            {
                Body = createCommentDto.Body,
                PostId = createCommentDto.PostId,
                UserId = createCommentDto.UserId,
                Anonymous = createCommentDto.Anonymous
            };
        }

        public static CommentDataDto ToCommentDataDto(this Comment comment)
        {
            return new CommentDataDto
            {
                Id = comment.Id,
                Body = comment.Body,
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt,
                Anonymous = comment.Anonymous,
                UserInfo = comment.User.ToUserInfoDto(),
            };
        }
    }
}
