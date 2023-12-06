using AutoMapper;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.dto;
using Models.mapperConfig;
using Models.request;
using Newtonsoft.Json.Linq;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class productoController : ControllerBase
    {
        private readonly productoLogic _logic = new productoLogic();
        private readonly ILogger<productoController> _logger;
        private readonly IMapper _mapper = mapper.Go(); 

        public productoController(ILogger<productoController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog se injecto a productoController");
        }

        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody] productoModel req)
        {
            try
            {
                productoModel res = await _logic.CreateAsync(req);
                if (res.id == 0 || res.id == null)
                {
                    return BadRequest();
                }
                return Ok(res.id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [AllowAnonymous]
        [HttpPost("listDetail")]
        public async Task<IActionResult> get([FromBody] filterRequest? req)
        {
            try
            {
                List<productoDto> res = await _logic.listAllAsync(req);
                _logger.LogInformation("lista de productos entregado con exito");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("list")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                List<productoDto> res = _mapper.Map<List<productoDto>>(await _logic.GetAllAsync());
                if (res.Count == 0)
                {
                    return BadRequest(res);
                }
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> put([FromBody]productoModel req)
        {
            try
            {
                productoModel res = await _logic.UpdateAsync(req);
                return CreatedAtAction("actualizado", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("getById")]
        public async Task<IActionResult> get(int id)
        {
            try
            {
                productoModel res = await _logic.GetByIdAsync(id);
                if (res == null)
                {
                    return NoContent();
                }
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("test")]
        public async Task<IActionResult> test()
        {
            try
            {
                throw new ArgumentException("El argumento no es válido: Error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error en test: {0}", ex.Message);
                throw ex;
            }
        }
        [HttpPost("update/stock")]
        public async Task<IActionResult> updateStock(List<detalleVentaModel> req)
        {
            try
            {
                bool res = await _logic.updateStockMulti(req);
                if (res == false)
                {
                    return NoContent();
                }
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
