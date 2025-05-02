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
        var targetUser = await userQueryRepository.FindByIdAsync(@event.Id, cancellationToken);

        targetUser.IsActive = IsActive.InActive;
        targetUser.UpdatedBy = @event.UpdatedBy;
        targetUser.UpdatedRole = @event.UpdatedRole;
        targetUser.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
        targetUser.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;

        await userQueryRepository.ChangeAsync(targetUser, cancellationToken);
        
        //todo : should be better active ticket & ticketComment
    }

    public Task AfterHandleAsync(UserInActived @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}