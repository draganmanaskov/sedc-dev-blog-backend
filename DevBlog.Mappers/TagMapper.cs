using DevBlog.Domain.Models;
using DevBlog.Dtos.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Mappers
{
    public static class TagMapper
    {
        public static Tag ToTag(this CreateTagDto createTagDto)
        {
            return new Tag
            {
                Value = createTagDto.Value
            };
        }

        public static TagDataDto ToTagDataDto(this Tag tag)
        {
            return new TagDataDto
            {
                Id = tag.Id,
                Value = tag.Value,
            };
        }
    }
}
