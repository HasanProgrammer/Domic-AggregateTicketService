using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Service.Events;

[EventConfig(Queue = "AggregateTicket_User_Queue")]
public class UserUpdated : UpdateDomainEvent<string>
{
    public string FirstName { get; init; }
    public string LastName  { get; init; }
    public string Username  { get; init; }
}