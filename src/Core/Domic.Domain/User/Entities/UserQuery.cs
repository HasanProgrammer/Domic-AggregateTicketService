#pragma warning disable CS0649

using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Domain.Ticket.Entities;

namespace Domic.Domain.User.Entities;

public class UserQuery : EntityQuery<string>
{
    //Fields
    
    public string Username { get; set; }
    public string UserImage { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    /*---------------------------------------------------------------*/
    
    //Relations
    
    public ICollection<TicketQuery> Tickets { get; set; }
}