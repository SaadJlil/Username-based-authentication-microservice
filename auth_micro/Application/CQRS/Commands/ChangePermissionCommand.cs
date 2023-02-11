using MediatR;

namespace Application.CQRS.Commands;

public record ChangePermissionCommand(string username, string Perm): IRequest<bool>;