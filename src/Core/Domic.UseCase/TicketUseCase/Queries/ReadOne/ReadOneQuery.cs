using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.UseCase.TicketUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<TicketDto>
{
    public required string Id { get; init; }
}