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
    public class tallasController : ControllerBase
    {
        private readonly tallasLogic _logic = new();

        [HttpGet("list")]
        public async Task<IActionResult> get()
        {
            try
            {
                List<tallasModel> res = await _logic.GetAllAsync();
                if(res == null)
                {
                    return BadRequest("no hay datos");
                }
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody] tallasModel req)
        {
            try
            {
                tallasModel res = await _logic.CreateAsync(req);
                if (res.id == 0)
                {
                    return BadRequest("no se pudo crear el registro");
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
