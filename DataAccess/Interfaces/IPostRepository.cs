using DevBlog.DataAccess.Implementations;
using DevBlog.Domain.Models;
using DevBlog.Dtos.Posts;

namespace DevBlog.DataAccess.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        List<Post> GetAllByUser(int userId);
        Post GetByIdForStars(int id);
        Post GetByIdPost(int id, int userId);
    }
}
