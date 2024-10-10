using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Ticket.Events;

[EventConfig(Queue = "AggregateTicket_Ticket_Queue")]
public class TicketCreated : CreateDomainEvent<string>
{
    public required string CategoryId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int Status { get; set; }
    public required int Priority { get; set; }
}