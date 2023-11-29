using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Tools;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Route("api/v{version:apiVersion}/[controller]")]
    //[ApiVersion(versionApi.v1)]
    [Authorize]
    public class tallaColorController : ControllerBase
    {
        private readonly tallaColorLogic _logic = new tallaColorLogic();

        [HttpGet("listByTallaId/{id}")]
        public async Task<IActionResult> get(int id)
        {
            List<tallaColorModel> res = await _logic.GetByTallaIdAsync(id);
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
                List<tallaColorModel> res = await _logic.GetAllAsync();
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest(false);
                throw;
            }
        }

        [HttpPost("createMultiple")]
        public async Task<IActionResult> postMulti([FromBody] List<tallaColorModel> req)
        {
            try
            {
                List<tallaColorModel> res = await _logic.insertMultipleAsyc(req);
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest(false);
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody] tallaColorModel req)
        {
            try
            {
                tallaColorModel res = await _logic.CreateAsync(req);
                if (res.id == 0 || res.id == null)
                {
                    return BadRequest($"no se pudo registrar el color {res.colorName} de la talla {res.talla}");
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
        public async Task<IActionResult> putMulti([FromBody] List<tallaColorModel> req)
        {
            try
            {
                List<tallaColorModel> res = await _logic.updateMultipleAsync(req);
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest(false);
                throw;
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> put([FromBody] tallaColorModel req)
        {
            try
            {
                tallaColorModel res = await _logic.UpdateAsync(req);
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
