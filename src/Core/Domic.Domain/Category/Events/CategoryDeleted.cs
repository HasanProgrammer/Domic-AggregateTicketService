using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Category.Events;

[EventConfig(Queue = "AggregateTicket_Category_Queue")]
public class CategoryDeleted : UpdateDomainEvent<string>;