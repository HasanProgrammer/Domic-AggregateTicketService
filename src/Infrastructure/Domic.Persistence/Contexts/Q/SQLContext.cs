using Domic.Core.Domain.Entities;
using Domic.Core.Persistence.Configs;
using Domic.Domain.Ticket.Entities;
using Domic.Persistence.Configs.Q;
using Microsoft.EntityFrameworkCore;

namespace Domic.Persistence.Contexts.Q;

/*Setting*/
public partial class SQLContext : DbContext
{
    public SQLContext(DbContextOptions<SQLContext> options) : base(options)
    {
        
    }
}

/*Entity*/
public partial class SQLContext
{
    public DbSet<ConsumerEventQuery> ConsumerEvents { get; set; }
    public DbSet<TicketQuery> Ticket { get; set; }
}

/*Config*/
public partial class SQLContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfiguration(new ConsumerEventQueryConfig());
        builder.ApplyConfiguration(new TicketQueryConfig());
    }
}