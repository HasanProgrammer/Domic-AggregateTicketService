using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.AggregateTicket.Grpc;
using Domic.Core.Common.ClassHelpers;
using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.WebAPI.Frameworks.Extensions.Mappers.TicketMappers;

public static class RpcResponseExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="result"></param>
    /// <param name="configuration"></param>
    /// <param name="serializer"></param>
    /// <returns></returns>
    public static ReadOneResponse ToResponse(this TicketDto result, IConfiguration configuration, ISerializer serializer)
        => new() {
            Code = configuration.GetValue<int>("StatusCode:SuccessFetchData"),
            Message = configuration.GetValue<string>("Message:FA:SuccessFetchData"),
            Body = new ReadOneResponseBody {
                Ticket = serializer.Serialize(result)
            }
        };
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="result"></param>
    /// <param name="configuration"></param>
    /// <param name="serializer"></param>
    /// <returns></returns>
    public static ReadAllPaginatedResponse ToResponse(this PaginatedCollection<TicketDto> result, IConfiguration configuration, ISerializer serializer)
        => new() {
            Code = configuration.GetValue<int>("StatusCode:SuccessFetchData"),
            Message = configuration.GetValue<string>("Message:FA:SuccessFetchData"),
            Body = new ReadAllPaginatedResponseBody {
                Tickets = serializer.Serialize(result)
            }
        };
}