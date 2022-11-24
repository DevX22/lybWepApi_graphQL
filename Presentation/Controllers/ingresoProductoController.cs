using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Models;
using Repository;
using System.Diagnostics;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ingresoProductoController : ControllerBase
    {
        private readonly ingresoProductoLogic _logic = new();
        
        [HttpGet]
        public IActionResult get()
        {
            try
            {
                List<ingresoProductoModel> res = _logic.GetAll();
                if (res.Count == 0)
                {
                    return NotFound("no hay datos");
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult post([FromBody]ingresoProductoModel req)
        {
            try
            {
                ingresoProductoModel res = _logic.Create(req);
                if(res.id== 0 || res == null)
                {
                    return BadRequest("error al registrar");
                }
                return Ok("registrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
