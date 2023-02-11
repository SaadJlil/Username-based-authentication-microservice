using Microsoft.AspNetCore.Mvc;
using Domain.Common.Enums;
using MediatR;
using Domain.Common.DTOs.Controllers.Register;
using Application.CQRS.Commands;
using Application.CQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using System;


using Domain.Events;
using MessageNamespace;


namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class userControllers : ControllerBase
    {
        private readonly IMediator _mediatr;
        public userControllers(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<RegisterOutputDto>> Register(RegisterInputDto dto)
        {
            return await _mediatr.Send(new RegisterCommand(dto));
        }


        [HttpPost("Authentication")]
        public async Task<ActionResult<string?>> Authentication(RegisterInputDto dto)
        {
            return await _mediatr.Send(new AuthenticationCommand(dto));
        }

        [HttpGet("Get Username from jwt token")]
        public async Task<ActionResult<string?>> GetUsernameFromJwt(string token)
        {
            return await _mediatr.Send(new GetUsernameQuery(token));
        }

        

        [HttpDelete("Delete User")]
        public async Task<ActionResult<bool?>> DeleteUser(string username)
        {
            return await _mediatr.Send(new DeleteUserCommand(username));
        }

//        [Authorize(Roles = "God")]
        //[Authorize]
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<RegisterOutputDto>>> GetAllUsers()
        {
            return Ok(await _mediatr.Send(new GetAllUsersQuery()));
        }

        [HttpPost("ChangePermission")]
        public async Task<ActionResult<bool>> ChangePermission(string username, string perm)
        {
            return await _mediatr.Send(new ChangePermissionCommand(username, perm));
        }

    }
}