
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

        public List<PostDataDto> GetAllPosts()
        {
            var posts = _postRepository.GetAll();

            var list = new List<PostDataDto>();

            posts.ForEach(post =>
            {
                list.Add(post.ToPostDataDto());
            });

            return list;

        }

        public PostDataDto GetById(int id)
        {
            var post = _postRepository.GetByIdPost(id, 0);

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
