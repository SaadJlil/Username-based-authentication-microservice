using MediatR;
using Domain.Common.DTOs.Register;

namespace Application.CQRS.Commands;

public record RegisterCommand(RegisterInputDto dto): IRequest<RegisterOutputDto>;