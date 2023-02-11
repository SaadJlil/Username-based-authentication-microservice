using MediatR;
using Application.CQRS.Commands;
using Infrastructure.Persistence;
using Domain.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.CQRS_impl.Commands;

public class ChangePermissionCommandHandler: IRequestHandler<ChangePermissionCommand, bool>
{
    private readonly TheContext _context;
    
    public ChangePermissionCommandHandler(TheContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(ChangePermissionCommand request, CancellationToken token)
    {
        var user = _context.user.Where(x => x.Username == request.username);
        if(!await user.AnyAsync())
        {
            return false;
        }
        var names = Enum.GetNames(typeof(Permissions));
        if(names.Where(x => x == request.Perm).Any())
        {
            var User = await user.FirstAsync();
            User.Permission = (Permissions) Enum.Parse(typeof(Permissions), request.Perm);
            _context.SaveChangesAsync(token);
            return true;
        }
        else 
        {
            return false;
        }
    }
}