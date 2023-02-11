using MediatR;
using Domain.Common.DTOs.Authentication;

namespace Application.CQRS.Commands;


public record AuthenticationCommand(AuthenticationInputDto dto): IRequest<string?>;