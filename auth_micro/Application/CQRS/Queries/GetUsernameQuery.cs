using MediatR;

namespace Application.CQRS.Queries;

public record GetUsernameQuery(string token): IRequest<string?>;