using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Ticket.Events;

[EventConfig(Queue = "AggregateTicket_Ticket_Queue")]
public class TicketInActived : UpdateDomainEvent<string>;