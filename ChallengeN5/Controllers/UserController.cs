using ChallengeN5.Business.Models;
using ChallengeN5.Business.Process;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeN5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserProcess _userProcess;

        public UserController(UserProcess userProcess) 
        {
            _userProcess = userProcess;
        }

        [HttpPost(Name = "GetUser")]
        public async Task<int> Login([FromBody] UserViewModel data)
        {
            int res = await _userProcess.UserTest();
            return res;
        }

    }
}
