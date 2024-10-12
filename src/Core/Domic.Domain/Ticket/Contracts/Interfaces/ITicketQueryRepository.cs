using System.Linq.Expressions;
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
    /// <param name="condition"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<List<TicketQuery>> FindByUserIdConditionallyAsync(string userId, Expression<Func<TicketQuery, bool>> condition, CancellationToken cancellationToken);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entities"></param>
    public void ChangeRange(List<TicketQuery> entities);
}