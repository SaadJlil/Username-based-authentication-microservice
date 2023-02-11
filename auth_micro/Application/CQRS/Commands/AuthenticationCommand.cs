using MediatR;
using Domain.Common.DTOs.Controllers.Register;

namespace Application.CQRS.Commands;

public record AuthenticationCommand(RegisterInputDto dto): IRequest<string?>;