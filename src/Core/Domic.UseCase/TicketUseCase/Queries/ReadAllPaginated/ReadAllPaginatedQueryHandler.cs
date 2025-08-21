using System.Linq.Expressions;
using Domic.Core.Common.ClassExtensions;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Entities;
using Domic.Domain.Ticket.Enumerations;
using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.UseCase.TicketUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(ITicketQueryRepository ticketQueryRepository) 
    : IQueryHandler<ReadAllPaginatedQuery, PaginatedCollection<TicketDto>>
{
    public async Task<PaginatedCollection<TicketDto>> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<TicketQuery, bool>> conditionOne =
            ticket => string.IsNullOrEmpty(query.UserId) || ticket.CreatedBy == query.UserId;
        
        Expression<Func<TicketQuery, bool>> conditionTwo =
            ticket => ticket.Title.Contains(query.SearchText)          ||
                      ticket.Category.Title.Contains(query.SearchText) ||
                      ( ticket.CreatedByUser.FirstName + " " + ticket.CreatedByUser.LastName ).Contains(query.SearchText) ||
                      ( ticket.UpdatedByUser.FirstName + " " + ticket.UpdatedByUser.LastName ).Contains(query.SearchText);

        var countWithConditions =
            await ticketQueryRepository.CountRowsConditionallyAsync(cancellationToken, conditionOne, conditionTwo);
        
        var tickets = await ticketQueryRepository.FindAllWithPaginateAndOrderingByProjectionConditionallyAsync(
            query.CountPerPage.Value,
            query.PageNumber.Value,
            Order.Date,
            accending: query.Sort == Sort.Newest,
            cancellationToken,
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
            conditionOne,
            conditionTwo
        );

        return tickets.ToPaginatedCollection(countWithConditions, query.CountPerPage.Value, query.PageNumber.Value);
    }
}