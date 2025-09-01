using Domic.Core.Common.ClassEnums;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Events;
using Domic.Domain.User.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Events;

public class UpdateUserConsumerEventBusHandler(IUserQueryRepository userQueryRepository) 
    : IConsumerEventBusHandler<UserUpdated>
{
    public Task BeforeHandleAsync(UserUpdated @event, CancellationToken cancellationToken) => Task.CompletedTask;

    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(UserUpdated @event, CancellationToken cancellationToken)
    {
        var targetUser = await userQueryRepository.FindByIdAsync(@event.Id, cancellationToken);

        targetUser.Username = @event.Username;
        targetUser.FirstName = @event.FirstName;
        targetUser.LastName = @event.LastName;
        targetUser.UpdatedBy = @event.UpdatedBy;
        targetUser.UpdatedRole = @event.UpdatedRole;
        targetUser.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
        targetUser.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;

        await userQueryRepository.ChangeAsync(targetUser, cancellationToken);
    }

    public Task AfterHandleAsync(UserUpdated @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}