using Logic;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ingresoProductoController : ControllerBase
    {
        private readonly ingresoProductoLogic _logic = new();
        
        [HttpGet("list")]
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

        [HttpPost("createmulti")]
        public async Task<IActionResult> postlist([FromBody]List<ingresoProductoModel> req)
        {
            try
            {
                List<ingresoProductoModel> res = await _logic.insertMultipleAsyc(req);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost("create")]
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
