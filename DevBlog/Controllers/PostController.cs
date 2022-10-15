using DevBlog.Dtos.Posts;
using DevBlog.Dtos.Users;
using DevBlog.Services.Implementations;
using DevBlog.Services.Interfaces;
using DevBlog.Shared.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevBlog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        
        [HttpPost("create"), Authorize(Roles = "Admin,Creator")]
        public ActionResult<PostDataDto> CreatePost([FromBody] CreatePostDto createPostDto)
        {
            try
            {
                var userName = User.FindFirstValue(ClaimTypes.Name);
                _ = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userInt);

                System.Diagnostics.Debug.WriteLine(userName);

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


        [HttpPut("update"), Authorize(Roles = "Admin,Creator")]
        public ActionResult<PostDataDto> UpdatePost([FromBody] UpdatePostDto updatePostDto)
        {
            try
            {
                PostDataDto post = _postService.UpdatePost(updatePostDto);

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
            catch (PostNotFoundException e)
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
        public ActionResult<List<PostDataDto>> GetAllPosts(int page, int limit, int tagId, string dateTime)
        {
            try
            {
                var posts = _postService.GetAllPosts(page, limit, tagId, dateTime);

                return StatusCode(StatusCodes.Status200OK, posts);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
            
        }

        [AllowAnonymous]
        [HttpGet("getTopRated")]
        public ActionResult<List<PostDataDto>> GetTopRatedPosts()
        {
            try
            {
                var posts = _postService.GetTopRatedPosts();

                return StatusCode(StatusCodes.Status200OK, posts);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }

        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<PostDataDto> GetById(int id, int userId)
        {
            try
            {
                var posts = _postService.GetById(id, userId);

                return StatusCode(StatusCodes.Status200OK, posts);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }

        [Authorize, Authorize(Roles = "Admin,Creator")]
        [HttpGet("userPosts/{id}")]
        public ActionResult<PostDataDto> GetAllByUser(int id)
        {
            try
            {
                var posts = _postService.GetAllUserPosts(id);

                return StatusCode(StatusCodes.Status200OK, posts);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }

        [Authorize, Authorize(Roles = "Admin,Creator")]
        [HttpDelete("delete/{id}")]
        public ActionResult<string> DeletePost(int id)
        {
            try
            {
                 _postService.DeletePost(id);

                return StatusCode(StatusCodes.Status200OK, "Post Delete");
            }
            catch (PostNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }

    }
}
