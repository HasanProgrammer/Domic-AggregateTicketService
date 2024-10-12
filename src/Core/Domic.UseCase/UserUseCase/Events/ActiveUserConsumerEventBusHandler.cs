using Domic.Core.Common.ClassConsts;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Events;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Events;

public class ActiveUserConsumerEventBusHandler(ITicketQueryRepository ticketQueryRepository) 
    : IConsumerEventBusHandler<UserActived>
{
    public void Handle(UserActived @event){}

    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(UserActived @event, CancellationToken cancellationToken)
    {
        var targetUser = await ticketQueryRepository.FindByUserIdAsync(@event.Id, cancellationToken);

        if (targetUser is not null)
        {
            //
        }
    }
}