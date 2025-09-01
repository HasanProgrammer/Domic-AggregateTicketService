using Domic.Core.Common.ClassEnums;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Events;
using Domic.Domain.User.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Events;

public class InActiveUserConsumerEventBusHandler(IUserQueryRepository userQueryRepository) 
    : IConsumerEventBusHandler<UserInActived>
{
    public Task BeforeHandleAsync(UserInActived @event, CancellationToken cancellationToken) => Task.CompletedTask;

    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(UserInActived @event, CancellationToken cancellationToken)
    {
        var targetUser = await userQueryRepository.FindByIdEagerLoadingAsync(@event.Id, cancellationToken);

        targetUser.IsActive = IsActive.InActive;
        targetUser.UpdatedBy = @event.UpdatedBy;
        targetUser.UpdatedRole = @event.UpdatedRole;
        targetUser.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
        targetUser.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;

        await userQueryRepository.ChangeAsync(targetUser, cancellationToken);
        
        foreach (var ticket in targetUser.AuthorTickets)
        {
            ticket.IsActive = IsActive.InActive;
            ticket.UpdatedBy = @event.UpdatedBy;
            ticket.UpdatedRole = @event.UpdatedRole;
            ticket.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
            ticket.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;
            
            foreach (var comment in ticket.Comments)
            {
                comment.IsActive = IsActive.InActive;
                comment.UpdatedBy = @event.UpdatedBy;
                comment.UpdatedRole = @event.UpdatedRole;
                comment.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
                comment.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;
            }
        }
    }

    public Task AfterHandleAsync(UserInActived @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}