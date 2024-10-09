using Domic.Core.AggregateTicket.Grpc;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.WebAPI.Frameworks.Extensions.Mappers.TicketMappers;
using Grpc.Core;

namespace Domic.WebAPI.EntryPoints.GRPCs;

public class TicketRPC(IMediator mediator, IConfiguration configuration, ISerializer serializer)
    : AggregateTicketService.AggregateTicketServiceBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<ReadOneResponse> ReadOne(ReadOneRequest request, ServerCallContext context)
    {
        var result = await mediator.DispatchAsync(request.ToQuery(), context.CancellationToken);

        return result.ToResponse(configuration, serializer);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<ReadAllPaginatedResponse> ReadAllPaginated(ReadAllPaginatedRequest request, ServerCallContext context)
    {
        var result = await mediator.DispatchAsync(request.ToQuery(), context.CancellationToken);

        return result.ToResponse(configuration, serializer);
    }
}