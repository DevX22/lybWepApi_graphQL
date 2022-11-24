using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Models.err_Models;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class testMiddlewareController : ControllerBase
    {
        [HttpGet()]
        public IActionResult get()
        {
            try
            {
                throw new ArgumentException("Prueba de exepcion controlada");
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Ocurrio un error al obtener toda la lista", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
                throw;
            }
        }
    }
}
