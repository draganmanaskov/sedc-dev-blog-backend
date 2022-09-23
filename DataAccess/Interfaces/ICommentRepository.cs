using DevBlog.Domain.Models;

namespace DevBlog.DataAccess.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        List<Comment> GetAllByUser(int userId);
    }
}
