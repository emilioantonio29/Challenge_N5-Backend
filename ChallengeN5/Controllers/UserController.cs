using ChallengeN5.Business.Models;
using ChallengeN5.Business.Process;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeN5.Controllers
{
    [Route("Api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserProcess _userProcess;

        public UserController(UserProcess userProcess) 
        {
            _userProcess = userProcess;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin([FromBody] UserViewModel data)
        {
            int res = await _userProcess.UserTest(data);
            return Ok(data);
        }

    }
}
