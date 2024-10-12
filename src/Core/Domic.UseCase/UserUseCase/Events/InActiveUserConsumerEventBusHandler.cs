using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Events;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Events;

public class InActiveUserConsumerEventBusHandler(ITicketQueryRepository ticketQueryRepository) 
    : IConsumerEventBusHandler<UserInActived>
{
    public void Handle(UserInActived @event){}

    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(UserInActived @event, CancellationToken cancellationToken)
    {
        var tickets =
            await ticketQueryRepository.FindByUserIdConditionallyAsync(
                @event.Id, ticket => ticket.IsActive == IsActive.Active, cancellationToken
            );

        if (tickets.Any())
        {
            foreach (var ticket in tickets)
            {
                ticket.IsActive = IsActive.InActive;
                ticket.UpdatedBy = @event.UpdatedBy;
                ticket.UpdatedRole = @event.UpdatedRole;
                ticket.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
                ticket.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;
            }
            
            ticketQueryRepository.ChangeRange(tickets);
        }
    }
}