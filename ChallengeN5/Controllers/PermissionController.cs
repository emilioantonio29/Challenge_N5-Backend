using ChallengeN5.Business.Process;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeN5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        [HttpPost(Name = "EndpointTest")]
        public object Get([FromBody] object data)
        {
            Console.WriteLine(PermissionProcess.Test());
            return data;
        }
    }
}
