﻿using Domic.Core.Common.ClassEnums;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Category.Events;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Events;

public class UpdateCategoryConsumerEventBusHandler(ICategoryQueryRepository categoryQueryRepository) 
    : IConsumerEventBusHandler<CategoryUpdated>
{
    public Task BeforeHandleAsync(CategoryUpdated @event, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithCleanCache(Keies = "Tickets")]
    [TransactionConfig(Type = TransactionType.Query)]
    public async Task HandleAsync(CategoryUpdated @event, CancellationToken cancellationToken)
    {
        var targetCategory = await categoryQueryRepository.FindByIdAsync(@event.Id, cancellationToken);

        targetCategory.Title = @event.Name;
        targetCategory.UpdatedBy = @event.UpdatedBy;
        targetCategory.UpdatedRole = @event.UpdatedRole;
        targetCategory.UpdatedAt_EnglishDate = @event.UpdatedAt_EnglishDate;
        targetCategory.UpdatedAt_PersianDate = @event.UpdatedAt_PersianDate;

        await categoryQueryRepository.ChangeAsync(targetCategory, cancellationToken);
    }

    public Task AfterHandleAsync(CategoryUpdated @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}