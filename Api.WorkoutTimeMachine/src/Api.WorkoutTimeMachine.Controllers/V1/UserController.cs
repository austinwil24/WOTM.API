using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.WorkoutTimeMachine.Controllers.V1
{
    [Route("api/v1/[controller]s")]
    public class UserController : Controller
    {
        private readonly ILogger _logger;

        public UserController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            _logger.LogDebug("{Class}.{Method}() Called.", nameof(UserController), nameof(GetUser));

            return Ok(new { id });
        }
    }
}
