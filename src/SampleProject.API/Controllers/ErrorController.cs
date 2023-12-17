using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SampleProject.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class ErrorController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        readonly ILogger _logger;
        public ErrorController([FromServices] IWebHostEnvironment webHostEnvironment, ILogger<ErrorController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [HttpGet("error-development")]
        [HttpPost("error-development")]
        [HttpPut("error-development")]
        [HttpDelete("error-development")]
        public IActionResult ErrorLocalDevelopment()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.LogError($"Exception: {context.Error.Message} at {context.Error.StackTrace}");

            return Problem(
                detail: context.Error.InnerException != null ? $"{context.Error.InnerException.StackTrace}\n{context.Error.StackTrace}" : context.Error.StackTrace,
                title: context.Error.Message + " " + context.Error.GetType().ToString()
                );
        }

        [HttpGet("error")]
        [HttpPost("error")]
        [HttpPut("error")]
        [HttpDelete("error")]

        public IActionResult Error()
        {
            if (_webHostEnvironment.IsStaging() || _webHostEnvironment.IsProduction())
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.LogError($"Exception: {context.Error.Message} at {context.Error.StackTrace} from {(context.Error.InnerException != null ? context.Error.InnerException.StackTrace : "")}");
            return Problem(title: context.Error.Message);
        }
    }
}
