using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.UseCase.TicketUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(ITicketQueryRepository ticketQueryRepository) 
    : IQueryHandler<ReadAllPaginatedQuery, List<TicketDto>>
{
    public async Task<List<TicketDto>> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken)
    {
        var tickets = await ticketQueryRepository.FindAllWithPaginateAndOrderingByProjectionConditionallyAsync(
            query.CountPerPage.Value,
            query.PageNumber.Value,
            Order.Id,
            accending: false,
            cancellationToken,
            ticket => new TicketDto {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Priority = ticket.Priority,
                Status = ticket.Status,
                Username = ticket.User.Username,
                UserImage = ticket.User.UserImage,
                FirstName = ticket.User.FirstName,
                LastName = ticket.User.LastName,
                CategoryName = ticket.Category.Title
            },
            ticket => !string.IsNullOrEmpty(query.UserId) && ticket.CreatedBy == query.UserId,
            ticket => ticket.Title.Contains(query.SearchText)          ||
                      ticket.Category.Title.Contains(query.SearchText) ||
                      ( ticket.User.FirstName + " " + ticket.User.LastName ).Contains(query.SearchText)
        );

        return tickets.ToList();
    }
}