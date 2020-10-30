using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MakersOfDenmark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AzureController : ControllerBase
    {
        // Used as a Testing101 API test.
        [HttpGet]
        public string Get()
        {
            return "Hello Azure!";
        }

    }
}