using AutoMapper;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.dto;
using Models.mapperConfig;
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
        private readonly IMapper _mapper = mapper.Go();

        [HttpGet("list")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                List<ventaDto> res = _mapper.Map<List<ventaDto>>(await _logic.GetAllDetailedAsync());
                if (res == null)
                {
                    return NoContent();
                }
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
        public async Task<IActionResult> post([FromBody] ventaDto req)
        {
            try
            {
                ventaModel reqSave = _mapper.Map<ventaModel>(req);
                ventaDto res = _mapper.Map<ventaDto>(await _logic.CreateAsync(reqSave));
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
        public async Task<IActionResult> put([FromBody] ventaDto req)
        {
            try
            {
                ventaModel reqSave = _mapper.Map<ventaModel>(req);
                ventaDto res = _mapper.Map<ventaDto>(await _logic.UpdateAsync(reqSave));
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
