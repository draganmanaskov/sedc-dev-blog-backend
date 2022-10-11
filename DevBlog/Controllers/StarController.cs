using DevBlog.Dtos.Posts;
using DevBlog.Dtos.Stars;
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
    public class StarController : ControllerBase
    {
        private IStarService _starService;

        public StarController(IStarService starService)
        {
            _starService = starService;
        }


        [AllowAnonymous]
        [HttpPost("create")]
        public ActionResult<double> CreateStar([FromBody] CreateStarDto createStarDto)
        {
            try
            {
                double postRating = _starService.CreateStar(createStarDto, 1);

                return StatusCode(StatusCodes.Status201Created, postRating);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (PostNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (StarNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (StarDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }


        [AllowAnonymous]
        [HttpPost("update")]
        public ActionResult<double> UpdateStar([FromBody] UpdateStarDto updateStarDto)
        {
            try
            {
                double postRating = _starService.UpdateStar(updateStarDto, 1);

                return StatusCode(StatusCodes.Status201Created, postRating);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (PostNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (StarNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (StarDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (UnauthorizedAccessException e)
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
