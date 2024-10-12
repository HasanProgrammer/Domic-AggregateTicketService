using Domic.Domain.Ticket.Entities;
using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Ticket.Contracts.Interfaces;

public interface ITicketQueryRepository : IQueryRepository<TicketQuery, string>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<List<TicketQuery>> FindByCategoryIdAsync(string categoryId, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<List<TicketQuery>> FindByUserIdAsync(string userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entities"></param>
    public void ChangeRange(List<TicketQuery> entities);
}