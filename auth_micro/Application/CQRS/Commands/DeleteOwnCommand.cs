using MediatR;

namespace Application.CQRS.Commands;

public record DeleteOwnCommand(string token): IRequest<bool?>;
