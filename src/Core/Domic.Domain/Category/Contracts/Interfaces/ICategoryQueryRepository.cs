using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Domain.Category.Entities;

namespace Domic.Domain.Ticket.Contracts.Interfaces;

public interface ICategoryQueryRepository : IQueryRepository<CategoryQuery, string>;