using ChallengeN5.Business.Models;
using ChallengeN5.Business.Utils;
using ChallengeN5.Data.Entities;
using ChallengeN5.Data.Repositories.DataAccess;
using ChallengeN5.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChallengeN5.Business.Process
{
    public class PermissionProcess
    {
        private PermissionRepository _permissionRepository;
        private PermissionTableRepository _permissionTableRepository;
        private PermissionTypeRepository _permissionTypeRepository;

        public PermissionProcess(
            PermissionRepository permissionRepository,
            PermissionTableRepository permissionTableRepository,
            PermissionTypeRepository permissionTypeRepository)
        {
            _permissionRepository = permissionRepository;
            _permissionTableRepository = permissionTableRepository;
            _permissionTypeRepository = permissionTypeRepository;
        }
        public async Task<IActionResult> GetPermissionsProcess() 
        {
            try
            {
                var res = await _permissionTableRepository.GetPermissionsList();

                if (res.Count > 0) 
                {
                    return ResponseCode.CustomResult(HttpStatusCode.OK, res);
                }
                else 
                {
                    return ResponseCode.CustomResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return ResponseCode.CustomResult(HttpStatusCode.InternalServerError, ex);
            }
        }
        public async Task<IActionResult> GetPermissionsRangeProcess(PermissionListRangeViewModel data)
        {
            try
            {
                var res = await _permissionTableRepository.GetPermissionsFilter(data.initial, data.limit);

                if (res.Count > 0)
                {
                    var total = await _permissionTableRepository.CountPermissions();
                    return ResponseCode.CustomResult(
                        HttpStatusCode.OK,
                        new { total = total, permission = res }
                        );
                }
                else
                {
                    return ResponseCode.CustomResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return ResponseCode.CustomResult(HttpStatusCode.InternalServerError, ex);
            }
        }
        public async Task<IActionResult> GetPermissionByIdProcess(int id)
        {
            try
            {
                var res = await _permissionTableRepository.GetPermissionById(id);

                if (res != null)
                {
                    return ResponseCode.CustomResult(HttpStatusCode.OK, res);
                }
                else
                {
                    return ResponseCode.CustomResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return ResponseCode.CustomResult(HttpStatusCode.InternalServerError, ex);
            }
        }
        public async Task<IActionResult> GetPermissionsBySearchValueProcess(string searchValue)
        {
            try
            {
                var res = await _permissionTableRepository.GetPermissionsListBySearchValue(searchValue);

                if (res != null)
                {
                    return ResponseCode.CustomResult(HttpStatusCode.OK, res);
                }
                else
                {
                    return ResponseCode.CustomResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return ResponseCode.CustomResult(HttpStatusCode.InternalServerError, ex);
            }
        }
        public async Task<IActionResult> UpdatePermissionProcess(PermissionViewModel data)
        {
            try
            {
                var permission = await _permissionTableRepository.GetPermissionById(data.id);

                if (permission == null)
                {
                    return ResponseCode.CustomResult(HttpStatusCode.NotFound, new { type = "permission", message = "Permission not found" });
                }

                var permissionType = await _permissionTypeRepository.GetPermissionTypeById(data.permissionTypeId);

                if (permissionType == null)
                {
                    return ResponseCode.CustomResult(HttpStatusCode.NotFound, new {type = "permissionType", message = "PermissionType not found"});
                }

                var permissionUpdate = new Permission
                {
                    Id = data.id,
                    Name = data.name,
                    Lastname = data.lastname,
                    PermissionType = permissionType,
                    PermissionTypeId = permissionType.Id,
                    Date = DateTime.Now
                };

                var update = await _permissionRepository.UpdatePermission(permissionUpdate);

                if (update == 1) 
                { 
                    return ResponseCode.CustomResult(HttpStatusCode.Created, new { message = "update successful" });
                }
                else
                {
                    return ResponseCode.CustomResult(HttpStatusCode.Conflict, new { message = "Ops! Unexpected Error" });
                }

            }
            catch (Exception ex)
            {
                return ResponseCode.CustomResult(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
