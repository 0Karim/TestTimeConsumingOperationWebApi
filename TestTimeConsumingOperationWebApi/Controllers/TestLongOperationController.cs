using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestTimeConsumingOperationWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestLongOperationController : ControllerBase
    {
        /// <summary>
        /// This is code forming a long running IO operation to work with async and await programming
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(15000);

            return Content("Web API Long Operation Completed");
        }
    }
}