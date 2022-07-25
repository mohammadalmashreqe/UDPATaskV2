using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UDPATaskV2.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityRole<Guid>
                {
                    Id = new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"),
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole<Guid>
                {
                    Id = new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            );
        }
    }
}
