using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clienteController : ControllerBase
    {
        private readonly clienteLogic _logic = new clienteLogic();

        [HttpGet("list")]
        public IActionResult get()
        {
            try
            {
                List<clienteModel> response = _logic.listDetaild();
                if (response == null)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("create")]
        public IActionResult post([FromBody]clienteModel request)
        {
            try
            {
                bool response = _logic.Create(request);
                return Ok(response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
