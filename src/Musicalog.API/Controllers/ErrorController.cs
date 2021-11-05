using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Error() => Problem();
    }
}
