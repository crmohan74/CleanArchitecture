using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SampleProject.API.Controllers
{
    [Route("api/")] 
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator
        {
            get
            {
                return _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
            }
        }
    }
}
