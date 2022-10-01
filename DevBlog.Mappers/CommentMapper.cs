using DevBlog.Domain.Models;
using DevBlog.Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                UserId = createCommentDto.UserId == 0 ? null : createCommentDto.UserId,
            };
        }
    }
}
