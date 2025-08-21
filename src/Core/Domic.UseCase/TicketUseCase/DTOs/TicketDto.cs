using Domic.Domain.Ticket.Enumerations;

namespace Domic.UseCase.TicketUseCase.DTOs;

public class TicketDto
{
    //ticket
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required Status Status { get; set; }
    public required string StatusTitle { get; set; }
    public required Priority Priority { get; set; }
    public required string PriorityTitle { get; set; }
    
    //comment
    public List<TicketCommentDto> Comments { get; init; }
    
    //user
    public required string Username { get; init; }
    public required string Author { get; set; }
    
    //category
    public required string CategoryName { get; init; }
    
    public required DateTime EnCreatedAt { get; set; }
    public required string FrCreatedAt { get; set; }
}