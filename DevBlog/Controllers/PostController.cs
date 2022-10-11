using DevBlog.Dtos.Posts;
using DevBlog.Dtos.Users;
using DevBlog.Services.Implementations;
using DevBlog.Services.Interfaces;
using DevBlog.Shared.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public ActionResult<PostDataDto> CreatePost([FromBody] CreatePostDto createPostDto)
        {
            try
            {
                PostDataDto post = _postService.CreatePost(createPostDto);

                return StatusCode(StatusCodes.Status201Created, post);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (TagNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }

        [AllowAnonymous]
        [HttpGet("getAllPosts")]
        public ActionResult<List<PostDataDto>> GetAllPosts()
        {
            try
            {
                var posts = _postService.GetAllPosts();

                return StatusCode(StatusCodes.Status200OK, posts);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
            
        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<PostDataDto> GetById(int id)
        {
            try
            {
                var posts = _postService.GetById(id);

                return StatusCode(StatusCodes.Status200OK, posts);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }

        }

    }
}
