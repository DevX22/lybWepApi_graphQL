﻿using Logic;
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
    public class tipoMedidaController : ControllerBase
    {
        private readonly tipoMedidaLogic _logic = new();
        private ResponseBack _res = new();

        [HttpGet("list")]
        public async Task<IActionResult> get()
        {
            try
            {
                List<tipoMedidaModel> response = await _logic.GetAllAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _res.DisplayMessage = "Ocurrio un problema";
                _res.isSuccess = false;
                return BadRequest(_res);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody] tipoMedidaModel req)
        {
            try
            {
                tipoMedidaModel res = await _logic.CreateAsync(req);
                if (res.id == 0)
                {
                    _res.isSuccess = false;
                    _res.DisplayMessage = $"No se pudo registrar el tipo de medida {req.tipoMedida}";
                    return BadRequest(_res);
                }
                _res.DisplayMessage = $"el tipo de medida {res.tipoMedida} se registro existosamente";
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
        public async Task<IActionResult> put([FromBody] tipoMedidaModel req)
        {
            try
            {
                tipoMedidaModel res = await _logic.UpdateAsync(req);
                _res.DisplayMessage = "Se actualizó el tipo de medida";
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
