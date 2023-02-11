using MediatR;
using Domain.Common.DTOs.Controllers.Register;

namespace Application.CQRS.Commands;

public record RegisterCommand(RegisterInputDto dto): IRequest<RegisterOutputDto>;