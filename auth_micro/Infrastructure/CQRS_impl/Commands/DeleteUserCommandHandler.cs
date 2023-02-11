using Domain.Common.DTOs.Controllers.Register;
using Application.CQRS.Commands;
using Infrastructure.Services;
using Infrastructure.Persistence;
using Domain.Models;
using MediatR;
using Domain.Interfaces.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.CQRS_impl.Commands;

public class DeleteUserCommandHandler: IRequestHandler<DeleteUserCommand, bool?>
{

    private readonly TheContext _context;

    public DeleteUserCommandHandler(TheContext context)
    {
        _context = context;
    }

    public async Task<bool?> Handle(DeleteUserCommand request, CancellationToken token)
    {
        var user = _context.user.Where(x => x.Username == request.username);
        if(!(await user.AnyAsync()))
        {
            throw new UserDoesNotExistException(request.username);
        }
        _context.Remove(await user.FirstAsync());
        await _context.SaveChangesAsync(token);
        return true;
    }
}
