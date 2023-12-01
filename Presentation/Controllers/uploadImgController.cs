using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.dto;
using Models.request;
using Models.response;
using Tools;

namespace Presentation.Controllers
{
    [Route("api/upload/img")]
    [ApiController]
    [Authorize]
    public class uploadImgController : ControllerBase
    {
        private readonly uploadLogic _up = new();

        [HttpPost("avatar")]
        public async Task<IActionResult> upAvatar(IFormFile img)
        {
            try
            {
                uploadResponse res = await _up.img(categoryImgStatic.Avatar, img);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("producto")]
        public async Task<IActionResult> upProducto([FromBody]productUploadRequest req)
        {
            try
            {
                productUploadResponse res = await _up.productImg(req);
                if(res == null)
                {
                    return NoContent();
                }
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
