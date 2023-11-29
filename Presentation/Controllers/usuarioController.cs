using Azure;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.dto;
using Models.request;
using Models.response;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class usuarioController : ControllerBase
    {
        private readonly usuarioLogic _logic = new();
        private ResponseBack _res = new();

        [HttpGet("list")]
        public async Task<IActionResult> get()
        {
            try
            {
                List<usuarioDto> res = await _logic.listDetaildAsyncUsser();
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
        public async Task<IActionResult> post([FromBody] usuarioModel request)
        {
            try
            {
                usuarioModel res = await _logic.CreateAsyncUsser(request);
                if (res.id == 0)
                {
                    _res.isSuccess = false;
                    _res.DisplayMessage = "No se pudo registrar el usuario";
                    return BadRequest(_res);
                }
                _res.DisplayMessage = "Usuario registrado exitosamente";
                return Ok(_res);
            }
            catch (Exception)
            {
                _res.DisplayMessage = "Ocurrio un problema";
                _res.isSuccess = false;
                return BadRequest(_res);
            }
        }
        [HttpPost("exists")]
        public async Task<IActionResult> post([FromBody]usserReq req)
        {
            try
            {
                bool exists = await _logic.existsUsuarioAsyncUsser(req.usser);
                if(exists)
                {
                    _res.isSuccess = exists;
                    _res.DisplayMessage = $"Nombre de usuario {req.usser}, no disponible";
                    return Ok(_res);
                }
                _res.isSuccess = exists;
                _res.DisplayMessage = $"Nombre de usuario {req.usser}, disponible";
                return Ok(_res);
            }
            catch (Exception)
            {
                _res.DisplayMessage = "Ocurrio un problema";
                _res.isSuccess = false;
                return BadRequest(_res);
            }
        }

        [HttpPut("updatePassWord")]
        public async Task<IActionResult> putPass([FromBody] updatePasswordRequest req)
        {
            try
            {
                _res = await _logic.updatePasswordAsyncUsser(req);
                _res.DisplayMessage = "Contraseña Cambiada";
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
