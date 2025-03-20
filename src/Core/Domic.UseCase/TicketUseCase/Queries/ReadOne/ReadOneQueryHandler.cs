using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.UseCase.TicketUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(ITicketQueryRepository ticketQueryRepository) : IQueryHandler<ReadOneQuery, TicketDto>
{
    public Task<TicketDto> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => ticketQueryRepository.FindByIdByProjectionConditionallyAsync(query.Id, 
            ticket => new TicketDto {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Priority = ticket.Priority,
                Status = ticket.Status,
                Username = ticket.CreatedByUser.Username,
                FirstName = ticket.CreatedByUser.FirstName,
                LastName = ticket.CreatedByUser.LastName,
                CategoryName = ticket.Category.Title,
                Comments = ticket.Comments.Select(comment => new TicketCommentDto {
                    Id = comment.Id,
                    Comment = comment.Comment,
                    OwnerFirstName = comment.CreatedBy,
                    OwnerLastName = comment.CreatedBy
                }).ToList()
            },
            ticket => string.IsNullOrEmpty(query.UserId) || ticket.CreatedBy == query.UserId,
            cancellationToken
        );
}