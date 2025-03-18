using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Entities;
using Domic.Domain.Ticket.Events;

namespace Domic.UseCase.TicketUseCase.Events;

public class CreateTicketCommentConsumerEventBusHandler(ITicketCommentQueryRepository ticketCommentQueryRepository) 
    : IConsumerEventBusHandler<TicketCommentCreated>
{
    public Task BeforeHandleAsync(TicketCommentCreated @event, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithCleanCache(Keies = "Tickets")]
    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(TicketCommentCreated @event, CancellationToken cancellationToken)
    {
        var newTicket = new TicketCommentQuery {
            Id = @event.Id,
            TicketId = @event.TicketId,
            Comment = @event.Comment,
            IsActive = IsActive.Active,
            CreatedBy = @event.CreatedBy,
            CreatedRole = @event.CreatedRole,
            CreatedAt_PersianDate = @event.CreatedAt_PersianDate,
            CreatedAt_EnglishDate = @event.CreatedAt_EnglishDate
        };
            
        await ticketCommentQueryRepository.AddAsync(newTicket, cancellationToken);
    }

    public Task AfterHandleAsync(TicketCommentCreated @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}