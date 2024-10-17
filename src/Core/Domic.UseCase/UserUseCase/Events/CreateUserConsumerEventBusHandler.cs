using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Events;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Events;

public class CreateUserConsumerEventBusHandler(ITicketQueryRepository ticketQueryRepository) 
    : IConsumerEventBusHandler<UserActived>
{
    public void Handle(UserActived @event){}

    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(UserActived @event, CancellationToken cancellationToken)
    {
        var tickets =
            await ticketQueryRepository.FindByUserIdConditionallyAsync(@event.Id,
                ticket => ticket.IsActive == IsActive.InActive, cancellationToken
            );

        if (tickets.Any())
        {
            foreach (var ticket in tickets)
            {
                ticket.IsActive = IsActive.Active;
                ticket.UpdatedBy = @event.UpdatedBy;
                ticket.UpdatedRole = @event.UpdatedRole;
                ticket.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
                ticket.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;
            }
            
            ticketQueryRepository.ChangeRange(tickets);
        }
    }
}