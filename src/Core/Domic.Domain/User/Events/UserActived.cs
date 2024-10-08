using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Service.Events;

[EventConfig(Queue = "AggregateTicket_User_Queue")]
public class UserActived : UpdateDomainEvent<string>;