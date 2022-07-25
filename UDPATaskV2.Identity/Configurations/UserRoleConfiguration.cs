using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace UDPATaskV2.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId =new Guid( "cbc43a8e-f7bb-4445-baaf-1add431ffbbf"),
                    UserId = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"),
                    UserId = new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9")
                }
            );
        }
    }
}
