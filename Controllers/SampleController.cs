using Microsoft.AspNetCore.Mvc;

namespace SelfHostedRestApiInConsoleApp.Controllers
{
    [ApiController]
    [Route("selfhostedrestapi/[controller]")]
    public class SampleController : ControllerBase
    {
        [HttpPost("sayhello")]
        public string SayHello([FromBody] string name)
        {
            var result = $"Hello {name}!";
            return result;
        }

        [HttpGet("sayhellotoworld")]
        public string SayHelloToWorld()
        {
            var result = "Hello World!";
            return result;
        }


    }
}
