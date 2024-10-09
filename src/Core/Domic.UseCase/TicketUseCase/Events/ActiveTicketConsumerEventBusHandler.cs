using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Events;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Events;

public class ActiveTicketConsumerEventBusHandler(ITicketQueryRepository ticketQueryRepository) 
    : IConsumerEventBusHandler<TicketActived>
{
    public void Handle(TicketActived @event){}

    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(TicketActived @event, CancellationToken cancellationToken)
    {
        var targetTicket = await ticketQueryRepository.FindByIdAsync(@event.Id, cancellationToken);
        
        if (targetTicket is not null)
        {
            targetTicket.IsActive = IsActive.Active;
            targetTicket.UpdatedBy = @event.UpdatedBy;
            targetTicket.UpdatedRole = @event.UpdatedRole;
            targetTicket.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
            targetTicket.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;
            
            ticketQueryRepository.Change(targetTicket);
        }
    }
}