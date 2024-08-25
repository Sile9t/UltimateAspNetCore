using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace WebApplication1.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service) =>
            _service = service;
    }
}
