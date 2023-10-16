using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Business.Utils
{
    public class ResponseCode
    {
        static public IActionResult CustomResult(HttpStatusCode statusCode, object? content = null)
        {
            int statusCodeValue = (int)statusCode;

            var result = new ObjectResult(content)
            {
                StatusCode = statusCodeValue
            };

            return result;
        }
    }
}
