using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class inventarioProductoController : ControllerBase
    {
        private readonly inventarioProductoLogic _logic = new inventarioProductoLogic();

        [HttpGet("list")]
        public async Task<IActionResult> get()
        {
            try
            {
                List<inventarioModel> res = await _logic.GetAllAsync();
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

        [HttpGet("listByProiduct/{id}")]
        public async Task<IActionResult> get(int id)
        {
            try
            {
                inventarioModel res = await _logic.GetByProductAsync(id);
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

        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody] inventarioModel req)
        {
            try
            {
                _logic.InsertAsync(req);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
