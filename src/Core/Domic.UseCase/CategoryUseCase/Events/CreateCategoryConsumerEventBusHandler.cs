using Domic.Core.Common.ClassConsts;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Category.Entities;
using Domic.Domain.Category.Events;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Events;

public class CreateCategoryConsumerEventBusHandler(ICategoryQueryRepository categoryQueryRepository) 
    : IConsumerEventBusHandler<CategoryCreated>
{
    public Task BeforeHandleAsync(CategoryCreated @event, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithCleanCache(Keies = "Tickets")]
    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(CategoryCreated @event, CancellationToken cancellationToken)
    {
        var newCategory = new CategoryQuery {
            Id = @event.Id,
            Title = @event.Title,
            CreatedBy = @event.CreatedBy,
            CreatedRole = @event.CreatedRole,
            CreatedAt_EnglishDate = @event.CreatedAt_EnglishDate,
            CreatedAt_PersianDate = @event.CreatedAt_PersianDate,
        };

        await categoryQueryRepository.AddAsync(newCategory, cancellationToken);
    }

    public Task AfterHandleAsync(CategoryCreated @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}