using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AqarPress.Core;
using AqarPress.Core.APIModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AqarPress.web.Areas.Mobile.Controllers
{
    [Produces("application/json")]
    [Route("api/1/Identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public IdentityService _identityService;
        public IdentityController(IdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost, Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginModel.Reply>> Login([FromBody] UserLoginModel user)
        {
            var loginResult = await _identityService.Login(user.MobileNumber, user.Password, user.DeviceToken);

            if (loginResult.IsFalse)
            {
                Log.Error(loginResult.Message);
                return BadRequest(loginResult.Message);
            }

            var reply = new UserLoginModel.Reply(loginResult.Value.User);

            reply.SessionId = loginResult.Value.Id.ToString().Replace("-", "_");

            return Ok(reply);
        }

    }
}