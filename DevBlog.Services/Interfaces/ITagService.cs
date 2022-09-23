using DevBlog.Dtos.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Services.Interfaces
{
    public interface ITagService
    {
        public void CreateTag(CreateTagDto createTagDto);
        public void UpdateTag(UpdateTagDto updateTagDto);
        public void DeleteTag(int id);
    }
}
