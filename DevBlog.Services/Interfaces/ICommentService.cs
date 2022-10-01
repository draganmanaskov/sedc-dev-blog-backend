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
        public void CreateComment(CreateCommentDto createCommentDto);
        public void UpdateComment(UpdateCommentDto updateCommentDto);
        public void DeleteComment(int id);

    }
}
