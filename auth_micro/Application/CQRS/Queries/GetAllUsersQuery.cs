using Domain.Common.DTOs.Controllers.Register;
using MediatR;

namespace Application.CQRS.Queries;

public record GetAllUsersQuery(): IRequest<IEnumerable<RegisterOutputDto>>;