using DevBlog.Domain.Models;

namespace DevBlog.DataAccess.Interfaces
{
    public interface IEmailRepository : IRepository<Email>
    {
        Email GetByEmail(string emailAddress);
    }
}
