using Domic.Core.AggregateTicket.Grpc;
using Domic.Domain.Commons.Enumerations;
using Domic.UseCase.TicketUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.TicketUseCase.Queries.ReadOne;

namespace Domic.WebAPI.Frameworks.Extensions.Mappers.TicketMappers;

public static class RpcRequestExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static ReadOneQuery ToQuery(this ReadOneRequest request)
        => new() {
            Id = request.TicketId.Value,
            UserId = request.UserId != null ? request.UserId.Value : ""
        };
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static ReadAllPaginatedQuery ToQuery(this ReadAllPaginatedRequest request)
        => new() {
            CountPerPage = request.CountPerPage.Value, 
            PageNumber = request.PageNumber.Value,
            Sort = (Sort)request.Sort.Value,
            UserId = request.UserId != null ? request.UserId.Value : "",
            SearchText = request.SearchText != null ? request.SearchText.Value : ""
        };
}