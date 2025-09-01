using Domic.Domain.User.Contracts.Interfaces;
using Domic.Domain.User.Entities;
using Domic.Persistence.Contexts.Q;
using Microsoft.EntityFrameworkCore;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.Q;

public class UserQueryRepository(SQLContext context) : IUserQueryRepository
{
    public Task<UserQuery> FindByIdEagerLoadingAsync(object id, CancellationToken cancellationToken) 
        => context.Users.AsNoTracking()
                        .Include(u => u.AuthorTickets)
                        .ThenInclude(t => t.Comments)
                        .FirstOrDefaultAsync(x => x.Id == id as string, cancellationToken);

    public Task<UserQuery> FindByIdAsync(string id, CancellationToken cancellationToken)
        => context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public Task AddAsync(UserQuery entity, CancellationToken cancellationToken)
    {
        context.Users.Add(entity);

        return Task.CompletedTask;
    }

    public Task ChangeAsync(UserQuery entity, CancellationToken cancellationToken)
    {
        context.Users.Update(entity);

        return Task.CompletedTask;
    }
}