using DevBlog.DataAccess.Interfaces;
using DevBlog.Domain.Models;
using DevBlog.Dtos.Posts;
using DevBlog.Dtos.Stars;
using DevBlog.Dtos.Tags;
using DevBlog.Mappers;
using DevBlog.Services.Interfaces;
using DevBlog.Shared.CustomExceptions;

namespace DevBlog.Services.Implementations
{
    public class StarService : IStarService
    {
        public readonly IStarRepository _starRepository;
        private readonly IUserService _userService;
        private readonly IPostService _postService;


        public StarService(IStarRepository starRepository, IUserService userService, IPostService postService)
        {
            _starRepository = starRepository;
            _userService = userService;
            _postService = postService;
        }

        public bool CheckIfStarExists(int postId, int userId)
        {
            var star = _starRepository.GetStarByPostAndUserId(postId, userId);
            if(star == null)
            {
                return false;
            }
            return true;
        }

        public double CreateStar(CreateStarDto createStarDto)
        {
            if(createStarDto.Value < 1 || createStarDto.Value > 5)
            {
                throw new StarDataException("Star Value must be between 1-5");
            }

            if(CheckIfStarExists(createStarDto.PostId, createStarDto.UserId))
            {
                throw new StarDataException("Star already exists for this post and user");
            }

            //Check if there is a user with that id
            _userService.GetUserById(createStarDto.UserId);
            //Check if there is a post with that id
            _postService.PostExists(createStarDto.PostId);
            //Create new Star
            _starRepository.Add(createStarDto.ToStar());

            //Update Post Rating
            return _postService.UpdateRating(createStarDto.PostId);    
        }

        public double UpdateStar(UpdateStarDto updateStarDto)
        {
            if (updateStarDto.Value < 1 || updateStarDto.Value > 5)
            {
                throw new StarDataException("Star Value must be between 1-5");
            }

            //IF a star does not exixt we cant update it
            //This may not be needd beacuse we check with ID
            if (!CheckIfStarExists(updateStarDto.PostId, updateStarDto.UserId))
            {
                throw new StarDataException("Star does not exists for this post and user");
            }

            //Check if there is a user with that id
            _userService.GetUserById(updateStarDto.UserId);
            //Check if there is a post with that id
            _postService.PostExists(updateStarDto.PostId);
            //Update Star
            var star = _starRepository.GetById(updateStarDto.Id);
            if (star == null)
            {
                throw new StarNotFoundException($"Star with id: {updateStarDto.Id} does not exist");
            }
            star.Value = updateStarDto.Value;
            _starRepository.Update(star);

            //Update Post Rating
            return _postService.UpdateRating(star.PostId);
        }
    }
}
