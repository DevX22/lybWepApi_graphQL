using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class domainController : ControllerBase
    {
        private readonly domainUrlLogic _logic = new();

        [HttpGet("get")]
        public async Task<IActionResult> get()
        {
            try
            {
                return Ok(await _logic.GetDomain());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
