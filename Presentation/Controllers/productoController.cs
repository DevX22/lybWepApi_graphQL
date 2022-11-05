using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.dto;
using Models.request;
using Newtonsoft.Json.Linq;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class productoController : ControllerBase
    {
        private readonly productoLogic _logic = new productoLogic();

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

        [HttpPost("list")]
        public async Task<IActionResult> get([FromBody] filterRequest? req)
        {
            try
            {
                List<productoDto> res = await _logic.listAllAsync(req);
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
        public async Task<IActionResult> get([FromBody]int id)
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
    }
}
