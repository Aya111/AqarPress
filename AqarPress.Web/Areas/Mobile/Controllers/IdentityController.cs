using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AqarPress.Core;
using AqarPress.Core.APIModels;
using AqarPress.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using View.DtoClasses;

namespace AqarPress.web.Areas.Mobile.Controllers
{
    [Produces("application/json")]
    [Route("api/1/Identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public IdentityService _identityService;

        public UserRepository _userRepository;
        public IdentityController(IdentityService identityService, UserRepository userRepository)
        {
            _identityService = identityService;
            _userRepository = userRepository;
        }

        [HttpPost, Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginModel.Reply>> Login([FromBody] UserLoginModel user)
        {
            var loginResult = await _identityService.Login(user.MobileNumber, user.Password, user.DeviceToken);

            Log.Information("login result is " + loginResult.IsTrue);

            if (loginResult.IsFalse)
            {
                Log.Error(loginResult.Message);
                return BadRequest(loginResult.Message);
            }

            var reply = new UserLoginModel.Reply(loginResult.Value.User);

            reply.SessionId = loginResult.Value.Id.ToString().Replace("-", "_");

            return Ok(reply);
        }

        [HttpPost, Route("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<RegisterationUser>> Register([FromBody] RegisterationUser registerationUser)
        {
            var user = new UserView()
            {
                Name = registerationUser.Name,
                Password = registerationUser.Password,
                MobilePhone = registerationUser.MobileNumber,
                RoleId = (int)UserRoles.Normal,
                DeviceToken = registerationUser.DeviceToken
            };

            var registerationResult = await _userRepository.Create(user);

            Log.Information("Registeration result is " + registerationResult.IsTrue);

            if (registerationResult.IsFalse)
            {
                Log.Error(registerationResult.Message);
                return BadRequest(registerationResult.Message);
            }

            user.Id = registerationResult.Value.Id;

            var reply = new UserLoginModel.Reply(user);

            reply.SessionId = registerationResult.Value.Id.ToString().Replace("-", "_");

            return Ok(reply);
        }

    }
}