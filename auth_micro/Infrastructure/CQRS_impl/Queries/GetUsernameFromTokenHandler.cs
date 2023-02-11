using MediatR;
using Application.CQRS.Queries;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.CQRS_impl.Queries;

public class GetUsernameQueryHandler: IRequestHandler<GetUsernameQuery, string?>
{
    private readonly IConfiguration _conf;
    public GetUsernameQueryHandler(IConfiguration conf)
    {
        _conf = conf;
    }


    public async Task<string?> Handle(GetUsernameQuery request, CancellationToken token)
    {
        var username = Authentication.GetUsernameFromToken(request.token, _conf);
        return username;
    }
    
}
