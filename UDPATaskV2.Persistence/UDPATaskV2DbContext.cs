
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UDPATaskV2.Domain.Entities;
using UDPATaskV2.Persistence.Configurations.Entities;

namespace UDPATaskV2.Persistence
{
    public class UDPATaskV2DbContext : AuditableDbContext
    {
        public UDPATaskV2DbContext(DbContextOptions<UDPATaskV2DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentsConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UDPATaskV2DbContext).Assembly);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
    }
}
