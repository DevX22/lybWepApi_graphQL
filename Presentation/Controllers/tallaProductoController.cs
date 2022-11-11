using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Tools;

namespace Presentation.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    //[ApiVersion(versionApi.v1)]
    [Authorize]
    public class tallaProductoController : ControllerBase
    {
        private readonly tallaProductoLogic _logic = new tallaProductoLogic();

        [AllowAnonymous]
        [HttpGet("listByProductId/{id}")]
        public async Task<IActionResult> get(int id)
        {
            List<tallaProductoModel> res = await _logic.GetByProductIdAsync(id);
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
                List<tallaProductoModel> res = await _logic.GetAllAsync();
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest(false);
                throw;
            }
        }

        [HttpPost("createMultiple")]
        public async Task<IActionResult> postMulti([FromBody] List<tallaProductoModel> req)
        {
            try
            {
                List<tallaProductoModel> res = await _logic.insertMultipleAsyc(req);
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest(false);
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody] tallaProductoModel req)
        {
            try
            {
                tallaProductoModel res = await _logic.CreateAsync(req);
                if (res.id == 0 || res.id == null)
                {
                    return BadRequest($"no se pudo registrar la talla {res.talla} del producto {res.producto}");
                }
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest(false);
                throw;
            }
        }

        [HttpPut("updateMultiple")]
        public async Task<IActionResult> putMulti([FromBody] List<tallaProductoModel> req)
        {
            try
            {
                List<tallaProductoModel> res = await _logic.updateMultipleAsync(req);
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest(false);
                throw;
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> put([FromBody] tallaProductoModel req)
        {
            try
            {
                tallaProductoModel res = await _logic.UpdateAsync(req);
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest(false);
                throw;
            }
        }
    }
}
