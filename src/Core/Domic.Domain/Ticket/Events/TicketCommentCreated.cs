using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Ticket.Events;

[EventConfig(Queue = "AggregateTicket_TicketComment_Queue")]
public class TicketCommentCreated : CreateDomainEvent<string>
{
    public string TicketId { get; init; }
    public string Comment { get; init; }
}