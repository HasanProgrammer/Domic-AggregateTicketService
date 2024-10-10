using System.Linq.Expressions;
using Domic.Core.Domain.Enumerations;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Entities;
using Domic.Persistence.Contexts.Q;
using Microsoft.EntityFrameworkCore;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.Q;

public class TicketQueryRepository(SQLContext context) : ITicketQueryRepository
{
    public Task<TicketQuery> FindByIdAsync(object id, CancellationToken cancellationToken)
        => context.Ticket.AsNoTracking().FirstOrDefaultAsync(t => t.Id == (string)id, cancellationToken);

    public Task<List<TicketQuery>> FindByCategoryIdAsync(string categoryId, CancellationToken cancellationToken)
        => context.Ticket.AsNoTracking().Where(ticket => ticket.CategoryId == categoryId).ToListAsync(cancellationToken);

    public async Task<IEnumerable<TViewModel>> FindAllWithPaginateAndOrderingByProjectionAsync<TViewModel>(
        Expression<Func<TicketQuery, TViewModel>> projection, int countPerPage, int pageNumber, Order order,
        bool accending, CancellationToken cancellationToken
    )
    {
        var query = context.Ticket.AsNoTracking();

        if (order == Order.Id)
            query = accending
                ? query.OrderBy(ticket => ticket.Id)
                : query.OrderByDescending(ticket => ticket.Id);
        else
            query = accending
                ? query.OrderBy(ticket => ticket.CreatedAt_EnglishDate)
                : query.OrderByDescending(ticket => ticket.CreatedAt_EnglishDate);
        
        var result = await query.Skip(countPerPage*(pageNumber - 1))
                                .Take(countPerPage)
                                .Select(projection)
                                .ToListAsync(cancellationToken);

        return result;
    }

    public void Add(TicketQuery entity) => context.Ticket.Add(entity);

    public void Change(TicketQuery entity) => context.Ticket.Update(entity);

    public void ChangeRange(List<TicketQuery> entities) => context.Ticket.UpdateRange(entities);
}