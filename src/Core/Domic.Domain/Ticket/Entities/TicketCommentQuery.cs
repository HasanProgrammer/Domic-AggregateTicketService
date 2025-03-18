#pragma warning disable CS0649

using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Ticket.Entities;

public class TicketCommentQuery : EntityQuery<string>
{
    //Fields
    
    public string TicketId { get; set; }
    public string Comment { get; set; }

    /*---------------------------------------------------------------*/
    
    //Relations
    
    public TicketQuery Ticket { get; set; }
}