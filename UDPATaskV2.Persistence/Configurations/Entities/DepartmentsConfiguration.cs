using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Domain.Entities;

namespace UDPATaskV2.Persistence.Configurations.Entities
{
    public class DepartmentsConfiguration : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(x => x.ID).HasDefaultValueSql("NEWID()");
         
        }

    }
}
