using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.response;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ventaController : ControllerBase
    {
        private readonly ventaLogic _logic = new();
        private ResponseBack _res = new();

        [HttpGet("list")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                List<ventaModel> res = await _logic.GetAllDetailedAsync();
                return Ok(res);
            }
            catch (Exception)
            {
                _res.DisplayMessage = "Ocurrio un problema";
                _res.isSuccess = false;
                return BadRequest(_res);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody] ventaModel req)
        {
            try
            {
                ventaModel res = await _logic.CreateAsync(req);
                if (res.id == 0)
                {
                    _res.DisplayMessage = "No se pudo registrar la venta";
                    _res.isSuccess = false;
                    return BadRequest(_res);
                }
                _res.DisplayMessage = "Venta registrada exitosamente";
                return Ok(_res);
            }
            catch (Exception)
            {
                _res.DisplayMessage = "Ocurrio un problema";
                _res.isSuccess = false;
                return BadRequest(_res);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> put([FromBody] ventaModel req)
        {
            try
            {
                ventaModel res = await _logic.UpdateAsync(req);
                _res.DisplayMessage = "Venta actualizada existosamente";
                return Ok(_res);
            }
            catch (Exception)
            {
                _res.DisplayMessage = "Ocurrio un problema";
                _res.isSuccess = false;
                return BadRequest(_res);
            }

        }

    }
}
