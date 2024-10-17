using Domic.Core.Common.ClassHelpers;
using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.UseCase.TicketUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQuery : PaginatedQuery, IQuery<PaginatedCollection<TicketDto>>
{
    public required string UserId { get; init; }
    public required string SearchText { get; init; }
}