using ChallengeN5.Business.Process;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeN5.Controllers
{
    [Route("Api/[controller]/[action]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private PermissionProcess _permissionProcess;

        public PermissionController(PermissionProcess permissionProcess)
        {
            _permissionProcess = permissionProcess;
        }

        [HttpPost(Name = "EndpointTest")]
        public object Get([FromBody] object data)
        {
            Console.WriteLine(_permissionProcess.Test());
            return data;
        }
    }
}
