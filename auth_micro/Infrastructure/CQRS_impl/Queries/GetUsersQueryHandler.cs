using MediatR;
using Application.CQRS.Queries;
using Domain.Common.DTOs.Controllers.Register;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.CQRS_impl.Queries;

public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQuery, IEnumerable<RegisterOutputDto>>
{
    public TheContext _context;
    public GetAllUsersQueryHandler(TheContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RegisterOutputDto>> Handle(GetAllUsersQuery request, CancellationToken token)
    {
        return await _context.user.Select(x => new RegisterOutputDto(x.Username)).ToListAsync();
    }

}