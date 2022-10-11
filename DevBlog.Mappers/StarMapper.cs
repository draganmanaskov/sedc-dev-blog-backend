using DevBlog.Domain.Models;
using DevBlog.Dtos.Stars;

namespace DevBlog.Mappers
{
    public static class StarMapper
    {
        public static Star ToStar(this CreateStarDto createStarDto)
        {
            return new Star
            {
                Value = createStarDto.Value,
                UserId = createStarDto.UserId,
                PostId = createStarDto.PostId,
            };
        }

        public static StarDataDto ToStarDataDto(this Star star)
        {
            return new StarDataDto
            {
                Id = star.Id,
                Value = star.Value,
                UserId = star.UserId,
                PostId = star.PostId,
            };
        }

    }
}
