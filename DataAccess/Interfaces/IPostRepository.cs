using DevBlog.Domain.Models;

namespace DevBlog.DataAccess.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        List<Post> GetAllByUser(int userId);
    }
}
