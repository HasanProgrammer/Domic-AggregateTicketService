using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Events;

namespace Domic.UseCase.TicketUseCase.Events;

public class InActiveTicketConsumerEventBusHandler(ITicketQueryRepository ticketQueryRepository) 
    : IConsumerEventBusHandler<TicketInActived>
{
    public void Handle(TicketInActived @event){}

    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(TicketInActived @event, CancellationToken cancellationToken)
    {
        var targetTicket = await ticketQueryRepository.FindByIdAsync(@event.Id, cancellationToken);
        
        if (targetTicket is not null)
        {
            targetTicket.IsActive = IsActive.InActive;
            targetTicket.UpdatedBy = @event.UpdatedBy;
            targetTicket.UpdatedRole = @event.UpdatedRole;
            targetTicket.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
            targetTicket.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;
            
            ticketQueryRepository.Change(targetTicket);
        }
    }
}