using DevBlog.DataAccess.Implementations;
using DevBlog.Domain.Models;
using DevBlog.Dtos.Posts;
using System.Collections.Generic;
using XAct.Categorization;
using Tag = DevBlog.Domain.Models.Tag;

namespace DevBlog.DataAccess.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        List<Post> GetAllByUser(int userId);
        Post GetByIdForStars(int id);
        Post GetByIdPost(int id, int userId);
        List<Post> GetAllDefault(int skip, int limit);
        List<Post> GetAllTime(int skip, int limit, DateTime date);
        List<Post> GetAllTag(int skip, int limit, Tag tag);
        List<Post> GetAllTagAndTime(int skip, int limit, Tag tag, DateTime date);
    }
}
