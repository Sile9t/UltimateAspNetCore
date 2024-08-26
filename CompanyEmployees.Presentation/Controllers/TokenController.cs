using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace WebApplication1.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TokenController(IServiceManager service) => _service = service; 
    }
}
