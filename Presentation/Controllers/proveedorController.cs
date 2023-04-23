using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Tools;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}")]
    //[ApiVersion(versionApi.v1)]
    [ApiController]
    [Authorize]
    public class proveedorController : ControllerBase
    {
        private readonly proveedorLogic _logic = new proveedorLogic();

        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody] proveedorModel req)
        {
            try
            {
                proveedorModel res = await _logic.CreateAsync(req);
                if (res.id == 0 || res.id == null)
                {
                    return NotFound(false);
                }
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> get(int id)
        {
            proveedorModel res = await _logic.GetByIdAsync(id);
            if (res == null)
            {
                return NotFound(res);
            }
            return Ok(res);
        }

        [HttpGet("list")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                List<proveedorModel> res = await _logic.listAsyncDetaild();
                if(res == null)
                {
                    return BadRequest(res);
                }
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> put([FromBody] proveedorModel req)
        {
            try
            {
                proveedorModel res = await _logic.updateAsyncCustom(req);
                if (res.id == 0 || res.id == null)
                {
                    return NotFound(false);
                }
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
