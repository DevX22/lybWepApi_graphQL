using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.dto;
using Models.request;
using Models.response;
using TinyHelpers.Extensions;
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
        [AllowAnonymous]
        [HttpPost("producto")]
        public async Task<IActionResult> upProducto(List<IFormFile> img, [FromForm]string name, [FromForm] string category)
        {
            try
            {
                productUploadRequest req = new productUploadRequest();
                req.productoName = name;
                req.category = category;
                req.imgs = img;
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
