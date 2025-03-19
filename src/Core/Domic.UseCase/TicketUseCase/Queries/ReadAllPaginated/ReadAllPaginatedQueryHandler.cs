using System.Linq.Expressions;
using Domic.Core.Common.ClassExtensions;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Entities;
using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.UseCase.TicketUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler(ITicketQueryRepository ticketQueryRepository) 
    : IQueryHandler<ReadAllPaginatedQuery, PaginatedCollection<TicketDto>>
{
    public async Task<PaginatedCollection<TicketDto>> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<TicketQuery, bool>> conditionOne =
            ticket => !string.IsNullOrEmpty(query.UserId) && ticket.CreatedBy == query.UserId;
        
        Expression<Func<TicketQuery, bool>> conditionTwo =
            ticket => ticket.Title.Contains(query.SearchText)          ||
                      ticket.Category.Title.Contains(query.SearchText) ||
                      ( ticket.CreatedByUser.FirstName + " " + ticket.CreatedByUser.LastName ).Contains(query.SearchText);

        var countWithConditions =
            await ticketQueryRepository.CountRowsConditionallyAsync(cancellationToken, conditionOne, conditionTwo);
        
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
                Username = ticket.CreatedByUser.Username,
                UserImage = ticket.CreatedByUser.UserImage,
                FirstName = ticket.CreatedByUser.FirstName,
                LastName = ticket.CreatedByUser.LastName,
                CategoryName = ticket.Category.Title,
                Comments = ticket.Comments.Select(comment => new TicketCommentDto {
                    Id = comment.Id,
                    Comment = comment.Comment,
                    OwnerFirstName = comment.CreatedBy,
                    OwnerLastName = comment.CreatedBy,
                    OwnerImage = comment.CreatedBy
                }).ToList()
            },
            conditionOne,
            conditionTwo
        );

        return tickets.ToPaginatedCollection(countWithConditions, query.CountPerPage.Value, query.PageNumber.Value);
    }
}