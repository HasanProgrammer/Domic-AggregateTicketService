using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Category.Events;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Events;

public class DeleteCategoryConsumerEventBusHandler(ITicketQueryRepository ticketQueryRepository) 
    : IConsumerEventBusHandler<CategoryDeleted>
{
    public void Handle(CategoryDeleted @event){}

    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(CategoryDeleted @event, CancellationToken cancellationToken)
    {
        var targetTickets = await ticketQueryRepository.FindByCategoryIdAsync(@event.Id, cancellationToken);

        if (targetTickets is not null)
        {
            foreach (var targetTicket in targetTickets)
            {
                targetTicket.IsDeleted = IsDeleted.Delete;
                targetTicket.UpdatedBy = @event.UpdatedBy;
                targetTicket.UpdatedRole = @event.UpdatedRole;
                targetTicket.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
                targetTicket.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;
            }
            
            ticketQueryRepository.ChangeRange(targetTickets);
        }
    }
}