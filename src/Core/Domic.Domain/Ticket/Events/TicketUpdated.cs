using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Ticket.Events;

[EventConfig(Queue = "AggregateTicket_Ticket_Queue")]
public class TicketUpdated : UpdateDomainEvent<string>
{
    public required string CategoryId { get; set; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required int Status { get; init; }
    public required int Priority { get; init; }
}