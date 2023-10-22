using ChallengeN5.Business.Models;
using ChallengeN5.Business.Process;
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

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            return await _permissionProcess.GetPermissionsProcess("GetPermissions");
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissionTypes()
        {
            return await _permissionProcess.GetPermissionTypesProcess("GetPermissionTypes");
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissionsRange([FromQuery] PermissionListRangeViewModel data)
        {
            return await _permissionProcess.GetPermissionsRangeProcess(data, "GetPermissionsRange");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionById(int id)
        {
            return await _permissionProcess.GetPermissionByIdProcess(id, "GetPermissionById");
        }

        [HttpGet("{searchValue}")]
        public async Task<IActionResult> GetPermissionBySearchValue(string searchValue)
        {
            return await _permissionProcess.GetPermissionsBySearchValueProcess(searchValue, "GetPermissionBySearchValue");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePermission([FromBody] PermissionViewModel data)
        {
            return await _permissionProcess.UpdatePermissionProcess(data, "UpdatePermission");
        }
    }
}
