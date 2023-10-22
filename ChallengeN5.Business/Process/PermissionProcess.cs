using ChallengeN5.Business.Models;
using ChallengeN5.Business.Utils;
using ChallengeN5.Data.Entities;
using ChallengeN5.Data.Repositories.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChallengeN5.Business.Process
{
    public class PermissionProcess
    {
        private PermissionRepository _permissionRepository;
        private PermissionTableRepository _permissionTableRepository;
        private PermissionTypeRepository _permissionTypeRepository;
        private ElasticSearchLog _elasticSearchLog;

        public PermissionProcess(
            PermissionRepository permissionRepository,
            PermissionTableRepository permissionTableRepository,
            PermissionTypeRepository permissionTypeRepository,
            ElasticSearchLog elasticSearchLog)
        {
            _permissionRepository = permissionRepository;
            _permissionTableRepository = permissionTableRepository;
            _permissionTypeRepository = permissionTypeRepository;
            _elasticSearchLog = elasticSearchLog;   
        }
        public async Task<IActionResult> GetPermissionsProcess(string endpoint) 
        {
            try
            {
                var res = await _permissionTableRepository.GetPermissionsList();

                if (res.Count > 0) 
                {
                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.OK, res);
                    return ResponseCode.CustomResult(HttpStatusCode.OK, res);
                }
                else 
                {
                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.NotFound);
                    return ResponseCode.CustomResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.InternalServerError, new { error = ex.Message });
                return ResponseCode.CustomResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IActionResult> GetPermissionTypesProcess(string endpoint)
        {
            try
            {
                var res = await _permissionTypeRepository.GetPermissionsList();

                if (res.Count > 0)
                {
                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.OK, res);
                    return ResponseCode.CustomResult(HttpStatusCode.OK, res);
                }
                else
                {
                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.NotFound);
                    return ResponseCode.CustomResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.InternalServerError, new { error = ex.Message });
                return ResponseCode.CustomResult(HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<IActionResult> GetPermissionsRangeProcess(PermissionListRangeViewModel data, string endpoint)
        {
            try
            {
                var res = await _permissionTableRepository.GetPermissionsFilter(data.initial, data.limit);

                if (res.Count > 0)
                {
                    var total = await _permissionTableRepository.CountPermissions();

                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.OK, res);

                    return ResponseCode.CustomResult(
                        HttpStatusCode.OK,
                        new { total = total, permission = res }
                        );
                }
                else
                {
                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.NotFound);

                    return ResponseCode.CustomResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.InternalServerError, new { error = ex.Message });

                return ResponseCode.CustomResult(HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<IActionResult> GetPermissionByIdProcess(int id, string endpoint)
        {
            try
            {
                var res = await _permissionTableRepository.GetPermissionById(id);

                if (res != null)
                {
                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.OK, res);

                    return ResponseCode.CustomResult(HttpStatusCode.OK, res);
                }
                else
                {
                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.NotFound);

                    return ResponseCode.CustomResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.InternalServerError, new { error = ex.Message });

                return ResponseCode.CustomResult(HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<IActionResult> GetPermissionsBySearchValueProcess(string searchValue, string endpoint)
        {
            try
            {
                var res = await _permissionTableRepository.GetPermissionsListBySearchValue(searchValue);

                if (res.Count > 0)
                {
                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.OK, res);

                    return ResponseCode.CustomResult(HttpStatusCode.OK, res);
                }
                else
                {
                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.NotFound);

                    return ResponseCode.CustomResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.InternalServerError, new { error = ex.Message });

                return ResponseCode.CustomResult(HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<IActionResult> UpdatePermissionProcess(PermissionViewModel data, string endpoint)
        {
            try
            {
                var permission = await _permissionTableRepository.GetPermissionById(data.id);

                if (permission == null)
                {
                    var message = new { type = "permission", message = "Permission not found" };

                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.NotFound, message);

                    return ResponseCode.CustomResult(HttpStatusCode.NotFound, message);
                }

                var permissionType = await _permissionTypeRepository.GetPermissionTypeById(data.permissionTypeId);

                if (permissionType == null)
                {
                    var message = new { type = "permissionType", message = "PermissionType not found" };

                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.NotFound, message);

                    return ResponseCode.CustomResult(HttpStatusCode.NotFound, message);
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
                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.Created, new { oldData = permission, newData = permissionUpdate });

                    return ResponseCode.CustomResult(HttpStatusCode.Created, new { message = "update successful" });
                }
                else
                {
                    string message = "Ops! Unexpected Error";

                    await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.NotFound, new { message = message });

                    return ResponseCode.CustomResult(HttpStatusCode.Conflict, new { message });
                }

            }
            catch (Exception ex)
            {
                await _elasticSearchLog.CreateDocument(endpoint, (int)HttpStatusCode.InternalServerError, new { error = ex.Message });

                return ResponseCode.CustomResult(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
