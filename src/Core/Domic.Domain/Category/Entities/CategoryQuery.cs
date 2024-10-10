using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Domain.Ticket.Entities;

namespace Domic.Domain.Category.Entities;

public class CategoryQuery : EntityQuery<string>
{
    //Fields
    
    public string Title { get; set; }
    
    /*---------------------------------------------------------------*/
    
    //relations
    
    public ICollection<TicketQuery> Tickets { get; set; }
}