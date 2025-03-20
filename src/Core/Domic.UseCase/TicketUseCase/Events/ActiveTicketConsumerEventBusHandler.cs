using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Entities;
using Domic.Domain.Ticket.Events;

namespace Domic.UseCase.TicketUseCase.Events;

public class ActiveTicketConsumerEventBusHandler(ITicketQueryRepository ticketQueryRepository,
    ITicketCommentQueryRepository ticketCommentQueryRepository
) : IConsumerEventBusHandler<TicketActived>
{
    public Task BeforeHandleAsync(TicketActived @event, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithCleanCache(Keies = "Tickets")]
    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(TicketActived @event, CancellationToken cancellationToken)
    {
        var targetTicket = await ticketQueryRepository.FindByIdEagerLoadingAsync(@event.Id, cancellationToken);
        
        targetTicket.IsActive = IsActive.Active;
        targetTicket.UpdatedBy = @event.UpdatedBy;
        targetTicket.UpdatedRole = @event.UpdatedRole;
        targetTicket.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
        targetTicket.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;
            
        await ticketQueryRepository.ChangeAsync(targetTicket, cancellationToken);

        var comments = new List<TicketCommentQuery>();

        foreach (var comment in targetTicket.Comments)
        {
            comment.IsActive = IsActive.Active;
            comment.UpdatedBy = @event.UpdatedBy;
            comment.UpdatedRole = @event.UpdatedRole;
            comment.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
            comment.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;

            comments.Add(comment);
        }
            
        await ticketCommentQueryRepository.ChangeRangeAsync(comments, cancellationToken);
    }

    public Task AfterHandleAsync(TicketActived @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}