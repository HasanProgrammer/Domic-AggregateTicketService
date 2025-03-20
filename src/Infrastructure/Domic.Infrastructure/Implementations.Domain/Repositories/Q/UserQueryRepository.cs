using Domic.Domain.User.Contracts.Interfaces;
using Domic.Domain.User.Entities;
using Domic.Persistence.Contexts.Q;
using Microsoft.EntityFrameworkCore;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.Q;

public class UserQueryRepository(SQLContext context) : IUserQueryRepository
{
    public Task<UserQuery> FindByIdAsync(string id, CancellationToken cancellationToken)
        => context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

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