using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.UseCase.TicketUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(ITicketQueryRepository ticketQueryRepository) : IQueryHandler<ReadOneQuery, TicketDto>
{
    public Task<TicketDto> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => ticketQueryRepository.FindByIdByProjectionAsync(ticket => new TicketDto {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            Priority = ticket.Priority,
            Status = ticket.Status,
            Username = ticket.User.Username,
            FirstName = ticket.User.FirstName,
            LastName = ticket.User.LastName,
            UserImage = ticket.User.UserImage,
            CategoryName = ticket.Category.Title
        }, query.Id, cancellationToken);
}