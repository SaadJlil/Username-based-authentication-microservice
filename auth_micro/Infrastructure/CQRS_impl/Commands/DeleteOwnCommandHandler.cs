using MediatR;
using Application.CQRS.Commands;
using Application.CQRS.Queries;

namespace Infrastructure.CQRS_impl.Commands;


public class DeleteOwnCommandHandler: IRequestHandler<DeleteOwnCommand, bool?>
{
    private readonly IMediator _mediatr;
    public DeleteOwnCommandHandler(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    public async Task<bool?> Handle(DeleteOwnCommand request, CancellationToken token)
    {
        var username = await _mediatr.Send(new GetUsernameQuery(request.token));
        return await _mediatr.Send(new DeleteUserCommand(username));
    }
}

