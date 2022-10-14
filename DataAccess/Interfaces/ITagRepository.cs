using DevBlog.Domain.Models;

namespace DevBlog.DataAccess.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        Tag GetTagByValue(string value);

        List<Tag> GetAllTags(int index);
    }
}
