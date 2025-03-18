using Domic.Core.Persistence.Configs;
using Domic.Domain.Ticket.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domic.Persistence.Configs.Q;

public class TicketCommentQueryConfig : BaseEntityQueryConfig<TicketCommentQuery, string>
{
    public override void Configure(EntityTypeBuilder<TicketCommentQuery> builder)
    {
        base.Configure(builder);
        
        //Configs
        
        builder.ToTable("TicketComments");
        
        //relations
        
        builder.HasOne(comment => comment.Ticket)
               .WithMany(ticket => ticket.Comments)
               .HasForeignKey(comment => comment.TicketId);
    }
}