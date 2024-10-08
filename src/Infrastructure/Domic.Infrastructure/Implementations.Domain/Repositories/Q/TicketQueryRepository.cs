using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Entities;
using Domic.Persistence.Contexts.Q;
using Microsoft.EntityFrameworkCore;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.Q;

public class TicketQueryRepository(SQLContext context) : ITicketQueryRepository
{
    public Task<TicketQuery> FindByIdAsync(object id, CancellationToken cancellationToken)
        => context.Ticket.AsNoTracking().FirstOrDefaultAsync(t => t.Id == (string)id, cancellationToken);

    public void Change(TicketQuery entity) => context.Ticket.Update(entity);
}