using DevBlog.Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Services.Interfaces
{
    public interface ICommentService
    {
        CommentDataDto CreateComment(CreateCommentDto createCommentDto);
        CommentDataDto UpdateComment(UpdateCommentDto updateCommentDto, int loggedInUserId);
        void DeleteComment(int id, int loggedInUserId);

    }
}
