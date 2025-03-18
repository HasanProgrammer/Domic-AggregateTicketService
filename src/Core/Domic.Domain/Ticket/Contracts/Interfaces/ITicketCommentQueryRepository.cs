using Domic.Domain.Ticket.Entities;
using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Ticket.Contracts.Interfaces;

public interface ITicketCommentQueryRepository : IQueryRepository<TicketCommentQuery, string>;