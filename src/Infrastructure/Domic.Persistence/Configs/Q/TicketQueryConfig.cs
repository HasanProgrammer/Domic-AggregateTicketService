using Domic.Core.Persistence.Configs;
using Domic.Domain.Ticket.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domic.Persistence.Configs.Q;

public class TicketQueryConfig : BaseEntityQueryConfig<TicketQuery, string>
{
    public override void Configure(EntityTypeBuilder<TicketQuery> builder)
    {
        base.Configure(builder);
        
        //Configs
        
        builder.ToTable("Tickets");
    }
}