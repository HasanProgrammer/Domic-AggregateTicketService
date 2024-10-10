#pragma warning disable CS0649

using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Domain.Category.Entities;
using Domic.Domain.Ticket.Enumerations;
using Domic.Domain.User.Entities;

namespace Domic.Domain.Ticket.Entities;

public class TicketQuery : EntityQuery<string>
{
    //Fields
    
    public string CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; }

    /*---------------------------------------------------------------*/
    
    //Relations
    
    public UserQuery User { get; set; }
    public CategoryQuery Category { get; set; }
}