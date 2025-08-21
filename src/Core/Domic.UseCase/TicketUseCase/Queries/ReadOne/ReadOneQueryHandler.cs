using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Enumerations;
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
                Status = ticket.Status,
                StatusTitle = ticket.Status == Status.Close ? "بسته شده" : (
                    ticket.Status == Status.Waiting ? "در انتظار پاسخ" : "بسته شده"
                ),
                Priority = ticket.Priority,
                PriorityTitle = ticket.Priority == Priority.Critical ? "بحرانی" : (
                    ticket.Priority == Priority.High ? "اولویت بالا" : (
                        ticket.Priority == Priority.Mid ? "اولویت متوسط" : "اولویت پایین"
                    )
                ),
                Username = ticket.CreatedByUser.Username,
                Author = ticket.CreatedByUser.FirstName + " " + ticket.CreatedByUser.LastName,
                CategoryName = ticket.Category.Title,
                Comments = ticket.Comments.Select(comment => new TicketCommentDto {
                    Id = comment.Id,
                    Comment = comment.Comment,
                    OwnerFirstName = comment.CreatedBy,
                    OwnerLastName = comment.CreatedBy
                }).ToList(),
                EnCreatedAt = ticket.CreatedAt_EnglishDate,
                FrCreatedAt = ticket.CreatedAt_PersianDate
            },
            ticket => string.IsNullOrEmpty(query.UserId) || ticket.CreatedBy == query.UserId,
            cancellationToken
        );
}