using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Immutable;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class imgProductoController : ControllerBase
    {
        private readonly imgProductoLogic _logic = new imgProductoLogic();

        [HttpGet("listByProductId/{id}")]
        public async Task<IActionResult> get(int id)
        {
            try
            {
                List<imgProductoModel> res = await _logic.GetByProductIdAsync(id);
                if (res == null)
                {
                    return NotFound(res);
                }
                return Ok(res);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Authorize(Roles = "Administrador")]
        [HttpPost("insertMultiple")]
        public IActionResult post([FromBody] List<imgProductoModel> req)
        {
            try
            {
                var res = _logic.insertMultipleAsyc(req);
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest(false);
                throw;
            }
        }

        [HttpPut("updateMultiple")]
        public IActionResult put([FromBody]List<imgProductoModel> req)
        {
            try
            {
                var res = _logic.updateMultipleAsync(req);
                return CreatedAtAction(Request.Method, true);
            }
            catch (Exception)
            {
                return BadRequest(false);
                throw;
            }
        }
        /*[HttpPut("updateMultipleSync")]
        public async Task<IActionResult> putSync([FromBody] List<imgProductoModel> req)
        {
            try
            {
                var res = await _logic.updateMultipleAsync(req);
                return CreatedAtAction(Request.Method, res);
            }
            catch (Exception)
            {
                return BadRequest(false);
                throw;
            }
        }*/
    }
}
