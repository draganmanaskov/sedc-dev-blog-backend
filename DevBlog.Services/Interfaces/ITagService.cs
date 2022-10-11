using DevBlog.Domain.Models;
using DevBlog.Dtos.Tags;

namespace DevBlog.Services.Interfaces
{
    public interface ITagService
    {
        Tag GetTagById(int id);
        void CreateTag(CreateTagDto createTagDto);
        void UpdateTag(UpdateTagDto updateTagDto);
        void DeleteTag(int id);
    }
}
