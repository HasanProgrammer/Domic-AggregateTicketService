namespace Domic.UseCase.TicketUseCase.DTOs;

public class TicketCommentDto
{
    public required string Id { get; init; }
    public required string Comment { get; init; }
    public required string OwnerFirstName { get; init; }
    public required string OwnerLastName { get; init; }
    public required string OwnerImage { get; init; }
}