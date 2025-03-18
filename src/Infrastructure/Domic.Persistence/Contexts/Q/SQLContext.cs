using Domic.Core.Domain.Entities;
using Domic.Core.Persistence.Configs;
using Domic.Domain.Category.Entities;
using Domic.Domain.Ticket.Entities;
using Domic.Domain.User.Entities;
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
    public DbSet<TicketQuery> Tickets { get; set; }
    public DbSet<TicketCommentQuery> TicketComments { get; set; }
    public DbSet<CategoryQuery> Categories { get; set; }
    public DbSet<UserQuery> Users { get; set; }
}

/*Config*/
public partial class SQLContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfiguration(new ConsumerEventQueryConfig());
        builder.ApplyConfiguration(new TicketQueryConfig());
        builder.ApplyConfiguration(new CategoryQueryConfig());
        builder.ApplyConfiguration(new UserQueryConfig());
    }
}