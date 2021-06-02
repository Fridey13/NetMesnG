using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetMesnG.Api.Controllers
{
    public class KeepAliveController : Controller
    {
        // GET
        [HttpGet("/keep_alive")]
        public async Task<IActionResult> KeepAlive()
        {
            var some = await Task.FromResult(1);
            return Ok(some);
        }
    }
}