using DevBlog.Domain.Models;

namespace DevBlog.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User LoginUser(string username, string hashedPassword);
        User GetUserByUsername(string username);
        User GetByIdPost(int id);
    }
}
