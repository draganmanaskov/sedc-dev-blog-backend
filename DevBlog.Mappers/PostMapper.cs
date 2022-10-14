using DevBlog.Domain.Models;
using DevBlog.Dtos.Comments;
using DevBlog.Dtos.Posts;
using DevBlog.Dtos.Stars;
using DevBlog.Dtos.Tags;

namespace DevBlog.Mappers
{
    public static class PostMapper
    {
        public static Post ToPost (this CreatePostDto createPostDto, List<Tag> tags)
        {
            return new Post
            {
                Title = createPostDto.Title,
                Description = createPostDto.Description,
                Body = createPostDto.Body,
                ImageUrl = createPostDto.ImageUrl,
                CreatedAt = DateTime.Now,
                UserId = createPostDto.UserId,
                Tags = tags           
            };
        }

        public static PostDataDto ToPostDataDto (this Post post)
        {
            List<TagDataDto> tags = new List<TagDataDto>();

            post.Tags.ForEach(tag =>
            {
                tags.Add(tag.ToTagDataDto());
            });

            StarDataDto userStar = null;

            if(post.Stars == null || post.Stars.Count == 0)
            {
                userStar = null;
            }
            else
            {
                userStar = post.Stars.FirstOrDefault().ToStarDataDto();
            }

            List<CommentDataDto> comments = new List<CommentDataDto>();
            if(post.Comments != null)
            {
                post.Comments.ForEach(comment =>
                {
                    comments.Add(comment.ToCommentDataDto());
                });
            }
          

            return new PostDataDto
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                Body = post.Body,
                ImageUrl= post.ImageUrl,
                Comments = comments,
                Tags = tags,
                Rating = post.Rating,
                User = post.User.ToUserInfoDto(),   
                UserStar = userStar,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
            };
        }
    }
}
