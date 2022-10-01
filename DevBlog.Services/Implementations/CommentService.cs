using DevBlog.DataAccess.Interfaces;
using DevBlog.Dtos.Comments;
using DevBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void CreateComment(CreateCommentDto createCommentDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateComment(UpdateCommentDto updateCommentDto)
        {
            throw new NotImplementedException();
        }
    }
}
