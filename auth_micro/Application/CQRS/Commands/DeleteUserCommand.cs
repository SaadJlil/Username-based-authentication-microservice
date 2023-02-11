using MediatR;

namespace Application.CQRS.Commands;

public record DeleteUserCommand(string username): IRequest<bool?>;