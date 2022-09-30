using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class rolUserController : ControllerBase
    {
        private readonly rolUserLogic _logic = new rolUserLogic();

        [HttpGet("list")]
        public IActionResult get()
        {
            try
            {
                List<rolUsuarioModel> response = _logic.GetAll();
                if(response == null)
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
        public IActionResult post([FromBody] rolUsuarioModel resquest)
        {
            try
            {
                rolUsuarioModel request = _logic.Create(resquest);
                if (request.id == 0 || request.id==null)
                {
                    return NotFound(false);
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("update")]
        public IActionResult put([FromBody] rolUsuarioModel request)
        {
            try
            {
                rolUsuarioModel response = _logic.Update(request);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return NotFound(false);
            }
        }
    }
}
