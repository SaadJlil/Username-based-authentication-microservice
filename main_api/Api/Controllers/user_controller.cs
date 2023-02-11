using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Common.DTOs.Register;
using Domain.Common.DTOs.Authentication;
using MediatR;
using Application.CQRS.Commands;
using MassTransit;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class user_controller : ControllerBase
    {
        private readonly IMediator _mediator; 

        public user_controller(IMediator mediator, IBus bus, IPublishEndpoint pub)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterOutputDto>> Register(RegisterInputDto dto)
        {
           return await _mediator.Send(new RegisterCommand(dto));
        }



        [HttpPost("Authenticate")]
        public async Task<ActionResult<string?>> Authentication(AuthenticationInputDto dto)
        {
           return await _mediator.Send(new AuthenticationCommand(dto));
        }



    }
}

