using ChallengeN5.Business.Process;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeN5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost(Name = "GetUser")]
        public object Post([FromBody] object data)
        {
            Console.WriteLine(UserProcess.Test());
            return data;
        }
    }
}
