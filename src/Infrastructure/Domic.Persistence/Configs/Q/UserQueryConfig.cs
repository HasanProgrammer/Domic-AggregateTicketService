using Domic.Core.Persistence.Configs;
using Domic.Domain.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domic.Persistence.Configs.Q;

public class UserQueryConfig : BaseEntityQueryConfig<UserQuery, string>
{
    public override void Configure(EntityTypeBuilder<UserQuery> builder)
    {
        base.Configure(builder);
        
        //Configs
        
        builder.ToTable("Users");
        
        //relations
    }
}