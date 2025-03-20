using Domic.Domain.Ticket.Entities;
using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Ticket.Contracts.Interfaces;

public interface ITicketCommentQueryRepository : IQueryRepository<TicketCommentQuery, string>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task ChangeRangeAsync(IEnumerable<TicketCommentQuery> entities, CancellationToken cancellationToken);
}