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
    public class establecimientoController : ControllerBase
    {
        private readonly establecimientoLogic _logic = new();

        [HttpGet("list")]
        public async Task<IActionResult> get()
        {
            try
            {
                List<establecimientoModel> res = await _logic.GetAllAsync();
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
