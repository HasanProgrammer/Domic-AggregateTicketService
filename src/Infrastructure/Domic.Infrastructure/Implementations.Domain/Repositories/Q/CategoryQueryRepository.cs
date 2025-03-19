using Domic.Domain.Category.Entities;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Persistence.Contexts.Q;
using Microsoft.EntityFrameworkCore;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.Q;

public class CategoryQueryRepository(SQLContext context) : ICategoryQueryRepository
{
    public Task<CategoryQuery> FindByIdAsync(object id, CancellationToken cancellationToken)
        => context.Categories.AsNoTracking().FirstOrDefaultAsync(t => t.Id == (string)id, cancellationToken);

    public Task AddAsync(CategoryQuery entity, CancellationToken cancellationToken)
    {
        context.Categories.Add(entity);

        return Task.CompletedTask;
    }

    public Task ChangeAsync(CategoryQuery entity, CancellationToken cancellationToken)
    {
        context.Categories.Update(entity);

        return Task.CompletedTask;
    }
}