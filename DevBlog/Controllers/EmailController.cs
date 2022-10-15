using DevBlog.Dtos.Emails;
using DevBlog.Dtos.Posts;
using DevBlog.Services.Implementations;
using DevBlog.Services.Interfaces;
using DevBlog.Shared.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("subscribe")]
        public IActionResult Subscribe([FromBody] EmailDataDto emailDataDto)
        {
            try
            {
                _emailService.Subscribe(emailDataDto.EmailAddress);
                return Ok();
            }
            catch (EmailNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (EmailDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }

        [HttpPost("unsubscribe")]
        public IActionResult Unsubscribe([FromBody] EmailDataDto emailDataDto)
        {
            try
            {
                _emailService.Unsubscribe(emailDataDto.EmailAddress);
                return Ok();
            }
            catch (EmailNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (EmailDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }

        [HttpPost("newsletter")]
        public IActionResult SendNewsletter(string postTitle, int postId )
        {
            _emailService.SendEmail(postTitle, postId);
            return Ok();
        }
    }
    
}
