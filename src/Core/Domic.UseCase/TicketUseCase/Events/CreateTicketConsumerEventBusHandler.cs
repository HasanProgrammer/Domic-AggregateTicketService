using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Entities;
using Domic.Domain.Ticket.Enumerations;
using Domic.Domain.Ticket.Events;

namespace Domic.UseCase.TicketUseCase.Events;

public class CreateTicketConsumerEventBusHandler(ITicketQueryRepository ticketQueryRepository) 
    : IConsumerEventBusHandler<TicketCreated>
{
    public void Handle(TicketCreated @event){}

    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(TicketCreated @event, CancellationToken cancellationToken)
    {
        var targetTicket = await ticketQueryRepository.FindByIdAsync(@event.Id, cancellationToken);
        
        if (targetTicket is null)
        {
            var newTicket = new TicketQuery {
                Id = @event.Id,
                CategoryId = @event.CategoryId,
                Title = @event.Title,
                Description = @event.Description,
                Status = (Status)@event.Status,
                Priority = (Priority)@event.Priority,
                IsActive = IsActive.Active,
                CreatedBy = @event.CreatedBy,
                CreatedRole = @event.CreatedRole,
                CreatedAt_PersianDate = @event.CreatedAt_PersianDate,
                CreatedAt_EnglishDate = @event.CreatedAt_EnglishDate
            };
            
            ticketQueryRepository.Add(newTicket);
        }
    }
}