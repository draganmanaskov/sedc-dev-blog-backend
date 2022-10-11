using DevBlog.Dtos.Comments;
using DevBlog.Dtos.Posts;
using DevBlog.Services.Interfaces;
using DevBlog.Shared.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public ActionResult<CommentDataDto> CreateComment([FromBody] CreateCommentDto createCommentDto)
        {
            try
            {
                CommentDataDto comment = _commentService.CreateComment(createCommentDto);

                return StatusCode(StatusCodes.Status201Created, comment);
            }
            catch(PostNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserNotFoundException e)
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
