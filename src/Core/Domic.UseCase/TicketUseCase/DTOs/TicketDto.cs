using Domic.Domain.Ticket.Enumerations;

namespace Domic.UseCase.TicketUseCase.DTOs;

public class TicketDto
{
    //ticket
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required Priority Priority { get; init; }
    public required Status Status { get; init; }
    
    //user
    public required string Username { get; init; }
    public required string UserImage { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}