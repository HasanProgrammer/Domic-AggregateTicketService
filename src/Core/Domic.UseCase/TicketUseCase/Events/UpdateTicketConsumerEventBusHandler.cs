using Domic.Core.Common.ClassConsts;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Enumerations;
using Domic.Domain.Ticket.Events;

namespace Domic.UseCase.TicketUseCase.Events;

public class UpdateTicketConsumerEventBusHandler(ITicketQueryRepository ticketQueryRepository) 
    : IConsumerEventBusHandler<TicketUpdated>
{
    public Task BeforeHandleAsync(TicketUpdated @event, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithCleanCache(Keies = "Tickets")]
    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(TicketUpdated @event, CancellationToken cancellationToken)
    {
        var targetTicket = await ticketQueryRepository.FindByIdAsync(@event.Id, cancellationToken);
        
        targetTicket.CategoryId = @event.CategoryId;
        targetTicket.Title = @event.Title;
        targetTicket.Description = @event.Description;
        targetTicket.Status = (Status)@event.Status;
        targetTicket.Priority = (Priority)@event.Priority;
        targetTicket.UpdatedBy = @event.UpdatedBy;
        targetTicket.UpdatedRole = @event.UpdatedRole;
        targetTicket.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;
        targetTicket.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;
            
        await ticketQueryRepository.ChangeAsync(targetTicket, cancellationToken);
    }

    public Task AfterHandleAsync(TicketUpdated @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}