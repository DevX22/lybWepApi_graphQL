using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Models;
using Repository;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class categoriaController : ControllerBase
    {
        private readonly categoriaLogic _logic = new categoriaLogic();
        private readonly ingresoProductoRepository _ingreso = new();

        [HttpGet("list")]
        public async Task<IActionResult> get()
        {
            try
            {
                List<categoriaModel> res = await _logic.GetAllAsync();
                if (res.Count == 0)
                {
                    return NotFound(res);
                }
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody]categoriaModel req)
        {
            try
            {
                categoriaModel res = await _logic.CreateAsync(req);
                if (res.id == 0 || res.id == null)
                {
                    return NotFound(false);
                }
                return Ok(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> put([FromBody]categoriaModel req)
        {
            //Request.Scheme + "://" + Request.Host.Value + Request.Path.Value
            //Uri uri = new Uri($"{Request.Scheme}://{Request.Host.Value}{Request.Path.Value}");
            try
            {
                categoriaModel res = await _logic.UpdateAsync(req);
                return CreatedAtAction(Request.Method, true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> get(int id)
        {
            try
            {
                categoriaModel res = await _logic.GetByIdAsync(id);
                if (res == null)
                {
                    return NotFound(res);
                }
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("insert")]
        public async Task<IActionResult> post([FromBody] categoriaModel req)
        {
            try
            {
                await _logic.insertAsync(req).ConfigureAwait(false);
                return Ok($"{req} \n status:{true}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //[HttpPost("insert")]
        //public async Task<IActionResult> post([FromBody] categoriaModel req)
        //{
        //    try
        //    {
        //        categoriaModel res = await _logic.insertAsync(req).ConfigureAwait(false);
        //        if (res.id == 0 || res.id == null)
        //        {
        //            return Ok(res);
        //        }
        //        return Ok(res);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
