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
    [Authorize]
    public class colorProductoController : ControllerBase
    {
        private readonly colorProductoLogic _logic = new colorProductoLogic();

        [HttpPost("inserMultiple")]
        public IActionResult post([FromBody] List<colorProductoModel> req)
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
        public IActionResult put([FromBody]List<colorProductoModel> req)
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

        [HttpGet("listByProductId/{id}")]
        public async Task<IActionResult> get(int id)
        {
            List<colorProductoModel> res = await _logic.GetByProductIdAsync(id);
            if (res == null)
            {
                return NotFound(res);
            }
            return Ok(res);
        }
    }
}
