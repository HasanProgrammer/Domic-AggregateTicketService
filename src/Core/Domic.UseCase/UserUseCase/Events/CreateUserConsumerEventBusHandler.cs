using Domic.Core.Common.ClassConsts;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Events;
using Domic.Domain.User.Contracts.Interfaces;
using Domic.Domain.User.Entities;

namespace Domic.UseCase.UserUseCase.Events;

public class CreateUserConsumerEventBusHandler(IUserQueryRepository userQueryRepository) 
    : IConsumerEventBusHandler<UserCreated>
{
    public Task BeforeHandleAsync(UserCreated @event, CancellationToken cancellationToken) => Task.CompletedTask;

    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(UserCreated @event, CancellationToken cancellationToken)
    {
        var newUser = new UserQuery {
            Id = @event.Id,
            Username = @event.Username,
            FirstName = @event.FirstName,
            LastName = @event.LastName,
            CreatedBy = @event.CreatedBy,
            CreatedRole = @event.CreatedRole,
            CreatedAt_EnglishDate = @event.CreatedAt_EnglishDate,
            CreatedAt_PersianDate = @event.CreatedAt_PersianDate,
        };

        await userQueryRepository.AddAsync(newUser, cancellationToken);
    }

    public Task AfterHandleAsync(UserCreated @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}