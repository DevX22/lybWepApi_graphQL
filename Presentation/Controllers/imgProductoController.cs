using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Immutable;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class imgProductoController : ControllerBase
    {
        private readonly imgProductoLogic _logic = new imgProductoLogic();

        [HttpGet("listByProduct/{id}")]
        public async Task<IActionResult> get(int id)
        {
            try
            {
                List<imgProductoModel> res = await _logic.GetByProductAsync(id);
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

        [HttpPost("inserMultiple")]
        public async Task<IActionResult> post([FromBody] List<imgProductoModel> req)
        {
            try
            {
                List<imgProductoModel> res = await _logic.insertMultipleAsyc(req);
                #region foreach
                //foreach (var item in res)
                //{
                //    if (item.id == 0)
                //    {
                //        return BadRequest();
                //    }
                //}
                #endregion
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("updateMultiple")]
        public async Task<IActionResult> put([FromBody]List<imgProductoModel> req)
        {
            try
            {
                List<imgProductoModel> res = await _logic.updateMultipleAsync(req);
                return CreatedAtAction(Request.Method, true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
