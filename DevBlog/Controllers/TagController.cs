using DevBlog.Dtos.Posts;
using DevBlog.Dtos.Tags;
using DevBlog.Services.Implementations;
using DevBlog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [AllowAnonymous]
        [HttpGet("getAllTags")]
        public ActionResult<List<TagDataDto>> GetAllTags()
        {
            try
            {
                var tags = _tagService.GetAll();

                return StatusCode(StatusCodes.Status200OK, tags);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }

        [HttpPost("create")]
        public ActionResult<string> CreateTag([FromBody] CreateTagDto createTagDto)
        {
            try
            {
                _tagService.CreateTag(createTagDto);

                return StatusCode(StatusCodes.Status200OK, "Tag Created");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }

        [HttpPost("update")]
        public ActionResult<string> UpdateTag([FromBody] UpdateTagDto updateTagDto)
        {
            try
            {
                _tagService.UpdateTag(updateTagDto);

                return StatusCode(StatusCodes.Status200OK, "Tag Updated");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }

        [HttpDelete("delete/{tagId}")]
        public ActionResult<string> DeleteTag(int tagId)
        {
            try
            {
                _tagService.DeleteTag(tagId);

                return StatusCode(StatusCodes.Status200OK, "Tag Deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }
    }
}
