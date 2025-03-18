using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Entities;
using Domic.Persistence.Contexts.Q;
using Microsoft.EntityFrameworkCore;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.Q;

public class TicketCommentQueryRepository(SQLContext context) : ITicketCommentQueryRepository
{
    public Task<TicketCommentQuery> FindByIdAsync(object id, CancellationToken cancellationToken)
        => context.TicketComments.AsNoTracking().FirstOrDefaultAsync(t => t.Id == (string)id, cancellationToken);

    public Task AddAsync(TicketCommentQuery entity, CancellationToken cancellationToken)
    {
        context.TicketComments.Add(entity);

        return Task.CompletedTask;
    }

    public Task ChangeAsync(TicketCommentQuery entity, CancellationToken cancellationToken)
    {
        context.TicketComments.Update(entity);

        return Task.CompletedTask;
    }
}