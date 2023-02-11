using MediatR;
using Domain.Common.DTOs.Controllers.Register;
using Application.CQRS.Commands;
using Infrastructure.Services;
using Infrastructure.Persistence;
using Domain.Interfaces.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Domain.Common.Enums;



namespace Infrastructure.CQRS_impl.Commands;

public class AuthenticationCommandHandler: IRequestHandler<AuthenticationCommand, string?>
{
    private IConfiguration _conf;
    private readonly TheContext _context;

    public AuthenticationCommandHandler(TheContext context, IConfiguration conf)
    {
        _conf = conf;
        _context = context; 
    }

    public async Task<string?> Handle(AuthenticationCommand request, CancellationToken token)
    {
        var user = _context.user.Where(x => x.Username == request.dto.Username);
        if(!await user.AnyAsync())
        {
            throw new UserDoesNotExistException(request.dto.Username);
        }
        string jwt = Authentication.CreateJwtToken(user.First().Username, user.First().Permission.ToString(), _conf);

        return jwt;
    }
}