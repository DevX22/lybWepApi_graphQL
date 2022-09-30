using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class colorProductoController : ControllerBase
    {
        private readonly colorProductoLogic _logic = new colorProductoLogic();

        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody]colorProductoModel req)
        {
            try
            {
                colorProductoModel res = await _logic.CreateAsync(req);
                if (res.id == 0 || res.id == null)
                {
                    return NotFound(false);
                }
                return Ok(res.id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("inserMultiple")]
        public async Task<IActionResult> post([FromBody] List<colorProductoModel> req)
        {
            try
            {
                List<colorProductoModel> res = await _logic.insertMultipleAsyc(req);
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
        public async Task<IActionResult> put([FromBody]List<colorProductoModel> req)
        {
            try
            {
                List<colorProductoModel> res = await _logic.updateMultipleAsync(req);
                return CreatedAtAction(Request.Method, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("listByProduct/{id}")]
        public async Task<IActionResult> get(int id)
        {
            List<colorProductoModel> res = await _logic.GetByProductAsync(id);
            if (res == null)
            {
                return NotFound(res);
            }
            return Ok(res);
        }
    }
}
