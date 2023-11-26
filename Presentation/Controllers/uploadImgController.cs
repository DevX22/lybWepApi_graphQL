using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.dto;
using Tools;

namespace Presentation.Controllers
{
    [Route("api/upload/img")]
    [ApiController]
    public class uploadImgController : ControllerBase
    {
        private readonly uploadLogic _up = new();

        [HttpPost("avatar")]
        public async Task<IActionResult> upAvatar(IFormFile img)
        {
            try
            {
                string url = await _up.img(categoryImgStatic.Avatar, img);
                return Ok(url);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
