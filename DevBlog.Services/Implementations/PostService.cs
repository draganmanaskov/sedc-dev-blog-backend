
using DevBlog.DataAccess.Interfaces;
using DevBlog.Domain.Models;
using DevBlog.Dtos.Posts;
using DevBlog.Mappers;
using DevBlog.Services.Interfaces;
using DevBlog.Shared.CustomExceptions;
using System.Linq.Expressions;
using XAct;

namespace DevBlog.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagService _tagService;
        private readonly IUserService _userService;

        public PostService(IPostRepository postRepository, ITagService tagService, IUserService userService)
        {
            _postRepository = postRepository;
            _tagService = tagService;
            _userService = userService;
        }

        public PostDataDto CreatePost(CreatePostDto createPostDto)
        {
            _userService.GetUserById(createPostDto.UserId);

            List<Tag> tags = new List<Tag>();

            createPostDto.TagIds.ForEach(tagId =>
            {
                tags.Add(_tagService.GetTagById(tagId));
            });

            Post post = _postRepository.Add(createPostDto.ToPost(tags));

            return post.ToPostDataDto();
        }

        public PostDataDto UpdatePost(UpdatePostDto updatePostDto)
        {
            _userService.GetUserById(updatePostDto.UserId);

            List<Tag> tags = new List<Tag>();

            updatePostDto.TagIds.ForEach(tagId =>
            {
                tags.Add(_tagService.GetTagById(tagId));
            });

            var post = _postRepository.GetById(updatePostDto.Id);
            if(post == null)
            {
                throw new PostNotFoundException($" Post with id: {post.Id} not found");
            }

            post.Title = updatePostDto.Title;
            post.Description = updatePostDto.Description;
            post.Body = updatePostDto.Body;
            post.Tags = tags;
            post.UpdatedAt = DateTime.Now;

            _postRepository.Update(post);

            return post.ToPostDataDto();

        }

        public List<PostDataDto> GetAllPosts(int page, int limit, int tagId, int year, int month)
        {
            Tag tag = null;
            if(tagId != 0)
            {
                tag = _tagService.GetTagById(tagId);
            }

            int skip = (page - 1) * limit;

            bool IsValidDate = DateTime.TryParse($"{year}/{month}/1", out DateTime date);

            List<Post> posts = null;

            if (tag != null && IsValidDate)
            {
                posts = _postRepository.GetAllTagAndTime(skip, limit, tag, date);
            }
            else if (tag != null && !IsValidDate)
            {
                posts = _postRepository.GetAllTag(skip, limit, tag);
            }
            else if (tag == null && IsValidDate)
            {
                posts = _postRepository.GetAllTime(skip, limit, date);
            }
            else
            {
                posts = _postRepository.GetAllDefault(skip, limit);
            }

            var list = new List<PostDataDto>();

            posts.ForEach(post =>
            {
                list.Add(post.ToPostDataDto());
            });

            return list;

        }

        public List<PostDataDto> GetAllUserPosts(int userId)
        {
            var user = _userService.GetUserById(userId);

            var list = new List<PostDataDto>();

            user.Posts.ForEach(post =>
            {
                list.Add(post.ToPostDataDto());
            });

            return list;
        }

        public PostDataDto GetById(int id, int userId)
        {
            var post = _postRepository.GetByIdPost(id, 1);

            return post.ToPostDataDto();
        }

        public void PostExists(int id)
        {   
            if(_postRepository.GetById(id) == null)
            {
                throw new PostNotFoundException($" Post with id: {id} does not exist");
            }
             
        }


        public double UpdateRating(int id)
        {
            var post = _postRepository.GetByIdForStars(id);

            double rating = 0;
            post.Stars.ForEach(star =>
            {
                rating += star.Value;
            });

            post.Rating = rating/post.Stars.Count();

            _postRepository.Update(post);

            return rating;
        }
    }
}
