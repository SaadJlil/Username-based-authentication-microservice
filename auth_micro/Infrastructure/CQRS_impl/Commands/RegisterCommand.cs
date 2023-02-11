using Domain.Common.DTOs.Controllers.Register;
using Application.CQRS.Commands;
using Infrastructure.Services;
using Infrastructure.Persistence;
using Domain.Models;
using MediatR;
using Domain.Interfaces.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.CQRS_impl.Commands;

public class RegisterCommandHandler: IRequestHandler<RegisterCommand, RegisterOutputDto>
{

    private readonly TheContext _context;

    public RegisterCommandHandler(TheContext context)
    {
        _context = context;
    }

    public async Task<RegisterOutputDto> Handle(RegisterCommand request, CancellationToken token)
    {
        if(await _context.user.Where(x => x.Username == request.dto.Username).AnyAsync())
        {
            throw new AlreadyExistsException(request.dto.Username);
        }

        Authentication.CreatePassword(request.dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
        var user = new Users{
            Username = request.dto.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Permission = Domain.Common.Enums.Permissions.Normal 
        };

        await _context.AddAsync<Users>(user, token);
        await _context.SaveChangesAsync(token);

        return new RegisterOutputDto(
            Username: request.dto.Username
        );
    }
}
