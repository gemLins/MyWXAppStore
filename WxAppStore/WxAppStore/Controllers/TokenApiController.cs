using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Google.Api.Ads.Common.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WxServices;

namespace WxAppStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenApiController : ControllerBase
    {
        TokenService _tokenService;
        public TokenApiController(TokenService tokenService)
        {

            _tokenService = tokenService;
        }

        public IActionResult GetToken(string code)
        {
            string res = _tokenService.getToken(code);

            return Ok(res);
        }

        public IActionResult verifyToken(string token = "")
        {

            if (string.IsNullOrEmpty(token))
            {
                return Ok();
            }
            var isVerify = _tokenService.verifyToken(token);

            return Ok(isVerify);
        }

    }
}