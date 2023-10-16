using ChallengeN5.Business.Models;
using ChallengeN5.Business.Utils;
using ChallengeN5.Data.Repositories.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChallengeN5.Business.Process
{
    public class UserProcess
    {
        private UserRepository _userRepository;

        public UserProcess(UserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<IActionResult> LoginProcess(UserViewModel data)
        {
            try 
            { 
                var res = await _userRepository.GetUserByUsername(data.username);

                if (res != null)
                {
                    if (data.password == res.Password) 
                    {
                        return ResponseCode.CustomResult(
                            HttpStatusCode.OK,
                            new UserResponseModel
                            {
                                id = res.Id,
                                username = res.Username
                            }
                        );

                    }
                    else 
                    {
                        return ResponseCode.CustomResult(HttpStatusCode.Unauthorized);
                    }
                }
                else 
                {
                    return ResponseCode.CustomResult(HttpStatusCode.Unauthorized);
                }
            }
            catch (Exception ex) 
            {
                return ResponseCode.CustomResult(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
